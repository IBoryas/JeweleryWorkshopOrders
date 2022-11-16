import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AuthModule, AuthHttpInterceptor } from '@auth0/auth0-angular';
import { PdfViewerModule } from 'ng2-pdf-viewer';

import { environment as env } from '../environments/environment';
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
import { LoginLogoutComponent } from './components/login-logout/login-logout.component';
import { PdfDialogComponent } from './components/orders/new-order/pdf-dialog/pdf-dialog.component';


@NgModule({
  declarations: [
    AppComponent,
    IndexComponent,
    HeaderComponent,
    OrdersTableComponent,
    CompletedTableComponent,
    NewOrderComponent,
    UpdateOrderComponent,
    PricesComponent,
    LoginLogoutComponent,
    PdfDialogComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    AngularMaterialModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    AuthModule.forRoot({
      ...env.auth,
      httpInterceptor: {
        allowedList: [`${env.dev.serverUrl}/api/*`],
      },
    }),
    PdfViewerModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthHttpInterceptor,
      multi: true,
    },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
