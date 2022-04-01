import { HttpClient, HttpParams } from '@angular/common/http';
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

  getCompanyTable = (companyIds: number[], page, itemsPerPage) => this.http.get<any[]>(
    `${environment.apiUrl}/company/table?${companyIds.map(id => `CompanyId=${id}`).join('&')}
      &pageNumber=${page}&pageSize=${itemsPerPage}`, { observe: 'response' })

}
