import {
  Component,
  OnInit,
  ViewChildren,
  QueryList
} from '@angular/core';
import { Sprint } from 'src/app/.classes/sprint';
import { CdkDragDrop, moveItemInArray, transferArrayItem } from '@angular/cdk/drag-drop';
import { BoardTask } from 'src/app/.classes/board-task';
import { BacklogTaskComponent } from '../backlog-task/backlog-task.component';

@Component({
  selector: 'app-backlog',
  templateUrl: './backlog.component.html',
  styleUrls: ['./backlog.component.scss']
})
export class BacklogComponent implements OnInit {

  constructor() { }

  sprints: Sprint[];

  @ViewChildren('taskElements')
  taskElements: QueryList<BacklogTaskComponent>;

  ngOnInit() {
    this.sprints = this.loadSprints();
  }

  loadSprints(): Sprint[] {
    let res = [];
    res.push({
      name: "Sprint 1",
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
        name: "Backlog",
        tasks: [{
          id: 4,
          description: 'Task #4',
          author: 'Author 1',
          estimate: 5,
          assigne: 'User 1'
        },
        {
          id: 5,
          description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Curabitur gravida, risus pulvinar sagittis tristique, libero ex varius lectus, nec dignissim neque quam et augue.',
          author: 'Author 1',
          estimate: 2,
          assigne: 'User 1'
        },
        {
          id: 6,
          description: 'Task #6',
          author: 'Author 1',
          estimate: 3,
          assigne: 'User 2'
        },
        ]
      });
    return res;
  }

  onAddNewTask(sprint: Sprint) {
    const task = new BoardTask();
    task.description = 'New task';
    task.author = 'Author 1';
    task.estimate = 2;
    task.assigne = 'User 1';

    //todo generate an unique id on the server side
    task.id = this.taskElements.length + 1;

    sprint.tasks.unshift(task);

    // todo
    setTimeout(
      () => {
        const taskElement = this.taskElements.find(i => i.task.id === task.id);
        taskElement.taskDescriptionComponent.taskDescriptionLabelElement.nativeElement.click();
      },
      1);
  }

  onTaskDropped(event: CdkDragDrop<string[]>) {
    if (event.previousContainer.data === event.container.data) {
      let sprint = this.sprints.find(i => i.name == event.container.data.toString());
      moveItemInArray(sprint.tasks, event.previousIndex, event.currentIndex);
    } else {
      let sprint = this.sprints.find(i => i.name == event.container.data.toString());
      let previousSprint = this.sprints.find(i => i.name == event.previousContainer.data.toString());

      transferArrayItem(previousSprint.tasks,
        sprint.tasks,
        event.previousIndex,
        event.currentIndex);
    }

  }

  onAddNewSprint() {
    let sprint = new Sprint();
    sprint.name = "Sprint " + (this.sprints.length);
    sprint.tasks = [];
    this.sprints.unshift(sprint);
  }
}
