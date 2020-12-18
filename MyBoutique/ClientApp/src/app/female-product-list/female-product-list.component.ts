import { Component, OnInit } from '@angular/core';
import { Product } from '../../_models/product';
import { ProductsService } from '../../_services/products.service';
import { ActivatedRoute } from '@angular/router';
import { CategoryConstants } from '../../environments/CategoryConstants';

@Component({
  selector: 'app-female-product-list',
  templateUrl: './female-product-list.component.html',
  styleUrls: ['./female-product-list.component.css']
})
export class FemaleProductListComponent implements OnInit {
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
          return p.categoryName === CategoryConstants.Female && p.categoryType === this.subcategory
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
          return p.categoryName === CategoryConstants.Female
        });
        this.filteredProducts.sort((a, b) => a.price - b.price);
      },
      error => this.errorMessage = <any>error
    )
  }
}

