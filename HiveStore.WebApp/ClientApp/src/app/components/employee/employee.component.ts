import { Component, OnInit, ElementRef } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Employee } from '../../models/employee.model';
import { EmployeeService } from '../../services/employee.service';
import * as jsPDF from 'jspdf';
import * as html2canvas from 'html2canvas';
import * as domtoimage from 'dom-to-image';
import { AppSettings } from '../../app.settings';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css'],
  providers: [EmployeeService]
})
export class EmployeeComponent implements OnInit {

  isLoading: boolean;
  formEmployee: FormGroup;
  employees: Employee[];
  formdata1: FormData;
  selectedEmployee: Employee;

  constructor(
    private el: ElementRef,
    private fb: FormBuilder,
    private employeeService: EmployeeService
  ) { }

  ngOnInit() {
    AppSettings.IsLoginPageEvent.next(false);
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
    this.formEmployee.patchValue({
      ipFirstName: '',
      ipLastName: '',
      ipCountry: '',
      ipCity: ''
    });
    this.selectedEmployee = null;
  }

  gridEmployeesOnRowSelect(event) {
    //console.log(this.selectedEmployee);
    this.formEmployee.patchValue({
      ipFirstName: this.selectedEmployee.FirstName,
      ipLastName: this.selectedEmployee.LastName,
      ipCountry: this.selectedEmployee.Country,
      ipCity: this.selectedEmployee.City
    });
  }

  getAllEmployees() {
    this.isLoading = true;
    this.employeeService.getAllEmployees().subscribe(
      (res) => {
        this.employees = res;
        this.isLoading = false;
      },
      error => {
        console.log(error);
        this.isLoading = false;
      }
    );
  }

  saveEmployee() {
    const employee: Employee = new Employee();
    employee.FirstName = this.formEmployee.value.ipFirstName;
    employee.LastName = this.formEmployee.value.ipLastName;
    employee.City = this.formEmployee.value.ipCity;
    employee.Country = this.formEmployee.value.ipCountry;
    employee.Id = this.selectedEmployee ? this.selectedEmployee.Id : 0;
    this.isLoading = true;
    this.employeeService.saveEmployee(employee).subscribe((res) => {
      console.log(res);
      this.isLoading = false;
      this.getAllEmployees();
    },
      error => {
        console.log(error);
        this.isLoading = false;
      }
    );
  }

  btnTestClick(event:any) {
    let pdfExpElement = document.getElementById('divPrint');
    domtoimage.toPng(pdfExpElement)
      .then(function (dataUrl) {
        var img = new Image();
        img.src = dataUrl;
        let doc = new jsPDF('p', 'pt', 'a4');
        doc.addImage(img, 'PNG', 10, 10, 580, 300);
        doc.save('test.pdf');
      })
      .catch(function (error) {
        console.error('oops, something went wrong!', error);
      });
  }

  generatePDFUsingHTML2Canvas() {

    let pdfExpElement = document.getElementById('divPrint');

    html2canvas(pdfExpElement).then(canvas => {
      const img = canvas.toDataURL("image/png");
      let doc = new jsPDF('p', 'pt', 'a4');
      doc.addImage(img, 'PNG', 10, 10, 580, 300);
      //doc.save('test.pdf');
      let pdfFile: File = doc.output('arraybuffer');
      let blob = new Blob([new Uint8Array(doc.output('arraybuffer'))], { type: 'application/pdf' });
      this.formdata1 = new FormData();
      this.formdata1.append('receiptPDF', blob, 'test.pdf');
      this.employeeService.testFileTransfer(this.formdata1).subscribe((res) => {
        console.log(res);
      },
        error => {
          console.log(error);
        }
      );
    });
  }
}
