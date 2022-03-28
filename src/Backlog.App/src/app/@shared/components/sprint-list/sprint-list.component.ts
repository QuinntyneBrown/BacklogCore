import { ChangeDetectionStrategy, Component, EventEmitter, Input, NgModule, Output, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { pageSizeOptions } from '@core';
import { MatButtonModule } from '@angular/material/button';
import { SprintDto } from '@api';


@Component({
  selector: 'bl-sprint-list',
  templateUrl: './sprint-list.component.html',
  styleUrls: ['./sprint-list.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class SprintListComponent {

  @Input() selected: SprintDto;

  private _dataSource: MatTableDataSource<SprintDto>;

  readonly pageSizeOptions: typeof pageSizeOptions = pageSizeOptions;

  readonly displayedColumns: string[] = ["name", "actions"];

  @ViewChild(MatPaginator, { static: true }) private _paginator: MatPaginator;

  @Input("sprints") set sprints(value: SprintDto[]) {
    this._dataSource = new MatTableDataSource(value);
    this.dataSource.paginator = this._paginator;
  }

  get dataSource() { return this._dataSource; }

  @Output() select: EventEmitter<SprintDto> = new EventEmitter();

  @Output() create: EventEmitter<void> = new EventEmitter();

  @Output() delete: EventEmitter<SprintDto> = new EventEmitter();

}

@NgModule({
  declarations: [
    SprintListComponent
  ],
  exports: [
    SprintListComponent
  ],
  imports: [
    CommonModule,
    MatTableModule,
    MatIconModule,
    MatPaginatorModule,
    MatButtonModule
  ]
})
export class SprintListModule { }
