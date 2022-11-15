import { HttpClient } from '@angular/common/http';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute } from '@angular/router';
import { takeUntil } from 'rxjs';
import { IMaterialType } from 'src/app/models/matrialType';
import { IPriceList } from 'src/app/models/priceList';
import { NgOnDestroy } from 'src/app/services/ng-on-destroy.service';
import { PriceService } from 'src/app/services/price.service';

@Component({
  selector: 'app-prices',
  templateUrl: './prices.component.html',
  styleUrls: ['./prices.component.css']
})
export class PricesComponent implements OnInit {

  constructor(private route:ActivatedRoute, 
    private destroyed$:NgOnDestroy,
    private service:PriceService){}

  tabs:string[] = [];

  displayedColumns: string[] = ['material','productCategory','product','price','actions'];
  
  materials!:IMaterialType[];

  dataSources:MatTableDataSource<IPriceList>[] = [];

  @ViewChild(MatSort) sort!: MatSort;
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  ngOnInit(): void {

    this.route.data.pipe(takeUntil(this.destroyed$)).subscribe((data)=>{
      this.materials = data['materials'];
      for (let x = 0; x < this.materials.length; x++) {
         this.tabs.push(this.materials[x].material);
         this.dataSources.push(new MatTableDataSource())
        }
    })

  }
  
  ngAfterViewInit(){
    
    this.route.data.pipe(takeUntil(this.destroyed$)).subscribe((data)=>{
      let prices:IPriceList[]=data['prices']
      for (let x = 0; x < this.materials.length; x++) {
        this.dataSources[x] = new MatTableDataSource(prices.filter(p=> p.materialId == this.materials[x].id));
        this.dataSources[x].sort = this.sort;
        this.dataSources[x].paginator = this.paginator;
        console.log(this.dataSources[x]);
     }
    })

  }

  updatePrice(price:IPriceList){
    if(price.price>0){
      this.service.updatePrice(price).pipe(takeUntil(this.destroyed$)).subscribe();
    }
  }


}
