import { Injectable } from '@angular/core';
import {
  Router, Resolve,
  RouterStateSnapshot,
  ActivatedRouteSnapshot
} from '@angular/router';
import { Observable, of } from 'rxjs';
import { ICompletedOrder } from 'src/app/models/completedList';
import { OrdersService } from 'src/app/services/orders.service';

@Injectable({
  providedIn: 'root'
})
export class CompletedTableResolver implements Resolve<ICompletedOrder[]> {

  constructor(private service:OrdersService){}

  resolve(): Observable<ICompletedOrder[]> {
    return this.service.getCompleted();
  }
}
