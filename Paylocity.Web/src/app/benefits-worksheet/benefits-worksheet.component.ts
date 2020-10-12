import { Component, OnInit } from '@angular/core';
import { Paycheck } from '../ViewModels/Paycheck';

@Component({
  selector: 'benefits-worksheet',
  templateUrl: './benefits-worksheet.component.html',
  styleUrls: ['./benefits-worksheet.component.scss']
})
export class BenefitsWorksheetComponent implements OnInit {

  paycheck:Paycheck;
  showItemizedDeductions:boolean;
  submittedForm: any;

  constructor() { }

  ngOnInit(): void {
    this.showItemizedDeductions = false;
  }

  formSubmittedHandler(value: [Paycheck, any]){
    // TODO: Error handling for getting fee info
    // Success
    this.showItemizedDeductions = true;
    this.paycheck = value[0];
    this.submittedForm = value[1];

    // Failure
    // If we don't get data back
    // - show error message
    // - do not show itemized fees screen
  }

  editWorksheet(){
    this.showItemizedDeductions = false;
  }

  resetWorksheet(){
    this.showItemizedDeductions = false;
    this.submittedForm = null;
  }

}
