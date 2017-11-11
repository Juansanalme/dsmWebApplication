

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
 *      Definition of the class PedidoCEN
 *
 */
public partial class PedidoCEN
{
private IPedidoCAD _IPedidoCAD;

public PedidoCEN()
{
        this._IPedidoCAD = new PedidoCAD ();
}

public PedidoCEN(IPedidoCAD _IPedidoCAD)
{
        this._IPedidoCAD = _IPedidoCAD;
}

public IPedidoCAD get_IPedidoCAD ()
{
        return this._IPedidoCAD;
}

public int New_ (string p_descripcion, Nullable<DateTime> p_fecha, int p_registrado, int p_carrito)
{
        PedidoEN pedidoEN = null;
        int oid;

        //Initialized PedidoEN
        pedidoEN = new PedidoEN ();
        pedidoEN.Descripcion = p_descripcion;

        pedidoEN.Fecha = p_fecha;


        if (p_registrado != -1) {
                // El argumento p_registrado -> Property registrado es oid = false
                // Lista de oids id
                pedidoEN.Registrado = new DSM1GenNHibernate.EN.DSM1.RegistradoEN ();
                pedidoEN.Registrado.Id = p_registrado;
        }


        if (p_carrito != -1) {
                // El argumento p_carrito -> Property carrito es oid = false
                // Lista de oids id
                pedidoEN.Carrito = new DSM1GenNHibernate.EN.DSM1.CarritoEN ();
                pedidoEN.Carrito.Id = p_carrito;
        }

        //Call to PedidoCAD

        oid = _IPedidoCAD.New_ (pedidoEN);
        return oid;
}

public void Modify (int p_Pedido_OID, string p_descripcion, Nullable<DateTime> p_fecha)
{
        PedidoEN pedidoEN = null;

        //Initialized PedidoEN
        pedidoEN = new PedidoEN ();
        pedidoEN.Id = p_Pedido_OID;
        pedidoEN.Descripcion = p_descripcion;
        pedidoEN.Fecha = p_fecha;
        //Call to PedidoCAD

        _IPedidoCAD.Modify (pedidoEN);
}

public void Destroy (int id
                     )
{
        _IPedidoCAD.Destroy (id);
}

public void Anyadir_linea (int p_Pedido_OID, System.Collections.Generic.IList<int> p_lineaPedido_OIDs)
{
        //Call to PedidoCAD

        _IPedidoCAD.Anyadir_linea (p_Pedido_OID, p_lineaPedido_OIDs);
}
}
}
