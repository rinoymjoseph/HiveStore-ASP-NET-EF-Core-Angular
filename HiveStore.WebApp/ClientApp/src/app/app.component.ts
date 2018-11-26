import { Component, OnInit } from '@angular/core';
import { ISubscription } from 'rxjs/Subscription';
import { AppSettings } from './app.settings';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  isLoginPageSub: ISubscription;
  isLoginPage: boolean;

  constructor() {
  }

  ngOnInit(): void {
    this.isLoginPageSub = AppSettings.IsLoginPageEvent.subscribe(
      (response: any) => {
        setTimeout(() => {
          this.isLoginPage = response;
        });
      },
      error => {
      });
  }
}
