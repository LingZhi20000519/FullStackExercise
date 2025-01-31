import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../envirments/environment';
import { Employee } from '../models/employee';
import { Observable } from 'rxjs';

@Injectable({providedIn: 'root'})
export class EmployeeService {
  private apiUrl = `${environment.apiUrl}/employee`
  constructor(private http: HttpClient) { }
  getEmployees(): Observable<Employee[]> { return this.http.get<Employee[]>(this.apiUrl); }
  getEmployeeById(id: number): Observable<Employee> { return this.http.get<Employee>(`${this.apiUrl}/${id}`) }
  createEmployees(employee: Employee): Observable<Employee> { return this.http.post<Employee>(this.apiUrl, employee) }
  deleteEmployees(id: number): Observable<void> { return this.http.delete<void>(`${this.apiUrl}/${id}`) }
  editEmployees(employee: Employee): Observable<Employee> { return this.http.put<Employee>(`${this.apiUrl}/${employee.id}`,employee) }
}
