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
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
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
@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    FooterComponent,
    ProductDetailsComponent,
    MaleProductListComponent,
    FemaleProductListComponent,
    KidProductListComponent,
    AddProductComponent,
    CartOrdersComponent,
    OrdersDetailsComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    AccountModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', redirectTo: 'products', pathMatch: 'full' },
      { path: 'products', component: HomeComponent },
      { path: 'products/:id', component: ProductDetailsComponent },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent,  },
      { path: 'male-products', component: MaleProductListComponent },
      { path: 'female-products', component: FemaleProductListComponent },
      { path: 'kid-products', component: KidProductListComponent },
      { path: 'add-product', component: AddProductComponent },
      { path: 'cart-orders', component: CartOrdersComponent },
      { path: 'orders-details', component: OrdersDetailsComponent }


    ]),
    FontAwesomeModule,
    MDBBootstrapModule.forRoot(),
    ReactiveFormsModule,
    RxReactiveFormsModule 
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
