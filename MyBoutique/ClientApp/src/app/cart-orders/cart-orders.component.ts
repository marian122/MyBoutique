import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ProductsService } from '../services/products.service';

@Component({
  selector: 'app-cart-orders',
  templateUrl: './cart-orders.component.html',
  styleUrls: ['./cart-orders.component.css']
})
export class CartOrdersComponent implements OnInit {
  public orders = [];
  public subTotal = 0;
  form: FormGroup;
  
  constructor(private service: ProductsService,
              private formBuilder: FormBuilder) { 
    this.orders = [];
    this.subTotal = 0;
  }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      name: ['', [Validators.required, Validators.minLength(2)]],
      description: ['', [Validators.required, Validators.minLength(2)]]
    });
    this.getOrdersBySessionId();
    
    
  }

  getOrdersBySessionId(): void {
    this.service.getAllOrders()
    .subscribe(success => {
      if(success){
        this.orders = this.service.orders;
        this.subTotal = this.service.subTotal;
        console.log(this.orders)
      }
    })
  }

  incrementQTY(item: any){
    if(item.quantity >= 1){
      item.quantity += 1;
      item.totalPrice = item.product.price * item.quantity;
      console.log(item)
    }
    
  }

  decrementQTY(item: any){
    if(item.quantity > 1){
      item.quantity -= 1;
      item.totalPrice -= item.product.price;
    }
  }

  public removeProduct = (id: number) => {
    this.service.deleteProductFromCart(id)
    .subscribe(event => {
      console.log(event);
      this.getOrdersBySessionId()
    });
  }

}
