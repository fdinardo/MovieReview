import { environment } from './../../environments/environment';
import { Movie } from './../models/movie';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})
export class MovieService {

  constructor(private http: HttpClient) { }

  getAll(): Observable<Movie[]> {
    return this.http
      .get<Movie[]>(`${environment.apiUrl}api/movies`);
  }

  create(movie: Movie): Observable<Movie> {
    return this.http
      .post<Movie>(`${environment.apiUrl}api/movies`, movie);
  }
}
