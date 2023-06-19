import { TestBed } from '@angular/core/testing';

import { HoroscopeService } from './horoscope.service';

describe('PollService', () => {
  let service: HoroscopeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(HoroscopeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
