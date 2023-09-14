import { Component, OnInit } from '@angular/core';
import { UsuarioService } from './usuario.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  usuarios: any[] = [];
  nombre: string = '';
  fechaNacimiento: string = '';
  telefono: string = '';

  constructor(private usuarioService: UsuarioService) {}

  ngOnInit() {
    this.obtenerUsuarios(); // Llama a obtenerUsuarios al inicializar el componente
  }
  
  obtenerUsuarios() {
    this.usuarioService.obtenerUsuarios().subscribe(response => {
      this.usuarios = response;
      console.log(response);
    });
  }

  registrarUsuario() {
    // Debes declarar nuevoUsuario aquí
    const nuevoUsuario = {
      nombre: this.nombre,
      fechaNacimiento: this.fechaNacimiento,
      telefono: this.telefono
    };
    console.log(nuevoUsuario)
    // Llama al nuevo método que manejará la lógica de registro
    this.registrarUsuarioEnServicio(nuevoUsuario);
  }

  // Este es el método que maneja la lógica de registro
  registrarUsuarioEnServicio(nuevoUsuario: any):void {
    console.log("hasta qui")
    this.usuarioService.registrarUsuario(nuevoUsuario).subscribe(response => {
      console.log('Usuario registrado:', response);
      
      // Actualiza la lista de usuarios después de registrar
      this.obtenerUsuarios();
    },error => {
      console.error('Error al registrar usuario:', error);
    });
  }
  
}
