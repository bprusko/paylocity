import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FeeInfo } from '../ViewModels/FeeInfo';

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
    component.feeInfo = new FeeInfo();
    fixture.detectChanges();
  });

  it('creates component', () => {
    expect(component).toBeTruthy();
  });

  it('displays page title', () => {
    component.feeInfo = {
      employee: {
        firstName: "John",
        lastName: "Smith",
        feeTotals: {
          discount: 0,
          gross: 1000,
          net: 1000
        }
      },
      dependents: [],
      feeTotals: {
        discount: 50,
        gross: 2000,
        net: 1950
      }
    };

    fixture.detectChanges();

    let pageTitle = fixture.nativeElement.querySelector('h2');
    expect(pageTitle.textContent).toEqual('Breakdown of Benefit Fees for John Smith');
  });

  it('displays employee fees', () => {
    component.feeInfo = {
      employee: {
        firstName: "John",
        lastName: "Smith",
        feeTotals: {
          discount: 0,
          gross: 1000,
          net: 1000
        }
      },
      dependents: [],
      feeTotals: {
        discount: 50,
        gross: 2000,
        net: 1950
      }
    };

    fixture.detectChanges();

    let employeeFeesTable = fixture.nativeElement.querySelector('#employeeFeesTable');
    expect(employeeFeesTable).toBeDefined();
  });

  describe('When an employee has dependents', () => {

    it('displays a table with dependent fee info', () => {
      component.feeInfo = {
        employee: {
          firstName: "John",
          lastName: "Smith",
          feeTotals: {
            discount: 0,
            gross: 1000,
            net: 1000
          }
        },
        dependents: [
          {
            firstName: "Dependent1",
            feeTotals: {
              discount: 50,
              gross: 500,
              net: 450
            }
          },
          {
            firstName: "Dependent2",
            feeTotals: {
              discount: 0,
              gross: 500,
              net: 500
            }
          }
        ],
        feeTotals: {
          discount: 50,
          gross: 2000,
          net: 1950
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
        employee: {
          firstName: "John",
          lastName: "Smith",
          feeTotals: {
            discount: 0,
            gross: 1000,
            net: 1000
          }
        },
        dependents: [],
        feeTotals: {
          discount: 50,
          gross: 2000,
          net: 1950
        }
      };

      fixture.detectChanges();

      let noDependentsMessage = fixture.nativeElement.querySelector('#noDependentsMessage p');
      expect(noDependentsMessage.textContent).toContain('Not Applicable');
    });

  });

  it('displays total fees', () => {
    component.feeInfo = {
      employee: {
        firstName: "John",
        lastName: "Smith",
        feeTotals: {
          discount: 0,
          gross: 1000,
          net: 1000
        }
      },
      dependents: [],
      feeTotals: {
        discount: 50,
        gross: 2000,
        net: 1950
      }
    };

    fixture.detectChanges();

    let totalFeesTable = fixture.nativeElement.querySelector('#totalFeesTable');
    expect(totalFeesTable.textContent).toBeDefined();
  });
});
