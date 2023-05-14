using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace twoshared.Core.ModelsView
{
    public class RolViewModel
    {
        public class Rol
        {
            [Required]
            public string Id { get; set; }

            [Required]
            [Display(Name = "Nombre Rol")]
            public string Name { get; set; }
        }

        public class Usuario
        {
            [Required]
            public string Id { get; set; }

            [Required]
            [Display(Name = "Correo Electronico")]
            public string Email { get; set; }

            [Required]
            [Display(Name = "Nombres")]
            public string Nombres { get; set; }

            [Required]
            [Display(Name = "Apellidos")]
            public string Apellidos { get; set; }

            [Required]
            [Display(Name = "Tipo de Documento")]
            public string ID_TipoDocumento { get; set; }

            [Required]
            [Display(Name = "Número de Documento")]
            public string NumDocumento { get; set; }

            [Required]
            [Display(Name = "Celular")]
            public string Celular { get; set; }

            [Required]
            [Display(Name = "Tipo de Usuario")]
            public int Id_TipoPersona { get; set; }

            [Required]
            [Display(Name = "Foto")]
            public string Foto { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Contraseña")]
            public string Password { get; set; }
        }
    }
}