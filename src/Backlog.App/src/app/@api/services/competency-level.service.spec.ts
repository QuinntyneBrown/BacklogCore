import { TestBed } from '@angular/core/testing';

import { CompetencyLevelService } from './competency-level.service';

describe('CompetencyLevelService', () => {
  let service: CompetencyLevelService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CompetencyLevelService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
