import { Component, OnInit } from '@angular/core';

import { EmployeeModalComponent } from './employee.modal.component'
import { Employee } from "./employee.model";
import { EmployeeService } from "./employee.service";

import { GridOptions } from "ag-grid/main";
import { DialogModule, ButtonModule, PanelModule, CalendarModule } from 'primeng/primeng';

@Component({
    selector: 'employee',
    templateUrl: './employee.component.html'
})
export class EmployeeComponent implements OnInit {

    private gridOptions: GridOptions;
    private gridApi;
    private gridColumnApi;
    private selectedEmployee: Employee;
    private editEmployee: boolean = false;
    private closeResult: string
    public enableButtons: boolean = false;

    public rowData: any[];
    public rowSelection = 'single';
    public showEmployeeModal: boolean = false;
    public showCalculatedPayroll: boolean = false;

    public columnDefs = [
        { headerName: 'Id', field: 'employeeId' },
        { headerName: 'FirstName', field: 'firstName' },
        { headerName: 'LastName', field: 'lastName' },
        {
            headerName: 'Dependants',
            valueGetter: function getDependantCount(params) {
                return params.data.dependants.length;
            }}
    ];

    constructor(private employeeService: EmployeeService) {

    }

    ngOnInit() {

        this.refreshEmployees();
    }

    public showEmployeeForm(isEdit: boolean = false) {

        this.showEmployeeModal = true;
        this.editEmployee = isEdit;
    }

    public closeEmployeeForm() {

        console.log(this.selectedEmployee);
        this.showEmployeeModal = false;
        this.editEmployee = false;

    }

    public payrollModalClosed(show: boolean) {

        this.showCalculatedPayroll = show;
    }

    public calculatePayroll() {

        this.showCalculatedPayroll = true;
    }

    public addEmployee(employee: Employee) {

        if (employee != undefined) {

            this.employeeService.AddEmployee(employee).subscribe(result => {

                this.closeEmployeeForm();
                this.refreshGrid()

            }, error => console.error(error));
        }
    }

    public updateEmployee(employee: Employee) {

        if (employee != undefined) {

            this.employeeService.UpdateEmployee(employee).subscribe(result => {

                this.closeEmployeeForm();
                this.refreshEmployees();

            }, error => console.error(error));
        }
    }

    public deleteEmployee() {

        var selectedEmployee = this.gridApi.getSelectedRows()[0] as Employee;

        this.employeeService.RemoveEmployee(selectedEmployee.employeeId).subscribe(result => {

            this.refreshGrid()

            if (this.gridApi.getDisplayedRowCount() == 0) {
                this.selectedEmployee = new Employee(0, '', '', []);
                console.log(this.selectedEmployee);
            }

        }, error => console.error(error));
    }

    private refreshEmployees() {

        this.employeeService.GetEmployees().subscribe(result => {
            this.rowData = result as Employee[];

            if (this.gridApi) {

                this.gridApi.setRowData(this.rowData);                 
            }
           
        }, error => console.error(error));
    }

    private refreshGrid() {
        this.refreshEmployees();
        this.gridApi.deselectAll();
    }
    
    onGridReady(params) {
        this.gridApi = params.api;
        this.gridColumnApi = params.columnApi;
        params.api.sizeColumnsToFit();
    }

    onSelectionChanged() {

        this.selectedEmployee = this.gridApi.getSelectedRows()[0] as Employee;
    }    
}
