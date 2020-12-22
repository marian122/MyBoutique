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
  product: Product;
  sizeArray: number[] = new Array();
  colorArray: number[] = new Array();


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
    this.productService.getById(productId).subscribe(
      (product: Product) => this.editForm(product),
      (err) => console.log(err)
    );
  }

  editForm(product: Product): void{
    this.form.patchValue({
      id: product.id,
      name: product.name,
      description: product.description,
      price: product.price,
      categoryName: product.categoryName,
      categoryType: product.categoryType,
    });

    this.form.setControl('sizes', this.setExistingSizes(product.sizes))
    this.form.setControl('colors', this.setExistingSizes(product.colors))
  }

  setExistingSizes(sizes: any[]): FormArray {
    const formArray = new FormArray([]);

    sizes.forEach(s => {
      formArray.push(this.formBuilder.group({
        id: s.id,
        name: s.name
      }))
    });

    return formArray;
  }

  setExistingColors(colors: any[]): FormArray {
    const formArray = new FormArray([]);

    colors.forEach(c => {
      formArray.push(this.formBuilder.group({
        id: c.id,
        name: c.name
      }))
    });

    return formArray;
  }

  selectCategoryName(event: any) {
    this.selectedCategoryName = event.target.value;
  }

  get sizes(): FormArray {
    return this.form.get('sizes') as FormArray
  }

  newSize(): FormGroup {
    return this.formBuilder.group({
      id: 0,
      name: ''
    })
  }

  addSize(): void{
    (<FormArray>this.form.get('sizes')).push(this.newSize());
  }

  deleteSize(index: number, sizeId: number): void{
    this.sizes.removeAt(index);

    this.sizeArray.push(sizeId);
  }

  get colors(): FormArray {
    return this.form.get("colors") as FormArray
  }

  newColor(): FormGroup {
    return this.formBuilder.group({
      id: 0,
      name: ''
    })
  }

  addColors() {
    this.colors.push(this.newColor());
  }

  deleteColor(value: any, colorId: number) {
    this.colors.removeAt(value);

    this.colorArray.push(colorId)
  }

  get f() { return this.form.controls; }

  onSubmit() {
    this.submitted = true;
    // stop here if form is invalid
    if (this.form.invalid) {
      return;
    }
    this.editProduct(this.form.value);

    this.colorArray.forEach(color => {
      this.productService.deleteColor(color).subscribe(data => {
        console.log(data);
      })
    });

    this.sizeArray.forEach(size => {
      this.productService.deleteSize(size).subscribe(data => {
        console.log(data);
      })
    });
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
