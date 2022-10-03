using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessEntity;
using BusinessLogic;
using UserCode;
using System.IO;
using System.Data.OleDb;

namespace WinForms
{
    public partial class frmCargaMasivaColumnas : Form
    {
        private string Excel03ConString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
        private string Excel07ConString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
        public frmCargaMasivaColumnas()
        {
            InitializeComponent(); cargaFiltros();
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

        private void btnImportar_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Esta seguro de guardar los cambios?", "Mensaje Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (respuesta == DialogResult.Yes)
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
                            dtResultado = obj.SP_GUARDAR_COLUMNAS(cboFiltro.SelectedValue.ToString(), str);

                            if (dtResultado.Rows.Count > 0)
                            {

                            }

                            dgMarcas.DataSource = null;

                            dgMarcasAntes.DataSource = null;

                            MessageBox.Show("Registro Exitoso!");

                            con.Close();

                        }
                    }
                }
            }
            else
            {
                return;
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
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                string filePath = openFileDialog1.FileName;
                string extension = Path.GetExtension(filePath);
                string header = "YES";// rbHeaderYes.Checked ? "YES" : "NO";
                string conStr, sheetName;
                dgMarcas.DataSource = null;
                dgMarcas.Columns.Clear();
                dgMarcas.Rows.Clear();
                dgMarcas.Refresh();


                conStr = string.Empty;
                //Cabecera( extension,  filePath);
                switch (extension)
                {

                    case ".xls": //Excel 97-03
                        conStr = string.Format(Excel03ConString, filePath, header);
                        break;

                    case ".xlsx": //Excel 07
                        conStr = string.Format(Excel07ConString, filePath, header);
                        break;
                }

                //Get the name of the First Sheet.
                using (OleDbConnection con = new OleDbConnection(conStr))
                {
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        cmd.Connection = con;
                        con.Open();
                        DataTable dtExcelSchema = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                        sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                        con.Close();
                    }
                }

                //Read Data from the First Sheet.
                using (OleDbConnection con = new OleDbConnection(conStr))
                {
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        using (OleDbDataAdapter oda = new OleDbDataAdapter())
                        {
                            DataTable dt = new DataTable();
                            cmd.CommandText = "SELECT * From [" + sheetName + "]";
                            cmd.Connection = con;
                            con.Open();
                            oda.SelectCommand = cmd;
                            oda.Fill(dt);
                            con.Close();

                            //Populate DataGridView.
                            dgMarcas.DataSource = dt;
                            dgMarcas.Sort(dgMarcas.Columns[0], ListSortDirection.Ascending);
                            //dgMarcas.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.Fill);
                            dgMarcas.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            dgMarcas.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;


                            string mi_variable;

                            mi_variable = "";

                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                if (i == 0)
                                {
                                    mi_variable = "'" + dt.Rows[i][0].ToString() + "'";
                                }
                                else {
                                    mi_variable = mi_variable + ", '" + dt.Rows[i][0].ToString() + "'";

                                  
                                }   
                            }

                            BL_MARCAS obj = new BL_MARCAS();
                            DataTable dtResultado = new DataTable();
                            dtResultado = obj.SP_CONSULTAR_COLUMNAS_ANTES(mi_variable, cboFiltro.SelectedValue.ToString());

                            dgMarcasAntes.DataSource = dtResultado;
                            dgMarcasAntes.Sort(dgMarcasAntes.Columns[0], ListSortDirection.Ascending);
                            //dataMarcasAntes.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.Fill);
                            dgMarcasAntes.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                            dgMarcasAntes.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;





                            dgMarcas.Columns[0].HeaderText = "JUNTA";
                            dgMarcas.Columns[1].HeaderText = cboFiltro.Text;
                            dgMarcasAntes.Columns[1].HeaderText = cboFiltro.Text;

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Existen inconvenientes con el archivo, favor de cambiar la extensión de la misma", "Mensaje Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
