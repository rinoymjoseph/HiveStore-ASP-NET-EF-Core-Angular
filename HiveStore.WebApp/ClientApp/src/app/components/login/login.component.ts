import { Component, OnInit } from '@angular/core';
import { Message } from 'primeng/primeng';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { AppSettings } from '../../app.settings';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  message: string;
  msgs: Message[] = [];
  loginForm: FormGroup;
  isLoading: boolean;

  constructor(private fb: FormBuilder,
    private router: Router) { }

  ngOnInit() {
    AppSettings.IsLoginPageEvent.next(true);
    this.createForm();
  }

  createForm() {
    this.loginForm = this.fb.group({
      userName: ['', Validators.required],
      password: ['', Validators.required],
      ddRole: ['']
    });
  }

  btnLoginClick(loginForm: FormGroup) {
    this.router.navigateByUrl('/');
  }
}
