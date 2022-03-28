import { ChangeDetectionStrategy, Component, EventEmitter, Input, NgModule, Output, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { pageSizeOptions } from '@core';
import { MatButtonModule } from '@angular/material/button';
import { UserDto } from '@api';



@Component({
  selector: 'bl-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class UserListComponent {

  @Input() selected: UserDto;

  private _dataSource: MatTableDataSource<UserDto>;

  readonly pageSizeOptions: typeof pageSizeOptions = pageSizeOptions;

  readonly displayedColumns: string[] = ["username", "actions"];

  @ViewChild(MatPaginator, { static: true }) private _paginator: MatPaginator;

  @Input("users") set users(value: UserDto[]) {
    this._dataSource = new MatTableDataSource(value);
    this.dataSource.paginator = this._paginator;
  }

  get dataSource() { return this._dataSource; }

  @Output() select: EventEmitter<UserDto> = new EventEmitter();

  @Output() create: EventEmitter<void> = new EventEmitter();

  @Output() delete: EventEmitter<UserDto> = new EventEmitter();

}

@NgModule({
  declarations: [
    UserListComponent
  ],
  exports: [
    UserListComponent
  ],
  imports: [
    CommonModule,
    MatTableModule,
    MatIconModule,
    MatPaginatorModule,
    MatButtonModule
  ]
})
export class UserListModule { }
