import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ItemShellComponent } from './item-shell.component';

describe('ItemShellComponent', () => {
  let component: ItemShellComponent;
  let fixture: ComponentFixture<ItemShellComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ItemShellComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ItemShellComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
