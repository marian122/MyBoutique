import { Component, OnInit, HostListener } from '@angular/core';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { Guid } from 'guid-typescript';
import { ProductsService } from '../_services/products.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit{
  @HostListener('window:unload', ['$event'])
  unloadHandler(event) {
    this.cleartCartProducts();
  }

  title = 'app';
  private cookieValue: string;
  cookieVal = Guid.create().toString();
  
  constructor(private router: Router,
    private cookieService: CookieService,
    private orderService: ProductsService) { }
  
  ngOnInit(): void {
    this.orderService.deleteAllProductsFromCart();
    this.cookieService.set('cookie-name', this.cookieVal);
    this.cookieValue = this.cookieService.get('cookie-name');
    console.log(this.cookieValue);
    this.router.navigate(['/products']);
  }

  cleartCartProducts(): void {
    this.orderService.deleteUnfinishedOrdersFromCart(this.cookieVal)
      .subscribe(event => {
        console.log(event);
      })
  }
}


