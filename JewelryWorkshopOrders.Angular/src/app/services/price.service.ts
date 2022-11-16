import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IPriceList } from '../models/priceList';
import { environment as env } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PriceService {

  constructor(private http: HttpClient) { }

  getPrices():Observable<IPriceList[]>{
    return this.http.get<IPriceList[]>(`${env.dev.serverUrl}/api/pricelist`);
  }

  updatePrice(data:IPriceList){
    return this.http.patch(`${env.dev.serverUrl}/api/pricelist`,data);
  }
}
