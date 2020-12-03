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

public partial class Usuarios : System.Web.UI.Page
{

    #region Variables Globales
    string conexion = ConfigurationManager.ConnectionStrings["conBD"].ConnectionString;
    #endregion


    protected void Page_Load(object sender, EventArgs e)
    {


        cargarusers();
        /* if (Convert.ToInt32(ddlRolU.Items.Count.ToString()) == 0)
         {
             cargarddlusers();
         }*/

    }

    void cargarusers()
    {
        string procedurecu = "spCargarUsuarios";
        MySqlConnection conn = new MySqlConnection(conexion);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand(procedurecu, conn);
        cmd.CommandType = CommandType.StoredProcedure;
        MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adaptador.Fill(dt);
        dgvUsr.DataSource = dt;
        dgvUsr.DataBind();
        conn.Close();
    }



    private string ByteArrayToString(byte[] arrInput)
    {
        var sOutput = new StringBuilder(arrInput.Length);
        for (int i = 0; i <= arrInput.Length - 1; i++)
        {
            sOutput.Append(arrInput[i].ToString("X2"));
        }
        return sOutput.ToString();
    }

    protected void dgvUsr_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void insertarusuario()
    {
        int admin = 0;
        int maestro = 0;
        int alumno = 0;

        if (chkadmin.Checked == true)
        {
            admin = 1;
        }

        if (chkmaestro.Checked == true)
        {
            maestro = 1;
        }

        if (chkalumno.Checked == true)
        {
            alumno = 1;
        }

        string code = "";
        byte[] tmpSource;
        byte[] tmpHash;
        tmpSource = ASCIIEncoding.ASCII.GetBytes(((TextBox)txtContraU).Text);
        tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
        code = ByteArrayToString(tmpHash);

        string procedureinsuc = "spAgregarUsuario";
        MySqlConnection conn = new MySqlConnection(conexion);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand(procedureinsuc, conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("_usuario", txtUsuarioU.Text);
        cmd.Parameters["_usuario"].Direction = ParameterDirection.Input;
        cmd.Parameters.AddWithValue("_contra", code);
        cmd.Parameters["_contra"].Direction = ParameterDirection.Input;
        cmd.Parameters.AddWithValue("_nombre", txtNombreU.Text);
        cmd.Parameters["_nombre"].Direction = ParameterDirection.Input;
        cmd.Parameters.AddWithValue("_apellidoP", txtApellidoPU.Text);
        cmd.Parameters["_apellidoP"].Direction = ParameterDirection.Input;
        cmd.Parameters.AddWithValue("_apellidoM", txtApellidoMU.Text);
        cmd.Parameters["_apellidoM"].Direction = ParameterDirection.Input;
        cmd.Parameters.AddWithValue("_alumno", alumno);
        cmd.Parameters["_alumno"].Direction = ParameterDirection.Input;
        cmd.Parameters.AddWithValue("_maestro", maestro);
        cmd.Parameters["_maestro"].Direction = ParameterDirection.Input;
        cmd.Parameters.AddWithValue("_admin", admin);
        cmd.Parameters["_admin"].Direction = ParameterDirection.Input;
        cmd.ExecuteNonQuery();
        MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
        conn.Close();
    }

    protected void modificarusuario()
    {
        int admin = 0;
        int maestro = 0;
        int alumno = 0;

        if (chkadmin.Checked == true)
        {
            admin = 1;
        }

        if (chkmaestro.Checked == true)
        {
            maestro = 1;
        }

        if (chkalumno.Checked == true)
        {
            alumno = 1;
        }

        string code = "";
        byte[] tmpSource;
        byte[] tmpHash;
        tmpSource = ASCIIEncoding.ASCII.GetBytes(((TextBox)txtContraU).Text);
        tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
        code = ByteArrayToString(tmpHash);

        string procedureinsuc = "spModificarUsuario";
        MySqlConnection conn = new MySqlConnection(conexion);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand(procedureinsuc, conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("_contra", code);
        cmd.Parameters["_contra"].Direction = ParameterDirection.Input;
        cmd.Parameters.AddWithValue("_nombre", txtNombreU.Text);
        cmd.Parameters["_nombre"].Direction = ParameterDirection.Input;
        cmd.Parameters.AddWithValue("_apellidoP", txtApellidoPU.Text);
        cmd.Parameters["_apellidoP"].Direction = ParameterDirection.Input;
        cmd.Parameters.AddWithValue("_apellidoM", txtApellidoMU.Text);
        cmd.Parameters["_apellidoM"].Direction = ParameterDirection.Input;
        cmd.Parameters.AddWithValue("_alumno", alumno.ToString());
        cmd.Parameters["_alumno"].Direction = ParameterDirection.Input;
        cmd.Parameters.AddWithValue("_maestro", maestro.ToString());
        cmd.Parameters["_maestro"].Direction = ParameterDirection.Input;
        cmd.Parameters.AddWithValue("_admin", admin.ToString());
        cmd.Parameters["_admin"].Direction = ParameterDirection.Input;
        cmd.Parameters.AddWithValue("_usuario", txtUsuarioU.Text);
        cmd.Parameters["_usuario"].Direction = ParameterDirection.Input;
        cmd.ExecuteNonQuery();
        MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
        conn.Close();
    }

    void buscarusers()
    {
        string procedurecu = "spCargarUsuariosFiltro";
        MySqlConnection conn = new MySqlConnection(conexion);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand(procedurecu, conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("_usuario", txtUsuarioU.Text);
        cmd.Parameters["_usuario"].Direction = ParameterDirection.Input;
        MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adaptador.Fill(dt);
        dgvUsr.DataSource = dt;
        dgvUsr.DataBind();
        if (dt.Rows.Count > 0)
        {
            txtUsuarioU.Text = dt.Rows[0][0].ToString();
            txtNombreU.Text = dt.Rows[0][1].ToString();
            txtApellidoPU.Text = dt.Rows[0][2].ToString();
            txtApellidoMU.Text = dt.Rows[0][3].ToString();

            if (dt.Rows[0][4].ToString() == "Si")
            {
                chkalumno.Checked = true;
            }
            else
            {
                chkalumno.Checked = false;
            }

            if (dt.Rows[0][5].ToString() == "Si")
            {
                chkmaestro.Checked = true;
            }
            else
            {
                chkmaestro.Checked = false;
            }

            if (dt.Rows[0][6].ToString() == "Si")
            {
                chkadmin.Checked = true;
            }
            else
            {
                chkadmin.Checked = false;
            }

        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No se encontro ni una coincidencia')", true);
            cargarusers();
        }


        conn.Close();
    }

    protected void btnAddUsr_Click(object sender, EventArgs e)
    {
        if (chkadmin.Checked == false & chkalumno.Checked == false & chkmaestro.Checked == false)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Selecciona al menos un rol de usuario')", true);
        }
        else
        {
            if (string.IsNullOrWhiteSpace(((TextBox)txtUsuarioU).Text) || string.IsNullOrWhiteSpace(((TextBox)txtContraU).Text) || string.IsNullOrWhiteSpace(((TextBox)txtNombreU).Text) || string.IsNullOrWhiteSpace(((TextBox)txtApellidoPU).Text) || string.IsNullOrWhiteSpace(((TextBox)txtApellidoMU).Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('*Ingresa todos los campos')", true);
            }
            else
            {
                insertarusuario();
                cargarusers();
            }

        }
    }

    protected void btnSrchUsr_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(((TextBox)txtUsuarioU).Text))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('*Ingresa el nombre de usuario')", true);
        }
        else
        {
            buscarusers();
        }

    }

    protected void btnModUsr_Click(object sender, EventArgs e)
    {

            if ((string.IsNullOrWhiteSpace(((TextBox)txtUsuarioU).Text)))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('*Ingresa un nombre de usuario')", true);
            }
            else
            {
            if (chkadmin.Checked == false & chkalumno.Checked == false & chkmaestro.Checked == false)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Selecciona al menos un rol de usuario')", true);
            }
            else
            {
                if (string.IsNullOrWhiteSpace(((TextBox)txtContraU).Text) || string.IsNullOrWhiteSpace(((TextBox)txtNombreU).Text) || string.IsNullOrWhiteSpace(((TextBox)txtApellidoPU).Text) || string.IsNullOrWhiteSpace(((TextBox)txtApellidoMU).Text))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('*Ingresa todos los campos')", true);
                }
                else
                {
                    modificarusuario();
                    cargarusers();
                }
            }
        }
    }

    protected void dgvUsr_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        dgvUsr.PageIndex = e.NewPageIndex;
        cargarusers();
    }
}