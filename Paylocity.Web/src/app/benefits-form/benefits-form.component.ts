import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Paycheck } from '../ViewModels/Paycheck';
import { PaycheckService } from '../services/paycheck.service';

@Component({
  selector: 'benefits-form',
  templateUrl: './benefits-form.component.html',
  styleUrls: ['./benefits-form.component.scss']
})
export class BenefitsFormComponent implements OnInit {

  benefitsForm: FormGroup;
  totalDependents: number;

  @Output()
  formSubmitted: EventEmitter<[Paycheck, any]> = new EventEmitter<[Paycheck, any]>();

  @Input()
  submittedForm: any;

  constructor(private formBuilder: FormBuilder,
    private paycheckService: PaycheckService) { }

  ngOnInit(): void {

    if(this.submittedForm != null) {

      this.benefitsForm = this.submittedForm;
      this.totalDependents = this.dependents.length;

    } else {

      this.benefitsForm = this.buildBenefitsForm();
      this.totalDependents = 0;

    }

  }

  buildBenefitsForm(): any {
    return this.formBuilder.group({
      employee: this.formBuilder.group({
        firstName: ['', Validators.required],
        lastName: ['', Validators.required],
      }),
      dependents: this.formBuilder.array([])
    });
  }

  get dependents() {
    return this.benefitsForm.get('dependents') as FormArray;
  }

  get employee() {
    return this.benefitsForm.get('employee') as FormGroup;
  }

  addDependent() {
    this.dependents.push(this.formBuilder.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
    }));
    this.totalDependents++;
  }

  removeDependent(index: number) {
    this.dependents.removeAt(index);
    this.totalDependents--;
  }

  calculateDeductions() {
    this.paycheckService.getPaycheck(this.benefitsForm.value).subscribe(response => {
      this.formSubmitted.emit([response as Paycheck, this.benefitsForm]);
    });
  }

}
