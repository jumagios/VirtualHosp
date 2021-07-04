using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VirtualHosp.Models.Enums;

namespace VirtualHosp.Models
{
    public class Consulta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public Medico Medico { get; set; }
        public Estado Estado { get; set; }
        public double Coseguro { get; set; }
    }
}