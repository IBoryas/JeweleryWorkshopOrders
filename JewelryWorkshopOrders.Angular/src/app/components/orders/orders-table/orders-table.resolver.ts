import { Injectable } from '@angular/core';
import { Resolve } from '@angular/router';
import { Observable, of } from 'rxjs';
import { IOrderList } from 'src/app/models/orders/orderList';
import { OrdersService } from 'src/app/services/orders.service';

@Injectable({
  providedIn: 'root'
})
export class OrdersTableResolver implements Resolve<IOrderList[]> {

  constructor(private service:OrdersService){}

  resolve(): Observable<IOrderList[]> {
    return this.service.getAll();
  }
}
