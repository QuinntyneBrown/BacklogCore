import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddDependencyRelationshipDialogComponent } from './add-dependency-relationship-dialog.component';

describe('AddDependencyRelationshipDialogComponent', () => {
  let component: AddDependencyRelationshipDialogComponent;
  let fixture: ComponentFixture<AddDependencyRelationshipDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddDependencyRelationshipDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddDependencyRelationshipDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
