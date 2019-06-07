import { Component, OnInit, Input, ViewChild, ChangeDetectorRef, ChangeDetectionStrategy } from '@angular/core';
import { BoardTask } from 'src/app/.classes/board-task';
import { EditableTextComponent } from '../../.common/editable-text/editable-text.component';

@Component({
  selector: 'app-backlog-task',
  templateUrl: './backlog-task.component.html',
  styleUrls: ['./backlog-task.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class BacklogTaskComponent implements OnInit {

  constructor(private cd: ChangeDetectorRef) { }

  ngOnInit() {
  }

  @Input()
  task: BoardTask;

  @ViewChild("editableText", { static: true })
  taskDescriptionComponent: EditableTextComponent;
}

