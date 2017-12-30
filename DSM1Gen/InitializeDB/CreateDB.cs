
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
using System.Collections;

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



                RegistradoCEN registradoCEN = new RegistradoCEN ();
                RegistradoCP registradoCP = new RegistradoCP ();
                CarritoCEN carritoCEN = new CarritoCEN ();
                CarritoCP carritoCP = new CarritoCP ();
                PedidoCEN pedidoCEN = new PedidoCEN ();
                
                int tester = registradoCP.Nuevo_usuarioYcarrito ("Beta", "Tester", 20, new DateTime (1997, 8, 6), "28595475X", "Test", "Beater", false).Id;

                //Variables para el testeo
                String reader = null;
                String reader_aux = null;
                Boolean booleano_molon = false;

                Console.WriteLine (" ===============================================");
                Console.WriteLine (" =                                             =");
                Console.WriteLine (" =      ########    ########     ########      =");
                Console.WriteLine (" =         ##            ##         ##         =");
                Console.WriteLine (" =         ##          ##           ##         =");
                Console.WriteLine (" =         ##        ##             ##         =");
                Console.WriteLine (" =      ########    ########     ########      =");
                Console.WriteLine (" =                                             =");
                Console.WriteLine (" =             ONLINE SHOP - BETA              =");
                Console.WriteLine (" ===============================================");

                Console.WriteLine ("\n Para este testeo te hemos preparado el usuario:");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write ("    Beater    "); Console.ForegroundColor = ConsoleColor.DarkGray; Console.WriteLine ("// Nombre de usuario");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write ("      Test    "); Console.ForegroundColor = ConsoleColor.DarkGray; Console.WriteLine ("// Contraseña \n");

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine (" ===============================================");
                Console.Write ("  LOGIN      "); Console.ForegroundColor = ConsoleColor.DarkGray; Console.WriteLine ("// Testeo de la funcion CEN Login()");
                Console.ForegroundColor = ConsoleColor.Gray;

                do {
                        Console.Write ("     Nombre de usuario: ");                                                                              Console.ForegroundColor = ConsoleColor.White;
                        reader = Console.ReadLine ();                                                                                            Console.ForegroundColor = ConsoleColor.Gray;

                        Console.Write ("            Contraseña: ");                                                                              Console.ForegroundColor = ConsoleColor.White;
                        reader_aux = Console.ReadLine ();                                                                                        Console.ForegroundColor = ConsoleColor.Gray;

                        booleano_molon = registradoCEN.Login (tester, reader_aux, reader);

                        if (!booleano_molon) {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine (" ---------------DATOS INCORRECTOS!--------------");                                              Console.ForegroundColor = ConsoleColor.Gray;

                                Console.WriteLine (" ===============================================");
                                Console.WriteLine (" Prueba otra vez:");
                        }
                } while (!booleano_molon);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine (" =================LOGIN CORRECTO===============\n");                                                     Console.ForegroundColor = ConsoleColor.Gray;

                //CREAMOS TRES USUARIOS REGISTRADOS Y SU CARRITOS
                Console.WriteLine ("Creamos otros tres usuarios que intervendrán cuando llegue el momento:");                                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine ("//Testeo del CP Nuevo_usuarioYcarrito, que se encarga de crear un usuario y su carrito");
                int registrado0 = registradoCP.Nuevo_usuarioYcarrito ("Pablo", "Manez", 20, new DateTime (1997, 8, 6), "6984984X", "Test", "Pablomanez", true).Id;
                int registrado1 = registradoCP.Nuevo_usuarioYcarrito ("Kirito", "Kun", 21, new DateTime (1997, 5, 4), "25698568X", "asuna", "Kirito", false).Id;
                int registrado2 = registradoCP.Nuevo_usuarioYcarrito ("Dan", "Senpai", 20, new DateTime (1997, 8, 21), "23906238S", "easy", "Dan", false).Id;

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write ("   " + registradoCEN.get_IRegistradoCAD ().ReadOIDDefault (registrado0).N_usuario);                            Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine ("(Admin)");                                                                                               Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine ("   " + registradoCEN.get_IRegistradoCAD ().ReadOIDDefault (registrado1).N_usuario);
                Console.WriteLine ("   " + registradoCEN.get_IRegistradoCAD ().ReadOIDDefault (registrado2).N_usuario + "\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine ("Inicializando datos...\n\n");

                //CREO TRES CATEGORIAS
                CategoriaCEN categoriaCEN = new CategoriaCEN ();

                Console.Write ("Creo tres categorías:");
                Console.WriteLine ("  -espada");
                Console.WriteLine ("  -pistola");
                Console.WriteLine ("  -arma");
                List<int> categorias = new List<int>();         //Utilizamos la List solo para esta demostracion, mas adelante usaremos un ReadAll
                int cat1 = categoriaCEN.New_ ("espada", 0);
                int cat2 = categoriaCEN.New_ ("pistola", 0);
                int cat3 = categoriaCEN.New_ ("arma", 0);
                categorias.Add (cat1);
                categorias.Add (cat2);
                categorias.Add (cat3);

                Console.WriteLine ("Utilizo la categoria 'arma' como supercategoria y las demas como subcategorias");
                Console.WriteLine ("Uso el relationer: Anyadir_supercat(espada, arma) y Anyadir_supercat(pistola, arma) \n");
                categoriaCEN.Anyadir_supercat (cat1, cat3);
                categoriaCEN.Anyadir_supercat (cat2, cat3);

                //SE DEBE ACCEDER A LOS ID AL USAR LOS RELATIONER
                //int asd = categoriaCEN.get_ICategoriaCAD().ReadOIDDefault(cat1).Supercategoria.Id


                //CREO UN ARTICULO
                ArticuloCEN articuloCEN = new ArticuloCEN ();
                List<int> articulos = new List<int>();
                int articulo1 = articuloCEN.New_ ("FrostMourne", 10.01, cat1, "Un arma muy especial", 5);
                int articulo2 = articuloCEN.New_ ("Escopeta Frost L4D", 1, cat2, "Piun, piun", 5);
                int articulo3 = articuloCEN.New_ ("Contrato Virtuoso", 800, cat2, "Espada YohRa", 5);
                int articulo4 = articuloCEN.New_ ("Raygun", 50, cat2, "Arma de rayos molona", 5);
                articulos.Add (articulo1);
                articulos.Add (articulo2);
                articulos.Add (articulo3);
                articulos.Add (articulo4);

                Console.WriteLine ("Creo dos articulos:");
                Console.WriteLine ("  Nombre: " + articuloCEN.get_IArticuloCAD ().ReadOIDDefault (articulo1).Nombre);
                int art1CatId = articuloCEN.get_IArticuloCAD ().ReadOIDDefault (articulo1).Categoria.Id;
                Console.WriteLine ("  Nombre de categoria: " + categoriaCEN.get_ICategoriaCAD ().ReadOIDDefault (art1CatId).Nombre + "\n");

                Console.WriteLine ("  Nombre: " + articuloCEN.get_IArticuloCAD ().ReadOIDDefault (articulo2).Nombre);
                int art2CatId = articuloCEN.get_IArticuloCAD ().ReadOIDDefault (articulo2).Categoria.Id;
                Console.WriteLine ("  Nombre de categoria: " + categoriaCEN.get_ICategoriaCAD ().ReadOIDDefault (art2CatId).Nombre + "\n");

                Console.WriteLine ("  Nombre: " + articuloCEN.get_IArticuloCAD ().ReadOIDDefault (articulo2).Nombre);
                int art3CatId = articuloCEN.get_IArticuloCAD ().ReadOIDDefault (articulo2).Categoria.Id;
                Console.WriteLine ("  Nombre de categoria: " + categoriaCEN.get_ICategoriaCAD ().ReadOIDDefault (art2CatId).Nombre + "\n");

                Console.WriteLine ("  Nombre: " + articuloCEN.get_IArticuloCAD ().ReadOIDDefault (articulo2).Nombre);
                int art4CatId = articuloCEN.get_IArticuloCAD ().ReadOIDDefault (articulo2).Categoria.Id;
                Console.WriteLine ("  Nombre de categoria: " + categoriaCEN.get_ICategoriaCAD ().ReadOIDDefault (art2CatId).Nombre + "\n");

                //CREO DOS PUJAS
                PujaCEN pujaCEN = new PujaCEN ();
                List<int> pujas = new List<int>();

                int pujaid = pujaCEN.New_ (DateTime.Now, 10, articulo1, 10, -1, false);
                int pujaid2 = pujaCEN.New_ (DateTime.Now, 100, articulo2, 100, -1, false);
                pujas.Add (pujaid);
                pujas.Add (pujaid2);

                RegistradoEN max = null;
                PujaEN puja = pujaCEN.get_IPujaCAD ().ReadOIDDefault (pujaid);
                OfertaPujaCP ofertaPujaCP = null;


                List<int> carrito = new List<int>();
                LineaPedidoCEN lineaPedidoCEN = new LineaPedidoCEN ();
                LineaPedidoCP lineaPedidoCP = new LineaPedidoCP ();
                do {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine ("==QUE DESEAS HACER?=========================");                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write ("-   1| "); Console.ForegroundColor = ConsoleColor.Gray; Console.WriteLine (" Ver categorias");          Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write ("-   2| "); Console.ForegroundColor = ConsoleColor.Gray; Console.WriteLine (" Ver Articulos");           Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write ("-   3| "); Console.ForegroundColor = ConsoleColor.Gray; Console.WriteLine (" Buscar articulo");         Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write ("-   4| "); Console.ForegroundColor = ConsoleColor.Gray; Console.WriteLine (" Ver pujas activas");       Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write ("-   5| "); Console.ForegroundColor = ConsoleColor.Gray; Console.WriteLine (" Ver carrito");             Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write ("-   6| "); Console.ForegroundColor = ConsoleColor.Gray; Console.WriteLine (" Ver mi lista de pedidos"); Console.ForegroundColor = ConsoleColor.Yellow;
                        if (!registradoCEN.get_IRegistradoCAD ().ReadOIDDefault (tester).Admin) {
                                Console.Write ("-   7| "); Console.ForegroundColor = ConsoleColor.Gray; Console.WriteLine (" Solicitar privilegios de administrador"); Console.ForegroundColor = ConsoleColor.Yellow;
                        }
                        else{
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write ("-   A| "); Console.ForegroundColor = ConsoleColor.White; Console.WriteLine (" Agregar categoria");  Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write ("-   B| "); Console.ForegroundColor = ConsoleColor.White; Console.WriteLine (" Agregar articulo");   Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write ("-   C| "); Console.ForegroundColor = ConsoleColor.White; Console.WriteLine (" Terminar puja");
                                Console.ForegroundColor = ConsoleColor.Yellow;
                        }

                        Console.Write ("- E| "); Console.ForegroundColor = ConsoleColor.Gray; Console.WriteLine (" Salir");          Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write (">"); reader = Console.ReadLine ();

                        switch (reader) {
                        case "1":
                        {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine ("\n---Lista de categorias-------------------------------------------"); Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.WriteLine ("//Ahora mismo solo mostramos las categorias que hemos creado anteriormente, mas adelante haremos uso del ReadAll()");
                                Console.WriteLine ("//Para crear una categoria dentro de otra hacemos uso del relationer Anyadir_supercat()"); Console.ForegroundColor = ConsoleColor.Green;
                                foreach (int i in categorias) {
                                        Console.WriteLine ("     " + categoriaCEN.get_ICategoriaCAD ().ReadOIDDefault (i).Nombre);
                                }

                                Console.WriteLine ("");
                                break;
                        }

                        case "2":
                        {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine ("\n---Lista de articulos-------------------------------------------");                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.WriteLine ("//Ahora mismo solo mostramos los articulos que hemos creado anteriormente, mas adelante haremos uso del ReadAll()"); Console.ForegroundColor = ConsoleColor.Cyan;
                                ArticuloEN art = null;
                                foreach (int i in articulos) {
                                        art = articuloCEN.get_IArticuloCAD ().ReadOIDDefault (i);
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        System.Console.Write ("    " + art.Id + "| "); Console.ForegroundColor = ConsoleColor.Gray;
                                        System.Console.WriteLine (art.Nombre + "  " + art.Precio + "$");
                                }

                                Console.WriteLine ("    Escribe el ID del articulo del que quieras ver mas detalles. Para volver al menu, escribe cualquier otra cosa. "); Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write ("    >"); reader = Console.ReadLine ();
                                int x = 0;
                                if (Int32.TryParse (reader, out x)) {
                                        art = articuloCEN.get_IArticuloCAD ().ReadOIDDefault (x);
                                        if (art != null) {
                                                Console.Write ("\n     Nombre: "); Console.ForegroundColor = ConsoleColor.Gray;
                                                Console.WriteLine (articuloCEN.get_IArticuloCAD ().ReadOIDDefault (art.Id).Nombre); Console.ForegroundColor = ConsoleColor.Cyan;

                                                Console.Write ("     Precio: "); Console.ForegroundColor = ConsoleColor.Gray;
                                                Console.WriteLine (articuloCEN.get_IArticuloCAD ().ReadOIDDefault (art.Id).Precio + "$"); Console.ForegroundColor = ConsoleColor.Cyan;

                                                int cat = articuloCEN.get_IArticuloCAD ().ReadOIDDefault (art.Id).Categoria.Id;
                                                Console.Write ("     Categoria: "); Console.ForegroundColor = ConsoleColor.Gray;
                                                Console.WriteLine (categoriaCEN.get_ICategoriaCAD ().ReadOIDDefault (cat).Nombre); Console.ForegroundColor = ConsoleColor.Cyan;

                                                Console.Write ("     Descripcion: "); Console.ForegroundColor = ConsoleColor.Gray;
                                                Console.WriteLine (articuloCEN.get_IArticuloCAD ().ReadOIDDefault (art.Id).Descripcion); Console.ForegroundColor = ConsoleColor.Cyan;

                                                Console.Write ("     Stock anyadido: "); Console.ForegroundColor = ConsoleColor.Gray;
                                                Console.WriteLine (articuloCEN.get_IArticuloCAD ().ReadOIDDefault (art.Id).Stock + " \n");

                                                Console.Write ("Anyadir al carrito? "); Console.ForegroundColor = ConsoleColor.Cyan;
                                                Console.Write ("(s/n)> ");
                                                reader = Console.ReadLine ();
                                                if (reader.Equals ("s") || reader.Equals ("S")) {
                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                        Console.Write ("Cantidad? (Actualmente en stock:" + articuloCEN.get_IArticuloCAD ().ReadOIDDefault (x).Stock + ")> ");
                                                        Console.ForegroundColor = ConsoleColor.White;
                                                        reader = Console.ReadLine ();
                                                        int cantidad = Convert.ToInt32 (reader);
                                                        if (cantidad > articuloCEN.get_IArticuloCAD ().ReadOIDDefault (x).Stock) {
                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.WriteLine ("Sobrepasas el stock");
                                                        }
                                                        else{
                                                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                                                Console.WriteLine ("//Testeo CP Anyado_lineaYprecio y CP Calcular_precio");
                                                                Console.WriteLine ("//Cada vez que se llama al CP Anyado_lineaYprecio se llama tambien al de Calcular_precio que recalcula el precio del carrito");
                                                                lineaPedidoCP.Anyado_lineaYprecio (cantidad, x, tester);
                                                                carrito.Add (x);
                                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                                Console.Write ("Articulo " + articuloCEN.get_IArticuloCAD ().ReadOIDDefault (x).Nombre + " anyadido al carrito\n");
                                                        }
                                                }
                                        }
                                }
                                Console.WriteLine ("");

                                break;
                        }

                        case "3":
                        {
                                int cont = 1;
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine ("---Buscar articulo-------------------------------------------");                 Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.WriteLine ("         //Testeo del ReadFilter - Busqueda por nombre");
                                Console.Write ("       Introduce el termino de busqueda: ");                                     Console.ForegroundColor = ConsoleColor.Cyan;
                                reader = Console.ReadLine ();
                                IList < ArticuloEN > busq_nombre = articuloCEN.Busqueda_por_nombre (reader);
                                foreach (ArticuloEN art in busq_nombre) {
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        System.Console.Write ("       " + art.Id + "| ");                                               Console.ForegroundColor = ConsoleColor.Gray;
                                        System.Console.WriteLine (art.Nombre + "  " + art.Precio + "$");
                                        cont++;
                                }
                                if (cont > 1) {
                                        Console.WriteLine ("    Escribe el ID del articulo del que quieras ver mas detalles. Para volver al menu, escribe cualquier otra cosa. "); Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.Write ("    >"); reader = Console.ReadLine ();

                                        foreach (ArticuloEN art in busq_nombre) {
                                                if (reader.Equals ((art.Id).ToString ())) {
                                                        Console.Write ("     \nNombre: ");                                                       Console.ForegroundColor = ConsoleColor.Gray;
                                                        Console.WriteLine (articuloCEN.get_IArticuloCAD ().ReadOIDDefault (art.Id).Nombre);        Console.ForegroundColor = ConsoleColor.Cyan;

                                                        Console.Write ("     Precio: ");                                                         Console.ForegroundColor = ConsoleColor.Gray;
                                                        Console.WriteLine (articuloCEN.get_IArticuloCAD ().ReadOIDDefault (art.Id).Precio + "$");    Console.ForegroundColor = ConsoleColor.Cyan;

                                                        int cat = articuloCEN.get_IArticuloCAD ().ReadOIDDefault (art.Id).Categoria.Id;
                                                        Console.Write ("     Categoria: ");                                                      Console.ForegroundColor = ConsoleColor.Gray;
                                                        Console.WriteLine (categoriaCEN.get_ICategoriaCAD ().ReadOIDDefault (cat).Nombre);   Console.ForegroundColor = ConsoleColor.Cyan;

                                                        Console.Write ("     Descripcion: ");                                                    Console.ForegroundColor = ConsoleColor.Gray;
                                                        Console.WriteLine (articuloCEN.get_IArticuloCAD ().ReadOIDDefault (art.Id).Descripcion);   Console.ForegroundColor = ConsoleColor.Cyan;

                                                        Console.Write ("     Stock anyadido: ");                                                 Console.ForegroundColor = ConsoleColor.Gray;
                                                        Console.WriteLine (articuloCEN.get_IArticuloCAD ().ReadOIDDefault (art.Id).Stock + " \n");
                                                }
                                        }
                                }
                                else{
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.Write ("       No se ha encontrado nada :( ");
                                }
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine ("-------------------------------------------------------------");
                                break;
                        }

                        case "4":
                        {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine ("---Pujas-------------------------------------------");               Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.WriteLine ("   //En este metodo testeamos el CP Nueva_oferta");                  Console.ForegroundColor = ConsoleColor.Cyan;
                                PujaEN puja_molona = null;
                                foreach (int i in pujas) {
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        puja_molona = pujaCEN.get_IPujaCAD ().ReadOIDDefault (i);
                                        if (puja_molona.Cerrada != true) {
                                                System.Console.Write ("    Puja#"); Console.ForegroundColor = ConsoleColor.Gray;
                                                System.Console.Write (puja_molona.Id); Console.ForegroundColor = ConsoleColor.Cyan;
                                                if (puja_molona.Id_usuario != -1) {
                                                        System.Console.Write (" | Maximo pujador: "); Console.ForegroundColor = ConsoleColor.Gray;
                                                        System.Console.Write (registradoCEN.get_IRegistradoCAD ().ReadOIDDefault (puja_molona.Id_usuario).N_usuario); Console.ForegroundColor = ConsoleColor.Red;
                                                }
                                                else
                                                        System.Console.Write (" | Sin pujadores  | Puja minima: "); Console.ForegroundColor = ConsoleColor.Red;

                                                System.Console.Write (" " + puja_molona.Puja_max + "$\n");

                                                Console.ForegroundColor = ConsoleColor.Gray;
                                        }
                                }
                                Console.WriteLine ("   Escribe el id de la puja en la que deseas participar. Si quieres volver atras escribe cualquier cosa: "); Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write ("   > "); reader = Console.ReadLine ();
                                Console.ForegroundColor = ConsoleColor.Gray;
                                int x = 0;
                                if (Int32.TryParse (reader, out x)) {
                                        puja_molona = pujaCEN.get_IPujaCAD ().ReadOIDDefault (x);
                                        if (puja_molona != null) {
                                                try
                                                {
                                                        ofertaPujaCP = new OfertaPujaCP ();
                                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                                        Console.Write ("   Importe> "); reader = Console.ReadLine ();

                                                        ofertaPujaCP.Nueva_oferta (DateTime.Now, DateTime.Now, tester, puja_molona.Id, Convert.ToInt32 (reader));
                                                        puja_molona = pujaCEN.get_IPujaCAD ().ReadOIDDefault (x);

                                                        System.Console.Write ("    Puja#"); Console.ForegroundColor = ConsoleColor.Gray;
                                                        System.Console.Write (puja_molona.Id); Console.ForegroundColor = ConsoleColor.Cyan;
                                                        System.Console.Write (" | Maximo pujador: "); Console.ForegroundColor = ConsoleColor.Gray;
                                                        System.Console.Write (registradoCEN.get_IRegistradoCAD ().ReadOIDDefault (puja_molona.Id_usuario).N_usuario); Console.ForegroundColor = ConsoleColor.Red;
                                                        System.Console.Write (" " + puja_molona.Puja_max + "$\n");
                                                }
                                                catch (Exception e)
                                                {
                                                        Console.ForegroundColor = ConsoleColor.Red;
                                                        Console.WriteLine ("   " + e.Message + "\n");
                                                }
                                        }
                                }
                                break;
                        }

                        case "5":
                        {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.WriteLine ("\n---Carrito-------------------------------------------"); Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.WriteLine ("    //Carrito desde el que podemos testear el CP Finaliza_compra");
                                ArticuloEN art = null;
                                foreach (int i in carrito) {
                                        art = articuloCEN.get_IArticuloCAD ().ReadOIDDefault (i);
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        System.Console.Write ("    " + art.Id + "| "); Console.ForegroundColor = ConsoleColor.Gray;
                                        System.Console.WriteLine (art.Nombre + "  " + art.Precio + "$");
                                }
                                Console.Write ("El precio total del carrito es: "); Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine (carritoCEN.get_ICarritoCAD ().ReadOIDDefault (tester).Precio + "\n");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.Write ("   Finalizar compra?"); Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write ("(s/n)> ");
                                reader = Console.ReadLine ();
                                Console.WriteLine ("");
                                if (reader.Equals ("s") || reader.Equals ("S")) {
                                        try
                                        {
                                                carritoCP.Finalizar_compra (tester, carritoCEN.get_ICarritoCAD ().ReadOIDDefault (tester).Precio); //FUNCIONA DE PUTA MADRE
                                        }
                                        catch (Exception e)
                                        {
                                                Console.WriteLine (e.Message);
                                                Console.WriteLine ("Esta excepcion salta cuando intenas comprar mas del stock disponible. Puede darse el caso de que otro usuario finalize la compra y deje un articulo sin stock antes de que tu lo compres.");
                                        }
                                }
                                break;
                        }

                        case "6":
                        {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.WriteLine ("\n---Ver pedidos realizados-------------------------------------------"); Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.WriteLine ("    //Aqui testeamos el ReadAll de pedidos"); Console.ForegroundColor = ConsoleColor.Gray;
                                pedidoCEN = new PedidoCEN ();
                                IList<PedidoEN> pedidos2 = pedidoCEN.Obtener_pedidos (0, 50);
                                IList<int> histPedidos2 = new List<int>();

                                foreach (PedidoEN pedido in pedidos2) {
                                        if (pedido.Registrado.Id == tester) {
                                                histPedidos2.Add (pedido.Id);
                                        }
                                }

                                //PEDIDOS DE UN USUARIO
                                Console.WriteLine ("Accedo al historial del usuario Beater:");
                                foreach (int pedId in histPedidos2) {
                                        int i = 1;
                                        PedidoEN ped = pedidoCEN.get_IPedidoCAD ().ReadOIDDefault (pedId);

                                        Console.WriteLine ("///////////////////////// Pedido numero: " + i + " /////////////////////////");
                                        Console.WriteLine ("Fecha: " + ped.Fecha);
                                        Console.WriteLine ("Contenido: ");

                                        IList<LineaPedidoEN> lineas2 = lineaPedidoCEN.Obtener_lineas (0, 50);
                                        foreach (LineaPedidoEN linea2 in lineas2) {
                                                if (linea2.Pedido.Id == pedId) {
                                                        Console.WriteLine ("ID LINEA DE PEDIDO: " + linea2.Id);
                                                        Console.WriteLine ("ARTICULO: " + articuloCEN.get_IArticuloCAD ().ReadOIDDefault (linea2.Articulo.Id).Nombre);
                                                        Console.WriteLine ("CANTIDAD: " + linea2.Cantidad + "\n");
                                                }
                                        }
                                }
                                break;
                        }

                        case "7":
                        {
                                if (registradoCEN.get_IRegistradoCAD ().ReadOIDDefault (tester).Admin)
                                        Console.WriteLine (" ----------------------ELIGE UNA OPCION VALIDA---------------------\n");
                                else{
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.Write ("---Solicitar permisos de administrador------------------------------------"); Console.ForegroundColor = ConsoleColor.DarkGray;
                                        Console.WriteLine ("         //Testeo del CEN Convertir_usuario()"); Console.ForegroundColor = ConsoleColor.White;
                                        registradoCEN.Convertir_usuario (tester, true);
                                        Console.WriteLine ("     HAS SIDO ASCENDIDO A ADMINISTRADOR!\n");
                                }
                                break;
                        }

                        case "a":
                        case "A":
                        {
                                if (!registradoCEN.get_IRegistradoCAD ().ReadOIDDefault (tester).Admin)
                                        Console.WriteLine (" ---------------ESE ES UN COMANDO DE ADMINISTRADOR--------------\n");
                                else{
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.WriteLine ("\n---Agregar categoria-------------------------------------------");
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.Write ("     Nombre >"); Console.ForegroundColor = ConsoleColor.White;
                                        reader = Console.ReadLine ();
                                        categorias.Add (categoriaCEN.New_ (reader, 0));
                                }
                                break;
                        }

                        case "b":
                        case "B":
                        {
                                if (!registradoCEN.get_IRegistradoCAD ().ReadOIDDefault (tester).Admin)
                                        Console.WriteLine (" ---------------ESE ES UN COMANDO DE ADMINISTRADOR--------------\n");
                                else{
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.WriteLine ("\n---Agregar articulo--------------------------------------------");             Console.ForegroundColor = ConsoleColor.DarkGray;
                                        Console.WriteLine ("//EN ESTE METODO NO SE COMPRUEBA QUE LOS DATOS ESTEN CORRECTAMENTE INTRODUCIDOS");              Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.Write ("     Nombre >");                                                                     Console.ForegroundColor = ConsoleColor.White;
                                        reader = Console.ReadLine ();
                                        String nombre = reader;
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.Write ("     Precio >");                                                                     Console.ForegroundColor = ConsoleColor.White;
                                        reader = Console.ReadLine ();
                                        Double precio = Convert.ToDouble (reader);
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.Write ("     Categoria (Por defecto existen:" + cat1 + "," + cat2 + "," + cat3 + ") >");     Console.ForegroundColor = ConsoleColor.White;
                                        reader = Console.ReadLine ();
                                        int categoria = Convert.ToInt32 (reader);
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.Write ("     Descripcion >");                                                                Console.ForegroundColor = ConsoleColor.White;
                                        reader = Console.ReadLine ();
                                        String descripcion = reader;
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.Write ("     Stock >");                                                                      Console.ForegroundColor = ConsoleColor.White;
                                        reader = Console.ReadLine ();
                                        int stock = Convert.ToInt32 (reader);

                                        articulos.Add (articuloCEN.New_ (nombre, precio, categoria, descripcion, stock));
                                }
                                break;
                        }

                        case "c":
                        case "C":
                        {
                                if (!registradoCEN.get_IRegistradoCAD ().ReadOIDDefault (tester).Admin)
                                        Console.WriteLine (" ---------------ESE ES UN COMANDO DE ADMINISTRADOR--------------\n");
                                else{
                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.WriteLine ("\n---Finalizar puja-------------------------------------------");                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                        Console.WriteLine ("//En este metodo testeamos el CP Terminar puja");                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                        //CERRAMOS LA PUJA
                                        PujaCP pujaCP2 = new PujaCP ();
                                        PujaEN puja_molona = null;
                                        foreach (int i in pujas) {
                                                Console.ForegroundColor = ConsoleColor.Cyan;
                                                puja_molona = pujaCEN.get_IPujaCAD ().ReadOIDDefault (i);
                                                if (puja_molona.Cerrada != true) {
                                                        System.Console.Write ("    Puja#"); Console.ForegroundColor = ConsoleColor.Gray;
                                                        System.Console.Write (puja_molona.Id); Console.ForegroundColor = ConsoleColor.Cyan;
                                                        if (puja_molona.Id_usuario != -1) {
                                                                System.Console.Write (" | Maximo pujador: "); Console.ForegroundColor = ConsoleColor.Gray;
                                                                System.Console.Write (registradoCEN.get_IRegistradoCAD ().ReadOIDDefault (puja_molona.Id_usuario).N_usuario); Console.ForegroundColor = ConsoleColor.Red;
                                                        }
                                                        else
                                                                System.Console.Write (" | Sin pujadores  | Puja minima: "); Console.ForegroundColor = ConsoleColor.Red;

                                                        System.Console.Write (" " + puja_molona.Puja_max + "$\n");

                                                        Console.ForegroundColor = ConsoleColor.Gray;
                                                }
                                        }
                                        Console.WriteLine ("   Escribe el id de la puja que deseas cerrar. Si quieres volver atras escribe cualquier cosa: "); Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.Write ("   > "); reader = Console.ReadLine ();
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                        int x = 0;
                                        if (Int32.TryParse (reader, out x)) {
                                                puja_molona = pujaCEN.get_IPujaCAD ().ReadOIDDefault (x);
                                                if (puja_molona != null) {
                                                        try
                                                        {
                                                                pujaCP2.Terminar_puja (puja_molona.Id, puja_molona.Fecha, puja_molona.Puja_inicial, puja_molona.Puja_max, puja_molona.Id_usuario, true);
                                                        }
                                                        catch (Exception e)
                                                        {
                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.WriteLine ("   " + e.Message + "\n");
                                                        }
                                                }
                                        }
                                }
                                break;
                        }

                        case "e":
                        case "E":
                        {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine (" ----------------------HASTA LA PROXIMA---------------------\n");
                                break;
                        }

                        default:
                        {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine (" ----------------------ELIGE UNA OPCION VALIDA---------------------\n");
                                break;
                        }
                        }
                } while (reader != "e" && reader != "E");


                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine ("LOS USUARIOS CREADOS PREVIAMENTE REALIZAN DIVERSAS ACCIONES");
                //LLAMO AL CP NEW DE LINEA DE PEDIDO

                CarritoEN carritoEN = carritoCEN.get_ICarritoCAD ().ReadOIDDefault (registrado0);
                /*
                 * System.Console.WriteLine("Anyado 2 "+articuloCEN.get_IArticuloCAD().ReadOIDDefault(articulo1).Nombre+" al carrito de "+registradoCEN.get_IRegistradoCAD().ReadOIDDefault(registrado0).N_usuario);
                 * lineaPedidoCP.Anyado_lineaYprecio(20, articulo1, registrado0);
                 * System.Console.WriteLine("El precio del carrito es: "+carritoCEN.get_ICarritoCAD().ReadOIDDefault(registrado0).Precio + "\n");
                 */
                System.Console.WriteLine ("Anyado 2 " + articuloCEN.get_IArticuloCAD ().ReadOIDDefault (articulo2).Nombre + " al carrito de " + registradoCEN.get_IRegistradoCAD ().ReadOIDDefault (registrado0).N_usuario);
                lineaPedidoCP.Anyado_lineaYprecio (2, articulo2, registrado0);
                System.Console.WriteLine ("El precio del carrito es: " + carritoCEN.get_ICarritoCAD ().ReadOIDDefault (registrado0).Precio + "\n");


                //CALCULO EL PRECIO DE UN CARRITO
                carritoCP = new CarritoCP ();
                Console.WriteLine ("Precio del carrito: " + carritoCEN.get_ICarritoCAD ().ReadOIDDefault (registrado0).Precio);
                carritoCP.Calcular_precio (registrado0);
                Console.WriteLine ("Precio del carrito al calcularlo: " + carritoCEN.get_ICarritoCAD ().ReadOIDDefault (registrado0).Precio);


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

                Console.WriteLine ("Finalizo la compra de pablomanez:");
                carritoCP.Finalizar_compra (registrado0, carritoCEN.get_ICarritoCAD ().ReadOIDDefault (registrado0).Precio);
                System.Console.WriteLine ("El precio del carrito es: " + carritoCEN.get_ICarritoCAD ().ReadOIDDefault (registrado0).Precio + "\n");

                Console.WriteLine ("Ahora " + articuloCEN.get_IArticuloCAD ().ReadOIDDefault (articulo1).Nombre + " tiene " + articuloCEN.get_IArticuloCAD ().ReadOIDDefault (articulo1).Stock + " unidades en stock \n");

                //CONSIGO TODOS LOS PEDIDOS DE UN USUARIO
                pedidoCEN = new PedidoCEN ();
                IList<PedidoEN> pedidos = pedidoCEN.Obtener_pedidos (0, 50);
                IList<int> histPedidos = new List<int>();

                foreach (PedidoEN pedido in pedidos) {
                        if (pedido.Registrado.Id == registrado0) {
                                histPedidos.Add (pedido.Id);
                        }
                }

                //PEDIDOS DE UN USUARIO
                Console.WriteLine ("Accedo al historial del usuario pablomanez:");
                foreach (int pedId in histPedidos) {
                        int i = 1;
                        PedidoEN ped = pedidoCEN.get_IPedidoCAD ().ReadOIDDefault (pedId);

                        Console.WriteLine ("///////////////////////// Pedido numero: " + i + " /////////////////////////");
                        Console.WriteLine ("Fecha: " + ped.Fecha);
                        Console.WriteLine ("Contenido: ");

                        IList<LineaPedidoEN> lineas2 = lineaPedidoCEN.Obtener_lineas (0, 50);
                        foreach (LineaPedidoEN linea2 in lineas2) {
                                if (linea2.Pedido.Id == pedId) {
                                        Console.WriteLine ("ID LINEA DE PEDIDO: " + linea2.Id);
                                        Console.WriteLine ("ARTICULO: " + articuloCEN.get_IArticuloCAD ().ReadOIDDefault (linea2.Articulo.Id).Nombre);
                                        Console.WriteLine ("CANTIDAD: " + linea2.Cantidad + "\n");
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

                PujaCP pujaCP = new PujaCP ();
                System.Console.WriteLine ("Cierro puja 1");
                /*
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
                */

                
                //CREO UNA VALORACION Y MODIFICO SU TEXTO
                ValoracionCEN valoracionCEN = new ValoracionCEN ();
                System.Console.WriteLine ("CREO UNA VALORACION Y LE CAMBIO EL TEXTO");
                int valoracionCEN_id1 = valoracionCEN.New_ (10, "La verdad es que es la hostia, pero quiero que Lujan me apruebe", registrado0, articulo1);
                 
                System.Console.WriteLine (valoracionCEN.get_IValoracionCAD ().ReadOIDDefault (valoracionCEN_id1).Texto);
                int pMod = valoracionCEN.get_IValoracionCAD ().ReadOIDDefault (valoracionCEN_id1).Puntuacion;
                valoracionCEN.Modify (valoracionCEN_id1, pMod, "He cambiado el texto y si, quiero que Lujan me apruebe");
                System.Console.WriteLine (valoracionCEN.get_IValoracionCAD ().ReadOIDDefault (valoracionCEN_id1).Texto);


                lineaPedidoCP.Anyado_lineaYprecio(2, articulo2, registrado0);
                lineaPedidoCP.Anyado_lineaYprecio(2, articulo2, registrado1);

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
