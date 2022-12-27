import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import {AbstractControl, FormBuilder, FormGroup, Validators} from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { filter, takeUntil, tap } from 'rxjs';
import { IAdditionalData } from 'src/app/models/additionalData';
import { IClientList } from 'src/app/models/clientList';
import { IMaster } from 'src/app/models/master';
import { IMaterialContent } from 'src/app/models/materialContent';
import { IMaterialType } from 'src/app/models/matrialType';
import { IAddOrder } from 'src/app/models/orders/addOrder';
import { IPrintOrder } from 'src/app/models/orders/printOrder';
import { IProduct } from 'src/app/models/product';
import { IProductType } from 'src/app/models/productType';
import { AdditionalDataService } from 'src/app/services/additionalData.service';
import { NgOnDestroy } from 'src/app/services/ng-on-destroy.service';
import { OrdersService } from 'src/app/services/orders.service';
import { PrinterService } from 'src/app/services/printer.service';
import { PdfDialogComponent } from './pdf-dialog/pdf-dialog.component';


@Component({
  selector: 'app-new-order',
  templateUrl: './new-order.component.html',
  styleUrls: ['./new-order.component.css']
})
export class NewOrderComponent implements OnInit{
  
  constructor(
    private service: AdditionalDataService,
    private orderService: OrdersService,
    private printerService: PrinterService,
    private route:ActivatedRoute,
    private router: Router,
    private destroyed$:NgOnDestroy,
    private formBuilder:FormBuilder,
    public dialog:MatDialog) {
      this.myForm = this.formBuilder.group({
        lastName: ["",[Validators.required]],
        firstName: ["",[Validators.required]],
        patronymic: [""],
        phoneNumber: ["",[Validators.required,Validators.pattern(/^\d+$/)]],
        employee: ["",[Validators.required]],
        materialType: ["",[Validators.required]],
        material: ["",[Validators.required]],
        takenWeight: ["",[Validators.required]],
        productType: ["",[Validators.required]],
        product: ["",[Validators.required]],
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

    this.myForm.get('materialType')?.valueChanges
    .pipe(takeUntil(this.destroyed$))
    .subscribe((materialType)=>{
          this.service.getMaterialContents(materialType.id)
            .pipe(takeUntil(this.destroyed$))
            .subscribe((x)=>{
              this.materialContents = x;
            })
            
            let productId = this.myForm.get('product')?.value.id;
            if (productId){
              this.getPrice(productId,materialType.id);
            }
    })

    this.myForm.get('productType')?.valueChanges
    .pipe(takeUntil(this.destroyed$))
    .subscribe((productType) =>{
      this.service.getProducts(productType.id)
      .pipe(takeUntil(this.destroyed$))
      .subscribe((x)=>{
        this.products = x;
      })
    })

    this.myForm.get('product')?.valueChanges
    .pipe(takeUntil(this.destroyed$))
    .subscribe((product) =>{
      let materialId = this.myForm.get('materialType')?.value.id;
      if (materialId){
        this.getPrice(product.id,materialId);
      }
    })

    this.myForm.get('lastName')?.valueChanges
    .pipe(takeUntil(this.destroyed$))
    .subscribe((client) => {
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
    
    formToAddOrder():IAddOrder{
      return {
        firstName: this.myForm.get('firstName')?.value,
        lastName: this.myForm.get('lastName')?.value,
        patronymic: this.myForm.get('patronymic')?.value,
        phoneNumber: this.myForm.get('phoneNumber')?.value,
        employeeId: this.myForm.get('employee')?.value.id,
        productId: this.myForm.get('product')?.value.id,
        productTypeId: this.myForm.get('productType')?.value.id,
        materialId: this.myForm.get('material')?.value.id,
        materialTypeId: this.myForm.get('materialType')?.value.id,
        takenWeight: this.myForm.get('takenWeight')?.value,
        price: this.myForm.get('price')?.value,
        notes: this.myForm.get('notes')?.value,
      }
    }

    formToPrintOrder():IPrintOrder{
      return {
        surname: this.myForm.get('lastName')?.value,
        name: this.myForm.get('firstName')?.value,
        patronymic: this.myForm.get('patronymic')?.value,
        phone: this.myForm.get('phoneNumber')?.value,
        materialType: this.myForm.get('materialType')?.value.material,
        materialContent: this.myForm.get('material')?.value.content,
        weight: this.myForm.get('takenWeight')?.value,
        master: this.myForm.get('employee')?.value.name,
        productType: this.myForm.get('productType')?.value.categoryName,
        product: this.myForm.get('product')?.value.productName,
        price: this.myForm.get('price')?.value,
      }
    }

    printData(){
      var data = this.formToPrintOrder();
      
      this.printerService.getOrderQuittance(data)
        .pipe(takeUntil(this.destroyed$))
        .subscribe(res=>{
          let blob:Blob = res.body as Blob;
          let url = window.URL.createObjectURL(blob);
          const dialogRef = this.dialog.open(PdfDialogComponent,{
            data: url
          });

          dialogRef.afterClosed().pipe(
            filter(Boolean),
            tap(() =>{
              const iframe = document.createElement('iframe');
              iframe.style.display = 'none';
              iframe.src = url;
              document.body.appendChild(iframe);
              iframe.contentWindow?.print();
              this.sendData()
            }),
            takeUntil(this.destroyed$)
            ).subscribe();
        })
    }

    sendData(){
      
      if (this.myForm.get('notes')?.value=="")
        this.myForm.patchValue({
          notes: null
        })
      if (this.myForm.get('patronymic')?.value=="")
        this.myForm.patchValue({
          patronymic: null
        })
      
      var data = this.formToAddOrder();
      //console.log(data);
      this.orderService.create(data)
        .pipe(takeUntil(this.destroyed$))
        .subscribe(()=>{
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
