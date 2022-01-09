import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DaysUntilSprintIsOverComponent } from './days-until-sprint-is-over.component';

describe('DaysUntilSprintIsOverComponent', () => {
  let component: DaysUntilSprintIsOverComponent;
  let fixture: ComponentFixture<DaysUntilSprintIsOverComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DaysUntilSprintIsOverComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DaysUntilSprintIsOverComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
