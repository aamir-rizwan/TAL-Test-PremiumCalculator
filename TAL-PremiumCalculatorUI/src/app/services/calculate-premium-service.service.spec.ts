import { TestBed } from '@angular/core/testing';

import { CalculatePremiumServiceService } from './calculate-premium-service.service';

describe('CalculatePremiumServiceService', () => {
  let service: CalculatePremiumServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CalculatePremiumServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
