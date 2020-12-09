import { Component, OnInit } from '@angular/core';
import { Product } from '../models/product';
import { Order } from '../models/order';
import { ProductsService } from '../services/products.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {
  currentProduct: Product = {
    id: 0,
    name: '',
    description: '',
    price: 0,
    categoryName: '',
    categoryType: '',
    sizes: null,
    colors: null,
    createdOn: null,
  }

  selectedColor = '';
  selectedSize = '';

  orderPayload: Order = {
    productId: this.currentProduct.id,
    userId: '',
    quantity: 1,
    size: this.selectedSize,
    color: this.selectedColor
  }

  constructor(private productService: ProductsService,
              private router: Router,
              private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.getProductById(this.route.snapshot.params.id);
  }

  incrementQTY(item){
    if(item.quantity >= 1){
      item.quantity += 1;
      item.totalPrice = item.product.price * item.quantity;
      console.log(item)
    }
    
  }

  decrementQTY(item){
    if(item.quantity > 1){
      item.quantity -= 1;
      item.totalPrice -= item.product.price;
    }
  }

  getCurrentColor(event: any){
    this.selectedColor = event.target.value;
  }

  getCurrentSize(event: any){
    this.selectedSize = event.target.value;
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

  addProductToCart(id, userId: string, quantity, size, color): void {
    let data = {
      productId: id,
      userId, 
      quantity,
      size,
      color
    };

    data.size = this.selectedSize;
    data.color = this.selectedColor;

    this.productService.addProductToCard(data)
    .subscribe(() => {
      console.log(data);
      this.router.navigate(['/cart-orders'], { relativeTo: this.route });
    })
  }

}
