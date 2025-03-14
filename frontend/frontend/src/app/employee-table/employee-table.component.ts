import { Component, OnInit } from '@angular/core';
import { Employee } from '../../models/employee';
import { EmployeeService } from '../employee.service';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';

@Component({
  selector: 'app-employee-table',
  imports: [CommonModule],
  templateUrl: './employee-table.component.html',
  styleUrl: './employee-table.component.css'
})
export class EmployeeTableComponent {
  employees: Employee[] = [];
  constructor(private employeeService: EmployeeService,private router:Router) { }

  // Init Employee Form
  ngOnInit() {
    this.employeeService.getEmployees().subscribe((data: Employee[]) => {
      this.employees = data;
      console.log(data)
    });
  }

  // delete Employee
  deleteEmployee(id:number){this.employeeService.deleteEmployees(id).subscribe({
    next:(response)=>{this.employees = this.employees.filter(e=>e.id!==id);},
    error:(err)=>{console.log(err);}
  })}

  // edit Employee
  editEmployee(id:number):void{this.router.navigate(['/edit',id]);}
}
