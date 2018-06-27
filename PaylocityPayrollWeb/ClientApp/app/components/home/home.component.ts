import { Component } from '@angular/core';

import { GridOptions } from "ag-grid/main";
import { Employee } from "./employee.model";
import { EmployeeService } from "./employee.service";

@Component({
    selector: 'home',
    templateUrl: './home.component.html'
})
export class HomeComponent {

    public gridOptions: GridOptions;
    private closeResult: string;


    constructor(private employeeService: EmployeeService) {
        this.gridOptions = <GridOptions>{};
    }
    columnDefs = [
        { headerName: 'Id', field: 'EmployeeId' },
        { headerName: 'FirstName', field: 'FirstName' },
        { headerName: 'LastName', field: 'LastName' }
    ];

    rowData = this.employeeService.GetEmployees();

    
}
