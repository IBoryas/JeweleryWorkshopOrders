import { Injectable } from '@angular/core';
import {
  Router, Resolve,
  RouterStateSnapshot,
  ActivatedRouteSnapshot
} from '@angular/router';
import { Observable, of } from 'rxjs';
import { IPriceList } from 'src/app/models/priceList';
import { PriceService } from 'src/app/services/price.service';

@Injectable({
  providedIn: 'root'
})
export class GetPricesResolver implements Resolve<IPriceList[]> {

  constructor(private service:PriceService){}

  resolve(): Observable<IPriceList[]> {
    return this.service.getPrices();
  }
}
