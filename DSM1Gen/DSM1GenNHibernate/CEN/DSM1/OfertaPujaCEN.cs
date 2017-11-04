

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
 *      Definition of the class OfertaPujaCEN
 *
 */
public partial class OfertaPujaCEN
{
private IOfertaPujaCAD _IOfertaPujaCAD;

public OfertaPujaCEN()
{
        this._IOfertaPujaCAD = new OfertaPujaCAD ();
}

public OfertaPujaCEN(IOfertaPujaCAD _IOfertaPujaCAD)
{
        this._IOfertaPujaCAD = _IOfertaPujaCAD;
}

public IOfertaPujaCAD get_IOfertaPujaCAD ()
{
        return this._IOfertaPujaCAD;
}

public int New_ (Nullable<DateTime> p_fecha, Nullable<DateTime> p_tiempo, int p_registrado, int p_puja, float p_cantidad_puja)
{
        OfertaPujaEN ofertaPujaEN = null;
        int oid;

        //Initialized OfertaPujaEN
        ofertaPujaEN = new OfertaPujaEN ();
        ofertaPujaEN.Fecha = p_fecha;

        ofertaPujaEN.Tiempo = p_tiempo;


        if (p_registrado != -1) {
                // El argumento p_registrado -> Property registrado es oid = false
                // Lista de oids id
                ofertaPujaEN.Registrado = new DSM1GenNHibernate.EN.DSM1.RegistradoEN ();
                ofertaPujaEN.Registrado.Id = p_registrado;
        }


        if (p_puja != -1) {
                // El argumento p_puja -> Property puja es oid = false
                // Lista de oids id
                ofertaPujaEN.Puja = new DSM1GenNHibernate.EN.DSM1.PujaEN ();
                ofertaPujaEN.Puja.Id = p_puja;
        }

        ofertaPujaEN.Cantidad_puja = p_cantidad_puja;

        //Call to OfertaPujaCAD

        oid = _IOfertaPujaCAD.New_ (ofertaPujaEN);
        return oid;
}

public void Modify (int p_OfertaPuja_OID, Nullable<DateTime> p_fecha, Nullable<DateTime> p_tiempo, float p_cantidad_puja)
{
        OfertaPujaEN ofertaPujaEN = null;

        //Initialized OfertaPujaEN
        ofertaPujaEN = new OfertaPujaEN ();
        ofertaPujaEN.Id = p_OfertaPuja_OID;
        ofertaPujaEN.Fecha = p_fecha;
        ofertaPujaEN.Tiempo = p_tiempo;
        ofertaPujaEN.Cantidad_puja = p_cantidad_puja;
        //Call to OfertaPujaCAD

        _IOfertaPujaCAD.Modify (ofertaPujaEN);
}

public void Destroy (int id
                     )
{
        _IOfertaPujaCAD.Destroy (id);
}
}
}
