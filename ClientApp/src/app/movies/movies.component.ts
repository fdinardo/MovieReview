import { MovieService } from './../_services/movie.service';
import { Movie } from './../models/movie';
import { Component, OnInit } from '@angular/core';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs/internal/Observable';


@Component({
  selector: 'app-movies',
  templateUrl: './movies.component.html',
  styleUrls: ['./movies.component.scss']
})
export class MoviesComponent implements OnInit {

  private getMoviesUrl = environment.apiUrl + 'api/movies';

  movies: Movie[] = [];

  constructor(private _service: MovieService,) { }

  ngOnInit() {
    this.getMovies()
      .subscribe(data => this.movies = data);
  }

  getMovies(): Observable<Movie[]> {
    return this._service.getAll();
  }

}
