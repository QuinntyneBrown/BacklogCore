import { TestBed } from '@angular/core/testing';

import { StoryActionbarService } from './story-actionbar.service';

describe('StoryActionbarService', () => {
  let service: StoryActionbarService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(StoryActionbarService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
