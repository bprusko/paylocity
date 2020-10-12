import { Component, EventEmitter, OnInit, Output } from '@angular/core';
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
  formSubmitted: EventEmitter<Paycheck> = new EventEmitter<Paycheck>();

  constructor(private formBuilder: FormBuilder,
    private paycheckService: PaycheckService) { }

  ngOnInit(): void {

    this.benefitsForm = this.formBuilder.group({
      employee: this.formBuilder.group({
        firstName: [''],
        lastName: [''],
      }),
      dependents: this.formBuilder.array([])
    });

    this.totalDependents = 0;

  }

  get dependents() {
    return this.benefitsForm.get('dependents') as FormArray;
  }

  addDependent() {
    this.dependents.push(this.formBuilder.group({
      firstName: ['', Validators.required],
      lastName: [''],
    }));
    this.totalDependents++;
  }

  removeDependent(index: number) {
    this.dependents.removeAt(index);
    this.totalDependents--;
  }

  calculateFees() {
    this.paycheckService.getPaycheck(this.benefitsForm.value).subscribe(response => {
      this.formSubmitted.emit(response as Paycheck);
    });
  }

}
