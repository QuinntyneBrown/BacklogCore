import { TestBed } from '@angular/core/testing';

import { TaskItemService } from './task-item.service';

describe('TaskItemService', () => {
  let service: TaskItemService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TaskItemService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
