using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace departamentomunicipio.Models
{
    public partial class Municipio
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Departamento")]
        public int DepartamentoId { get; set; }
        [Display(Name = "Nombre Municipio")]
        public string Name { get; set; } = null!;
        [JsonIgnore]
        public virtual Departamento ? Departamento { get; set; } = null!;
    }
}
