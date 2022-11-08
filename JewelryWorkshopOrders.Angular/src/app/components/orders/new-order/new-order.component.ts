import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import {AbstractControl, FormBuilder, FormGroup, Validators} from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { takeUntil } from 'rxjs';
import { IAdditionalData } from 'src/app/models/additionalData';
import { IClientList } from 'src/app/models/clientList';
import { IMaster } from 'src/app/models/master';
import { IMaterialContent } from 'src/app/models/materialContent';
import { IMaterialType } from 'src/app/models/matrialType';
import { IProduct } from 'src/app/models/product';
import { IProductType } from 'src/app/models/productType';
import { AdditionalDataService } from 'src/app/services/additionalData.service';
import { NgOnDestroy } from 'src/app/services/ng-on-destroy.service';
import { OrdersService } from 'src/app/services/orders.service';


@Component({
  selector: 'app-new-order',
  templateUrl: './new-order.component.html',
  styleUrls: ['./new-order.component.css']
})
export class NewOrderComponent implements OnInit{
  
  constructor(
    private service: AdditionalDataService,
    private orderService: OrdersService,
    private route:ActivatedRoute,
    private router: Router,
    private destroyed$:NgOnDestroy,
    private formBuilder:FormBuilder) {
      this.myForm = this.formBuilder.group({
        lastName: ["",[Validators.required]],
        firstName: ["",[Validators.required]],
        patronymic: [""],
        phoneNumber: ["",[Validators.required,Validators.pattern(/^\d+$/)]],
        employeeId: ["",[Validators.required]],
        materialType: ["",[Validators.required]],
        materialId: ["",[Validators.required]],
        takenWeight: ["",[Validators.required]],
        productType: ["",[Validators.required]],
        productId: ["",[Validators.required]],
        price: ["",[Validators.required]],
        notes: [""]
      })
    }
    
    myForm!:FormGroup;


    ngOnInit(): void {
      this.route.data
      .pipe(takeUntil(this.destroyed$))
      .subscribe((x)=>{
        let data:IAdditionalData = x['data'];
        this.materials = data[0];
        this.masters = data[1];
        this.productTypes = data[2];
        this.clients=data[3];
    })

    this.myForm.get('materialType')?.valueChanges.subscribe((id)=>{
          this.service.getMaterialContents(id)
            .pipe(takeUntil(this.destroyed$))
            .subscribe((x)=>{
              this.materialContents = x;
            })
            
            let productId = this.myForm.get('productId')?.value;
            if (productId){
              this.getPrice(productId,id);
            }
    })

    this.myForm.get('productType')?.valueChanges.subscribe((id) =>{
      this.service.getProducts(id)
      .pipe(takeUntil(this.destroyed$))
      .subscribe((x)=>{
        this.products = x;
      })
    })

    this.myForm.get('productId')?.valueChanges.subscribe((id) =>{
      let materialId = this.myForm.get('materialType')?.value;
      if (materialId){
        this.getPrice(id,materialId);
      }
    })

    this.myForm.get('lastName')?.valueChanges.subscribe((client) => {
      var id = this.clients.find(x => x.clientData === client)?.id;
      if (id)
      {
        this.isClientLoad = true;
        this.service.getClientById(id)
          .pipe(takeUntil(this.destroyed$))  
          .subscribe((x)=>{
            let clientPatronymic:string;
            if(x.patronymic)
              clientPatronymic=x.patronymic;
            else
              clientPatronymic=""; 
            this.myForm.patchValue({
              lastName: x.lastName,
              firstName: x.firstName,
              patronymic: clientPatronymic,
              phoneNumber: x.phoneNumber
            })
            this.isClientLoad = false;
        })
      }
    })
  }

    getPrice(product:number,material:number){
      this.service.getPrice(product,material)
      .pipe(takeUntil(this.destroyed$))
      .subscribe((x)=>{
        let price:number|string;
        if (x)
          price = x.price;
        else
          price="";
        this.myForm.patchValue({
            price: price
        })
      })
    }
    
    isClientLoad:boolean = false;
    
    sendData(){
      
      if (this.myForm.get('notes')?.value=="")
        this.myForm.patchValue({
          notes: null
        })
      if (this.myForm.get('patronymic')?.value=="")
        this.myForm.patchValue({
          patronymic: null
        })
      var data = this.myForm.value;
      // console.log(data);
      this.orderService.create(data).subscribe(()=>{
        this.router.navigate(['/currentOrders']);
      });
    }
    
  materials:IMaterialType[] = [];
  masters:IMaster[] = [];
  productTypes:IProductType[] = [];
  materialContents:IMaterialContent[] = [];
  products:IProduct[] =[];
  clients:IClientList[] =[];

}
