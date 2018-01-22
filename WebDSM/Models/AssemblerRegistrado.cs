using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DSM1GenNHibernate.EN.DSM1;
using DSM1GenNHibernate.CEN.DSM1;

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
            reg.Dni = en.Dni;
            
            return reg;
        }

        public Admin Conversion(IList<RegistradoEN> ens)
        {
            Admin admin = new Admin();
            
            foreach (RegistradoEN item in ens)
            {
                Registrado reg = new Registrado();
                reg.Admin = item.Admin;
                reg.Apellidos = item.Apellidos;
                reg.Contrasenya = item.Contrasenya;
                reg.Dni = item.Dni;
                reg.Edad = item.Edad;
                reg.FNacimiento = item.Fecha_nac;
                reg.Id = item.Id;
                reg.Nombre = item.Nombre;
                reg.NUsuario = item.N_usuario;

                admin.Registrado.Add(reg);
            }

            return admin;
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