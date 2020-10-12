import { ComponentFixture, TestBed } from '@angular/core/testing';
import { Paycheck } from '../ViewModels/Paycheck';

import { ItemizedFeesComponent } from './itemized-fees.component';

describe('ItemizedFeesComponent', () => {
  let component: ItemizedFeesComponent;
  let fixture: ComponentFixture<ItemizedFeesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ItemizedFeesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ItemizedFeesComponent);
    component = fixture.componentInstance;
    component.feeInfo = new Paycheck();
    fixture.detectChanges();
  });

  it('creates component', () => {
    expect(component).toBeTruthy();
  });

  it('displays page title', () => {
    component.feeInfo = {
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

  it('displays employee fees', () => {
    component.feeInfo = {
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

    let employeeFeesTable = fixture.nativeElement.querySelector('#employeeFeesTable');
    expect(employeeFeesTable).toBeDefined();
  });

  describe('When an employee has dependents', () => {

    it('displays a table with dependent fee info', () => {

      component.feeInfo = {
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

      let dependentTable = fixture.nativeElement.querySelector('#dependentFeesTable');
      expect(dependentTable).toBeDefined();
    });

  });

  describe('When an employee does not have dependents', () => {

    it('displays a table with dependent fee info', () => {
      component.feeInfo = {
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

  it('displays total fees', () => {
    component.feeInfo = {
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

    let totalFeesTable = fixture.nativeElement.querySelector('#totalFeesTable');
    expect(totalFeesTable.textContent).toBeDefined();
  });
});
