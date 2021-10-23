import { TestBed } from '@angular/core/testing';

import { CompentencyLevelService } from './compentency-level.service';

describe('CompentencyLevelService', () => {
  let service: CompentencyLevelService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CompentencyLevelService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
