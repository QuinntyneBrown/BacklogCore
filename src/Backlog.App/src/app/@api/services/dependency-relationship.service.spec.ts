import { TestBed } from '@angular/core/testing';

import { DependencyRelationshipService } from './dependency-relationship.service';

describe('DependencyRelationshipService', () => {
  let service: DependencyRelationshipService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DependencyRelationshipService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
