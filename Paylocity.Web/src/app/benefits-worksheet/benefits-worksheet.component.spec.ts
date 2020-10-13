import { ComponentFixture, fakeAsync, TestBed, tick } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { Component, EventEmitter, Input, Output} from '@angular/core';

import { BenefitsWorksheetComponent } from './benefits-worksheet.component';
import { Paycheck } from '../ViewModels/Paycheck';

describe('BenefitsWorksheetComponent', () => {
  let component: BenefitsWorksheetComponent;
  let fixture: ComponentFixture<BenefitsWorksheetComponent>;

  const paycheck: Paycheck = {
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

  @Component({ selector: 'benefits-form'})
  class MockBenefitsFormComponent {
    @Output() formSubmitted: EventEmitter<[Paycheck, any]> = new EventEmitter<[Paycheck, any]>();
    @Input() submittedForm: any;
  }

  @Component({ selector: 'itemized-deductions'})
  class MockItemizedDeductionsComponent {
    @Input() paycheck: Paycheck;
  }

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [BenefitsWorksheetComponent, MockBenefitsFormComponent, MockItemizedDeductionsComponent]
    })
      .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BenefitsWorksheetComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('creates component', () => {
    expect(component).toBeTruthy();
  });

  it('displays page title', () => {
    let pageTitle = fixture.nativeElement.querySelector('h1');
    expect(pageTitle.textContent).toEqual('Benefit Deductions Worksheet');
  });

  it('initially displays the benefits form', () => {
    const element = fixture.debugElement.query(By.css('benefits-form'));
    expect(element).toBeTruthy();
  });

  describe('When submitting the benefits form succeeds', () => {

    it('calls formSubmittedHandler', () => {
      spyOn(component, 'formSubmittedHandler');
      const element = fixture.debugElement.query(By.css('benefits-form'));
      element.triggerEventHandler('formSubmitted', [paycheck, 'benefits form']);
      expect(component.formSubmittedHandler).toHaveBeenCalledWith([paycheck, 'benefits form']);
    });

    it('shows the itemized fees', () => {
      component.formSubmittedHandler([paycheck, 'benefits form']);
      fixture.detectChanges();
      expect(component.showItemizedDeductions).toBeTrue();
      const element = fixture.nativeElement.querySelector('#itemizedDeductions');
      expect(element).not.toBeNull();
    });

    it('hides the benefits form', () => {
      component.formSubmittedHandler([paycheck, 'benefits form']);
      fixture.detectChanges();
      const element = fixture.nativeElement.querySelector('#benefitsForm');
      expect(element).toBeNull();
    });

    it('stores a copy of the benefits form', () => {
      component.formSubmittedHandler([paycheck, 'benefits form']);
      fixture.detectChanges();
      expect(component.submittedForm).toEqual('benefits form');
    });

    it('updates the binding for benefits form', () => {
      component.formSubmittedHandler([paycheck, 'benefits form']);
      fixture.detectChanges();
      expect(component.paycheck).toEqual(paycheck);
    });

    it('does not show an error message', () => {
      component.formSubmittedHandler([paycheck, 'benefits form']);
      fixture.detectChanges();
      expect(component.showErrorMessage).toBeFalse();
      const element = fixture.nativeElement.querySelector('#worksheetErrorMessage');
      expect(element).toBeNull();
    });

    describe('Clicking the reset worksheet button', () => {
      beforeEach(() => {
        component.formSubmittedHandler([paycheck, 'benefits form']);
        fixture.detectChanges();
      });

      it('calls resetWorksheet', fakeAsync(() => {
        spyOn(component, 'resetWorksheet');

        let button = fixture.debugElement.nativeElement.querySelector('#resetWorksheetButton');
        button.click();
        tick();
        expect(component.resetWorksheet).toHaveBeenCalled();
      }));

      it('sets showItemizedFees to false', fakeAsync(() => {
        expect(component.showItemizedDeductions).toBeTrue();

        let button = fixture.debugElement.nativeElement.querySelector('#resetWorksheetButton');
        button.click();
        tick();

        expect(component.showItemizedDeductions).toBeFalse();
      }));

      it('displays the benefits form again', fakeAsync(() => {
        expect(component.showItemizedDeductions).toBeTrue();

        let button = fixture.debugElement.nativeElement.querySelector('#resetWorksheetButton');
        button.click();
        tick();

        fixture.detectChanges();

        const element = fixture.nativeElement.querySelector('#benefitsForm');
        expect(element).not.toBeNull();
      }));

      it('hides the itemized fees again', fakeAsync(() => {
        expect(component.showItemizedDeductions).toBeTrue();

        let button = fixture.debugElement.nativeElement.querySelector('#resetWorksheetButton');
        button.click();
        tick();

        fixture.detectChanges();

        const element = fixture.nativeElement.querySelector('#itemizedFees');
        expect(element).toBeNull();
      }));

      it('sets submittedForm to null', fakeAsync(() => {
        let button = fixture.debugElement.nativeElement.querySelector('#resetWorksheetButton');
        button.click();
        tick();

        fixture.detectChanges();

        expect(component.submittedForm).toBeNull();
      }));

    });

    describe('Clicking the edit worksheet button', () => {
      beforeEach(() => {
        component.formSubmittedHandler([paycheck, 'benefits form']);
        fixture.detectChanges();
      });

      it('calls editWorksheet', fakeAsync(() => {
        spyOn(component, 'editWorksheet');

        let button = fixture.debugElement.nativeElement.querySelector('#editWorksheetButton');
        button.click();
        tick();
        expect(component.editWorksheet).toHaveBeenCalled();
      }));

      it('sets showItemizedFees to false', fakeAsync(() => {
        expect(component.showItemizedDeductions).toBeTrue();

        let button = fixture.debugElement.nativeElement.querySelector('#editWorksheetButton');
        button.click();
        tick();

        expect(component.showItemizedDeductions).toBeFalse();
      }));

      it('displays the benefits form again', fakeAsync(() => {
        expect(component.showItemizedDeductions).toBeTrue();

        let button = fixture.debugElement.nativeElement.querySelector('#resetWorksheetButton');
        button.click();
        tick();

        fixture.detectChanges();

        const element = fixture.nativeElement.querySelector('#benefitsForm');
        expect(element).not.toBeNull();
      }));

      it('hides the itemized fees again', fakeAsync(() => {
        expect(component.showItemizedDeductions).toBeTrue();

        let button = fixture.debugElement.nativeElement.querySelector('#editWorksheetButton');
        button.click();
        tick();

        fixture.detectChanges();

        const element = fixture.nativeElement.querySelector('#itemizedFees');
        expect(element).toBeNull();
      }));

    });

  });

  describe('When submitting the benefits form fails', () => {
    it('shows an error message', () => {
      component.formSubmittedHandler([null, 'benefits form']);
      fixture.detectChanges();
      const element = fixture.nativeElement.querySelector('#worksheetErrorMessage');
      expect(component.showErrorMessage).toBeTrue();
      expect(element).not.toBeNull();
      expect(element.textContent).toContain('Sorry, there was an error calculating the deductions. If this continues, please contact support.');

    });

    it('does not show the itemized fees', () => {
      component.formSubmittedHandler([null, 'benefits form']);
      fixture.detectChanges();
      expect(component.showItemizedDeductions).toBeFalse();
      const element = fixture.nativeElement.querySelector('#itemizedDeductions');
      expect(element).toBeNull();
    });
  });

});
