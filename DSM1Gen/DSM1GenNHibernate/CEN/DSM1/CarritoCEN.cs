

using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using DSM1GenNHibernate.Exceptions;

using DSM1GenNHibernate.EN.DSM1;
using DSM1GenNHibernate.CAD.DSM1;


namespace DSM1GenNHibernate.CEN.DSM1
{
/*
 *      Definition of the class CarritoCEN
 *
 */
public partial class CarritoCEN
{
private ICarritoCAD _ICarritoCAD;

public CarritoCEN()
{
        this._ICarritoCAD = new CarritoCAD ();
}

public CarritoCEN(ICarritoCAD _ICarritoCAD)
{
        this._ICarritoCAD = _ICarritoCAD;
}

public ICarritoCAD get_ICarritoCAD ()
{
        return this._ICarritoCAD;
}

public int New_ (Nullable<DateTime> p_fecha_anyadido, int p_registrado, float p_precio)
{
        CarritoEN carritoEN = null;
        int oid;

        //Initialized CarritoEN
        carritoEN = new CarritoEN ();
        carritoEN.Fecha_anyadido = p_fecha_anyadido;


        if (p_registrado != -1) {
                // El argumento p_registrado -> Property registrado es oid = false
                // Lista de oids id
                carritoEN.Registrado = new DSM1GenNHibernate.EN.DSM1.RegistradoEN ();
                carritoEN.Registrado.Id = p_registrado;
        }

        carritoEN.Precio = p_precio;

        //Call to CarritoCAD

        oid = _ICarritoCAD.New_ (carritoEN);
        return oid;
}

public void Modify (int p_Carrito_OID, Nullable<DateTime> p_fecha_anyadido, float p_precio)
{
        CarritoEN carritoEN = null;

        //Initialized CarritoEN
        carritoEN = new CarritoEN ();
        carritoEN.Id = p_Carrito_OID;
        carritoEN.Fecha_anyadido = p_fecha_anyadido;
        carritoEN.Precio = p_precio;
        //Call to CarritoCAD

        _ICarritoCAD.Modify (carritoEN);
}

public void Destroy (int id
                     )
{
        _ICarritoCAD.Destroy (id);
}

public void Vaciar_carrito (int p_Carrito_OID, System.Collections.Generic.IList<int> p_lineaPedido_OIDs)
{
        //Call to CarritoCAD

        _ICarritoCAD.Vaciar_carrito (p_Carrito_OID, p_lineaPedido_OIDs);
}
public CarritoEN Ver_detalles (int id
                               )
{
        CarritoEN carritoEN = null;

        carritoEN = _ICarritoCAD.Ver_detalles (id);
        return carritoEN;
}
}
}
