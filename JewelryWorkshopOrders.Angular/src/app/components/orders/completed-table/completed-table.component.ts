import { Component, ViewChild} from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute } from '@angular/router';
import { takeUntil } from 'rxjs';
import { ICompletedOrder } from 'src/app/models/completedList';
import { NgOnDestroy } from 'src/app/services/ng-on-destroy.service';
import { OrdersService } from 'src/app/services/orders.service';

@Component({
  selector: 'app-completed-table',
  templateUrl: './completed-table.component.html',
  styleUrls: ['./../orders-table/orders-table.component.css'],
  providers: [NgOnDestroy]
})

export class CompletedTableComponent{
  displayedColumns: string[] = ['order','client','master','material','weight',
                              'startDate','endDate','price','notes','actions'];

  dataSource!:MatTableDataSource<ICompletedOrder>;

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
    })
  }

  deleteOrder(id:number){
    var index = this.dataSource.data.findIndex(e=>e.id == id);
    this.dataSource.data.splice(index,1);
    this.dataSource.paginator = this.paginator;
    this.service.delete(id)
      .pipe(takeUntil(this.destroyed$))
      .subscribe();
  }

}


