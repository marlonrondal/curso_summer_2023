import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {
  private baseUrl = 'https://localhost:7178/api/personas/ultimos10';
  private baseUrlpost = 'https://localhost:7178/api/personas';

  constructor(private http: HttpClient) { }

  obtenerUsuarios(): Observable<any> {
    return this.http.get<any[]>(`${this.baseUrl}`);
  }

  registrarUsuario(usuario: any): Observable<any> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    return this.http.post<any>(`${this.baseUrlpost}`, usuario, { headers });
  }
}
