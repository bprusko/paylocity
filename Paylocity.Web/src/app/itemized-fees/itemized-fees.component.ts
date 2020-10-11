import { Component, Input, OnInit } from '@angular/core';
import { Dependent } from '../ViewModels/Dependent';
import { Employee } from '../ViewModels/Employee';
import { FeeInfo } from '../ViewModels/FeeInfo';
import { FeeTotals } from '../ViewModels/FeeTotals';

@Component({
  selector: 'itemized-fees',
  templateUrl: './itemized-fees.component.html',
  styleUrls: ['./itemized-fees.component.scss']
})
export class ItemizedFeesComponent implements OnInit {

  @Input()
  feeInfo: FeeInfo;

  constructor() { }

  ngOnInit(): void {

  }

}
