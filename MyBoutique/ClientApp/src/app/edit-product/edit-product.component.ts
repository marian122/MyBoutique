import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { throwError } from 'rxjs';
import { first } from 'rxjs/operators';
import { Product } from '../../_models/product';
import { AlertService } from '../../_services';
import { ProductsService } from '../../_services/products.service';

@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrls: ['./edit-product.component.css']
})
export class EditProductComponent implements OnInit {
  selectedCategoryName: string = '';
  form: FormGroup;
  loading = false;
  submitted = false;
  progress: number;

  constructor(private productService: ProductsService,
    private formBuilder: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private alertService: AlertService) { }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      id: 0,
      name: ['', [Validators.required, Validators.minLength(2)]],
      description: ['', [Validators.required, Validators.minLength(2)]],
      price: [0, Validators.required],
      categoryName: ['', [Validators.required]],
      categoryType: ['', [Validators.required]],
      sizes: this.formBuilder.array([]),
      colors: this.formBuilder.array([]),
    });

    this.loadProductForEdit(this.route.snapshot.params.id);
  }

  loadProductForEdit(productId: number) {
    this.productService.getById(productId).subscribe(product => {
      this.form.controls['id'].setValue(productId);
      this.form.controls['name'].setValue(product.name);
      this.form.controls['description'].setValue(product.description);
      this.form.controls['price'].setValue(product.price);
      this.form.controls['categoryName'].setValue(product.categoryName);
      this.form.controls['categoryType'].setValue(product.categoryType);
      this.form.controls['sizes'].patchValue(product.sizes);
      this.form.controls['colors'].patchValue(product.colors);
    })
  }

  selectCategoryName(event: any) {
    this.selectedCategoryName = event.target.value;
  }

  get sizes(): FormArray {
    return this.form.get('sizes') as FormArray
  }

  newSize(): FormGroup {
    return this.formBuilder.group({
      name: ''
    })
  }

  addSizes() {
    this.sizes.push(this.newSize());
  }

  deleteSize(value: any) {
    this.sizes.removeAt(value);
  }

  get colors(): FormArray {
    return this.form.get("colors") as FormArray
  }

  newColor(): FormGroup {
    return this.formBuilder.group({
      name: ''
    })
  }

  addColors() {
    this.colors.push(this.newColor());
  }

  deleteColor(value: any) {
    this.colors.removeAt(value);
  }

  get f() { return this.form.controls; }

  onSubmit() {
    this.submitted = true;
    // stop here if form is invalid
    if (this.form.invalid) {
      return;
    }

    const product = this.form.value;
    this.editProduct(product);
  }

  editProduct(product: Product) {
    product.id = +product.id;
    this.productService.updateProduct(product)
    .pipe(first())
      .subscribe(
        data => {
          console.log(data);
          let message = `Успешно редактирахте ${product.name}.`;
          this.alertService.success(message, { autoClose: true });
          setTimeout(() => {
            this.router.navigate(['/products'], { relativeTo: this.route });
          }, 1500);
        },
        error => {
          console.log(error);
          this.loading = false;
        });

  }

  
}
