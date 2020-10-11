import { Dependent } from './Dependent';
import { Employee } from './Employee';
import { FeeTotals } from './FeeTotals';

export class FeeInfo{
    employee:Employee;
    dependents:Array<Dependent>;
    feeTotals: FeeTotals;
}