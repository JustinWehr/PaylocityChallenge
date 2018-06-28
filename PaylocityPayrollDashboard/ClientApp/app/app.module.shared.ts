import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CommonModule } from '@angular/common';
import { HttpModule } from '@angular/http';
import { HttpClientModule } from '@angular/common/http'
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AgGridModule } from 'ag-grid-angular';
import { DialogModule, ButtonModule, PanelModule, CalendarModule } from 'primeng/primeng';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { EmployeeComponent } from './components/employee/employee.component';
import { EmployeeModalComponent } from './components/employee/employee.modal.component'
import { PayrollDetailModalComponent } from './components/payroll/payrolldetail.modal.component'

import { EmployeeService } from './components/employee/employee.service';
import { PayrollService } from './components/payroll/payroll.service';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        EmployeeComponent,
        EmployeeModalComponent,
        PayrollDetailModalComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        HttpClientModule,
        FormsModule,
        ReactiveFormsModule,
        BrowserAnimationsModule,
        BrowserModule,
        AgGridModule.withComponents([]),
        DialogModule,ButtonModule, PanelModule, CalendarModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'employee', pathMatch: 'full' },
            { path: 'employee', component: EmployeeComponent },
            { path: '**', redirectTo: 'employee' }
        ])
    ],
    providers: [
        EmployeeService, PayrollService
    ]

})
export class AppModuleShared {
}
