using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessEntity;
using BusinessLogic;
using UserCode;
using WinForms.SvTareo;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;

namespace WinForms
{
    public partial class frmRegistroEnsayos : Form
    {
        public frmRegistroEnsayos()
        {
            InitializeComponent();
            cargaFiltros();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            BL_MARCAS obj = new BL_MARCAS();
            DataTable dtResultado = new DataTable();
            string tipo_ensayo = "";

            if (rbRadiografias.Checked == true) {

                tipo_ensayo = "R";
            }
            else if (rbDureza.Checked == true){
                tipo_ensayo = "D";
            }
            else if (rbOtros.Checked == true){
                tipo_ensayo = "O";
            }



            dtResultado = obj.SP_CONSULTAR_DATOS_REGISTRO_ENSAYOS("", txtUnit.Text, txtLine.Text, txtTrain.Text, txtServicio.Text,cboFiltro.SelectedValue.ToString(), txtFiltro.Text, tipo_ensayo);

            if (dtResultado.Rows.Count > 0)
            {
                dgMarcas.DataSource = dtResultado;
                dgMarcas.AutoResizeColumns();
                dgMarcas.Visible = true;

                dgMarcas.Columns[0].ReadOnly = true;
                dgMarcas.Columns[0].Frozen = true;
                dgMarcas.Columns[1].Frozen = true;
                dgMarcas.Columns[2].Frozen = true;
                dgMarcas.Columns[3].Frozen = true;

                dgMarcas.Columns[0].DefaultCellStyle.BackColor = Color.Gray; 

                dgMarcas.Columns[0].DefaultCellStyle.ForeColor = Color.White;


                dgMarcas.Columns[(dtResultado.Columns.Count) - 1].ReadOnly = true;
                dgMarcas.Columns[(dtResultado.Columns.Count) - 1].DefaultCellStyle.BackColor = Color.Gray;

                lblTotal.Text = "TOTAL: " + dtResultado.Rows.Count;
            }
            else
            {
                MessageBox.Show("NO SE ENCONTRARON REGISTROS!!!", "", MessageBoxButtons.OK);
                dgMarcas.DataSource = null;
                return;
            }
        }

        private void dgMarcas_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
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

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            DataTable dt = GetDataTableFromDGV(dgMarcas);
            int inicio = 1, fin = 0;

            string tipo_ensayo = "";

            if (rbRadiografias.Checked == true){tipo_ensayo = "R";}
            else if (rbDureza.Checked == true){tipo_ensayo = "D";}
            else if (rbOtros.Checked == true){tipo_ensayo = "O";}

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
                        dtResultado = obj.SP_GUARDAR_DATOS_REGISTRO_ENSAYOS("", str,tipo_ensayo, Convert.ToString(dt.Columns.Count-2));
 
                        //dtResultado = obj.SP_CONSULTAR_DATOS_REGISTRO_ENSAYOS("", txtUnit.Text, txtLine.Text, txtTrain.Text, txtServicio.Text);

                        //if (dtResultado.Rows.Count > 0)
                        //{
                        //    dgMarcas.DataSource = dtResultado;
                        //    dgMarcas.AutoResizeColumns();
                        //    dgMarcas.Visible = true;

                        //    dgMarcas.Columns[0].ReadOnly = true;

                        //    dgMarcas.Columns[0].DefaultCellStyle.BackColor = Color.Gray;

                        //    dgMarcas.Columns[0].DefaultCellStyle.ForeColor = Color.White;

                        //    dgMarcas.Columns[22].ReadOnly = true;

                        //    dgMarcas.Columns[22].DefaultCellStyle.BackColor = Color.Gray;

                        //    dgMarcas.Columns[22].DefaultCellStyle.ForeColor = Color.White;
                        //}

                        if (dtResultado.Rows.Count > 0)
                        {

                        }

                        MessageBox.Show("Registro Exitoso!");

                        con.Close();
                        
                    }
                }
            }
        }
        private void cargaFiltros()
        {

            BL_MARCAS obj = new BL_MARCAS();
            DataTable dtResultado = new DataTable();
            dtResultado = obj.SP_CONSULTAR_FILTROS("");//frmLogin.obj_user_E.IDE_USUARIO);
            if (dtResultado.Rows.Count > 0)
            {
                cboFiltro.ValueMember = "ID";
                cboFiltro.DisplayMember = "DESCRIPCION";
                cboFiltro.DataSource = dtResultado;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgMarcas_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {

                DateTime fec_inicio;
                fec_inicio = DateTime.Parse("04/06/2016");

                DateTime fec_fin;
                fec_fin = DateTime.Parse("01/02/2019");

                int row ;

                row = e.RowIndex;

                try
                {

                    for (int i = 0; i < dgMarcas.Columns.Count; i++)
                    {
                        if (dgMarcas.Columns[i].Name.Contains("FECHA"))
                        {

                            //MessageBox.Show(dgMarcas.Rows[row].Cells[i].EditedFormattedValue.ToString());

                            //MessageBox.Show(dgMarcas.Rows[row].Cells[1].FormattedValue.ToString());

                            if (!dgMarcas.Rows[row].Cells[i].EditedFormattedValue.ToString().Equals(""))
                            {
                                if (DateTime.Parse(dgMarcas.Rows[row].Cells[i].EditedFormattedValue.ToString()) < DateTime.Parse(dgMarcas.Rows[row].Cells[1].FormattedValue.ToString()))
                                {
                                    MessageBox.Show("La fecha de ensayo es menor que la fecha de I.V.", "Error de validación",
                                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    e.Cancel = true;
                                    return;
                                }
                            };
                        }
                    }
                }
                catch { }

                

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

        private void btnExportar_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "Registro_Juntas_Soldadas_" + (DateTime.Now.ToShortDateString()).Replace("/", "") + ".xls";
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

        private void rbRadiografias_Click(object sender, EventArgs e)
        {
            if (rbOtros.Checked == true)
            {
                rbDureza.Checked = false;
                rbRadiografias.Checked = false;
                rbOtros.Checked = true;
                lblTitulo.Text = "OTROS";
                dgMarcas.DataSource = null;
                dgMarcas.Rows.Clear();
                return;
            }
            else if (rbDureza.Checked == true)
            {
                rbDureza.Checked = true;
                rbRadiografias.Checked = false;
                rbOtros.Checked = false;
                lblTitulo.Text = "DUREZAS Y TT";
                dgMarcas.DataSource = null;
                dgMarcas.Rows.Clear();
                return;
            }
            else if (rbRadiografias.Checked == true)
            {
                rbDureza.Checked = false;
                rbRadiografias.Checked = true;
                rbOtros.Checked = false;
                lblTitulo.Text = "RADIOGRAFIAS";
                dgMarcas.DataSource = null;
                dgMarcas.Rows.Clear();
                return;
            }

        }

        private void rbDureza_Click(object sender, EventArgs e)
        {
            if (rbOtros.Checked == true)
            {
                rbDureza.Checked = false;
                rbRadiografias.Checked = false;
                rbOtros.Checked = true;
                lblTitulo.Text = "OTROS"; 
                dgMarcas.DataSource = null;
                dgMarcas.Rows.Clear();

                return;
            }
            else if (rbDureza.Checked == true)
            {
                rbDureza.Checked = true;
                rbRadiografias.Checked = false;
                rbOtros.Checked = false;
                lblTitulo.Text = "DUREZAS Y TT";
                dgMarcas.DataSource = null;
                dgMarcas.Rows.Clear();

                return;
            }
            else if (rbRadiografias.Checked == true)
            {
                rbDureza.Checked = false;
                rbRadiografias.Checked = true;
                rbOtros.Checked = false;
                lblTitulo.Text = "RADIOGRAFIAS";
                dgMarcas.DataSource = null;
                dgMarcas.Rows.Clear();

                return;
            }
        }

        private void rbOtros_Click(object sender, EventArgs e)
        {
            if (rbOtros.Checked == true)
            {
                rbDureza.Checked = false;
                rbRadiografias.Checked = false;
                rbOtros.Checked = true;
                lblTitulo.Text = "OTROS";
                dgMarcas.DataSource = null;
                dgMarcas.Rows.Clear();
                return;
            }
            else if (rbDureza.Checked == true)
            {
                rbDureza.Checked = true;
                rbRadiografias.Checked = false;
                rbOtros.Checked = false;
                lblTitulo.Text = "DUREZAS Y TT";
                dgMarcas.DataSource = null;
                dgMarcas.Rows.Clear();
                return;
            }
            else if (rbRadiografias.Checked == true)
            {
                rbDureza.Checked = false;
                rbRadiografias.Checked = true;
                rbOtros.Checked = false;
                lblTitulo.Text = "RADIOGRAFIAS";
                dgMarcas.DataSource = null;
                dgMarcas.Rows.Clear();
                return;
            }
        }
    }
}
