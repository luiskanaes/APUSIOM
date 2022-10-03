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

namespace WinForms.TareoPersonal
{
    public partial class frmTareo_Empleados : Form
    {
        AutoCompleteStringCollection DataEstadiDiario = new AutoCompleteStringCollection();
        public static string dni = "";
        public static string mes = "";
        public static string anio = "";
        private static List<BE_UBICACIONES_ESTADO> LstEstadoDiario = new List<BE_UBICACIONES_ESTADO>();
        public static string DNI;
        public static string NOMBRES;
        public static string UBI;
        public static string MES;
        public static string ANIO; public static string EMPRESA; public static string DES_UBI;


        public frmTareo_Empleados()
        {
            InitializeComponent();
        }

        private void frmTareo_Empleados_Load(object sender, EventArgs e)
        {
            cargasMeses();
            cargasAnios();
           
            ListarEmpresa();
            //verificarEstadoTareoEmp();
            btnCerrarTareo.Visible = false;
            //btnExportar.Visible = false;
            btnGrabar.Visible = false;
            btnImportar.Visible = false;
            EstadoDiario();
        }
        protected void ListarEmpresa()
        {
            BL_FUNCIONES obj = new BL_FUNCIONES();
            DataTable dtResultado = new DataTable();
            dtResultado = obj.ListarEmpresaPerfil_Tareo_Emp(frmLogin.obj_perfil_E.IdPerfil, frmLogin.obj_user_E.IDE_USUARIO);
            if (dtResultado.Rows.Count > 0)
            {

                cboEmpresa.ValueMember = "ID";
                cboEmpresa.DisplayMember = "DESCRIPCION";
                cboEmpresa.DataSource = dtResultado;
                // ListarCesos();
                cargaUbicaciones();
            }
        }
        public void EstadoDiario()
        {
            BE_UBICACIONES_ESTADO objCab = new BE_UBICACIONES_ESTADO();

            DataTable dt = new DataTable();
            dt.Clear();

            DataEstadiDiario.Clear();
            LstEstadoDiario.Clear();

            objCab.IDE_UBICACION = cboUbicacion.SelectedValue.ToString();
            objCab.FLG_ESTADO = Convert.ToInt32(1);

            BL_UBICACIONES_ESTADO oBESol = new BL_UBICACIONES_ESTADO();
            DataTable dtResultado = new DataTable();
            dt = oBESol.uspSEL_UBICACIONES_ESTADO_POR_UBICACION(cboUbicacion.SelectedValue.ToString(), "");


            if (dt.Rows.Count > 0)
            {
                LstEstadoDiario = new BL_UBICACIONES_ESTADO().f_list_EstadoDiario(objCab);
                //foreach (DataRow row in dt.Rows)
                //{
                //    DataEstadiDiario.Add(Convert.ToString(row["DES_ABREVIADO"]));
                //}

            }
            else
            {
                dt.Rows.Clear();
                dt.Clear();
                DataEstadiDiario.Clear();
            }
        }
       private int verificarEstadoTareoEmp()
        {
            BL_TAREO_EMPLEADO obj = new BL_TAREO_EMPLEADO();
            DataTable dtResultado = new DataTable();
            dtResultado = obj.SP_VERIFICAR_ESTADO_TAREOEMP(cboEmpresa.SelectedValue.ToString(), cboMes.SelectedValue.ToString(), cboAnio.SelectedValue.ToString(), cboUbicacion.SelectedValue.ToString());

            if (dtResultado.Rows.Count == 0)
            {
                lblEstado.Visible = true;
                lblEstado.Text = "PENDIENTE";
                btnImportar.Visible = true;
                //btnExportar.Visible = false;
                btnCerrarTareo.Visible = true;
                btnGrabar.Visible = true;
                btn_Excel.Visible = true;
                btnMPL.Visible = true;
                btnMPO.Visible = true;
                btnMp.Visible = true;
                return 1;
            }
            if (dtResultado.Rows[0]["ESTADO"].ToString() == "2")
            {
                lblEstado.Visible = true;
                lblEstado.Text = "EN PROCESO";
                btnImportar.Visible = true;
                btnGrabar.Visible = true;
                btnCerrarTareo.Visible = true;
                btn_Excel.Visible = true;
                btnMPL.Visible = true;
                btnMPO.Visible = true; btnMp.Visible = true;
                return 1;
            }
            if (dtResultado.Rows[0]["ESTADO"].ToString() == "3")
            {
                lblEstado.Visible = true;
                lblEstado.Text = "MIGRADO";
                btnCerrarTareo.Visible = false;
                // btnExportar.Visible = true;
                btnGrabar.Visible = false;
                btnImportar.Visible = false;
                btn_Excel.Visible = false;
                btnMPL.Visible = false;
                btnMPO.Visible = false; btnMp.Visible = false;
                return 1;
            }
            if (dtResultado.Rows[0]["ESTADO"].ToString() == "4")
            {
                lblEstado.Visible = true;
                lblEstado.Text = "----------";
                btnCerrarTareo.Visible = false;
                // btnExportar.Visible = true;
                MessageBox.Show("Existe un mes sin cerrar para iniciar este mes favor de cerrar el anterior");
                btnGrabar.Visible = false;
                btnImportar.Visible = false;
                btn_Excel.Visible = false;
                btnMPL.Visible = false;
                btnMPO.Visible = false; btnMp.Visible = false;
                return 2;
            }

            //else {

            //    lblEstado.Visible = true;
            //    lblEstado.Text = "MIGRADO";
            //    btnImportar.Visible = false;
            //    btnExportar.Visible = false;
            //}
            return 2;
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
            dtResultado = obj.SP_CONSULTAR_UBICACIONES_TAREO_EMP(frmLogin.obj_user_E.IDE_USUARIO,cboEmpresa.SelectedValue.ToString());//frmLogin.obj_user_E.IDE_USUARIO);
            if (dtResultado.Rows.Count > 0)
            {

                cboUbicacion.ValueMember = "ID";
                cboUbicacion.DisplayMember = "DESCRIPCION";
                cboUbicacion.DataSource = dtResultado;

            }

        }

        private void cargasAnios()
        {
            cboAnio.DataSource = new BindingSource(anios, null);
            cboAnio.DisplayMember = "Value";
            cboAnio.ValueMember = "Key";
            cboAnio.SelectedValue = 2019;
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
            //{2017,"2017"},
            {2018,"2018"},
            {2019,"2019"},
            {2020,"2020"}
        };

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            Listar();

        }

        protected void Listar()
        {
            if (verificarEstadoTareoEmp() == 1) {


            buscarEmpleados();

            bloquearCelda();

            bloquearCeldaCeseFecIng();

            }         

        }

        private void bloquearCeldaCeseFecIng()
        {
             
        }

        private void bloquearCelda()
        {
            BL_TAREO_EMPLEADO obj = new BL_TAREO_EMPLEADO();
            DataTable dtResultado = new DataTable();
            dtResultado = obj.SP_DESMOVILIZACIONES_UBICACION(cboMes.SelectedValue.ToString(), cboAnio.SelectedValue.ToString(), cboUbicacion.SelectedValue.ToString(), cboEmpresa.SelectedValue.ToString());

            if (dtResultado.Rows.Count > 0)
            {

                String dni, dia;

                dni = "";


                try
                {

                    foreach (DataRow row in dtResultado.Rows)
                    {
                        dni = row["IDE_USUARIO"].ToString();
                        dia = row["DIA"].ToString();

                        String searchValue = dni;
                        int rowIndex = -1;
                        foreach (DataGridViewRow row2 in dgTareo.Rows)
                        {
                            if (row2.Cells[1].Value.ToString().Equals(searchValue))
                            {
                                
                                if(cboUbicacion.SelectedValue.ToString().Equals( "999")) {

                                }else { 
                                rowIndex = row2.Index;

                                dgTareo.Rows[rowIndex].Cells[int.Parse(dia) + 5].Style.BackColor = Color.Gray;
                                dgTareo.Rows[rowIndex].Cells[int.Parse(dia) + 5].ReadOnly = true;
                                dgTareo.Rows[rowIndex].Cells[int.Parse(dia) + 5].Style.ForeColor = Color.Gray;
                                break;}
                            }
                        }

                    }

                }
                catch { } 

            }
        } 
        private void buscarEmpleados()
        {
            BL_TAREO_EMPLEADO obj = new BL_TAREO_EMPLEADO();
            DataTable dtResultado = new DataTable();
            dtResultado = obj.SP_CONSULTAR_EMPLEADOS(cboEmpresa.SelectedValue.ToString(), cboMes.SelectedValue.ToString(), cboAnio.SelectedValue.ToString(), cboUbicacion.SelectedValue.ToString());

            if (dtResultado.Rows.Count > 0)
            {

                //gridDetalle.Rows.Clear();
                //gridDetalle.Columns.Clear();
                //gridDetalle.Refresh();
                dgTareo.DataSource = dtResultado;
                dgTareo.AutoResizeColumns();
                dgTareo.Visible = true;

            


                dgTareo.AllowUserToAddRows = true;
                //ALINEACIONES 

                dgTareo.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //dgTareo.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgTareo.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;//APELLIDOS
                dgTareo.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                dgTareo.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgTareo.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgTareo.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //COLORES

                dgTareo.Columns[0].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#fff451");
                dgTareo.Columns[1].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#fff451");
                dgTareo.Columns[2].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#fff451");

                //dgTareo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgTareo.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                //ANCHO

                DataGridViewColumn

                column = dgTareo.Columns[0]; column.Width = 20;
                //column = dgTareo.Columns[1]; column.Width = 60;
                //    column = dgTareo.Columns[2]; column.Width = 80;
                //column = dgTareo.Columns[3]; column.Width = 40;
                column = dgTareo.Columns[4]; column.Width = 57;
                column = dgTareo.Columns[5]; column.Width = 69;
                //column = dgTareo.Columns[6]; column.Width = 0;
                //column = dgTareo.Columns[7]; column.Width = 0;

                column = dgTareo.Columns[6]; column.Width = 30;
                column = dgTareo.Columns[7]; column.Width = 30;
                column = dgTareo.Columns[8]; column.Width = 30;
                column = dgTareo.Columns[9]; column.Width = 30;
                column = dgTareo.Columns[10]; column.Width = 30;
                column = dgTareo.Columns[11]; column.Width = 30;
                column = dgTareo.Columns[12]; column.Width = 30;
                column = dgTareo.Columns[13]; column.Width = 30;
                column = dgTareo.Columns[14]; column.Width = 30;
                column = dgTareo.Columns[15]; column.Width = 30;
                column = dgTareo.Columns[16]; column.Width = 30;
                column = dgTareo.Columns[17]; column.Width = 30;
                column = dgTareo.Columns[18]; column.Width = 30;
                column = dgTareo.Columns[19]; column.Width = 30;
                column = dgTareo.Columns[20]; column.Width = 30;
                column = dgTareo.Columns[21]; column.Width = 30;
                column = dgTareo.Columns[22]; column.Width = 30;
                column = dgTareo.Columns[23]; column.Width = 30;
                column = dgTareo.Columns[24]; column.Width = 30;
                column = dgTareo.Columns[25]; column.Width = 30;
                column = dgTareo.Columns[26]; column.Width = 30;
                column = dgTareo.Columns[27]; column.Width = 30;
                column = dgTareo.Columns[28]; column.Width = 30;
                column = dgTareo.Columns[29]; column.Width = 30;
                column = dgTareo.Columns[30]; column.Width = 30;
                column = dgTareo.Columns[31]; column.Width = 30;
                column = dgTareo.Columns[32]; column.Width = 30;
                column = dgTareo.Columns[33]; column.Width = 30;
                column = dgTareo.Columns[34]; column.Width = 30;




                //dgTareo.Columns[8].Visible = true;
                //dgTareo.Columns[9].Visible= true;



                string MES = cboMes.SelectedValue.ToString();
                MES = MES.PadLeft(2, '0');

                string date = "01/" + MES + "/" + cboAnio.SelectedValue.ToString();
                DateTime now = Convert.ToDateTime(date);

                var startDate = new DateTime(now.Year, now.Month, 1); // iniciar el primer día de mes
                                                                      // Establecer esta variable al Calendar
                var endDate = startDate.AddMonths(1).AddDays(-1); // este es el último día del mes en curso.


                int maxcolum = dgTareo.Columns.Count;
                int maxRows = dtResultado.Rows.Count;
                string VALOR;
                for (int i = 0; i < maxRows; i++)
                {
                    DataGridViewRow Rows = dgTareo.Rows[i];
                    for (int j = 6; j < maxcolum; j++)
                    {
                        dgTareo.Columns[j].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                        VALOR = (Rows.Cells[j].Value == null) ? "0" : Rows.Cells[j].Value.ToString();

                        BE_UBICACIONES_ESTADO result = LstEstadoDiario.Find(
                        delegate (BE_UBICACIONES_ESTADO bk)
                        {
                            if (bk.ABREVIATURA.ToUpper() == VALOR.ToUpper())
                            {
                                VALOR = bk.COLOR_FONDO;
                            }
                            return bk.COLOR_FONDO == VALOR;
                        }
                        );

                        if (result != null)
                        {
                            string VALORzx = VALOR;
                            dgTareo.Rows[i].Cells[j].Style.BackColor = ColorTranslator.FromHtml(VALOR);
                        }
                    }
                }


                dgTareo.AllowUserToAddRows = false;

                dgTareo.Columns[0].Frozen = true;
                dgTareo.Columns[1].Frozen = true;
                dgTareo.Columns[2].Frozen = true;

                dgTareo.Columns[0].ReadOnly = true;
                dgTareo.Columns[1].ReadOnly = true;
                dgTareo.Columns[2].ReadOnly = true;
                dgTareo.Columns[3].ReadOnly = true;
                dgTareo.Columns[4].ReadOnly = true;
                dgTareo.Columns[5].ReadOnly = true;


                //btn_Excel.Visible = true;
                //btnMPL.Visible = true;
                //btnMPO.Visible = true;
                //btnCerrarTareo.Visible = true; 
                //btnGrabar.Visible = true;

                if (cboUbicacion.SelectedValue.ToString().Equals("999"))
                {
                    btnExcelDetalle.Visible = true;
                }
            }
            else
            {
                lblEstado.Text = "-----------------------";
                dgTareo.DataSource = null;
                //     btnExportar.Visible = false;
                 MessageBox.Show("No se encontraron registros para la consulta");
                return;
            }
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

                BL_UBICACIONES_ESTADO oBESol = new BL_UBICACIONES_ESTADO();
                DataTable dtResultado = new DataTable();
                dtResultado = oBESol.uspSEL_UBICACIONES_ESTADO_POR_UBICACION(cboUbicacion.SelectedValue.ToString(), "");
                if (dtResultado.Rows.Count > 0)
                {
                    contexMenuuu.Items.Add(" ***DESMOVILIZAR***");
                    contexMenuuu.Items.Add(" -LIMPIAR");
                    for (int i = 0; i < dtResultado.Rows.Count; i++)
                    {
                        string ESTADO = dtResultado.Rows[i]["ABREVIATURA"].ToString() + "-" + dtResultado.Rows[i]["DESCRIPCION"].ToString();
                        contexMenuuu.Items.Add(ESTADO);
                        //dgvListar.Rows[renglon].Cells["COLOR_FONDO"].Value = dtResultado.Rows[i]["COLOR_FONDO"].ToString();
                        //dgvListar.Rows[renglon].Cells["COLOR_FONDO"].Style.BackColor = ColorTranslator.FromHtml(dtResultado.Rows[i]["COLOR_FONDO"].ToString());
                    }
                }

                contexMenuuu.Show(dgTareo, new Point(e.X, e.Y));
                contexMenuuu.ItemClicked += new ToolStripItemClickedEventHandler(
                contexMenuuu_ItemClicked);
            }
             

           
        }


        void contexMenuuu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem item = e.ClickedItem;
            // click derecho

            

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


                        if (item.ToString().Contains("DESMOVILIZAR"))
                        {  
                           
                            //dgTareo.Rows[Int32.Parse(values[1])].Cells[2].Value = "test";
                            
                            DNI = dgTareo.Rows[Int32.Parse(values[0])].Cells[1].Value.ToString();
                            NOMBRES = dgTareo.Rows[Int32.Parse(values[0])].Cells[2].Value.ToString();
                            MES = cboMes.SelectedValue.ToString();
                            ANIO = cboAnio.SelectedValue.ToString();
                            EMPRESA = cboEmpresa.SelectedValue.ToString(); DES_UBI = cboUbicacion.Text.ToString();

                            UBI = cboUbicacion.SelectedValue.ToString();

                            if (cboUbicacion.Text.ToString().Contains("DESMOVILI")) {
                                DNI = dgTareo.Rows[Int32.Parse(values[0])].Cells[1].Value.ToString();
                                NOMBRES = dgTareo.Rows[Int32.Parse(values[0])].Cells[2].Value.ToString();
                                MES = cboMes.SelectedValue.ToString();
                                ANIO = cboAnio.SelectedValue.ToString();
                                EMPRESA = cboEmpresa.SelectedValue.ToString();
                                DES_UBI = cboUbicacion.Text.ToString();

                                new frmMovilizarEmpTareo().ShowDialog();
                            }
                            else {
                                new frmDesmovilizacionTareo().ShowDialog();

                            }
                            bloquearCelda();

                            return;
                        }

                        if (dgTareo[Int32.Parse(values[1]), Int32.Parse(values[0])].Style.BackColor   == Color.Gray)
                        {

                        }
                        else if(dgTareo[Int32.Parse(values[1]), Int32.Parse(values[0])].Style.BackColor != Color.Red)
                        {
                            dgTareo[Int32.Parse(values[1]), Int32.Parse(values[0])].Value = valuess[0];
                        }

                        
                    }

                    if (lblEstado.Text.Equals("MIGRADO"))
                    {

                    }
                    else {grabarGrillaAutomatico();
                    }
                    colorCelda();
                    bloquearCelda();

                    //sb.Append("Total: " + selectedCellCount.ToString());
                    //MessageBox.Show(sb.ToString(), "Selected Cells");
                }
            }
        }

        private void dgTareo_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {

            //if (e.Button == MouseButtons.Right)
            //{
            //    this.dgTareo.Rows[e.RowIndex].Selected = true;
            //    this.dgTareo.CurrentCell = this.dgTareo.Rows[e.RowIndex].Cells[1];
            //    //this.contextMenuStrip1.Show(this.gridAsignacion, e.Location);
            //    //contextMenuStrip1.Show(Cursor.Position);
            //}

        }

        private void dgTareo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void btnGrabar_Click(object sender, EventArgs e)
        {
            grabarGrilla();
        }



        private void grabarGrilla() {

            DataTable dt = GetDataTableFromDGV(dgTareo);


            if (dt.Rows.Count > 0)
            {
                string consString = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                using (SqlConnection con = new SqlConnection(consString))
                {
                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                    {
                        string sqlTrunc = "TRUNCATE TABLE TAREO_EMPLEADOS_TMP";
                        SqlCommand cmd = new SqlCommand(sqlTrunc, con);
                        con.Open();
                        cmd.ExecuteNonQuery();


                        //Set the database table name
                        sqlBulkCopy.DestinationTableName = "dbo.TAREO_EMPLEADOS_TMP";

                        //[OPTIONAL]: Map the DataTable columns with that of the database table
                        sqlBulkCopy.ColumnMappings.Add("Column2", "DNI_EMPLEADO");
                        sqlBulkCopy.ColumnMappings.Add("Column7", "DIA_1");
                        sqlBulkCopy.ColumnMappings.Add("Column8", "DIA_2");
                        sqlBulkCopy.ColumnMappings.Add("Column9", "DIA_3");
                        sqlBulkCopy.ColumnMappings.Add("Column10", "DIA_4");
                        sqlBulkCopy.ColumnMappings.Add("Column11", "DIA_5");
                        sqlBulkCopy.ColumnMappings.Add("Column12", "DIA_6");
                        sqlBulkCopy.ColumnMappings.Add("Column13", "DIA_7");
                        sqlBulkCopy.ColumnMappings.Add("Column14", "DIA_8");
                        sqlBulkCopy.ColumnMappings.Add("Column15", "DIA_9");
                        sqlBulkCopy.ColumnMappings.Add("Column16", "DIA_10");
                        sqlBulkCopy.ColumnMappings.Add("Column17", "DIA_11");
                        sqlBulkCopy.ColumnMappings.Add("Column18", "DIA_12");
                        sqlBulkCopy.ColumnMappings.Add("Column19", "DIA_13");
                        sqlBulkCopy.ColumnMappings.Add("Column20", "DIA_14");
                        sqlBulkCopy.ColumnMappings.Add("Column21", "DIA_15");
                        sqlBulkCopy.ColumnMappings.Add("Column22", "DIA_16");
                        sqlBulkCopy.ColumnMappings.Add("Column23", "DIA_17");
                        sqlBulkCopy.ColumnMappings.Add("Column24", "DIA_18");
                        sqlBulkCopy.ColumnMappings.Add("Column25", "DIA_19");
                        sqlBulkCopy.ColumnMappings.Add("Column26", "DIA_20");
                        sqlBulkCopy.ColumnMappings.Add("Column27", "DIA_21");
                        sqlBulkCopy.ColumnMappings.Add("Column28", "DIA_22");
                        sqlBulkCopy.ColumnMappings.Add("Column29", "DIA_23");
                        sqlBulkCopy.ColumnMappings.Add("Column30", "DIA_24");
                        sqlBulkCopy.ColumnMappings.Add("Column31", "DIA_25");
                        sqlBulkCopy.ColumnMappings.Add("Column32", "DIA_26");
                        sqlBulkCopy.ColumnMappings.Add("Column33", "DIA_27");
                        sqlBulkCopy.ColumnMappings.Add("Column34", "DIA_28"); 
                        sqlBulkCopy.ColumnMappings.Add("Column35", "DIA_29");                       

                        if (dgTareo.Columns.Count >= 36)
                        {
                            sqlBulkCopy.ColumnMappings.Add("Column36", "DIA_30");
                        }

                        if (dgTareo.Columns.Count >= 37)
                        {
                            sqlBulkCopy.ColumnMappings.Add("Column37", "DIA_31");
                        }



                        //sqlBulkCopy.ColumnMappings.Add("Column36", "DIA_30");
                      //  sqlBulkCopy.ColumnMappings.Add("Column37", "DIA_31");

                        //sqlBulkCopy.ColumnMappings.Add("Country", "Country");
                        //con.Open();
                        sqlBulkCopy.WriteToServer(dt);

                        string sqlUpd =
                        "UPDATE TAREO_EMPLEADOS_TMP SET MES = " + cboMes.SelectedValue.ToString() + " , ANIO =  " + cboAnio.SelectedValue.ToString() + " , UBICACION =  0" + cboUbicacion.SelectedValue.ToString() + " , EMPRESA =  000" + cboEmpresa.SelectedValue.ToString();
                        SqlCommand cmd2 = new SqlCommand(sqlUpd, con);
                        //con.Open();
                        cmd2.ExecuteNonQuery();

                        BL_TAREO_EMPLEADO obj = new BL_TAREO_EMPLEADO();
                        DataTable dtResultado = new DataTable();
                        dtResultado = obj.SP_ACTUALIZAR_TB_EMP(cboEmpresa.SelectedValue.ToString(), cboMes.SelectedValue.ToString(), cboAnio.SelectedValue.ToString(), cboUbicacion.SelectedValue.ToString());



                        MessageBox.Show("Registro Exitoso!");

                        con.Close();
                        //if (dtResultado.Rows[0]["TOTAL"].ToString() == "0")
                        //{
                        //    return;
                        //}

                    }
                }

                Listar();
            }
        }

        private void grabarGrillaAutomatico()
        {

            DataTable dt = GetDataTableFromDGV(dgTareo);


            if (dt.Rows.Count > 0)
            {
                string consString = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
                using (SqlConnection con = new SqlConnection(consString))
                {
                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                    {
                        string sqlTrunc = "TRUNCATE TABLE TAREO_EMPLEADOS_TMP";
                        SqlCommand cmd = new SqlCommand(sqlTrunc, con);
                        con.Open();
                        cmd.ExecuteNonQuery();


                        //Set the database table name
                        sqlBulkCopy.DestinationTableName = "dbo.TAREO_EMPLEADOS_TMP";

                        //[OPTIONAL]: Map the DataTable columns with that of the database table
                        sqlBulkCopy.ColumnMappings.Add("Column2", "DNI_EMPLEADO");
                        sqlBulkCopy.ColumnMappings.Add("Column7", "DIA_1");
                        sqlBulkCopy.ColumnMappings.Add("Column8", "DIA_2");
                        sqlBulkCopy.ColumnMappings.Add("Column9", "DIA_3");
                        sqlBulkCopy.ColumnMappings.Add("Column10", "DIA_4");
                        sqlBulkCopy.ColumnMappings.Add("Column11", "DIA_5");
                        sqlBulkCopy.ColumnMappings.Add("Column12", "DIA_6");
                        sqlBulkCopy.ColumnMappings.Add("Column13", "DIA_7");
                        sqlBulkCopy.ColumnMappings.Add("Column14", "DIA_8");
                        sqlBulkCopy.ColumnMappings.Add("Column15", "DIA_9");
                        sqlBulkCopy.ColumnMappings.Add("Column16", "DIA_10");
                        sqlBulkCopy.ColumnMappings.Add("Column17", "DIA_11");
                        sqlBulkCopy.ColumnMappings.Add("Column18", "DIA_12");
                        sqlBulkCopy.ColumnMappings.Add("Column19", "DIA_13");
                        sqlBulkCopy.ColumnMappings.Add("Column20", "DIA_14");
                        sqlBulkCopy.ColumnMappings.Add("Column21", "DIA_15");
                        sqlBulkCopy.ColumnMappings.Add("Column22", "DIA_16");
                        sqlBulkCopy.ColumnMappings.Add("Column23", "DIA_17");
                        sqlBulkCopy.ColumnMappings.Add("Column24", "DIA_18");
                        sqlBulkCopy.ColumnMappings.Add("Column25", "DIA_19");
                        sqlBulkCopy.ColumnMappings.Add("Column26", "DIA_20");
                        sqlBulkCopy.ColumnMappings.Add("Column27", "DIA_21");
                        sqlBulkCopy.ColumnMappings.Add("Column28", "DIA_22");
                        sqlBulkCopy.ColumnMappings.Add("Column29", "DIA_23");
                        sqlBulkCopy.ColumnMappings.Add("Column30", "DIA_24");
                        sqlBulkCopy.ColumnMappings.Add("Column31", "DIA_25");
                        sqlBulkCopy.ColumnMappings.Add("Column32", "DIA_26");
                        sqlBulkCopy.ColumnMappings.Add("Column33", "DIA_27");
                        sqlBulkCopy.ColumnMappings.Add("Column34", "DIA_28");
                        sqlBulkCopy.ColumnMappings.Add("Column35", "DIA_29");
                        
                        if (dgTareo.Columns.Count >= 36)
                        {
                            sqlBulkCopy.ColumnMappings.Add("Column36", "DIA_30");
                        }

                        if (dgTareo.Columns.Count >= 37)
                        {
                            sqlBulkCopy.ColumnMappings.Add("Column37", "DIA_31");
                        }



                        //sqlBulkCopy.ColumnMappings.Add("Country", "Country");
                        //con.Open();
                        sqlBulkCopy.WriteToServer(dt);

                        string sqlUpd =
                      "UPDATE TAREO_EMPLEADOS_TMP SET MES = " + cboMes.SelectedValue.ToString() + " , ANIO =  " + cboAnio.SelectedValue.ToString() + " , UBICACION =  0" + cboUbicacion.SelectedValue.ToString() + " , EMPRESA =  000" + cboEmpresa.SelectedValue.ToString();
                        
                        SqlCommand cmd2 = new SqlCommand(sqlUpd, con);
                        //con.Open();
                        cmd2.ExecuteNonQuery();

                        BL_TAREO_EMPLEADO obj = new BL_TAREO_EMPLEADO();
                        DataTable dtResultado = new DataTable();
                        dtResultado = obj.SP_ACTUALIZAR_TB_EMP(cboEmpresa.SelectedValue.ToString(), cboMes.SelectedValue.ToString(), cboAnio.SelectedValue.ToString(), cboUbicacion.SelectedValue.ToString());



                        //MessageBox.Show("Registro Exitoso!");

                        con.Close();

                        colorCelda();
                        //if (dtResultado.Rows[0]["TOTAL"].ToString() == "0")
                        //{
                        //    return;
                        //}

                    }
                }

              //  Listar();
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

        private void dgTareo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.Value != null) && (e.Value.ToString().Length != 0))
            {
                e.Value = e.Value.ToString().ToUpper();
                e.FormattingApplied = true;
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {


        }




        private void btnCerrarTareo_Click(object sender, EventArgs e)
        {
            if (verificarTodoTareado() == 1)
            {
                //MessageBox.Show("return");
                return;

            }
            BL_TAREO_EMPLEADO obj = new BL_TAREO_EMPLEADO();
            DataTable dtResultado = new DataTable();
            dtResultado = obj.SP_CERRAR_PERIODO_EMPLEADOS(cboEmpresa.SelectedValue.ToString(), cboMes.SelectedValue.ToString(), cboAnio.SelectedValue.ToString(), cboUbicacion.SelectedValue.ToString());

            if (dtResultado.Rows.Count > 0)
            {
                MessageBox.Show("Periodo Cerrado");

            }

            buscarEmpleados();

            verificarEstadoTareoEmp();
        }

        int verificarTodoTareado()
        {
            int flg = 0;

            for (int i = 0; i < dgTareo.Columns.Count; i++)
            {
                String header = dgTareo.Columns[i].HeaderText;
                if (header.Contains("-L"))
                { 
                    foreach (DataGridViewRow row in dgTareo.Rows)
                    {
                        if (row.Cells[i].Value.ToString().Trim().Equals("")) {

                            row.Cells[i].Style.BackColor = Color.Red;

                            flg = 1;
                        }

                    } 
                }

                if (header.Contains("-M"))
                {
                    foreach (DataGridViewRow row in dgTareo.Rows)
                    {
                        if (row.Cells[i].Value.ToString().Trim().Equals(""))
                        {

                            row.Cells[i].Style.BackColor = Color.Red;

                            flg = 1;
                        }

                    }

                }
                if (header.Contains("-X"))
                {
                    foreach (DataGridViewRow row in dgTareo.Rows)
                    {
                        if (row.Cells[i].Value.ToString().Trim().Equals(""))
                        {

                            row.Cells[i].Style.BackColor = Color.Red;

                            flg = 1;
                        }

                    }

                }
                if (header.Contains("-J"))
                {
                    foreach (DataGridViewRow row in dgTareo.Rows)
                    {
                        if (row.Cells[i].Value.ToString().Trim().Equals(""))
                        {

                            row.Cells[i].Style.BackColor = Color.Red;

                            flg = 1;
                        }

                    }

                }
                if (header.Contains("-V"))
                {
                    foreach (DataGridViewRow row in dgTareo.Rows)
                    {
                        if (row.Cells[i].Value.ToString().Trim().Equals(""))
                        {

                            row.Cells[i].Style.BackColor = Color.Red;

                            flg = 1;
                        }

                    }

                }

                if (header.Contains("-S"))
                {
                    foreach (DataGridViewRow row in dgTareo.Rows)
                    {
                        if (row.Cells[i].Value.ToString().Trim().Equals(""))
                        {
                            if (cboUbicacion.Text.ToString().Contains("OF"))
                            {

                            }
                            else
                            {
                                row.Cells[i].Style.BackColor = Color.Red;

                                flg = 1;
                            }
                        }

                    }

                }

                if (header.Contains("-D"))
                {
                    foreach (DataGridViewRow row in dgTareo.Rows)
                    {
                        if (row.Cells[i].Value.ToString().Trim().Equals(""))
                        {

                            row.Cells[i].Style.BackColor = Color.Red;

                            flg = 1;
                        }

                    }

                }

            }

            if (flg == 1) {

                MessageBox.Show("Existen personas sin tareo, las celdas estan de rojo");
                
            }

            return flg;
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            BL_TAREO_EMPLEADO obj = new BL_TAREO_EMPLEADO();
            DataTable dtResultado = new DataTable();
            dtResultado = obj.SP_IMPORTAR_EMPLEADOS(cboEmpresa.SelectedValue.ToString(), cboMes.SelectedValue.ToString(), cboAnio.SelectedValue.ToString(), cboUbicacion.SelectedValue.ToString());

            if (dtResultado.Rows.Count > 0)
            {
                MessageBox.Show("No se encontraron registros para la consulta");
                
            }

            buscarEmpleados();

            verificarEstadoTareoEmp();
        }

        private void dgTareo_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            grabarGrilla();
        }

        private void cboUbicacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            EstadoDiario();
            btnCerrarTareo.Visible = false;
            btn_Excel.Visible = false;
            btnGrabar.Visible = false;
            btnImportar.Visible = false;
            btnMPL.Visible = false;
            btnMPO.Visible = false;
            btnCerrarTareo.Visible = false;
            btnGrabar.Visible = false;
            btnMp.Visible = false;
            btnExcelDetalle.Visible = false;
            dgTareo.DataSource = null;

        }

        private void cboEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargaUbicaciones();
            btn_Excel.Visible = false;
            btnMPL.Visible = false;
            btnMPO.Visible = false;
            btnCerrarTareo.Visible = false;
            btnGrabar.Visible = false;
            btnMp.Visible = false;
            dgTareo.DataSource = null;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btn_Excel_Click(object sender, EventArgs e)
        {
            BL_TAREO_EMPLEADO obj = new BL_TAREO_EMPLEADO();
            DataTable dtResultado = new DataTable();
            dtResultado = obj.SP_REPORTE_EMPLEADOS(cboEmpresa.SelectedValue.ToString(), cboMes.SelectedValue.ToString(), cboAnio.SelectedValue.ToString(), cboUbicacion.SelectedValue.ToString());

            if (dtResultado.Rows.Count > 0)
            { 
                dgReporte.DataSource = dtResultado;
              
            }

            DateTime dateTime = DateTime.UtcNow.Date;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "Reporte_Tareo_Empleados"+ cboEmpresa.SelectedValue.ToString() +"_"+ cboUbicacion.SelectedValue.ToString()+"_"+ dateTime.ToString("ddMMyyyy") + ".xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //ToCsV(dataGridView1, @"c:\export.xls");
                ToCsV(dgReporte, sfd.FileName); // Here dataGridview1 is your grid view name
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

        private void dgTareo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void dgTareo_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dgTareo_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
             
        }

        private void dgTareo_CellLeave_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgTareo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void btnMPO_Click(object sender, EventArgs e)
        {
            //foreach (DataGridViewRow row in dgTareo.Rows)
            //{
                for (int i = 0; i < dgTareo.Columns.Count; i++)
                {
                    String header = dgTareo.Columns[i].HeaderText;


                if (header.Contains("-S"))
                {

                    //MessageBox.Show("si "+ header);
                    foreach (DataGridViewRow row in dgTareo.Rows)
                    {
                        if (row.Cells[i].Style.BackColor != Color.Gray)
                        {
                            row.Cells[i].Value = "X";
                        }
                    }

                }

                if (header.Contains("-D"))
                {
                    foreach (DataGridViewRow row in dgTareo.Rows)
                    {
                        if (row.Cells[i].Style.BackColor != Color.Gray)
                        {
                            row.Cells[i].Value = "DSO";
                        }
                    }

                }
            }
            //}
        }

        private void btnMPL_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgTareo.Columns.Count; i++)
            {
                String header = dgTareo.Columns[i].HeaderText;
                if (header.Contains("-S"))
                {

                    //MessageBox.Show("si "+ header);
                    foreach (DataGridViewRow row in dgTareo.Rows)
                    {
                        if (row.Cells[i].Style.BackColor != Color.Gray)
                        {
                            row.Cells[i].Value = "";
                        }
                    }

                }

                if (header.Contains("-D"))
                {
                    foreach (DataGridViewRow row in dgTareo.Rows)
                    {
                        if (row.Cells[i].Style.BackColor != Color.Gray)
                        {
                            row.Cells[i].Value = "DSO";
                        }
                    }

                }
                if (header.Contains("-S"))
                {
                    foreach (DataGridViewRow row in dgTareo.Rows)
                    {
                        if (row.Cells[i].Style.BackColor != Color.Gray)
                        {
                            row.Cells[i].Value = "DSO";
                        }
                    }

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgTareo.Columns.Count; i++)
            {
                String header = dgTareo.Columns[i].HeaderText;
                if (header.Contains("-L"))
                {

                    //MessageBox.Show("si "+ header);
                    foreach (DataGridViewRow row in dgTareo.Rows)
                    {
                        if (row.Cells[i].Style.BackColor != Color.Gray)
                        {
                        if (cboUbicacion.Text.ToString().Contains("OF"))
                        {                           

                            row.Cells[i].Value = "H";

                        }
                        else {

                            row.Cells[i].Value = "X";

                        }
                        }
                    }

                }

                if (header.Contains("-M"))
                {
                    foreach (DataGridViewRow row in dgTareo.Rows)
                    {
                        if (row.Cells[i].Style.BackColor != Color.Gray)
                        {
                            if (cboUbicacion.Text.ToString().Contains("OF"))
                            {

                                row.Cells[i].Value = "H";

                            }
                            else
                            {

                                row.Cells[i].Value = "X";

                            }
                        }
                    }

                }
                if (header.Contains("-X"))
                {
                    foreach (DataGridViewRow row in dgTareo.Rows)
                    {
                        if (row.Cells[i].Style.BackColor != Color.Gray)
                        {
                            if (cboUbicacion.Text.ToString().Contains("OF"))
                            {

                                row.Cells[i].Value = "H";

                            }
                            else
                            {

                                row.Cells[i].Value = "X";

                            }
                        }

                    }

                }
                if (header.Contains("-J"))
                {
                    foreach (DataGridViewRow row in dgTareo.Rows)
                    {
                        if (row.Cells[i].Style.BackColor != Color.Gray)
                        {
                            if (cboUbicacion.Text.ToString().Contains("OF"))
                            {

                                row.Cells[i].Value = "H";

                            }
                            else
                            {

                                row.Cells[i].Value = "X";

                            }
                        }

                    }

                }
                if (header.Contains("-V"))
                {
                    foreach (DataGridViewRow row in dgTareo.Rows)
                    {
                        if (row.Cells[i].Style.BackColor != Color.Gray)
                        {
                            if (cboUbicacion.Text.ToString().Contains("OF"))
                            {

                                row.Cells[i].Value = "H";

                            }
                            else
                            {

                                row.Cells[i].Value = "X";

                            }
                        }

                    }

                }

                if (header.Contains("-S"))
                {

                    foreach (DataGridViewRow row in dgTareo.Rows)
                    {
                        if (row.Cells[i].Style.BackColor != Color.Gray)
                        {
                            row.Cells[i].Value = "";
                        }
                    }

                }

                if (header.Contains("-D"))
                {
                    foreach (DataGridViewRow row in dgTareo.Rows)
                    {
                        if (row.Cells[i].Style.BackColor != Color.Gray)
                        {
                            row.Cells[i].Value = "";
                        }
                    }

                }

            }
        }

        private void dgTareo_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            bloquearCelda();
            colorCelda();
        }

        void colorCelda() {

            string MES = cboMes.SelectedValue.ToString();
            MES = MES.PadLeft(2, '0');

            string date = "01/" + MES + "/" + cboAnio.SelectedValue.ToString();
            DateTime now = Convert.ToDateTime(date);

            var startDate = new DateTime(now.Year, now.Month, 1); // iniciar el primer día de mes
                                                                  // Establecer esta variable al Calendar
            var endDate = startDate.AddMonths(1).AddDays(-1); // este es el último día del mes en curso.


            int maxcolum = dgTareo.Columns.Count;
            int maxRows = dgTareo.RowCount;
            string VALOR;
            for (int i = 0; i < maxRows; i++)
            {
                DataGridViewRow Rows = dgTareo.Rows[i];
                for (int j = 6; j < maxcolum; j++)
                {
                    dgTareo.Columns[j].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    
                            VALOR = (Rows.Cells[j].Value == null) ? "0" : Rows.Cells[j].Value.ToString();

                            BE_UBICACIONES_ESTADO result = LstEstadoDiario.Find(
                            delegate (BE_UBICACIONES_ESTADO bk)
                            {
                                if (bk.ABREVIATURA.ToUpper() == VALOR.ToUpper())
                                {
                                    VALOR = bk.COLOR_FONDO;
                                }
                                return bk.COLOR_FONDO == VALOR;
                            }
                            );

                            if (result != null)
                            {
                                string VALORzx = VALOR;
                                dgTareo.Rows[i].Cells[j].Style.BackColor = ColorTranslator.FromHtml(VALOR);
                            }
                        }
                   
                }

            }

        private void button1_Click_1(object sender, EventArgs e)
        {
            BL_TAREO_EMPLEADO obj = new BL_TAREO_EMPLEADO();
            DataTable dtResultado = new DataTable();
            dtResultado = obj.SP_REPORTE_EMPLEADOS_DETALLE(cboEmpresa.SelectedValue.ToString(), cboMes.SelectedValue.ToString(), cboAnio.SelectedValue.ToString(), cboUbicacion.SelectedValue.ToString());

            if (dtResultado.Rows.Count > 0)
            {

                //gridDetalle.Rows.Clear();
                //gridDetalle.Columns.Clear();
                //gridDetalle.Refresh();
                dgTareo.DataSource = null;
                dgTareo.DataSource = dtResultado;
                dgTareo.AutoResizeColumns();
                dgTareo.Visible = true;




                dgTareo.AllowUserToAddRows = true;
                //ALINEACIONES 

                dgTareo.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //dgTareo.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgTareo.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;//APELLIDOS
                dgTareo.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.TopLeft;
                dgTareo.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgTareo.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgTareo.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //COLORES

                dgTareo.Columns[0].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#fff451");
                dgTareo.Columns[1].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#fff451");
                dgTareo.Columns[2].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#fff451");

                //dgTareo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgTareo.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                //ANCHO

                DataGridViewColumn

                column = dgTareo.Columns[0]; column.Width = 20;
                //column = dgTareo.Columns[1]; column.Width = 60;
                //    column = dgTareo.Columns[2]; column.Width = 80;
                //column = dgTareo.Columns[3]; column.Width = 40;
                column = dgTareo.Columns[4]; column.Width = 57;
                column = dgTareo.Columns[5]; column.Width = 69;
                //column = dgTareo.Columns[6]; column.Width = 0;
                //column = dgTareo.Columns[7]; column.Width = 0;

                column = dgTareo.Columns[6]; column.Width = 30;
                column = dgTareo.Columns[7]; column.Width = 30;
                column = dgTareo.Columns[8]; column.Width = 30;
                column = dgTareo.Columns[9]; column.Width = 30;
                column = dgTareo.Columns[10]; column.Width = 30;
                column = dgTareo.Columns[11]; column.Width = 30;
                column = dgTareo.Columns[12]; column.Width = 30;
                column = dgTareo.Columns[13]; column.Width = 30;
                column = dgTareo.Columns[14]; column.Width = 30;
                column = dgTareo.Columns[15]; column.Width = 30;
                column = dgTareo.Columns[16]; column.Width = 30;
                column = dgTareo.Columns[17]; column.Width = 30;
                column = dgTareo.Columns[18]; column.Width = 30;
                column = dgTareo.Columns[19]; column.Width = 30;
                column = dgTareo.Columns[20]; column.Width = 30;
                column = dgTareo.Columns[21]; column.Width = 30;
                column = dgTareo.Columns[22]; column.Width = 30;
                column = dgTareo.Columns[23]; column.Width = 30;
                column = dgTareo.Columns[24]; column.Width = 30;
                column = dgTareo.Columns[25]; column.Width = 30;
                column = dgTareo.Columns[26]; column.Width = 30;
                column = dgTareo.Columns[27]; column.Width = 30;
                column = dgTareo.Columns[28]; column.Width = 30;
                column = dgTareo.Columns[29]; column.Width = 30;
                column = dgTareo.Columns[30]; column.Width = 30;
                column = dgTareo.Columns[31]; column.Width = 30;
                column = dgTareo.Columns[32]; column.Width = 30;
                column = dgTareo.Columns[33]; column.Width = 30;
                column = dgTareo.Columns[34]; column.Width = 30;




                //dgTareo.Columns[8].Visible = true;
                //dgTareo.Columns[9].Visible= true;



                string MES = cboMes.SelectedValue.ToString();
                MES = MES.PadLeft(2, '0');

                string date = "01/" + MES + "/" + cboAnio.SelectedValue.ToString();
                DateTime now = Convert.ToDateTime(date);

                var startDate = new DateTime(now.Year, now.Month, 1); // iniciar el primer día de mes
                                                                      // Establecer esta variable al Calendar
                var endDate = startDate.AddMonths(1).AddDays(-1); // este es el último día del mes en curso.


                int maxcolum = dgTareo.Columns.Count;
                int maxRows = dtResultado.Rows.Count;
                string VALOR;
                for (int i = 0; i < maxRows; i++)
                {
                    DataGridViewRow Rows = dgTareo.Rows[i];
                    for (int j = 6; j < maxcolum; j++)
                    {
                        dgTareo.Columns[j].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                        VALOR = (Rows.Cells[j].Value == null) ? "0" : Rows.Cells[j].Value.ToString();

                        BE_UBICACIONES_ESTADO result = LstEstadoDiario.Find(
                        delegate (BE_UBICACIONES_ESTADO bk)
                        {
                            if (bk.ABREVIATURA.ToUpper() == VALOR.ToUpper())
                            {
                                VALOR = bk.COLOR_FONDO;
                            }
                            return bk.COLOR_FONDO == VALOR;
                        }
                        );

                        if (result != null)
                        {
                            string VALORzx = VALOR;
                            dgTareo.Rows[i].Cells[j].Style.BackColor = ColorTranslator.FromHtml(VALOR);
                        }
                    }
                }


                dgTareo.AllowUserToAddRows = false;

                dgTareo.Columns[0].Frozen = true;
                dgTareo.Columns[1].Frozen = true;
                dgTareo.Columns[2].Frozen = true;

                dgTareo.Columns[0].ReadOnly = true;
                dgTareo.Columns[1].ReadOnly = true;
                dgTareo.Columns[2].ReadOnly = true;
                dgTareo.Columns[3].ReadOnly = true;
                dgTareo.Columns[4].ReadOnly = true;
                dgTareo.Columns[5].ReadOnly = true;


                //btn_Excel.Visible = true;
                //btnMPL.Visible = true;
                //btnMPO.Visible = true;
                //btnCerrarTareo.Visible = true; 
                //btnGrabar.Visible = true;

                if (cboUbicacion.SelectedValue.ToString().Equals("999"))
                {
                    btnExcelDetalle.Visible = true;
                }

                bloquearCeldaTodas();
                btnGrabar.Visible = false;
            }
            else
            {
                lblEstado.Text = "-----------------------";
                dgTareo.DataSource = null;
                //     btnExportar.Visible = false;
                MessageBox.Show("No se encontraron registros para la consulta");
                return;
            }   
        }
        private void bloquearCeldaTodas()
        {
            BL_TAREO_EMPLEADO obj = new BL_TAREO_EMPLEADO();
            DataTable dtResultado = new DataTable();
            int rowIndex = -1;
            dtResultado = obj.SP_DESMOVILIZACIONES_UBICACION_TODAS(cboMes.SelectedValue.ToString(), cboAnio.SelectedValue.ToString(), cboUbicacion.SelectedValue.ToString(), cboEmpresa.SelectedValue.ToString());

            if (dtResultado.Rows.Count > 0)
            {

                String dni, dia,ubicacion, claveFila,claveGrilla;

                dni = "";


                try
                {

                    foreach (DataRow row in dtResultado.Rows)
                    {
                        dni = row["IDE_USUARIO"].ToString();
                        ubicacion = row["UBICACION"].ToString();
                        dia = row["DIA"].ToString();

                        claveFila = dni + "-" + ubicacion;

                        //MessageBox.Show("fila del sp : " + row );

                        String searchValue = dni; 
                      
                        foreach (DataGridViewRow row2 in dgTareo.Rows)
                        {
                            //MessageBox.Show("fila de la grilla : " + row2);

                            string[] split = System.Text.RegularExpressions.Regex.Split(row2.Cells[3].Value.ToString(), @"-");

                            claveGrilla = row2.Cells[1].Value.ToString() + "-" + split[0].Trim();

                            //if (row2.Cells[1].Value.ToString().Equals(searchValue)    )

                            if (claveFila.Equals(claveGrilla))

                            {
                                //if (split[0].Trim().Contains(ubicacion))
                               
                                    rowIndex = row2.Index;
                                    dgTareo.Rows[row2.Index].Cells[int.Parse(dia) + 5].Style.BackColor = Color.Gray;
                                    dgTareo.Rows[row2.Index].Cells[int.Parse(dia) + 5].ReadOnly = true;
                                    dgTareo.Rows[row2.Index].Cells[int.Parse(dia) + 5].Style.ForeColor = Color.Gray;
                                dgTareo.Rows[row2.Index].Cells[int.Parse(dia) + 5].Value = "";
                                //break;
                                //}

                            }
                    }
                }

                 }



                catch (Exception e)
                {
                }

            }
        }
    }
} 
