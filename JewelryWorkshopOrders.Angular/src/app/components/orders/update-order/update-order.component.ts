import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { takeUntil } from 'rxjs';
import { IAdditionalData } from 'src/app/models/additionalData';
import { IClientList } from 'src/app/models/clientList';
import { IMaster } from 'src/app/models/master';
import { IMaterialContent } from 'src/app/models/materialContent';
import { IMaterialType } from 'src/app/models/matrialType';
import { IOrder } from 'src/app/models/orderInfo';
import { IProduct } from 'src/app/models/product';
import { IProductType } from 'src/app/models/productType';
import { AdditionalDataService } from 'src/app/services/additionalData.service';
import { NgOnDestroy } from 'src/app/services/ng-on-destroy.service';
import { OrdersService } from 'src/app/services/orders.service';

@Component({
  selector: 'app-update-order',
  templateUrl: './update-order.component.html',
  styleUrls: ['./../new-order/new-order.component.css']
})
export class UpdateOrderComponent implements OnInit {

  order!:IOrder
  id!:number;

  constructor(
    private service: AdditionalDataService,
    private orderService: OrdersService,
    private route:ActivatedRoute,
    private router: Router,
    private destroyed$:NgOnDestroy,
    private formBuilder:FormBuilder) {}
    
    myForm!:FormGroup;
    
    
    ngOnInit(): void {
      this.myForm = this.formBuilder.group({
        lastName: ["", [Validators.required]],
        firstName: ["", [Validators.required]],
        patronymic: [""],
        phoneNumber: ["", [Validators.required,Validators.pattern(/^\d+$/)]],
        employeeId: ["", [Validators.required]],
        materialType: ["", [Validators.required]],
        materialId: ["", [Validators.required]],
        takenWeight: ["", [Validators.required]],
        productType: ["", [Validators.required]],
        productId: ["", [Validators.required]],
        price: ["", [Validators.required]],
        notes: [""]
      })
      
      this.route.data
      .pipe(takeUntil(this.destroyed$))
      .subscribe((x)=>{
        let data:IAdditionalData = x['info'];
        this.materials = data[0];
        this.masters = data[1];
        this.productTypes = data[2];
        this.clients=data[3];
      })
      
      this.route.data
        .pipe(takeUntil(this.destroyed$))
        .subscribe((data)=>{
          this.order = data['order'];
          this.id = this.order.id;
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

      this.myForm.patchValue({
            lastName: this.order.clientFullName,
              employeeId: this.order.employeeId,
              materialType: this.order.materialTypeId, 
              materialId: this.order.materialId, 
              takenWeight: this.order.takenWeight,
              productType: this.order.productTypeId,
              productId:this.order.productId, 
              price: this.order.price,
              notes: this.order.notes
          })
  }

  recommendedPrice!:number|string;

    getPrice(product:number,material:number){
      this.service.getPrice(product,material)
      .pipe(takeUntil(this.destroyed$))
      .subscribe((x)=>{
        if (x)
          this.recommendedPrice = x.price;
        else
          this.recommendedPrice="";
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
      this.orderService.update(this.id,data).subscribe(()=>{
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
