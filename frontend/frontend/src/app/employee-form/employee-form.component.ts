import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Employee } from '../../models/employee';
import { EmployeeService } from '../employee.service';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-employee-form',
  imports: [FormsModule],
  templateUrl: './employee-form.component.html',
  styleUrl: './employee-form.component.css'
})
export class EmployeeFormComponent {
  employee: Employee = {
    id: 0,
    firstName: '',
    lastName: '',
    phone: '',
    email: '',
    position: ''
  }
  errorMessage: string = "";
  constructor(private employeeService: EmployeeService, private router: Router) { }

  onSubmit(): void {
    this.employeeService.createEmployees(this.employee).subscribe({
      next: () => { this.router.navigate(['/']) },
      error: (err) => {
        console.error(err);
        this.errorMessage = `Error:${err.status}`;
      }
    });
  }
}
