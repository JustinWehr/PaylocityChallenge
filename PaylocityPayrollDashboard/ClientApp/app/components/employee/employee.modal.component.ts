
import { Component, Input, Output, EventEmitter } from '@angular/core';
import { FormControl, FormGroup, FormArray, Validators  } from '@angular/forms';
import { Employee } from "./employee.model";
import { Dependant } from './dependant.model'
import { EmployeeService } from "./employee.service";

@Component({
    selector: 'employeeModal',
    templateUrl: './employee.modal.component.html'
})
export class EmployeeModalComponent {
    @Input() display: boolean;
    @Input() employee: Employee;
    @Input() edit: boolean;
    
    @Output() addedEmployee = new EventEmitter<Employee>();
    @Output() editedEmployee = new EventEmitter<Employee>();
    @Output() closeEmployee = new EventEmitter<Employee>();
   
    public employeeFormGroup: FormGroup;
    public firstName: FormControl;
    public lastName: FormControl;
    public dependants: FormArray[];

    public formEmployee: Employee; 

    constructor(private employeeService: EmployeeService) {
        this.createForm();
    }

    //fires when input changes
    public ngOnChanges() {

        if (!this.display) {
            return;
        }
        
        //recreate the form and local employee since we a reloading the dialog
        this.createForm();
        this.formEmployee = new Employee(0, '', '', new Array<Dependant>());

        // rebuild the form if we doing an edit. 
        if (this.employee != undefined && this.edit) {
            
            this.formEmployee = this.employee;
            let dependants = this.formEmployee.dependants;

            for (var i = 0, len = dependants.length; i < len; i++) {
                this.addDependant(dependants[i].firstName, dependants[i].lastName);
            }
        }
    }

    private createForm() {
        this.employeeFormGroup = new FormGroup({
            firstName: new FormControl('', Validators.required),
            lastName: new FormControl('', Validators.required),
            dependants: new FormArray([])
        });
    }   

    private addDependant(firstName: string, lastName: string): void {

        let dependants = this.employeeFormGroup.controls.dependants as FormArray;
        dependants.push(this.createDependant(firstName, lastName));
    }

    private createDependant(firstName: string, lastName: string): FormGroup {
        return new FormGroup({
            firstName: new FormControl(firstName, Validators.required),
            lastName: new FormControl(lastName, Validators.required) 
        });
    }

    private removeDependant(index: number) {
        let dependants = this.employeeFormGroup.controls.dependants as FormArray;
        dependants.removeAt(index);
    } 

    public addEmployee() {

        if (this.employeeFormGroup.valid) {

            this.buildEmployeeDependants();
            this.addedEmployee.emit(this.formEmployee);            
        }
    }

    public editEmployee() {

        if (this.employeeFormGroup.valid) {

            this.buildEmployeeDependants();
            this.editedEmployee.emit(this.formEmployee);
        }
    }

    private buildEmployeeDependants(): void {

        this.formEmployee.dependants = this.employeeFormGroup.controls.dependants.value as Dependant[];       
    }
    
    public close() {

        this.closeEmployee.emit();
    }
}