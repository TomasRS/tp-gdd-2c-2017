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
            for (int i = 0; i < funcionalidadesCheckedListBox.Items.Count; i++)
            {
                funcionalidadesCheckedListBox.SetItemChecked(i, false);
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

            if (!Util.HayAlMenosAlgoSeleccionadoEnListBox(funcionalidadesCheckedListBox))
            {
                Util.ShowMessage("Debe seleccionar al menos una funcionalidad.", MessageBoxIcon.Exclamation);
                return;
            }

            guardarInformacion();
        }

        //Metodos para cargar los datos en la UI
        public override void CargarDatos()
        {
            rol = mapper.ObtenerRol(idRol);

            nombreTextBox.Text = rol.getNombre();
            tildarFuncionalidadesQueTiene(mapper.getFuncionalidadesDelRol(idRol));
        }

        private void tildarFuncionalidadesQueTiene(DataSet funcionalidadesDelRol)
        {
            List<String> funcionalidadesACheckear = funcionalidadesDelRol.Tables[0].AsEnumerable().Select(r=> r.Field<string>("descripcion")).ToList();

            for (int i = 0; i < funcionalidadesCheckedListBox.Items.Count; i++)
            {
                if (funcionalidadesACheckear.Contains(((System.Data.DataRowView)(funcionalidadesCheckedListBox.Items[i])).Row.ItemArray[0].ToString()))
                    funcionalidadesCheckedListBox.SetItemCheckState(i, CheckState.Checked);
            }
        }

        private void checkearFuncionalidadDeLaLista(String unaFuncionalidad)
        {
            int index = funcionalidadesCheckedListBox.Items.IndexOf(unaFuncionalidad);
            funcionalidadesCheckedListBox.SetItemChecked(index, true);
        }

        //Metodo implementado del abstract tanto para crear como modificar
        public override void guardarInformacion()
        {
            if (Util.EsNombreValido(nombreTextBox.Text))
                tipoAccion.trigger(this);
            else
                Util.ShowMessage("El nombre debe ser alfabético.", MessageBoxIcon.Exclamation);
        }

        //Metodo de crear
        public override void Crear()
        {
            String queryRol = "INSERT INTO GAME_OF_CODE.Rol(nombre, estado_habilitacion) VALUES (@rol, 1)";
            String nombreRol = this.nombreTextBox.Text;
            parametros.Clear();
            parametros.Add(new SqlParameter("@rol", nombreRol));
            QueryBuilder.Instance.build(queryRol, parametros).ExecuteNonQuery();

            foreach (DataRowView funcionalidad in funcionalidadesCheckedListBox.CheckedItems)
            {
                parametros.Clear();
                parametros.Add(new SqlParameter("@rol", nombreRol));
                parametros.Add(new SqlParameter("@funcionalidad", funcionalidad.Row["descripcion"] as String));

                String queryRolFuncionalidad = "INSERT INTO GAME_OF_CODE.Funcionalidad_por_Rol(id_funcionalidad, id_rol) VALUES ((SELECT id_funcionalidad FROM GAME_OF_CODE.Funcionalidad WHERE descripcion = @funcionalidad), (SELECT  id_rol FROM GAME_OF_CODE.Rol WHERE nombre = @rol))";

                QueryBuilder.Instance.build(queryRolFuncionalidad, parametros).ExecuteNonQuery();
            }
            Util.ShowMessage("El rol fue creado correctamente.", MessageBoxIcon.Information);
        }

        //Metodos de modificar
        public override void Modificar()
        {
            if (nombreTextBox.Text != "")
            {
                renombrarRol();
                actualizarFuncionalidades();
            }
            else
                Util.ShowMessage("El campo nombre del rol no puede estar vacío.", MessageBoxIcon.Exclamation);

            this.Close();
        }

        private void renombrarRol()
        {
            String nuevoNombreRol = this.nombreTextBox.Text;

            parametros.Clear();
            parametros.Add(new SqlParameter("@id_rol", idRol));
            parametros.Add(new SqlParameter("@nombre_nuevo", nuevoNombreRol));

            String queryUpdateRol = "UPDATE GAME_OF_CODE.Rol SET nombre = @nombre_nuevo WHERE id_rol = " + idRol.ToString();
            int rowsAffected = QueryBuilder.Instance.build(queryUpdateRol, parametros).ExecuteNonQuery();
            if (rowsAffected.Equals(1))
                Util.ShowMessage("El rol fue modificado correctamente.", MessageBoxIcon.Information);
            else
                Util.ShowMessage("No se pudo modificar el rol.", MessageBoxIcon.Error);
        }

        private void actualizarFuncionalidades()
        {
            agregarFuncionalidadesSiCorresponde();
            quitarFuncionalidadesSiCorresponde();
        }

        private void agregarFuncionalidadesSiCorresponde()
        {
            foreach (DataRowView funcionalidad in this.funcionalidadesCheckedListBox.CheckedItems)
            {
                if (verificarSiLaTiene(funcionalidad.Row["descripcion"] as String))
                {

                }
                else
                {
                    parametros.Clear();
                    parametros.Add(new SqlParameter("@rol", mapper.getNombreRol(idRol)));
                    parametros.Add(new SqlParameter("@funcionalidad", funcionalidad.Row["descripcion"] as String));

                    String queryRolXFuncionalidad = "INSERT INTO GAME_OF_CODE.Funcionalidad_por_rol(id_funcionalidad, id_rol) VALUES ((SELECT f.id_funcionalidad FROM GAME_OF_CODE.Funcionalidad f WHERE f.descripcion = @funcionalidad), (SELECT r.id_rol FROM GAME_OF_CODE.Rol r WHERE r.nombre = @rol))";

                    QueryBuilder.Instance.build(queryRolXFuncionalidad, parametros).ExecuteNonQuery();
                }
            }
        }
        private void quitarFuncionalidadesSiCorresponde()
        {
            foreach (DataRowView funcionalidad in this.funcionalidadesCheckedListBox.Items)
            {
                int index = funcionalidadesCheckedListBox.Items.IndexOf(funcionalidad);
                String estado = this.funcionalidadesCheckedListBox.GetItemCheckState(index).ToString();

                if (estado == "Unchecked")
                {
                    parametros.Clear();
                    parametros.Add(new SqlParameter("@rol", mapper.getNombreRol(idRol)));
                    parametros.Add(new SqlParameter("@funcionalidad", funcionalidad.Row["descripcion"] as String));

                    String queryBorrarRolXFuncionalidad = "DELETE GAME_OF_CODE.Funcionalidad_por_Rol WHERE id_funcionalidad = (SELECT f.id_funcionalidad FROM GAME_OF_CODE.Funcionalidad f WHERE f.descripcion = @funcionalidad) AND id_rol = (SELECT r.id_rol FROM GAME_OF_CODE.Rol r WHERE r.nombre = @rol)";

                    QueryBuilder.Instance.build(queryBorrarRolXFuncionalidad, parametros).ExecuteNonQuery();
                }
            }
        }
        private bool verificarSiLaTiene(String funcionalidad)
        {
            parametros.Clear();
            parametros.Add(new SqlParameter("@rol", mapper.getNombreRol(idRol)));
            parametros.Add(new SqlParameter("@funcionalidad", funcionalidad));

            String queryCantidadRolXFuncionalidad = "SELECT COUNT(*) FROM GAME_OF_CODE.Funcionalidad_por_Rol rxf WHERE rxf.id_funcionalidad = (SELECT f.id_funcionalidad FROM GAME_OF_CODE.Funcionalidad f WHERE f.descripcion = @funcionalidad) AND rxf.id_rol = (SELECT r.id_rol FROM GAME_OF_CODE.Rol r WHERE r.nombre = @rol)";
            int tieneLaFuncionalidad = (int)QueryBuilder.Instance.build(queryCantidadRolXFuncionalidad, parametros).ExecuteScalar();
            return tieneLaFuncionalidad.Equals(1);
        }

        //----------------------------------------------------------------------
        private List<string> getDescripcionesListBox()
        {
            List<string> descripciones = new List<string>();
            System.Windows.Forms.ListBox.SelectedObjectCollection coleccion = funcionalidadesCheckedListBox.SelectedItems;
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
            funcionalidadesCheckedListBox.DataSource = funcionalidades.Tables[0].DefaultView;
            funcionalidadesCheckedListBox.ValueMember = "descripcion";
        }
    }
}
