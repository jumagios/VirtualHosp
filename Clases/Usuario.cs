using System;
using System.ComponentModel.DataAnnotations;
using VirtualHosp.Enums;

namespace VirtualHosp.Clases
{
    class Usuario
    {
        [Required(ErrorMessage = "Nombre es requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Apellido es requerido")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Fecha es requerida")]
        public DateTime FechaNacimiento { get; set; }
        [Required(ErrorMessage = "Tipo es requerido")]
        public TipoDocumento TipoDocumento { get; set; }
        [Required(ErrorMessage = "Numero es requerido")]
        public int NumeroDocumento { get; set; }        
        public EstadoCivil EstadoCivil { get; set; }
        [Required(ErrorMessage = "Email es requerido")]
        public string Email { get; set; }        
        public string Direccion { get; set; }        
        public string Nacionalidad { get; set; }        
        public string Ciudad { get; set; }        
        public int CodigoPostal { get; set; } 
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Contraseña es requerida")]
        [StringLength(30, ErrorMessage = "Debe ser entre 5 y 30 caracteres", MinimumLength = 5)]        
        public string Password { get; set; }        

    }
}
