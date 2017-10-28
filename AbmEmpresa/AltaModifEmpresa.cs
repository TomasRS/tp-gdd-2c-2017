﻿using PagoAgilFrba.DataProvider;
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

namespace PagoAgilFrba.AbmEmpresa
{
    public partial class AltaModifEmpresa : AbstractForm
    {
        private DBMapper mapper = new DBMapper();
        private int idEmpresa;
        private IList<TextBox> campos = new List<TextBox>();
        private TipoDeAccion tipoAccion;

        public AltaModifEmpresa(TipoDeAccion tipoAccion)
        {
            this.tipoAccion = tipoAccion;
            InitializeComponent();
            CenterToScreen();
        }

        private void limpiarButton_Click(object sender, EventArgs e)
        {
            nombreTextBox.Clear();
            cuitTextBox.Clear();
            direccionTextBox.Clear();
        }

        private void volverButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuPrincipal().ShowDialog();
            this.Close();
        }

        public override void darDeAlta()
        {
            guardarInformacion("crear");
        }

        public override void guardarModificacion()
        {
            guardarInformacion("modificar");
        }

        private void guardarInformacion(String accion)
        {
            //Completar logica
            String nombre = nombreTextBox.Text;
            String cuit = cuitTextBox.Text;
            String direccion = direccionTextBox.Text;
            String rubro = rubroComboBox.Text;

            //Crear empresa
            #region
            try
            {
                Empresa empresa = new Empresa();
                empresa.setNombre(nombre);
                empresa.setCuit(cuit);
                empresa.setDireccion(direccion);
                empresa.setIDRubro(mapper.getIDRubro(rubro));

                if (accion.Equals("crear"))
                    idEmpresa = mapper.CrearEmpresa(empresa);
                else if (accion.Equals("modificar"))
                    idEmpresa = mapper.ModificarEmpresa(empresa, idEmpresa);

                if (idEmpresa > 0)
                    Util.ShowMessage("Empresa guardada correctamente.", MessageBoxIcon.Information);

                if (accion.Equals("modificar"))
                    this.Close();
            }
            catch (CuitYaExisteException)
            {
                Util.ShowMessage("Ya existe una empresa con ese cuit.", MessageBoxIcon.Error);
                return;
            }
            #endregion
        }

        private void CargarRubros()
        {
            string query = "SELECT id_rubro, descripcion from GAME_OF_CODE.Rubro";

            SqlCommand cmd = new SqlCommand(query, ConnectionManager.Instance.getConnection());

            SqlDataAdapter data_adapter = new SqlDataAdapter(cmd);
            DataTable rubros = new DataTable();
            data_adapter.Fill(rubros);

            rubroComboBox.ValueMember = "id_rubro";
            rubroComboBox.DisplayMember = "descripcion";
            rubroComboBox.DataSource = rubros;
            rubroComboBox.SelectedIndex = 0;
        }

        private void guardarButton_Click(object sender, EventArgs e)
        {
            if (!Util.CamposEstanLlenos(campos))
            {
                Util.ShowMessage("Todos los campos son obligatorios", MessageBoxIcon.Exclamation);
                return;
            }

            tipoAccion.accion(this);
        }

        private void AltaModifEmpresa_Load(object sender, EventArgs e)
        {
            campos.Add(nombreTextBox);
            campos.Add(cuitTextBox);
            campos.Add(direccionTextBox);

            CargarRubros();
            tipoAccion.cargarDatosSiCorresponde(this);
        }
    }
}
