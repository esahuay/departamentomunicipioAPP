using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace departamentomunicipio.Models
{
    public partial class Departamento
    {
        public Departamento()
        {
            Municipios = new HashSet<Municipio>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<Municipio> Municipios { get; set; }
    }
}
