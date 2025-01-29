import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Employee } from '../../models/employee';
import { EmployeeService } from '../employee.service';
import { Router,ActivatedRoute } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-employee-form',
  imports: [FormsModule,CommonModule],
  templateUrl: './employee-form.component.html',
  styleUrl: './employee-form.component.css'
})
export class EmployeeFormComponent implements OnInit {
  employee: Employee = {
    id: 0,
    firstName: '',
    lastName: '',
    phone: '',
    email: '',
    position: ''
  }
  errorMessage: string = "";
  isEditing:boolean=false;
  constructor(private employeeService: EmployeeService, private router: Router,private route:ActivatedRoute) { }

  ngOnInit() {
    this.route.paramMap.subscribe((result)=>{
        const id = result.get('id');
        if(id)
        {
          // edit
          this.isEditing = true;
          console.log("Edit");
          this.employeeService.getEmployeeById(Number(id)).subscribe({
            next:(result)=>{this.employee = result},
            error:(err) => this.errorMessage = `Error:${err.status} - ${err.errorMessage}`
          });
        }
        else
        {
          // create
          this.isEditing = false;
          console.log("Create");
        }
      }
    );
  }

  onSubmit(): void {
    if(this.isEditing){
      this.employeeService.editEmployees(this.employee).subscribe({
        next: () => { this.router.navigate(['/']) },
        error: (err) => {
          console.error(err);
          this.errorMessage = `Error in Edit:${err.status} - ${err.errorMessage}`;
        }
      });
    }
    else{
      this.employeeService.createEmployees(this.employee).subscribe({
        next: () => { this.router.navigate(['/']) },
        error: (err) => {
          console.error(err);
          this.errorMessage = `Error in Create:${err.status} - ${err.errorMessage}`;
        }
      });
    }
  }
}
