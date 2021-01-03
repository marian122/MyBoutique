import { Component, OnInit } from '@angular/core';
import { ProductsService } from '../../_services/products.service';
import { OrderService } from '../../_services/order.service';
import { ShoppingCartService } from '../../_services/shopping-cart.service';

@Component({
  selector: 'app-orders-details',
  templateUrl: './orders-details.component.html',
  styleUrls: ['./orders-details.component.css']
})
export class OrdersDetailsComponent implements OnInit {
  public orderData = [];
  public subTotal = 0;

  constructor(private productService: ProductsService,
    private orderService: OrderService,
    private shoppingCartService: ShoppingCartService) { 
    this.orderData = [];
    this.subTotal = 0;
  }

  ngOnInit(): void {
    this.getOrdersData();
  }

  getOrdersData(): void {
    this.shoppingCartService.getAllOrderData()
      .subscribe(success => {
        if (success) {
          this.orderData = this.shoppingCartService.orderData;
        }
      })
  }

  completeOrder(id: number){
    this.shoppingCartService.completeOrderData(id)
    .subscribe(event => {
      this.subTotal = 0;
      this.getOrdersData();
    })
  }

  public removeProduct = (data) => {
    data.forEach(element => {
      console.log(element.id)
      this.orderService.deleteOrder(element.id)
      .subscribe(event => {
        this.getOrdersData();
      });
    });
  }
}
