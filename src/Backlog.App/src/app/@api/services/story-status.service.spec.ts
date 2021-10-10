import { TestBed } from '@angular/core/testing';

import { StoryStatusService } from './story-status.service';

describe('StoryStatusService', () => {
  let service: StoryStatusService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(StoryStatusService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
