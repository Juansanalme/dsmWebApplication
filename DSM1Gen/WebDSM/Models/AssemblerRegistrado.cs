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
            reg.id = en.Id;
            reg.admin = en.Admin;
            reg.nombre = en.Nombre;
            reg.apellidos = en.Apellidos;
            reg.edad = en.Edad;
            reg.fNacimiento = en.Fecha_nac;
            reg.contrasenya = en.Contrasenya;
            reg.nUsuario = en.N_usuario;

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