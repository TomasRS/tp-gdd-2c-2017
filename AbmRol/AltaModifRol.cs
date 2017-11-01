using PagoAgilFrba.DataProvider;
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

namespace PagoAgilFrba.AbmRol
{
    public partial class AltaModifRol : AbstractForm
    {
        private IList<TextBox> campos = new List<TextBox>();
        private TipoDeAccion tipoAccion;
        private SqlCommand command { get; set; }
        private DBMapper mapper = new DBMapper();
        private IList<SqlParameter> parametros = new List<SqlParameter>();
        private int idRol;
        private Rol rol;

        public AltaModifRol(TipoDeAccion tipoAccion)
        {
            this.tipoAccion = tipoAccion;
            InitializeComponent();
            CenterToScreen();
        }
        public void ShowDialog(String idRolAModificar)
        {
            this.idRol = Convert.ToInt32(idRolAModificar);
            this.ShowDialog();
        }
        private void limpiarButton_Click(object sender, EventArgs e)
        {
            nombreTextBox.Clear();
            limpiarFuncionalidades();
        }
        private void limpiarFuncionalidades()
        {
            for (int i = 0; i < funcionalidadesListBox.Items.Count; i++)
            {
                funcionalidadesListBox.SetItemChecked(i, false);
            }
        }

        private void volverButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuPrincipal().ShowDialog();
            this.Close();
        }

        private void actualizarButton_Click(object sender, EventArgs e)
        {
            if (!Util.CamposEstanLlenos(campos))
            {
                Util.ShowMessage("Debe completar el campo nombre.", MessageBoxIcon.Exclamation);
                return;
            }

            if (!Util.HayAlMenosAlgoSeleccionadoEnListBox(funcionalidadesListBox))
            {
                Util.ShowMessage("Debe seleccionar al menos una funcionalidad.", MessageBoxIcon.Exclamation);
                return;
            }

            guardarInformacion();
        }

        public override void CargarDatos()
        {
            rol = mapper.ObtenerRol(idRol);

            nombreTextBox.Text = rol.getNombre();
            tildarFuncionalidadesQueTiene(mapper.getFuncionalidadesDelRol(idRol));
        }

        private void tildarFuncionalidadesQueTiene(DataSet funcionalidadesDelRol)
        {
            CheckedListBox funcionalidadesDelRolListBox = new CheckedListBox();
            funcionalidadesDelRolListBox.DataSource = funcionalidadesDelRol.Tables[0].DefaultView;
            funcionalidadesDelRolListBox.ValueMember = "descripcion";

            foreach (var item in funcionalidadesDelRolListBox.Items)
            {
                var row = (item as DataRowView).Row;
                checkearFuncionalidadDeLaLista(row["descripcion"].ToString());
            }
        }

        private void checkearFuncionalidadDeLaLista(String descripcion)
        {
            int index = funcionalidadesListBox.Items.IndexOf(descripcion);
            funcionalidadesListBox.SetItemCheckState(index, CheckState.Checked);
        }

        public override void guardarInformacion()
        {
            if (Util.EsNombreValido(nombreTextBox.Text))
                tipoAccion.trigger(this);
            else
                Util.ShowMessage("El nombre debe ser alfabético.", MessageBoxIcon.Exclamation);
        }

        public override void Crear()
        {
            String queryRol = "INSERT INTO GAME_OF_CODE.Rol(nombre, estado_habilitacion) VALUES (@rol, 1)";
            String nombreRol = this.nombreTextBox.Text;
            parametros.Clear();
            parametros.Add(new SqlParameter("@rol", nombreRol));
            QueryBuilder.Instance.build(queryRol, parametros).ExecuteNonQuery();

            foreach (DataRowView funcionalidad in funcionalidadesListBox.CheckedItems)
            {
                parametros.Clear();
                parametros.Add(new SqlParameter("@rol", nombreRol));
                parametros.Add(new SqlParameter("@funcionalidad", funcionalidad.Row["descripcion"] as String));

                String queryRolFuncionalidad = "INSERT INTO GAME_OF_CODE.Funcionalidad_por_Rol(id_funcionalidad, id_rol) VALUES ((SELECT id_funcionalidad FROM GAME_OF_CODE.Funcionalidad WHERE descripcion = @funcionalidad), (SELECT  id_rol FROM GAME_OF_CODE.Rol WHERE nombre = @rol))";

                QueryBuilder.Instance.build(queryRolFuncionalidad, parametros).ExecuteNonQuery();
            }
            Util.ShowMessage("El rol fue creado correctamente.", MessageBoxIcon.Information);
        }

        public override void Modificar()
        {
            //Implementar
        }

        private List<string> getDescripcionesListBox()
        {
            List<string> descripciones = new List<string>();
            System.Windows.Forms.ListBox.SelectedObjectCollection coleccion = funcionalidadesListBox.SelectedItems;
            foreach (Object objeto in coleccion)
            {
                descripciones.Add(objeto.ToString());
            }

            return descripciones;
        }

        public override void setearTituloCreacion()
        {
            this.Text = "Alta de rol";
        }
        public override void setearTituloModificacion()
        {
            this.Text = "Modificación de rol";
        }

        private void AltaModifRol_Load(object sender, EventArgs e)
        {
            campos.Add(nombreTextBox);

            CargarFuncionalidades();
            tipoAccion.cargarDatosSiCorresponde(this);
            tipoAccion.setearTituloVentana(this);
        }

        public void CargarFuncionalidades()
        {
            DataSet funcionalidades = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            parametros = new List<SqlParameter>();
            command = QueryBuilder.Instance.build("SELECT DISTINCT descripcion FROM GAME_OF_CODE.Funcionalidad", parametros);
            adapter.SelectCommand = command;
            adapter.Fill(funcionalidades);
            funcionalidadesListBox.DataSource = funcionalidades.Tables[0].DefaultView;
            funcionalidadesListBox.ValueMember = "descripcion";
        }
    }
}
