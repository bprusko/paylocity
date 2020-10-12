import { ComponentFixture, TestBed } from '@angular/core/testing';
import { Paycheck } from '../ViewModels/Paycheck';

import { ItemizedDeductionsComponent } from './itemized-deductions.component';

describe('ItemizedDeductionsComponent', () => {
  let component: ItemizedDeductionsComponent;
  let fixture: ComponentFixture<ItemizedDeductionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ItemizedDeductionsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ItemizedDeductionsComponent);
    component = fixture.componentInstance;
    component.paycheck = new Paycheck();
    fixture.detectChanges();
  });

  it('creates component', () => {
    expect(component).toBeTruthy();
  });

  it('displays page title', () => {
    component.paycheck = {
      biweeklyBase: 2000,
      employee: {
        firstName: "John",
        lastName: "Smith",
        deductions: {
          discount: 0,
          gross: 38.46,
          net: 38.46
        }
      },
      dependents: [],
      netPay: 1961.54,
      totalDeductions: {
        discount: 0,
        gross: 38.46,
        net: 38.46
      }
    };

    fixture.detectChanges();

    let pageTitle = fixture.nativeElement.querySelector('h2');
    expect(pageTitle.textContent).toEqual('Breakdown of Benefit Deductions for John Smith');
  });

  it('displays employee deductions', () => {
    component.paycheck = {
      biweeklyBase: 2000,
      employee: {
        firstName: "John",
        lastName: "Smith",
        deductions: {
          discount: 0,
          gross: 38.46,
          net: 38.46
        }
      },
      dependents: [],
      netPay: 1961.54,
      totalDeductions: {
        discount: 0,
        gross: 38.46,
        net: 38.46
      }
    };
    fixture.detectChanges();

    let employeeFeesTable = fixture.nativeElement.querySelector('#employeeDeductionsTable');
    expect(employeeFeesTable).toBeDefined();
  });

  describe('When an employee has dependents', () => {

    it('displays a table with dependent deductions', () => {

      component.paycheck = {
        biweeklyBase: 2000,
        employee: {
          firstName: "John",
          lastName: "Smith",
          deductions: {
            discount: 0,
            gross: 38.46,
            net: 38.46
          }
        },
        dependents: [
          {
            firstName: "Dependent1",
            deductions: {
              discount: 1.92,
              gross: 19.23,
              net: 17.31
            }
          },
          {
            firstName: "Dependent2",
            deductions: {
              discount: 0,
              gross: 19.23,
              net: 19.23
            }
          }
        ],
        netPay: 1925,
        totalDeductions: {
          discount: 1.92,
          gross: 76.92,
          net: 75
        }
      };

      fixture.detectChanges();

      let dependentTable = fixture.nativeElement.querySelector('#dependentDeductionsTable');
      expect(dependentTable).toBeDefined();
    });

  });

  describe('When an employee does not have dependents', () => {

    it('displays a table with dependent deductions', () => {
      component.paycheck = {
        biweeklyBase: 2000,
        employee: {
          firstName: "John",
          lastName: "Smith",
          deductions: {
            discount: 0,
            gross: 38.46,
            net: 38.46
          }
        },
        dependents: [],
        netPay: 1961.54,
        totalDeductions: {
          discount: 0,
          gross: 38.46,
          net: 38.46
        }
      };

      fixture.detectChanges();

      let noDependentsMessage = fixture.nativeElement.querySelector('#noDependentsMessage p');
      expect(noDependentsMessage.textContent).toContain('Not Applicable');
    });

  });

  it('displays total deductions', () => {
    component.paycheck = {
      biweeklyBase: 2000,
      employee: {
        firstName: "John",
        lastName: "Smith",
        deductions: {
          discount: 0,
          gross: 38.46,
          net: 38.46
        }
      },
      dependents: [],
      netPay: 1961.54,
      totalDeductions: {
        discount: 0,
        gross: 38.46,
        net: 38.46
      }
    };

    fixture.detectChanges();

    let totalFeesTable = fixture.nativeElement.querySelector('#totalDeductionsTable');
    expect(totalFeesTable.textContent).toBeDefined();
  });
});
