import { Component, OnInit } from '@angular/core';
import { AccountService } from '../../_services';
import { OrderService } from '../../_services/order.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  count = 0;
  isExpanded = false;
  collapsed = true;
  isLoggedIn;
  

  constructor(
    private accountService: AccountService, private orderService: OrderService) {
    this.isLoggedIn = localStorage.getItem("user");

    this.orderService.cartCountSubject.subscribe(status => {
      this.count = status;
    })
  }


  collapse() {
    this.isExpanded = false;
  }


  toggle() {
    this.isExpanded = !this.isExpanded;
  }


   LogOut() {
    this.accountService.logout();
    this.isLoggedIn = ""
    this.collapsed = !this.collapsed;
    window.location.reload();
  }

}
