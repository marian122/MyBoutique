import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { Guid } from 'guid-typescript';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit {
  title = 'app';

  
  constructor(private router: Router) {}
  
  ngOnInit(): void {
    this.router.navigate(['/products']);
  }
}


