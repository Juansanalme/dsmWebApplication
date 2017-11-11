
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DSM1GenNHibernate.EN.DSM1;
using DSM1GenNHibernate.CEN.DSM1;
using DSM1GenNHibernate.CAD.DSM1;
using DSM1GenNHibernate.Utils;

/*PROTECTED REGION END*/
namespace InitializeDB
{
public class CreateDB
{
public static void Create (string databaseArg, string userArg, string passArg)
{
        String database = databaseArg;
        String user = userArg;
        String pass = passArg;

        // Conex DB
        SqlConnection cnn = new SqlConnection (@"Server=(local)\sqlexpress; database=master; integrated security=yes");

        // Order T-SQL create user
        String createUser = @"IF NOT EXISTS(SELECT name FROM master.dbo.syslogins WHERE name = '" + user + @"')
            BEGIN
                CREATE LOGIN ["                                                                                                                                     + user + @"] WITH PASSWORD=N'" + pass + @"', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
            END"                                                                                                                                                                                                                                                                                    ;

        //Order delete user if exist
        String deleteDataBase = @"if exists(select * from sys.databases where name = '" + database + "') DROP DATABASE [" + database + "]";
        //Order create databas
        string createBD = "CREATE DATABASE " + database;
        //Order associate user with database
        String associatedUser = @"USE [" + database + "];CREATE USER [" + user + "] FOR LOGIN [" + user + "];USE [" + database + "];EXEC sp_addrolemember N'db_owner', N'" + user + "'";
        SqlCommand cmd = null;

        try
        {
                // Open conex
                cnn.Open ();

                //Create user in SQLSERVER
                cmd = new SqlCommand (createUser, cnn);
                cmd.ExecuteNonQuery ();

                //DELETE database if exist
                cmd = new SqlCommand (deleteDataBase, cnn);
                cmd.ExecuteNonQuery ();

                //CREATE DB
                cmd = new SqlCommand (createBD, cnn);
                cmd.ExecuteNonQuery ();

                //Associate user with db
                cmd = new SqlCommand (associatedUser, cnn);
                cmd.ExecuteNonQuery ();

                System.Console.WriteLine ("DataBase create sucessfully..");
        }
        catch (Exception ex)
        {
                throw ex;
        }
        finally
        {
                if (cnn.State == ConnectionState.Open) {
                        cnn.Close ();
                }
        }
}

public static void InitializeData ()
{
        /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/
        try
        {
                // Insert the initilizations of entities using the CEN classes

                //CREO UN USUARIO REGISTRADO
                RegistradoCEN registradoCEN = new RegistradoCEN ();
                int registradoCEN_id = registradoCEN.New_ ("Pablo", "Manez Fernandez", 20, new DateTime (1997, 8, 6), "6984984X", "apruebame", "pablomanez", false);

                //System.Console.WriteLine (registradoCEN.get_IRegistradoCAD ().ReadOIDDefault (registradoCEN_id).Nombre);
                //System.Console.WriteLine (registradoCEN.get_IRegistradoCAD ().ReadOIDDefault (registradoCEN_id).Apellidos);
                //System.Console.WriteLine (registradoCEN.get_IRegistradoCAD ().ReadOIDDefault (registradoCEN_id).Edad);
                //System.Console.WriteLine (registradoCEN.get_IRegistradoCAD ().ReadOIDDefault (registradoCEN_id).Fecha_nac);
                //System.Console.WriteLine (registradoCEN.get_IRegistradoCAD ().ReadOIDDefault (registradoCEN_id).Dni);
                //System.Console.WriteLine ("Contrasenya encriptada: " + registradoCEN.get_IRegistradoCAD ().ReadOIDDefault (registradoCEN_id).Contrasenya);
                //System.Console.WriteLine ("Encripto la contrasenya 'apruebame': " + Util.GetEncondeMD5 ("apruebame"));
                //System.Console.WriteLine (registradoCEN.get_IRegistradoCAD ().ReadOIDDefault (registradoCEN_id).N_usuario);
                //System.Console.WriteLine ("Es admin?" + registradoCEN.Es_admin (registradoCEN_id));
                //registradoCEN.Convertir_usuario (registradoCEN_id, true);
                //System.Console.WriteLine ("He convertido a Pablo en admin?" + registradoCEN.Es_admin (registradoCEN_id));

                //CREO TRES CATEGORIAS
                CategoriaCEN categoriaCEN = new CategoriaCEN ();
                int cat1 = categoriaCEN.New_ ("espada", 0);
                int cat2 = categoriaCEN.New_ ("pistola", 0);
                int cat3 = categoriaCEN.New_ ("arma", 0);

                categoriaCEN.Anyadir_supercat (cat1, cat3);
                categoriaCEN.Anyadir_supercat (cat2, cat3);
                
                //CREO UN CARRITO
                CarritoCEN carritoCEN = new CarritoCEN ();
                int carritoid = carritoCEN.New_ (registradoCEN_id, 0);
                
                //CREO UN ARTICULO
                ArticuloCEN articuloCEN = new ArticuloCEN ();
                int articulo1 = articuloCEN.New_ ("FrostMourne", 10.01, cat1, "Un arma muy especial", 5);
                int articulo2 = articuloCEN.New_ ("Escopeta Frost L4D", 1, cat2, "Piun, piun", 5);

                //ANYADIR LINEAS DE PEDIDO A UN CARRITO
                LineaPedidoCEN lineaPedidoCEN = new LineaPedidoCEN();
                int linped1 = lineaPedidoCEN.New_(2, articulo1);
                int linped2 = lineaPedidoCEN.New_(2, articulo2);

                lineaPedidoCEN.Anyadir_producto(linped1, carritoid);
                lineaPedidoCEN.Anyadir_producto(linped2, carritoid);
                
                
                IList<LineaPedidoEN> lineas2 = carritoCEN.get_ICarritoCAD().ReadOIDDefault(carritoid).LineaPedido;
                /*
                foreach (LineaPedidoEN linea in lineas2)
                {
                    System.Console.WriteLine("praise lujan");
                }
                */
                CarritoEN carritoEN = carritoCEN.get_ICarritoCAD().ReadOIDDefault(carritoid);
                //carritoCEN.get_ICarritoCAD().Finalizar_compra(carritoEN);
                
                /*
                //BUSCO ARTICULOS POR NOMBRE
                System.Console.WriteLine ("USO: Busqueda_por_nombre()");
                String ans = Console.ReadLine ();
                IList<ArticuloEN> busq_nombre = articuloCEN.Busqueda_por_nombre (ans);
                foreach (ArticuloEN art in busq_nombre) {
                        System.Console.WriteLine ("NOMBRE: " + art.Nombre);
                        System.Console.WriteLine ("PRECIO: " + art.Precio);
                }
                */

                /*
                //CREO UNA VALORACION Y MODIFICO SU TEXTO
                ValoracionCEN valoracionCEN = new ValoracionCEN ();
                System.Console.WriteLine ("CREO UNA VALORACION Y LE CAMBIO EL TEXTO");
                int valoracionCEN_id1 = valoracionCEN.New_ (10, "La verdad es que es la hostia, pero quiero que Lujan me apruebe", registradoCEN_id, articulo1);

                System.Console.WriteLine (valoracionCEN.get_IValoracionCAD ().ReadOIDDefault (valoracionCEN_id1).Texto);
                int pMod = valoracionCEN.get_IValoracionCAD ().ReadOIDDefault (valoracionCEN_id1).Puntuacion;
                valoracionCEN.Modify (valoracionCEN_id1, pMod, "He cambiado el texto y si, quiero que Lujan me apruebe");
                System.Console.WriteLine (valoracionCEN.get_IValoracionCAD ().ReadOIDDefault (valoracionCEN_id1).Texto);
                */









                // p.e. CustomerCEN customer = new CustomerCEN();
                // customer.New_ (p_user:"user", p_password:"1234");

                /*PROTECTED REGION END*/
            }
        catch (Exception ex)
        {
                System.Console.WriteLine (ex.InnerException);
                throw ex;
        }
}
}
}
