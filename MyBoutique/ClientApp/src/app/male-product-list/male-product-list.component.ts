import { Component, OnInit } from '@angular/core';
import { Product } from '../models/product';
import { ProductsService } from '../services/products.service';

@Component({
  selector: 'app-male-product-list',
  templateUrl: './male-product-list.component.html',
  styleUrls: ['./male-product-list.component.css']
})
export class MaleProductListComponent implements OnInit {
  public products = [];
  filteredProducts: Product[] = [];

  constructor(private productsService: ProductsService) { 
    this.products = [];
  }

  ngOnInit(): void {
    this.getProductsByCategory();
  }

  getProductsByCategory(): void{
    this.productsService.getAll()
    .subscribe(success => {
      if(success){
        this.products = this.productsService.products;
        this.filteredProducts = this.products.filter(p =>  {
          return p.categoryName === "Мъже"
        });
      }
    })
  }
}
