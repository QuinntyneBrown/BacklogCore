import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TitleGroupComponent } from './title-group.component';

describe('TitleGroupComponent', () => {
  let component: TitleGroupComponent;
  let fixture: ComponentFixture<TitleGroupComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TitleGroupComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TitleGroupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
