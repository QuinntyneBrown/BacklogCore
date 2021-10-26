import { Component, ElementRef, forwardRef, ViewChild } from '@angular/core';
import { NG_VALUE_ACCESSOR } from '@angular/forms';
import { takeUntil } from 'rxjs/operators';
import { Subject } from 'rxjs';
import { BaseControlValueAccessor } from '@core';

@Component({
  selector: 'bl-choose-a-file-or-drag-it-here',
  templateUrl: './choose-a-file-or-drag-it-here.component.html',
  styleUrls: ['./choose-a-file-or-drag-it-here.component.scss'],
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => ChooseAFileOrDragItHereComponent),
      multi: true
    }
  ]
})
export class ChooseAFileOrDragItHereComponent extends BaseControlValueAccessor  {

  private readonly _digitalAssetIds$: Subject<string[]> = new Subject();

  private readonly _fileToUpload$: Subject<File | null> = new Subject();

  @ViewChild("input", { static: true }) public fileInput: ElementRef<HTMLInputElement>;

  registerOnChange(fn: any): void {
    this._digitalAssetIds$
    .pipe(takeUntil(this._destroyed$))
    .subscribe(fn);
  }

  public handleFileInput(files: FileList) {
    this._fileToUpload$.next(files[0]);
  }

  public handleChooseAFileClick() { this.fileInput.nativeElement.click(); }
}
