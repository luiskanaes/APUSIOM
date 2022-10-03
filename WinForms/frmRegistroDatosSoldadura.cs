using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using BusinessLogic;

namespace WinForms
{
    public partial class frmRegistroDatosSoldadura : Form
    {
        public frmRegistroDatosSoldadura()
        {
            InitializeComponent();
            cargaFiltros();
        }

        private void cargaFiltros()
        {


        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            buscarBoton();
        }

        void buscarBoton()
        {
            BL_MARCAS obj = new BL_MARCAS();
            DataTable dtResultado = new DataTable();
            DataTable dtResultadoOC = new DataTable();
            DataTable dtResultadoCoti = new DataTable();
            DataTable dtResultadoFactor = new DataTable();

            dtResultado = obj.SP_CONSULTAR_MONTO_TOTAL_POR_CODIGO_SIOM(txtCodigoSiom.Text);
            //dtResultado = obj.SP_CONSULTAR_DATOS("", txtUnit.Text, txtLine.Text, txtTrain.Text,txtServicio.Text,dtpInicio.Text,dtpFin.Text, chkSinFecha.Checked == true ? "1" : "0",txtIv.Text, cboFiltro.SelectedValue.ToString(),txtFiltro.Text, chkSoloValidos.Checked == true ? "1" : "0", chkValidoProgramar.Checked == true ? "1" : "0");
            if (Convert.ToInt32(dtResultado.Rows[0]["MONTO"].ToString()) != 0)
            {

                DataRow row = dtResultado.Rows[0];
                string rowValue = row["Monto"].ToString();
                txtPrecio.Text = rowValue;
                txtRealizadoPor.Text = frmLogin.obj_user_E.IDE_USUARIO;

            }
            else
            {

                DialogResult dialogResult = MessageBox.Show("¿Desea agregar nuevo metrado?", "NO SE ENCONTRARON REGISTROS!!!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                   // Form Formulario = new frmRegistroNuevoMetrado();
                   // Formulario.Show();
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
                // MessageBox.Show("", "", MessageBoxButtons.OK);

                txtCodigoSiom.Text = "";
                txtPrecio.Text = "";
                txtFactor.Text = "";
                //  txtVerificado.Text = "";
                txtPrecioFinal.Text = "0";
                txtFactorFinal.Text = "0";
                txtCantidad.Text = "";
                txtRevisionPlano.Text = "";
                dgCotizacion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgOC.DataSource = null;
                //lblTotal.Text = "TOTAL: ";
                /*  dgMarcas.DataSource = null; 
                  dgMarcas.Refresh(); */
                return;
            }

            DataTable dtResultadoRev = new DataTable();
            dtResultado = obj.SP_CONSULTAR_REV_POR_CODIGO_SIOM(txtCodigoSiom.Text);
            //dtResultado = obj.SP_CONSULTAR_DATOS("", txtUnit.Text, txtLine.Text, txtTrain.Text,txtServicio.Text,dtpInicio.Text,dtpFin.Text, chkSinFecha.Checked == true ? "1" : "0",txtIv.Text, cboFiltro.SelectedValue.ToString(),txtFiltro.Text, chkSoloValidos.Checked == true ? "1" : "0", chkValidoProgramar.Checked == true ? "1" : "0");
            if (dtResultado.Rows.Count > 0)
            {

                DataRow row = dtResultado.Rows[0];
                string rowValue = row["Rev"].ToString();
                txtRevisionPlano.Text = rowValue;


                string rowValue2 = row["CLIENTE"].ToString();
                txtCliente.Text = rowValue2;

            }

            DataTable dtResultado_editable = new DataTable();
            dtResultado_editable = obj.SP_CONSULTAR_COLUMNAS_EDITABLES("", Convert.ToString(frmLogin.obj_perfil_E.IdPerfil));

            dtResultadoFactor = obj.SP_CONSULTAR_FACTOR_POR_CODIGO_SIOM(txtCodigoSiom.Text);

            if (dtResultadoFactor.Rows.Count > 0)
            {
                DataRow row = dtResultadoFactor.Rows[0];
                string rowValue = row["factor"].ToString();
                txtFactor.Text = rowValue;
            }


            dtResultadoOC = obj.SP_CONSULTAR_OC_CODIGO_SIOM(txtCodigoSiom.Text);

            if (dtResultadoOC.Rows.Count > 0)
            { dgOC.DataSource = dtResultadoOC; }

            dtResultadoCoti = obj.SP_CONSULTAR_COTIZACIONES_CODIGO_SIOM(txtCodigoSiom.Text);

            if (dtResultadoCoti.Rows.Count > 0)
            { dgCotizaciones.DataSource = dtResultadoCoti; }
        }

        private void txtCodigoSiom_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmRegistroDatosSoldadura_Load(object sender, EventArgs e)
        {

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ruta = "C:\\SIOM\\COTIZACIONES\\" + txtCliente.Text;

            if (Directory.Exists(ruta))
            {
                MessageBox.Show("La carpeta existe.",
                    "Carpeta existe", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("La carpeta no existe.",
                    "Carpeta no existe", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }


            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "EXCEL_" + (DateTime.Now.ToShortDateString()).Replace("/", "") + ".xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //ToCsV(dataGridView1, @"c:\export.xls");
                ToCsV(dgCotizacion, sfd.FileName); // Here dataGridview1 is your grid view name
            }
        }
        private void ToCsV(DataGridView dGV, string filename)
        {
            string stOutput = "";
            // Export titles:
            string sHeaders = "";

            for (int j = 0; j < dGV.Columns.Count; j++)
                sHeaders = sHeaders.ToString() + Convert.ToString(dGV.Columns[j].HeaderText) + "\t";
            stOutput += sHeaders + "\r\n";
            // Export data.
            for (int i = 0; i < dGV.RowCount; i++)
            {
                string stLine = "";
                for (int j = 0; j < dGV.Rows[i].Cells.Count; j++)
                    stLine = stLine.ToString() + Convert.ToString(dGV.Rows[i].Cells[j].Value) + "\t";
                stOutput += stLine + "\r\n";
            }
            Encoding utf16 = Encoding.GetEncoding(1254);
            byte[] output = utf16.GetBytes(stOutput);
            FileStream fs = new FileStream(filename, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(output, 0, output.Length); //write the encoded file
            bw.Flush();
            bw.Close();
            fs.Close();
        }


        private void txtFactorFinal_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                Decimal precio;

                try
                {
                    precio = Decimal.Multiply((Convert.ToDecimal(txtPrecio.Text) / Convert.ToDecimal(txtFactor.Text)), Convert.ToDecimal(txtFactorFinal.Text)); //* txtFactorFinal.Text;

                    txtPrecioFinal.Text = (Convert.ToString((int)Math.Round(precio)));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de cálculo");
                    txtPrecioFinal.Text = "";
                }
            }
        }

        private void txtCodigoSiom_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                buscarBoton();
            }
        }

        private void dgCotizacion_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

            SetHyperLinkOnGrid();
        }

        private void SetHyperLinkOnGrid()
        {
            if (dgCotizacion.Columns.Contains("RUTA"))
            {
                dgCotizacion.Columns["RUTA"].DefaultCellStyle = GetHyperLinkStyleForGridCell();
            }

        }
        private DataGridViewCellStyle GetHyperLinkStyleForGridCell()
        {
            // Set the Font and Uderline into the Content of the grid cell .  
            {
                DataGridViewCellStyle l_objDGVCS = new DataGridViewCellStyle();
                System.Drawing.Font l_objFont = new System.Drawing.Font(FontFamily.GenericSansSerif, 8, FontStyle.Underline);
                l_objDGVCS.Font = l_objFont;
                l_objDGVCS.ForeColor = Color.Blue;
                return l_objDGVCS;
            }
        }

        private void dgCotizacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string sUrl = dgCotizacion.Rows[e.RowIndex].Cells[6].Value.ToString();

            ProcessStartInfo sInfo = new ProcessStartInfo(sUrl);
            try { Process.Start(sInfo); }
            catch (Exception ed) { }


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnCargar_Click_1(object sender, EventArgs e)
        {
            String cantidad = txtCantidad.Text;

            if (cantidad.Equals(""))
            {
                MessageBox.Show("Debe ingresar la cantidad");
                return;
            }

            if (Convert.ToInt32(cantidad) < 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a 0");
            }



            BL_MARCAS obj = new BL_MARCAS();
            DataTable dtResultado = new DataTable();
            DataTable dtResultadoOC = new DataTable();
            DataTable dtResultadoFactor = new DataTable();

            dtResultado = obj.SP_CONSULTAR_PARA_CARGAR(txtCodigoSiom.Text, txtRevisionPlano.Text, txtPrecioFinal.Text, txtFactorFinal.Text, txtCantidad.Text, txtRealizadoPor.Text, dtFecha.Value.ToString());
            //dtResultado = obj.SP_CONSULTAR_DATOS("", txtUnit.Text, txtLine.Text, txtTrain.Text,txtServicio.Text,dtpInicio.Text,dtpFin.Text, chkSinFecha.Checked == true ? "1" : "0",txtIv.Text, cboFiltro.SelectedValue.ToString(),txtFiltro.Text, chkSoloValidos.Checked == true ? "1" : "0", chkValidoProgramar.Checked == true ? "1" : "0");
            // dtResultadoOC = obj.SP_CONSULTAR_OC_CODIGO_SIOM(txtCodigoSiom.Text);

            if (dgCotizacion.Rows.Count == 0)
            {
                dgCotizacion.DataSource = dtResultado;
                txtCodigoSiom.Text = "";
                txtPrecio.Text = "";
                txtFactor.Text = "";
                //  txtVerificado.Text = "";
                txtPrecioFinal.Text = "";
                txtFactorFinal.Text = "";
                txtCantidad.Text = "";
                txtRevisionPlano.Text = "";
                dgCotizacion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgOC.DataSource = null;
                dgCotizaciones.DataSource = null;
            }
            else
            {
                DataTable dtOld = (DataTable)dgCotizacion.DataSource;
                dtOld.Merge(dtResultado);
                dgCotizacion.DataSource = dtOld;
                txtCodigoSiom.Text = "";
                txtPrecio.Text = "";
                txtFactor.Text = "";
                txtVerificado.Text = "";
                txtPrecioFinal.Text = "";
                txtFactorFinal.Text = "";
                txtCantidad.Text = "";
                txtRevisionPlano.Text = "";
                dgCotizacion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgOC.DataSource = null;
                dgCotizaciones.DataSource = null;
            }

            for (int i = 0; i < dgCotizacion.Rows.Count - 1; i++)
            {

                dgCotizacion[0, i].Value = (i + 1).ToString();
            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            DataTable dtGuardar = (DataTable)dgCotizacion.DataSource;
            BL_MARCAS obj = new BL_MARCAS();
            String codigo_siom, precio, factor, cantidad, cliente, cod_cotizacion, realizadopor, fechacoti;
            DataTable dtResultado = new DataTable();
            int error = 0;

            // validar si existen planos
            for (int i = 0; i < dtGuardar.Rows.Count; i++)
            {
                string rutaOrigenPdf = "C:\\DOCUMENTOS_SIOM\\" + dgCotizacion[1, i].Value + "_1.pdf";

                //Determina si el archivo es un PDF.

                //Determina si existe el archivo.
                if (File.Exists(rutaOrigenPdf))
                {
                    //Abre archivo .pdf
                    //  System.Diagnostics.Process.Start(rutaOrigenPdf);
                }
                else
                {
                    error++;
                    //El archivo no existe, continua sin realizar acción.
                    MessageBox.Show("No se cuenta con el plano:" + dgCotizacion[1, i].Value + ".pdf Favor de subirlo al directorio.");
                }


            }

            if (error >= 1)
            {
                return;
            }


            if (txtRealizadoPor.Text.Equals(""))
            {
                MessageBox.Show("Debe colocar quien realiza la cotizacion.");
                return;
            }

            if (txtCodCotizacion.Text.Equals(""))
            {
                MessageBox.Show("Debe colocar el Codigo de Cotizacion.");
                return;
            }

            if (dgCotizacion.Rows.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un producto");
                return;
            }

            for (int i = 0; i < dtGuardar.Rows.Count; i++)
            {
                codigo_siom = dtGuardar.Rows[i]["CODIGO_SIOM"].ToString();
                precio = dtGuardar.Rows[i]["PRECIO_UNITARIO"].ToString();
                factor = dtGuardar.Rows[i]["FACTOR"].ToString();
                cantidad = dtGuardar.Rows[i]["CANTIDAD"].ToString();
                cliente = txtCliente.Text;
                cod_cotizacion = txtCodCotizacion.Text;
                realizadopor = txtRealizadoPor.Text;
                fechacoti = dtFecha.Text;

                dtResultado = obj.SP_INSERTAR_COTIZACION(codigo_siom, precio, factor, cantidad, cliente, cod_cotizacion, realizadopor, fechacoti);
            }
            if (dtResultado.Rows.Count == 1)
            {
                string ruta = "C:\\SIOM\\COTIZACIONES\\" + txtCliente.Text + "\\" + txtCodCotizacion.Text;
                for (int i = 0; i < dgCotizacion.Rows.Count; i++)
                {

                    string nombreArchivo = dgCotizacion[1, i].Value + "_1.pdf";
                    string rutaOrigenPdf = "C:\\DOCUMENTOS_SIOM\\" + dgCotizacion[1, i].Value + "_1.pdf";



                    Directory.CreateDirectory(ruta);
                    /* String FileName = ruta + "\\" + "COTIZACION_" + dgCotizacion[1, i].Value + ".xls";
                     ToCsV(dgCotizacion, FileName);
                    */


                    try
                    {
                        File.Copy(rutaOrigenPdf, Path.Combine(ruta, Path.GetFileName(nombreArchivo)), true);
                    }
                    catch (Exception ex) { }




                }



                String FileName = ruta + "\\" + "COTIZACION_" + txtCodCotizacion.Text + ".xls";
                ToCsV(dgCotizacion, FileName);


                /*   SaveFileDialog sfd = new SaveFileDialog();
                   sfd.Filter = "Excel Documents (*.xls)|*.xls";
                   sfd.FileName = "EXCEL_" + (DateTime.Now.ToShortDateString()).Replace("/", "") + ".xls";
                   if (sfd.ShowDialog() == DialogResult.OK)
                   {
                       //ToCsV(dataGridView1, @"c:\export.xls");
                       ToCsV(dgCotizacion, sfd.FileName); // Here dataGridview1 is your grid view name
                   }*/

                dgCotizacion.DataSource = null;
                txtCliente.Text = "";
                txtCodCotizacion.Text = "";
                MessageBox.Show("COTIZACION REGISTRADA");
            }
        }




        /*private DataTable GetDataTableFromDGV(DataGridView dgv)
{
var dt = new DataTable();
foreach (DataGridViewColumn column in dgv.Columns)
{
if (column.Visible)
{ 
dt.Columns.Add();
}
}

object[] cellValues = new object[dgv.Columns.Count];
foreach (DataGridViewRow row in dgv.Rows)
{
for (int i = 0; i < row.Cells.Count; i++)
{
cellValues[i] = row.Cells[i].Value;
}
dt.Rows.Add(cellValues);
}

return dt;
}

private void btnGrabar_Click(object sender, EventArgs e)
{
DataTable dt = GetDataTableFromDGV(dgMarcas);
int inicio = 1, fin = 0 ;

BL_MARCAS obj = new BL_MARCAS();
DataTable dtResultado_col = new DataTable();
dtResultado_col = obj.SP_CONSULTAR_COLUMNAS_PIP35();
int i = 0;

foreach (DataColumn row in dt.Columns)
{
//dt.Columns.Add("Column"+ row["ID"].ToString(), typeof(string));

if ( dt.Columns.Count != i ) {
dt.Columns[i].ColumnName = Guid.NewGuid().ToString();
i++;
}

}
i = 0;
foreach (DataRow row in dtResultado_col.Rows)
{
//dt.Columns.Add("Column"+ row["ID"].ToString(), typeof(string));
dt.Columns[i].ColumnName = "Column"+ row["NUM_COLUMNA"].ToString();

if (dt.Columns.Count == i)
{
dt.Columns[i].ColumnName = "E";
i++;
}

i++;
}


if (dt.Rows.Count > 0)
{
fin = dt.Columns.Count;

string consString = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
using (SqlConnection con = new SqlConnection(consString))
{
using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
{
//string sqlTrunc = "TRUNCATE TABLE TMP_DATOS";
//SqlCommand cmd = new SqlCommand(sqlTrunc, con);
con.Open();
//cmd.ExecuteNonQuery();


//Set the database table name
sqlBulkCopy.DestinationTableName = "dbo.TMP_DATOS";

//[OPTIONAL]: Map the DataTable columns with that of the database table
//sqlBulkCopy.ColumnMappings.Add("Column2", "DNI_EMPLEADO");

//while (inicio <= fin)
//{
//    sqlBulkCopy.ColumnMappings.Add("Column"+inicio, "col_" + inicio);
//    inicio++;
//}

foreach (DataRow row in dtResultado_col.Rows)
{
sqlBulkCopy.ColumnMappings.Add("Column" + row["NUM_COLUMNA"].ToString(), "col_" + row["NUM_COLUMNA"].ToString());
//dt.Columns[i].ColumnName = "Column" + row["NUM_COLUMNA"].ToString();
//if (dt.Columns.Count == i)
//{
//    dt.Columns[i].ColumnName = "E";
//    i++;
//}

i++;
}

dt.Columns.Add("Column149", typeof(System.String));
dt.Columns.Add("Column150", typeof(System.String));

Guid guid = Guid.NewGuid();
string str = guid.ToString();
foreach (DataRow dr in dt.Rows)
{
dr["Column149"] = DateTime.Now.ToString("dd/MM/yyyy"); ;
dr["Column150"] = str; 
}

sqlBulkCopy.ColumnMappings.Add("Column149", "col_149");
sqlBulkCopy.ColumnMappings.Add("Column150", "col_150");

sqlBulkCopy.WriteToServer(dt);

DataTable dtResultado = new DataTable();
dtResultado = obj.SP_GUARDAR_DATOS("", str);

if (dtResultado.Rows.Count > 0)
{

}

MessageBox.Show("Registro Exitoso!");

con.Close();



}
}
}
}

private void dgMarcas_CellLeave(object sender, DataGridViewCellEventArgs e)
{
dtp.Visible = false;
}

private void dgMarcas_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
{
DataGridViewColumn col = dgMarcas.Columns[e.ColumnIndex] as DataGridViewColumn;

if (dgMarcas.Columns[e.ColumnIndex].Name.Contains("INT_"))
{
DataGridViewTextBoxCell cell = dgMarcas[e.ColumnIndex, e.RowIndex] as DataGridViewTextBoxCell;
if (cell != null)
{
char[] chars = e.FormattedValue.ToString().ToCharArray();
foreach (char c in chars)
{
if (char.IsDigit(c) == false)
{
MessageBox.Show("SOLO NUMEROS ENTEROS");
e.Cancel = true;
break;
}
}
}
}


if (dgMarcas.Columns[e.ColumnIndex].Name.Contains("DEC_"))
{

DataGridViewTextBoxCell cell = dgMarcas[e.ColumnIndex, e.RowIndex] as DataGridViewTextBoxCell;
if (cell != null)
{
char[] chars = e.FormattedValue.ToString().ToCharArray();
foreach (char c in chars)
{
if (char.IsDigit(c) == false)
{
if (c.ToString() != ".")
{
MessageBox.Show("SOLO NUMEROS DECIMALES");
e.Cancel = true;
break;
}                            
}
}
}

}

try
{

DateTime fec_inicio;
fec_inicio = DateTime.Parse("04/06/2016");

DateTime fec_fin;
fec_fin = DateTime.Parse("01/02/2019");

if (!dgMarcas.Rows[e.RowIndex].IsNewRow)
{
//Sólo controlamos el dato de la columna 0
if (dgMarcas.Columns[e.ColumnIndex].Name.Contains("FECHA_"))
{

if (e.FormattedValue.ToString().Length != 10 && !(e.FormattedValue.ToString().Equals("")))
{
MessageBox.Show("El dato introducido no tiene formato fecha DD/MM/YYYY ", "Error de validación",
MessageBoxButtons.OK, MessageBoxIcon.Error);
e.Cancel = true;
return;
}

if (!this.EsFecha(e.FormattedValue.ToString()) && !(e.FormattedValue.ToString().Equals("")))
{
MessageBox.Show("El dato introducido no es de tipo fecha", "Error de validación",
MessageBoxButtons.OK, MessageBoxIcon.Error);
//       dgMarcas.Rows[e.RowIndex].ErrorText = "El dato introducido no es de tipo fecha";
//dgMarcas.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
e.Cancel = true;
}

if (DateTime.Parse(e.FormattedValue.ToString()) > fec_fin && !(e.FormattedValue.ToString().Equals("")))
{
MessageBox.Show("El dato introducido sobrepasa la fecha limite, revisar fecha", "Error de validación",
MessageBoxButtons.OK, MessageBoxIcon.Error);
e.Cancel = true;
return;
}

if (DateTime.Parse(e.FormattedValue.ToString()) < fec_inicio && !(e.FormattedValue.ToString().Equals("")))
{
MessageBox.Show("El dato introducido es menor a la fecha de inicio de proyecto, revisar fecha", "Error de validación",
MessageBoxButtons.OK, MessageBoxIcon.Error);
e.Cancel = true;
return;
}
}
}
}
catch { }
}
private Boolean EsFecha(String fecha)
{
try
{
DateTime.Parse(fecha);
return true;
}
catch
{
return false;
}
}


private void dgMarcas_CellValueChanged(object sender, DataGridViewCellEventArgs e)
{

//var editedCell = this.dgMarcas.Rows[e.RowIndex].Cells[e.ColumnIndex];
//var newValue = editedCell.Value;
int ultimaColumna;
ultimaColumna = dgMarcas.Columns.Count - 1;
string x;
string y;
string valorAnterior;
int num;

x = e.RowIndex.ToString() ;
num = e.ColumnIndex + 1;
y = num.ToString();

//dgMarcas.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = System.Drawing.Color.Red;

if (e.ColumnIndex.ToString() != ultimaColumna.ToString()) {
valorAnterior = dgMarcas.Rows[e.RowIndex].Cells[ultimaColumna].Value.ToString();
dgMarcas.Rows[e.RowIndex].Cells[ultimaColumna].Value = valorAnterior +","+ y;
}


//dgMarcas.Rows[e.RowIndex].Cells[e.ColumnIndex]. = 1;
}

private void btnExportar_Click(object sender, EventArgs e)
{
SaveFileDialog sfd = new SaveFileDialog();
sfd.Filter = "Excel Documents (*.xls)|*.xls";
sfd.FileName = "Registro_PIP35_" + (DateTime.Now.ToShortDateString()).Replace("/", "") + ".xls";
if (sfd.ShowDialog() == DialogResult.OK)
{
//ToCsV(dataGridView1, @"c:\export.xls");
ToCsV(dgMarcas, sfd.FileName); // Here dataGridview1 is your grid view name
}
}*/

        /*
        private void ToCsV(DataGridView dGV, string filename)
            {
                string stOutput = "";
                // Export titles:
                string sHeaders = "";

                for (int j = 0; j < dGV.Columns.Count; j++)
                    sHeaders = sHeaders.ToString() + Convert.ToString(dGV.Columns[j].HeaderText) + "\t";
                stOutput += sHeaders + "\r\n";
                // Export data.
                for (int i = 0; i < dGV.RowCount; i++)
                {
                    string stLine = "";
                    for (int j = 0; j < dGV.Rows[i].Cells.Count; j++)
                        stLine = stLine.ToString() + Convert.ToString(dGV.Rows[i].Cells[j].Value) + "\t";
                    stOutput += stLine + "\r\n";
                }
                Encoding utf16 = Encoding.GetEncoding(1254);
                byte[] output = utf16.GetBytes(stOutput);
                FileStream fs = new FileStream(filename, FileMode.Create);
                BinaryWriter bw = new BinaryWriter(fs);
                bw.Write(output, 0, output.Length); //write the encoded file
                bw.Flush();
                bw.Close();
                fs.Close();
            }

            private void dgMarcas_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (e.KeyChar.ToString() == e.KeyChar.ToString().ToUpper()) {
                    return;
                }
                e.Handled = true;
                SendKeys.Send(e.KeyChar.ToString().ToUpper());
            }


            private void dgMarcas_MouseDown(object sender, MouseEventArgs e)
            {

                try
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        var hit = dgMarcas.HitTest(e.X, e.Y);
                        dgMarcas.ClearSelection();

                        // cell selection
                        dgMarcas[hit.ColumnIndex, hit.RowIndex].Selected = true;

                        frmMostrarDocumentos frm = new frmMostrarDocumentos();
                        string value = dgMarcas.Rows[hit.RowIndex].Cells[0].FormattedValue.ToString();
                        frm.junta = value;

                        frm.Show();

                    }
                }
                catch { }
            }

            private void frmRegistroDatosSoldadura_Load(object sender, EventArgs e)
            {

            }
        }*/
    }
}