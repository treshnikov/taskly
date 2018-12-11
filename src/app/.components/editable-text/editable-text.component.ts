import { Component, OnInit, ViewChild, ElementRef, Input, ChangeDetectionStrategy } from '@angular/core';

@Component({
  changeDetection: ChangeDetectionStrategy.OnPush,
  selector: 'app-editable-text',
  templateUrl: './editable-text.component.html',
  styleUrls: ['./editable-text.component.scss']
})
export class EditableTextComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  @Input()
  text: string;

  isInEditMode: Boolean = false;

  @ViewChild('label')
  taskDescriptionLabelElement: ElementRef;

  @ViewChild('input')
  taskDescriptionInputElement: ElementRef;

  taskDescriptionLabelElementWidth:number;
  taskDescriptionLabelElementHeight:number;

  oldTaskDescription: string;

  onTaskDescriptionLabelClick()
  {
    this.isInEditMode = !this.isInEditMode;
    this.oldTaskDescription = this.text;

    this.taskDescriptionLabelElementWidth = this.taskDescriptionLabelElement.nativeElement.offsetWidth;
    this.taskDescriptionLabelElementHeight = this.taskDescriptionLabelElement.nativeElement.offsetHeight;

    // todo
    setTimeout(() => {
      this.taskDescriptionInputElement.nativeElement.focus();
      this.taskDescriptionInputElement.nativeElement.select();
    
    }, 0);
  }

  onTaskDescriptionInputLostFocus(saveEdits: boolean = true)
  {
    if (!saveEdits)
    {
      this.text = this.oldTaskDescription;
    }
    this.isInEditMode = false;
  }

}
