using Data.DTO;
using Data.DTOs;

namespace alkemyUmsaFront.ViewModel
{
    public class UsuariosViewModel
    {
        public string Nombre { get; set; }
        public int Dni { get; set; }
        public string Email { get; set; }
        public int Rol { get; set; }
        public string Contrasena { get; set; }

        public static implicit operator UsuariosViewModel(UsuarioDto usuario)
        {
            var usuariosViewModel = new UsuariosViewModel();
            usuariosViewModel.Nombre = usuario.Nombre;
            usuariosViewModel.Dni = usuario.Dni;
            usuariosViewModel.Email = usuario.Email;
            usuariosViewModel.Rol = usuario.Rol;
            usuariosViewModel.Contrasena = usuario.Contrasena;

            return usuariosViewModel;
        }
    }
}