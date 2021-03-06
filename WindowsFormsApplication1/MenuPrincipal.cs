﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using MercadoEnvio.DataProvider;

namespace MercadoEnvio
{
    public partial class MenuPrincipal : Form
    {
        private SqlCommand command { get; set; }
        private Dictionary<String, Form> funcionalidades = new Dictionary<String, Form>();
     
        public MenuPrincipal()
        {
            InitializeComponent();

            funcionalidades.Add("Comprar/Ofertar", new Comprar_Ofertar.BuscadorPublicaciones());
            funcionalidades.Add("Generar Publicacion", new Generar_Publicacion.GenerarPublicacion());
            funcionalidades.Add("Editar Publicacion", new Editar_Publicacion.FiltrarPublicacion());
            funcionalidades.Add("Calificar Vendedor", new Calificar_Vendedor.Listado());
            funcionalidades.Add("ABM Rol", new ABM_Rol.RolForm());
            funcionalidades.Add("Crear Empresa", new ABM_Empresa.AgregarEmpresa("empresaCreadaPorAdmin", "OK"));
            funcionalidades.Add("Editar Empresa", new ABM_Empresa.FiltroEmpresa());
            funcionalidades.Add("Crear Cliente", new ABM_Cliente.AgregarCliente("clienteCreadoPorAdmin", "OK"));
            funcionalidades.Add("Editar Cliente", new ABM_Cliente.FiltroCliente());
            funcionalidades.Add("Agregar Visibilidad", new ABM_Visibilidad.AgregarVisibilidad());
            funcionalidades.Add("Editar Visibilidad", new ABM_Visibilidad.FiltroVisibilidad());
            funcionalidades.Add("Consulta de facturas", new Consulta_Facturas_Vendedor.ListadoFacturas()); 
            funcionalidades.Add("Listado Estadistico", new Listado_Estadistico.Estadisticas());
            funcionalidades.Add("Ver Historial", new Historial_Cliente.Historial());
            funcionalidades.Add("Cambiar Contraseña", new Login.CambiarContrasena());
                         
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            DataSet actions = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            
            String funcionalidadesUsuario = "select f.func_nombre from NET_A_CERO.Roles r, NET_A_CERO.Rol_x_Funcionalidad fr, NET_A_CERO.Funcionalidades f where r.rol_id = fr.rol_id and f.func_id = fr.func_id and r.rol_nombre = @rol";
            IList<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@rol", UsuarioSesion.Usuario.rol));
            command = QueryBuilder.Instance.build(funcionalidadesUsuario, parametros);

            adapter.SelectCommand = command;
            adapter.Fill(actions, "Funcionalidades");
            comboBoxAccion.DataSource = actions.Tables[0].DefaultView;
            comboBoxAccion.ValueMember = "func_nombre";

        }

        private void botonAceptar_Click(object sender, EventArgs e)
        {
            String accionElegida = comboBoxAccion.SelectedValue.ToString();
            
            this.Hide();
            funcionalidades[accionElegida].ShowDialog();
            this.Close();
          
        }

        private void botonCerrarSesion_Click(object sender, EventArgs e)
        {
            // Relleno la sesion con datos inexistentes para que no queden datos cacheados de un usuario del sistema
            UsuarioSesion.Usuario.id = 0;
            UsuarioSesion.Usuario.nombre = null;
            UsuarioSesion.Usuario.rol = null;

            // Redirect al Login
            this.Hide();
            new Login.LoginForm().ShowDialog();
            this.Close();

        }
    }
}