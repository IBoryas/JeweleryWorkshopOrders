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

@Injectable({
  providedIn: 'root'
})
export class AdditionalDataService {

  constructor(private http:HttpClient) { }

  getMaterialTypes():Observable<IMaterialType[]>{
    return this.http.get<IMaterialType[]>('/api/materialtypes');
  }

  getMasters():Observable<IMaster[]>{
    return this.http.get<IMaster[]>('/api/employees');
  }

  getProductTypes():Observable<IProductType[]>{
    return this.http.get<IProductType[]>('/api/productcategory')
  }

  getCLients():Observable<IClientList[]>{
    return this.http.get<IClientList[]>('/api/clients');
  }

  getMaterialContents(id:number):Observable<IMaterialContent[]>{
    return this.http.get<IMaterialContent[]>(`/api/materials/${id}`)
  }

  getProducts(id:number):Observable<IProduct[]>{
    return this.http.get<IProduct[]>(`/api/products/${id}`)
  }

  getClientById(id:number):Observable<IClient>{
    return this.http.get<IClient>(`/api/clients/${id}`)
  }

  getPrice(product:number, material:number):Observable<IPrice>{
    return this.http.get<IPrice>(`/api/pricelist/${product}/${material}`)
  }
}
