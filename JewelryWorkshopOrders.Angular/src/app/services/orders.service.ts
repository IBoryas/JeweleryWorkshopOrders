import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { ICompletedOrder } from '../models/completedList';
import { IOrder } from '../models/orderInfo';
import { IOrderList } from '../models/orderList';

@Injectable({
  providedIn: "root"
})
export class OrdersService {

  constructor(private http:HttpClient) { }

  getAll():Observable<IOrderList[]>{
    return this.http.get<IOrderList[]>('/api/orders');
  } 
 
  delete(id:number):Observable<any>{
    return this.http.delete(`/api/orders/${id}`)
  }

  complete(id:number):Observable<any>{
    return this.http.patch(`/api/orders/${id}`,"")
  }

  getCompleted():Observable<ICompletedOrder[]>{
    return this.http.get<ICompletedOrder[]>('/api/orders/completed');
  }

  create(data:any):Observable<any>{
    return this.http.post('/api/orders',data);
  }

  getByID(id:string):Observable<IOrder>{
    return this.http.get<IOrder>(`/api/orders/${id}`);
  }

  update(id:number,data:any):Observable<any>{
    return this.http.put(`/api/orders/${id}`,data);
  }
}
