import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { first } from 'rxjs/operators';
import { AlertService } from 'src/_services';
import { ProductsService } from '../../_services/products.service';
import { CookieService } from 'ngx-cookie-service';
import { OrderService } from '../../_services/order.service';
import { ShoppingCartService } from '../../_services/shopping-cart.service';

@Component({
  selector: 'app-cart-orders',
  templateUrl: './cart-orders.component.html',
  styleUrls: ['./cart-orders.component.css']
})
export class CartOrdersComponent implements OnInit {
  public orders = [];
  public subTotal = 0;
  private cookieValue: string;

  form: FormGroup;
  loading = false;
  submitted = false;
  selectedDeliveryType = '';

  constructor(private productService: ProductsService,
    private formBuilder: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private alertService: AlertService,
    private cookieService: CookieService,
    private orderService: OrderService,
    private shoppingCartService: ShoppingCartService) {
    this.orders = [];
    this.subTotal = 0;
  }

  ngOnInit(): void {
    this.cookieValue = this.cookieService.get('cookie-name');
    this.getOrdersBySessionId();

    this.form = this.formBuilder.group({
      firstName: ['', [Validators.required, Validators.minLength(2)]],
      lastName: ['', [Validators.required, Validators.minLength(2)]],
      phone: ['', [Validators.required]],
      city: ['', [Validators.required, Validators.minLength(2)]],
      deliveryType: ['', [Validators.required]],
      address: ['', [Validators.required, Validators.minLength(2)]],
      additionalInformation: ['', [Validators.maxLength(350)]],
      orders: this.formBuilder.array([]),
      userId: this.cookieService.get('cookie-name')
    });
  }

  get f() { return this.form.controls; }

  onSubmit() {
    this.submitted = true;
    // stop here if form is invalid
    if (this.form.invalid) {
      return;
    }

    this.form.value.orders = this.orders

    this.loading = true;

    this.shoppingCartService.createOrder(this.form.value)
      .pipe(first())
      .subscribe(
        data => {
          this.router.navigate(['/successfull-order'], { relativeTo: this.route });
          this.cleartCartProducts();
        },
        error => {
          this.alertService.error(error);
          this.loading = false;
        });

  }

  cleartCartProducts(): void {
    this.orderService.deleteOrdersFromCartForCurrentUser(this.cookieValue)
      .subscribe(event => {
        console.log(event);
      })
  }

  getOrdersBySessionId(): void {
    this.orderService.getAllOrders()
      .subscribe(success => {
        if (success) {
          this.orders = this.orderService.orders;
          this.subTotal = 0;
          this.orders.forEach(element => {
            this.subTotal += element.totalPrice
          });
        }
      })
  }

  incrementQTY(item: any) {
    if (item.quantity >= 1) {
      item.quantity += 1;
      item.totalPrice = item.product.price * item.quantity;
      this.subTotal += item.product.price;
    }

  }

  decrementQTY(item: any) {
    if (item.quantity > 1) {
      item.quantity -= 1;
      item.totalPrice -= item.product.price;
      this.subTotal -= item.product.price;
    }
  }

  public removeProduct = (id: number, productName: string) => {
    this.orderService.deleteOrder(id)
      .subscribe(event => {
        let message = `Успешно премахнахте ${productName} от вашата количка.`;
        this.alertService.success(message, { autoClose: true });
        this.getOrdersBySessionId();
      })
  }

}
