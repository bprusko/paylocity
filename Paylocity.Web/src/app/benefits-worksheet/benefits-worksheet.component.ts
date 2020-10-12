import { Component, OnInit } from '@angular/core';
import { Paycheck } from '../ViewModels/Paycheck';

@Component({
  selector: 'benefits-worksheet',
  templateUrl: './benefits-worksheet.component.html',
  styleUrls: ['./benefits-worksheet.component.scss']
})
export class BenefitsWorksheetComponent implements OnInit {

  feeInfo:Paycheck;
  showItemizedFees:boolean;
  submittedForm: any;

  constructor() { }

  ngOnInit(): void {
    this.showItemizedFees = false;
  }

  formSubmittedHandler(value: [Paycheck, any]){
    // TODO: Error handling for getting fee info
    // Success
    this.showItemizedFees = true;
    this.feeInfo = value[0];
    this.submittedForm = value[1];

    // Failure
    // If we don't get data back
    // - show error message
    // - do not show itemized fees screen
  }

  editWorksheet(){
    this.showItemizedFees = false;
  }

  resetWorksheet(){
    this.showItemizedFees = false;
    this.submittedForm = null;
  }

}
