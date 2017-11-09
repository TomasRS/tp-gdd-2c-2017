using PagoAgilFrba.Excepciones;
using PagoAgilFrba.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagoAgilFrba.DataProvider
{
    class DBMapper
    {
        private String query;
        private IList<SqlParameter> parametros = new List<SqlParameter>();
        private SqlParameter parametroOutput;
        private SqlCommand command;

        //GENERICOS
        public int Crear(Mapeable objeto)
        {
            query = objeto.GetQueryCrear();
            parametros.Clear();
            parametros = objeto.GetParametros();
            parametroOutput = new SqlParameter("@id", SqlDbType.Int);
            parametroOutput.Direction = ParameterDirection.Output;
            parametros.Add(parametroOutput);
            command = QueryBuilder.Instance.build(query, parametros);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            return (int)parametroOutput.Value;
        }

        public int Modificar(Decimal id, Mapeable objeto)
        {
            query = objeto.GetQueryModificar();
            parametros.Clear();
            parametros = objeto.GetParametros();
            parametros.Add(new SqlParameter("@id", id));
            parametroOutput = new SqlParameter("@id_output", SqlDbType.Int);
            parametroOutput.Direction = ParameterDirection.Output;
            parametros.Add(parametroOutput);
            command = QueryBuilder.Instance.build(query, parametros);
            command.CommandType = CommandType.StoredProcedure;
            int rowsAffected = command.ExecuteNonQuery();
            return rowsAffected;
        }

        public Mapeable Obtener(int id, Type clase)
        {
            Mapeable objeto = (Mapeable)Activator.CreateInstance(clase);
            query = objeto.GetQueryObtener();
            parametros.Clear();
            parametros.Add(new SqlParameter("@id", id));
            SqlDataReader reader = QueryBuilder.Instance.build(query, parametros).ExecuteReader();
            if (reader.Read())
            {
                objeto.CargarInformacion(reader);
                return objeto;
            }
            return objeto;
        }




        public DataTable SelectDataTable(String que, String deDonde, String condiciones)
        {
            return this.SelectDataTableConUsuario(que, deDonde, condiciones);
        }

        public DataTable SelectDataTableConUsuario(String que, String deDonde, String condiciones)
        {
            parametros.Clear();
            //parametros.Add(new SqlParameter("@idUsuario", UsuarioSesion.Usuario.id));
            command = QueryBuilder.Instance.build("SELECT " + que + " FROM " + deDonde + " WHERE " + condiciones, parametros);
            command.CommandTimeout = 0;
            DataSet datos = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(datos);
            return datos.Tables[0];
        }

        
        /*
         * 
         *  GET TABLE QUERIES 
         * 
         */
        public Cliente ObtenerCliente(int idCliente)
        {
            Cliente objeto = new Cliente();
            Type clase = objeto.GetType();
            return (Cliente)this.Obtener(idCliente, clase);
        }

        public Empresa ObtenerEmpresa(int idEmpresa)
        {
            Empresa objeto = new Empresa();
            Type clase = objeto.GetType();
            return (Empresa)this.Obtener(idEmpresa, clase);
        }

        public Rol ObtenerRol(int idRol)
        {
            Rol objeto = new Rol();
            Type clase = objeto.GetType();
            return (Rol)this.Obtener(idRol, clase);
        }

        public DataSet getFuncionalidadesDelRol(int idRol)
        {
            DataSet funcionalidades = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@id_rol", idRol));
            command = QueryBuilder.Instance.build("SELECT DISTINCT f.descripcion from GAME_OF_CODE.Funcionalidad f, GAME_OF_CODE.Funcionalidad_por_Rol fr WHERE f.id_funcionalidad = fr.id_funcionalidad AND fr.id_rol = @id_rol", parametros);
            adapter.SelectCommand = command;
            adapter.Fill(funcionalidades);
            return funcionalidades;
        }

        public DataSet getRolesDelUsuario(int idUsuario)
        {
            DataSet roles = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@id_usuario", idUsuario));
            command = QueryBuilder.Instance.build("SELECT DISTINCT r.nombre from GAME_OF_CODE.Rol r, GAME_OF_CODE.Rol_por_Usuario ru WHERE r.id_rol = ru.id_rol AND ru.id_usuario = @id_usuario", parametros);
            adapter.SelectCommand = command;
            adapter.Fill(roles);
            return roles;
        }

        public DataSet getSucursalesDelUsuario(int idUsuario)
        {
            DataSet sucursales = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@id_usuario", idUsuario));
            command = QueryBuilder.Instance.build("SELECT DISTINCT s.nombre from GAME_OF_CODE.Sucursal s, GAME_OF_CODE.Usuario_por_Sucursal su WHERE s.id_sucursal = su.id_sucursal AND su.id_usuario = @id_usuario", parametros);
            adapter.SelectCommand = command;
            adapter.Fill(sucursales);
            return sucursales;
        }

        public String getNombreRol(int idRol)
        {
            query = "SELECT nombre FROM GAME_OF_CODE.Rol WHERE id_rol = @id_rol";
            parametros.Clear();
            parametros.Add(new SqlParameter("@id_rol", idRol));
            String descripcion = (String)QueryBuilder.Instance.build(query, parametros).ExecuteScalar();
            return descripcion;
        }

        public Sucursal ObtenerSucursal(int idSucursal)
        {
            Sucursal objeto = new Sucursal();
            Type clase = objeto.GetType();
            return (Sucursal)this.Obtener(idSucursal, clase);
        }

        public Factura ObtenerFactura(int idFactura)
        {
            Factura objeto = new Factura();
            Type clase = objeto.GetType();
            return (Factura)this.Obtener(idFactura, clase);
        }

        public int getIDRol(String nombreRol)
        {
            query = "SELECT id_rol FROM GAME_OF_CODE.Rol WHERE nombre = @nombre";
            parametros.Clear();
            parametros.Add(new SqlParameter("@nombre", nombreRol));
            int idRol = (int)QueryBuilder.Instance.build(query, parametros).ExecuteScalar();
            return idRol;
        }

        public Boolean ExisteNombreRol(String nombreRol)
        {
            query = "SELECT COUNT(*) FROM GAME_OF_CODE.Rol WHERE nombre = @nombre";
            parametros.Clear();
            parametros.Add(new SqlParameter("@nombre", nombreRol));
            return ControlDeUnicidad(query, parametros);
        }

        /*
         * 
         *  DELETE QUERIES (deshabilitar)
         *
         */
        public Boolean CambiarHabilitacionUsuario(int id, String enDonde, int nuevoEstadoHabilitacion)
        {
            query = "UPDATE GAME_OF_CODE." + enDonde + " SET estado_habilitacion = " + nuevoEstadoHabilitacion.ToString() + "WHERE id_usuario = @id";
            parametros.Clear();
            parametros.Add(new SqlParameter("@id", id));
            int filasAfectadas = QueryBuilder.Instance.build(query, parametros).ExecuteNonQuery();
            return filasAfectadas.Equals(1);
        }

        public Boolean CambiarHabilitacionCliente(int id, String enDonde, int nuevoEstadoHabilitacion)
        {
            query = "UPDATE GAME_OF_CODE." + enDonde + " SET estado_habilitacion = " + nuevoEstadoHabilitacion.ToString() + "WHERE id_cliente = @id";
            parametros.Clear();
            parametros.Add(new SqlParameter("@id", id));
            int filasAfectadas = QueryBuilder.Instance.build(query, parametros).ExecuteNonQuery();
            return filasAfectadas.Equals(1);
        }

        public Boolean CambiarHabilitacionEmpresa(int id, String enDonde, int nuevoEstadoHabilitacion)
        {
            query = "UPDATE GAME_OF_CODE." + enDonde + " SET estado_habilitacion = " + nuevoEstadoHabilitacion.ToString() + "WHERE id_empresa = @id";
            parametros.Clear();
            parametros.Add(new SqlParameter("@id", id));
            int filasAfectadas = QueryBuilder.Instance.build(query, parametros).ExecuteNonQuery();
            return filasAfectadas.Equals(1);
        }

        public Boolean CambiarHabilitacionRol(int id, String enDonde, int nuevoEstadoHabilitacion)
        {
            query = "UPDATE GAME_OF_CODE." + enDonde + " SET estado_habilitacion = " + nuevoEstadoHabilitacion.ToString() + "WHERE id_rol = @id";
            parametros.Clear();
            parametros.Add(new SqlParameter("@id", id));
            int filasAfectadas = QueryBuilder.Instance.build(query, parametros).ExecuteNonQuery();
            return filasAfectadas.Equals(1);
        }

        public Boolean CambiarHabilitacionSucursal(int id, String enDonde, int nuevoEstadoHabilitacion)
        {
            query = "UPDATE GAME_OF_CODE." + enDonde + " SET estado_habilitacion = " + nuevoEstadoHabilitacion.ToString() + "WHERE id_sucursal = @id";
            parametros.Clear();
            parametros.Add(new SqlParameter("@id", id));
            int filasAfectadas = QueryBuilder.Instance.build(query, parametros).ExecuteNonQuery();
            return filasAfectadas.Equals(1);
        }

        public Boolean CambiarHabilitacionFactura(int id, String enDonde, int nuevoEstadoHabilitacion)
        {
            query = "UPDATE GAME_OF_CODE." + enDonde + " SET estado_habilitacion = " + nuevoEstadoHabilitacion.ToString() + "WHERE id_factura = @id";
            parametros.Clear();
            parametros.Add(new SqlParameter("@id", id));
            int filasAfectadas = QueryBuilder.Instance.build(query, parametros).ExecuteNonQuery();
            return filasAfectadas.Equals(1);
        }

        /*
         * 
         *  SELECT TABLE QUERIES 
         *
         */
        public DataTable SelectClientesParaFiltro()
        {
            return this.SelectClientesParaFiltroConFiltro("");
        }

        public DataTable SelectClientesParaFiltroConFiltro(String filtro)
        {
            return this.SelectDataTable("cli.id_cliente, cli.nombre Nombre, cli.apellido Apellido, cli.dni Documento, cli.mail Mail, cli.telefono Teléfono, cli.direccion Dirección, cli.codigo_postal 'Código Postal', cli.cli_fecha_nac 'Fecha de Nacimiento', cli.estado_habilitacion 'Habilitado'"
                , "GAME_OF_CODE.Cliente cli"
                , "(cli.estado_habilitacion = 1 OR cli.estado_habilitacion = 0) " + filtro);
        }

        public DataTable SelectEmpresasParaFiltro()
        {
            return this.SelectEmpresasParaFiltroConFiltro("");
        }

        public DataTable SelectEmpresasParaFiltroConFiltro(String filtro)
        {
            return this.SelectDataTable("emp.id_empresa, emp.nombre Nombre, emp.emp_cuit CUIT, emp.emp_direccion Dirección, (SELECT descripcion FROM GAME_OF_CODE.Rubro WHERE id_rubro = emp.id_rubro) 'Rubro', emp.porcentaje_comision 'Porcentaje comisión', emp.estado_habilitacion 'Habilitado'"
              , "GAME_OF_CODE.Empresa emp"
              , "(emp.estado_habilitacion = 1 OR emp.estado_habilitacion = 0) " + filtro);
        }

        public DataTable SelectRolesParaFiltro()
        {
            return this.SelectRolesParaFiltroConFiltro("");
        }

        public DataTable SelectRolesParaFiltroConFiltro(String filtro)
        {
            return this.SelectDataTable("r.id_rol, r.nombre Nombre, r.estado_habilitacion 'Habilitado'"
                ,"GAME_OF_CODE.Rol r"
                , "(r.estado_habilitacion = 1 OR r.estado_habilitacion = 0)");
        }

        public DataTable SelectSucursalesParaFiltro()
        {
            return this.SelectSucursalesParaFiltroConFiltro("");
        }

        public DataTable SelectSucursalesParaFiltroConFiltro(String filtro)
        {
            return this.SelectDataTable("S.id_sucursal, S.nombre Nombre, S.direccion Direccion, S.codigo_postal CodPostal, S.estado_habilitacion 'Habilitado'"
                , "GAME_OF_CODE.Sucursal S"
                , "(S.estado_habilitacion = 1 OR S.estado_habilitacion = 0)" + filtro);
        }

        public DataTable SelectFacturasParaFiltro()
        {
            return this.SelectDataTable("F.id_factura, F.numero_factura 'Número factura', F.fecha_alta 'Fecha de alta', F.monto_total 'Monto total', F.fecha_vencimiento 'Fecha de vencimiento', E.nombre 'Nombre empresa', C.nombre 'Nombre cliente', C.apellido 'Apellido', F.estado_habilitacion 'Habilitado'"
                , "GAME_OF_CODE.Factura F, GAME_OF_CODE.Empresa E, GAME_OF_CODE.Cliente C"
                , "(F.estado_habilitacion = 1 OR F.estado_habilitacion = 0) AND (E.id_empresa = F.id_empresa) AND (F.id_cliente = C.id_cliente) AND (F.id_pago IS NULL) ORDER BY F.numero_factura asc");
        }

        public DataTable SelectItemsFactura(int idFactura)
        {
            return this.SelectDataTable("I.item_factura 'Item factura', I.cantidad 'Cantidad', I.item_monto 'Importe'"
                , "GAME_OF_CODE.Detalle_Factura I"
                , "I.id_factura = " + idFactura);
        }

        public DataTable SelectUsuariosParaFiltro()
        {
            return this.SelectDataTable("id_usuario, username 'Username'", "GAME_OF_CODE.Usuario", "estado_habilitacion = 0");
        }

        public DataTable SelectFacturasParaRendir(DateTime fechaInicio, DateTime fechaFin, int idEmpresa)
        {
            return SelectDataTable("F.id_factura, F.numero_factura 'Número factura', F.monto_total 'Monto total', PF.fecha_cobro 'Fecha de Pago'"
                        , "GAME_OF_CODE.Factura F, GAME_OF_CODE.Pago_de_Facturas PF"
                        , "(F.id_empresa = " + idEmpresa.ToString() + ")" + " AND ((SELECT COUNT(*) FROM GAME_OF_CODE.Detalle_Rendicion WHERE id_factura = F.id_factura) = 0) AND (F.id_pago = PF.id_pago_facturas) AND (PF.fecha_cobro BETWEEN '" + fechaInicio.ToString("yyyy-MM-dd") + "' and '" + fechaFin.ToString("yyyy-MM-dd") + "')");
        }

        //-------------------------------------------------------------
        /** Usuario **/
        public int getIDUsuario(String username)
        {
            query = "SELECT id_usuario FROM GAME_OF_CODE.Usuario WHERE username = @username";
            parametros.Clear();
            parametros.Add(new SqlParameter("@username", username));
            int idUsuario = (int)QueryBuilder.Instance.build(query, parametros).ExecuteScalar();
            return idUsuario;
        }

        public int getIDUnicaSucursalUsuario(int idUsuario)
        {
            query = "SELECT id_sucursal FROM GAME_OF_CODE.Usuario_por_Sucursal WHERE id_usuario = @id_usuario";
            parametros.Clear();
            parametros.Add(new SqlParameter("@id_usuario", idUsuario));
            int idSucursal = (int)QueryBuilder.Instance.build(query, parametros).ExecuteScalar();
            return idSucursal;
        }

        public int getIDSucursal(String nombreSucursal)
        {
            query = "SELECT id_sucursal FROM GAME_OF_CODE.Sucursal WHERE nombre = @nombre";
            parametros.Clear();
            parametros.Add(new SqlParameter("@nombre", nombreSucursal));
            int idSucursal = (int)QueryBuilder.Instance.build(query, parametros).ExecuteScalar();
            return idSucursal;
        }

        public void ResetearIntentosFallidosUsuario(int idUsuario)
        {
            query = "UPDATE GAME_OF_CODE.Usuario SET intentos_fallidos = 0 WHERE id_usuario = @id_usuario";
            parametros.Clear();
            parametros.Add(new SqlParameter("@id_usuario", idUsuario));
            QueryBuilder.Instance.build(query, parametros).ExecuteNonQuery();
        }

        public Boolean HayUsuariosDeshabilitados()
        {
            query = "SELECT COUNT(*) FROM GAME_OF_CODE.Usuario WHERE estado_habilitacion = 0";
            parametros.Clear();
            return ControlDeUnicidad(query, parametros);
        }
        
        /** Clientes **/

        public int CrearCliente(Cliente cliente)
        {

            if (existeCliente(cliente.getMail()))
                throw new ClienteYaExisteException();

            return this.Crear(cliente);
        }

        public int ModificarCliente(Cliente cliente, int idCliente)
        {
            return this.Modificar(idCliente,cliente);
        }

        public Boolean existeCliente(string mail)
        {
            query = "SELECT COUNT(*) FROM GAME_OF_CODE.Cliente WHERE mail = @mail";
            parametros.Clear();
            parametros.Add(new SqlParameter("@mail", mail));
            return ControlDeUnicidad(query, parametros);
        }

        public int getIDCliente(String mailCliente)
        {
            query = "SELECT id_cliente FROM GAME_OF_CODE.Cliente WHERE mail = @mail";
            parametros.Clear();
            parametros.Add(new SqlParameter("@mail", mailCliente));
            int id = (int)QueryBuilder.Instance.build(query, parametros).ExecuteScalar();
            return id;
        }

        public String getMailCliente(int idCliente)
        {
            query = "SELECT mail FROM GAME_OF_CODE.Cliente WHERE id_cliente = @id";
            parametros.Clear();
            parametros.Add(new SqlParameter("@id", idCliente));
            String mailDelCliente = (String)QueryBuilder.Instance.build(query, parametros).ExecuteScalar();
            return mailDelCliente;
        }

        public int getIDClienteEnBaseA(String nroFactura, int idEmpresa)
        {
            query = "SELECT id_cliente FROM GAME_OF_CODE.Factura WHERE numero_factura = @numero_factura AND id_empresa = @id_empresa";
            parametros.Clear();
            parametros.Add(new SqlParameter("@numero_factura", nroFactura));
            parametros.Add(new SqlParameter("@id_empresa", idEmpresa));
            int idCliente = (int)QueryBuilder.Instance.build(query, parametros).ExecuteScalar();
            return idCliente;
        }

        /** Empresas **/

        public int CrearEmpresa(Empresa empresa)
        {
            if (existeEmpresaConCuit(empresa.getCuit()))
                throw new CuitYaExisteException();

            return this.Crear(empresa);
        }

        public int ModificarEmpresa(Empresa empresa, int idEmpresa)
        {
            return this.Modificar(idEmpresa, empresa);
        }

        public Boolean empresaEstaActiva(int idEmpresa)
        {
            query = "SELECT COUNT(*) FROM GAME_OF_CODE.Empresa WHERE id_empresa = @id_empresa AND estado_habilitacion = 1";
            parametros.Clear();
            parametros.Add(new SqlParameter("@id_empresa", idEmpresa));
            return ControlDeUnicidad(query, parametros);
        }

        private Boolean existeEmpresaConCuit(String cuit)
        {
            query = "SELECT COUNT(*) FROM GAME_OF_CODE.Empresa WHERE emp_cuit = @cuit";
            parametros.Clear();
            parametros.Add(new SqlParameter("@cuit", cuit));
            return ControlDeUnicidad(query, parametros);
        }

        public int getIDRubro(String rubroDescripcion)
        {
            query = "SELECT id_rubro FROM GAME_OF_CODE.Rubro WHERE descripcion = @descripcion";
            parametros.Clear();
            parametros.Add(new SqlParameter("@descripcion", rubroDescripcion));
            int id = (int)QueryBuilder.Instance.build(query, parametros).ExecuteScalar();
            return id;
        }

        public String getDescripcionRubro(int idRubro)
        {
            query = "SELECT descripcion FROM GAME_OF_CODE.Rubro WHERE id_rubro = @id_rubro";
            parametros.Clear();
            parametros.Add(new SqlParameter("@id_rubro", idRubro));
            String descripcionRubro = (String)QueryBuilder.Instance.build(query, parametros).ExecuteScalar();
            return descripcionRubro;
        }

        public String getNombreEmpresa(int idEmpresa)
        {
            query = "SELECT nombre FROM GAME_OF_CODE.Empresa WHERE id_empresa = @id";
            parametros.Clear();
            parametros.Add(new SqlParameter("@id", idEmpresa));
            String descripcionRubro = (String)QueryBuilder.Instance.build(query, parametros).ExecuteScalar();
            return descripcionRubro;
        }

        public Boolean EmpresaTieneTodasSusFacturasRendidas(int idEmpresa)
        {
            query = "GAME_OF_CODE.TotalDeFacturasPorRendirDeUnaEmpresa";
            parametros.Clear();
            parametros.Add(new SqlParameter("@id_empresa", idEmpresa));
            parametroOutput = new SqlParameter("@cantSinRendir", SqlDbType.Int);
            parametroOutput.Direction = ParameterDirection.Output;
            parametros.Add(parametroOutput);
            command = QueryBuilder.Instance.build(query, parametros);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
            return ((int)parametroOutput.Value).Equals(0);
        }

        /** Sucursales **/

        public int CrearSucursal(Sucursal sucursal)
        {
            if (existeSucursalConCodPostal(sucursal.getCodPostal()))
                throw new CodigoPostalYaExisteException();

            return this.Crear(sucursal);
        }

        public int ModificarSucursal(Sucursal sucursal, int idSucursal)
        {
            return this.Modificar(idSucursal, sucursal);
        }

        private Boolean existeSucursalConCodPostal(String codPostal)
        {
            query = "SELECT COUNT(*) FROM GAME_OF_CODE.Sucursal WHERE codigo_postal = @codPostal";
            parametros.Clear();
            parametros.Add(new SqlParameter("@codPostal", codPostal));
            return ControlDeUnicidad(query, parametros);
        }

        public String getNombreSucursal(int idSucursal)
        {
            query = "SELECT nombre FROM GAME_OF_CODE.Sucursal WHERE id_sucursal = @id_sucursal";
            parametros.Clear();
            parametros.Add(new SqlParameter("@id_sucursal", idSucursal));
            String nombreSucursal = (String)QueryBuilder.Instance.build(query, parametros).ExecuteScalar();
            return nombreSucursal;
        }

        //* Facturas*//
        public int CrearFactura(Factura factura)
        {
            if (existeFacturaParaEmpresa(factura))
                throw new YaExisteNumeroFacturaParaEmpresa();

            return this.Crear(factura);
        }

        public int CrearDetalleFactura(ItemFactura itemFactura, int idFactura)
        {
            return this.Crear(itemFactura);
        }

        public int ModificarFactura(Factura factura, int idFactura)
        {
            return this.Modificar(idFactura, factura);
        }

        public Boolean existeFacturaParaEmpresa(Factura factura)
        {
            String nroFactura = factura.getNumFactura();
            int idEmpresa = factura.getIDEmpresa();

            query = "SELECT COUNT(*) FROM GAME_OF_CODE.Factura WHERE numero_factura = @numero_factura AND id_empresa = @id_empresa";
            parametros.Clear();
            parametros.Add(new SqlParameter("@numero_factura", nroFactura));
            parametros.Add(new SqlParameter("@id_empresa", idEmpresa));
            return ControlDeUnicidad(query, parametros);
        }

        public Boolean ExisteFacturaParaEmpresaYCliente(String nroFactura, int idEmpresa, int idCliente)
        {
            query = "SELECT COUNT(*) FROM GAME_OF_CODE.Factura WHERE numero_factura = @numero_factura AND id_empresa = @id_empresa AND id_cliente = @id_cliente";
            parametros.Clear();
            parametros.Add(new SqlParameter("@numero_factura", nroFactura));
            parametros.Add(new SqlParameter("@id_empresa", idEmpresa));
            parametros.Add(new SqlParameter("@id_cliente", idCliente));
            return ControlDeUnicidad(query, parametros);
        }

        public Boolean SeEncuentraPagaFactura(String nroFactura, int idEmpresa)
        {
            query = "SELECT COUNT(*) FROM GAME_OF_CODE.Factura WHERE numero_factura = @numero_factura AND id_empresa = @id_empresa AND id_pago IS NOT NULL";
            parametros.Clear();
            parametros.Add(new SqlParameter("@numero_factura", nroFactura));
            parametros.Add(new SqlParameter("@id_empresa", idEmpresa));
            return ControlDeUnicidad(query, parametros);
        }

        public Boolean FacturaEstaActiva(String nroFactura, int idEmpresa)
        {
            query = "SELECT COUNT(*) FROM GAME_OF_CODE.Factura WHERE numero_factura = @numero_factura AND id_empresa = @id_empresa AND estado_habilitacion = 1";
            parametros.Clear();
            parametros.Add(new SqlParameter("@numero_factura", nroFactura));
            parametros.Add(new SqlParameter("@id_empresa", idEmpresa));
            return ControlDeUnicidad(query, parametros);
        }

        public int getImporteFactura(String nroFactura, int idEmpresa)
        {
            query = "SELECT monto_total FROM GAME_OF_CODE.Factura WHERE numero_factura = @numero_factura AND id_empresa = @id_empresa";
            parametros.Clear();
            parametros.Add(new SqlParameter("@numero_factura", nroFactura));
            parametros.Add(new SqlParameter("@id_empresa", idEmpresa));
            int importe = (int)QueryBuilder.Instance.build(query, parametros).ExecuteScalar();
            return importe;    
        }

        public DataTable getFactura(String nroFactura, int idEmpresa, int idCliente)
        {
            DataTable facturaDT = SelectDataTable("f.id_factura, f.id_pago, f.numero_factura 'Número factura', f.fecha_alta 'Fecha de alta', f.monto_total 'Monto total', f.fecha_vencimiento 'Fecha de vencimiento', c.mail 'Mail cliente', e.nombre 'Nombre empresa'"
                                                    ,"GAME_OF_CODE.Factura f, GAME_OF_CODE.Cliente c, GAME_OF_CODE.Empresa e"
                                                    , "f.numero_factura = " + nroFactura + " AND e.id_empresa = '" + idEmpresa.ToString() + "' AND c.id_cliente = '" + idCliente.ToString() + "'");
            return facturaDT;
        }

        public void BorrarIDPagoDeLaFactura(int idFactura)
        {
            query = "GAME_OF_CODE.pr_set_id_pago_factura_null";
            parametros.Clear();
            parametros.Add(new SqlParameter("@id_factura", idFactura));
            command = QueryBuilder.Instance.build(query, parametros);
            command.CommandType = CommandType.StoredProcedure;
            command.ExecuteNonQuery();
        }

        public int getIDFacturaParaEmpresa(String nroFactura, int idEmpresa)
        {
            query = "SELECT id_factura FROM GAME_OF_CODE.Factura WHERE numero_factura = @numero_factura AND id_empresa = @id_empresa";
            parametros.Clear();
            parametros.Add(new SqlParameter("@numero_factura", nroFactura));
            parametros.Add(new SqlParameter("@id_empresa", idEmpresa));
            int idFactura = (int)QueryBuilder.Instance.build(query, parametros).ExecuteScalar();
            return idFactura;  
        }

        public Boolean FacturaEstaRendida(int idFactura)
        {
            query = "SELECT COUNT(*) FROM GAME_OF_CODE.Detalle_Rendicion WHERE id_factura = @id_factura";
            parametros.Clear();
            parametros.Add(new SqlParameter("@id_factura", idFactura));
            return ControlDeUnicidad(query, parametros);
        }

        //* Pago de facturas *//
        public int CrearPagoFactura(PagoFactura pagoFactura)
        {
            return this.Crear(pagoFactura);
        }

        public void AgregarACadaFacturaElIDDelPago(PagoFactura pagoFactura, int idPago)
        {
            foreach (Factura factura in pagoFactura.getFacturasAPagar())
            {
                query = "UPDATE GAME_OF_CODE.Factura SET id_pago = @id_pago WHERE numero_factura = @numero_factura AND id_empresa = @id_empresa";
                parametros.Clear();
                parametros.Add(new SqlParameter("@id_pago", idPago));
                parametros.Add(new SqlParameter("@numero_factura", factura.getNumFactura()));
                parametros.Add(new SqlParameter("@id_empresa", factura.getIDEmpresa()));
                QueryBuilder.Instance.build(query, parametros).ExecuteNonQuery();
            }
        }


        //* Medio de pago *//
        public int getIDMedioPago(String descripcion)
        {
            query = "SELECT id_medio_pago FROM GAME_OF_CODE.Medio_de_Pago WHERE descripcion = @descripcion";
            parametros.Clear();
            parametros.Add(new SqlParameter("@descripcion", descripcion));
            int idMedioPago = (int)QueryBuilder.Instance.build(query, parametros).ExecuteScalar();
            return idMedioPago;
        }

        //* Devolucion *//
        public int CrearDevolucion(PagoAgilFrba.Modelo.Devolucion devolucion)
        {
            return this.Crear(devolucion);
        }

        /*
        *
        *   TABLE UNIQUE CONTROL 
        *
        */

        private Boolean ControlDeUnicidad(String query, IList<SqlParameter> parametros)
        {
            int cantidad = (int)QueryBuilder.Instance.build(query, parametros).ExecuteScalar();
            return cantidad > 0;
        }
    }
}
