import { Injectable } from "@angular/core";
import { ControlValueAccessor } from "@angular/forms";
import { Destroyable } from "./destroyable";

@Injectable()
export abstract class BaseControlValueAccessor extends Destroyable implements ControlValueAccessor {

  writeValue(obj: any): void {

  }

  registerOnChange(fn: any): void {

  }

  registerOnTouched(fn: any): void {

  }

  setDisabledState?(isDisabled: boolean): void {

  }

}
