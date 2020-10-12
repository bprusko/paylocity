import { Dependent } from './Dependent';
import { Employee } from './Employee';
import { Deduction } from './Deduction';

export class Paycheck{
    biweeklyBase:number;
    dependents:Array<Dependent>;
    employee:Employee;
    netPay:number;
    totalDeductions: Deduction;
}