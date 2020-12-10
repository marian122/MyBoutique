import { Component, OnInit } from '@angular/core';
import { ProductsService } from '../services/products.service';

@Component({
  selector: 'app-orders-details',
  templateUrl: './orders-details.component.html',
  styleUrls: ['./orders-details.component.css']
})
export class OrdersDetailsComponent implements OnInit {
  public orderData = [];
  public subTotal = 0;

  constructor(private service: ProductsService) { 
    this.orderData = [];
    this.subTotal = 0;
  }

  ngOnInit(): void {
    this.getOrdersData();
  }

  getOrdersData(): void {
    this.service.getAllOrderData()
      .subscribe(success => {
        if (success) {
          this.orderData = this.service.orderData;
          this.subTotal = this.service.subTotal;
          console.log(this.orderData)
        }
      })
  }

}
