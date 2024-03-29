import { Component, OnInit, AfterViewInit } from '@angular/core';
import { Product } from '../../_models/product';
import { AlertService } from '../../_services';
import { ProductsService } from '../../_services/products.service';
import { Picture } from '../../_models/picture';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit{
  public pictures: Picture[];
  public loading: boolean;
  isLoggedIn;
  errorMessage = ''; 
  filteredProducts: Product[] = [];    
  products: Product[] = [];    

  constructor(private productsService: ProductsService,
    private alertService: AlertService) { this.products = []; }

  ngOnInit(): void {
   

    this.loading = true;
    this.productsService.getAll().subscribe(
      products => {
        this.products = products
        
        this.products.sort((a, b) => {
          return this.getTime(b.createdOn) - this.getTime(a.createdOn)
        });
        console.log(products)
      },    
      error => this.errorMessage = <any>error    
    )
    this.isLoggedIn = localStorage.getItem("user");

  }

  private getTime(date?: Date) {
    return date != null ? new Date(date).getTime() : 0;
  }

  onSaveComplete(): void {    
    this.productsService.getAll().subscribe(    
      products => {    
        this.products = products;
      },    
      error => this.errorMessage = <any>error    
    );    
  }    

  public deleteProduct = (id: number) => {

    this.productsService.deleteProduct(id)
      .subscribe(
        event => {
            let message = `Продуктът беше премахнат успешно!`;
            this.alertService.success(message, { autoClose: true });
            this.onSaveComplete();    
        },
        err => {
          this.loading = false;
          this.alertService.error(err.error.err, { autoClose: true });
        }
      );

  }
}
