using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Clientes
    {
        private String CodEmpresas_C;
        private String NombreEmpresa_C;
        private String RazonSocial_C;
        private String Telefono_C;
        private String Email_C;
        private String Direccion_C;
        private String CodLocalidades_C;
        private String CodProvincias_C;
        private DateTime FechaCreacion_C;
        private bool Estado_C;

        public Clientes() { }

        public string CodEmpresas_C1 { get => CodEmpresas_C; set => CodEmpresas_C = value; }
        public string NombreEmpresa_C1 { get => NombreEmpresa_C; set => NombreEmpresa_C = value; }
        public string RazonSocial_C1 { get => RazonSocial_C; set => RazonSocial_C = value; }
        public string Telefono_C1 { get => Telefono_C; set => Telefono_C = value; }
        public string Email_C1 { get => Email_C; set => Email_C = value; }
        public string Direccion_C1 { get => Direccion_C; set => Direccion_C = value; }
        public string CodLocalidades_C1 { get => CodLocalidades_C; set => CodLocalidades_C = value; }
        public string CodProvincias_C1 { get => CodProvincias_C; set => CodProvincias_C = value; }
        public DateTime FechaCreacion_C1 { get => FechaCreacion_C; set => FechaCreacion_C = value; }
        public bool Estado_C1 { get => Estado_C; set => Estado_C = value; }
    }
}
