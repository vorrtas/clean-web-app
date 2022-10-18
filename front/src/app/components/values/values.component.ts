import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ValuesService } from 'src/app/services/values.service';

@Component({
  selector: 'app-values',
  templateUrl: './values.component.html',
  styleUrls: ['./values.component.scss']
})
export class ValuesComponent implements OnInit {

  constructor(private vservice: ValuesService) { }

  numbers!: Observable<number[]>;

  ngOnInit(): void {
    this.numbers = this.vservice.GetNumbers();
  }

}
