import { Component, OnInit } from '@angular/core';
import { Product } from '../../models/product';
import { ProductsService } from '../../services/products.service';

@Component({
  selector: 'app-female-underwear',
  templateUrl: './female-underwear.component.html',
  styleUrls: ['./female-underwear.component.css']
})
export class FemaleUnderwearComponent implements OnInit {
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
          return p.categoryName === "Жени" && p.categoryType === "Бельо"
        });
      }
    })
  }

}