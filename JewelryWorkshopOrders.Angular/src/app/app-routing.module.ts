import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { IndexComponent } from './components/index/index.component';
import { CompletedTableComponent } from './components/orders/completed-table/completed-table.component';
import { CompletedTableResolver } from './components/orders/completed-table/completed-table.resolver';
import { NewOrderComponent } from './components/orders/new-order/new-order.component';
import { NewOrderResolver } from './components/orders/new-order/new-order.resolver';
import { OrdersTableComponent } from './components/orders/orders-table/orders-table.component';
import { OrdersTableResolver } from './components/orders/orders-table/orders-table.resolver';
import { UpdateOrderComponent } from './components/orders/update-order/update-order.component';
import { UpdateOrderGuard } from './components/orders/update-order/update-order.guard';
import { UpdateOrderResolver } from './components/orders/update-order/update-order.resolver';
import { GetMaterialsResolver} from './components/prices/getmaterials.resolver';
import { GetPricesResolver } from './components/prices/getprices.resolver';
import { PricesComponent } from './components/prices/prices.component';

const routes: Routes = [
  {
    path: 'currentOrders',
    component: OrdersTableComponent,
    resolve: {
      orders: OrdersTableResolver
    }
  },
  {
    path: 'completedOrders',
    component: CompletedTableComponent,
    resolve: {
      orders: CompletedTableResolver
    }
  },
  {
    path: 'newOrder',
    component: NewOrderComponent,
    resolve: {
      data: NewOrderResolver
    }
  },
  {
    path: "updateOrder/:id",
    component: UpdateOrderComponent,
    canActivate: [UpdateOrderGuard],
    resolve: {
      order: UpdateOrderResolver,
      info: NewOrderResolver 
    },
  },
  {
    path: "prices",
    component: PricesComponent,
    resolve:{
      materials: GetMaterialsResolver,
      prices: GetPricesResolver
    }
  },
  {
    path: '**',
    component: IndexComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
