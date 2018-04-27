import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Employee } from './employee.model';
import { EmployeeService } from './employee.service';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css'],
  providers: [EmployeeService]
})
export class EmployeeComponent implements OnInit {

  formEmployee: FormGroup;
  employees: Employee[];

  constructor(private fb: FormBuilder,
    private employeeService: EmployeeService
  ) { }

  ngOnInit() {
    this.createEmployeeForm();
    this.getAllEmployees();
  }

  createEmployeeForm() {
    this.formEmployee = this.fb.group({
      ipFirstName: [],
      ipLastName: [],
      ipCountry: [],
      ipCity: []
    });
  }

  btnSaveClick(event: any) {
    if (this.formEmployee.valid) {
      this.saveEmployee();
    }
  }

  btnCancelClick(event: any) {

  }

  getAllEmployees() {
    this.employeeService.getAllEmployees().subscribe(
      (res) => {
        this.employees = res;
      },
      error => {
        console.log(error);
      }
    );
  }

  saveEmployee() {
    const employee: Employee = new Employee();
    employee.FirstName = this.formEmployee.value.ipFirstName;
    employee.LastName = this.formEmployee.value.ipLastName;
    employee.City = this.formEmployee.value.ipCity;
    employee.Country = this.formEmployee.value.ipCountry;
    this.employeeService.saveEmployee(employee).subscribe((res) => {
      console.log(res);
    },
      error => {
        console.log(error);
      }
    );
  }
}
