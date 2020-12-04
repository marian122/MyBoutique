import { Component, OnInit } from '@angular/core';
import { Product } from '../models/product';
import { ProductsService } from '../services/products.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-female-product-list',
  templateUrl: './female-product-list.component.html',
  styleUrls: ['./female-product-list.component.css']
})
export class FemaleProductListComponent implements OnInit {
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
          return p.categoryName === "Жени"
        });
      }
    })
  }

}
