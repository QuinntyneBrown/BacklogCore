import { TestBed } from '@angular/core/testing';

import { SkillRequirementService } from './skill-requirement.service';

describe('SkillRequirementService', () => {
  let service: SkillRequirementService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SkillRequirementService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
