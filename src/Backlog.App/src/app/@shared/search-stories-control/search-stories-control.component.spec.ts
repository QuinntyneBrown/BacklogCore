import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchStoriesControlComponent } from './search-stories-control.component';

describe('SearchStoriesControlComponent', () => {
  let component: SearchStoriesControlComponent;
  let fixture: ComponentFixture<SearchStoriesControlComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SearchStoriesControlComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SearchStoriesControlComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
