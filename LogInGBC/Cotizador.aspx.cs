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
using iTextSharp.text.pdf;
using System.IO;
using iTextSharp.text;
using System.Net.Mail;

public partial class Cotizador : System.Web.UI.Page
{



    #region Variables Globales
    string conexion = ConfigurationManager.ConnectionStrings["conBD"].ConnectionString;
    #region Variables PDF
    double precioCurso = 0;
    string sucursal = "";
    string horario = "";
    string dia = "";
    int cantidadPersonas = 0;
    string nombreCurso = "";
    string nombreCliente = "";
    string correoCliente = "";
    string telefono = "";
    string descripcionCurso = "";
    string duracion = "";
    #endregion
    int seleccionarHorario = 0;
    int seleccionarCantidad = 0;
    string totalCurso = "";
    Dictionary<string, String> dias = new Dictionary<string, string>();
    Dictionary<string, String> horarios = new Dictionary<string, string>();
    #endregion

    public void informacionCurso()
    {
        MySqlConnection conn = new MySqlConnection(conexion);
        conn.Open();
        string query = "spCotizadorInfoCurso";
        MySqlCommand cmd = new MySqlCommand(query, conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("_id", ddlCurso.SelectedValue);
        cmd.Parameters["_id"].Direction = ParameterDirection.Input;
        MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adaptador.Fill(dt);
        nombreCurso = Convert.ToString(dt.Rows[0].ItemArray[0].ToString());
        duracion = Convert.ToString(dt.Rows[0].ItemArray[1].ToString());
        precioCurso = Convert.ToDouble(dt.Rows[0].ItemArray[2].ToString());
        descripcionCurso = Convert.ToString(dt.Rows[0].ItemArray[3].ToString());
        horario = Convert.ToString(ddlHorarios.SelectedItem);
        dia = Convert.ToString(ddlDias.SelectedItem);
        sucursal = Convert.ToString(ddlSucursal.SelectedItem);
        if (txtCantidad.Visible == true)
        {
            if (String.IsNullOrEmpty(txtCantidad.Text))
            {
                //Mandar Mensaje de error
            }
            else
            {
                cantidadPersonas = Convert.ToInt32(txtCantidad.Text);
                totalCurso = Convert.ToString(precioCurso * cantidadPersonas);
            }
        }
        else
        {
            //No hacer nada
        }
        if (String.IsNullOrEmpty(txtCantidad.Text))
        {
            //No hacer nada
        }
        else
        {
            telefono = Convert.ToString(txtTelefono.Text);
        }
        nombreCliente = txtNombre.Text;
        correoCliente = txtxCorreo.Text;
        conn.Close();
    }

    private void mostrarPDF(string strS)
    {
        Response.ClearContent();
        Response.ClearHeaders();
        Response.ContentType = "application/pdf";
        Response.AddHeader("Content-Disposition", "attachment; filename=" + strS);
        Response.TransmitFile(strS);
        Response.End();
        Response.Flush();
        Response.Clear();
    }

    void generarYEnviarPDFInterno()
    {
        informacionCurso();
MemoryStream ms = new MemoryStream();
        Document doc = new Document(PageSize.LETTER);
        PdfWriter writer = PdfWriter.GetInstance(doc, ms);
        doc.AddTitle("Cotizacion");
        doc.AddCreator("Daniel Hernandez");
        doc.Open();
        Font _standarFont = new Font(Font.FontFamily.HELVETICA, 14, Font.NORMAL, BaseColor.BLACK);
        Font _tittleFont = new Font(Font.FontFamily.HELVETICA, 20, Font.BOLD, BaseColor.BLACK);
        Font _notesFont = new Font(Font.FontFamily.HELVETICA, 10, Font.BOLD, BaseColor.BLACK);
        doc.Add(new Paragraph("Muchas gracias por interesarse en nuestros cursos, aqui esta anexada la informacion correspondiente a sus preferencias", _standarFont));
        doc.Add(Chunk.NEWLINE);
        doc.Add(new Paragraph("Nombre del curso:             " + nombreCurso, _standarFont));
        doc.Add(new Paragraph("Precio del curso:               " + "$" + precioCurso, _standarFont));
        if (txtCantidad.Visible == true)
        {
            doc.Add(new Paragraph("Cantidad de personas:      " + cantidadPersonas, _standarFont));
            doc.Add(new Paragraph("Total a pagar:                    " + "$" + totalCurso, _standarFont));

        }
        else
        {
            //No hacer nada
        }
        if (String.IsNullOrEmpty(txtCantidad.Text))
        { }
        else
        {
            doc.Add(new Paragraph("*El precio puede variar en caso de ser mas personas", _notesFont));
        }
        doc.Add(new Paragraph("Duracion del curso:           " + duracion + " meses", _standarFont));
        doc.Add(new Paragraph("Dia y hora seleccionados: " + dia + " " + horario, _standarFont));
        doc.Add(new Paragraph("*Sujeto a disponibilidad", _notesFont));
        doc.Add(new Paragraph("Sucursal:                            " + sucursal, _standarFont));
        doc.Add(new Paragraph("*Sujeto a disponibilidad", _notesFont));
        if (String.IsNullOrEmpty(descripcionCurso))
        { }
        else
        {
            doc.Add(new Paragraph("Descripcion del curso: " + descripcionCurso, _standarFont));
        }
        doc.Add(Chunk.NEWLINE);
        doc.Add(new Paragraph("*TODOS LOS CURSOS QUE SEAN GRUPALES SON DE MINIMO 5 PERSONAS Y UN MAXIMO DE 15, EN CASO DE EXCEDER ESA CANTIDAD, SE DIVIDIRAN EN VARIOS GRUPOS.", _notesFont));
        writer.CloseStream = false;
        doc.Close();
        ms.Position = 0;
        writer.Close();

const string SERVER = "relay-hosting.secureserver.net";
   MailMessage oMail = new MailMessage();
   oMail.From = new MailAddress("robertovega@globalcollegemonterrey.com");
   oMail.To.Add(new MailAddress(txtxCorreo.Text));
   oMail.Subject = "Cotizacion de: " + txtNombre.Text; // email's subject
   oMail.IsBodyHtml = true;
   oMail.Priority = MailPriority.High;
   oMail.Body =  "Esta es la cotizacion de " + txtNombre.Text + "<br>" + "Total: " + totalCurso + "<br>";
        if (cantidadPersonas != 0)
        {
            oMail.Body = oMail.Body + "Esta Persona cotizo con nosotros, su correo es: " + txtxCorreo.Text + "<br>" +
            "Curso: " + nombreCurso + "<br>" + "Cantidad de personas: " + cantidadPersonas + "<br>" + "Solicito un horario de: " + dia + " " + horario;
        }
        else
        {
            oMail.Body = oMail.Body + "Esta Persona cotizo con nosotros, su correo es: " + txtxCorreo.Text + "<br>" +
            "Curso: " + nombreCurso + "<br>" + "Cantidad de personas: " + cantidadPersonas + "<br>" + "Solicito un horario de: " + dia + " " + horario;
        }
        if (String.IsNullOrEmpty(txtTelefono.Text))
        {
        }
        else
        {
            oMail.Body = oMail.Body + "<br>" + "Su telefono es: " + txtTelefono.Text + "<br>";
        }
oMail.Attachments.Add(new Attachment(ms, "cotizacionGlobal" + ".pdf"));
   SmtpClient smtpClient = new SmtpClient(SERVER);
   smtpClient.Send(oMail); 
   oMail = null;    // free up resources
    }

   

    #region Cargar Drop Down

    void cargarDiasYHorarios()
    {
        dias.Add("S", "Sabado");
        dias.Add("D", "Domingo");
        dias.Add("LM", "Lunes y Miercoles");
        dias.Add("MJ", "Martes y Jueves");
        horarios.Add("811", "8:00am-11:00am");
        horarios.Add("112", "11:00am-2:00pm");
        horarios.Add("25", "2:00pm-5:00pm");
        horarios.Add("101", "10:00am-1:00pm");
        horarios.Add("7309", "7:30pm-9:00pm");
        horarios.Add("4530", "4:00pm-5:30pm");
        ddlDias.DataSource = dias;
        ddlDias.DataTextField = "Value";
        ddlDias.DataValueField = "Key";
        ddlDias.DataBind();
        ddlHorarios.DataSource = horarios;
        ddlHorarios.DataTextField = "Value";
        ddlHorarios.DataValueField = "Key";
        ddlHorarios.DataBind();
    }

    void cargarCategorias()
    {
        MySqlConnection conn = new MySqlConnection(conexion);
        conn.Open();
        string query = "spBuscarCategoria";
        MySqlCommand cmd = new MySqlCommand(query, conn);
        MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adaptador.Fill(dt);
        ddlTipoCurso.DataValueField = "idCategoria";
        ddlTipoCurso.DataTextField = "Categoria";
        ddlTipoCurso.DataSource = dt;
        ddlTipoCurso.DataBind();
        conn.Close();
    }

    void cargarCursos()
    {
        MySqlConnection conn = new MySqlConnection(conexion);
        conn.Open();
        string query = "spCotizadorCargarCurso";
        MySqlCommand cmd = new MySqlCommand(query, conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("_id", ddlTipoCurso.SelectedValue);
        cmd.Parameters["_id"].Direction = ParameterDirection.Input;
        MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adaptador.Fill(dt);
        ddlCurso.DataValueField = "idCurso";
        ddlCurso.DataTextField = "NombreCurso";
        ddlCurso.DataSource = dt;
        ddlCurso.DataBind();
        conn.Close();
    }

    void cargarSucursal()
    {
        MySqlConnection conn = new MySqlConnection(conexion);
        conn.Open();
        string query = "spCotizadorCargarSucursal";
        MySqlCommand cmd = new MySqlCommand(query, conn);
        MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adaptador.Fill(dt);
        ddlSucursal.DataValueField = "idSucursal";
        ddlSucursal.DataTextField = "nombreSucursal";
        ddlSucursal.DataSource = dt;
        ddlSucursal.DataBind();
        conn.Close();
    }
    #endregion

    void cargarInicio()
    {
        MySqlConnection conn = new MySqlConnection(conexion);
        conn.Open();
        string query = "spCotizadorCargarInicio";
        MySqlCommand cmd = new MySqlCommand(query, conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("_id", ddlCurso.SelectedValue);
        cmd.Parameters["_id"].Direction = ParameterDirection.Input;
        MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adaptador.Fill(dt);
        seleccionarHorario = Convert.ToInt16(dt.Rows[0].ItemArray[0].ToString());
        seleccionarCantidad = Convert.ToInt16(dt.Rows[0].ItemArray[1].ToString());
        conn.Close();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            cargarCategorias();
            cargarCursos();
            cargarInicio();
            cargarSucursal();
            cargarDiasYHorarios();
        }
    }

    protected void btnCotizar_Click(object sender, EventArgs e)
    {
        //Aqui comenzamos las validaciones antes de adentrarnos al codigo de PDF
        if (txtCantidad.Visible == true)
        {
            if (string.IsNullOrEmpty(txtCantidad.Text))
            {
                Response.Write("<script>window.alert('Introduzca una cantidad valida');</script>");
            }
            else
            {
                if (string.IsNullOrEmpty(txtNombre.Text))
                {
                    Response.Write("<script>window.alert('Introduzca un nombre);</script>");
                }
                else
                {
                    if (string.IsNullOrEmpty(txtxCorreo.Text))
                    {
                        Response.Write("<script>window.alert('Introduzca un correo');</script>");
                    }
                    else
                    {
                        generarYEnviarPDFInterno();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Más información en su correo')", true);
                    }
                }
            }
        }
        else
        {

        }
        //Aqui terminan las validaciones
    }

    protected void ddlCurso_SelectedIndexChanged(object sender, EventArgs e)
    {
        cargarInicio();
        if (seleccionarCantidad == 0)
        {
            lblCantidad.Visible = true;
            txtCantidad.Visible = true;
        }
        else
        {
            lblCantidad.Visible = false;
            txtCantidad.Visible = false;
        }
    }

    protected void ddlTipoCurso_SelectedIndexChanged(object sender, EventArgs e)
    {
             MySqlConnection conn = new MySqlConnection(conexion);
        conn.Open();
        string query = "spCotizadorCargarCurso";
        MySqlCommand cmd = new MySqlCommand(query, conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("_id", ddlTipoCurso.SelectedValue);
        cmd.Parameters["_id"].Direction = ParameterDirection.Input;
        MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        adaptador.Fill(dt);
        ddlCurso.DataValueField = "idCurso";
        ddlCurso.DataTextField = "NombreCurso";
        ddlCurso.DataSource = dt;
        ddlCurso.DataBind();
        conn.Close();
    }
}