import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';
import { Paycheck } from '../ViewModels/Paycheck';

import { PaycheckService } from './paycheck.service';

describe('PaycheckService', () => {
  let service: PaycheckService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PaycheckService],
      imports: [
        HttpClientTestingModule
      ]});
    service = TestBed.inject(PaycheckService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('creates the service', () => {
    expect(service).toBeTruthy();
  });

  describe('Get Paycheck', () => {

    it('returns paycheck info when HTTP request succeeds', () => {
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
        dependents: [],
        netPay: 1961.54,
        totalDeductions: {
          discount: 0,
          gross: 38.46,
          net: 38.46
        }
      };

      service.getPaycheck({}).subscribe(result => {
        expect(result).toEqual(paycheck);
      });

      const req = httpMock.expectOne('http://localhost:5000/api/v1/paycheck/deductions');
      expect(req.request.method).toBe("POST");
      req.flush(paycheck);
    });

    it('returns null when HTTP request fails', () => {
      service.getPaycheck({}).subscribe(result => {
        expect(result).toBeNull();
      });

      const req = httpMock.expectOne('http://localhost:5000/api/v1/paycheck/deductions');
      expect(req.request.method).toBe("POST");
      req.flush('404 error', { status: 404, statusText: 'Paycheck Service Test: Not Found'});
    });
  });

});
