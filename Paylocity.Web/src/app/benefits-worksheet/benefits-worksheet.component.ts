import { Component, OnInit } from '@angular/core';
import { FeeInfo } from '../ViewModels/FeeInfo';

@Component({
  selector: 'benefits-worksheet',
  templateUrl: './benefits-worksheet.component.html',
  styleUrls: ['./benefits-worksheet.component.scss']
})
export class BenefitsWorksheetComponent implements OnInit {

  showItemizedFees:boolean;
  feeInfo:FeeInfo;

  constructor() { }

  ngOnInit(): void {
    this.showItemizedFees = false;
  }

  formSubmittedHandler(value: FeeInfo){
    // TODO: Error handling for getting fee info

    // This represents successes case
    this.showItemizedFees = true;
    this.feeInfo = value;

    // If we don't get data back
    // - show error message instead
    // - do not show itemized fees screen
  }

  resetWorksheet(){
    this.showItemizedFees = false;
  }

}
