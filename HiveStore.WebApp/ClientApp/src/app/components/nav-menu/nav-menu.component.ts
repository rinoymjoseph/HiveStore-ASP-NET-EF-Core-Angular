import { Component } from '@angular/core';
import { AccountService } from '../../services/account.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css'],
  providers: [AccountService]
})
export class NavMenuComponent {

  constructor(private accountService:AccountService) {

  }

  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  signOut() {
    this.accountService.signOut().subscribe(
      (res) => {
        console.log(res);
      },
      error => {
        console.log(error);
      }
    );

  }
}
