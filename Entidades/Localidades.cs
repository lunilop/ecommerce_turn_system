using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Localidades
    {
        private String CodProvincias_L;
        private String CodLocalidades_L;
        private String Nombre_L;

        public Localidades() { }

        public string CodProvincias_L1 { get => CodProvincias_L; set => CodProvincias_L = value; }
        public string CodLocalidades_L1 { get => CodLocalidades_L; set => CodLocalidades_L = value; }
        public string Nombre_L1 { get => Nombre_L; set => Nombre_L = value; }
    }
}
