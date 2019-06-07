import { Component, OnInit } from '@angular/core';
import { IssuesService } from 'src/app/.services/issueService/IssuesService';
import { BoardTask } from 'src/app/.classes/board-task';

@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html',
  styleUrls: ['./settings.component.scss']
})
export class SettingsComponent implements OnInit {

  issues: BoardTask[];

  constructor(private issueService: IssuesService) { }

  ngOnInit() {
  }

  testHttpRequest(){
    this.issueService.getAllIssues().subscribe(issues => {
      this.issues = issues;
      console.log('all the issues loaded', issues);
    });

  }

}
