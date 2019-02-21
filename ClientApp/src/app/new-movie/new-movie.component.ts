import { MovieService } from './../_services/movie.service';
import { Component, OnInit } from '@angular/core';
import { Movie } from '../models/movie';

@Component({
  selector: 'app-new-movie',
  templateUrl: './new-movie.component.html',
  styleUrls: ['./new-movie.component.scss']
})
export class NewMovieComponent implements OnInit {

  movie = new Movie();
  constructor(private _service: MovieService) { }

  ngOnInit() {
  }

  onSubmit() {
    this._service.create(this.movie)
      .subscribe(data => {
        this.movie.id = data.id;
      });

    console.log(this.movie);
  }
}
