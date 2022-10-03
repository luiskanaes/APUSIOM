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
    public partial class frmReportePaquetePruebas : Form
    {
        public frmReportePaquetePruebas()
        {
            InitializeComponent();
            cargaFiltros();
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

        private void frmReportePaquetePruebas_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BL_MARCAS obj = new BL_MARCAS();
            DataTable dtResultado = new DataTable();
            dtResultado = obj.SP_CONSULTAR_PAQUETES_PRUEBA("", txtUnit.Text, txtLine.Text, txtTrain.Text, txtServicio.Text,txtPaquete.Text ,cboFiltro.SelectedValue.ToString(),txtFiltro.Text);

            if (dtResultado.Rows.Count > 0)
            {
                dgMarcas.DataSource = dtResultado;
                dgMarcas.AutoResizeColumns();
                dgMarcas.Columns["JUNTA"].Frozen = true;
                dgMarcas.Columns["JUNTA"].Width = 160;
                dgMarcas.Visible = true;

                dgMarcas.Columns[0].ReadOnly = true;
                //dgMarcas.Columns[1].ReadOnly = true;
                dgMarcas.Columns[23].ReadOnly = true;

                dgMarcas.Columns[0].DefaultCellStyle.Font = new System.Drawing.Font(this.Font, FontStyle.Bold);
                //dgMarcas.Columns[1].ReadOnly = true;
                dgMarcas.Columns[23].DefaultCellStyle.Font = new System.Drawing.Font(this.Font, FontStyle.Bold);

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
                        dtResultado = obj.SP_GUARDAR_DATOS_PAQUETES_PRUEBA("", str);

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

        private void btnExportar_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "Reporte_Paquete_Pruebas" + (DateTime.Now.ToShortDateString()).Replace("/", "") + ".xls";
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

        }
    }
}
