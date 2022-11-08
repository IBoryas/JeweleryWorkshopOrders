import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IPriceList } from '../models/priceList';

@Injectable({
  providedIn: 'root'
})
export class PriceService {

  constructor(private http: HttpClient) { }

  getPrices():Observable<IPriceList[]>{
    return this.http.get<IPriceList[]>('/api/pricelist');
  }

  updatePrice(data:IPriceList){
    return this.http.patch('/api/pricelist',data);
  }
}
