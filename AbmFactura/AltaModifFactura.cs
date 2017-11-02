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

        public AltaModifFactura(TipoDeAccion tipoAccion)
        {
            this.tipoAccion = tipoAccion;
            InitializeComponent();
            CenterToScreen();
        }
        private void limpiarButton_Click(object sender, EventArgs e)
        {
            clienteTextBox.Clear();
            nroFacturaTextBox.Clear();
            fechaAltaFactDateTimePicker.Text = "";
            fechaVencDateTimePicker.Text = "";
            empresaComboBox.SelectedIndex = -1;
            itemsDataGridView.Rows.Clear();
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
        }

        public override void guardarInformacion()
        {
            String mailCliente = clienteTextBox.Text;
            String empresa = empresaComboBox.Text;
            String numeroFactura = nroFacturaTextBox.Text;
            DateTime fechaAlta;
            DateTime.TryParse(fechaAltaFactDateTimePicker.Text, out fechaAlta);
            DateTime fechaVenc;
            DateTime.TryParse(fechaVencDateTimePicker.Text, out fechaVenc);
            //Pasar la tabla de items a una List<ItemFactura> o algo asi

            //Crear factura
            #region
            try
            {
                factura = new Factura();
                factura.setIDCliente(mapper.getIDCliente(mailCliente));
                factura.setIDEmpresa((int)empresaComboBox.SelectedValue);
                factura.setNumeroFactura(numeroFactura);
                factura.setFechaAltaFactura(fechaAlta);
                factura.setFechaVencimientoFactura(fechaVenc);
                //Agregar a la factura los items que tengo en la lista comentada de arriba

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
                Util.ShowMessage("Ya existe una factura con número " + numeroFactura + "para la empresa " + empresa, MessageBoxIcon.Error);
                return;
            }
            #endregion
        }

        public override void CargarDatos()
        {
            throw new NotImplementedException();
        }

        public override void Crear()
        {
            idFactura = mapper.CrearFactura(factura);
            if (idFactura > 0)
                Util.ShowMessage("Factura guardada correctamente.", MessageBoxIcon.Information);
        }

        public override void Modificar()
        {
            //idFactura = mapper.ModificarFactura(factura, idFactura);
            if (idFactura > 0)
            {
                Util.ShowMessage("Factura guardada correctamente.", MessageBoxIcon.Information);
                this.Close();
            }
        }


        //--------------------Extras-------------------------------------
        private void AltaModifFactura_Load(object sender, EventArgs e)
        {
            campos.Add(clienteTextBox);
            campos.Add(nroFacturaTextBox);

            CargarEmpresas();
            CargarColumnasItems();
            DeshabilitarSortHeaders();
            tipoAccion.cargarDatosSiCorresponde(this);
            tipoAccion.setearTituloVentana(this);
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
            itemsDataGridView.Columns.Add("monto_unitario", "Monto unitario");
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
    }
}
