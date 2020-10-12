import { Component, Input, OnInit } from '@angular/core';
import { Dependent } from '../ViewModels/Dependent';
import { Employee } from '../ViewModels/Employee';
import { Paycheck } from '../ViewModels/Paycheck';
import { Deduction } from '../ViewModels/Deduction';

@Component({
  selector: 'itemized-fees',
  templateUrl: './itemized-fees.component.html',
  styleUrls: ['./itemized-fees.component.scss']
})
export class ItemizedFeesComponent implements OnInit {

  @Input()
  feeInfo: Paycheck;

  constructor() { }

  ngOnInit(): void {

  }

}
