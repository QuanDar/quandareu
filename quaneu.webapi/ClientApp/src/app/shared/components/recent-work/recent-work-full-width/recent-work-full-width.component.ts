import { Component, OnInit } from '@angular/core';
import { IWork } from '../../../../core/http/work/work';
import { WorkService } from '../../../../core/http/work/work.service';

@Component({
  selector: 'app-recent-work-full-width',
  templateUrl: './recent-work-full-width.component.html',
  styleUrls: ['./recent-work-full-width.component.css']
})
export class RecentWorkFullWidthComponent implements OnInit {

  public works: IWork[];

  constructor(private _workService: WorkService) { }

  ngOnInit() {
    this._workService.getAll().subscribe(data => this.works = data);
  }
}
