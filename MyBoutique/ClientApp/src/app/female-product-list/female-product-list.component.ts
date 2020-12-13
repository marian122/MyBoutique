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
          return p.categoryName === CategoryConstants.Female && p.categoryType === this.subcategory
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
          return p.categoryName === CategoryConstants.Female
        });
      }
    })
  }

}
