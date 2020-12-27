import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormArray } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { first } from 'rxjs/operators';
import { ProductsService } from '../../_services/products.service';
import { HttpEventType, HttpResponse, HttpClient } from '@angular/common/http';
import { AlertService } from '../../_services';
import { Product } from '../../_models/product';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {
  public productMessage: string;
  public message: string;
  public progress: number;
  selectedCategoryName: string = '';
  form: FormGroup;
  loading = false;
  loadingProduct = false;
  submitted = false;
  productIdUpdate = null;

  constructor(private productService: ProductsService,
    private formBuilder: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private alertService: AlertService
  ) { }


  ngOnInit(): void {
    this.form = this.formBuilder.group({
      name: ['', [Validators.required, Validators.minLength(2)]],
      description: ['', [Validators.required, Validators.minLength(2)]],
      price: [0, Validators.required],
      categoryName: ['', [Validators.required]],
      categoryType: ['', [Validators.required]],
      sizes: this.formBuilder.array([]),
      colors: this.formBuilder.array([]),
      
    });
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
    this.createProduct(product);
  }

  createProduct(product: Product) {
    this.loadingProduct = true;

    this.productService.createProduct(product)
      .pipe(first())
      .subscribe(
        data => {
          console.log(product);
          this.productMessage = `Успешно добавихте ${product.name}, сега добавете снимки към него с бутона по-долу.`;
          this.loadingProduct = false;
          //setTimeout(() => {
          //  this.router.navigate(['/products'], { relativeTo: this.route });
          //}, 1500);
        },
        error => {
          console.log(error);
          this.loadingProduct = false;
        });
  }

  uploadFile (files) {

    if (files.length === 0) {
      return;
    }

    let filesToUpload: FileList = files;
    const formData = new FormData();

    Array.from(filesToUpload).map((file, index) => {
      return formData.append('file' + index, file, file.name);
    });

    this.loading = true;

    this.productService.upload(formData).subscribe(
      event => {
        if (event.type === HttpEventType.UploadProgress) {

          this.progress = Math.round(100 * event.loaded / event.total);
        } else if (event.type === HttpEventType.Response) {

          this.message = `Успешно добавяне на продукт.`;
          this.alertService.success(this.message, { autoClose: true });
          this.loading = false;
          setTimeout(() => {
            this.router.navigate(['/products'], { relativeTo: this.route });
          }, 1500);

          if (this.progress == 100) {
            this.loading = false
          }
        }
      })

  }

}
