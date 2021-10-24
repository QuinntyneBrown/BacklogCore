import { TestBed } from '@angular/core/testing';

import { StoriesFeatureService } from './stories-feature.service';

describe('StoriesFeatureService', () => {
  let service: StoriesFeatureService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(StoriesFeatureService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
