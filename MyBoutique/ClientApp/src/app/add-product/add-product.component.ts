import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormArray } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { first } from 'rxjs/operators';
import { ProductsService } from '../../_services/products.service';
import { HttpEventType, HttpResponse, HttpClient } from '@angular/common/http';
import { AlertService } from '../../_services';
import { environment } from '../../environments/environment';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {
  selectedCategoryName: string = '';
  form: FormGroup;
  loading = false;
  submitted = false;
    progress: number;
  constructor(private productService: ProductsService,
    private formBuilder: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private alertService: AlertService,
    private http: HttpClient
  ) { }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      name: ['', [Validators.required, Validators.minLength(2)]],
      description: ['', [Validators.required, Validators.minLength(2)]],
      price: [0],
      categoryName: ['', [Validators.required, Validators.minLength(2)]],
      categoryType: ['', [Validators.required, Validators.minLength(2)]],
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


   
    this.loading = true;

    this.productService.createProduct(this.form.value)
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

  //public uploadFiles = (files) => {

  //  if (files.length === 0) {
  //    return;
  //  }

  //  let filesToUpload = <File>files[0];
  //  const formData = new FormData();
  //  formData.append('file', filesToUpload, filesToUpload.name);

  //  this.loading = true;

  //  this.http.post(`${environment.apiUrl}/api/image`, formData, { reportProgress: true, observe: 'events' }).subscribe(
  //    event => {
  //      if (event.type === HttpEventType.UploadProgress) {

  //        this.progress = Math.round(100 * event.loaded / event.total);
  //      } else if (event instanceof HttpResponse) {

  //        let message = `Файлът бяха качени успешно :)`;
  //        this.alertService.success(message, { autoClose: true });

  //        if (this.progress == 100) {
  //          this.loading = false
  //        }
  //      }
  //    },
  //    err => {
  //      this.loading = false;
  //      this.alertService.error(err.error.err, { autoClose: true });
  //    });

  //}
}
