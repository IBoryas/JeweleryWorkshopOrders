import { Injectable } from '@angular/core';
import {
  Router, Resolve,
  RouterStateSnapshot,
  ActivatedRouteSnapshot
} from '@angular/router';
import { Observable, of } from 'rxjs';
import { IMaterialType } from 'src/app/models/matrialType';
import { AdditionalDataService } from 'src/app/services/additionalData.service';

@Injectable({
  providedIn: 'root'
})
export class GetMaterialsResolver implements Resolve<IMaterialType[]> {

  constructor(private service:AdditionalDataService){}

  resolve(): Observable<IMaterialType[]> {
    return this.service.getMaterialTypes();
  }
}
