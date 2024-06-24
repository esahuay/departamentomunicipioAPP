using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace departamentomunicipio.Models
{
    public partial class Tablapai
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        [DisplayName("Departamento")]
        public int IdDepartamento { get; set; }
        [DisplayName("Municipio")]
        public int IdMunicipio { get; set; }
        public virtual Departamento Departamento { get; set; } = null!;
        public virtual Municipio Municipio { get; set; } = null!;
    }
}
