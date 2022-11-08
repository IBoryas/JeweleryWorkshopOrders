import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgxMatSelectSearchModule } from 'ngx-mat-select-search';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { IndexComponent } from './components/index/index.component';
import { HeaderComponent } from './components/header/header.component';
import { OrdersTableComponent } from './components/orders/orders-table/orders-table.component';
import { AngularMaterialModule } from './modules/angular-material.module';
import { CompletedTableComponent } from './components/orders/completed-table/completed-table.component';
import { NewOrderComponent } from './components/orders/new-order/new-order.component';
import { UpdateOrderComponent } from './components/orders/update-order/update-order.component';
import { PricesComponent } from './components/prices/prices.component';


@NgModule({
  declarations: [
    AppComponent,
    IndexComponent,
    HeaderComponent,
    OrdersTableComponent,
    CompletedTableComponent,
    NewOrderComponent,
    UpdateOrderComponent,
    PricesComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    AngularMaterialModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    NgxMatSelectSearchModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
