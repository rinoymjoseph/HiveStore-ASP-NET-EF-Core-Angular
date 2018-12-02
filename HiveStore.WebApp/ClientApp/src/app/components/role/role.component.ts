import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { RoleService } from '../../services/role.service';
import { Role } from '../../models/role.model';
import { AppSettings } from '../../app.settings';

@Component({
  selector: 'app-role',
  templateUrl: './role.component.html',
  styleUrls: ['./role.component.css'],
  providers: [RoleService]
})
export class RoleComponent implements OnInit {

  isLoading: boolean;
  formRole: FormGroup;
  roles: Role[];
  formdata1: FormData;
  selectedRole: Role;

  constructor(
    private fb: FormBuilder,
    private roleService: RoleService) { }

  ngOnInit() {
    AppSettings.IsLoginPageEvent.next(false);
    this.createRoleForm();
    this.getAllRoles();
  }

  createRoleForm() {
    this.formRole = this.fb.group({
      ipRoleName: [],
      ipUnitPrice: []
    });
  }

  btnSaveClick(event: any) {
    if (this.formRole.valid) {
      this.saveRole();
    }
  }

  btnCancelClick(event: any) {
    this.formRole.patchValue({
      ipRoleName: '',
      ipUnitPrice: ''
    });
    this.selectedRole = null;
  }

  gridRolesOnRowSelect(event) {
    //console.log(this.selectedUser);
    this.formRole.patchValue({
      ipRoleName: this.selectedRole.Name
    });
  }

  getAllRoles() {
    this.isLoading = true;
    this.roleService.getAllRoles().subscribe(
      (res) => {
        this.roles = res;
        this.isLoading = false;
      },
      error => {
        console.log(error);
        this.isLoading = false;
      }
    );
  }

  saveRole() {
    const role: Role = new Role();
    role.Id = this.selectedRole ? this.selectedRole.Id : null;
    role.Name = this.formRole.value.ipRoleName;
    this.isLoading = true;
    this.roleService.saveRole(role).subscribe((res) => {
      console.log(res);
      this.isLoading = false;
      this.getAllRoles();
    },
      error => {
        console.log(error);
        this.isLoading = false;
      }
    );
  }

}
