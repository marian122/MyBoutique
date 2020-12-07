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
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { FooterComponent } from './footer/footer.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { MaleProductListComponent } from './male-product-list/male-product-list.component';
import { FemaleProductListComponent } from './female-product-list/female-product-list.component';
import { KidProductListComponent } from './kid-product-list/kid-product-list.component';
import { DiscountProductListComponent } from './discount-product-list/discount-product-list.component';
import { AddProductComponent } from './add-product/add-product.component';
import { UnderwearComponent } from './male-product-list/underwear/underwear.component';
import { FemaleBlouseComponent } from './female-product-list/female-blouse/female-blouse.component';
import { FemaleShirtComponent } from './female-product-list/female-shirt/female-shirt.component';
import { FemaleUnionsuitComponent } from './female-product-list/female-unionsuit/female-unionsuit.component';
import { FemaleJacketsComponent } from './female-product-list/female-jackets/female-jackets.component';
import { FemaleCoatsComponent } from './female-product-list/female-coats/female-coats.component';
import { FemaleSkirtsComponent } from './female-product-list/female-skirts/female-skirts.component';
import { FemalePantsComponent } from './female-product-list/female-pants/female-pants.component';
import { FemaleSingletsComponent } from './female-product-list/female-singlets/female-singlets.component';
import { FemaleTunicsComponent } from './female-product-list/female-tunics/female-tunics.component';
import { FemaleScarvesComponent } from './female-product-list/female-scarves/female-scarves.component';
import { FemaleUnderwearComponent } from './female-product-list/female-underwear/female-underwear.component';
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
    DiscountProductListComponent,
    AddProductComponent,
    UnderwearComponent,
    FemaleBlouseComponent,
    FemaleShirtComponent,
    FemaleUnionsuitComponent,
    FemaleJacketsComponent,
    FemaleCoatsComponent,
    FemaleSkirtsComponent,
    FemalePantsComponent,
    FemaleSingletsComponent,
    FemaleTunicsComponent,
    FemaleScarvesComponent,
    FemaleUnderwearComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ApiAuthorizationModule,
    RouterModule.forRoot([
      { path: '', redirectTo: 'products', pathMatch: 'full' },
      { path: 'products', component: HomeComponent },
      { path: 'products/:id', component: ProductDetailsComponent },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent, canActivate: [AuthorizeGuard] },
      { path: 'male-products', component: MaleProductListComponent },
      { path: 'female-products', component: FemaleProductListComponent },
      { path: 'kid-products', component: KidProductListComponent },
      { path: 'discount-products', component: DiscountProductListComponent },
      { path: 'add-product', component: AddProductComponent },
      { path: 'male-products/underwear', component: UnderwearComponent },
      { path: 'female-products/blouses', component: FemaleBlouseComponent },
      { path: 'female-products/underwear', component: FemaleUnderwearComponent }


    ]),
    FontAwesomeModule,
    MDBBootstrapModule.forRoot(),
    ReactiveFormsModule,
    RxReactiveFormsModule 
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
