import { Component, OnInit } from '@angular/core';
import { ProductsService } from '../../_services/products.service';

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
          console.log(this.orderData);
        }
      })
  }

  completeOrder(id: number){
    this.service.completeOrderData(id)
    .subscribe(event => {
      this.subTotal = 0;
      this.getOrdersData();
    })
  }

  public removeProduct = (data) => {
    data.forEach(element => {
      console.log(element.id)
      this.service.deleteOrder(element.id)
      .subscribe(event => {
        console.log(event)
        this.getOrdersData();
      });
    });
  }
}
