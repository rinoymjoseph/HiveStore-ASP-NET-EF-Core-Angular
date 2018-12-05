import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { map, catchError, } from 'rxjs/operators';
import { Observable, of } from 'rxjs'
import { AccountService } from './account.service';

@Injectable()
export class AuthGuard implements CanActivate {

  message: string;

  constructor(private accountService: AccountService) {
  }

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
    return this.accountService.getSignedInUser().pipe(
      map((user) => {
        console.log(user);
        return true;
      }),
      catchError((error) => {
        console.log(error);
        return of(false);
      }));
  }
}
