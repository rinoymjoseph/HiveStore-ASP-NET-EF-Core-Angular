import { Component, OnInit, ElementRef } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { User } from '../../models/user.model';
import { UserService } from '../../services/user.service';
import { AppSettings } from '../../app.settings';
import { Observable } from 'rxjs';
import { startWith } from 'rxjs/operators';
import { map } from 'rxjs/operators';

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
  countryJSON: any;
  countries: string[] = [];
  autoCountries: Observable<string[]>;
  cities: string[] = [];
  autoCities: Observable<string[]>;

  constructor(
    private el: ElementRef,
    private fb: FormBuilder,
    private userService: UserService
  ) {
  }

  ngOnInit() {
    AppSettings.IsLoginPageEvent.next(false);
    this.createUserForm();
    this.getAllUsers();
    this.getCountries();
  }

  createUserForm() {
    this.formUser = this.fb.group({
      ipUserName: [],
      ipPassword: [],
      ipFirstName: [],
      ipLastName: [],
      //ipCountry: [],
      autoCountry: [],
      autoCity: [],
      ipCity: []
    });
  }

  countrySelectionChanged(event: any) {
    if (event.source.selected === true) {
      this.cities = this.countryJSON[event.source.value];

      this.formUser.controls["autoCity"].reset(null, { onlySelf: true, emitEvent: false });

      this.autoCities = this.formUser.controls["autoCity"].valueChanges
        .pipe(
          startWith(''),
          map(filterStr => filterStr ? this.filterCities(filterStr) : this.cities.slice(0,10)));
    }
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

  getCountries() {
    this.userService.getCountryList().subscribe(
      (res) => {
        //console.log(res);
        this.countryJSON = res;
        this.countries = Object.keys(this.countryJSON);

        this.autoCountries = this.formUser.controls["autoCountry"].valueChanges
          .pipe(
            startWith(''),
            map(filterStr => filterStr ? this.filterCountries(filterStr) : this.countries.slice(0,10)));

      },
      error => {
        console.log(error);
      }
    );
  }

  filterCountries(filterStr: string): string[] {
    console.log('Country Filter String : ' + filterStr);
    return this.countries.filter(country =>
      country.toLowerCase().indexOf(filterStr.toLowerCase()) === 0).slice(0,10);
  }

  filterCities(filterStr: string): string[] {
    console.log('City Filter String : ' + filterStr);
    return this.cities.filter(city =>
      city.toLowerCase().indexOf(filterStr.toLowerCase()) === 0).slice(0,10);
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
