import { ElementRef } from "@angular/core";

export function classListAccessorMixin(BaseClass) {
  return class extends BaseClass {
    elementRef: ElementRef
    public get classList(): DOMTokenList {
      return (this.elementRef?.nativeElement as HTMLElement)?.classList;
    }
  }
}

export const ClassListAccessor = classListAccessorMixin(class { });

