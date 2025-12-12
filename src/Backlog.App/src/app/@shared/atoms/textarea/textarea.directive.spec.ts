import { ElementRef } from '@angular/core';
import { TextareaDirective } from './textarea.directive';

describe('TextareaDirective', () => {
  it('should create an instance', () => {
    const mockElementRef = { nativeElement: document.createElement('div') } as ElementRef;
    const directive = new TextareaDirective(mockElementRef);
    expect(directive).toBeTruthy();
  });
});
