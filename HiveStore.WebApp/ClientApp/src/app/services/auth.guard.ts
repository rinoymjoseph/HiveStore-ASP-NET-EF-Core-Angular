import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { AccountService } from './account.service';

@Injectable()
export class AuthGuard implements CanActivate {

  message: string;

  constructor(private accountService: AccountService) {

  }

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
    return this.accountService.getSignedInUser()
      .map(
        (user) => {
          console.log(user);
          return true;
        },
        error => {
          this.message = <any>error;
          return false;
        });
  }

  async getSignedInUser() {
    let isUserAuthorized = false;
    await this.accountService.getSignedInUser()
      .subscribe(
        (user) => {
          isUserAuthorized = true;
        },
        error => {
          this.message = <any>error;
        });
    return isUserAuthorized;
  }
}
