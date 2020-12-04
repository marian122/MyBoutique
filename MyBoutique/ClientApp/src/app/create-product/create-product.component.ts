import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { first } from 'rxjs/operators';
import { ProductsService } from '../services/products.service';

@Component({
  selector: 'app-create-product',
  templateUrl: './create-product.component.html',
  styleUrls: ['./create-product.component.css']
})
export class CreateProductComponent implements OnInit {
  form: FormGroup;
  constructor(private router: Router,
              private route: ActivatedRoute,
              private productService: ProductsService,
              private formBuilder: FormBuilder,) { }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      name: ['', [Validators.required, Validators.minLength(1)]],
      description: ['', [Validators.required, Validators.minLength(1)]],
      price: [''],
      categoryName: ['', [Validators.required, Validators.minLength(1)]],
      categoryType: ['', [Validators.required, Validators.minLength(1)]],
      sizes: [''],
      colors: [''], 
    });
  }

  get f() { return this.form.controls; }

  onSubmit() {

    // stop here if form is invalid
    if (this.form.invalid) {
      return;
    }

    this.productService.createProduct(this.form.value)
      .pipe(first())
      .subscribe(
        data => {
          this.router.navigate(['/products'], { relativeTo: this.route });
        },
        error => {
          console.log(error);
        });
  }
}
