import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment as env } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PrinterService {

  constructor(private http: HttpClient) { }

  getOrderQuittance(order:any){
    return this.http.get(`${env.dev.serverUrl}/api/print`,{
      params: order,
      observe: 'response',
      responseType: 'blob'
    });
  }
}
