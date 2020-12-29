import { Component, OnInit } from '@angular/core';
import { Product } from '../../_models/product';
import { Order } from '../../_models/order';
import { ProductsService } from '../../_services/products.service';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertService } from 'src/_services';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CookieService } from 'ngx-cookie-service';
import { OrderService } from '../../_services/order.service';
import { Picture } from '../../_models/picture';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {
  public pictures: Picture[];
  private cookieValue: string;
  isLoggedIn: any;
  public product: Product;

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
    pictures: '',
  }


  selectedColor = '';
  selectedSize = '';

  orderPayload: Order = {
    productId: this.currentProduct.id,
    userId:'',
    quantity: 1,
    size: this.selectedSize,
    color: this.selectedColor,
    picUrl: ''
  }

  form: FormGroup;

  constructor(private productService: ProductsService,
    private router: Router,
    private route: ActivatedRoute,
    private alertService: AlertService,
    private formBuilder: FormBuilder,
    private cookieService: CookieService,
    private orderService: OrderService) { }

  ngOnInit(): void {
    this.cookieValue = this.cookieService.get('cookie-name');
    this.getProductById(this.route.snapshot.params.id);

    this.form = this.formBuilder.group({
      size: ['', [Validators.required]],
      color: ['', [Validators.required]],
    });
    this.isLoggedIn = localStorage.getItem("user");
  }
  

  incrementQTY(item) {
    if (item.quantity >= 1) {
      item.quantity += 1;
      item.totalPrice = item.product.price * item.quantity;
      console.log(item)
    }

  }

  decrementQTY(item) {
    if (item.quantity > 1) {
      item.quantity -= 1;
      item.totalPrice -= item.product.price;
    }
  }

  getCurrentColor(event: any) {
    this.selectedColor = event.target.value;
  }

  getCurrentSize(event: any) {
    this.selectedSize = event.target.value;
  }

  getProductById(id: number): void {
    this.productService.getById(id)
      .subscribe(
        data => {
          this.product = data;
          this.currentProduct = data;
          console.log(this.currentProduct)
          console.log(this.product)
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
    data.userId = this.cookieValue;

    if (data.size !== "" && data.color !== "") {
      this.orderService.addProductToCard(data)
        .subscribe(() => {
          let message = `Успешно добавихте продукта в количката.`;
          this.alertService.success(message, { autoClose: true });
          setTimeout(() => {
            this.router.navigate(['/products'], { relativeTo: this.route });
          }, 1500);
        })
    }

    if (data.size == "") {
      let message = `Моля изберете размер`;
      this.alertService.warn(message, { autoClose: true });
    }
    if (data.color == "") {
      let message = `Моля изберете цвят`;
      this.alertService.warn(message, { autoClose: true });
    }
  }

}
