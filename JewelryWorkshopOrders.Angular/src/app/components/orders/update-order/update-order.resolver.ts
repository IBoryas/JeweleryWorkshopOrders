import { Injectable } from '@angular/core';
import {
  Router, Resolve,
  RouterStateSnapshot,
  ActivatedRouteSnapshot
} from '@angular/router';
import { Observable, of } from 'rxjs';
import { IOrder } from 'src/app/models/orders/orderInfo';
import { OrdersService } from 'src/app/services/orders.service';

@Injectable({
  providedIn: 'root'
})
export class UpdateOrderResolver implements Resolve<IOrder> {

  constructor(private service:OrdersService){}

  resolve(route: ActivatedRouteSnapshot): Observable<IOrder> {
    const id = route.paramMap.get('id');
    if(!id)
      throw new Error("Parameter 'id' is missing");
      
    return this.service.getByID(id);
  }
}
