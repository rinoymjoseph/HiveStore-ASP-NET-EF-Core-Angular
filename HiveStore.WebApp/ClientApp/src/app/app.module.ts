import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import {
  MatSelectModule,
  MatButtonModule,
  MatInputModule,
  MatCheckboxModule,
  MatProgressBarModule,
} from '@angular/material';

import { InputTextModule } from 'primeng/inputtext';
import { ListboxModule } from 'primeng/listbox';
import { CheckboxModule } from 'primeng/checkbox';
import { ButtonModule } from 'primeng/button';
import { TableModule } from 'primeng/table';
import { MessageModule } from 'primeng/message';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { EmployeeComponent } from './components/employee/employee.component';
import { ProductComponent } from './components/product/product.component';
import { OrderComponent } from './components/order/order.component';
import { RequestInfoComponent } from './components/request-info/request-info.component';
import { LoginComponent } from './components/login/login.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    EmployeeComponent,
    ProductComponent,
    OrderComponent,
    RequestInfoComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MatSelectModule,
    MatButtonModule,
    MatInputModule,
    MatCheckboxModule,
    MatProgressBarModule,
    InputTextModule,
    ListboxModule,
    CheckboxModule,
    ButtonModule,
    TableModule,
    MessageModule,
    RouterModule.forRoot([
      { path: '', component: EmployeeComponent, pathMatch: 'full' },
      { path: 'login', component: LoginComponent },
      { path: 'employee', component: EmployeeComponent },
      { path: 'product', component: ProductComponent },
      { path: 'order', component: OrderComponent }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
