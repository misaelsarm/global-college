using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using System.Security;
using System.Security.Cryptography;
using System.Configuration;
using System.Text;

using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data;
using System.Web.Configuration;
using System.IO;
using System.IO.Compression;
using System.Web.Services;

public partial class ClasesA : System.Web.UI.Page
{
    #region Variables Globales
    string conexion = ConfigurationManager.ConnectionStrings["conBD"].ConnectionString;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (ddlclasesa.Items.Count < 1)
        {
            cargarMateriales();
        }

    }



    protected void cargarclase()
    {
        string etiqueta;
        string consulta = "SpDesplegarMaterial";
        MySqlConnection conn = new MySqlConnection(conexion);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand(consulta, conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("_Clave", ddlclasesa.SelectedValue);
        cmd.Parameters["_Clave"].Direction = ParameterDirection.Input;
        MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adaptador.Fill(dt);
        etiqueta = dt.Rows[0].ItemArray[0].ToString();
        lblvideo.Text = etiqueta;
        conn.Close();
    }

    void cargarMateriales()
    {
        string procedure = "spCargarMaterialesAlumno", usuario = Session["uxr"].ToString();
        string conexion = ConfigurationManager.ConnectionStrings["conBD"].ConnectionString;
        MySqlConnection conn = new MySqlConnection(conexion);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand(procedure, conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("_usuario", usuario);
        cmd.Parameters["_usuario"].Direction = ParameterDirection.Input;
        MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adaptador.Fill(dt);
        ddlclasesa.DataValueField = "claveNivel";
        ddlclasesa.DataTextField = "nombre";
        ddlclasesa.DataSource = dt;
        ddlclasesa.DataBind();
        conn.Close();
    }


    protected void btnverclase_Click(object sender, EventArgs e)
    {
        cargarclase();
    }
}