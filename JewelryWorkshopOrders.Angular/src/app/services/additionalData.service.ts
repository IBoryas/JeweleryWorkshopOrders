import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IClient } from '../models/client';
import { IClientList } from '../models/clientList';
import { IMaster } from '../models/master';
import { IMaterialContent } from '../models/materialContent';
import { IMaterialType } from '../models/matrialType';
import { IPrice } from '../models/price';
import { IProduct } from '../models/product';
import { IProductType } from '../models/productType';
import { environment as env } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AdditionalDataService {

  constructor(private http:HttpClient) { }

  getMaterialTypes():Observable<IMaterialType[]>{
    return this.http.get<IMaterialType[]>(`${env.dev.serverUrl}/api/materialtypes`);
  }

  getMasters():Observable<IMaster[]>{
    return this.http.get<IMaster[]>(`${env.dev.serverUrl}/api/employees`);
  }

  getProductTypes():Observable<IProductType[]>{
    return this.http.get<IProductType[]>(`${env.dev.serverUrl}/api/productcategory`)
  }

  getCLients():Observable<IClientList[]>{
    return this.http.get<IClientList[]>(`${env.dev.serverUrl}/api/clients`);
  }

  getMaterialContents(id:number):Observable<IMaterialContent[]>{
    return this.http.get<IMaterialContent[]>(`${env.dev.serverUrl}/api/materials/${id}`)
  }

  getProducts(id:number):Observable<IProduct[]>{
    return this.http.get<IProduct[]>(`${env.dev.serverUrl}/api/products/${id}`)
  }

  getClientById(id:number):Observable<IClient>{
    return this.http.get<IClient>(`${env.dev.serverUrl}/api/clients/${id}`)
  }

  getPrice(product:number, material:number):Observable<IPrice>{
    return this.http.get<IPrice>(`${env.dev.serverUrl}/api/pricelist/${product}/${material}`)
  }
}
