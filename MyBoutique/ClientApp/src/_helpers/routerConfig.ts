import { Routes } from '@angular/router'; 
import { AddProductComponent } from '../app/add-product/add-product.component';
import { CartOrdersComponent } from '../app/cart-orders/cart-orders.component';
import { FemaleProductListComponent } from '../app/female-product-list/female-product-list.component';
import { HomeComponent } from '../app/home/home.component';
import { KidProductListComponent } from '../app/kid-product-list/kid-product-list.component';
import { MaleProductListComponent } from '../app/male-product-list/male-product-list.component';
import { OrdersDetailsComponent } from '../app/orders-details/orders-details.component';
import { ProductDetailsComponent } from '../app/product-details/product-details.component';
import { SuccessfullOrderComponent } from '../app/successfull-order/successfull-order.component';
import { EditProductComponent } from '../app/edit-product/edit-product.component';

export const routes: Routes = [    
    { path: 'products', component: HomeComponent },
      { path: 'products/:id', component: ProductDetailsComponent },
      { path: 'male-products', component: MaleProductListComponent },
      { path: 'female-products', component: FemaleProductListComponent },
      { path: 'kid-products', component: KidProductListComponent },
      { path: 'add-product', component: AddProductComponent },
      { path: 'edit-product/:id', component: EditProductComponent },
      { path: 'cart-orders', component: CartOrdersComponent },
      { path: 'orders-details', component: OrdersDetailsComponent },
      { path: 'successfull-order', component: SuccessfullOrderComponent },
      
];    


