import { Component, ElementRef, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { BehaviorSubject, merge } from "rxjs";
import { filter, map, switchMap, takeUntil, tap } from "rxjs/operators";
import { Destroyable } from "@core/destroyable";
import { BreakpointService } from "@core";
import { routeChanged$ } from "@core/route-changed";


@Component({
  selector: "bl-shell",
  templateUrl: "./shell.component.html",
  styleUrls: ["./shell.component.scss"]
})
export class ShellComponent extends Destroyable implements OnInit {

  private readonly _menuClickSubject: BehaviorSubject<boolean> = new BehaviorSubject(true);

  private readonly _menuClick$ = this._menuClickSubject.asObservable();

  readonly opened$ = this._menuClick$;

  private readonly _side$ = this._breakpointService.isGreaterThanMedium$.pipe(
    filter(matches => matches),
    tap(_ => this._menuClickSubject.next(true)),
    map(_ => "side")
  );

  private readonly _over$ = this._breakpointService.isLessThanMedium$.pipe(
    filter(matches => matches),
    tap(_ => this._closeNavBarAndDrawer()),
    map(_ => "over")
  );

  readonly mode$ = merge(this._side$, this._over$);

  private get _matDrawerContentElement(): HTMLElement {
    return this._elementRef.nativeElement.querySelector("mat-drawer-content");
  }

  private _closeNavBarAndDrawer() {
    this._menuClickSubject.next(false);
  }

  constructor(
    private readonly _breakpointService: BreakpointService,
    private readonly _router: Router,
    private readonly _elementRef: ElementRef<HTMLElement>
  ) {
    super();
  }

  handleMenuClick() {
    this._menuClickSubject.next(!this._menuClickSubject.value);
  }

  ngOnInit() {
    routeChanged$(this._router)
    .pipe(
      takeUntil(this._destroyed$),
      switchMap(_ => this.mode$),
      tap(mode => {
        if(mode == "over") {
          this._closeNavBarAndDrawer();
        }
        this._matDrawerContentElement.scrollTop = 0;
      })
    ).subscribe();
  }
}
