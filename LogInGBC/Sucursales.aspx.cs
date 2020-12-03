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

public partial class Sucursales : System.Web.UI.Page
{
    #region Variables Globales
    string conexion = ConfigurationManager.ConnectionStrings["conBD"].ConnectionString;
    string idscs;
    #endregion

    protected void cargarsucursal()
    {
        string procedurebsuc = "spBuscarSucursal";
        MySqlConnection conn = new MySqlConnection(conexion);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand(procedurebsuc, conn);
        cmd.CommandType = CommandType.StoredProcedure;
        MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adaptador.Fill(dt);
        dgvSucursales.DataSource = dt;
        dgvSucursales.DataBind();
        conn.Close();
    }

    protected void insertarsuc()
    {
        string procedureinsuc = "spInsertarSucursal";
        MySqlConnection conn = new MySqlConnection(conexion);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand(procedureinsuc, conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("_nombre", txtNombreSuc.Text);
        cmd.Parameters["_nombre"].Direction = ParameterDirection.Input;
        cmd.Parameters.AddWithValue("_direccion", txtDireSuc.Text);
        cmd.Parameters["_direccion"].Direction = ParameterDirection.Input;
        cmd.Parameters.AddWithValue("_estatus", Convert.ToString(ddlEstatusSuc.SelectedValue));
        cmd.Parameters["_estatus"].Direction = ParameterDirection.Input;
        cmd.ExecuteNonQuery();
        MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
        /* 
         DataTable dt = new DataTable();
         adaptador.Fill(dt);
         dgvSucursales.DataSource = dt;
         dgvSucursales.DataBind();*/
        conn.Close();
    }

    protected void modificarsucursal()
    {
        string procedureinsuc = "spModificarSucursal";
        MySqlConnection conn = new MySqlConnection(conexion);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand(procedureinsuc, conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("_id", Convert.ToInt16(idscs));
        cmd.Parameters["_id"].Direction = ParameterDirection.Input;
        cmd.Parameters.AddWithValue("_nombre", txtNombreSuc.Text);
        cmd.Parameters["_nombre"].Direction = ParameterDirection.Input;
        cmd.Parameters.AddWithValue("_direccion", txtDireSuc.Text);
        cmd.Parameters["_direccion"].Direction = ParameterDirection.Input;
        cmd.Parameters.AddWithValue("_estatus", Convert.ToString(ddlEstatusSuc.SelectedValue));
        cmd.Parameters["_estatus"].Direction = ParameterDirection.Input;
        cmd.ExecuteNonQuery();
        MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
        /* 
         DataTable dt = new DataTable();
         adaptador.Fill(dt);
         dgvSucursales.DataSource = dt;
         dgvSucursales.DataBind();*/
        conn.Close();
    }


    public void buscarsucursal()
    {
        string procedurebsuc = "spBuscarSucursalNombre";
        MySqlConnection conn = new MySqlConnection(conexion);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand(procedurebsuc, conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("_nombre", txtNombreSuc.Text);
        cmd.Parameters["_nombre"].Direction = ParameterDirection.Input;
        cmd.ExecuteNonQuery();
        MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adaptador.Fill(dt);
        dgvSucursales.DataSource = dt;
        dgvSucursales.DataBind();


        if (dt.Rows.Count > 0)
        {
            ViewState["idscs"] = dt.Rows[0][0].ToString();
            txtNombreSuc.Text = dt.Rows[0][1].ToString();
            txtDireSuc.Text = dt.Rows[0][2].ToString();
            if (dt.Rows[0][3].ToString() == "Activo")
            {
                ddlEstatusSuc.SelectedIndex = 1;
            }
            else
            {
                ddlEstatusSuc.SelectedIndex = 0;
            }
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No se encontro ni una coincidencia')", true);
            cargarsucursal();
        }


        conn.Close();  
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        GridViewRow pagerRow = (GridViewRow)dgvSucursales.BottomPagerRow;

        if (pagerRow != null && pagerRow.Visible == false)
        {
            pagerRow.Visible = true;
        }

        cargarsucursal();
    }


    protected void btnAddSuc_Click(object sender, EventArgs e)
    {
        if(string.IsNullOrWhiteSpace(((TextBox)txtNombreSuc).Text) || string.IsNullOrWhiteSpace(((TextBox)txtDireSuc).Text))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('*Introduce todos los datos')", true);
        }
        else
        {
            insertarsuc();
            cargarsucursal();
        }

    }

    protected void btnSrchSuc_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(((TextBox)txtNombreSuc).Text))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('*Introduce un nombre de sucursal')", true);
            cargarsucursal();
        }
        else
        {
            buscarsucursal();
        }
    }

    protected void btnModSuc_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Convert.ToString(ViewState["idscs"])))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('*Realiza una busqueda primero')", true);
        }
        else
        {
            if (string.IsNullOrWhiteSpace(((TextBox)txtNombreSuc).Text) || string.IsNullOrWhiteSpace(((TextBox)txtDireSuc).Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('*Introduce todos los datos')", true);
            }
            else
            {
                idscs = Convert.ToString(ViewState["idscs"]);
                modificarsucursal();
                cargarsucursal();
            }
        }


    }



    protected void dgvSucursales_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        dgvSucursales.PageIndex = e.NewPageIndex;
        cargarsucursal();
    }


    protected void dgvSucursales_RowDataBound(object sender, GridViewRowEventArgs e)
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
}