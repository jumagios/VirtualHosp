﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VirtualHosp.Enums;

namespace VirtualHosp.Clases
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nombre es requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Apellido es requerido")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Fecha es requerida")]
        [Display(Name = "Fecha de nacimiento")]
        public DateTime FechaNacimiento { get; set; }
        [Required(ErrorMessage = "Tipo es requerido")]
        [Display(Name = "Tipo de documento")]
        public TipoDocumento TipoDocumento { get; set; }
        [Required(ErrorMessage = "Numero es requerido")]
        [Display(Name = "Número de documento")]
        public int NumeroDocumento { get; set; }
        [Display(Name = "Estado civil")]
        public EstadoCivil EstadoCivil { get; set; }
        [Required(ErrorMessage = "Email es requerido")]
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string Nacionalidad { get; set; }
        public string Ciudad { get; set; }
        [Display(Name = "Codigo Postal")]
        public int CodigoPostal { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "Contraseña es requerida")]
        [StringLength(30, ErrorMessage = "Debe ser entre 5 y 30 caracteres", MinimumLength = 5)]
        public string Password { get; set; }

    }
}
