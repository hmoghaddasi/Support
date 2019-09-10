import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { ConfigModel } from '../shared/config.model';
import { Observable } from 'rxjs';
import { ConfigService } from '../shared/config.service';
import { FormGroup, FormControl, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-config-select',
  templateUrl: './config-select.component.html',
  styleUrls: ['./config-select.component.css']
})

export class ConfigSelectComponent implements OnInit {
  @Input() parentId: number;
  @Input() selectedConfig: number;
  @Input() label: string;
  @Output() selectedConfigChange = new EventEmitter<number>();
  configSelectFormGroup: FormGroup;
  configs: Observable<ConfigModel>;

  constructor(private service: ConfigService
  ) { }

  ngOnInit() {
    this.configs = this.service.getConfigChild(this.parentId);
  }

  selectedItemChanged(change: any) {
    this.selectedConfigChange.emit(change.value);
  }
}

