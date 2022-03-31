import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl } from '@angular/forms';
import { distinctUntilChanged, forkJoin, map, mergeMap, share, shareReplay, tap, zip } from 'rxjs';
import { DataService } from 'src/app/services/data.service';

@Component({
  selector: 'app-make-appointment',
  templateUrl: './make-appointment.component.html',
  styleUrls: ['./make-appointment.component.scss']
})
export class MakeAppointmentComponent implements OnInit {
  appointmentForm = this.fb.group({
    countries: [[]],
    companies: [[]],
    employees: [[]]
  })

  countries;
  companies;
  employees;

  constructor(private data: DataService, private fb: FormBuilder) { }

  ngOnInit(): void {
    this.getDropdownData();
    this.updateDropdownOnChange();
  }

  getDropdownData = () => {
    zip([this.data.getContries(), this.data.getCompanies(), this.data.getEmployees()])
      .pipe(
        tap(([countries, companies, employees]) => {
          this.countries = countries;
          this.companies = companies;
          this.employees = employees;
        })
      ).subscribe();
  }

  updateDropdownOnChange = () => {
    this.appointmentForm.valueChanges
      .pipe(
        distinctUntilChanged((a, b) => JSON.stringify(a) === JSON.stringify(b)),
        tap((v) => {
          this.appointmentForm.get('countries').setValue(v.countries);
          this.appointmentForm.get('employees').setValue([...new Set([...v.employees, ...this.employees.filter(e => v.companies.includes(e.companyId)).map(e => e.id)])]);
          this.appointmentForm.get('companies').setValue([...new Set([...v.companies, ...this.companies.filter(c => v.countries.includes(c.countryId)).map(c => c.id)])]);
        })
      )
      .subscribe();
  }

}
