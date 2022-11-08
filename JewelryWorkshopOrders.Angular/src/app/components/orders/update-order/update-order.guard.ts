import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { IOrderList } from 'src/app/models/orderList';
import { OrdersService } from 'src/app/services/orders.service';

@Injectable({
  providedIn: 'root'
})
export class UpdateOrderGuard implements CanActivate {

  constructor(private router:Router, private service: OrdersService) {}

  canActivate(
    route: ActivatedRouteSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {

    const id = Number(route.paramMap.get('id'));

    if (!id || isNaN(id)){
      this.router.navigateByUrl('/');
    }

    this.service.getAll().subscribe((data)=>{
      if (!(data.find(o=> o.id == id)))
        this.router.navigateByUrl('/');
    });

    
      return true;
  }
  
}
