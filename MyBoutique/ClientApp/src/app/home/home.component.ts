import { Component, OnInit } from '@angular/core';
import { ProductsService } from '../../_services/products.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit{
  public products = [];
  isLoggedIn;

  constructor(private productsService: ProductsService) { 
    this.products = [];
  }

  ngOnInit(): void {
    this.getAllProducts();
    this.isLoggedIn = localStorage.getItem("user");
  }

  getAllProducts(): void{
    this.productsService.getAll()
    .subscribe(success => {
      if(success){
        this.products = this.productsService.products 
        console.log(this.products)
      }
    })
  }
}
