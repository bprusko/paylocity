import { Component, Input, OnInit } from '@angular/core';
import { Paycheck } from '../ViewModels/Paycheck';

@Component({
  selector: 'itemized-deductions',
  templateUrl: './itemized-deductions.component.html',
  styleUrls: ['./itemized-deductions.component.scss']
})
export class ItemizedDeductionsComponent implements OnInit {

  @Input()
  paycheck: Paycheck;

  constructor() { }

  ngOnInit(): void {

  }

}
