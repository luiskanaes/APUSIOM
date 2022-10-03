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

using System.Configuration;
using System.Data.SqlClient;
using System.IO;


namespace WinForms.RRHH
{
    public partial class frmRegistroDescansoMedico : Form
    {
        public frmRegistroDescansoMedico()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            buscarEmpleados();
            groupBox4.Visible = true;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {

            DataTable dt = GetDataTableFromDGV(dgTareo);


            if (dt.Rows.Count > 0)
            {
                string consString = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                using (SqlConnection con = new SqlConnection(consString))
                {
                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                    {
                        string sqlTrunc = "TRUNCATE TABLE TAREO_EMPLEADOS_DESCANSO_MEDICO_TMP";
                        SqlCommand cmd = new SqlCommand(sqlTrunc, con);
                        con.Open();
                        cmd.ExecuteNonQuery();


                        //Set the database table name
                        sqlBulkCopy.DestinationTableName = "dbo.TAREO_EMPLEADOS_DESCANSO_MEDICO_TMP";

                        //[OPTIONAL]: Map the DataTable columns with that of the database table
                        sqlBulkCopy.ColumnMappings.Add("Column2", "DNI_EMPLEADO");
                        sqlBulkCopy.ColumnMappings.Add("Column5", "DIA_1");
                        sqlBulkCopy.ColumnMappings.Add("Column6", "DIA_2");
                        sqlBulkCopy.ColumnMappings.Add("Column7", "DIA_3");
                        sqlBulkCopy.ColumnMappings.Add("Column8", "DIA_4");
                        sqlBulkCopy.ColumnMappings.Add("Column9", "DIA_5");
                        sqlBulkCopy.ColumnMappings.Add("Column10", "DIA_6");
                        sqlBulkCopy.ColumnMappings.Add("Column11", "DIA_7");
                        sqlBulkCopy.ColumnMappings.Add("Column12", "DIA_8");
                        sqlBulkCopy.ColumnMappings.Add("Column13", "DIA_9");
                        sqlBulkCopy.ColumnMappings.Add("Column14", "DIA_10");
                        sqlBulkCopy.ColumnMappings.Add("Column15", "DIA_11");
                        sqlBulkCopy.ColumnMappings.Add("Column16", "DIA_12");
                        sqlBulkCopy.ColumnMappings.Add("Column17", "DIA_13");
                        sqlBulkCopy.ColumnMappings.Add("Column18", "DIA_14");
                        sqlBulkCopy.ColumnMappings.Add("Column19", "DIA_15");
                        sqlBulkCopy.ColumnMappings.Add("Column20", "DIA_16");
                        sqlBulkCopy.ColumnMappings.Add("Column21", "DIA_17");
                        sqlBulkCopy.ColumnMappings.Add("Column22", "DIA_18");
                        sqlBulkCopy.ColumnMappings.Add("Column23", "DIA_19");
                        sqlBulkCopy.ColumnMappings.Add("Column24", "DIA_20");
                        sqlBulkCopy.ColumnMappings.Add("Column25", "DIA_21");
                        sqlBulkCopy.ColumnMappings.Add("Column26", "DIA_22");
                        sqlBulkCopy.ColumnMappings.Add("Column27", "DIA_23");
                        sqlBulkCopy.ColumnMappings.Add("Column28", "DIA_24");
                        sqlBulkCopy.ColumnMappings.Add("Column29", "DIA_25");
                        sqlBulkCopy.ColumnMappings.Add("Column30", "DIA_26");
                        sqlBulkCopy.ColumnMappings.Add("Column31", "DIA_27");
                        sqlBulkCopy.ColumnMappings.Add("Column32", "DIA_28");


                        if (dgTareo.Columns.Contains("DIA_29"))
                        {
                            sqlBulkCopy.ColumnMappings.Add("Column33", "DIA_29");
                        }

                        if (dgTareo.Columns.Contains("DIA_30"))
                        {
                            sqlBulkCopy.ColumnMappings.Add("Column34", "DIA_30");
                        }


                        if (dgTareo.Columns.Contains("DIA_31"))
                        {
                            sqlBulkCopy.ColumnMappings.Add("Column35", "DIA_31");
                        }


                       




                        //sqlBulkCopy.ColumnMappings.Add("Country", "Country");
                        //con.Open();
                        sqlBulkCopy.WriteToServer(dt);

                        string sqlUpd = "UPDATE TAREO_EMPLEADOS_DESCANSO_MEDICO_TMP SET MES = " + cboMes.SelectedValue.ToString() + " , ANIO =  " + cboAnio.SelectedValue.ToString() + " , UBICACION =  " + cboUbicacion.SelectedValue.ToString();
                        SqlCommand cmd2 = new SqlCommand(sqlUpd, con);
                        //con.Open();
                        cmd2.ExecuteNonQuery();

                        BL_TAREO_EMPLEADO obj = new BL_TAREO_EMPLEADO();
                        DataTable dtResultado = new DataTable();
                        dtResultado = obj.SP_ACTUALIZAR_TB_EMP_DESCANSO_MEDICO("0001", cboMes.SelectedValue.ToString(), cboAnio.SelectedValue.ToString(), cboUbicacion.SelectedValue.ToString());



                        MessageBox.Show("Registro Exitoso!");

                        con.Close();
                        //if (dtResultado.Rows[0]["TOTAL"].ToString() == "0")
                        //{
                        //    return;
                        //}

                    }
                }
            }
        }

        private void btnCerrarTareo_Click(object sender, EventArgs e)
        {

        }

        private void frmRegistroDescansoMedico_Load(object sender, EventArgs e)
        {
            cargasMeses();
            cargasAnios();
            cargaUbicaciones();
            cargarPersonal();
        }
        private void cargasMeses()
        {
            cboMes.DataSource = new BindingSource(meses, null);
            cboMes.DisplayMember = "Value";
            cboMes.ValueMember = "Key";
            cboMes.SelectedValue = 1;

        }

        private void cargaUbicaciones()
        {

            BL_TAREO_EMPLEADO obj = new BL_TAREO_EMPLEADO();
            DataTable dtResultado = new DataTable();
            dtResultado = obj.SP_CONSULTAR_UBICACIONES("");//frmLogin.obj_user_E.IDE_USUARIO);
            if (dtResultado.Rows.Count > 0)
            {

                cboUbicacion.ValueMember = "ID";
                cboUbicacion.DisplayMember = "DESCRIPCION";
                cboUbicacion.DataSource = dtResultado;

            }

        }

        private void cargarPersonal()
        {

            BL_TAREO_EMPLEADO obj = new BL_TAREO_EMPLEADO();
            DataTable dtResultado = new DataTable();
            dtResultado = obj.SP_CONSULTAR_PERSONAL(cboUbicacion.SelectedValue.ToString());//frmLogin.obj_user_E.IDE_USUARIO);
            if (dtResultado.Rows.Count > 0)
            {

                cboPersonal.ValueMember = "DNI";
                cboPersonal.DisplayMember = "APE_NOMBRES";
                cboPersonal.DataSource = dtResultado;

            }

        }




        private void cargasAnios()
        {
            cboAnio.DataSource = new BindingSource(anios, null);
            cboAnio.DisplayMember = "Value";
            cboAnio.ValueMember = "Key";
            cboAnio.SelectedValue = 2017;
        }

        public static Dictionary<int, string> meses = new Dictionary<int, string>()
        {
            {1,"ENERO"},
            {2,"FEBRERO"},
            {3,"MARZO"},
            {4,"ABRIL"},
            {5,"MAYO"},
            {6,"JUNIO"},
            {7,"JULIO"},
            {8,"AGOSTO"},
            {9,"SEPTIEMBRE"},
            {10,"OCTUBRE"},
            {11,"NOVIEMBRE"},
            {12,"DICIEMBRE"}
        };

        public static Dictionary<int, string> anios = new Dictionary<int, string>()
        {
            {2017,"2017"},
            {2018,"2018"},
            {2019,"2019"},
            {2020,"2020"}
        };

        private void buscarEmpleados()
        {
            BL_TAREO_EMPLEADO obj = new BL_TAREO_EMPLEADO();
            DataTable dtResultado = new DataTable();
            dtResultado = obj.SP_CONSULTAR_EMPLEADOS_DESCANSO_MEDICO("0001", cboMes.SelectedValue.ToString(), cboAnio.SelectedValue.ToString(), cboUbicacion.SelectedValue.ToString());

           if (dtResultado.Rows.Count > 0)
            {

                //dgTareo.DataSource = null;
                dgTareo.DataSource = dtResultado;
                dgTareo.AutoResizeColumns();
                dgTareo.Visible = true;

                dgTareo.Columns[0].Frozen = true;
                dgTareo.Columns[1].Frozen = true;
                dgTareo.Columns[2].Frozen = true;

                //dgTareo.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                //dgTareo.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                ////dgTareo.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                ////dgTareo.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                //dgTareo.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //dgTareo.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //dgTareo.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                //dgTareo.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                //dgTareo.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                //dgTareo.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                //dgTareo.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                //dgTareo.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                //dgTareo.Columns[13].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                //dgTareo.Columns[14].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                //dgTareo.Columns[15].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                //dgTareo.Columns[16].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                //dgTareo.Columns[17].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                //dgTareo.Columns[18].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                //dgTareo.Columns[19].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                //dgTareo.Columns[20].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                //dgTareo.Columns[21].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                //dgTareo.Columns[22].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                //dgTareo.Columns[23].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                //dgTareo.Columns[24].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                //dgTareo.Columns[25].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                //dgTareo.Columns[26].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                //dgTareo.Columns[27].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                //dgTareo.Columns[28].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                //dgTareo.Columns[29].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                //dgTareo.Columns[30].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                //dgTareo.Columns[31].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                //dgTareo.Columns[32].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                //dgTareo.Columns[33].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                //dgTareo.Columns[34].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                //dgTareo.Columns[35].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                //dgTareo.Columns[36].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;


                //DataGridViewColumn

                ////column = dgTareo.Columns[0]; column.Width = 20;
                //column = dgTareo.Columns[1]; column.Width = 50;
                ////column = dgTareo.Columns[2]; column.Width = 25;
                //column = dgTareo.Columns[3]; column.Width = 25;
                //column = dgTareo.Columns[4]; column.Width = 25;
                //column = dgTareo.Columns[5]; column.Width = 25;
                //column = dgTareo.Columns[6]; column.Width = 25;
                //column = dgTareo.Columns[7]; column.Width = 25;
                //column = dgTareo.Columns[8]; column.Width = 25;
                //column = dgTareo.Columns[9]; column.Width = 25;
                //column = dgTareo.Columns[10]; column.Width = 25;
                //column = dgTareo.Columns[11]; column.Width = 25;
                //column = dgTareo.Columns[12]; column.Width = 30;
                //column = dgTareo.Columns[13]; column.Width = 30;
                //column = dgTareo.Columns[14]; column.Width = 30;
                //column = dgTareo.Columns[15]; column.Width = 30;
                //column = dgTareo.Columns[16]; column.Width = 30;
                //column = dgTareo.Columns[17]; column.Width = 30;
                //column = dgTareo.Columns[18]; column.Width = 30;
                //column = dgTareo.Columns[19]; column.Width = 30;
                //column = dgTareo.Columns[20]; column.Width = 30;
                //column = dgTareo.Columns[21]; column.Width = 30;
                //column = dgTareo.Columns[22]; column.Width = 30;
                //column = dgTareo.Columns[23]; column.Width = 30;
                //column = dgTareo.Columns[24]; column.Width = 30;
                //column = dgTareo.Columns[25]; column.Width = 30;
                //column = dgTareo.Columns[26]; column.Width = 30;
                //column = dgTareo.Columns[27]; column.Width = 30;
                //column = dgTareo.Columns[28]; column.Width = 30;
                //column = dgTareo.Columns[29]; column.Width = 30;
                //column = dgTareo.Columns[30]; column.Width = 30;
                //column = dgTareo.Columns[31]; column.Width = 30;
                //column = dgTareo.Columns[32]; column.Width = 30;
                //column = dgTareo.Columns[33]; column.Width = 30;
                ////column = dgTareo.Columns[34]; column.Width = 30;



                //dgTareo.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //dgTareo.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //dgTareo.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //dgTareo.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //dgTareo.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //dgTareo.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //dgTareo.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //dgTareo.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //dgTareo.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //dgTareo.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //dgTareo.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //dgTareo.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //dgTareo.Columns[16].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //dgTareo.Columns[17].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //dgTareo.Columns[18].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //dgTareo.Columns[19].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //dgTareo.Columns[20].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //dgTareo.Columns[21].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //dgTareo.Columns[22].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //dgTareo.Columns[23].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //dgTareo.Columns[24].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //dgTareo.Columns[25].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //dgTareo.Columns[26].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //dgTareo.Columns[27].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //dgTareo.Columns[28].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //dgTareo.Columns[29].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //dgTareo.Columns[30].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //dgTareo.Columns[31].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //dgTareo.Columns[32].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //dgTareo.Columns[33].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                ////dgTareo.Columns[34].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                if (dgTareo.Columns.Contains("btn")){
                    dgTareo.Columns.Remove("btn");
                }

                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                dgTareo.Columns.Add(btn);
                btn.HeaderText = "SUSTENTO";
                btn.Text = "Sustento";
                btn.Name = "btn";
                btn.UseColumnTextForButtonValue = true;

                //if (dgTareo.Columns.Count > 35)
                //{
                //    column = dgTareo.Columns[35]; column.Width = 30;
                //    //column = dgTareo.Columns[36]; column.Width = 30;

                //    dgTareo.Columns[35].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //    //dgTareo.Columns[36].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //}

                //if (dgTareo.Columns.Count > 37)
                //{
                //    column = dgTareo.Columns[37]; column.Width = 30;
                //    dgTareo.Columns[37].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //}


            }
            else
            {
                //lblEstado.Text = "--------------";
                dgTareo.DataSource = null;
                //     btnExportar.Visible = false;
            }
        }

        private void dgTareo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgTareo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void dgTareo_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgTareo_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dgTareo_MouseClick(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                //ContextMenu m = new ContextMenu();
                //m.MenuItems.Add(new MenuItem("B - BAJADA"));
                //m.MenuItems.Add(new MenuItem("C - CESADO"));
                //m.MenuItems.Add(new MenuItem("DM - DESCANSO MEDICO"));
                //m.MenuItems.Add(new MenuItem("DSO - DESCANSO MEDICO OBLIGATORIO"));
                //m.MenuItems.Add(new MenuItem("FER - DIA FERIADO"));
                //m.MenuItems.Add(new MenuItem("X - DIA LABORADO OBRA")); 
                //m.MenuItems.Add(new MenuItem("H - DIA LABORADO OF CENTRAL"));
                //m.MenuItems.Add(new MenuItem("FA - FALTA"));
                //m.MenuItems.Add(new MenuItem("P - LIC PATERNIDAD"));
                //m.MenuItems.Add(new MenuItem("LC - LICENCIA CON GOCE"));
                //m.MenuItems.Add(new MenuItem("LS - LICENCIA SIN GOCE"));
                //m.MenuItems.Add(new MenuItem("MAT - MATERNIDAD"));
                //m.MenuItems.Add(new MenuItem("SUB - SUBSIDIO POR SALUD"));
                //m.MenuItems.Add(new MenuItem("S - SUSPENSION"));
                //m.MenuItems.Add(new MenuItem("V - VACACIONES"));

                //m.Show(dgTareo, new Point(e.X, e.Y));

                ContextMenuStrip contexMenuuu = new ContextMenuStrip();

                contexMenuuu.Items.Add(" -LIMPIAR");
                //contexMenuuu.Items.Add("B-BAJADA");
                //contexMenuuu.Items.Add("FA-FALTA");
                //contexMenuuu.Items.Add("S-SUSPENSION");
                //contexMenuuu.Items.Add("X-DIA LABORADO OBRA");
                //contexMenuuu.Items.Add("LC-LICENCIA CON GOCE");
                //contexMenuuu.Items.Add("DSO-DESCANSO SEMANAL OBLIGATORIO");

                contexMenuuu.Items.Add("DM-DESCANSO MEDICO");                 
                contexMenuuu.Items.Add("SU-SUBCIDIO");
                contexMenuuu.Items.Add("SUM-SUBCIDIO X MATERNIDAD");

                //contexMenuuu.Items.Add("C-CESADO/ DESMOVILIZADO");
                //contexMenuuu.Items.Add("SUB-SUBSIDIO POR SALUD");
                //contexMenuuu.Items.Add("P-LIC PATERNIDAD");
                //contexMenuuu.Items.Add("H-DIA LABORADO OF CENTRAL");
                //contexMenuuu.Items.Add("MAT-SUB MATERNIDAD");}









                //contexMenuuu.Items.Add("FER-DIA FERIADO");
                //contexMenuuu.Items.Add("KA-DEYSU 1");
                //contexMenuuu.Items.Add("KB-DEYSU 2");
                //contexMenuuu.Items.Add("KC-DEYSU 3");
                //contexMenuuu.Items.Add("KD-DEYSU 4");
                //contexMenuuu.Items.Add("KE-DEYSU 5");
                //contexMenuuu.Items.Add("KF-DEYSU 6");
                //contexMenuuu.Items.Add("KG-DEYSU 7");
                //contexMenuuu.Items.Add("KH-DEYSU 8");
                //contexMenuuu.Items.Add("KI-DEYSU 9");
                //contexMenuuu.Items.Add("KJ-DEYSU 10");
                //contexMenuuu.Items.Add("KK-DEYSU 11");
                //contexMenuuu.Items.Add("KL-DEYSU 12");

                contexMenuuu.Show(dgTareo, new Point(e.X, e.Y));
                contexMenuuu.ItemClicked += new ToolStripItemClickedEventHandler(
                contexMenuuu_ItemClicked);



            }
        }

        void contexMenuuu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem item = e.ClickedItem;
            // your code here

            //MessageBox.Show("" + item.ToString());
            IList<string> strList = new List<string>();
            Int32 selectedCellCount =
               dgTareo.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedCellCount > 0)
            {
                if (dgTareo.AreAllCellsSelected(true))
                {
                    MessageBox.Show("All cells are selected", "Selected Cells");
                }
                else
                {
                    System.Text.StringBuilder sb =
                        new System.Text.StringBuilder();

                    for (int i = 0; i < selectedCellCount; i++)
                    {
                        sb.Append("Row: ");
                        sb.Append(dgTareo.SelectedCells[i].RowIndex.ToString());
                        sb.Append(", Column: ");
                        sb.Append(dgTareo.SelectedCells[i].ColumnIndex.ToString());
                        sb.Append(Environment.NewLine);


                        strList.Add(dgTareo.SelectedCells[i].RowIndex.ToString() + "," + dgTareo.SelectedCells[i].ColumnIndex.ToString());


                    }

                    foreach (var el in strList)
                    {
                        Console.WriteLine(el);

                        string ss = item.ToString();
                        string[] valuess = ss.Split('-');

                        string s = el;
                        string[] values = s.Split(',');

                        dgTareo[Int32.Parse(values[1]), Int32.Parse(values[0])].Value = valuess[0];
                    }



                    //sb.Append("Total: " + selectedCellCount.ToString());
                    //MessageBox.Show(sb.ToString(), "Selected Cells");
                }
            }
        }

        private void dgTareo_KeyDown(object sender, KeyEventArgs e)
        {
          
        }

        private void dgTareo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String DirectorioFile = ConfigurationManager.AppSettings["DESCANSO_MEDICO"];


            if (dgTareo.Columns[e.ColumnIndex].Name == "btn")
            {

                if (dgTareo.SelectedCells.Count > 0)
                {
                    int selectedrowindex = dgTareo.SelectedCells[0].RowIndex;

                    DataGridViewRow selectedRow = dgTareo.Rows[selectedrowindex];

                    string a = Convert.ToString(selectedRow.Cells["DNI"].Value);

                    // crear carpeta por anio

                    DirectorioFile = DirectorioFile + cboAnio.SelectedValue.ToString() ;//+ "-" // + cboMes.SelectedValue.ToString();
                     
                    //  crear carpeta 

                    DirectorioFile = DirectorioFile+ "-" + a;

                    bool exists = System.IO.Directory.Exists(DirectorioFile);

                    if (!exists)
                        System.IO.Directory.CreateDirectory(DirectorioFile );


                }
                 


                OpenFileDialog openFileDialogCSV = new OpenFileDialog();

                openFileDialogCSV.InitialDirectory = Application.ExecutablePath.ToString();
                //openFileDialogCSV.Filter = "(*.*)|*.*";
                openFileDialogCSV.FilterIndex = 1;
                openFileDialogCSV.RestoreDirectory = true;

                if (openFileDialogCSV.ShowDialog() == DialogResult.OK)
                {
                    this.txtFileToImport.Text = openFileDialogCSV.FileName.ToString();
                    //System.IO.File.Copy(this.txtFileToImport.Text, targetPath);
                    File.Copy(txtFileToImport.Text, Path.Combine(DirectorioFile, Path.GetFileName(txtFileToImport.Text)), true);

                    MessageBox.Show("Archivo guardado en la ruta :" + DirectorioFile, "Archivo");
                }



                //string ruta = "D:\\Descargas";

                //if (Directory.Exists(ruta))
                //{
                //    MessageBox.Show("La carpeta existe.",
                //        "Carpeta existe", MessageBoxButtons.OK,
                //        MessageBoxIcon.Information);
                //}
                //else
                //{
                //    MessageBox.Show("La carpeta no existe.",
                //        "Carpeta no existe", MessageBoxButtons.OK,
                //        MessageBoxIcon.Exclamation);
                //}




                //string fileName = "test.txt";
                //string sourcePath = @"D:\";
                //string targetPath = @"D:\MV\";


                //// Use Path class to manipulate file and directory paths.
                //string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
                //string destFile = System.IO.Path.Combine(targetPath, fileName);

                //// To copy a folder's contents to a new location:
                //// Create a new target folder, if necessary.
                //if (!System.IO.Directory.Exists(targetPath))
                //{
                //    System.IO.Directory.CreateDirectory(targetPath);
                //}

                //// To copy a file to another location and 
                //// overwrite the destination file if it already exists.
                //System.IO.File.Copy(sourceFile, destFile, true);

                //// To copy all the files in one directory to another directory.
                //// Get the files in the source folder. (To recursively iterate through
                //// all subfolders under the current directory, see
                //// "How to: Iterate Through a Directory Tree.")
                //// Note: Check for target path was performed previously
                ////       in this code example.
                //if (System.IO.Directory.Exists(sourcePath))
                //{
                //    string[] files = System.IO.Directory.GetFiles(sourcePath);

                //    // Copy the files and overwrite destination files if they already exist.
                //    foreach (string s in files)
                //    {
                //        // Use static Path methods to extract only the file name from the path.
                //        fileName = System.IO.Path.GetFileName(s);
                //        destFile = System.IO.Path.Combine(targetPath, fileName);
                //        System.IO.File.Copy(s, destFile, true);
                //    }
                //}
                //else
                //{
                //    Console.WriteLine("Source path does not exist!");
                //}

                //// Keep console window open in debug mode.
                //Console.WriteLine("Press any key to exit.");
                ////Console.ReadKey();


            }
        }


        private DataTable GetDataTableFromDGV(DataGridView dgv)
        {
            var dt = new DataTable();
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                if (column.Visible)
                {
                    // You could potentially name the column based on the DGV column name (beware of dupes)
                    // or assign a type based on the data type of the data bound to this DGV column.
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

        private void cboUbicacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarPersonal();
            groupBox4.Visible = false;
            dgTareo.DataSource = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BL_TAREO_EMPLEADO obj = new BL_TAREO_EMPLEADO();
            DataTable dtResultado = new DataTable();
            dtResultado = obj.SP_INSERT_NEW_PERSONAL(cboMes.SelectedValue.ToString(), cboAnio.SelectedValue.ToString(), cboUbicacion.SelectedValue.ToString(),cboPersonal.SelectedValue.ToString());//frmLogin.obj_user_E.IDE_USUARIO);
            if (dtResultado.Rows.Count > 0)
            {
                buscarEmpleados();
            }

            
        }
    }
}
