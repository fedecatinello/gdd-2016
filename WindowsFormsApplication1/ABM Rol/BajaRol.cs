using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using MercadoEnvio.DataProvider;

namespace MercadoEnvio.ABM_Rol
{

    public partial class BajaRol : Form
    {
        private SqlCommand command { get; set; }
        private IList<SqlParameter> parametros = new List<SqlParameter>();
        
        public Object SelectedItem { get; set; }        

        public BajaRol()
        {
            InitializeComponent();            
        }

        private void BajaForm_Load(object sender, EventArgs e)
        {
            CargarRoles();
        }

        private void CargarRoles()
        {
            DataSet roles = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            parametros = new List<SqlParameter>();
            command = QueryBuilder.Instance.build("SELECT DISTINCT rol_nombre FROM NET_A_CERO.Roles WHERE rol_activo = 1", parametros);
            adapter.SelectCommand = command;
            adapter.Fill(roles);
            comboBoxRol.DataSource = roles.Tables[0].DefaultView;
            comboBoxRol.ValueMember = "nombre";
            comboBoxRol.SelectedIndex = -1;
        }

        private void botonVolver_Click(object sender, EventArgs e)
        {
            this.Hide();
            new RolForm().ShowDialog();
            this.Close();
        }

        private void botonDeshabilitar_Click(object sender, EventArgs e)
        {
            String rolElegido = this.comboBoxRol.Text;

            parametros.Clear();
            parametros.Add(new SqlParameter("@nombre", rolElegido));

            String sql = "UPDATE NET_A_CERO.Roles SET rol_activo = 0 WHERE rol_nombre = @nombre";

            int filas_afectadas = 0;
                        
            filas_afectadas = QueryBuilder.Instance.build(sql, parametros).ExecuteNonQuery();
            if (filas_afectadas != -1)
            {
                MessageBox.Show("Deshabilitado rol " + rolElegido);
            }
            else
            {
                MessageBox.Show("Error");
            }

            parametros.Clear();
            parametros.Add(new SqlParameter("@nombre", rolElegido));

            // Borramos el rol en los usuarios que lo tienen
            String sql2 = "DELETE NET_A_CERO.Usuarios_x_Rol WHERE rol_id = (SELECT rol_id FROM NET_A_CERO.Roles WHERE rol_nombre = @nombre AND rol_activo = 0)"; 

            filas_afectadas = QueryBuilder.Instance.build(sql2, parametros).ExecuteNonQuery();
            if (filas_afectadas != -1)
            {
                MessageBox.Show("Se quito el rol " + rolElegido + " a " + filas_afectadas + " usuarios porque fue deshabilitado");
            }
            else
            {
                MessageBox.Show("Error");
            }
            CargarRoles();
        }

        private void comboBoxRol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void labelRol_Click(object sender, EventArgs e)
        {

        }
        
    }
}