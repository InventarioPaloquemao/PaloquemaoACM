using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccessData.DSInventarioTableAdapters;
using System.Data;


namespace PaloquemaoACM
{
    public partial class Default : System.Web.UI.Page
    {
        string nombre;
        string categoria;
        List <string> ListaEntrada=new List<string>();
        /// <summary>
        /// Lista almacena una lista de tipo string
        /// </summary>
        List<string> lista = new List<string>();
        /// <summary>
        /// Instancia de un objeto de la clase LinkButton
        /// </summary>
       Button btnCategorias = new Button();
        string btn = "";

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
           // pa_ObtenerCategoriasTableAdapter 
            CategoriasTableAdapter objCategoria = new CategoriasTableAdapter();
            ProveedoresTableAdapter objAdapterProveedor = new ProveedoresTableAdapter();
            ddlCategoria.DataSource = objCategoria.GetData();
            ddlCategoria.DataTextField = "Descripcion";
            ddlCategoria.DataValueField = "Id_Categoria";
            ddlCategoria.DataBind();
            ddlProveedor.DataSource = objAdapterProveedor.GetData();
            ddlProveedor.DataTextField = "Nombre_Proveedor";
            ddlProveedor.DataValueField = "Id_Proveedor";
            ddlProveedor.DataBind();

            if (ViewState["Valor"] != null)
            {
                lblErrorProd.Text = (string)ViewState["Valor"];
            }
        }

        /// <summary>
        /// Meotodo que responde al click del boton crear producto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        protected void btnCrearProducto_Click(object sender, EventArgs e)
        {
            try
            {
                int categoria= ddlCategoria.SelectedIndex+1;
                ProductosTableAdapter objAdapter = new ProductosTableAdapter();
                if ((ddlCategoria.SelectedIndex != 0 && ddlProveedor.SelectedIndex != 0))
                {


                    int filas = objAdapter.Insert(txbCodigo.Text.Trim(),
                        txbNombreProd.Text.Trim(),
                        Convert.ToInt32(txbCantixCaja.Text.Trim()),
                        Convert.ToInt32(txbTotalUnidades.Text.Trim()),
                        Convert.ToDecimal(txbPrecioProveedor.Text.Trim()),
                        ddlProveedor.SelectedIndex,
                       categoria
                        );

                    if (filas > 0)
                    {

                        lblErrorProd.Text = "Nuevo producto";
                        ViewState.Add("Valor",lblErrorProd);
                        Response.Redirect("/Default.aspx#registroProducto");
                       
                        
                        
                    }
                    else
                    {
                        lblErrorProd.Text = "No se puede crear el producto";
                        ViewState.Add("Valor", lblErrorProd);
                        Response.Redirect("/Default.aspx#registroProducto");
                       
                        
                    }


                }
                else
                {
                    lblErrorProd.Text = "Seleccione un valor en las listas despegables";
                    ViewState.Add("Valor", lblErrorProd);
                    Response.Redirect("/Default.aspx#registroProducto");
                   
                }
            }
            catch
            {

            }



        }

        protected void MenuCategoria()
        {
            try
            {
                //Contar las iteraciones en un ciclo
                int iteraciones = 0;
                /// Instancia de un DataTable
                DataTable objCategoriaTablaBuscada = new DataTable();
                ///Instancia de un Table Adapter para las categorias
                pa_ObtenerCategoriasTableAdapter objpaCategoria = new pa_ObtenerCategoriasTableAdapter();
                //Obtengo los valores almacenados en el DataSet y los asigono a un datatable
                objCategoriaTablaBuscada = objpaCategoria.GetData();
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
            catch (Exception ex) { }
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
                Vista_Producto_EmpleadoTableAdapter objProductosTA = new Vista_Producto_EmpleadoTableAdapter();

                DataTable objTablaBuscadaProductos = new DataTable();

                objTablaBuscadaProductos = objProductosTA.GetData();


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
            catch (Exception ex) { }


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
                ///invoco el metodo para llenar gridview
                cargarGridView(btn);
                gvCategorias.Visible = true;

            }
            catch (ArgumentOutOfRangeException ex) { }
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
                List<string> objLista = new List<string>();
                TableRow objFila = new TableRow();

                Vista_Producto_AdministradorTableAdapter objProductos = new Vista_Producto_AdministradorTableAdapter();
                DataTable objTabla = new DataTable();
                //Obtengo los valores en el table adapter
                objTabla = objProductos.GetData();

                string consulta = "[NOMBRE PRODUCTO] LIKE  '" + txbBuscar.Text.Trim() + "%'";
                //realizo la consulta en la tabla y realizo una consulta con parametros de filtro
                gvCategorias.DataSource = objTabla.Select(consulta);
                gvCategorias.DataBind();
                gvCategorias.Visible = true;
            }
            catch (Exception)
            { }
        }
        /// <summary>
        /// Evento al cual responde el gridview al hacer click en la fila
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow objFila=gvCategorias.SelectedRow;
            
            if(objFila != null){
                 nombre = objFila.Cells[1].Text;
                 categoria = objFila.Cells[2].Text;
                 txbNombreProducto.Focus();
                 txbNombreProducto.Text = nombre;
                 txbCategoria.Text = categoria;
                 ListaEntrada.Add(nombre);
                 ListaEntrada.Add(categoria);
                 ViewState.Add("ValoresProductos",ListaEntrada);
                Response.Redirect("/Default.aspx#regProducto");
            }
        }

        protected void btnActualizarCantidad_Click(object sender, EventArgs e)
        {
           

        }


    }
}