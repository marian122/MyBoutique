import { Component } from '@angular/core';
import { AccountService } from '../../_services';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;
  collapsed = true;
  isLoggedIn;


  constructor(
    private accountService: AccountService) { this.isLoggedIn = localStorage.getItem("user"); }


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
