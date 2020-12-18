import { Component, OnInit } from '@angular/core';
import { CategoryConstants } from '../../environments/CategoryConstants';
import { Product } from '../../_models/product';
import { ProductsService } from '../../_services/products.service';

@Component({
  selector: 'app-male-product-list',
  templateUrl: './male-product-list.component.html',
  styleUrls: ['./male-product-list.component.css']
})
export class MaleProductListComponent implements OnInit {
  isLoggedIn;
  errorMessage = '';
  filteredProducts: Product[] = [];
  products: Product[] = [];
  subcategory = '';
  isExpanded = false;

  constructor(private productsService: ProductsService) {
    this.products = [];
  }

  ngOnInit(): void {
    this.getProductsByCategory();
    this.isLoggedIn = localStorage.getItem("user");
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  //For edit later
  onSaveComplete(): void {
    this.productsService.getAll().subscribe(
      products => {
        this.products = products;
      },
      error => this.errorMessage = <any>error
    );
    
  }

  getProductsBySubcategory(value: any): void{
    this.subcategory = value;

    this.productsService.getAll().subscribe(
      products => {
        this.products = products
        this.filteredProducts = this.products.filter(p =>  {
          return p.categoryName === CategoryConstants.Male && p.categoryType === this.subcategory
        });
        this.filteredProducts.sort((a, b) => a.price - b.price);
      },
      error => this.errorMessage = <any>error
    )
  }

  getProductsByCategory(): void{
    this.productsService.getAll().subscribe(
      products => {
        this.products = products
        this.filteredProducts = this.products.filter(p =>  {
          return p.categoryName === CategoryConstants.Male
        });
        this.filteredProducts.sort((a, b) => a.price - b.price);
      },
      error => this.errorMessage = <any>error
    )
  }
}
