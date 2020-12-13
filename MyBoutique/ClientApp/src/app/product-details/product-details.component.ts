import { Component, OnInit } from '@angular/core';
import { Product } from '../../_models/product';
import { Order } from '../../_models/order';
import { ProductsService } from '../../_services/products.service';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertService } from 'src/_services';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

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
  form: FormGroup;
  constructor(private productService: ProductsService,
              private router: Router,
              private route: ActivatedRoute,
              private alertService: AlertService,
              private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.getProductById(this.route.snapshot.params.id);

    this.form = this.formBuilder.group({
      size: ['', [Validators.required]],
      color: ['', [Validators.required]],
    });
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

    if(data.size !== "" && data.color !== ""){
      this.productService.addProductToCard(data)
      .subscribe(() => {
        let message = `Успешно добавихте продукта в количката.`;
        this.alertService.success(message, { autoClose: true });
        setTimeout(() => {
          this.router.navigate(['/cart-orders'], { relativeTo: this.route });
        }, 2500);
      })
    }
    
    if(data.size == ""){
      let message = `Моля изберете размер`;
      this.alertService.warn(message, { autoClose: true });
    }
    if(data.color == ""){
      let message = `Моля изберете цвят`;
      this.alertService.warn(message, { autoClose: true });
    }
  }

}
