import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-successfull-order',
  templateUrl: './successfull-order.component.html',
  styleUrls: ['./successfull-order.component.css']
})
export class SuccessfullOrderComponent implements OnInit {

  constructor(private router: Router,
              private route: ActivatedRoute) { }

  ngOnInit(): void {
    setTimeout(() => {
      this.router.navigate(['/products'], { relativeTo: this.route });
    }, 10000)
  }

}
