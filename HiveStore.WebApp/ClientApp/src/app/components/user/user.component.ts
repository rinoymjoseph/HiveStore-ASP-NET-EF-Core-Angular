import { Component, OnInit, ElementRef } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { User } from '../../models/user.model';
import { UserService } from '../../services/user.service';
import { AppSettings } from '../../app.settings';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css'],
  providers: [UserService]
})
export class UserComponent implements OnInit {

  isLoading: boolean;
  formUser: FormGroup;
  users: User[];
  formdata1: FormData;
  selectedUser: User;

  constructor(
    private el: ElementRef,
    private fb: FormBuilder,
    private userService: UserService
  ) { }

  ngOnInit() {
    AppSettings.IsLoginPageEvent.next(false);
    this.createUserForm();
    this.getAllUsers();
  }

  createUserForm() {
    this.formUser = this.fb.group({
      ipUserName: [],
      ipPassword: [],
      ipFirstName: [],
      ipLastName: [],
      ipCountry: [],
      ipCity: []
    });
  }

  btnSaveClick(event: any) {
    if (this.formUser.valid) {
      this.saveUser();
    }
  }

  btnCancelClick(event: any) {
    this.formUser.patchValue({
      ipUserName: '',
      ipPassword: '',
      ipFirstName: '',
      ipLastName: '',
      ipCountry: '',
      ipCity: ''
    });
    this.selectedUser = null;
  }

  gridUsersOnRowSelect(event) {
    //console.log(this.selectedUser);
    this.formUser.patchValue({
      ipUserName: this.selectedUser.UserName,
      ipPassword: this.selectedUser.Password,
      ipFirstName: this.selectedUser.FirstName,
      ipLastName: this.selectedUser.LastName,
      ipCountry: this.selectedUser.Country,
      ipCity: this.selectedUser.City
    });
  }

  getAllUsers() {
    this.isLoading = true;
    this.userService.getAllUsers().subscribe(
      (res) => {
        this.users = res;
        this.isLoading = false;
      },
      error => {
        console.log(error);
        this.isLoading = false;
      }
    );
  }

  saveUser() {
    const user: User = new User();
    user.UserName = this.formUser.value.ipUserName;
    user.Password = this.formUser.value.ipPassword;
    user.FirstName = this.formUser.value.ipFirstName;
    user.LastName = this.formUser.value.ipLastName;
    user.City = this.formUser.value.ipCity;
    user.Country = this.formUser.value.ipCountry;
    user.Id = this.selectedUser ? this.selectedUser.Id : '';
    this.isLoading = true;
    this.userService.saveUser(user).subscribe((res) => {
      console.log(res);
      this.isLoading = false;
      this.getAllUsers();
    },
      error => {
        console.log(error);
        this.isLoading = false;
      }
    );
  }
}
