import { Component, OnInit } from '@angular/core';
import { Message } from 'primeng/primeng';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { AppSettings } from '../../app.settings';
import { Router } from '@angular/router';
import { AccountService } from '../../services/account.service';
import { SignIn } from '../../models/sign-in.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  providers: [AccountService]
})
export class LoginComponent implements OnInit {

  message: string;
  msgs: Message[] = [];
  loginForm: FormGroup;
  isLoading: boolean;

  constructor(private fb: FormBuilder,
    private router: Router, private accountService: AccountService) { }

  ngOnInit() {
    AppSettings.IsLoginPageEvent.next(true);
    this.createForm();
  }

  createForm() {
    this.loginForm = this.fb.group({
      ipUserName: ['', Validators.required],
      ipPassword: ['', Validators.required],
      ddRole: ['']
    });
  }

  btnLoginClick(loginForm: FormGroup) {
    let signIn: SignIn = new SignIn();
    signIn.UserName = this.loginForm.value.ipUserName;
    signIn.Password = this.loginForm.value.ipPassword;
    this.accountService.signIn(signIn).subscribe(
      (res) => {
        console.log(res);
        this.router.navigateByUrl('/');
    },
      error => {
        console.log(error);
      }
    );
  }
}
