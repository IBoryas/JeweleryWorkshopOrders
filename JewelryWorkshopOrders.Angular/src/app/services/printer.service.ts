import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IPrintOrder } from '../models/orders/printOrder';

@Injectable({
  providedIn: 'root'
})
export class PrinterService {

  constructor(private http: HttpClient) { }

  getOrderQuittance(order:any){
    return this.http.get('/api/print',{
      params: order,
      observe: 'response',
      responseType: 'blob'
    });
  }
}
