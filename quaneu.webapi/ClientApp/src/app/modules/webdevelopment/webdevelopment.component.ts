import { Component, OnInit } from '@angular/core';
import { WorkService } from '../../core/http/work/work.service';
import { IWork } from '../../core/http/work/work';

@Component({
  selector: 'app-webdevelopment',
  templateUrl: './webdevelopment.component.html',
  styleUrls: ['./webdevelopment.component.css']
})
export class WebdevelopmentComponent implements OnInit {

  public works: IWork[];

  constructor(private _workService: WorkService) { }

  ngOnInit() {
    this._workService.getAll().subscribe(data => this.works = data);
  }
}
