import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { ICompletedOrder } from '../models/orders/completedOrdersList';
import { IOrder } from '../models/orders/orderInfo';
import { IOrderList } from '../models/orders/orderList';
import { environment as env } from 'src/environments/environment';

@Injectable({
  providedIn: "root"
})
export class OrdersService {

  constructor(private http:HttpClient) { }

  getAll():Observable<IOrderList[]>{
    return this.http.get<IOrderList[]>(`${env.dev.serverUrl}/api/orders`);
  } 
 
  delete(id:number):Observable<any>{
    return this.http.delete(`${env.dev.serverUrl}/api/orders/${id}`)
  }

  complete(id:number):Observable<any>{
    return this.http.patch(`${env.dev.serverUrl}/api/orders/${id}`,"")
  }

  getCompleted():Observable<ICompletedOrder[]>{
    return this.http.get<ICompletedOrder[]>(`${env.dev.serverUrl}/api/orders/completed`);
  }

  create(data:any):Observable<any>{
    return this.http.post(`${env.dev.serverUrl}/api/orders`,data);
  }

  getByID(id:string):Observable<IOrder>{
    return this.http.get<IOrder>(`${env.dev.serverUrl}/api/orders/${id}`);
  }

  update(id:number,data:any):Observable<any>{
    return this.http.put(`${env.dev.serverUrl}/api/orders/${id}`,data);
  }
}
