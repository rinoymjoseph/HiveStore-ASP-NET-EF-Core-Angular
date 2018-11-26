import { Component, OnInit } from '@angular/core';
import { AppSettings } from '../../app.settings';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
})
export class OrderComponent implements OnInit {

  constructor() { }

  ngOnInit() {
    AppSettings.IsLoginPageEvent.next(false);
  }

}
