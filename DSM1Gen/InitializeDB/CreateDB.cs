
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DSM1GenNHibernate.EN.DSM1;
using DSM1GenNHibernate.CEN.DSM1;
using DSM1GenNHibernate.CAD.DSM1;
using DSM1GenNHibernate.CP.DSM1;
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

                //CREO UN USUARIO REGISTRADO Y SU CARRITO
                RegistradoCEN registradoCEN = new RegistradoCEN ();
                RegistradoCP registradoCP = new RegistradoCP();
                CarritoCEN carritoCEN = new CarritoCEN();
                CarritoCP carritoCP = new CarritoCP();

                Console.WriteLine("Creo tres usuarios: pablomanez, Kirito-kun, DatrixZ \n");
                int registrado0 = registradoCP.Nuevo_usuarioYcarrito("Pablo", "Manez Fernandez", 20, new DateTime(1997, 8, 6), "6984984X", "apruebame", "pablomanez", false).Id;
                int registrado1 = registradoCP.Nuevo_usuarioYcarrito("Kirito", "Kun", 21, new DateTime(1997, 5, 4), "25698568X", "asuna", "Kirito-kun", false).Id;
                int registrado2 = registradoCP.Nuevo_usuarioYcarrito("Dan", "Senpai", 20, new DateTime(1997, 8, 21), "23906238S", "easy", "DatrixZ", false).Id;
                
                //CREO TRES CATEGORIAS
                CategoriaCEN categoriaCEN = new CategoriaCEN ();

                Console.WriteLine("Creo tres categorías: espada, pistola, arma \n");
                int cat1 = categoriaCEN.New_ ("espada", 0);
                int cat2 = categoriaCEN.New_ ("pistola", 0);
                int cat3 = categoriaCEN.New_ ("arma", 0);

                Console.WriteLine("Utilizo la categoria 'arma' como supercategoria y las demas como subcategorias");
                Console.WriteLine("Uso el relationer: Anyadir_supercat(espada, arma) y Anyadir_supercat(pistola, arma) \n");
                categoriaCEN.Anyadir_supercat (cat1, cat3);
                categoriaCEN.Anyadir_supercat (cat2, cat3);

                //SE DEBE ACCEDER A LOS ID AL USAR LOS RELATIONER
                //int asd = categoriaCEN.get_ICategoriaCAD().ReadOIDDefault(cat1).Supercategoria.Id


                //CREO UN ARTICULO
                ArticuloCEN articuloCEN = new ArticuloCEN ();

                int articulo1 = articuloCEN.New_ ("FrostMourne", 10.01, cat1, "Un arma muy especial", 5);
                int articulo2 = articuloCEN.New_ ("Escopeta Frost L4D", 1, cat2, "Piun, piun", 5);

                Console.WriteLine("Creo dos articulos:");
                Console.WriteLine("Nombre: " + articuloCEN.get_IArticuloCAD().ReadOIDDefault(articulo1).Nombre);
                Console.WriteLine("Precio: " + articuloCEN.get_IArticuloCAD().ReadOIDDefault(articulo1).Precio);
                int art1CatId = articuloCEN.get_IArticuloCAD().ReadOIDDefault(articulo1).Categoria.Id;
                Console.WriteLine("Nombre de categoria: " + categoriaCEN.get_ICategoriaCAD().ReadOIDDefault(art1CatId).Nombre);
                Console.WriteLine("Descripcion: " + articuloCEN.get_IArticuloCAD().ReadOIDDefault(articulo1).Descripcion);
                Console.WriteLine("Stock anyadido: " + articuloCEN.get_IArticuloCAD().ReadOIDDefault(articulo1).Stock + " \n");

                Console.WriteLine("Nombre: " + articuloCEN.get_IArticuloCAD().ReadOIDDefault(articulo2).Nombre);
                Console.WriteLine("Precio: " + articuloCEN.get_IArticuloCAD().ReadOIDDefault(articulo2).Precio);
                int art2CatId = articuloCEN.get_IArticuloCAD().ReadOIDDefault(articulo2).Categoria.Id;
                Console.WriteLine("Nombre de categoria: " + categoriaCEN.get_ICategoriaCAD().ReadOIDDefault(art2CatId).Nombre);
                Console.WriteLine("Descripcion: " + articuloCEN.get_IArticuloCAD().ReadOIDDefault(articulo2).Descripcion);
                Console.WriteLine("Stock anyadido: " + articuloCEN.get_IArticuloCAD().ReadOIDDefault(articulo2).Stock + "\n");



                //LLAMO AL CP NEW DE LINEA DE PEDIDO
                LineaPedidoCEN lineaPedidoCEN = new LineaPedidoCEN ();
                LineaPedidoCP lineaPedidoCP = new LineaPedidoCP();

                CarritoEN carritoEN = carritoCEN.get_ICarritoCAD().ReadOIDDefault(registrado0);

                System.Console.WriteLine("Anyado 2 "+articuloCEN.get_IArticuloCAD().ReadOIDDefault(articulo1).Nombre+" al carrito de "+registradoCEN.get_IRegistradoCAD().ReadOIDDefault(registrado0).N_usuario);
                lineaPedidoCP.Anyado_lineaYprecio(2, articulo1, registrado0);
                System.Console.WriteLine("El precio del carrito es: "+carritoCEN.get_ICarritoCAD().ReadOIDDefault(registrado0).Precio + "\n");

                System.Console.WriteLine("Anyado 2 " + articuloCEN.get_IArticuloCAD().ReadOIDDefault(articulo2).Nombre + " al carrito de " + registradoCEN.get_IRegistradoCAD().ReadOIDDefault(registrado0).N_usuario);
                lineaPedidoCP.Anyado_lineaYprecio(2, articulo2, registrado0);
                System.Console.WriteLine("El precio del carrito es: " +carritoCEN.get_ICarritoCAD().ReadOIDDefault(registrado0).Precio + "\n");

                /*
                //CALCULO EL PRECIO DE UN CARRITO
                carritoCP = new CarritoCP ();
                Console.WriteLine ("Precio del carrito: " + carritoCEN.get_ICarritoCAD ().ReadOIDDefault (registrado0).Precio);
                carritoCP.Calcular_precio (registrado0);
                Console.WriteLine ("Precio del carrito al calcularlo: " + carritoCEN.get_ICarritoCAD ().ReadOIDDefault (registrado0).Precio);
                */

                //CONSEGUIR TODAS LAS LINEAS DE UN CARRITO
                IList<LineaPedidoEN> lineas = lineaPedidoCEN.Obtener_lineas (0, 50);
                IList<int> lineasid = new List<int>();

                foreach (LineaPedidoEN linea in lineas) {
                        if (linea.Carrito.Id == registrado0) {
                                lineasid.Add (linea.Id);
                        }
                }

                //FINALIZO LA COMPRA
                carritoCP = new CarritoCP ();

                Console.WriteLine("Finalizo la compra de pablomanez:");
                carritoCP.Finalizar_compra (registrado0, carritoCEN.get_ICarritoCAD ().ReadOIDDefault (registrado0).Precio); //FUNCIONA DE PUTA MADRE
                System.Console.WriteLine("El precio del carrito es: " + carritoCEN.get_ICarritoCAD().ReadOIDDefault(registrado0).Precio + "\n");

                Console.WriteLine("Ahora " + articuloCEN.get_IArticuloCAD().ReadOIDDefault(articulo1).Nombre + " tiene " + articuloCEN.get_IArticuloCAD().ReadOIDDefault(articulo1).Stock + " unidades en stock \n");

                //CONSIGO TODOS LOS PEDIDOS DE UN USUARIO
                PedidoCEN pedidoCEN = new PedidoCEN ();
                IList<PedidoEN> pedidos = pedidoCEN.Obtener_pedidos (0, 50);
                IList<int> histPedidos = new List<int>();

                foreach (PedidoEN pedido in pedidos) {
                        if (pedido.Registrado.Id == registrado0) {
                                histPedidos.Add (pedido.Id);
                        }
                }

                //PEDIDOS DE UN USUARIO
                Console.WriteLine("Accedo al historial del usuario pablomanez:");
                foreach(int pedId in histPedidos)
                {
                    int i = 1;
                    PedidoEN ped = pedidoCEN.get_IPedidoCAD().ReadOIDDefault(pedId);

                    Console.WriteLine("///////////////////////// Pedido numero: " + i + " /////////////////////////");
                    Console.WriteLine("Fecha: " + ped.Fecha);
                    Console.WriteLine("Contenido: ");

                    IList<LineaPedidoEN> lineas2 = lineaPedidoCEN.Obtener_lineas(0, 50);
                    foreach (LineaPedidoEN linea2 in lineas2)
                    {
                        if (linea2.Pedido.Id == pedId)
                        {
                            Console.WriteLine("ID LINEA DE PEDIDO: " + linea2.Id);
                            Console.WriteLine("ARTICULO: " + articuloCEN.get_IArticuloCAD().ReadOIDDefault(linea2.Articulo.Id).Nombre);
                            Console.WriteLine("CANTIDAD: " + linea2.Cantidad + "\n");
                        }
                    }


                }



                /*
                 *  //BUSCO ARTICULOS POR NOMBRE
                 *  System.Console.WriteLine ("USO: Busqueda_por_nombre()");
                 *  String ans = Console.ReadLine ();
                 *  IList<ArticuloEN> busq_nombre = articuloCEN.Busqueda_por_nombre (ans);
                 *  foreach (ArticuloEN art in busq_nombre) {
                 *          System.Console.WriteLine ("NOMBRE: " + art.Nombre);
                 *          System.Console.WriteLine ("PRECIO: " + art.Precio);
                 *  }
                 */

                //CREO DOS PUJAS
                PujaCEN pujaCEN = new PujaCEN ();
                int pujaid = pujaCEN.New_ (DateTime.Now, 10, articulo1, 10, -1, false);
                int pujaid2 = pujaCEN.New_ (DateTime.Now, 10, articulo2, 20, -1, false);

                RegistradoEN max = null;
                PujaEN puja = pujaCEN.get_IPujaCAD ().ReadOIDDefault (pujaid);
                OfertaPujaCP ofertaPujaCP = null;
                //INICIAMOS LAS PUJAS
                try
                {
                        System.Console.WriteLine ("Puja#" + puja.Id + " | MAX: " + puja.Id_usuario + " " + puja.Puja_max + "$\n");
                        ofertaPujaCP = new OfertaPujaCP ();

                        System.Console.WriteLine ("Kirito-kun puja " + 15 + "$");
                        ofertaPujaCP.Nueva_oferta (DateTime.Now, DateTime.Now, registrado1, pujaid, 15); //Nueva oferta de Kirito-kun
                        puja = pujaCEN.get_IPujaCAD ().ReadOIDDefault (pujaid);                         //Actualizo puja
                        max = registradoCEN.get_IRegistradoCAD ().ReadOIDDefault (puja.Id_usuario);     //Actualizo nombre del usuario con la puja mas alta
                        System.Console.WriteLine ("Puja#" + puja.Id + " | MAX: " + max.N_usuario + " " + puja.Puja_max + "$\n");

                        System.Console.WriteLine ("DatrixZ puja " + 20 + "$");
                        ofertaPujaCP.Nueva_oferta (DateTime.Now, DateTime.Now, registrado2, pujaid, 20); //Nueva oferta de DatrixZ mayor que la anterior
                        puja = pujaCEN.get_IPujaCAD ().ReadOIDDefault (pujaid);
                        max = registradoCEN.get_IRegistradoCAD ().ReadOIDDefault (puja.Id_usuario);
                        System.Console.WriteLine ("Puja#" + puja.Id + " | MAX: " + max.N_usuario + " " + puja.Puja_max + "$\n");

                        System.Console.WriteLine ("Pablo-sensei puja " + 10 + "$");
                        ofertaPujaCP.Nueva_oferta (DateTime.Now, DateTime.Now, registrado0, pujaid, 10); //Nueva oferta de Pablo-sensei menor que la anterior
                        puja = pujaCEN.get_IPujaCAD ().ReadOIDDefault (pujaid);
                        max = registradoCEN.get_IRegistradoCAD ().ReadOIDDefault (puja.Id_usuario);
                        System.Console.WriteLine ("Puja#" + puja.Id + " | MAX: " + max.N_usuario + " " + puja.Puja_max + "$\n");
                }
                catch (Exception e) { System.Console.WriteLine (e.Message + "\n"); }

                try
                {
                        System.Console.WriteLine ("DatrixZ puja " + 50 + "$");
                        ofertaPujaCP.Nueva_oferta (DateTime.Now, DateTime.Now, registrado2, pujaid, 50); //Nueva oferta de DatrixZ contra s� mismo
                        puja = pujaCEN.get_IPujaCAD ().ReadOIDDefault (pujaid);
                        max = registradoCEN.get_IRegistradoCAD ().ReadOIDDefault (puja.Id_usuario);
                        System.Console.WriteLine ("Puja#" + puja.Id + " | MAX: " + max.N_usuario + " " + puja.Puja_max + "$\n");
                }
                catch (Exception e) { System.Console.WriteLine (e.Message + "\n"); }


                System.Console.WriteLine ("Puja#" + puja.Id + " | MAX: " + max.N_usuario + " " + puja.Puja_max + " " + puja.Cerrada + "$\n");


                //CERRAMOS LA PUJA
                PujaCP pujaCP = new PujaCP ();
                System.Console.WriteLine ("Cierro puja 1");
                pujaCP.Terminar_puja (pujaid, puja.Fecha, puja.Puja_inicial, puja.Puja_max, puja.Id_usuario, true);
                try
                {
                        System.Console.WriteLine ("Cierro puja 1 otra vez");
                        pujaCP.Terminar_puja (pujaid, puja.Fecha, puja.Puja_inicial, puja.Puja_max, puja.Id_usuario, true);
                }
                catch (Exception e) { System.Console.WriteLine (e.Message + "\n"); }
                try
                {
                        System.Console.WriteLine ("Cierro puja 2");
                        pujaCP.Terminar_puja (pujaid2, puja.Fecha, puja.Puja_inicial, puja.Puja_max, puja.Id_usuario, true);
                }
                catch (Exception e) { System.Console.WriteLine (e.Message + "\n"); }


                try
                {
                        System.Console.WriteLine ("Pablo-sensei puja " + 100 + "$");
                        ofertaPujaCP.Nueva_oferta (DateTime.Now, DateTime.Now, registrado1, pujaid, 100); //Nueva oferta de Pablo-sensei en una puja cerrada
                        puja = pujaCEN.get_IPujaCAD ().ReadOIDDefault (pujaid);
                        max = registradoCEN.get_IRegistradoCAD ().ReadOIDDefault (puja.Id_usuario);
                        System.Console.WriteLine ("Puja#" + puja.Id + " | MAX: " + max.N_usuario + " " + puja.Puja_max + "$\n");
                }
                catch (Exception e) { System.Console.WriteLine (e.Message + "\n"); }


                /*
                 * //CREO UNA VALORACION Y MODIFICO SU TEXTO
                 * ValoracionCEN valoracionCEN = new ValoracionCEN ();
                 * System.Console.WriteLine ("CREO UNA VALORACION Y LE CAMBIO EL TEXTO");
                 * int valoracionCEN_id1 = valoracionCEN.New_ (10, "La verdad es que es la hostia, pero quiero que Lujan me apruebe", registradoCEN_id, articulo1);
                 *
                 * System.Console.WriteLine (valoracionCEN.get_IValoracionCAD ().ReadOIDDefault (valoracionCEN_id1).Texto);
                 * int pMod = valoracionCEN.get_IValoracionCAD ().ReadOIDDefault (valoracionCEN_id1).Puntuacion;
                 * valoracionCEN.Modify (valoracionCEN_id1, pMod, "He cambiado el texto y si, quiero que Lujan me apruebe");
                 * System.Console.WriteLine (valoracionCEN.get_IValoracionCAD ().ReadOIDDefault (valoracionCEN_id1).Texto);
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
