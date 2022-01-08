import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StoryControlComponent } from './story-control.component';

describe('StoryControlComponent', () => {
  let component: StoryControlComponent;
  let fixture: ComponentFixture<StoryControlComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StoryControlComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(StoryControlComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
