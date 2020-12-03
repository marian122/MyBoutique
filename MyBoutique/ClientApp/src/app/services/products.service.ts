import { Injectable } from '@angular/core';
import { HttpClient, HttpEvent, HttpHeaders, HttpRequest } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { catchError, map, tap } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';
import { Product } from '../models/product';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {
  public products = [];

  constructor(private http: HttpClient) { }

  public getAll(){
    return this.http.get(`${environment.apiUrl}/api/products`)
    .pipe(map((data: Product[]) => {
      data.sort((a,b) => b.price - a.price);
      this.products = data;
      return true;
    }))
  }
}
