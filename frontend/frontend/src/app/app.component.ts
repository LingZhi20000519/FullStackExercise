import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { EmployeeTableComponent } from './employee-table/employee-table.component'

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, EmployeeTableComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'frontend';
}