using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using BusinessLogic;

namespace WinForms
{
    public partial class frmRegistroJuntasSoldadas : Form
    {
        public frmRegistroJuntasSoldadas()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            BL_MARCAS obj = new BL_MARCAS();
            DataTable dtResultado = new DataTable();
            dtResultado = obj.SP_CONSULTAR_DATOS_REGISTRO_JUNTAS(txtMina.Text, txtLlave.Text, txtMaterial.Text, txtPlano.Text, txtProducto.Text);

            if (dtResultado.Rows.Count > 0)
            {
                dgMarcas.DataSource = dtResultado;
                dgMarcas.AutoResizeColumns();
                dgMarcas.Visible = true;

                // dgMarcas.Columns["LLAVE"].Frozen = true;

                dgMarcas.Columns[0].ReadOnly = true;
                /*  dgMarcas.Columns[1].ReadOnly = true;
                  dgMarcas.Columns[2].ReadOnly = true;
                  dgMarcas.Columns[3].ReadOnly = true;
                  dgMarcas.Columns[4].ReadOnly = true;
                  dgMarcas.Columns[5].ReadOnly = true;
                  dgMarcas.Columns[6].ReadOnly = true;
                  dgMarcas.Columns[7].ReadOnly = true;
                  dgMarcas.Columns[8].ReadOnly = true;
                  dgMarcas.Columns[9].ReadOnly = true;
                */

                dgMarcas.Columns[0].DefaultCellStyle.BackColor = Color.Gray;
                /* dgMarcas.Columns[1].DefaultCellStyle.BackColor = Color.Gray;
                 dgMarcas.Columns[2].DefaultCellStyle.BackColor = Color.Gray;
                 dgMarcas.Columns[3].DefaultCellStyle.BackColor = Color.Gray;
                 dgMarcas.Columns[4].DefaultCellStyle.BackColor = Color.Gray;
                 dgMarcas.Columns[5].DefaultCellStyle.BackColor = Color.Gray;
                 dgMarcas.Columns[6].DefaultCellStyle.BackColor = Color.Gray;
                 dgMarcas.Columns[7].DefaultCellStyle.BackColor = Color.Gray;
                 dgMarcas.Columns[8].DefaultCellStyle.BackColor = Color.Gray;
                 dgMarcas.Columns[9].DefaultCellStyle.BackColor = Color.Gray;*/



                dgMarcas.Columns[0].DefaultCellStyle.ForeColor = Color.White;
                /*       dgMarcas.Columns[1].DefaultCellStyle.ForeColor = Color.White;
                       dgMarcas.Columns[2].DefaultCellStyle.ForeColor = Color.White;
                       dgMarcas.Columns[3].DefaultCellStyle.ForeColor = Color.White;
                       dgMarcas.Columns[4].DefaultCellStyle.ForeColor = Color.White;
                       dgMarcas.Columns[5].DefaultCellStyle.ForeColor = Color.White;
                       dgMarcas.Columns[6].DefaultCellStyle.ForeColor = Color.White;
                       dgMarcas.Columns[7].DefaultCellStyle.ForeColor = Color.White;
                       dgMarcas.Columns[8].DefaultCellStyle.ForeColor = Color.White;
                       dgMarcas.Columns[9].DefaultCellStyle.ForeColor = Color.White;*/


                /*  dgMarcas.Columns[18].ReadOnly = true;
                  dgMarcas.Columns[19].ReadOnly = true;
                  dgMarcas.Columns[20].ReadOnly = true;
                  dgMarcas.Columns[20].DefaultCellStyle.BackColor = Color.Gray;
                  dgMarcas.Columns[20].DefaultCellStyle.ForeColor = Color.White;*/
                lblTotal.Text = "TOTAL: " + dtResultado.Rows.Count;
            }
            else
            {
                MessageBox.Show("NO SE ENCONTRARON REGISTROS!!!", "", MessageBoxButtons.OK);
                dgMarcas.DataSource = null;
                lblTotal.Text = "TOTAL: " + dtResultado.Rows.Count;
                return;
            }


            //DataTable dtResultado_editable = new DataTable();
            //dtResultado_editable = obj.SP_CONSULTAR_COLUMNAS_EDITABLES("", Convert.ToString(frmLogin.obj_perfil_E.IdPerfil));

            //// dgMarcas.ReadOnly = true;

            //if (dgMarcas.Rows.Count != 0 && dgMarcas.Rows != null)
            //{

            //    foreach (DataRow row in dtResultado_editable.Rows)
            //    {
            //        dgMarcas.Columns[(row["CABECERA"].ToString())].ReadOnly = true;

            //        dgMarcas.Columns[(row["CABECERA"].ToString())].DefaultCellStyle.ForeColor = Color.White;

            //        dgMarcas.Columns[(row["CABECERA"].ToString())].DefaultCellStyle.BackColor = Color.Gray;

            //        dgMarcas.Columns[(row["CABECERA"].ToString())].DefaultCellStyle.Font = new System.Drawing.Font(this.Font, FontStyle.Bold);

            //    }

            //}


        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            DataTable dt = GetDataTableFromDGV(dgMarcas);
            int inicio = 1, fin = 0;

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

                        while (inicio <= fin)
                        {
                            sqlBulkCopy.ColumnMappings.Add("Column" + inicio, "col_" + inicio);
                            inicio++;
                        }

                        dt.Columns.Add("Column149", typeof(System.String));
                        dt.Columns.Add("Column150", typeof(System.String));

                        Guid guid = Guid.NewGuid();
                        string str = guid.ToString();
                        foreach (DataRow dr in dt.Rows)
                        {
                            //need to set value to MyRow column 
                            dr["Column149"] = DateTime.Now.ToString("dd/MM/yyyy"); ;
                            dr["Column150"] = str;   // or set it to some other value 
                        }

                        sqlBulkCopy.ColumnMappings.Add("Column149", "col_149");
                        sqlBulkCopy.ColumnMappings.Add("Column150", "col_150");

                        sqlBulkCopy.WriteToServer(dt);

                        BL_MARCAS obj = new BL_MARCAS();
                        DataTable dtResultado = new DataTable();
                        dtResultado = obj.SP_GUARDAR_DATOS_REGISTRO_JUNTAS("", str);

                        if (dtResultado.Rows.Count > 0)
                        {

                        }

                        MessageBox.Show("Registro Exitoso!");

                        con.Close();



                    }
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

        private void dgMarcas_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            dtp.Visible = false;
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "Metrado Producto ING." + (DateTime.Now.ToShortDateString()).Replace("/", "") + ".xls";
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

        private void dgMarcas_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

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
    }
}
