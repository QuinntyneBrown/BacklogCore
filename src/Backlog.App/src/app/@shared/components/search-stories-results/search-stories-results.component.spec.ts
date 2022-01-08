import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchStoriesResultsComponent } from './search-stories-results.component';

describe('SearchStoriesResultsComponent', () => {
  let component: SearchStoriesResultsComponent;
  let fixture: ComponentFixture<SearchStoriesResultsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SearchStoriesResultsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SearchStoriesResultsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
