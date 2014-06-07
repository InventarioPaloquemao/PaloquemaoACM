using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccessData.DSInventarioTableAdapters;
using AccessData;
namespace AcessData
{
    public class ProcesoDatos
    {
        private UserProfileTableAdapter objTAUserProfile = new UserProfileTableAdapter();
        private ProveedoresTableAdapter objTAProveedor = new ProveedoresTableAdapter();
        private CategoriasTableAdapter objTACategorias = new CategoriasTableAdapter();
        private ProductosTableAdapter objTAProductos = new ProductosTableAdapter();
        private PedidoTableAdapter objTAPedido = new PedidoTableAdapter();
        private Detalle_PedidoTableAdapter objTADetallePedido = new Detalle_PedidoTableAdapter();
        private Entrada_ProductoTableAdapter objTAEntradaProducto = new Entrada_ProductoTableAdapter();
        private QueriesTableAdapter objStoredProcedure = new QueriesTableAdapter();
        private int _intFilasAfectadas = 0;
        
        //UserProfile CRUD

        /// <summary>
        /// Metodo encargado de ingresar datos en el TableAdapter para la tabla UserProfile
        /// </summary>
        /// <param name="guidFKIdUser"> Id de usuario a registrarse </param>
        /// <param name="strNombres"> Nombre del usuario </param>
        /// <param name="strApellidos"> Apellidos del usuario </param>
        /// <returns> Un valor entero que determinar el valor de filas afectadas 0 o 1 para este caso </returns>
        public int InsertarUserProfile(System.Guid guidFKIdUser, string strNombres, string strApellidos)
        {

            _intFilasAfectadas = 0;
            try
            {
                int Estado = 1;
                _intFilasAfectadas = objTAUserProfile.Insert(guidFKIdUser, strNombres, strApellidos, Estado);
            }
            catch (Exception ex)
            {
                _intFilasAfectadas = 0;
            }
            return _intFilasAfectadas;

        }
        /// <summary>
        /// Metodo encargado de obtener todos los datos de la tabla UserProfile
        /// </summary>
        /// <returns> Un objeto DataTable que contiene los datos de la tabla correspondiente</returns>
        public DSInventario.UserProfileDataTable ObtenerDatosUserProfile()
        {
            DSInventario.UserProfileDataTable objDTUserProfile = new DSInventario.UserProfileDataTable();

            try
            {
                objDTUserProfile = objTAUserProfile.GetData();

            }
            catch (Exception ex)
            {
                objDTUserProfile = null;
            }
            return objDTUserProfile;
        }

        /// <summary>
        /// Metodo para actualizar apellido y nombre del usuario
        /// </summary>
        /// <param name="nuevoNombre"> nuevo nombre para el usuario </param>
        /// <param name="nuevoApellido"> nuevo apellido para el usuario </param>
        /// <param name="FkIdUser"> Llave foranea para el usuario </param>
        /// <param name="oldName"> nombre original </param>
        /// <param name="oldLastName"> apellido original </param>
        /// <returns></returns>
        public int ActualizarUserProfile(string Nombres, string Apellidos, System.Guid Original_FK_Id_User, string Original_Nombres, string Original_Apellidos)
        {
            _intFilasAfectadas = 0;
            int Estado = 1;
            try
            {
                _intFilasAfectadas = objTAUserProfile.Update(Original_FK_Id_User, Nombres, Apellidos, Estado, Original_FK_Id_User, Original_Nombres, Original_Apellidos, Estado);
            }
            catch (Exception ex)
            {
                _intFilasAfectadas = 0;
            }
            return _intFilasAfectadas;
        }

        /// <summary>
        /// Metodo que se encarga de eliminar los datos en la tabla UserProfile 
        /// </summary>
        /// <param name="FKIdUserprofile"></param>
        /// <param name="strName"></param>
        /// <param name="strLastName"></param>
        /// <param name="intEstado"></param>
        /// <returns></returns>
        public int EliminarUser(System.Guid FKIdUserprofile, string strName, string strLastName, int intEstado)
        {
            int _intFilasAfectadas = 0;
            try
            {
                _intFilasAfectadas = objTAUserProfile.Delete(FKIdUserprofile, strName, strLastName, intEstado);
            }
            catch (Exception ex)
            {
                _intFilasAfectadas = 0;

            }
            return _intFilasAfectadas;
        }

        //Proveedores CRUD

        /// <summary>
        /// Metodo encargado de ingresar datos en el table adapter correspondiente a la tabla Proveedores
        /// </summary>
        /// <param name="strNombreProveedor"> Nombre del proveedor </param>
        /// <param name="strTelefono"> Numero telefonico </param>
        /// <param name="strDireccion"> Direccion proveeedor </param>
        /// <returns></returns>
        public int InsertaProveedores(string strNombreProveedor, string strTelefono, string strDireccion)
        {
            int _intFilasAfectadas = 0;
            try
            {
                int Estado = 1;
                _intFilasAfectadas = objTAProveedor.Insert(strNombreProveedor, strDireccion, strTelefono, Estado);
            }
            catch (Exception ex)
            {
                _intFilasAfectadas = 0;
            }
            return _intFilasAfectadas;
        }

        /// <summary>
        /// Metodo encargado de actualizar datos del proveedor
        /// </summary>
        /// <param name="IdProveedor"></param>
        /// <param name="strNombreProveedor"></param>
        /// <param name="strTelefono"></param>
        /// <param name="strDireccion"></param>
        /// <param name="strNuevoNombreProveedor"></param>
        /// <param name="strNuevoTelefono"></param>
        /// <param name="strNuevoDireccion"></param>
        /// <returns></returns>
        public int ActualizarProveedor(string Nombre_Proveedor, string Direccion, string Telefono, int Original_Id_Proveedor, string Original_Nombre_Proveedor, string Original_Direccion, string Original_Telefono)
        {
            int Estado_Proveedor = 1;
            _intFilasAfectadas = 0;
            try
            {
                _intFilasAfectadas = objTAProveedor.Update(Nombre_Proveedor, Direccion, Telefono, Estado_Proveedor, Original_Id_Proveedor, Original_Nombre_Proveedor, Original_Direccion, Original_Telefono, Estado_Proveedor, Original_Id_Proveedor);

            }
            catch (Exception ex)
            {
                _intFilasAfectadas = 0;
            }
            return _intFilasAfectadas;
        }
        /// <summary>
        /// Metodo encargado de eliminar datos del proveedor
        /// </summary>
        /// <param name="IdProveedor"></param>
        /// <param name="strNombreProveedor"></param>
        /// <param name="strDreccion"></param>
        /// <param name="strTelefono"></param>
        /// <returns></returns>
        public int EliminarProveedor(int Original_Id_Proveedor, string Original_Nombre_Proveedor, string Original_Direccion, string Original_Telefono)
        {
            int Estado_Proveedor = 1;
            _intFilasAfectadas = 0;
            try
            {
                _intFilasAfectadas = objTAProveedor.Delete(Original_Id_Proveedor, Original_Nombre_Proveedor, Original_Direccion, Original_Telefono, Estado_Proveedor);
            }
            catch (Exception ex)
            {
                _intFilasAfectadas = 0;
            }
            return _intFilasAfectadas;
        }

        /// <summary>
        /// Metodo para obtener los datos de proveedores
        /// </summary>
        /// <returns></returns>
        public DSInventario.ProveedoresDataTable ObtenerProveedores()
        {
            DSInventario.ProveedoresDataTable objDTProveedores = new DSInventario.ProveedoresDataTable();

            try
            {

                objDTProveedores.Rows.Add(objTAProveedor.GetData().Select("Proveedores.Estado_Proveedor = 1"));
            }
            catch (Exception ex)
            {
                objDTProveedores = null;
            }
            return objDTProveedores;
        }

        //Categorias CRUD

        /// <summary>
        /// Metodo para ingresar datos al table adapter correspondiente a la tabla categorias
        /// </summary>
        /// <param name="descripcion"></param>
        /// <returns></returns>
        public int InsertarCategoria(string descripcion)
        {
            _intFilasAfectadas = 0;
            try
            {
                int EstadoCategoria = 1;
                _intFilasAfectadas = objTACategorias.Insert(descripcion, EstadoCategoria);
            }
            catch (Exception ex)
            {
                _intFilasAfectadas = 0;
            }
            return _intFilasAfectadas;
        }

        /// <summary>
        /// Metodo encargado de actualizar la tabla categorias
        /// </summary>
        /// <param name="Descripcion"></param>
        /// <param name="Original_Id_Categoria"></param>
        /// <param name="Original_Descripcion"></param>
        /// <returns></returns>
        public int ActualizarCategoria(string Descripcion, int Original_Id_Categoria, string Original_Descripcion)
        {
            int EstadoCategoria = 1;
            _intFilasAfectadas = 0;
            try
            {
                _intFilasAfectadas = objTACategorias.Update(Descripcion, EstadoCategoria, Original_Id_Categoria, Original_Descripcion, EstadoCategoria);
            }
            catch (Exception ex)
            {
                _intFilasAfectadas = 0;
            }
            return _intFilasAfectadas;
        }

        /// <summary>
        /// Metodo para eliminar datos en tabla categoria
        /// </summary>
        /// <param name="idCategoria"></param>
        /// <param name="descripcion"></param>
        /// <returns></returns>
        public int EliminarCategoria(int idCategoria, string descripcion)
        {
            _intFilasAfectadas = 0;
            try
            {
                _intFilasAfectadas = objTACategorias.Delete(idCategoria, descripcion, 1);
            }
            catch (Exception ex)
            {
                _intFilasAfectadas = 0;
            }
            return _intFilasAfectadas;
        }

        /// <summary>
        /// Metodo encargado de obtener las categorias
        /// </summary>
        /// <returns></returns>
        public DSInventario.CategoriasDataTable ObtenerCategoria()
        {
            DSInventario.CategoriasDataTable objDTCategoria = new DSInventario.CategoriasDataTable();

            try
            {
                objDTCategoria.Rows.Add(objTACategorias.GetData().Select("EstadoCategoria = 1"));
            }
            catch (Exception ex)
            {
                objDTCategoria = null;
            }
            return objDTCategoria;
        }

        //Productos CRUD

        /// <summary>
        /// Metodo encargado de ingresar datos a la tabla productos
        /// </summary>
        /// <param name="Nombre_Producto"></param>
        /// <param name="UnidadesPorCaja"></param>
        /// <param name="Existencias"></param>
        /// <param name="ValorProveedor"></param>
        /// <param name="FK_Id_Proveedor"></param>
        /// <param name="FK_Id_Categoria"></param>
        /// <returns></returns>
        public int InsertarProducto(string Nombre_Producto, int UnidadesPorCaja, int Existencias, decimal ValorProveedor, int FK_Id_Proveedor, int FK_Id_Categoria)
        {
            _intFilasAfectadas = 0;
            try
            {
                int EstadoProducto = 1;
                _intFilasAfectadas = objTAProductos.Insert(Nombre_Producto, UnidadesPorCaja, Existencias, ValorProveedor, FK_Id_Proveedor, FK_Id_Categoria, EstadoProducto);
            }
            catch (Exception ex)
            {
                _intFilasAfectadas = 0;
            }
            return _intFilasAfectadas;
        }

        /// <summary>
        /// Metodo para actualizar productos
        /// </summary>
        /// <param name="Nombre_Producto"></param>
        /// <param name="UnidadesPorCaja"></param>
        /// <param name="Existencias"></param>
        /// <param name="ValorProveedor"></param>
        /// <param name="FK_Id_Proveedor"></param>
        /// <param name="FK_Id_Categoria"></param>
        /// <param name="Original_Id_Producto"></param>
        /// <param name="Original_Nombre_Producto"></param>
        /// <param name="Original_UnidadesPorCaja"></param>
        /// <param name="Original_Existencias"></param>
        /// <param name="Original_ValorProveedor"></param>
        /// <param name="Original_FK_Id_Proveedor"></param>
        /// <param name="Original_FK_Id_Categoria"></param>
        /// <returns></returns>
        public int ActualizarProducto(string Nombre_Producto,
                    int UnidadesPorCaja,
                    int Existencias,
                    decimal ValorProveedor,
                    int FK_Id_Proveedor,
                    int FK_Id_Categoria,
                    int Original_Id_Producto,
                    string Original_Nombre_Producto,
                    int Original_UnidadesPorCaja,
                    int Original_Existencias,
                    decimal Original_ValorProveedor,
                    int Original_FK_Id_Proveedor,
                    int Original_FK_Id_Categoria)
        {
            _intFilasAfectadas = 0;
            try
            {
                _intFilasAfectadas = objTAProductos.Update(Nombre_Producto, UnidadesPorCaja, Existencias, ValorProveedor, FK_Id_Proveedor, FK_Id_Categoria, 1, Original_Id_Producto, Original_Nombre_Producto, Original_UnidadesPorCaja, Original_Existencias, Original_ValorProveedor, Original_FK_Id_Proveedor, Original_FK_Id_Categoria, 1, null, null, null);
            }
            catch (Exception ex)
            {
                _intFilasAfectadas = 0;
            }
            return _intFilasAfectadas;
        }


        /// <summary>
        /// Metodo encargado de eliminar los productos
        /// </summary>
        /// <param name="Original_Id_Producto"></param>
        /// <param name="Original_Nombre_Producto"></param>
        /// <param name="Original_UnidadesPorCaja"></param>
        /// <param name="Original_Existencias"></param>
        /// <param name="Original_ValorProveedor"></param>
        /// <param name="Original_FK_Id_Proveedor"></param>
        /// <param name="Original_FK_Id_Categoria"></param>
        /// <param name="Original_EstadoProducto"></param>
        /// <param name="Original_Costo_Unidad_Mayorista"></param>
        /// <returns></returns>
        public int EliminarProducto(int Original_Id_Producto, string Original_Nombre_Producto, int Original_UnidadesPorCaja, int Original_Existencias, decimal Original_ValorProveedor, int Original_FK_Id_Proveedor, int Original_FK_Id_Categoria, global::System.Nullable<int> Original_EstadoProducto, global::System.Nullable<decimal> Original_Costo_Unidad_Mayorista)
        {
            _intFilasAfectadas = 0;
            try
            {
                _intFilasAfectadas = objTAProductos.Delete(Original_Id_Producto, Original_Nombre_Producto, Original_UnidadesPorCaja, Original_Existencias, Original_ValorProveedor, Original_FK_Id_Proveedor, Original_FK_Id_Categoria, 1, null, null, null);
            }
            catch (Exception ex)
            {
                _intFilasAfectadas = 0;
            }
            return _intFilasAfectadas;
        }

        /// <summary>
        /// Metodo para obtener los datos del table adapter correspondiente a la tabla productos
        /// </summary>
        /// <returns></returns>
        public DSInventario.ProductosDataTable ObtenerProductos()
        {
            DSInventario.ProductosDataTable objDTProductos = new DSInventario.ProductosDataTable();
            try
            {
                objDTProductos.Rows.Add(objTAProductos.GetData().Select("EstadoProducto = 1 "));
            }
            catch (Exception ex)
            {
                objDTProductos = null;
            }
            return objDTProductos;
        }

        //Procedimiento almacenado  para actualizar existencias

        /// <summary>
        /// Metodod para actualizar existencias de los productos
        /// </summary>
        /// <param name="IdProducto"></param>
        /// <param name="NuevaCantidad"></param>
        /// <returns></returns>
        public int ActualizarExistenciasProducto(int IdProducto,int NuevaCantidad)
        {
            _intFilasAfectadas = 0;
            try
            {
                _intFilasAfectadas = objStoredProcedure.pa_ActualizarExistencias(IdProducto, NuevaCantidad);
            }
            catch (Exception ex) 
            {
                _intFilasAfectadas = 0;
            }
            return _intFilasAfectadas;
        }

        //Entrada Producto CRUD

        /// <summary>
        /// Metodo para ingresar datos en entrada producto
        /// </summary>
        /// <param name="Cantidad_ingresada"></param>
        /// <param name="FK_Id_User"></param>
        /// <param name="FK_Id_Producto"></param>
        /// <returns></returns>
        public int InsertarEntradaProducto( int Cantidad_ingresada, System.Guid FK_Id_User, int FK_Id_Producto)
        {
            _intFilasAfectadas = 0;
            try
            {
                DateTime Fecha = DateTime.Now;
                _intFilasAfectadas = objTAEntradaProducto.Insert(Fecha, Cantidad_ingresada, FK_Id_User, FK_Id_Producto);
            }catch(Exception ex)
            {
                _intFilasAfectadas = 0;
            }
            return _intFilasAfectadas;
        }

        /// <summary>
        /// Metodo encargado para obtener entradas de productos
        /// </summary>
        /// <returns></returns>
        public DSInventario.Entrada_ProductoDataTable ObtenerEntradasProducto()
        {
            DSInventario.Entrada_ProductoDataTable objDTEntradaProducto = new DSInventario.Entrada_ProductoDataTable();
            
            try
            {
                 objDTEntradaProducto.Rows.Add(objTAEntradaProducto.GetData());
            }
            catch (Exception ex) 
            {
                objTAEntradaProducto = null;
            }
            return objDTEntradaProducto;
        }

        //Pedido CRUD
        /// <summary>
        /// Metodo para ingresar datos en Pedido
        /// </summary>
        /// <param name="IdUser"></param>
        /// <returns></returns>
        public int InsertarPedido(System.Guid IdUser) 
        {
            _intFilasAfectadas = 0;
            
            try
            {
                _intFilasAfectadas = objTAPedido.Insert(DateTime.Now,IdUser);
            }catch(Exception ex)
            {
                _intFilasAfectadas = 0;
            }
            return _intFilasAfectadas;
        }

        /// <summary>
        /// Metodo para obtener Pedidos
        /// </summary>
        /// <returns></returns>
        public DSInventario.PedidoDataTable ObtenerPedido()
        {
            DSInventario.PedidoDataTable objDTPedido = new DSInventario.PedidoDataTable();
            try {
                objDTPedido.Rows.Add(objTAPedido.GetData());
            }catch(Exception ex)
            {
                objDTPedido = null;
            }
            return objDTPedido;
        }





        //Detalle pedido CRUD

        /// <summary>
        /// Metodo para insertar datos en tabla Detalle Pedido
        /// </summary>
        /// <param name="Cantidad_Pedido"></param>
        /// <param name="FK_Id_Pedido"></param>
        /// <param name="FK_Id_Producto"></param>
        /// <returns></returns>
        public int InsertaDetallePedido(string Cantidad_Pedido, int FK_Id_Pedido, int FK_Id_Producto) 
        {
            _intFilasAfectadas = 0;
            try
            {
                _intFilasAfectadas = objTADetallePedido.Insert(Cantidad_Pedido,FK_Id_Pedido,FK_Id_Producto);
            }
            catch (Exception ex)
            {
                _intFilasAfectadas = 0;
            }
            return _intFilasAfectadas;
        }

        public DSInventario.Detalle_PedidoDataTable ObtenerDetallePedido() 
        {
            DSInventario.Detalle_PedidoDataTable objDTDetallePedido = new DSInventario.Detalle_PedidoDataTable();
            try
            {
                objDTDetallePedido.Rows.Add(objTADetallePedido.GetData());
            }
            catch (Exception ex)
            {
                objDTDetallePedido = null;
            }
            return objDTDetallePedido;
        }
    }
}
