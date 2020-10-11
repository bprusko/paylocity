import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { TestBed } from '@angular/core/testing';

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

      service.getPaycheck({}).subscribe(result => {
        expect(result).toEqual(feeInfo);
      });

      const req = httpMock.expectOne('http://localhost:5000/api/v1/benefits/fees');
      expect(req.request.method).toBe("POST");
      req.flush(feeInfo);
    });

    it('returns null when HTTP request fails', () => {
      service.getPaycheck({}).subscribe(result => {
        expect(result).toBeNull();
      });

      const req = httpMock.expectOne('http://localhost:5000/api/v1/benefits/fees');
      expect(req.request.method).toBe("POST");
      req.flush('404 error', { status: 404, statusText: 'Not Found'});
    });
  });

});
