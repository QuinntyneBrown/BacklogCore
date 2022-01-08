import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TwoColumnLayoutComponent } from './two-column-layout.component';

describe('TwoColumnLayoutComponent', () => {
  let component: TwoColumnLayoutComponent;
  let fixture: ComponentFixture<TwoColumnLayoutComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TwoColumnLayoutComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TwoColumnLayoutComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
