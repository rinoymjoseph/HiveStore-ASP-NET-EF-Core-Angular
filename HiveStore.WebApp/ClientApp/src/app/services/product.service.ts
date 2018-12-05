import { HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { Observable } from 'rxjs'
import { AppSettings } from '../app.settings';
import { BaseResponse } from '../models/base-response.model';
import { Product } from '../models/product.model';
import { BaseService } from '../services/base.service';

export class ProductService extends BaseService {

  getAllProducts(): Observable<[Product]> {
    const getAllProductsURL = AppSettings.GET_ALL_PRODUCTS_URL;

    return this.http.get<BaseResponse>(getAllProductsURL).pipe(
      map((res: BaseResponse) => this.extractData(res)),
      catchError((res: HttpErrorResponse) => this.handleError(res))
    );
  }

  saveProduct(product: Product): Observable<string> {
    const httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json', 'Accept': 'application/json' })
    };
    const saveProductURL = AppSettings.SAVE_PRODUCT_URL;
    return this.http.post<BaseResponse>(saveProductURL, product, httpOptions).pipe(
      map((res: BaseResponse) => this.extractData(res)),
      catchError((res: HttpErrorResponse) => this.handleError(res))
    );
  }
}
