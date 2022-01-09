import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddSprintDialogComponent } from './add-sprint-dialog.component';

describe('AddSprintDialogComponent', () => {
  let component: AddSprintDialogComponent;
  let fixture: ComponentFixture<AddSprintDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddSprintDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddSprintDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
