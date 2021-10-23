import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StoryActionbarComponent } from './story-actionbar.component';

describe('StoryActionbarComponent', () => {
  let component: StoryActionbarComponent;
  let fixture: ComponentFixture<StoryActionbarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StoryActionbarComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(StoryActionbarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
