import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddSkillRequirementDialogComponent } from './add-skill-requirement-dialog.component';

describe('AddSkillRequirementDialogComponent', () => {
  let component: AddSkillRequirementDialogComponent;
  let fixture: ComponentFixture<AddSkillRequirementDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddSkillRequirementDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddSkillRequirementDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
