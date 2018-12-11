import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { BoardTask } from 'src/app/.classes/board-task';
import { EditableTextComponent } from '../editable-text/editable-text.component';

@Component({
  selector: 'app-backlog-task',
  templateUrl: './backlog-task.component.html',
  styleUrls: ['./backlog-task.component.scss']
})
export class BacklogTaskComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  @Input()
  task: BoardTask;

  @ViewChild("editableText")
  taskDescriptionComponent: EditableTextComponent;
}

