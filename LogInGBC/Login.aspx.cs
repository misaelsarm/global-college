//
using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;

public partial class Login : System.Web.UI.Page
{
    #region Variables Globales
    string conexion = ConfigurationManager.ConnectionStrings["conBD"].ConnectionString;
    #endregion

    void cargarTipoUsuario()
    {
        string procedurecu = "spCargarTipoUsuario";
        MySqlConnection conn = new MySqlConnection(conexion);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand(procedurecu, conn);
        cmd.CommandType = CommandType.StoredProcedure;
        MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adaptador.Fill(dt);
        ddlrol.DataValueField = "IDPERMISO";
        ddlrol.DataTextField = "DESCRIPCION";
        ddlrol.DataSource = dt;
        ddlrol.DataBind();
        conn.Close();
    }

    void iniciarSesion()
    {
        string procedure = "";
        string code = "";
        MySqlConnection conn = new MySqlConnection(conexion);
        conn.Open();
        string sSourceData;
        byte[] tmpSource;
        byte[] tmpHash;
        sSourceData = inputPassword.Text;
        tmpSource = ASCIIEncoding.ASCII.GetBytes(sSourceData);
        tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
        code = ByteArrayToString(tmpHash);
        switch (Convert.ToInt16(ddlrol.SelectedValue))
        {
            case 0: //Es coordinador
                procedure = "spIniciarSesionCoordinador";
                Session["permiso"] = 0;
                break;
            case 1: //Es maestro
                procedure = "spIniciarSesionMaestro";
                Session["permiso"] = 1;
                break;
            case 2: //Es alumno
                procedure = "spIniciarSesionAlumno";
                Session["permiso"] = 2;
                break;


        }
        MySqlCommand cmd = new MySqlCommand(procedure, conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("_usuario", inputUser.Text);
        cmd.Parameters["_usuario"].Direction = ParameterDirection.Input;
        cmd.Parameters.AddWithValue("_contra", code);
        cmd.Parameters["_contra"].Direction = ParameterDirection.Input;
        MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adaptador.Fill(dt);
        if (dt.Rows.Count.Equals(1))
        {
            Session["uxr"] = inputUser.Text;
            Session["sesionusr"] = dt.Rows[0][0].ToString();
            Session["validacion"] = 1;
            int permiso = Convert.ToInt16(Session["permiso"].ToString());
            switch (permiso)
            {
                case 0:
                    Response.Redirect("InicioCS.aspx");
                    break;
                case 1:
                    Response.Redirect("ClasesM.aspx");
                    break;
                case 2:
                    Response.Redirect("ClasesA.aspx");
                    break;

            }

        }
        else
        {
            Session["validacion"] = 0;
            Response.Write("<script>window.alert('El usuario o la contraseña son incorrectos');</script>");
        }
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

    protected void Page_Load(object sender, EventArgs e)
    {
        Session["validacion"] = 0;
        if (!Page.IsPostBack)
        {
            Session["validacion"] = 0;
            cargarTipoUsuario();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        iniciarSesion();
    }
}