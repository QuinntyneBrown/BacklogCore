import { ElementRef } from '@angular/core';
import { TitleFormFieldDirective } from './title-form-field.directive';

describe('TitleFormFieldDirective', () => {
  it('should create an instance', () => {
    const mockElementRef = { nativeElement: document.createElement('div') } as ElementRef;
    const directive = new TitleFormFieldDirective(mockElementRef);
    expect(directive).toBeTruthy();
  });
});
