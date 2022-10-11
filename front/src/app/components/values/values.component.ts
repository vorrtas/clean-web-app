import { Component, OnInit } from '@angular/core';
import { ValuesService } from 'src/app/services/values.service';

@Component({
  selector: 'app-values',
  templateUrl: './values.component.html',
  styleUrls: ['./values.component.scss']
})
export class ValuesComponent implements OnInit {

  constructor(private vservice: ValuesService) { }

  numbers?: number[];

  ngOnInit(): void {
    this.vservice.GetNumbers().subscribe((v: any) => this.numbers = v.values);
  }

}
