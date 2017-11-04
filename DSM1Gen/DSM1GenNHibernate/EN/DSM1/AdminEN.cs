
using System;
// Definición clase AdminEN
namespace DSM1GenNHibernate.EN.DSM1
{
public partial class AdminEN                                                                        : DSM1GenNHibernate.EN.DSM1.RegistradoEN


{
public AdminEN() : base ()
{
}



public AdminEN(int id,
               string nombre, string apellidos, int edad, Nullable<DateTime> fecha_nac, string dni, String contraseña, string n_usuario, System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.ValoracionEN> valoracion, System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.PedidoEN> pedido, DSM1GenNHibernate.EN.DSM1.CarritoEN carrito, System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.PujaEN> pujaGanadora, System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.ArticuloEN> a_favorito, System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.OfertaPujaEN> ofertaPuja
               )
{
        this.init (Id, nombre, apellidos, edad, fecha_nac, dni, contraseña, n_usuario, valoracion, pedido, carrito, pujaGanadora, a_favorito, ofertaPuja);
}


public AdminEN(AdminEN admin)
{
        this.init (Id, admin.Nombre, admin.Apellidos, admin.Edad, admin.Fecha_nac, admin.Dni, admin.Contraseña, admin.N_usuario, admin.Valoracion, admin.Pedido, admin.Carrito, admin.PujaGanadora, admin.A_favorito, admin.OfertaPuja);
}

private void init (int id
                   , string nombre, string apellidos, int edad, Nullable<DateTime> fecha_nac, string dni, String contraseña, string n_usuario, System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.ValoracionEN> valoracion, System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.PedidoEN> pedido, DSM1GenNHibernate.EN.DSM1.CarritoEN carrito, System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.PujaEN> pujaGanadora, System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.ArticuloEN> a_favorito, System.Collections.Generic.IList<DSM1GenNHibernate.EN.DSM1.OfertaPujaEN> ofertaPuja)
{
        this.Id = id;


        this.Nombre = nombre;

        this.Apellidos = apellidos;

        this.Edad = edad;

        this.Fecha_nac = fecha_nac;

        this.Dni = dni;

        this.Contraseña = contraseña;

        this.N_usuario = n_usuario;

        this.Valoracion = valoracion;

        this.Pedido = pedido;

        this.Carrito = carrito;

        this.PujaGanadora = pujaGanadora;

        this.A_favorito = a_favorito;

        this.OfertaPuja = ofertaPuja;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        AdminEN t = obj as AdminEN;
        if (t == null)
                return false;
        if (Id.Equals (t.Id))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id.GetHashCode ();
        return hash;
}
}
}
