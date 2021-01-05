import { Component, OnInit } from '@angular/core';
import { CategoryConstants } from '../../environments/CategoryConstants';
import { Product } from '../../_models/product';
import { AlertService } from '../../_services';
import { ProductsService } from '../../_services/products.service';

@Component({
  selector: 'app-male-product-list',
  templateUrl: './male-product-list.component.html',
  styleUrls: ['./male-product-list.component.css']
})
export class MaleProductListComponent implements OnInit {
  public loading: boolean;
  isLoggedIn: any;
  errorMessage = '';
  filteredProducts: Product[] = [];
  products: Product[] = [];
  subcategory = '';
  isExpanded = false;
  selectedSort = '';

  constructor(private productsService: ProductsService,
    private alertService: AlertService) {
    this.products = [];
  }

  ngOnInit(): void {
    this.loading = true;

    this.getProductsByCategory();
    this.isLoggedIn = localStorage.getItem("user");

  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  sortBy(event: any) {
    this.selectedSort = event.target.value;
    if (this.subcategory == '') {
      this.getProductsByCategory();
    } else {
      this.getProductsBySubcategory(this.subcategory);
    }
  }

  getProductsBySubcategory(value: any): void{
    this.subcategory = value;

    this.productsService.getAll().subscribe(
      products => {
        this.products = products
        if (this.selectedSort == '' || this.selectedSort == 'low') {
          this.filteredProducts = this.products.filter(p => {
            return p.categoryName === CategoryConstants.Male && p.categoryType === this.subcategory
          });
          this.filteredProducts.sort((a, b) => a.price - b.price);
        } else if (this.selectedSort == 'high') {
          this.filteredProducts = this.products.filter(p => {
            return p.categoryName === CategoryConstants.Male && p.categoryType === this.subcategory
          });
          this.filteredProducts.sort((a, b) => b.price - a.price);
        }
        
      },
      error => this.errorMessage = <any>error
    )
  }

  getProductsByCategory(): void{
    this.productsService.getAll().subscribe(
      products => {
        this.products = products
        if (this.selectedSort == '' || this.selectedSort == 'low') {
          this.filteredProducts = this.products.filter(p => {
            return p.categoryName === CategoryConstants.Male
          });
          this.filteredProducts.sort((a, b) => a.price - b.price);
        } else if (this.selectedSort == 'high') {
          this.filteredProducts = this.products.filter(p => {
            return p.categoryName === CategoryConstants.Male
          });
          this.filteredProducts.sort((a, b) => b.price - a.price);
        }
        
      },
      error => this.errorMessage = <any>error
    )
  }

  public deleteProduct = (id: number) => {

    this.productsService.deleteProduct(id)
      .subscribe(
        event => {
            let message = `Продуктът беше премахнат успешно!`;
            this.alertService.success(message, { autoClose: true });
            this.getProductsByCategory();    
        },
        err => {
          this.loading = false;
          this.alertService.error(err.error.err, { autoClose: true });
        }
      );

  }
}
