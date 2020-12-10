import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { first } from 'rxjs/operators';
import { ProductsService } from '../services/products.service';

@Component({
  selector: 'app-cart-orders',
  templateUrl: './cart-orders.component.html',
  styleUrls: ['./cart-orders.component.css']
})
export class CartOrdersComponent implements OnInit {
  public orders = [];
  public subTotal = 0;
  form: FormGroup;
  loading = false;
  submitted = false;

  constructor(private service: ProductsService,
    private formBuilder: FormBuilder,
    private router: Router,
    private route: ActivatedRoute) {
    this.orders = [];
    this.subTotal = 0;
  }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      firstName: ['', [Validators.required, Validators.minLength(2)]],
      lastName: ['', [Validators.required, Validators.minLength(2)]],
      phone: ['', [Validators.required, Validators.minLength(9)]],
      email: ['', [Validators.required, Validators.minLength(2)]],
      city: ['', [Validators.required, Validators.minLength(2)]],
      address: ['', [Validators.required, Validators.minLength(2)]],
      additionalInformation: [''],
      orders: this.formBuilder.array([])
    });
    this.getOrdersBySessionId();
  }

  onSubmit() {
    this.submitted = true;
    // stop here if form is invalid
    if (this.form.invalid) {
      return;
    }

    this.form.value.orders = this.orders

    this.loading = true;

    this.service.createOrder(this.form.value)
      .pipe(first())
      .subscribe(
        data => {
          console.log(this.form.value);

          this.router.navigate(['/products'], { relativeTo: this.route });
        },
        error => {
          console.log(error);
          this.loading = false;
        });

  }

  getOrdersBySessionId(): void {
    this.service.getAllOrders()
      .subscribe(success => {
        if (success) {
          this.orders = this.service.orders;
          this.subTotal = this.service.subTotal;
          console.log(this.orders)
        }
      })
  }

  incrementQTY(item: any) {
    if (item.quantity >= 1) {
      item.quantity += 1;
      item.totalPrice = item.product.price * item.quantity;
      console.log(item)
    }

  }

  decrementQTY(item: any) {
    if (item.quantity > 1) {
      item.quantity -= 1;
      item.totalPrice -= item.product.price;
    }
  }

  public removeProduct = (id: number) => {
    this.service.deleteProductFromCart(id)
      .subscribe(event => {
        console.log(event);
        this.getOrdersBySessionId()
      });
  }

}
