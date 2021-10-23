import { TestBed } from '@angular/core/testing';

import { StoryFeatureService } from './story-feature.service';

describe('StoryFeatureService', () => {
  let service: StoryFeatureService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(StoryFeatureService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
