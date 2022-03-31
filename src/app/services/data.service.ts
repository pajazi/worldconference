import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { ICompany } from '../models/company';
import { ICountry } from '../models/country';
import { IEmployee } from '../models/employee';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor(private http: HttpClient) { }

  getContries = () => this.http.get<ICountry[]>(`${environment.apiUrl}/country`)
  
  getCompanies = () => this.http.get<ICompany[]>(`${environment.apiUrl}/company`)

  getEmployees = () => this.http.get<IEmployee[]>(`${environment.apiUrl}/employee`)

}
