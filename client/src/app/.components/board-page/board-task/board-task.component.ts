import { Component, OnInit, Input, ElementRef, ViewChild, ChangeDetectionStrategy } from '@angular/core';
import { BoardTask } from 'src/app/.classes/board-task';
import { EditableTextComponent } from '../../.common/editable-text/editable-text.component';

@Component({
  selector: 'app-board-task',
  templateUrl: './board-task.component.html',
  styleUrls: ['./board-task.component.scss']
})
export class BoardTaskComponent implements OnInit {

  constructor(private el:ElementRef) { }

  ngOnInit() {
  }

  @Input()
  task: BoardTask;

  @ViewChild("editableText", { static: true })
  taskDescriptionComponent: EditableTextComponent;
}
