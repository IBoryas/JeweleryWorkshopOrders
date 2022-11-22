import { Component, ViewChild} from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute } from '@angular/router';
import { takeUntil } from 'rxjs';
import { IOrderList } from 'src/app/models/orders/orderList';
import { NgOnDestroy } from 'src/app/services/ng-on-destroy.service';
import { OrdersService } from 'src/app/services/orders.service';

@Component({
  selector: 'app-orders-table',
  templateUrl: './orders-table.component.html',
  styleUrls: ['./orders-table.component.css'],
  providers: [NgOnDestroy]
})

export class OrdersTableComponent{
  
  displayedColumns: string[] = ['order','client','master','material','weight','date','price','notes','actions'];
  dataSource!:MatTableDataSource<IOrderList>;

  @ViewChild(MatPaginator, { static: true }) paginator!: MatPaginator;

  constructor(
    private route:ActivatedRoute, 
    private destroyed$:NgOnDestroy, 
    private service:OrdersService){}
  
  ngOnInit()
  {
    this.route.data.pipe(takeUntil(this.destroyed$)).subscribe((data) => {
      this.dataSource = new MatTableDataSource(data['orders']);
      this.dataSource.paginator = this.paginator;
      console.log(this.dataSource);
    })
  }

  applyFilter(event: Event) {
    let target = event.target as HTMLInputElement;
    let filterValue = target.value;
    filterValue = filterValue.trim();
    filterValue = filterValue.toLowerCase();
    this.dataSource.filter = filterValue;
  }

  deleteOrder(id:number){
    var index = this.dataSource.data.findIndex(e=>e.id == id);
    this.dataSource.data.splice(index,1);
    this.dataSource.paginator = this.paginator;
    this.service.delete(id)
      .pipe(takeUntil(this.destroyed$))
      .subscribe();
  }

  completeOrder(id:number){
    var index = this.dataSource.data.findIndex(e=>e.id == id);
    this.dataSource.data.splice(index,1);
    this.dataSource.paginator = this.paginator;
    this.service.complete(id)
      .pipe(takeUntil(this.destroyed$))
      .subscribe();
  }

}


