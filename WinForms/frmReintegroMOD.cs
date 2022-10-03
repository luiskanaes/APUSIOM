using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessEntity;
using BusinessLogic;
using UserCode;

namespace WinForms
{
    public partial class frmReintegroMOD : Form
    {
        public frmReintegroMOD()
        {
            InitializeComponent();
          //  cargaFiltros();
        }

        private void cargaFiltros()
        {

            BL_MARCAS obj = new BL_MARCAS();
            DataTable dtResultado = new DataTable();
            dtResultado = obj.SP_CONSULTAR_FILTROS("");//frmLogin.obj_user_E.IDE_USUARIO);
            if (dtResultado.Rows.Count > 0)
            {
                /*   cboFiltro.ValueMember = "ID";
                   cboFiltro.DisplayMember = "DESCRIPCION";
                   cboFiltro.DataSource = dtResultado;*/
            }
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {

            BL_MARCAS obj = new BL_MARCAS();
            DataTable dtResultado = new DataTable();
            dtResultado = obj.SP_CONSULTAR_DATOS_INGENIERIA(txtCodigoSiom.Text, txtGrupo.Text, txtDescripcion.Text, txtUnidadMedida.Text);

            if (dtResultado.Rows.Count > 0)
            {
                dgMarcas.DataSource = dtResultado;
                dgMarcas.AutoResizeColumns();
                /* dgMarcas.Columns["JUNTA"].Frozen = true;
                 dgMarcas.Columns["JUNTA"].Width= 155;
                 dgMarcas.Columns["JUNTA"].ReadOnly = true;
                 dgMarcas.Visible = true;*/

                dgMarcas.Columns[(dtResultado.Columns.Count) - 1].ReadOnly = true;
                dgMarcas.Columns[(dtResultado.Columns.Count) - 1].DefaultCellStyle.BackColor = Color.Gray;

                //dgMarcas.Columns[85].ReadOnly = true;
                //dgMarcas.Columns[86].ReadOnly = true;
                //dgMarcas.Columns[87].ReadOnly = true;
                //dgMarcas.Columns[88].ReadOnly = true;
                //dgMarcas.Columns[89].ReadOnly = true;
                //dgMarcas.Columns[90].ReadOnly = true;
                //dgMarcas.Columns[91].ReadOnly = true;
                //dgMarcas.Columns[92].ReadOnly = true;
                //dgMarcas.Columns[93].ReadOnly = true;
                //dgMarcas.Columns[94].ReadOnly = true;

                //dgMarcas.Columns[85].DefaultCellStyle.BackColor = Color.Gray;
                //dgMarcas.Columns[86].DefaultCellStyle.BackColor = Color.Gray;
                //dgMarcas.Columns[87].DefaultCellStyle.BackColor = Color.Gray;
                //dgMarcas.Columns[88].DefaultCellStyle.BackColor = Color.Gray;
                //dgMarcas.Columns[89].DefaultCellStyle.BackColor = Color.Gray;
                //dgMarcas.Columns[90].DefaultCellStyle.BackColor = Color.Gray;
                //dgMarcas.Columns[91].DefaultCellStyle.BackColor = Color.Gray;
                //dgMarcas.Columns[92].DefaultCellStyle.BackColor = Color.Gray;
                //dgMarcas.Columns[93].DefaultCellStyle.BackColor = Color.Gray;
                //dgMarcas.Columns[94].DefaultCellStyle.BackColor = Color.Gray;

                lblTotal.Text = "TOTAL: " + dtResultado.Rows.Count;

            }
            else
            {
                MessageBox.Show("NO SE ENCONTRARON REGISTROS!!!", "", MessageBoxButtons.OK);
                lblTotal.Text = "TOTAL: ";
                dgMarcas.DataSource = null;
                dgMarcas.Refresh();
                return;
            }

            DataTable dtResultado_editable = new DataTable();
            dtResultado_editable = obj.SP_CONSULTAR_COLUMNAS_EDITABLES("", Convert.ToString(frmLogin.obj_perfil_E.IdPerfil));

            if (dgMarcas.Rows.Count != 0 && dgMarcas.Rows != null)
            {

                foreach (DataRow row in dtResultado_editable.Rows)
                {
                    dgMarcas.Columns[(row["CABECERA"].ToString())].ReadOnly = true;

                    //dgMarcas.Columns[(row["CABECERA"].ToString())].DefaultCellStyle.ForeColor = Color.White;

                    //dgMarcas.Columns[(row["CABECERA"].ToString())].DefaultCellStyle.BackColor = Color.Gray;

                    dgMarcas.Columns[(row["CABECERA"].ToString())].DefaultCellStyle.Font = new System.Drawing.Font(this.Font, FontStyle.Bold);

                }

            }

        }
        private DataTable GetDataTableFromDGV(DataGridView dgv)
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
            int inicio = 1, fin = 0;

            BL_MARCAS obj = new BL_MARCAS();
            DataTable dtResultado_col = new DataTable();
            dtResultado_col = obj.SP_CONSULTAR_COLUMNAS_PIP35();
            int i = 0;

            foreach (DataColumn row in dt.Columns)
            {
                //dt.Columns.Add("Column"+ row["ID"].ToString(), typeof(string));

                if (dt.Columns.Count != i)
                {
                    dt.Columns[i].ColumnName = Guid.NewGuid().ToString();
                    i++;
                }

            }
            i = 0;
            foreach (DataRow row in dtResultado_col.Rows)
            {
                //dt.Columns.Add("Column"+ row["ID"].ToString(), typeof(string));
                dt.Columns[i].ColumnName = "Column" + row["NUM_COLUMNA"].ToString();

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

                //Validamos si no e/*s*/ una fila nueva
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

            x = e.RowIndex.ToString();
            num = e.ColumnIndex + 1;
            y = num.ToString();

            //dgMarcas.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = System.Drawing.Color.Red;

            if (e.ColumnIndex.ToString() != ultimaColumna.ToString())
            {
                valorAnterior = dgMarcas.Rows[e.RowIndex].Cells[ultimaColumna].Value.ToString();
                dgMarcas.Rows[e.RowIndex].Cells[ultimaColumna].Value = valorAnterior + "," + y;
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

        private void dgMarcas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == e.KeyChar.ToString().ToUpper())
            {
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
         
    }
}
