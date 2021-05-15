using System;
using VirtualHosp.Enums;

namespace VirtualHosp.Clases
{
    class Usuario
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
        public int NumeroDocumento { get; set; }        
        public EstadoCivil EstadoCivil { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string Nacionalidad { get; set; }
        public string Ciudad { get; set; }
        public int CodigoPostal { get; set; }
       
    }
}
