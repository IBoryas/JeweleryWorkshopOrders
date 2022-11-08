import { Injectable } from '@angular/core';
import {
  Router, Resolve,
  RouterStateSnapshot,
  ActivatedRouteSnapshot
} from '@angular/router';
import { forkJoin, Observable, of } from 'rxjs';
import { IAdditionalData } from "src/app/models/additionalData"
import { IMaster } from 'src/app/models/master';
import { IMaterialType } from 'src/app/models/matrialType';
import { IProductType } from 'src/app/models/productType';
import { AdditionalDataService } from 'src/app/services/additionalData.service';

@Injectable({
  providedIn: 'root'
})
export class NewOrderResolver implements Resolve<IAdditionalData> {

  constructor(private service:AdditionalDataService){}

  resolve(): Observable<IAdditionalData> {
    let materials = this.service.getMaterialTypes();
    let masters = this.service.getMasters();
    let productTypes = this.service.getProductTypes();
    let clients = this.service.getCLients();
    return forkJoin([materials,masters,productTypes,clients]); 
  }
}
