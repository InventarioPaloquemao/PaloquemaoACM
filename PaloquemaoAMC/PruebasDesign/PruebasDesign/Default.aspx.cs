using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccessData.DSInventarioTableAdapters;
using System.Data;
using AcessData;


namespace PaloquemaoACM
{
    public partial class Default : System.Web.UI.Page
    {
        string nombre;
        string categoria;
      
        /// <summary>
        /// Lista almacena una lista de tipo string
        /// </summary>
        List<string> lista = new List<string>();
        /// <summary>
        /// Instancia de un objeto de la clase LinkButton
        /// </summary>
       Button btnCategorias = new Button();
        string btn = "";
        ProcesoDatos objProcesoDatos = new ProcesoDatos();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                CargarDropDownList();
              
            }

            cargarGridView(btn);
            MenuCategoria();
           

        }

        /// <summary>
        /// Meotodo para cargar DropDownList en la creacion de producto
        /// </summary>
        protected void CargarDropDownList()
        {
            try
            {
                ddlCategoria.DataSource = objProcesoDatos.ObtenerCategoria();
                ddlCategoria.DataTextField = "Descripcion";
                ddlCategoria.DataValueField = "Id_Categoria";
                ddlCategoria.DataBind();
                ddlProveedor.DataSource = objProcesoDatos.ObtenerProveedores();
                ddlProveedor.DataTextField = "Nombre_Proveedor";
                ddlProveedor.DataValueField = "Id_Proveedor";
                ddlProveedor.DataBind();
            }catch(Exception ex)
            {
                Response.Write("<script>alert('error\n "+ex.Message+"'\n en MetodoCargarDropDownList) </script>");
            }
            
        }

        /// <summary>
        /// Metodo encargado de crear el menu de las categorias
        /// </summary>
        protected void MenuCategoria()
        {
            try
            {
                //Contar las iteraciones en un ciclo
                int iteraciones = 0;
                /// Instancia de un DataTable
                DataTable objCategoriaTablaBuscada = new DataTable();
               
                
                //Obtengo los valores almacenados en el DataSet y los asigono a un datatable
                objCategoriaTablaBuscada = objProcesoDatos.ObtenerCategoria();  
                ///Agrego valores a la lista desde un datatable recorriendo las filas y obteniendo los valores de la celda especifica 
                for (int i = 0; i < objCategoriaTablaBuscada.Rows.Count; i++)
                {

                    lista.Add(objCategoriaTablaBuscada.Rows[i].Field<string>(1));


                }

                //Instancias de un objeto fila 
                TableRow objFila = new TableRow();
                //Instancia de un objeto celda 
                TableCell objCelda = new TableCell();
                //Agrego una fila a la tabla
                tableNav.Controls.Add(objFila);
                ///Recorro la lista creando durante su recorrido objetos de la clase LinkButton 
                ///agregandoles atributos y eventos 
                foreach (string linea in lista)
                {
                    if(!linea.StartsWith("--")){    
                    btnCategorias = new Button();
                    btnCategorias.ID = linea;
                    btnCategorias.Text = linea;
                    //asigno el algoritmo que va a dar un nombre unico al control dentro del dom de HTML 
                    btnCategorias.ClientIDMode = System.Web.UI.ClientIDMode.AutoID;
                    //agrego el evento y el metodo que se desencadena al control
                    btnCategorias.Attributes.Add("onClick", "ClickInLinkButtom()");
                    //Agrego un manejador de eventos
                    btnCategorias.Click += new EventHandler(this.ClickInLinkButtom);
                    //Valido el numero de celdas creadas por fila
                    if (iteraciones <= 4)
                    {
                        objCelda.Controls.Add(btnCategorias);
                        objFila.Cells.Add(objCelda);
                        iteraciones++;
                    }
                    else
                    {
                        objCelda = new TableCell();
                        objFila = new TableRow();
                        objCelda.Controls.Add(btnCategorias);
                        objFila.Cells.Add(objCelda);
                        tableNav.Controls.Add(objFila);
                        iteraciones = 0;
                    }
                  }
                }
            }
            catch (Exception ex) 
            {
                Response.Write("<script>alert('error\n "+ex.Message+" \n en el metodo MenuCategorias')</script>");
            }
        }
        /// <summary>
        /// Metodo encargado de enlazar el origen de datos para el gridview
        /// </summary>
        /// <param name="strNombreBoton">recibe el nombre del boton que desencadena el metodo</param>
        protected void cargarGridView(string strNombreBoton)
        {
            try
            {
                //Instancia del Table Adapter  correspondiente a la vista para el administrador
                
                DataTable objTablaBuscadaProductos = new DataTable();

                objTablaBuscadaProductos = objProcesoDatos.ObtenerDatosVistaAdministrador();


                //Valido el nombre de la categoria 
                if (strNombreBoton != "")
                {
                    string consulta = "CATEGORIA LIKE '" + strNombreBoton + "'";
                    //realizo la consulta de acuerdo al parametro de filtro declarado en la consulta
                    DataRow[] objFilaBuscada = objTablaBuscadaProductos.Select(consulta);
                    //asigno el origen de datos
                    gvCategorias.DataSource = objFilaBuscada;
                    gvCategorias.DataBind();

                }

            }
            catch (Exception ex) 
            {
                Response.Write("<script>alert(error \n'"+ex.Message +"\n en Metodo para cargar gridwiev')</script>");
            }


        }

        /// <summary>
        /// Evento que se desencadena al hacer click en la categoria
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="e"></param>
        protected void ClickInLinkButtom(object Sender, EventArgs e)
        {

            try
            {
            //Instancio un objeto de la clase control
            System.Web.UI.Control controlIN = new Control();
            //Cast para obtener el nombre del control que desencadena el metodo
            controlIN = (Control)Sender;
            //Accedo al ID del control
            string btn = controlIN.ID;
            //invoco el metodo para llenar gridview
            cargarGridView(btn);
            gvCategorias.Visible = true;

            }
            catch (ArgumentOutOfRangeException ex) 
            {
                Response.Write("<script>alert('error \n"+ex.Message +"\n en EventoClickLinkButtom')</script>");
            }
        }


        /// <summary>
        /// Evento que se desencadena al dar click en buscar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            //Invoco ala metodo que se encarga de asignar un origen de datos al gridview
            llenarDatos();
        }
        /// <summary>
        /// Metodo encargadado de buscar los productos
        /// </summary>
        protected void llenarDatos()
        {
            try
            {
            
                TableRow objFila = new TableRow(); 
                //AccessData.DSInventario.Vista_Producto_AdministradorDataTable objTabla = new AccessData.DSInventario.Vista_Producto_AdministradorDataTable();   
                DataTable objTabla = new DataTable();
                //Obtengo los valores en el table adapter
                objTabla = objProcesoDatos.ObtenerDatosVistaAdministrador();

                string consulta = "[NOMBRE PRODUCTO] LIKE  '" + txbBuscar.Text.Trim() + "%'";
                //realizo la consulta en la tabla y realizo una consulta con parametros de filtro
                gvCategorias.DataSource = objTabla.Select(consulta);
                gvCategorias.DataBind();
                gvCategorias.Visible = true;
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('error\n "+ex.Message+"\n en Metodo llenarDatos')</script>");
            }
        }
        /// <summary>
        /// Evento al cual responde el gridview al hacer click en la fila
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow objFila = gvCategorias.SelectedRow;

                if (objFila != null)
                {
                    gvCategorias.Visible = false;
                }
            }catch(Exception ex)
            {
              Response.Write("<script>alert('error\n "+ex.Message+"\n en evento generado despues de seleccionar una fila en GridView')</script>");
            }
        }

  

        /// <summary>
        /// Evento que se desencadena al dar click en el boton crear producto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCrearProducto_Click1(object sender, EventArgs e)
        {

            int intFilasAfectadas = 0;
       
            try 
            {

                intFilasAfectadas = objProcesoDatos.InsertarProducto(txbNombreProd.Text.Trim(), Convert.ToInt32(txbCantixCaja.Text.Trim()), Convert.ToInt32(txbTotalUnidades.Text.Trim()), Convert.ToDecimal(txbPrecioProveedor.Text.Trim()), Convert.ToInt32(ddlProveedor.SelectedValue),Convert.ToInt32(ddlCategoria.SelectedValue));
                if (intFilasAfectadas > 0)
                {
                   
                  //  Response.Redirect("/Default.aspx#registroProducto");
                    Response.Write("<script> alert('Nuevo producto')</script>");
                }
                else
                {
                    Response.Write("<script> alert('NO se puede crear producto')</script>");
                }
            }catch(Exception ex)
            {
                Response.Write("<script> alert(' "+ex.Message+" ')</script>");
            }
            
        }

      

        }


    
}