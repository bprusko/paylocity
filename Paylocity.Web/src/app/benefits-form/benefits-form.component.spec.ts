import { ComponentFixture, fakeAsync, TestBed, tick } from '@angular/core/testing';
import { FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { BenefitsFormComponent } from './benefits-form.component';
import { PaycheckService } from '../services/paycheck.service';
import { of } from 'rxjs';

describe('BenefitsFormComponent', () => {
  let component: BenefitsFormComponent;
  let fixture: ComponentFixture<BenefitsFormComponent>;

  const feeInfo = {
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
              return of(feeInfo);
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
      spyOn(component.formSubmitted, 'emit');
      const button = fixture.nativeElement.querySelector('#calculateButton');
      button.click();
      tick();
      fixture.detectChanges();
      expect(component.formSubmitted.emit).toHaveBeenCalledWith(feeInfo);
    }));

  });
});
