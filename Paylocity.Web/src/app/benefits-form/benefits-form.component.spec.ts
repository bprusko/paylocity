import { ComponentFixture, fakeAsync, TestBed, tick } from '@angular/core/testing';
import { FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { BenefitsFormComponent } from './benefits-form.component';
import { PaycheckService } from '../services/paycheck.service';
import { of } from 'rxjs';
import { Paycheck } from '../ViewModels/Paycheck';

describe('BenefitsFormComponent', () => {
  let component: BenefitsFormComponent;
  let fixture: ComponentFixture<BenefitsFormComponent>;

  const paycheck:Paycheck = {
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

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BenefitsFormComponent ],
      imports: [ ReactiveFormsModule ],
      providers: [
        FormBuilder,
        {
          provide: PaycheckService,
          useValue: {
            getPaycheck: function () {
              return of(paycheck);
            }
          }
        }
      ]
    })
      .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BenefitsFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('creates component', () => {
    expect(component).toBeTruthy();
  });

  describe('Add Dependent', () => {

    it('increases count for number of dependents', fakeAsync(() => {
      expect(component.totalDependents).toEqual(0);
      component.addDependent();
      expect(component.totalDependents).toEqual(1);
    }));

    it('add new inputs for new dependent', fakeAsync(() => {
      expect(component.dependents.length).toEqual(0);
      component.addDependent();
      expect(component.dependents.length).toEqual(1);
    }));

  });

  describe('Remove Dependent', () => {

    it('decreases count for number of dependents', fakeAsync(() => {
      component.addDependent();
      expect(component.totalDependents).toEqual(1);
      component.removeDependent(0);
      expect(component.totalDependents).toEqual(0);
    }));

    it('removes inputs for existing dependent', fakeAsync(() => {
      component.addDependent();
      component.addDependent();
      expect(component.dependents.length).toEqual(2);
      component.dependents.at(0).patchValue({ firstName: 'First Name #1', lastName: 'Last Name #1' });
      component.dependents.at(1).patchValue({ firstName: 'First Name #2', lastName: 'Last Name #2' });

      component.removeDependent(1);
      expect(component.dependents.length).toEqual(1);
      let dependents = component.benefitsForm.value['dependents'];
      expect(dependents[0].firstName).toEqual('First Name #1');
      expect(dependents[0].lastName).toEqual('Last Name #1');
    }));

  });

  describe('Clicking the calculate button', () => {

    it('emits an event with paycheck data', fakeAsync(() => {
      component.employee.patchValue({ firstName: 'First Name #1', lastName: 'Last Name #1' });
      fixture.detectChanges();
      spyOn(component.formSubmitted, 'emit');
      const button = fixture.nativeElement.querySelector('#calculateButton');
      button.click();
      tick();
      fixture.detectChanges();
      expect(component.formSubmitted.emit).toHaveBeenCalledWith([paycheck, component.benefitsForm]);
    }));

  });
});
