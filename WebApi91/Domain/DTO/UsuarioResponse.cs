using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class UsuarioResponse
    {
        public string Nombre { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public int Fkrol { get; set; }
    }
}
