import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { BaseResponse } from '../models/base-response.model';
import { HttpErrorResponse } from '@angular/common/http';
import { ErrorObservable } from 'rxjs/observable/ErrorObservable';

@Injectable()
export class BaseService {

  router: Router;
  http: HttpClient;

  constructor(private _router: Router, private _http: HttpClient) {
    this.router = _router;
    this.http = _http;
  }

  public extractData(res: BaseResponse) {
    if (res.IsSuccess) {
      return JSON.parse(res.Response);
    } else {
      //this.router.navigateByUrl('MillBaseEC/Error');
    }
  }

  public handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', error.error.message);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      if (error.status === 403) {
        //window.location.replace(window.location.href);
        //this.router.navigateByUrl('/login')
        this.router.navigateByUrl('/login');
      }
      //console.error(
      //  `Backend returned code ${error.status}, ` +
      //  `body was: ${error.error}`);
    }
    // return an ErrorObservable with a user-facing error message
    return new ErrorObservable(
      'Something bad happened; please try again later.');
  }
}
