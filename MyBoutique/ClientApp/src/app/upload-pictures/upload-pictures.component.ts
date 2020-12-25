import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { ProductsService } from '../../_services/products.service';
import { AlertService } from '../../_services';
import { HttpEventType } from '@angular/common/http';

@Component({
  selector: 'app-upload-pictures',
  templateUrl: './upload-pictures.component.html',
  styleUrls: ['./upload-pictures.component.css']
})
export class UploadPicturesComponent implements OnInit {
  @Output() public onUploadFinished = new EventEmitter();
  public message: string;
  public progress: number;
  loading = false;
  submitted = false;
  constructor(private productService: ProductsService,
    private alertService: AlertService) { }

  ngOnInit(): void {
  }

  public uploadFile = (files) => {

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

          this.message = `Успешно :)`;
          this.alertService.success(this.message, { autoClose: true });
          this.onUploadFinished.emit(event.body);

          if (this.progress == 100) {
            this.loading = false
          }
        }
      })

  }
}
