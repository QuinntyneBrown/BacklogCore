import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'bl-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.scss']
})
export class SidenavComponent {
  @Output() menuClick: EventEmitter<void> = new EventEmitter();
}
