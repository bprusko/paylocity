import { ComponentFixture, fakeAsync, TestBed, tick } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { Component, EventEmitter, Input, Output} from '@angular/core';

import { BenefitsWorksheetComponent } from './benefits-worksheet.component';
import { FeeInfo } from '../ViewModels/FeeInfo';

describe('BenefitsWorksheetComponent', () => {
  let component: BenefitsWorksheetComponent;
  let fixture: ComponentFixture<BenefitsWorksheetComponent>;
  let eventValue: FeeInfo;

  @Component({ selector: 'benefits-form'})
  class MockBenefitsFormComponent {
    @Output() formSubmitted: EventEmitter<FeeInfo> = new EventEmitter<FeeInfo>();
  }

  @Component({ selector: 'itemized-fees'})
  class MockItemizedFeesComponent {
    @Input() feeInfo: FeeInfo;
  }

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [BenefitsWorksheetComponent, MockBenefitsFormComponent, MockItemizedFeesComponent]
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
    expect(pageTitle.textContent).toEqual('Benefits Worksheet');
  });

  it('initially displays the benefits form', () => {
    const element = fixture.debugElement.query(By.css('benefits-form'));
    expect(element).toBeTruthy();
  });

  describe('When benefits form is submitted', () => {

    beforeEach(() => {
      const eventValue = {
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
    });

    it('calls formSubmittedHandler', () => {
      spyOn(component, 'formSubmittedHandler');
      const element = fixture.debugElement.query(By.css('benefits-form'));
      element.triggerEventHandler('formSubmitted', eventValue);
      expect(component.formSubmittedHandler).toHaveBeenCalled();
    });

    it('shows the itemized fees', () => {
      component.formSubmittedHandler(eventValue);
      fixture.detectChanges();
      expect(component.showItemizedFees).toBeTrue();
      const element = fixture.nativeElement.querySelector('#itemizedFees');
      expect(element).not.toBeNull();
    });

    it('hides the benefits form', () => {
      component.formSubmittedHandler(eventValue);
      fixture.detectChanges();
      const element = fixture.nativeElement.querySelector('#benefitsForm');
      expect(element).toBeNull();
    });

    describe('Clicking the reset button', () => {
      beforeEach(() => {
        component.formSubmittedHandler(eventValue);
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
        expect(component.showItemizedFees).toBeTrue();

        let button = fixture.debugElement.nativeElement.querySelector('#resetWorksheetButton');
        button.click();
        tick();

        expect(component.showItemizedFees).toBeFalse();
      }));

      it('displays the benefits form again', fakeAsync(() => {
        expect(component.showItemizedFees).toBeTrue();

        let button = fixture.debugElement.nativeElement.querySelector('#resetWorksheetButton');
        button.click();
        tick();

        fixture.detectChanges();

        const element = fixture.nativeElement.querySelector('#benefitsForm');
        expect(element).not.toBeNull();
      }));

      it('hides the itemized fees again', fakeAsync(() => {
        expect(component.showItemizedFees).toBeTrue();

        let button = fixture.debugElement.nativeElement.querySelector('#resetWorksheetButton');
        button.click();
        tick();

        fixture.detectChanges();

        const element = fixture.nativeElement.querySelector('#itemizedFees');
        expect(element).toBeNull();
      }));

    });

  });

});
