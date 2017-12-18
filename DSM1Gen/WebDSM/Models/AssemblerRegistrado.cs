using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DSM1GenNHibernate.EN.DSM1;

namespace WebDSM.Models
{
    public class AssemblerRegistrado
    {
        public Registrado ConvertENToModelUI(RegistradoEN en)
        {
            Registrado reg = new Registrado();
            reg.Id = en.Id;
            reg.Admin = en.Admin;
            reg.Nombre = en.Nombre;
            reg.Apellidos = en.Apellidos;
            reg.Edad = en.Edad;
            reg.FNacimiento = en.Fecha_nac;
            reg.Contrasenya = en.Contrasenya;
            reg.NUsuario = en.N_usuario;

            return reg;
        }

        public IList<Registrado> ConvertListENToModel(IList<RegistradoEN> ens)
        {
            IList<Registrado> regs = new List<Registrado>();
            foreach (RegistradoEN en in ens)
            {
                regs.Add(ConvertENToModelUI(en));
            }
            return regs;
        }
    }
}