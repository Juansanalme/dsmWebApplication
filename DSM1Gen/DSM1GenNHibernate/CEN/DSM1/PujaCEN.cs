

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
 *      Definition of the class PujaCEN
 *
 */
public partial class PujaCEN
{
private IPujaCAD _IPujaCAD;

public PujaCEN()
{
        this._IPujaCAD = new PujaCAD ();
}

public PujaCEN(IPujaCAD _IPujaCAD)
{
        this._IPujaCAD = _IPujaCAD;
}

public IPujaCAD get_IPujaCAD ()
{
        return this._IPujaCAD;
}

public int New_ (Nullable<DateTime> p_fecha, float p_puja_inicial, int p_articulo, float p_puja_max, int p_id_usuario, bool p_cerrada)
{
        PujaEN pujaEN = null;
        int oid;

        //Initialized PujaEN
        pujaEN = new PujaEN ();
        pujaEN.Fecha = p_fecha;

        pujaEN.Puja_inicial = p_puja_inicial;


        if (p_articulo != -1) {
                // El argumento p_articulo -> Property articulo es oid = false
                // Lista de oids id
                pujaEN.Articulo = new DSM1GenNHibernate.EN.DSM1.ArticuloEN ();
                pujaEN.Articulo.Id = p_articulo;
        }

        pujaEN.Puja_max = p_puja_max;

        pujaEN.Id_usuario = p_id_usuario;

        pujaEN.Cerrada = p_cerrada;

        //Call to PujaCAD

        oid = _IPujaCAD.New_ (pujaEN);
        return oid;
}

public void Modify (int p_Puja_OID, Nullable<DateTime> p_fecha, float p_puja_inicial, float p_puja_max, int p_id_usuario, bool p_cerrada)
{
        PujaEN pujaEN = null;

        //Initialized PujaEN
        pujaEN = new PujaEN ();
        pujaEN.Id = p_Puja_OID;
        pujaEN.Fecha = p_fecha;
        pujaEN.Puja_inicial = p_puja_inicial;
        pujaEN.Puja_max = p_puja_max;
        pujaEN.Id_usuario = p_id_usuario;
        pujaEN.Cerrada = p_cerrada;
        //Call to PujaCAD

        _IPujaCAD.Modify (pujaEN);
}

public void Destroy (int id
                     )
{
        _IPujaCAD.Destroy (id);
}

public void Actualizar (int p_Puja_OID, Nullable<DateTime> p_fecha, float p_puja_inicial, float p_puja_max, int p_id_usuario, bool p_cerrada)
{
        PujaEN pujaEN = null;

        //Initialized PujaEN
        pujaEN = new PujaEN ();
        pujaEN.Id = p_Puja_OID;
        pujaEN.Fecha = p_fecha;
        pujaEN.Puja_inicial = p_puja_inicial;
        pujaEN.Puja_max = p_puja_max;
        pujaEN.Id_usuario = p_id_usuario;
        pujaEN.Cerrada = p_cerrada;
        //Call to PujaCAD

        _IPujaCAD.Actualizar (pujaEN);
}

public void Declarar_ganador (int p_Puja_OID, int p_usuarioGanador_OID)
{
        //Call to PujaCAD

        _IPujaCAD.Declarar_ganador (p_Puja_OID, p_usuarioGanador_OID);
}
}
}
