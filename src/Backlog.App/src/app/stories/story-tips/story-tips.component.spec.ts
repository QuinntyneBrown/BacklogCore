import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StoryTipsComponent } from './story-tips.component';

describe('StoryTipsComponent', () => {
  let component: StoryTipsComponent;
  let fixture: ComponentFixture<StoryTipsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StoryTipsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(StoryTipsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
