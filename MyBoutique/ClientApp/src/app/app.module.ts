import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import { RxReactiveFormsModule } from "@rxweb/reactive-form-validators"

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { FooterComponent } from './footer/footer.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { MaleProductListComponent } from './male-product-list/male-product-list.component';
import { FemaleProductListComponent } from './female-product-list/female-product-list.component';
import { KidProductListComponent } from './kid-product-list/kid-product-list.component';
import { AddProductComponent } from './add-product/add-product.component';
import { CartOrdersComponent } from './cart-orders/cart-orders.component';
import { OrdersDetailsComponent } from './orders-details/orders-details.component';
import { AccountModule } from './account/account.module';
import { AlertComponent } from './alert/alert.component';
import { SuccessfullOrderComponent } from './successfull-order/successfull-order.component';
import { RegisterComponent } from './account/register.component';
import { routes } from '../_helpers/routerConfig';
import { CacheInterceptor } from '../_services/cache.interceptor';
import { CookieService } from 'ngx-cookie-service';
import { EditProductComponent } from './edit-product/edit-product.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    FooterComponent,
    ProductDetailsComponent,
    MaleProductListComponent,
    FemaleProductListComponent,
    KidProductListComponent,
    AddProductComponent,
    CartOrdersComponent,
    OrdersDetailsComponent,
    AlertComponent,
    SuccessfullOrderComponent,
    EditProductComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    AccountModule,
    FormsModule,
    RouterModule.forRoot(routes),
    FontAwesomeModule,
    MDBBootstrapModule.forRoot(),
    ReactiveFormsModule,
    RxReactiveFormsModule 
  ],
  providers: [  
    { provide: HTTP_INTERCEPTORS, useClass: CacheInterceptor, multi: true },
     CookieService
  ],  

  bootstrap: [AppComponent]
})
export class AppModule { }
