import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {MatButtonModule, MatCheckboxModule, MatMenuModule} from '@angular/material';
import { MatToolbarModule } from '@angular/material/toolbar';

import {CdkDragDrop, moveItemInArray, transferArrayItem} from '@angular/cdk/drag-drop';

import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatInputModule } from '@angular/material/input';
import { MatCardModule } from '@angular/material/card';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatProgressBarModule } from '@angular/material/progress-bar';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BoardComponent } from './.components/board-page/board/board.component';
import { BoardTaskComponent } from './.components/board-page/board-task/board-task.component';
import {MatIconModule} from '@angular/material/icon';
import { RouterModule, Routes } from '@angular/router';
import { AngularFontAwesomeModule } from 'angular-font-awesome';


import {DragDropModule, CdkDropList} from '@angular/cdk/drag-drop';
import { SettingsComponent } from './.components/admin-page/settings/settings.component';
import { HeaderComponent } from './.components/home-page/header/header.component';
import { SidePanelComponent } from './.components/home-page/side-panel/side-panel.component';
import { VersionComponent } from './.components/home-page/version/version.component';
import { BacklogComponent } from './.components/backlog-page/backlog/backlog.component';
import { HomeComponent } from './.components/home-page/home/home.component';
import { BacklogTaskComponent } from './.components/backlog-page/backlog-task/backlog-task.component';
import { EditableTextComponent } from './.components/.common/editable-text/editable-text.component';

const appRoutes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'board', component: BoardComponent },
  { path: 'backlog', component: BacklogComponent },
  { path: 'settings', component: SettingsComponent },
  {path: '**', component: HomeComponent}
];


@NgModule({
  declarations: [
    AppComponent,
    BoardComponent,
    BoardTaskComponent,
    SettingsComponent,
    HeaderComponent,
    SidePanelComponent,
    VersionComponent,
    BacklogComponent,
    HomeComponent,
    BacklogTaskComponent,
    EditableTextComponent,
  ],
  imports: [
    RouterModule.forRoot(
      appRoutes,
      { useHash: true,}
    ),
    FormsModule,
    HttpClientModule,
    BrowserModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatGridListModule,
    MatInputModule,
    MatCheckboxModule,
    MatCardModule,
    MatButtonModule,
    MatMenuModule,
    MatSlideToggleModule,
    MatProgressBarModule,
    DragDropModule,
    MatButtonModule,
    MatIconModule,
    AngularFontAwesomeModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
