import { Observable } from 'rxjs';
import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { ProjectModel } from '../shared/project.model';
import { ProjectService } from '../shared/project.service';

@Component({
  selector: 'app-project-select',
  templateUrl: './project-select.component.html',
  styleUrls: ['./project-select.component.css']
})

export class ProjectSelectComponent implements OnInit {

  @Input() selectedProject: number;
  @Output() selectedProjectChange = new EventEmitter<number>();
  projects: Observable<ProjectModel>;

  constructor(private service: ProjectService) { }

  ngOnInit() {
    this.projects = this.service.getAll();
  }

  selectedItemChanged(change: any) {
    this.selectedProjectChange.emit(change.value);
  }
}
