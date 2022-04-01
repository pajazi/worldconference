import { Component, Input, OnChanges, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { map, Observable, tap } from 'rxjs';
import { DataService } from '../../services/data.service';
@Component({
  selector: 'app-appointment-table',
  templateUrl: './appointment-table.component.html',
  styleUrls: ['./appointment-table.component.scss']
})
export class AppointmentTableComponent implements OnChanges {
  @ViewChild(MatPaginator) paginator: MatPaginator;
  @Input() selectedCompanies;

  displayedColumns: string[] = ['Company', 'Country', 'City', 'Employees'];
  company$: Observable<{ data: any[], pagination: any }>;

  constructor(private data: DataService) { }

  ngOnChanges(): void {
    this.updateTable()
  }

  updateTable() {
    if (this.selectedCompanies.length)
      this.company$ = this.data.getCompanyTable(this.selectedCompanies, (this.paginator?.pageIndex + 1) || 1, (this.paginator?.pageSize) || 10)
        .pipe(
          map(response => ({
            data: response.body.map(country => ({...country, employees: country.employees.map(e => e.name).join(', ')})),
            pagination: JSON.parse(response.headers.get('Pagination'))
          })),
          tap((e) => console.log(e))
        )
  }

}
