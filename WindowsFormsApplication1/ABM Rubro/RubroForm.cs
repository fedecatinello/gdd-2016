using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using MercadoEnvio.DataProvider;

namespace MercadoEnvio.ABM_Rubro
{
    public partial class RubroForm : Form
    {
        //private String query;
        //private SqlCommand command;
        //private IList<SqlParameter> parametros = new List<SqlParameter>();

        public RubroForm()
        {
            InitializeComponent();
            groupBox1.Visible = false;
            label1.Visible = false;
            textBox_Descripcion.Visible = false;
            button_Buscar.Visible = false;
            button_Limpiar.Visible = false;
            button_Cancelar.Visible = false;
            dataGridView_Rubro.Visible = false;
        }

        
        private void RubroForm_Load(object sender, EventArgs e)
        {
            //CargarRubro();
            //AgregarColumnaDeModificacion();
           // AgregarListenerBotonDeModificacion();
        }
        /*----------------NO HAY QUE IMPLEMENTARLO---------------------
        private void CargarRubro()
        {
            command = QueryBuilder.Instance.build("SELECT * FROM Rubro", parametros);

            DataSet rubros = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(rubros);
            dataGridView_Rubro.DataSource = rubros.Tables[0].DefaultView;
        }

        private void AgregarColumnaDeModificacion()
        {
            DataGridViewButtonColumn botonColumnaModificar = new DataGridViewButtonColumn();
            botonColumnaModificar.Text = "modificar";
            botonColumnaModificar.Name = "modificar";
            botonColumnaModificar.UseColumnTextForButtonValue = true;
            dataGridView_Rubro.Columns.Add(botonColumnaModificar);
        }

        private void AgregarListenerBotonDeModificacion()
        {
            // Add a CellClick handler to handle clicks in the button column.
            dataGridView_Rubro.CellClick +=
                new DataGridViewCellEventHandler(dataGridView_Rubro_CellClick);
        }

        private void dataGridView_Rubro_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Controla que la celda que se clickeo fue la de modificar
            if (e.ColumnIndex == dataGridView_Rubro.Columns["modificar"].Index && e.RowIndex >= 0)
            {
                String idRubroAModificiar = dataGridView_Rubro.Rows[e.RowIndex].Cells["id"].Value.ToString();
                new EditarRubro(idRubroAModificiar).ShowDialog();
            }
        }
        */
        private void button_Buscar_Click(object sender, EventArgs e)
        {
            /*
            String filtro = "";

            if (textBox_Descripcion.Text != "") filtro += "descripcion like '" + textBox_Descripcion.Text + "%'";

            query = "SELECT * FROM Rubro WHERE " + filtro;

            command = QueryBuilder.Instance.build(query, parametros);

            DataSet rubros = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(rubros);
            dataGridView_Rubro.DataSource = rubros.Tables[0].DefaultView;
             */
        }

        private void button_Limpiar_Click(object sender, EventArgs e)
        {
            /*
            textBox_Descripcion.Text = "";
            CargarRubro();
             */
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new MenuPrincipal().ShowDialog();
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}