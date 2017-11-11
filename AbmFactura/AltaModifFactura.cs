using PagoAgilFrba.DataProvider;
using PagoAgilFrba.Excepciones;
using PagoAgilFrba.Menu_Principal;
using PagoAgilFrba.Modelo;
using PagoAgilFrba.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagoAgilFrba.AbmFactura
{
    public partial class AltaModifFactura : AbstractForm
    {
        private DBMapper mapper = new DBMapper();
        private int idFactura;
        private IList<TextBox> campos = new List<TextBox>();
        private TipoDeAccion tipoAccion;
        private Factura factura;
        private DataTable itemsDataTable;
        private List<ItemFactura> itemsFactura;
        private List<ItemFactura> itemsEliminados;
        private List<int> indicesDeAgregados;

        public AltaModifFactura(TipoDeAccion tipoAccion)
        {
            this.tipoAccion = tipoAccion;
            InitializeComponent();
            CenterToScreen();
        }
        public void ShowDialog(String idFacturaAModificar)
        {
            this.idFactura = Convert.ToInt32(idFacturaAModificar);
            this.ShowDialog();
        }
        private void limpiarButton_Click(object sender, EventArgs e)
        {
            clienteComboBox.SelectedIndex = -1;
            nroFacturaTextBox.Clear();
            fechaAltaFactDateTimePicker.Text = "";
            fechaVencDateTimePicker.Text = "";
            empresaComboBox.SelectedIndex = -1;
            itemsDataGridView.Rows.Clear();
            itemsDataGridView.Refresh();
        }
        private void volverButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuPrincipal().ShowDialog();
            this.Close();
        }
        private void DeshabilitarSortHeaders()
        {
            foreach (DataGridViewColumn column in itemsDataGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }


        //------------Implementacion metodos del abstract----------

        public override void setearTituloCreacion()
        {
            this.Text = "Alta de factura";
        }
        public override void setearTituloModificacion()
        {
            this.Text = "Modificación de factura";
            limpiarButton.Visible = false;
            volverButton.Visible = false;
        }

        public override void guardarInformacion()
        {
            String mailCliente = clienteComboBox.Text;
            String empresa = empresaComboBox.Text;
            String numeroFactura = nroFacturaTextBox.Text;
            DateTime fechaAlta;
            DateTime.TryParse(fechaAltaFactDateTimePicker.Text, out fechaAlta);
            DateTime fechaVenc;
            DateTime.TryParse(fechaVencDateTimePicker.Text, out fechaVenc);

            if (!mapper.existeCliente(clienteComboBox.Text))
            {
                Util.ShowMessage("El mail del cliente no existe. Ingrese un mail existente.", MessageBoxIcon.Exclamation);
                return;
            }
            //Crear factura
            #region
            try
            {
                
                factura = new Factura();
                factura.setIDCliente(mapper.getIDCliente(mailCliente));
                factura.setIDEmpresa((int)empresaComboBox.SelectedValue);
                factura.setNumeroFactura(numeroFactura);
                factura.setMontoTotal(calcularMontoTotal());
                factura.setFechaAltaFactura(fechaAlta);
                factura.setFechaVencimientoFactura(fechaVenc);


                if (itemsFactura.Count.Equals(0))
                {
                    Util.ShowMessage("Debe añadir al menos un item factura en el listado de items.", MessageBoxIcon.Exclamation);
                    return;
                }

                tipoAccion.trigger(this);
            }
            catch (FechaFuturaException e)
            {
                Util.ShowMessage(e.Message, MessageBoxIcon.Error);
                return;
            }
            catch (FechaPasadaException)
            {
                Util.ShowMessage("La fecha de alta no puede ser una fecha futura.", MessageBoxIcon.Error);
                return;
            }
            catch (FormatoInvalidoException e)
            {
                Util.ShowMessage("Datos mal ingresados en: " + e.Message, MessageBoxIcon.Error);
                return;
            }
            catch (YaExisteNumeroFacturaParaEmpresa)
            {
                Util.ShowMessage("Ya existe una factura con número " + numeroFactura + " para la empresa \"" + empresa + "\".", MessageBoxIcon.Error);
                return;
            }
            #endregion
        }

        public override void CargarDatos()
        {
            Factura factura = mapper.ObtenerFactura(idFactura);

            clienteComboBox.Text = mapper.getMailCliente(factura.getIDCliente());
            empresaComboBox.Text = mapper.getNombreEmpresa(factura.getIDEmpresa());
            nroFacturaTextBox.Text = factura.getNumFactura();
            fechaAltaFactDateTimePicker.Text = factura.getFechaAlta().ToString();
            fechaVencDateTimePicker.Text = factura.getFechaVenc().ToString();

            popularItems();
        }

        private void popularItems()
        {
            itemsDataTable = mapper.SelectItemsFactura(idFactura);
            itemsDataGridView.Columns.Clear();
            itemsDataGridView.DataSource = null;
            itemsDataGridView.DataSource = itemsDataTable;
        }

        public override void Crear()
        {
            idFactura = mapper.CrearFactura(factura);
            if (idFactura > 0)
            {
                itemsFactura = armarListaItemsFactura();
                factura.setItemsFactura(itemsFactura);
                itemsFactura.ForEach(unItemFactura => crearItemFactura(unItemFactura));
                Util.ShowMessage("Factura guardada correctamente.", MessageBoxIcon.Information);
                limpiarButton_Click(this, null);
            }   
        }

        public void crearItemFactura(ItemFactura item)
        {
            item.setIDFactura(idFactura);
            mapper.CrearDetalleFactura(item, idFactura);
        }

        public override void Modificar()
        {
            idFactura = mapper.ModificarFactura(factura, idFactura);
            if (idFactura > 0)
            {
                itemsFactura.ForEach(unItemFactura => editar(unItemFactura));
                itemsEliminados.ForEach(unEliminado => eliminar(unEliminado));
                indicesDeAgregados.ForEach(unIndice => agregarItemFacturaDeIndice(unIndice));
                Util.ShowMessage("Factura guardada correctamente.", MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void editar(ItemFactura itemFactura)
        {
            //mapper.Modificar(itemFactura.getIDItem(), itemFactura);
        }

        private void eliminar(ItemFactura itemFactura)
        {
            //
        }

        private void agregarItemFacturaDeIndice(int indice)
        {
            //
        }

        //--------------------Extras-------------------------------------
        private void AltaModifFactura_Load(object sender, EventArgs e)
        {
            campos.Add(nroFacturaTextBox);

            CargarClientes();
            CargarEmpresas();
            CargarColumnasItems();
            DeshabilitarSortHeaders();
            tipoAccion.cargarDatosSiCorresponde(this);
            tipoAccion.setearTituloVentana(this);
        }

        private void CargarClientes()
        {
            string query = "SELECT id_cliente, mail from GAME_OF_CODE.Cliente";

            SqlCommand cmd = new SqlCommand(query, ConnectionManager.Instance.getConnection());

            SqlDataAdapter data_adapter = new SqlDataAdapter(cmd);
            DataTable clientes = new DataTable();
            data_adapter.Fill(clientes);

            clienteComboBox.ValueMember = "id_cliente";
            clienteComboBox.DisplayMember = "mail";
            clienteComboBox.DataSource = clientes;
            clienteComboBox.SelectedIndex = 0;
        }

        private void CargarEmpresas()
        {
            string query = "SELECT id_empresa, nombre from GAME_OF_CODE.Empresa";

            SqlCommand cmd = new SqlCommand(query, ConnectionManager.Instance.getConnection());

            SqlDataAdapter data_adapter = new SqlDataAdapter(cmd);
            DataTable rubros = new DataTable();
            data_adapter.Fill(rubros);

            empresaComboBox.ValueMember = "id_empresa";
            empresaComboBox.DisplayMember = "nombre";
            empresaComboBox.DataSource = rubros;
            empresaComboBox.SelectedIndex = 0;
        }
        private void CargarColumnasItems()
        {
            itemsDataGridView.Columns.Add("item_factura", "Item factura");
            itemsDataGridView.Columns.Add("cantidad", "Cantidad");
            itemsDataGridView.Columns.Add("item_monto", "Importe");
        }

        private void guardarButton_Click(object sender, EventArgs e)
        {
            if (!Util.CamposEstanLlenos(campos))
            {
                Util.ShowMessage("Todos los campos son obligatorios.", MessageBoxIcon.Exclamation);
                return;
            }

            tipoAccion.accion(this);
        }

        private List<ItemFactura> armarListaItemsFactura()
        {
            List<ItemFactura> items = new List<ItemFactura>();

            for (int i = 0; i < itemsDataTable.Rows.Count - 1; i++)
            {
                if (camposDeItemLlenos(itemsDataTable.Rows[i]))
                {
                    ItemFactura item = new ItemFactura();
                    item.setDescripcion(itemsDataTable.Rows[i][0].ToString());
                    item.setCantidad(itemsDataTable.Rows[i][1].ToString());
                    item.setImporte(itemsDataTable.Rows[i][2].ToString());
                    item.setIDFactura(idFactura);
                    items.Add(item);
                }
                else
                    throw new FormatoInvalidoException("listado de items. No puede haber ningún dato vacío.");
            }

            return items;
        }

        private Boolean camposDeItemLlenos(DataRow row)
        {
            return row[0].ToString() != "" && row[1].ToString() != "" && row[2].ToString() != "";
        }

        private int calcularMontoTotal()
        {
            int montoFinal = 0;
            for (int i = 0; i < itemsDataTable.Rows.Count - 1; i++)
            {
                //MontoFinal es la suma de los importes de cada item (el importe ya es el total para ese item)
                montoFinal += Util.getNumeroFromString(itemsDataTable.Rows[i][2].ToString());
            }
            return montoFinal;
        }

        private void agregarItemButton_Click(object sender, EventArgs e)
        {
            if (itemsDataTable.Rows.Count.Equals(0))
            {
                itemsDataTable.Rows.Add();
                //Agregar a la lista de agregados
                return;
            }

            int indexUltimaRow = itemsDataTable.Rows.Count-1;
            if (!camposDeItemLlenos(itemsDataTable.Rows[indexUltimaRow]))
            {
                Util.ShowMessage("Primero complete todos los datos del último item de la lista.", MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                itemsDataTable.Rows.Add();
                //agregar a la lista de agregados
            }
        }

        private void borrarSeleccionadosButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in itemsDataGridView.SelectedRows)
            {
                int indexRow = row.Index;
                itemsDataTable.Rows.RemoveAt(indexRow);
                //Agregar a la lista de eliminados
            }
        }
    }
}
