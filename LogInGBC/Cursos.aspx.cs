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

public partial class Cursos : System.Web.UI.Page
{

    #region Variables Globales
    string conexion = ConfigurationManager.ConnectionStrings["conBD"].ConnectionString;
    string idcatcur;
    string idcur;
    string clavelvl;
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        cargarcurso();
        cargarcategoria();
        cargarniveles();
        if (Convert.ToInt32(ddlCategoriaCur.Items.Count.ToString()) == 0)
        {
            cargarddlcategoria();
        }
        if (Convert.ToInt32(ddlnivelcurso.Items.Count.ToString()) == 0)
        {
            cargarddlcursos();
        }
    }



    #region Procedimientos Cursos
    // Sección de procedimientos para la seccion de cursos 
    protected void cargarcurso()
    {
        string procedurebsuc = "spBuscarCurso";
        MySqlConnection conn = new MySqlConnection(conexion);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand(procedurebsuc, conn);
        cmd.CommandType = CommandType.StoredProcedure;
        MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adaptador.Fill(dt);
        dgvCur.DataSource = dt;
        dgvCur.DataBind();
        conn.Close();
    }

    protected void buscarcurso()
    {
        string procedurebsuc = "spBuscarCursoNombre";
        MySqlConnection conn = new MySqlConnection(conexion);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand(procedurebsuc, conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("_nombre", txtNombreCur.Text);
        cmd.Parameters["_nombre"].Direction = ParameterDirection.Input;
        cmd.ExecuteNonQuery();
        MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adaptador.Fill(dt);
        dgvCur.DataSource = dt;
        dgvCur.DataBind();
        if (dt.Rows.Count > 0)
        {



            ViewState["idcur"] = dt.Rows[0][0].ToString();
            // Este procedure carga el dropd down de la categoria del curso buscado segun el id del curso el cual se guarda en la variable de view state
            string procedurecursoddl = "spCargarCursoDDL";
            MySqlCommand cmd2 = new MySqlCommand(procedurecursoddl, conn);
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("_idCurso", Convert.ToInt32(ViewState["idcur"]));
            cmd2.Parameters["_idCurso"].Direction = ParameterDirection.Input;
            cmd2.ExecuteNonQuery();
            MySqlDataAdapter adaptador2 = new MySqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            adaptador2.Fill(dt2);

            ddlCategoriaCur.SelectedValue = (dt2.Rows[0][0].ToString());

            txtNombreCur.Text = dt.Rows[0][1].ToString();
            txtDuracionCur.Text = dt.Rows[0][2].ToString();
            txtDesCur.Text = dt.Rows[0][3].ToString();
            txtPrecioCur.Text = dt.Rows[0][4].ToString();
            //Cantidad
            if (dt.Rows[0][5].ToString() == "Si")
            {
                ddlCantidadCur.SelectedIndex = 1;
            }
            else
            {
                ddlCantidadCur.SelectedIndex = 0;
            }
            //Horario
            if (dt.Rows[0][6].ToString() == "Si")
            {
                ddlHorarioCur.SelectedIndex = 1;
            }
            else
            {
                ddlHorarioCur.SelectedIndex = 0;
            }
            //Categoria
            for (int i = 0; i == Convert.ToInt32(ddlCategoriaCur.Items.Count.ToString()); i++)
            {
                ddlCategoriaCur.SelectedIndex = i;
                if (dt.Rows[0][7].ToString() == ddlCategoriaCur.SelectedValue)
                {
                    break;
                }
            }
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No se encontro ni una coincidencia')", true);
            cargarcurso();
        }
        conn.Close();
    }

    protected void insertarcurso()
    {
        string procedureinsuc = "spInsertarCurso";
        MySqlConnection conn = new MySqlConnection(conexion);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand(procedureinsuc, conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("_nombre", txtNombreCur.Text);
        cmd.Parameters["_nombre"].Direction = ParameterDirection.Input;
        cmd.Parameters.AddWithValue("_dura", txtDuracionCur.Text);
        cmd.Parameters["_dura"].Direction = ParameterDirection.Input;
        cmd.Parameters.AddWithValue("_desc", txtDesCur.Text);
        cmd.Parameters["_desc"].Direction = ParameterDirection.Input;
        cmd.Parameters.AddWithValue("_precio", txtPrecioCur.Text);
        cmd.Parameters["_precio"].Direction = ParameterDirection.Input;
        cmd.Parameters.AddWithValue("_selecCant", Convert.ToString(ddlCantidadCur.SelectedValue));
        cmd.Parameters["_selecCant"].Direction = ParameterDirection.Input;
        cmd.Parameters.AddWithValue("_selecthora", Convert.ToString(ddlHorarioCur.SelectedValue));
        cmd.Parameters["_selecthora"].Direction = ParameterDirection.Input;
        cmd.Parameters.AddWithValue("_idCat", Convert.ToString(ddlCategoriaCur.SelectedValue));
        cmd.Parameters["_idCat"].Direction = ParameterDirection.Input;
        cmd.ExecuteNonQuery();
        MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
        /* 
         DataTable dt = new DataTable();
         adaptador.Fill(dt);
         dgvSucursales.DataSource = dt;
         dgvSucursales.DataBind();*/
        conn.Close();
    }

    protected void modificarcurso()
    {
        string procedureinsuc = "spModificarCurso";
        MySqlConnection conn = new MySqlConnection(conexion);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand(procedureinsuc, conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("_nombre", txtNombreCur.Text);
        cmd.Parameters["_nombre"].Direction = ParameterDirection.Input;
        cmd.Parameters.AddWithValue("_dura", txtDuracionCur.Text);
        cmd.Parameters["_dura"].Direction = ParameterDirection.Input;
        cmd.Parameters.AddWithValue("_desc", txtDesCur.Text);
        cmd.Parameters["_desc"].Direction = ParameterDirection.Input;
        cmd.Parameters.AddWithValue("_precio", txtPrecioCur.Text);
        cmd.Parameters["_precio"].Direction = ParameterDirection.Input;
        cmd.Parameters.AddWithValue("_selectC", Convert.ToString(ddlCantidadCur.SelectedValue));
        cmd.Parameters["_selectC"].Direction = ParameterDirection.Input;
        cmd.Parameters.AddWithValue("_selectH", Convert.ToString(ddlHorarioCur.SelectedValue));
        cmd.Parameters["_selectH"].Direction = ParameterDirection.Input;
        cmd.Parameters.AddWithValue("_idCat", Convert.ToString(ddlCategoriaCur.SelectedValue));
        cmd.Parameters["_idCat"].Direction = ParameterDirection.Input;
        cmd.Parameters.AddWithValue("_id", idcur);
        cmd.Parameters["_id"].Direction = ParameterDirection.Input;
        cmd.ExecuteNonQuery();
        MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);

        conn.Close();
    }
    #endregion

    #region Botones Cursos
    protected void btnAddCur_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(((TextBox)txtNombreCur).Text) || string.IsNullOrWhiteSpace(((TextBox)txtDuracionCur).Text) || string.IsNullOrWhiteSpace(((TextBox)txtPrecioCur).Text) || string.IsNullOrWhiteSpace(((TextBox)txtDesCur).Text))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('*Introduce todos los datos')", true);
        }
        else
        {
            insertarcurso();
            cargarcurso();
            cargarddlcursos();
        }

    }

    protected void btnSrchCur_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(((TextBox)txtNombreCur).Text))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('*Introduce un nombre de curso')", true);
            cargarcurso();
        }
        else
        {
            buscarcurso();
        }
        
    }

    protected void btnModCur_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Convert.ToString(ViewState["idcur"])))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('*Realiza una busqueda primero')", true);
        }
        else
        {
            if (string.IsNullOrWhiteSpace(((TextBox)txtNombreCur).Text) || string.IsNullOrWhiteSpace(((TextBox)txtDuracionCur).Text) || string.IsNullOrWhiteSpace(((TextBox)txtPrecioCur).Text) || string.IsNullOrWhiteSpace(((TextBox)txtDesCur).Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('*Introduce todos los datos')", true);
            }
            else
            {
                idcur = Convert.ToString(ViewState["idcur"]);
                modificarcurso();
                cargarcurso();
                cargarddlcursos();
            }
        }

    }

    protected void dgvCur_RowDataBound(object sender, GridViewRowEventArgs e)
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
    #endregion

    #region Procedimientos Categorias
    // Seccion de procedimientos para la seccion de las categorias


    protected void cargarcategoria()
    {
        string procedurebsuc = "spBuscarCategoria";
        MySqlConnection conn = new MySqlConnection(conexion);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand(procedurebsuc, conn);
        cmd.CommandType = CommandType.StoredProcedure;
        MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adaptador.Fill(dt);
        dgvCategoriasCur.DataSource = dt;
        dgvCategoriasCur.DataBind();
        conn.Close();
    }

    protected void cargarddlcategoria()
    {
        string procedurebsuc = "spBuscarCategoria";
        MySqlConnection conn = new MySqlConnection(conexion);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand(procedurebsuc, conn);
        cmd.CommandType = CommandType.StoredProcedure;
        MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adaptador.Fill(dt);
        ddlCategoriaCur.DataValueField = "idCategoria";
        ddlCategoriaCur.DataTextField = "Categoria";
        ddlCategoriaCur.DataSource = dt;
        ddlCategoriaCur.DataBind();
        conn.Close();
    }

    public void buscarcategoria()
    {
        string procedurebsuc = "spBuscarCategoriaNombre";
        MySqlConnection conn = new MySqlConnection(conexion);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand(procedurebsuc, conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("_desc", txtnombrecat.Text);
        cmd.Parameters["_desc"].Direction = ParameterDirection.Input;
        cmd.ExecuteNonQuery();
        MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adaptador.Fill(dt);

      

        dgvCategoriasCur.DataSource = dt;
        dgvCategoriasCur.DataBind();
        if (dt.Rows.Count > 0)
        {
            ViewState["idcatcur"] = dt.Rows[0][0].ToString();

            txtnombrecat.Text = dt.Rows[0][1].ToString();
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No se encontro ni una coincidencia')", true);
            cargarcategoria();
        }
        conn.Close();
    }

    protected void insertarcategoria()
    {
        string procedureinsuc = "spInsertarCategoria";
        MySqlConnection conn = new MySqlConnection(conexion);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand(procedureinsuc, conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("_desc", txtnombrecat.Text);
        cmd.Parameters["_desc"].Direction = ParameterDirection.Input;
        cmd.ExecuteNonQuery();
        MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
        /* 
         DataTable dt = new DataTable();
         adaptador.Fill(dt);
         dgvSucursales.DataSource = dt;
         dgvSucursales.DataBind();*/
        conn.Close();
    }

    protected void modificarcategoria()
    {
        string procedureinsuc = "spModificarCategoria";
        MySqlConnection conn = new MySqlConnection(conexion);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand(procedureinsuc, conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("_id", Convert.ToInt16(idcatcur));
        cmd.Parameters["_id"].Direction = ParameterDirection.Input;
        cmd.Parameters.AddWithValue("_desc", txtnombrecat.Text);
        cmd.Parameters["_desc"].Direction = ParameterDirection.Input;
        cmd.ExecuteNonQuery();
        MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
        cargarddlcategoria();
        /* 
         DataTable dt = new DataTable();
         adaptador.Fill(dt);
         dgvSucursales.DataSource = dt;
         dgvSucursales.DataBind();*/
        conn.Close();
    }
    #endregion

    #region Botones Categorias
    protected void btnAddCat_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(((TextBox)txtnombrecat).Text))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('*Introduce el nombre de la categoria')", true);
        }
        else
        {
            insertarcategoria();
            cargarcategoria();
            cargarddlcategoria();
        }
    }

    protected void btnSrchCat_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(((TextBox)txtnombrecat).Text))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('*Introduce el nombre de la categoria')", true);
            cargarcategoria();
        }
        else
        {
            buscarcategoria();
        }

    }

    protected void dgvCategoriasCur_RowDataBound(object sender, GridViewRowEventArgs e)
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



    protected void btnModCat_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Convert.ToString(ViewState["idcatcur"])))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('*Realiza una busqueda primero')", true);
        }
        else{ 
        if (string.IsNullOrWhiteSpace(((TextBox)txtnombrecat).Text))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('*Introduce el nombre de la categoria')", true);
        }
        else
        {
            idcatcur = Convert.ToString(ViewState["idcatcur"]);
            modificarcategoria();
            cargarcategoria();
            cargarddlcategoria();
        }
        }
    }
    #endregion


    #region Procedimientos Niveles
    protected void cargarniveles()
    {
        string procedurebsuc = "spBuscarNivel";
        MySqlConnection conn = new MySqlConnection(conexion);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand(procedurebsuc, conn);
        cmd.CommandType = CommandType.StoredProcedure;
        MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adaptador.Fill(dt);
        dgvniveles.DataSource = dt;
        dgvniveles.DataBind();
        conn.Close();
    }

    public void buscarniveles()
    {
        string procedurebsuc = "spBuscarNivelClave";
        MySqlConnection conn = new MySqlConnection(conexion);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand(procedurebsuc, conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("_clave", txtclavelvl.Text);
        cmd.Parameters["_clave"].Direction = ParameterDirection.Input;
        cmd.ExecuteNonQuery();
        MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adaptador.Fill(dt);


        dgvniveles.DataSource = dt;
        dgvniveles.DataBind();

        if (dt.Rows.Count > 0)
        {
            ViewState["clavelvl"] = dt.Rows[0][0].ToString();

            // Este procedure carga el dropd down del curso de la categoria buscado segun la clave del nivel el cual se guarda en la variable de view state
            string procedurecursoddl = "spCargarNivelDLL";
            MySqlCommand cmd2 = new MySqlCommand(procedurecursoddl, conn);
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("_ClaveNivel", ViewState["clavelvl"].ToString());
            cmd2.Parameters["_ClaveNivel"].Direction = ParameterDirection.Input;
            cmd2.ExecuteNonQuery();
            MySqlDataAdapter adaptador2 = new MySqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            adaptador2.Fill(dt2);

            ddlnivelcurso.SelectedValue = (dt2.Rows[0][0].ToString());

            txtclavelvl.Text = dt.Rows[0][0].ToString();
            txtnombrelvl.Text = dt.Rows[0][1].ToString();
            txtlinklvl.Text = dt.Rows[0][2].ToString();

        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('No se encontro ni una coincidencia')", true);
            cargarniveles();
        }
        conn.Close();
    }

    protected void cargarddlcursos()
    {
        string procedurebsuc = "spBuscarCurso";
        MySqlConnection conn = new MySqlConnection(conexion);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand(procedurebsuc, conn);
        cmd.CommandType = CommandType.StoredProcedure;
        MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adaptador.Fill(dt);
        ddlnivelcurso.DataValueField = "idCurso";
        ddlnivelcurso.DataTextField = "Nombre_Curso";
        ddlnivelcurso.DataSource = dt;
        ddlnivelcurso.DataBind();
        conn.Close();
    }

    protected void insertarnivel()
    {
        string procedureinsuc = "spInsertarNivel";
        MySqlConnection conn = new MySqlConnection(conexion);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand(procedureinsuc, conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("_clave", txtclavelvl.Text);
        cmd.Parameters["_clave"].Direction = ParameterDirection.Input;
        cmd.Parameters.AddWithValue("_nombre", txtnombrelvl.Text);
        cmd.Parameters["_nombre"].Direction = ParameterDirection.Input;
        cmd.Parameters.AddWithValue("_clase", txtlinklvl.Text);
        cmd.Parameters["_clase"].Direction = ParameterDirection.Input;
        cmd.Parameters.AddWithValue("_idCurso", ddlnivelcurso.SelectedValue);
        cmd.Parameters["_idCurso"].Direction = ParameterDirection.Input;
        cmd.ExecuteNonQuery();
        MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
        conn.Close();
    }

    protected void modificarnivel()
    {
        string procedureinsuc = "spModificarNivel";
        MySqlConnection conn = new MySqlConnection(conexion);
        conn.Open();
        MySqlCommand cmd = new MySqlCommand(procedureinsuc, conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("_clave", clavelvl);
        cmd.Parameters["_clave"].Direction = ParameterDirection.Input;
        cmd.Parameters.AddWithValue("_nombre", txtnombrelvl.Text);
        cmd.Parameters["_nombre"].Direction = ParameterDirection.Input;
        cmd.Parameters.AddWithValue("_clase", txtlinklvl.Text);
        cmd.Parameters["_clase"].Direction = ParameterDirection.Input;
        cmd.Parameters.AddWithValue("_idCurso", ddlnivelcurso.SelectedValue);
        cmd.Parameters["_idCurso"].Direction = ParameterDirection.Input;
        cmd.ExecuteNonQuery();
        MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);

        conn.Close();
    }

    #endregion

    #region Botones Niveles
    protected void dgvCur_SelectedIndexChanged(object sender, EventArgs e)
    {

    }


    protected void btnAddlvl_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(((TextBox)txtnombrelvl).Text) || string.IsNullOrWhiteSpace(((TextBox)txtclavelvl).Text) || string.IsNullOrWhiteSpace(((TextBox)txtlinklvl).Text))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('*Introduce todos los datos')", true);
        }
        else
        {
            insertarnivel();
            cargarniveles();
        }


    }

    protected void btnSrchlvl_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(((TextBox)txtclavelvl).Text))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('*Introduce la clave del nivel')", true);
        }
        else
        {
            buscarniveles();
        }

    }

    protected void btnModlvl_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Convert.ToString(ViewState["clavelvl"])))
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('*Realiza una busqueda primero')", true);
        }
        else
        {
            if (string.IsNullOrWhiteSpace(((TextBox)txtnombrelvl).Text) || string.IsNullOrWhiteSpace(((TextBox)txtclavelvl).Text) || string.IsNullOrWhiteSpace(((TextBox)txtlinklvl).Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('*Introduce todos los datos')", true);
            }
            else
            {
                clavelvl = Convert.ToString(ViewState["clavelvl"]);
                modificarnivel();
                cargarniveles();
            }
        }

    }
    #endregion



    protected void dgvCur_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        dgvCur.PageIndex = e.NewPageIndex;
        cargarcurso();
    }

    protected void dgvniveles_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        dgvniveles.PageIndex = e.NewPageIndex;
        cargarniveles();
    }

    protected void dgvCategoriasCur_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        dgvCategoriasCur.PageIndex = e.NewPageIndex;
        cargarcategoria();
    }
}



