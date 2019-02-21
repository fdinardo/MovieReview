import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from '../../environments/environment';

@Component({
  selector: 'app-movies',
  templateUrl: './movies.component.html',
  styleUrls: ['./movies.component.scss']
})
export class MoviesComponent implements OnInit {
  private getMoviesUrl = environment.apiUrl + 'api/movies';

  movies: object;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.http.get(this.getMoviesUrl)
      .subscribe(data => {
        this.movies = data;
        console.log(data);
      });
  }

}
