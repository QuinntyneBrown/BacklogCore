import { Component, ElementRef, OnInit, ViewChild } from "@angular/core";
import { NavigationEnd, Router } from "@angular/router";
import { MatDrawer } from "@angular/material/sidenav";
import { merge, of } from "rxjs";
import { filter, map, takeUntil, tap } from "rxjs/operators";
import { Destroyable } from "@core/destroyable";
import { BreakpointService } from "@core";
import { HeaderDirective } from "@shared/components/header/header.directive";


@Component({
  selector: "bl-shell",
  templateUrl: "./shell.component.html",
  styleUrls: ["./shell.component.scss"]
})
export class ShellComponent extends Destroyable implements OnInit {

  public vm$ = of(true)
  .pipe(
    map(_ => {
      return {

      };
    })
  )

  private readonly _side$ = this._breakpointService.isGreaterThanMedium$.pipe(
    filter(matches => matches),
    tap(_ => this.drawer?.open()),
    map(_ => "side")
  );

  private readonly _over$ = this._breakpointService.isLessThanMedium$.pipe(
    filter(matches => matches),
    tap(_ => this._closeNavBarAndDrawer()),
    map(_ => "over")
  );

  public mode$ = merge(this._side$, this._over$);

  @ViewChild(MatDrawer, { static: true }) public drawer: MatDrawer | undefined;

  @ViewChild(HeaderDirective, { static: true }) private _header: HeaderDirective | undefined;

  private get _matDrawerContentElement(): HTMLElement {
    return this._elementRef.nativeElement.querySelector("mat-drawer-content");
  }

  private _closeNavBarAndDrawer() {
    this._header?.close();
    this.drawer?.close();
  }

  constructor(
    private readonly _breakpointService: BreakpointService,
    private readonly _router: Router,
    private readonly _elementRef: ElementRef
  ) {
    super();
  }

  public ngOnInit() {
    this._router.events
      .pipe(
        takeUntil(this._destroyed$),
        tap(x => {
          if (x instanceof NavigationEnd && this.drawer?.mode == "over") {
            this._closeNavBarAndDrawer();
          }
          this._matDrawerContentElement.scrollTop = 0;
        })
      )
      .subscribe();
  }
}
