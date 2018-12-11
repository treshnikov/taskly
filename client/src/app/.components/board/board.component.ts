import {
  Component,
  OnInit,
  ViewChildren,
  QueryList
} from '@angular/core';
import {
  DragDropModule
} from '@angular/cdk/drag-drop';
import {
  CdkDragDrop,
  moveItemInArray,
  transferArrayItem
} from '@angular/cdk/drag-drop';
import {
  Board
} from './../../.classes/board';
import { BoardColumn } from 'src/app/.classes/board-column';
import { BoardTask } from 'src/app/.classes/board-task';
import { BacklogTaskComponent } from '../backlog-task/backlog-task.component';
import { BoardTaskComponent } from '../board-task/board-task.component';

@Component({
  selector: 'app-board',
  templateUrl: './board.component.html',
  styleUrls: ['./board.component.scss']
})
export class BoardComponent implements OnInit {

  constructor() {}

  board: Board;

  @ViewChildren('taskElements') 
  taskElements: QueryList<BoardTaskComponent>;

  ngOnInit() {
    this.board = this.loadBoard();
  }

  private loadBoard(): Board {
    let board = new Board();

    board.id = 1;
    board.name = "board";
    board.columns = [{
        name: 'todo',
        connectedTo: ['done'],
        tasksStates: ['todo'],
        tasks: [{
            id: 1,
            description: 'Task #1',
            author: 'Author 1',
            estimate: 5,
            assigne: 'User 1'
          },
          {
            id: 2,
            description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur gravida, risus pulvinar sagittis tristique, libero ex varius lectus, nec dignissim neque quam et augue.',
            author: 'Author 1',
            estimate: 2,
            assigne: 'User 1'
          },
          {
            id: 3,
            description: 'Task #3',
            author: 'Author 1',
            estimate: 3,
            assigne: 'User 2'
          },
        ]
      },
      {
        name: 'done',
        connectedTo: ['completed'],
        tasksStates: ['done'],
        tasks: [{
            id: 4,
            description: 'Task #4',
            author: 'Author 1',
            estimate: 5,
            assigne: 'User 1'
          },
          {
            id: 5,
            description: 'Task #5',
            author: 'Author 1',
            estimate: 2,
            assigne: 'User 1'
          },
          {
            id: 6,
            description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur gravida, risus pulvinar sagittis tristique, libero ex varius lectus, nec dignissim neque quam et augue. Donec nec velit efficitur, pellentesque nunc ut, efficitur lectus. In vehicula euismod diam et aliquet. In quis ultrices dui, nec blandit eros. Integer dolor lectus, aliquet eget varius in, accumsan ac dolor.',
            author: 'Author 1',
            estimate: 3,
            assigne: 'User 2'
          },
        ]
      },
      {
        name: 'completed',
        connectedTo: ['todo', 'done'],
        tasksStates: ['completed'],
        tasks: [{
            id: 7,
            description: 'Task #7',
            author: 'Author 1',
            estimate: 5,
            assigne: 'User 1'
          },
          {
            id: 8,
            description: 'Task #8',
            author: 'Author 1',
            estimate: 2,
            assigne: 'User 1'
          },
          {
            id: 9,
            description: 'Task #9',
            author: 'Author 1',
            estimate: 3,
            assigne: 'User 2'
          },
        ]
      },

      {
        name: 'todo2',
        connectedTo: ['done'],
        tasksStates: ['todo'],
        tasks: [{
            id: 10,
            description: 'Task #1',
            author: 'Author 1',
            estimate: 5,
            assigne: 'User 1'
          },
          {
            id: 11,
            description: 'Task #2',
            author: 'Author 1',
            estimate: 2,
            assigne: 'User 1'
          },
          {
            id: 12,
            description: 'Task #3',
            author: 'Author 1',
            estimate: 3,
            assigne: 'User 2'
          },
        ]
      },
      {
        name: 'done2',
        connectedTo: ['completed'],
        tasksStates: ['done'],
        tasks: [{
            id: 13,
            description: 'Task #4',
            author: 'Author 1',
            estimate: 5,
            assigne: 'User 1'
          },
          {
            id: 14,
            description: 'Task #5',
            author: 'Author 1',
            estimate: 2,
            assigne: 'User 1'
          },
          {
            id: 15,
            description: 'Task #6',
            author: 'Author 1',
            estimate: 3,
            assigne: 'User 2'
          },
        ]
      },
      {
        name: 'completed2',
        connectedTo: ['todo', 'done'],
        tasksStates: ['completed'],
        tasks: [{
            id: 16,
            description: 'Task #7',
            author: 'Author 1',
            estimate: 5,
            assigne: 'User 1'
          },
          {
            id: 17,
            description: 'Task #8',
            author: 'Author 1',
            estimate: 2,
            assigne: 'User 1'
          },
          {
            id: 18,
            description: 'Task #9',
            author: 'Author 1',
            estimate: 3,
            assigne: 'User 2'
          },
        ]
      },
    ];
    return board;
  }

  dropTask(event: CdkDragDrop < string[] > ) {
    if (event.previousContainer.data === event.container.data) {
      let column = this.board.columns.find(i => i.name == event.container.data.toString());
      moveItemInArray(column.tasks, event.previousIndex, event.currentIndex);
    } else {
      let column = this.board.columns.find(i => i.name == event.container.data.toString());
      let previousColumn = this.board.columns.find(i => i.name == event.previousContainer.data.toString());

      transferArrayItem(previousColumn.tasks,
        column.tasks,
        event.previousIndex,
        event.currentIndex);
    }
  }

  getColumnId(columnName: string): string {
    return "id_" + columnName + "_";
  }

  onAddNewTask(column: BoardColumn)
  {
    let newTask = new BoardTask();
    newTask.description = 'New Task';

    //todo generate an unique id on the server side
    newTask.id = this.taskElements.length + 1;
    column.tasks.unshift(newTask);

    // todo
    setTimeout(
      () => {
        const taskElement = this.taskElements.find(i => i.task.id === newTask.id);
        taskElement.taskDescriptionComponent.taskDescriptionLabelElement.nativeElement.click();
      }, 
      1);
    
  }

}
