import { AfterViewInit, Component, ElementRef, forwardRef, Input, ViewChild } from '@angular/core';
import { NG_VALUE_ACCESSOR } from '@angular/forms';
import { switchMap, takeUntil, tap } from 'rxjs/operators';
import { fromEvent, Subject } from 'rxjs';
import { BaseControl } from '@core';
import { DigitalAssetDto, DigitalAssetService, UploadDigitalAssetResponse } from '@api';

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
export class ChooseAFileOrDragItHereComponent extends BaseControl implements AfterViewInit  {

  private readonly _digitalAssetIds$: Subject<string[]> = new Subject();

  private readonly _fileToUpload$: Subject<File | null> = new Subject();

  @ViewChild("input", { static: true }) public fileInput: ElementRef<HTMLInputElement>;

  @Input() public idOnly: boolean = true;

  public digitalAssetId$: Subject<string| DigitalAssetDto> = new Subject();

  constructor(
    private readonly _digitalAssetService: DigitalAssetService,
    private readonly _elementRef: ElementRef<HTMLElement>
  ) {
    super()
  }

  public ngAfterViewInit(): void {
    fromEvent(this._elementRef.nativeElement,"dragover")
    .pipe(
      tap((x: DragEvent) => this.onDragOver(x)),
      takeUntil(this._destroyed$)
    ).subscribe();

    fromEvent(this._elementRef.nativeElement,"drop")
    .pipe(
      tap((x: DragEvent) => this.onDrop(x)),
      takeUntil(this._destroyed$)
    ).subscribe();
  }

  public async onDrop(e: DragEvent): Promise<any> {
    e.stopPropagation();
    e.preventDefault();

    if (e.dataTransfer && e.dataTransfer.files) {
      const packageFiles = function (fileList: FileList): FormData {
        const formData = new FormData();
        for (var i = 0; i < fileList.length; i++) {
          formData.append(fileList[i].name, fileList[i]);
        }
        return formData;
      }

      const data = packageFiles(e.dataTransfer.files);

      this._digitalAssetService.UploadDigitalAsset()
        .pipe(
          switchMap((x: UploadDigitalAssetResponse) => this._digitalAssetService.GetDigitalAssetsByIdsResponse(x.digitalAssetIds)),
          tap(x => {
            if(this.idOnly) {
              this.digitalAssetId$.next(x[0].digitalAssetId)
            } else {
              this.digitalAssetId$.next(x[0])
            }
          }),
          takeUntil(this._destroyed$)
        )
        .subscribe();
    }
  }

  registerOnChange(fn: any): void {
    this._digitalAssetIds$
    .pipe(takeUntil(this._destroyed$))
    .subscribe(fn);
  }

  public onDragOver(e: DragEvent): void {
    e.stopPropagation();
    e.preventDefault();
  }

  public handleFileInput(files: FileList) {
    this._fileToUpload$.next(files[0]);
  }

  public handleChooseAFileClick() { this.fileInput.nativeElement.click(); }
}
