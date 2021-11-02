import { TestBed } from '@angular/core/testing';

import { CachedQueryService } from './cached-query.service';

describe('CachedQueryService', () => {
  let service: CachedQueryService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CachedQueryService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
