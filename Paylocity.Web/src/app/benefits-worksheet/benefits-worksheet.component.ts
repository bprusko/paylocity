import { Component, OnInit } from '@angular/core';
import { Paycheck } from '../ViewModels/Paycheck';

@Component({
  selector: 'benefits-worksheet',
  templateUrl: './benefits-worksheet.component.html',
  styleUrls: ['./benefits-worksheet.component.scss']
})
export class BenefitsWorksheetComponent implements OnInit {

  paycheck:Paycheck;
  showErrorMessage:boolean;
  showItemizedDeductions:boolean;
  submittedForm: any;

  constructor() { }

  ngOnInit(): void {
    this.showItemizedDeductions = false;
  }

  formSubmittedHandler(value: [Paycheck, any]){
    this.paycheck = value[0];
    this.submittedForm = value[1];

    if(this.paycheck != null) {
      this.showItemizedDeductions = true;
      this.showErrorMessage = false;
    }
    else {
      this.showErrorMessage = true;
    }

  }

  editWorksheet(){
    this.showItemizedDeductions = false;
  }

  resetWorksheet(){
    this.showItemizedDeductions = false;
    this.submittedForm = null;
  }

}
