using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using System.Security;
using System.Security.Cryptography;
using System.Configuration;
using System.Text;

public partial class Grupos : System.Web.UI.Page
{
    #region Variables Globales
    string conexion = ConfigurationManager.ConnectionStrings["conBD"].ConnectionString;
    string idgpoid;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        cargargrupos();
        cargargpomaestros();
        cargargpoalumnos();

        if (Convert.ToInt32(ddlNivelesCurso.Items.Count.ToString()) == 0)
        {
            cargarddlniveles();
        }

        if (Convert.ToInt32(ddlSucursalCarga.Items.Count.ToString()) == 0)
        {
            cargarddlsucursales();
        }

        if (Convert.ToInt32(ddlgpoa.Items.Count.ToString()) == 0)
        {
            cargarddlgposa();
        }

        if (Convert.ToInt32(ddlgpom.Items.Count.ToString()) == 0)
        {
            cargarddlgposm();
        }
    }

    #region Cargar niveles y Sucursales
    protected void cargarddlniveles()
    {
        string procedurebsuc = "spBuscarNivel";
        MySqlConnection conn = new MySqlConnection(conexion);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand(procedurebsuc, conn);
        cmd.CommandType = CommandType.StoredProcedure;
        MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adaptador.Fill(dt);
        ddlNivelesCurso.DataValueField = "Clave_de_Nivel";
        ddlNivelesCurso.DataTextField = "Clave_de_Nivel";
        ddlNivelesCurso.DataSource = dt;
        ddlNivelesCurso.DataBind();
        conn.Close();
    }

    protected void cargarddlsucursales()
    {
        string procedurebsuc = "spBuscarSucursal";
        MySqlConnection conn = new MySqlConnection(conexion);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand(procedurebsuc, conn);
        cmd.CommandType = CommandType.StoredProcedure;
        MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adaptador.Fill(dt);
        ddlSucursalCarga.DataValueField = "idSucursal";
        ddlSucursalCarga.DataTextField = "Nombre_Sucursal";
        ddlSucursalCarga.DataSource = dt;
        ddlSucursalCarga.DataBind();
        conn.Close();
    }
    #endregion

    #region Grupo

    protected void cargargrupos()
    {
        string procedurebsuc = "spBuscarGrupo";
        MySqlConnection conn = new MySqlConnection(conexion);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand(procedurebsuc, conn);
        cmd.CommandType = CommandType.StoredProcedure;
        MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adaptador.Fill(dt);
        dgvGpo.DataSource = dt;
        dgvGpo.DataBind();
        conn.Close();
    }

    protected void insertargrupo()
    {
        string procedureinsuc = "spInsertarGrupo";
        MySqlConnection conn = new MySqlConnection(conexion);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand(procedureinsuc, conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("_ClaveGpo", txtApodoGpo.Text);
        cmd.Parameters["_ClaveGpo"].Direction = ParameterDirection.Input;
        cmd.Parameters.AddWithValue("_idSuc", ddlSucursalCarga.SelectedValue);
        cmd.Parameters["_idSuc"].Direction = ParameterDirection.Input;
        cmd.Parameters.AddWithValue("_claveNiv", ddlNivelesCurso.SelectedValue);
        cmd.Parameters["_claveNiv"].Direction = ParameterDirection.Input;
        cmd.ExecuteNonQuery();
        MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
        conn.Close();
    }

    protected void buscargrupo()
    {
        string procedureinsuc = "spBuscarGrupoClave";
        MySqlConnection conn = new MySqlConnection(conexion);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand(procedureinsuc, conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("_clave", txtApodoGpo.Text);
        cmd.Parameters["_clave"].Direction = ParameterDirection.Input;
        cmd.ExecuteNonQuery();
        MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adaptador.Fill(dt);
        dgvGpo.DataSource = dt;
        dgvGpo.DataBind();
        if (dt.Rows.Count < 1)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('La busqueda no obtuvo ni un resultado')", true);
            cargargrupos();
        }
        else
        {
            {
                ViewState["idgpoid"] = dt.Rows[0][0].ToString();

                //Este procedure carga los dos ddl segun la busqueda del gpo
                string procedurecursoddl = "spCargarSucursalNivel";
                MySqlCommand cmd2 = new MySqlCommand(procedurecursoddl, conn);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("_id", ViewState["idgpoid"]);
                cmd2.Parameters["_id"].Direction = ParameterDirection.Input;
                cmd2.ExecuteNonQuery();
                MySqlDataAdapter adaptador2 = new MySqlDataAdapter(cmd2);
                DataTable dt2 = new DataTable();
                adaptador2.Fill(dt2);

                ddlSucursalCarga.SelectedValue = dt2.Rows[0][0].ToString();
                ddlNivelesCurso.SelectedValue = dt2.Rows[0][1].ToString();

                txtApodoGpo.Text = dt.Rows[0][1].ToString();
            }
        }
        conn.Close();
    }

    protected void modificargrupo()
    {
        string procedureinsuc = "spModificarGrupo";
        MySqlConnection conn = new MySqlConnection(conexion);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand(procedureinsuc, conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("_idGrupo", idgpoid);
        cmd.Parameters["_idGrupo"].Direction = ParameterDirection.Input;
        cmd.Parameters.AddWithValue("_claveGpo", txtApodoGpo.Text);
        cmd.Parameters["_claveGpo"].Direction = ParameterDirection.Input;
        cmd.Parameters.AddWithValue("_idSuc", ddlSucursalCarga.SelectedValue);
        cmd.Parameters["_idSuc"].Direction = ParameterDirection.Input;
        cmd.Parameters.AddWithValue("_ClaveNiv", ddlNivelesCurso.SelectedValue);
        cmd.Parameters["_ClaveNiv"].Direction = ParameterDirection.Input;
        cmd.ExecuteNonQuery();
        MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
        conn.Close();
    }

    #endregion

    #region Grupo alumnos
    protected void cargarddlgposa()
    {
        string procedurebsuc = "spBuscarGrupo";
        MySqlConnection conn = new MySqlConnection(conexion);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand(procedurebsuc, conn);
        cmd.CommandType = CommandType.StoredProcedure;
        MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adaptador.Fill(dt);
        ddlgpoa.DataValueField = "IDGRUPO";
        ddlgpoa.DataTextField = "Clave_Grupo";
        ddlgpoa.DataSource = dt;
        ddlgpoa.DataBind();
        conn.Close();
    }

    protected void insertargrupoalumno()
    {
        string procedureinsuc = "spInsertarAlumnoGrupo";
        MySqlConnection conn = new MySqlConnection(conexion);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand(procedureinsuc, conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("_usuario", txtgpouser.Text);
        cmd.Parameters["_usuario"].Direction = ParameterDirection.Input;
        cmd.Parameters.AddWithValue("_idGpo", ddlgpoa.SelectedValue);
        cmd.Parameters["_idGpo"].Direction = ParameterDirection.Input;
        cmd.Parameters.AddWithValue("_activo", ddlactividadalumno.SelectedIndex);
        cmd.Parameters["_activo"].Direction = ParameterDirection.Input;
        cmd.ExecuteNonQuery();
        MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
        conn.Close();
    }

    protected void buscargrupoalumno()
    {
        string procedureinsuc = "spBuscarAlumnoGrupo";
        MySqlConnection conn = new MySqlConnection(conexion);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand(procedureinsuc, conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("_usuario", txtgpouser.Text);
        cmd.Parameters["_usuario"].Direction = ParameterDirection.Input;
        cmd.Parameters.AddWithValue("_idGrupo", ddlgpoa.SelectedValue);
        cmd.Parameters["_idGrupo"].Direction = ParameterDirection.Input;
        cmd.ExecuteNonQuery();
        MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adaptador.Fill(dt);
        dgvgpoa.DataSource = dt;
        dgvgpoa.DataBind();
        if (dt.Rows.Count <= 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('La busqueda no obtuvo ni un resultado')", true);
            cargargpoalumnos();
        }
        conn.Close();
    }

    protected void modificargrupoalumno()
    {
        string procedureinsuc = "spModificarAlumnoGrupo";
        MySqlConnection conn = new MySqlConnection(conexion);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand(procedureinsuc, conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("_activo", ddlactividadalumno.SelectedValue);
        cmd.Parameters["_activo"].Direction = ParameterDirection.Input;
        cmd.Parameters.AddWithValue("_usuario", txtgpouser.Text);
        cmd.Parameters["_usuario"].Direction = ParameterDirection.Input;
        cmd.Parameters.AddWithValue("_idGrupo", ddlgpoa.SelectedValue);
        cmd.Parameters["_idGrupo"].Direction = ParameterDirection.Input;
        cmd.ExecuteNonQuery();
        MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
        conn.Close();
    }

    private void cargargpoalumnos()
    {
        string procedurecu = "spCargarAlumnoGpo";
        MySqlConnection conn = new MySqlConnection(conexion);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand(procedurecu, conn);
        cmd.CommandType = CommandType.StoredProcedure;
        MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adaptador.Fill(dt);
        dgvgpoa.DataSource = dt;
        dgvgpoa.DataBind();
        conn.Close();
    }

    protected void cargarddlgposm()
    {
        string procedurebsuc = "spBuscarGrupo";
        MySqlConnection conn = new MySqlConnection(conexion);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand(procedurebsuc, conn);
        cmd.CommandType = CommandType.StoredProcedure;
        MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adaptador.Fill(dt);
        ddlgpom.DataValueField = "IDGRUPO";
        ddlgpom.DataTextField = "Clave_Grupo";
        ddlgpom.DataSource = dt;
        ddlgpom.DataBind();
        conn.Close();
    }

   private void cargargpomaestros()
    {
        string procedurecu = "spCargarMaestroGpo";
        MySqlConnection conn = new MySqlConnection(conexion);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand(procedurecu, conn);
        cmd.CommandType = CommandType.StoredProcedure;
        MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adaptador.Fill(dt);
        dgvgpom.DataSource = dt;
        dgvgpom.DataBind();
        conn.Close();
    }

    protected void insertargrupomaestro()
    {
        string procedureinsuc = "spInsertarMaestroGrupo";
        MySqlConnection conn = new MySqlConnection(conexion);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand(procedureinsuc, conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("_usuario", txtgpousrm.Text);
        cmd.Parameters["_usuario"].Direction = ParameterDirection.Input;
        cmd.Parameters.AddWithValue("_idGpo", ddlgpom.SelectedValue);
        cmd.Parameters["_idGpo"].Direction = ParameterDirection.Input;
        cmd.Parameters.AddWithValue("_activo", ddlactividadmaestro.SelectedIndex);
        cmd.Parameters["_activo"].Direction = ParameterDirection.Input;
        cmd.ExecuteNonQuery();
        MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
        conn.Close();
    }

    protected void buscargrupomaestro()
    {
        string procedureinsuc = "spBuscarMaestroGrupo";
        MySqlConnection conn = new MySqlConnection(conexion);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand(procedureinsuc, conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("_usuario", txtgpousrm.Text);
        cmd.Parameters["_usuario"].Direction = ParameterDirection.Input;
        cmd.Parameters.AddWithValue("_idGpo", ddlgpom.SelectedValue);
        cmd.Parameters["_idGpo"].Direction = ParameterDirection.Input;
        cmd.ExecuteNonQuery();
        MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adaptador.Fill(dt);
        dgvgpom.DataSource = dt;
        dgvgpom.DataBind();
        if(dt.Rows.Count <= 0)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('La busqueda no obtuvo ni un resultado')", true);
            cargargpomaestros();
        }
        conn.Close();
    }

    protected void modificargrupomaestro()
    {
        string procedureinsuc = "spModificarMaestroGrupo";
        MySqlConnection conn = new MySqlConnection(conexion);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand(procedureinsuc, conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("_activo", ddlactividadmaestro.SelectedValue);
        cmd.Parameters["_activo"].Direction = ParameterDirection.Input;
        cmd.Parameters.AddWithValue("_usuario", txtgpousrm.Text);
        cmd.Parameters["_usuario"].Direction = ParameterDirection.Input;
        cmd.Parameters.AddWithValue("_idGrupo", ddlgpom.SelectedValue);
        cmd.Parameters["_idGrupo"].Direction = ParameterDirection.Input;
        cmd.ExecuteNonQuery();
        MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
        conn.Close();
    }


    #endregion

    protected void btnAddGpo_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(((TextBox)txtApodoGpo).Text))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('*Introduce todos los datos')", true);
        }
        else
        {
            insertargrupo();
            cargargrupos();
        }

    }

    protected void btnSrchGpo_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(((TextBox)txtApodoGpo).Text))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('*Introduce la clave de grupo')", true);
        }
        else
        {
            buscargrupo();
        }
        
    }

    protected void btnModGpo_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Convert.ToString(ViewState["idgpoid"])))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('*Realiza una busqueda primero')", true);
        }
        else
        {
            if (string.IsNullOrWhiteSpace(((TextBox)txtApodoGpo).Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('*Introduce todos los datos')", true);
            }
            else
            {

                idgpoid = ViewState["idgpoid"].ToString();
                modificargrupo();
                cargargrupos();
            }
        }

    }

    protected void dgvGpo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        switch (e.Row.RowType)
        {
            case DataControlRowType.Header:
                e.Row.Cells[0].Visible = false;
                break;
            case DataControlRowType.DataRow:
                e.Row.Cells[0].Visible = false;
                break;
        }
    }

    protected void btnaddgpoa_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(((TextBox)txtgpouser).Text))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('*Introduce todos los datos')", true);
        }
        else
        {
            insertargrupoalumno();
            cargargpoalumnos();
        }

    }


    protected void btnsrchgpoa_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(((TextBox)txtgpouser).Text))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('*Introduce todos los datos')", true);
        }
        else
        {
            buscargrupoalumno();
        }
    }

    protected void btnmodgpoa_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(((TextBox)txtgpouser).Text))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('*Introduce todos los datos')", true);
        }
        else
        {
            modificargrupoalumno();
            cargargpoalumnos();
        }
    }


    protected void btnaddgpom_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(((TextBox)txtgpousrm).Text))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('*Introduce todos los datos')", true);
        }
        else
        {
            insertargrupomaestro();
            cargargpomaestros();
        }
    }

    protected void btnsrchgpom_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(((TextBox)txtgpousrm).Text))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('*Introduce todos los datos')", true);
        }
        else
        {
            buscargrupomaestro();
        }
    }

    protected void btnmodgpom_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(((TextBox)txtgpousrm).Text))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('*Introduce todos los datos')", true);
        }
        else
        {
            modificargrupomaestro();
            cargargpomaestros();
        }
    }

    protected void dgvGpo_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        dgvGpo.PageIndex = e.NewPageIndex;
        cargargrupos();
    }

    protected void dgvgpoa_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        dgvgpoa.PageIndex = e.NewPageIndex;
        cargargpoalumnos();
    }

    protected void dgvgpom_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        dgvgpom.PageIndex = e.NewPageIndex;
        cargargpomaestros();
    }
}