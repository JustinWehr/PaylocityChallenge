
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
   
    public employeeFormGroup: FormGroup;
    public dependants: Dependant[] = [];
    public formEmployee: Employee = new Employee(0, '', '', '', this.dependants);

    constructor(private employeeService: EmployeeService) {
       
    }

    //fires when input changes
    ngOnChanges() {

        if (!this.display) {
            return;
        }

        this.employeeFormGroup = new FormGroup({
            firstName: new FormControl(null, Validators.required),
            lastName: new FormControl(null, Validators.required),
            email: new FormControl(null, [Validators.required,
            Validators.pattern("[^ @]*@[^ @]*")]),
            dependants: new FormArray([])
        });

        if (this.employee != undefined && this.edit) {
            
            this.formEmployee = this.employee;
            this.dependants = this.formEmployee.dependants;

            for (var i = 0, len = this.dependants.length; i < len; i++) {
                this.addDependant(this.dependants[i].firstName, this.dependants[i].lastName);
            }
        }
    }

    addDependant(firstName: string, lastName: string): void {

        let dependants = this.employeeFormGroup.get('dependants') as FormArray;
        dependants.push(this.createDependant(firstName, lastName));
    }

    createDependant(firstName: string, lastName: string): FormGroup {
        return new FormGroup({
            firstName: new FormControl(firstName, Validators.required),
            lastName: new FormControl(lastName, Validators.required),
        });
    }

    removeDependant(index: number) {
        let dependants = this.employeeFormGroup.get('dependants') as FormArray;
        dependants.removeAt(index);
    } 

    addEmployee() {

        if (this.employeeFormGroup.valid) {

            this.buildEmployeeDependants();
            this.addedEmployee.emit(this.formEmployee);            
        }
    }

    editEmployee() {

        if (this.employeeFormGroup.valid) {

            this.buildEmployeeDependants();
            this.editedEmployee.emit(this.formEmployee);
        }
    }

    buildEmployeeDependants(): void {

        this.formEmployee.dependants = this.employeeFormGroup.controls['dependants'].value as Dependant[];       
    }

    //setForm() {
    //    this.employeeFormGroup.patchValue({
    //        firstName: this.employee.firstName,
    //        lastName: this.employee.lastName,
    //        email: this.employee.email
    //    })

    //    for (var i = 0, len = this.employee.dependants.length; i < len; i++) {
    //        console.log(this.employee.dependants[i].name);
    //        this.addDependant(this.employee.dependants[i].name);
    //    }
    //}

    close() {

        this.employeeFormGroup.reset();
        this.addedEmployee.emit(undefined);
    }
}