import { ElementRef } from '@angular/core';
import { TitleBarDirective } from './title-bar.directive';

describe('TitleBarDirective', () => {
  it('should create an instance', () => {
    const mockElementRef = { nativeElement: document.createElement('div') } as ElementRef;
    const directive = new TitleBarDirective(mockElementRef);
    expect(directive).toBeTruthy();
  });
});
