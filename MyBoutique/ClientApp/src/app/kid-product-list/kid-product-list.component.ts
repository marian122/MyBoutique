import { Component, OnInit } from '@angular/core';
import { CategoryConstants } from '../../environments/CategoryConstants';
import { Product } from '../models/product';
import { ProductsService } from '../services/products.service';

@Component({
  selector: 'app-kid-product-list',
  templateUrl: './kid-product-list.component.html',
  styleUrls: ['./kid-product-list.component.css']
})
export class KidProductListComponent implements OnInit {
  public products = [];
  filteredProducts: Product[] = [];
  subcategory = '';
  isExpanded = false;

  constructor(private productsService: ProductsService) { 
    this.products = [];
  }

  ngOnInit(): void {
    this.getProductsByCategory();
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  getProductsBySubcategory(value: any){
    this.subcategory = value;

    this.productsService.getAll()
    .subscribe(success => {
      if(success){
        this.products = this.productsService.products;
        this.filteredProducts = this.products.filter(p =>  {
          return p.categoryName === CategoryConstants.Kid && p.categoryType === this.subcategory
        });
      }
    })
  }

  getProductsByCategory(): void{
    this.productsService.getAll()
    .subscribe(success => {
      if(success){
        this.products = this.productsService.products;
        this.filteredProducts = this.products.filter(p =>  {
          return p.categoryName === CategoryConstants.Kid
        });
      }
    })
  }

}

