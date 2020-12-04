import { Component, OnInit } from '@angular/core';
import { Product } from '../models/product';
import { ProductsService } from '../services/products.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {
  currentProduct: Product = {
    name: '',
    description: '',
    price: 0,
    categoryName: '',
    categoryType: '',
    sizes: null,
    colors: null,
    createdOn: null,
  }
  constructor(private productService: ProductsService,
              private router: Router,
              private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.getProductById(this.route.snapshot.params.id);
  }

  getProductById(id: number): void {
    this.productService.getById(id)
    .subscribe(
      data => {
        this.currentProduct = data;
      },
      error => {
        console.log(error);
      }
    )
  }

}
