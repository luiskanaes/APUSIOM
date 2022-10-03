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

namespace WinForms
{
    public partial class frmTareoDiario : Form
    {
        string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
        String DirectorioFile = ConfigurationManager.AppSettings["FileTareos"];
        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());
        public static BE_ASIGNACION_TAREAS obj_asignacion_E;

        decimal HoraMaxima = 24;
        decimal BonoMaxima = 24;
        decimal EstDiario = 0;// horas por dia de jornada
        string AsistenciaPersona;
        public frmTareoDiario()
        {
            InitializeComponent();
            ListarEmpresa();
        }

        private void frmTareoDiario_Load(object sender, EventArgs e)
        {
            
        }
        protected void ListarEmpresa()
        {
            BL_FUNCIONES obj = new BL_FUNCIONES();
            DataTable dtResultado = new DataTable();
            dtResultado = obj.ListarEmpresaPerfil(frmLogin.obj_perfil_E.IdPerfil, frmLogin.obj_user_E.IDE_USUARIO);
            if (dtResultado.Rows.Count > 0)
            {

                cboEmpresa.ValueMember = "ID";
                cboEmpresa.DisplayMember = "DESCRIPCION";
                cboEmpresa.DataSource = dtResultado;
                ListarCesos();
            }
        }
        protected void ListarCesos()
        {
            int anio = DateTime.Now.Year;
            BL_FUNCIONES obj = new BL_FUNCIONES();
            DataTable dtResultado = new DataTable();
            dtResultado = obj.ListarCesosPerfil(frmLogin.obj_perfil_E.IdPerfil, frmLogin.obj_user_E.IDE_USUARIO, Convert.ToInt32(cboEmpresa.SelectedValue));
            if (dtResultado.Rows.Count > 0)
            {
                cboCentroCosto.ValueMember = "ID";
                cboCentroCosto.DisplayMember = "CECOS";
                cboCentroCosto.DataSource = dtResultado;
                //ListarIngenieros();
            }
        }

        private void cboEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarCesos();
        }
       
       

        private void cboCentroCosto_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ListarIngenieros();
            //listarCuadrilla();
        }

        

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            consultarDia();


            //ListarIngenieros();
        }
        protected void consultarDia()
        {
            string dia = dateTareo.Value.Date.ToString("dddd").ToUpper();

            if (dia == "SÁBADO")
            {
                BL_ASIGNACION_TAREO obj = new BL_ASIGNACION_TAREO();
                DataTable dtResultado = new DataTable();
                dtResultado = obj.SP_CONSULTAR_FLG_100(cboCentroCosto.SelectedValue.ToString(), dia);
                if (dtResultado.Rows.Count > 0)
                {
                    obj.SP_CERRAR_DIA_TRABAJO(cboCentroCosto.SelectedValue.ToString(), dateTareo.Value.Date.ToString("dd/MM/yyyy"));
                }
            }

            //Procesar_domingos_feriados();//PARA GENERAR ASISTENCIAS
            ConsultarTareo();
        }

        protected void ConsultarTareo()
        {

            BL_ASIGNACION_TAREO obj = new BL_ASIGNACION_TAREO();
            DataTable dtResultado = new DataTable();
            cboEstado.Items.Clear();
            cboEstado.Text = string.Empty;

            cboMigrar.Items.Clear();
            cboMigrar.Text = string.Empty;

            dtResultado = obj.Listar_TareoFecha(Convert.ToInt32(cboEmpresa.SelectedValue.ToString()), cboCentroCosto.SelectedValue.ToString(), dateTareo.Value.Date.ToString("dd/MM/yyyy"));
            JornadasHoras();//FERIADOS
            if (dtResultado.Rows.Count > 0)
            {
                groupControles.Visible = true;
                cboEstado.SelectedText = dtResultado.Rows[0]["ESTADO"].ToString();
                cboMigrar.SelectedText = dtResultado.Rows[0]["ESTADO_MIGRACION"].ToString();
                string FLG_ESTADO = dtResultado.Rows[0]["FLG_ESTADO"].ToString();
                string FLG_MIGRADO = dtResultado.Rows[0]["FLG_MIGRADO"].ToString();
                lblEstado.Text = FLG_ESTADO;
                if (Convert.ToBoolean(FLG_MIGRADO) == false )
                {
                    
                    btnAbrir.Visible = true ;
                    btnCerrar.Visible = true ;
                    
                    if (FLG_ESTADO == "1")
                    {
                        Procesar_domingos_feriados();//procesar feridos
                        btnProcesar.Visible = false;
                      
                    }
                    else
                    {
                        btnProcesar.Visible = true;
                        
                    }
                    
                }
                else
                {
                    btnAdvertencia.Visible = false;
                    btnProcesar.Visible = false;
          
                    btnAbrir.Visible = false;
                    btnCerrar.Visible = false;
                }

                consultarGrilla();
            }
            else
            {
                BL_ASIGNACION_TAREO xobj = new BL_ASIGNACION_TAREO();
                DataTable xdtResultado = new DataTable();


                xdtResultado = xobj.SP_INSERT_ASIGNACION_TAREO(Convert.ToInt32(cboEmpresa.SelectedValue.ToString()), 
                    cboCentroCosto.SelectedValue.ToString(), dateTareo.Value.Date.ToString("dd/MM/yyyy"), 
                    frmLogin.obj_user_E.IDE_USUARIO, dateTareo.Value.Date.ToString("dddd"));

                consultarDia();

                //gridDetalle.Rows.Clear();
                //gridDetalle.Columns.Clear();
                //gridDetalle.Refresh();
                //groupControles.Visible = false;
                //cboEstado.SelectedText = "No registra informacion";
                //cboMigrar.SelectedText = "No registra informacion";
                //btnProcesar.Visible = false;
                //btnAbrir.Visible = false;
                //btnCerrar.Visible = false;
            }
            //consultarGrilla();ccs
            //listarCuadrilla();ccs
        }
        protected void listarCuadrilla()
        {
            try
            {
                BL_ASIGNACION_TAREAS xobj = new BL_ASIGNACION_TAREAS();
                DataTable dtResultado = new DataTable();
                dtResultado = xobj.Listar_ActividadAsignadas(cboEmpresa.SelectedValue.ToString(), cboCentroCosto.SelectedValue.ToString(), null, dateTareo.Value.Date.ToString("dd/MM/yyyy"), "", "");


                if (dtResultado.Rows.Count > 0)
                {
                    gridDetalle.Visible = true;
                    //DetalleTrabajos();
                    consultarGrilla();
                }
                else
                {
                    //gridDetalle.Visible = false;
                    gridDetalle.Rows.Clear();
                    gridDetalle.Refresh();
                    consultarGrilla();
                }
            }
            catch (Exception ex)
            {

            }


        }
      
        protected void procesar_dia()
        {
            if (AccesoInternet())
            {

                DialogResult respuesta = MessageBox.Show("¿Desea procesar tareo del día " + dateTareo.Value.Date.ToString("dd/MM/yyyy"), "Mensaje SSK", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (respuesta == DialogResult.Yes)
                {
                    
                    DataTable dtResultado = new DataTable();
                    int procesos = 0;
                    BL_TAREO obj = new BL_TAREO();
                    DataTable dt = new DataTable();
                    DataTable dtGestorP1 = new DataTable();
                    DataTable dtGestorP2 = new DataTable();

                    dtResultado = obj.uspWCF_SELECT_PERIODO(Convert.ToInt32(cboEmpresa.SelectedValue), cboCentroCosto.SelectedValue.ToString(), dateTareo.Value.Date.ToString("dd/MM/yyyy"));

                 

                    if (dtResultado.Rows[0]["ESTADO"].ToString() == "SI")
                    {



                        dtGestorP1 = obj.SP_GENERAR_TAREO_CONSOLIDADO(cboCentroCosto.SelectedValue.ToString(), dateTareo.Value.Date.ToString("dd/MM/yyyy"));
                        if (dtGestorP1.Rows.Count > 0)
                        {
                            if (dtGestorP1.Rows[0]["ESTADO"].ToString() == "1")
                            {
                                procesos++;
                            }
                            else
                            {
                                procesos = 0;
                            }
                        }

                        dtGestorP2 = obj.SP_GENERAR_TAREO_CONSOLIDADO_DETALLE(cboCentroCosto.SelectedValue.ToString(), dateTareo.Value.Date.ToString("dd/MM/yyyy"));
                        if (dtGestorP2.Rows.Count > 0)
                        {
                            if (dtGestorP2.Rows[0]["ESTADO"].ToString() == "1")
                            {
                                procesos++;
                            }
                            else
                            {
                                procesos = 0;
                            }
                        }

                        if (procesos == 2)
                        {
                            BL_TAREO objx = new BL_TAREO();
                            objx.UpdateMigracion(Convert.ToInt32(cboEmpresa.SelectedValue.ToString()), cboCentroCosto.SelectedValue.ToString(), dateTareo.Value.Date.ToString("dd/MM/yyyy"));

                            objx.SP_CORREO_CIERRE_TAREO_DIA(cboCentroCosto.SelectedValue.ToString(), dateTareo.Value.Date.ToString("dd/MM/yyyy"), frmLogin.obj_user_E.IDE_USUARIO);
                            ConsultarTareo();
                            MessageBox.Show("Proceso satisfactorio", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            MessageBox.Show("Existen problemas con la migración de registros", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }

                        //FIN CCS
                    }
                    else
                    {
                        MessageBox.Show("Fecha no permitida para la migración ", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                  
                }
            }
            else
            {
                MessageBox.Show("Sin acceso a internet", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void btnProcesar_Click(object sender, EventArgs e)
        {
            // PARA EL TAREO NORMAL CITRIX
            if (AccesoInternet())
            {
                
                DialogResult respuesta = MessageBox.Show("¿Desea migrar Tareo del día " + dateTareo.Value.Date.ToString("dd/MM/yyyy"), "Mensaje ICSK", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (respuesta == DialogResult.Yes)
                {
                    //SvTareo.TareoClient objServicio = new SvTareo.TareoClient();
                    //string ls_error = "";
                    //bool lb_conectado = objServicio.ProbarConexionTareo(ref ls_error);
                    //if (lb_conectado == true)
                    //{
                        DataTable dtResultado = new DataTable();
                        int procesos = 0;
                        BL_TAREO obj = new BL_TAREO();
                        DataTable dt = new DataTable();
                        DataTable dtGestorP1 = new DataTable();
                        DataTable dtGestorP2 = new DataTable();

                    dtResultado = obj.uspWCF_SELECT_PERIODO(Convert.ToInt32(cboEmpresa.SelectedValue), cboCentroCosto.SelectedValue.ToString(), dateTareo.Value.Date.ToString("dd/MM/yyyy"));

                    //if (Convert.ToInt32(cboEmpresa.SelectedValue) == 1)
                    //{
                    //    dtResultado =  obj.uspWCF_SELECT_PERIODO(Convert.ToInt32(cboEmpresa.SelectedValue), cboCentroCosto.SelectedValue.ToString(), dateTareo.Value.Date.ToString("dd/MM/yyyy"));
                    //}

                    //else
                    //{
                    //    dtResultado = obj.uspWCF_SELECT_PERIODO_SKEX(Convert.ToInt32(cboEmpresa.SelectedValue), cboCentroCosto.SelectedValue.ToString(), dateTareo.Value.Date.ToString("dd/MM/yyyy"));
                    //}


                    if (dtResultado.Rows[0]["ESTADO"].ToString() == "SI")
                        {


                            
                            dtGestorP1 = obj.SP_GENERAR_TAREO_CONSOLIDADO( cboCentroCosto.SelectedValue.ToString(), dateTareo.Value.Date.ToString("dd/MM/yyyy"));
                            if (dtGestorP1.Rows.Count > 0)
                            {
                                if (dtGestorP1.Rows[0]["ESTADO"].ToString() == "1")
                                {
                                    procesos++;
                                }
                                else
                                {
                                    procesos = 0;
                                }
                            }

                            dtGestorP2 = obj.SP_GENERAR_TAREO_CONSOLIDADO_DETALLE(cboCentroCosto.SelectedValue.ToString(), dateTareo.Value.Date.ToString("dd/MM/yyyy"));
                            if (dtGestorP2.Rows.Count > 0)
                            {
                                if (dtGestorP2.Rows[0]["ESTADO"].ToString() == "1")
                                {
                                    procesos++;
                                }
                                else
                                {
                                    procesos = 0;
                                }
                            }

                            if (procesos == 2)
                            {
                                BL_TAREO objx = new BL_TAREO();
                                objx.UpdateMigracion(Convert.ToInt32(cboEmpresa.SelectedValue.ToString()), cboCentroCosto.SelectedValue.ToString(), dateTareo.Value.Date.ToString("dd/MM/yyyy"));

                            objx.SP_CORREO_CIERRE_TAREO_DIA(cboCentroCosto.SelectedValue.ToString(), dateTareo.Value.Date.ToString("dd/MM/yyyy"), frmLogin.obj_user_E.IDE_USUARIO);
                            ConsultarTareo();
                                MessageBox.Show("Proceso satisfactorio", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else
                            {
                                MessageBox.Show("Existen problemas con la migración de registros", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }

                           
                            
                            //FIN CCS
                        }
                        else
                        {
                            MessageBox.Show("Fecha no permitida para la migración ", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    //}
                    //else
                    //{

                    //    MessageBox.Show("Error con la conexion ", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //}
                }
            }
            else
            {
                MessageBox.Show("Sin acceso a internet", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            /* PARA EL TAREO DESCONECTADO
            if (AccesoInternet())
            {
                SvTareo.TareoClient objServicio = new SvTareo.TareoClient();
                string ls_error = "";
                bool lb_conectado = objServicio.ProbarConexionTareo(ref ls_error);

                if (lb_conectado == true)
                {
                    DataTable dtResultado = new DataTable();

                    if (Convert.ToInt32(cboEmpresa.SelectedValue) == 1)
                    {
                        dtResultado = new TareoClient().Get_Estado_PeridoTareo_SSK(Convert.ToInt32(cboEmpresa.SelectedValue), cboCentroCosto.SelectedValue.ToString(), dateTareo.Value.Date.ToString("yyyyMMdd"));
                    }
                    else
                    {
                        dtResultado = new TareoClient().Get_Estado_PeridoTareo_SKEx(Convert.ToInt32(cboEmpresa.SelectedValue), cboCentroCosto.SelectedValue.ToString(), dateTareo.Value.Date.ToString("yyyyMMdd"));
                    }


                    if (dtResultado.Rows[0]["ESTADO"].ToString() == "SI")
                    {
                        obj_asignacion_E = new BE_ASIGNACION_TAREAS();
                        obj_asignacion_E.IDE_EMPRESA = Convert.ToInt32(cboEmpresa.SelectedValue.ToString());
                        obj_asignacion_E.CENTRO_COSTO = cboCentroCosto.SelectedValue.ToString();
                        obj_asignacion_E.FECHA_TAREO = dateTareo.Value.Date.ToString("dd/MM/yyyy");
                        obj_asignacion_E.FECHA_TAREO_FORMAT = dateTareo.Value.Date.ToString("yyyyMMdd");

                        frmMigracionTareo f2 = new frmMigracionTareo(); //creamos un objeto del formulario hijo
                        DialogResult res = f2.ShowDialog();
                        if (f2.varfMigracion > 0)
                        {
                            ConsultarTareo();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Fecha no permitida, para la migración ", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }
                else
                {

                    MessageBox.Show("Error con la conexion ", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            else
            {
                MessageBox.Show("Sin acceso a internet", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            */
        }

        private void rdoTareo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoTareo.Checked)
            {
                rdoGestor.Checked = false;
                rdoGeneral.Checked = false;
            }
            consultarGrilla();
        }

        private void rdoGestor_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoGestor.Checked)
            {
                rdoTareo.Checked = false;
                rdoGeneral.Checked = false;
            }
            
            consultarGrilla();
        }
        protected void consultarGrilla()
        {
            if (lblFeriado.Text == "1")
            {
                DetalleTotalHoras();
            }
            else
            {
                if (rdoGestor.Checked)
                {
                    ListarGestorCuadro("");
                }
                else if (rdoTareo.Checked)

                {
                    DetalleTrabajos("", "");
                }
                else if (rdoGeneral.Checked)
                {
                    DetalleTotalHoras();// NUEVO
                }
            }
        }
        protected void JornadasHoras()
        {
            int anio = DateTime.Now.Year;
            BL_FUNCIONES obj = new BL_FUNCIONES();
            DataTable dtResultado = new DataTable();

            string feriado;
            dtResultado = obj.ListarHrasJorandas(dateTareo.Value.Date.ToString("dd/MM/yyyy"), Convert.ToInt32(cboEmpresa.SelectedValue), dateTareo.Value.Date.ToString("dddd"),cboCentroCosto.SelectedValue.ToString ());
            if (dtResultado.Rows.Count > 0)
            {
                EstDiario = Convert.ToDecimal(dtResultado.Rows[0]["HORAS_TRABAJO"].ToString());
                feriado = dtResultado.Rows[0]["FERIADO"].ToString();
                if (feriado == "1")
                {
                    lblFeriado.Text = "1";
                    gridDetalle.Visible = true;
                    AsistenciaPersona = "F";
                }
                else
                {
                    string dateString = dateTareo.Value.Date.ToString("dddd");
                    if (dateString == "domingo")
                    {
                        lblFeriado.Text = "1";
         
                        feriado = "0";
                    }
                    else
                    {
                        lblFeriado.Text = "0";
                        AsistenciaPersona = string.Empty;
                    }
                }

            }
            else
            {
                AsistenciaPersona = string.Empty;
            }
        }
        protected void ListarGestorCuadro(string capataz)
        {
            gridDetalle.Rows.Clear();
            gridDetalle.Columns.Clear();
            gridDetalle.Refresh();

            DataTable dtResultado = new DataTable();
            BL_TAREO xobj = new BL_TAREO();
            dtResultado = xobj.Listar_CuadroAcumulado(Convert.ToInt32(cboEmpresa.SelectedValue), cboCentroCosto.SelectedValue.ToString(), dateTareo.Value.Date.ToString("dd/MM/yyyy"), capataz ); 
            
             if (dtResultado.Rows.Count > 0)
            {

                gridDetalle.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                gridDetalle.ColumnCount = 14;
                gridDetalle.Columns[0].Name = "Item";
                gridDetalle.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                gridDetalle.Columns[0].Width = 30;

                gridDetalle.Columns[1].Name = "Apellidos y nombres";
                gridDetalle.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                gridDetalle.Columns[2].Name = "Asistencia";
                gridDetalle.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                gridDetalle.Columns[2].Width = 60;

                gridDetalle.Columns[3].Name = "F/E";
                gridDetalle.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                gridDetalle.Columns[3].Width = 50;

                gridDetalle.Columns[4].Name = "Cuenta Costo";
                gridDetalle.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                gridDetalle.Columns[4].Width = 70;

                gridDetalle.Columns[5].Name = "Hrs Total";
                gridDetalle.Columns[5].DefaultCellStyle.BackColor = Color.FromArgb(218, 247, 166);
                gridDetalle.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                gridDetalle.Columns[5].Width  = 50;

                gridDetalle.Columns[6].Name = "Hrs Normales";
                gridDetalle.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                gridDetalle.Columns[6].Width = 50;

                gridDetalle.Columns[7].Name = "Hrs 60";
                gridDetalle.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                gridDetalle.Columns[7].Width = 50;


                gridDetalle.Columns[8].Name = "Hrs 100";
                gridDetalle.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                gridDetalle.Columns[8].Width = 50;

                gridDetalle.Columns[9].Name = "Hrs Falta";
                gridDetalle.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                gridDetalle.Columns[9].Width = 50;

                gridDetalle.Columns[10].Name = "Hrs Altura";
                gridDetalle.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                gridDetalle.Columns[10].Width = 50;

                gridDetalle.Columns[11].Name = "Hrs Agua";
                gridDetalle.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                gridDetalle.Columns[11].Width = 50;

                gridDetalle.Columns[12].Name = "Hrs Nocturnas";
                gridDetalle.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                gridDetalle.Columns[12].Width = 60;

                gridDetalle.Columns[13].Name = "hrs Tunel";
                gridDetalle.Columns[13].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                gridDetalle.Columns[13].Width = 50;


                string NRO, NOMBRE_COMPLETO, ASISTENCIA, H_ASISTENCIA, CUENTA_COSTO, ACUMULADO, HRS_NORMALES, HRS_60, HRS_100, HRS_FALTA,
                        HRS_ALTURA, HRS_AGUA, HRS_NOCTURNA, HRS_TUNEL;
                string[] xrow;



                for (int i = 0; i < dtResultado.Rows.Count; i++)
                {

                    NRO = dtResultado.Rows[i]["NRO"].ToString();
                    NOMBRE_COMPLETO = dtResultado.Rows[i]["NOMBRE_COMPLETO"].ToString();
                    ASISTENCIA = dtResultado.Rows[i]["ASISTENCIA"].ToString();
                    H_ASISTENCIA = dtResultado.Rows[i]["H_ASISTENCIA"].ToString();
                    CUENTA_COSTO = dtResultado.Rows[i]["CUENTA_COSTO"].ToString();
                    ACUMULADO = dtResultado.Rows[i]["ACUMULADO"].ToString();
                    HRS_NORMALES = dtResultado.Rows[i]["HRS_NORMALES"].ToString();
                    HRS_60 = dtResultado.Rows[i]["HRS_60"].ToString();
                    HRS_100 = dtResultado.Rows[i]["HRS_100"].ToString();
                    HRS_FALTA = dtResultado.Rows[i]["HRS_FALTA"].ToString();
                    HRS_ALTURA = dtResultado.Rows[i]["HRS_ALTURA"].ToString();
                    HRS_AGUA = dtResultado.Rows[i]["HRS_AGUA"].ToString();
                    HRS_NOCTURNA = dtResultado.Rows[i]["HRS_NOCTURNA"].ToString();
                    HRS_TUNEL = dtResultado.Rows[i]["HRS_TUNEL"].ToString();


                    xrow = new string[] {
                        NRO, NOMBRE_COMPLETO, ASISTENCIA, H_ASISTENCIA, CUENTA_COSTO, ACUMULADO, HRS_NORMALES, HRS_60, HRS_100, HRS_FALTA,
                     HRS_ALTURA, HRS_AGUA, HRS_NOCTURNA, HRS_TUNEL

                        };

                    gridDetalle.Rows.Add(xrow);

                }

                double sumatoria = 0;

                for (int i = 5; i < gridDetalle.ColumnCount ; i++)
                {
                    sumatoria = 0;

                    foreach (DataGridViewRow row in gridDetalle.Rows)
                    {
                        //Aquí seleccionaremos la columna que contiene los datos numericos. 
                        if (row.Cells[i].Value == null)
                        {
                            sumatoria += Convert.ToDouble((row.Cells[i].Value == null) ? "0" : row.Cells[i].Value.ToString());
                        }
                        else if (row.Cells[i].Value.ToString() == "")
                        {
                            sumatoria += Convert.ToDouble((row.Cells[i].Value.ToString() == "" ? "0" : row.Cells[i].Value.ToString()));
                        }
                        else
                        {
                            sumatoria += Convert.ToDouble(row.Cells[i].Value.ToString());
                        }

                        //(rx.Cells["Asistencia"].Value == null) ? "" : rx.Cells["Asistencia"].Value.ToString()
                    }
                    DataGridViewRow rowTotal = gridDetalle.Rows[gridDetalle.Rows.Count - 1];
                    rowTotal.Cells[i].Value = sumatoria;

                    sumatoria = 0;

                }
                gridDetalle.Rows[gridDetalle.Rows.Count - 1].DefaultCellStyle.BackColor = Color.FromArgb(255, 248, 110);
                gridDetalle.Rows[gridDetalle.Rows.Count - 1].ReadOnly = true;
                gridDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }

        }
        protected void DetalleTrabajos(string capataz, string ingeniero)
        {
            gridDetalle.Rows.Clear();
            gridDetalle.Columns.Clear();
            gridDetalle.Refresh();

         
            gridDetalle.AutoGenerateColumns = false;
      

            gridDetalle.ColumnCount = 6;
            gridDetalle.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridDetalle.Columns[0].Name = "Item";
            gridDetalle.Columns[1].Name = "ID_PERSONAL";
            gridDetalle.Columns[2].Name = "Apellidos y nombres";
            gridDetalle.Columns[3].Name = "Especialidad";
            gridDetalle.Columns[4].Name = "Categoria";
            gridDetalle.Columns[5].Name = "Asistencia";

            DataGridViewTextBoxColumn colED = new DataGridViewTextBoxColumn();
            colED.Name = "EstadoDiario";
            colED.HeaderText = "E/F";
            colED.Width = 40;
            colED.ReadOnly = true;
            //colED.DefaultCellStyle.BackColor = Color.FromArgb(244, 243, 226);
            colED.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridDetalle.Columns.Insert(6, colED);


            gridDetalle.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
           
            gridDetalle.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridDetalle.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridDetalle.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //agregar columna de tareas agregadas en bd

            BL_ASIGNACION_TAREAS xobj = new BL_ASIGNACION_TAREAS();
            DataTable dtResultado = new DataTable();
            dtResultado = xobj.Listar_ActividadAsignadas(cboEmpresa.SelectedValue.ToString(), cboCentroCosto.SelectedValue.ToString(), null, dateTareo.Value.Date.ToString("dd/MM/yyyy"), capataz, ingeniero);
            int cantidadTareas = dtResultado.Rows.Count;

            if (dtResultado.Rows.Count > 0)
            {
                gridDetalle.Visible = true;
                for (int i = 0; i < dtResultado.Rows.Count; i++)
                {

                    DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                    col.Name = dtResultado.Rows[i]["ITEM_ACTIVIDAD"].ToString();
                    col.DataPropertyName = dtResultado.Rows[i]["IDE_TAREA"].ToString();
                    col.HeaderText = "Tarea " + dtResultado.Rows[i]["ITEM_ACTIVIDAD"].ToString();
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    col.Width = 67;

                    gridDetalle.Columns.Add(col);
                }
                //}

                DataGridViewTextBoxColumn colTotal = new DataGridViewTextBoxColumn();
                colTotal.Name = "Total";
                colTotal.HeaderText = "Total";
                colTotal.DefaultCellStyle.BackColor = Color.FromArgb(218, 247, 166);
                colTotal.Width = 55;
                colTotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                gridDetalle.Columns.Add(colTotal);

                BL_FUNCIONES Fobj = new BL_FUNCIONES();
                DataTable dtBonificacion = new DataTable();
                dtBonificacion = Fobj.ListarBonificacion(cboCentroCosto.SelectedValue.ToString(), Convert.ToInt32(cboEmpresa.SelectedValue));

                if (dtBonificacion.Rows.Count > 0)
                {
                    for (int i = 0; i < dtBonificacion.Rows.Count; i++)
                    {

                        DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                        col.Name = dtBonificacion.Rows[i]["DES_ASUNTO"].ToString();
                        col.DataPropertyName = dtBonificacion.Rows[i]["IDE_TIPO"].ToString();
                        col.HeaderText = dtBonificacion.Rows[i]["DES_ASUNTO"].ToString();
                        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        col.Width = 60;
                        gridDetalle.Columns.Add(col);
                    }
                }

                DataGridViewTextBoxColumn colTotalMax = new DataGridViewTextBoxColumn();
                colTotalMax.Name = "TotalMax";
                colTotalMax.HeaderText = "Total";
                colTotalMax.Width = 55;
                colTotalMax.DefaultCellStyle.BackColor = Color.FromArgb(218, 247, 166);
                colTotalMax.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                gridDetalle.Columns.Add(colTotalMax);

                //tamaños
                gridDetalle.Columns[0].Width = 30;
                gridDetalle.Columns[2].Width = 300;
                gridDetalle.Columns["Especialidad"].Width = 100;
                gridDetalle.Columns["Asistencia"].Width = 60;
                gridDetalle.Columns["Categoria"].Width = 70;
                //gridDetalle.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


                //celda bloqueados
                gridDetalle.Columns["Item"].ReadOnly = true;
                gridDetalle.Columns[1].ReadOnly = true;
                gridDetalle.Columns[2].ReadOnly = true;
                gridDetalle.Columns[3].ReadOnly = true;
                gridDetalle.Columns["Total"].ReadOnly = true;
                gridDetalle.Columns["TotalMax"].ReadOnly = true;

                gridDetalle.Columns["TotalMax"].Visible = false;
                gridDetalle.Columns["ID_PERSONAL"].Visible = false;



                //llenar trabajadores
                BL_ASIGNACION_TAREAS obj = new BL_ASIGNACION_TAREAS();
                DataTable dtResul = new DataTable();
                string dateString = dateTareo.Value.Date.ToString("dddd");

                dtResul = obj.Lista_Personal_tareas_x_fecha(cboCentroCosto.SelectedValue.ToString(), Convert.ToInt32(cboEmpresa.SelectedValue), capataz, dateTareo.Value.Date.ToString("dd/MM/yyyy"), dateString, ingeniero);
                
                if (dtResul.Rows.Count > 0)
                {
   
                    for (int i = 0; i < dtResul.Rows.Count; i++)
                    {
                        DataGridViewRow row = (DataGridViewRow)gridDetalle.Rows[i].Clone();
                        row.Cells[0].Value = Convert.ToString(i + 1);
                        row.Cells[1].Value = dtResul.Rows[i]["ID_PERSONAL"].ToString();
                        row.Cells[2].Value = dtResul.Rows[i]["NOMBRES"].ToString();
                        row.Cells[3].Value = dtResul.Rows[i]["ESPECIALIDAD"].ToString();
                        row.Cells[4].Value = dtResul.Rows[i]["CATEGORIA"].ToString();
                        gridDetalle.Rows.Add(row);
                    }
                }
                BL_TAREO Xobj = new BL_TAREO();
                BL_FUNCIONES ObjFuncion = new BL_FUNCIONES();
                DataTable dtResulTareo = new DataTable();
                DataTable dtAsistencia = new DataTable();
                DataTable dtBono = new DataTable();
             
                string codPersona = null;
                decimal Total = 0;
                decimal TotalBono = 0;

                int filas = Convert.ToInt32(gridDetalle.Rows.Count);
                for (int i = 0; i < filas - 1; i++)
                {
                    Total = 0;
                    TotalBono = 0;
                   
                    codPersona = gridDetalle.Rows[i].Cells["ID_PERSONAL"].Value.ToString();
                    //ASISTENCIA
                    dtAsistencia = Xobj.AsistenciaPersonal_tareo(Convert.ToInt32(cboEmpresa.SelectedValue), cboCentroCosto.SelectedValue.ToString(), dateTareo.Value.Date.ToString("dd/MM/yyyy"), codPersona);
                    if (dtAsistencia.Rows.Count > 0)
                    {
                        gridDetalle.Rows[i].Cells["Asistencia"].Value = dtAsistencia.Rows[0]["ESTADO_DIARIO"].ToString();
                        // valor del feriado o enfermo
                        string ED = dtAsistencia.Rows[0]["ESTADO_DIARIO"].ToString();
                        if (ED == "F" || ED == "E") // || ED == "B"
                        {
                            gridDetalle.Rows[i].Cells["EstadoDiario"].Value = EstDiario;
                            gridDetalle.Rows[i].Cells["EstadoDiario"].Style.BackColor = Color.FromArgb(244, 243, 226);
                        }

                    }
                    else
                    {
                        //DIAS FERIADOS
                        gridDetalle.Rows[i].Cells["Asistencia"].Value = AsistenciaPersona;
                        if (AsistenciaPersona == "F")
                        {
                            gridDetalle.Rows[i].Cells["EstadoDiario"].Value = EstDiario;
                            gridDetalle.Rows[i].Cells["EstadoDiario"].Style.BackColor = Color.FromArgb(244, 243, 226);
                        }
                    }




                    /// PARA LAS TAREAS NORMALES ///
                    DataTable dtTareas = new DataTable();
                    BL_ASIGNACION_TAREAS objTareas = new BL_ASIGNACION_TAREAS();

                    dtTareas = xobj.Listar_ActividadAsignadas(cboEmpresa.SelectedValue.ToString(), cboCentroCosto.SelectedValue.ToString(), null, dateTareo.Value.Date.ToString("dd/MM/yyyy"), capataz, ingeniero);
                    if (dtTareas.Rows.Count > 0)
                    {
                        for (int mi = 0; mi < dtTareas.Rows.Count; mi++)
                        {
                            try
                            {
                                string codTarea = dtTareas.Rows[mi]["IDE_TAREA"].ToString();//codigo

                                dtResulTareo = Xobj.actividadesPersona_tareo(Convert.ToInt32(cboEmpresa.SelectedValue), cboCentroCosto.SelectedValue.ToString(), 1, dateTareo.Value.Date.ToString("dd/MM/yyyy"), codPersona, Convert.ToInt32(codTarea));
                                if (dtResulTareo.Rows.Count > 0)
                                {
                                    Total = Total + Convert.ToDecimal(dtResulTareo.Rows[0]["HORA_EMPLEADA"].ToString());
                                    gridDetalle.Rows[i].Cells[7 + mi].Value = dtResulTareo.Rows[0]["HORA_EMPLEADA"].ToString();

                                }
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        gridDetalle.Rows[i].Cells[7 + cantidadTareas].Value = Total;
                    }

                    BL_FUNCIONES objfun = new BL_FUNCIONES();
                    DataTable dtBonos = new DataTable();
                    dtBonos = objfun.ListarBonificacion(cboCentroCosto.SelectedValue.ToString(), Convert.ToInt32(cboEmpresa.SelectedValue));

                    if (dtBonos.Rows.Count > 0)
                    {
                        for (int bi = 0; bi < dtBonos.Rows.Count; bi++)
                        {
                            try
                            {
                                string codBono = dtBonos.Rows[bi]["IDE_TIPO"].ToString();//codigo


                                dtResulTareo = Xobj.actividadesPersona_tareo(Convert.ToInt32(cboEmpresa.SelectedValue), cboCentroCosto.SelectedValue.ToString(), 2, dateTareo.Value.Date.ToString("dd/MM/yyyy"), codPersona, Convert.ToInt32(codBono));
                                if (dtResulTareo.Rows.Count > 0)
                                {
                                    TotalBono = TotalBono + Convert.ToDecimal(dtResulTareo.Rows[0]["HORA_EMPLEADA"].ToString());
                                    gridDetalle.Rows[i].Cells[8 + cantidadTareas + bi].Value = dtResulTareo.Rows[0]["HORA_EMPLEADA"].ToString();
                                    decimal HValor = Convert.ToDecimal(string.IsNullOrEmpty(dtResulTareo.Rows[0]["HORA_EMPLEADA"].ToString()) ? "0" : dtResulTareo.Rows[0]["HORA_EMPLEADA"].ToString());
                                }
                            }
                            catch (Exception ex)
                            {

                            }
                        }

                    }
                }
            }
            else
            {
                gridDetalle.Visible = false ;
                MessageBox.Show("No se registra tareo de la cuadrilla" , "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            gridDetalle.ReadOnly = true;
            //gridDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }


        //private void btnTareas_Click(object sender, EventArgs e)
        //{
        //    obj_asignacion_E = new BE_ASIGNACION_TAREAS();
        //    obj_asignacion_E.IDE_EMPRESA = Convert.ToInt32(cboEmpresa.SelectedValue.ToString());
        //    obj_asignacion_E.CENTRO_COSTO = cboCentroCosto.SelectedValue.ToString();
        //    obj_asignacion_E.IDE_INGCAMPO = cboIngeniero.SelectedValue.ToString();
        //    obj_asignacion_E.IDE_CAPATAZ = cboCapataz.SelectedValue.ToString();
        //    obj_asignacion_E.FECHA_TAREO = dateTareo.Value.Date.ToString("dd/MM/yyyy");
        //    new frmTareas().ShowDialog();
        //}

        private void btnCerrar_Click(object sender, EventArgs e)
        {
          
            DialogResult respuesta = MessageBox.Show("¿Desea Cerrar Tareo del dia " + dateTareo.Value.Date.ToString("dd/MM/yyyy"), "Mensaje SSK", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (respuesta == DialogResult.Yes)
            {
                BL_ASIGNACION_TAREO objT = new BL_ASIGNACION_TAREO();
                objT.SP_ACTUALIZAR_PERSONAL_ACTIVO_HH_DIA_CC(cboCentroCosto.SelectedValue.ToString(), dateTareo.Value.Date.ToString("dd/MM/yyyy"));


                BL_ASIGNACION_TAREO obj = new BL_ASIGNACION_TAREO();
                DataTable dtResultado = new DataTable();

                BL_TAREO xobj = new BL_TAREO();
                DataTable dtResul = new DataTable();
                dtResul = xobj.ListarPersonal_SinTareo(Convert.ToInt32(cboEmpresa.SelectedValue.ToString()), cboCentroCosto.SelectedValue.ToString(), dateTareo.Value.Date.ToString("dd/MM/yyyy"));

                if (dtResul.Rows.Count > 0)
                {
                    MessageBox.Show("No se ha cargado el tareo de " + dtResul.Rows.Count.ToString () + " obreros, pendiente digitación", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    BL_TAREO objTareo = new BL_TAREO();
                    DataTable dtResulTareo = new DataTable();

                    dtResulTareo = objTareo.ExcesoHrs_Personal(Convert.ToInt32(cboEmpresa.SelectedValue.ToString()), cboCentroCosto.SelectedValue.ToString(), dateTareo.Value.Date.ToString("dd/MM/yyyy"));

                    if (dtResulTareo.Rows.Count > 0)
                    {
                        btnAdvertencia.Visible = true;
                        MessageBox.Show("Existe personal que excede las 24Hrs de trabajo, ver detalle 'Exceso de Horas'", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        btnAdvertencia.Visible = false ;
                        dtResultado = obj.CerrarTareo_fecha(Convert.ToInt32(cboEmpresa.SelectedValue.ToString()), cboCentroCosto.SelectedValue.ToString(), dateTareo.Value.Date.ToString("dd/MM/yyyy"), 0);
                        //Procesar_domingos_feriados();
                        ConsultarTareo();
                        consultarGrilla();
                    }
                }

                
            }
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Desea Aperturar Tareo del dia " + dateTareo.Value.Date.ToString("dd/MM/yyyy"), "Mensaje SSK", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (respuesta == DialogResult.Yes)
            {
                BL_ASIGNACION_TAREO obj = new BL_ASIGNACION_TAREO();
                DataTable dtResultado = new DataTable();

                dtResultado = obj.CerrarTareo_fecha(Convert.ToInt32(cboEmpresa.SelectedValue.ToString()), cboCentroCosto.SelectedValue.ToString(), dateTareo.Value.Date.ToString("dd/MM/yyyy"), 1);
                ConsultarTareo();
            }
        }

        private void btnPersonal_Click(object sender, EventArgs e)
        {
            obj_asignacion_E = new BE_ASIGNACION_TAREAS();
            obj_asignacion_E.IDE_EMPRESA = Convert.ToInt32(cboEmpresa.SelectedValue.ToString());
            obj_asignacion_E.CENTRO_COSTO = cboCentroCosto.SelectedValue.ToString();
            obj_asignacion_E.FECHA_TAREO = dateTareo.Value.Date.ToString("dd/MM/yyyy");
            new frmPersonalSinTareo().ShowDialog();
        }
    

      
        protected void ExportarFileTareo()
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                string qry = "SELECT * FROM TAREO WHERE IDE_EMPRESA =" + cboEmpresa.SelectedValue.ToString() + " and CCENTRO = '" + cboCentroCosto.SelectedValue.ToString() + "' and convert(varchar(10),[FECHA_TAREO],103) = '" + dateTareo.Value.Date.ToString("dd/MM/yyyy") + "'";

                using (SqlCommand cmd = new SqlCommand(qry))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);

                            //Build the Text file data.
                            string txt = string.Empty;
                            int col = 0;
                            string Startuppath = DirectorioFile;// Application.StartupPath + "/";
                            string Destinationpath = Startuppath + cboCentroCosto.SelectedValue.ToString () + "_T_"+   dateTareo.Value.Date.ToString("yyyyMMdd") + ".txt"; //File Extension as your requirement .dat or .txt 
                            using (StreamWriter Streamwrite = File.CreateText(Destinationpath))
                            {
                                foreach (DataColumn column in dt.Columns)
                                {
                                    col += 1;
                                    //Add the Header row for Text file.
                                    if (col == 18)// cantidad de columnas de la tabla tareo
                                    {
                                        txt += column.ColumnName + "\t\t";
                                    }
                                    else
                                    {
                                        txt += column.ColumnName + ",";

                                    }
                                }

                                //Add new line.
                                //Streamwrite.WriteLine(txt);
                                txt += "\r\n";
                                
                                col = 0;
                                foreach (DataRow row in dt.Rows)
                                {
                                    col = 0;
                                    foreach (DataColumn column in dt.Columns)
                                    {
                                        col += 1;
                                        if (col == 18)// cantidad de columnas de la tabla tareo
                                        {
                                            //Add the Data rows.
                                            txt += row[column.ColumnName].ToString() + "\t\t";
                                        }
                                        else
                                        {
                                            //Add the Data rows.
                                            txt += row[column.ColumnName].ToString() + ",";
                                        }

                                    }

                                    //Add new line.
                                   
                                    txt += "\r\n";
                                }
                                Streamwrite.WriteLine(txt);
                                Streamwrite.WriteLine(Streamwrite.NewLine);
                                Streamwrite.Close();
                                ExportarFileAsistencia();
                                //MessageBox.Show("File Created Successfully in " + Destinationpath);
                            }
                        }
                    }
                }
            }

        }
        protected void ExportarFileAsistencia()
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                string qry = "SELECT * FROM ASISTENCIA_PERSONAL WHERE IDE_EMPRESA =" + cboEmpresa.SelectedValue.ToString() + " and CCENTRO = '" + cboCentroCosto.SelectedValue.ToString() + "' and convert(varchar(10),[FEC_ASISTENCIA],103) = '" + dateTareo.Value.Date.ToString("dd/MM/yyyy") + "'";

                using (SqlCommand cmd = new SqlCommand(qry))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);

                            //Build the Text file data.
                            string txt = string.Empty;
                            int col = 0;
                            string Startuppath = DirectorioFile;// Application.StartupPath + "/";
                            string Destinationpath = Startuppath + cboCentroCosto.SelectedValue.ToString() + "_A_" + dateTareo.Value.Date.ToString("yyyyMMdd") + ".txt"; //File Extension as your requirement .dat or .txt 
                            using (StreamWriter Streamwrite = File.CreateText(Destinationpath))
                            {
                                foreach (DataColumn column in dt.Columns)
                                {
                                    col += 1;
                                    //Add the Header row for Text file.
                                    if (col == 9)// cantidad de columnas de la tabla asistencia
                                    {
                                        txt += column.ColumnName + "\t\t";
                                    }
                                    else
                                    {
                                        txt += column.ColumnName + ",";

                                    }
                                }

                                //Add new line.
                                //Streamwrite.WriteLine(txt);
                                txt += "\r\n";

                                col = 0;
                                foreach (DataRow row in dt.Rows)
                                {
                                    col = 0;
                                    foreach (DataColumn column in dt.Columns)
                                    {
                                        col += 1;
                                        if (col == 9)// cantidad de columnas de la tabla asistencia
                                        {
                                            //Add the Data rows.
                                            txt += row[column.ColumnName].ToString() + "\t\t";
                                        }
                                        else
                                        {
                                            //Add the Data rows.
                                            txt += row[column.ColumnName].ToString() + ",";
                                        }

                                    }

                                    //Add new line.

                                    txt += "\r\n";
                                }
                                Streamwrite.WriteLine(txt);
                                Streamwrite.WriteLine(Streamwrite.NewLine);
                                Streamwrite.Close();
                                MessageBox.Show("File Created Successfully in " + Destinationpath);
                            }
                        }
                    }
                }
            }

        }
   

        private void btnGenerarFile_Click(object sender, EventArgs e)
        {
            ExportarFileTareo();
        }

        private void btnAdvertencia_Click(object sender, EventArgs e)
        {
            obj_asignacion_E = new BE_ASIGNACION_TAREAS();
            obj_asignacion_E.IDE_EMPRESA = Convert.ToInt32(cboEmpresa.SelectedValue.ToString());
            obj_asignacion_E.CENTRO_COSTO = cboCentroCosto.SelectedValue.ToString();
            obj_asignacion_E.FECHA_TAREO = dateTareo.Value.Date.ToString("dd/MM/yyyy");


            //new frmMigracionTareo().ShowDialog();

            frmExcesoHoras f2 = new frmExcesoHoras(); //creamos un objeto del formulario hijo
            DialogResult res = f2.ShowDialog();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1)
            {

                btnBuscar.PerformClick();
            }
            

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnIndicadores_Click(object sender, EventArgs e)
        {
            obj_asignacion_E = new BE_ASIGNACION_TAREAS();
            obj_asignacion_E.IDE_EMPRESA = Convert.ToInt32(cboEmpresa.SelectedValue.ToString());
            obj_asignacion_E.CENTRO_COSTO = cboCentroCosto.SelectedValue.ToString();
            obj_asignacion_E.FECHA_TAREO = dateTareo.Value.Date.ToString("dd/MM/yyyy");


            //new frmMigracionTareo().ShowDialog();

            frmIndicadores f2 = new frmIndicadores(); //creamos un objeto del formulario hijo
            DialogResult res = f2.ShowDialog();
        }
        private bool AccesoInternet()
        {

            try
            {
                System.Net.IPHostEntry host = System.Net.Dns.GetHostEntry("www.google.com");
                return true;

            }
            catch (Exception es)
            {

                return false;
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (AccesoInternet())
            {
                DataTable dtResultado = new DataTable();
                DataTable dt = new DataTable();
                BL_TAREO objTareo = new BL_TAREO();


                dtResultado = objTareo.uspWCF_SELECT_PERIODO(Convert.ToInt32(cboEmpresa.SelectedValue), cboCentroCosto.SelectedValue.ToString(), dateTareo.Value.Date.ToString("dd/MM/yyyy"));


                //if (Convert.ToInt32(cboEmpresa.SelectedValue) == 1)
                //{
                //    dtResultado = objTareo.uspWCF_SELECT_PERIODO(Convert.ToInt32(cboEmpresa.SelectedValue), cboCentroCosto.SelectedValue.ToString(), dateTareo.Value.Date.ToString("dd/MM/yyyy"));
                //}
                //else
                //{
                //    dtResultado = objTareo.uspWCF_SELECT_PERIODO_SKEX(Convert.ToInt32(cboEmpresa.SelectedValue), cboCentroCosto.SelectedValue.ToString(), dateTareo.Value.Date.ToString("dd/MM/yyyy"));
                //}

                if (dtResultado.Rows[0]["ESTADO"].ToString() == "SI")
                {
                    DialogResult respuesta = MessageBox.Show("¿Desea eliminar registros migrados del día " + dateTareo.Value.Date.ToString("dd/MM/yyyy"), "Mensaje SSK", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (respuesta == DialogResult.Yes)
                    {
                        BL_ASIGNACION_TAREO obj = new BL_ASIGNACION_TAREO();
                        DataTable dtAbrir = new DataTable();

                        dtAbrir = obj.CerrarTareo_fecha(Convert.ToInt32(cboEmpresa.SelectedValue.ToString()), cboCentroCosto.SelectedValue.ToString(), dateTareo.Value.Date.ToString("dd/MM/yyyy"), 1);



                        dt = objTareo.uspWCF_TAREO_LIMPIAR_MIGRACION_GESTOR(Convert.ToInt32(cboEmpresa.SelectedValue), cboCentroCosto.SelectedValue.ToString(), dateTareo.Value.Date.ToString("dd/MM/yyyy"));
                        if (dt.Rows.Count > 0)
                        {
                           MessageBox.Show("Proceso revertido, puede volver a realizar la migración de tareos", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
 
                        }
                        else
                        {
                            MessageBox.Show("No se puede eliminar registro, consultar al administrador ", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }

                        ConsultarTareo();

                    }
                }
                else
                {
                    MessageBox.Show("Fecha cerrada, no se puede eliminar registros ", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            else
            {
                MessageBox.Show("Sin acceso a internet", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


            //// TAREO DESCONECTADO 
            /*
            if (AccesoInternet())
            {

                SvTareo.TareoClient objServicio = new SvTareo.TareoClient();
                string ls_error = "";
                bool lb_conectado = objServicio.ProbarConexionTareo(ref ls_error);

                if (lb_conectado == true)
                {
                    DataTable dtResultado = new DataTable();
                    DataTable dt = new DataTable();
                    if (Convert.ToInt32(cboEmpresa.SelectedValue) == 1)
                    {
                        dtResultado = new TareoClient().Get_Estado_PeridoTareo_SSK(Convert.ToInt32(cboEmpresa.SelectedValue), cboCentroCosto.SelectedValue.ToString(), dateTareo.Value.Date.ToString("yyyyMMdd"));
                    }
                    else
                    {
                        dtResultado = new TareoClient().Get_Estado_PeridoTareo_SKEx(Convert.ToInt32(cboEmpresa.SelectedValue), cboCentroCosto.SelectedValue.ToString(), dateTareo.Value.Date.ToString("yyyyMMdd"));
                    }


                    if (dtResultado.Rows[0]["ESTADO"].ToString() == "SI")
                    {
                        DialogResult respuesta = MessageBox.Show("¿Desea eliminar registros migrados del día " + dateTareo.Value.Date.ToString("dd/MM/yyyy"), "Mensaje SSK", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (respuesta == DialogResult.Yes)
                        {
                            BL_ASIGNACION_TAREO obj = new BL_ASIGNACION_TAREO();
                            DataTable dtAbrir = new DataTable();

                            dtAbrir = obj.CerrarTareo_fecha(Convert.ToInt32(cboEmpresa.SelectedValue.ToString()), cboCentroCosto.SelectedValue.ToString(), dateTareo.Value.Date.ToString("dd/MM/yyyy"), 1);


                            SvTareo.TareoClient objSer = new SvTareo.TareoClient();
                            dt = new TareoClient().TAREO_LIMPIAR_MIGRACION(cboCentroCosto.SelectedValue.ToString(), dateTareo.Value.Date.ToString("dd/MM/yyyy"));
                            if (dt.Rows.Count > 0)
                            {
                                dt.Clear();
                                dt = new TareoClient().LIMPIAR_MIGRACION_GESTOR(Convert.ToInt32(cboEmpresa.SelectedValue), cboCentroCosto.SelectedValue.ToString(), dateTareo.Value.Date.ToString("dd/MM/yyyy"));
                                if (dt.Rows.Count > 0)
                                {
                                    MessageBox.Show("Proceso revertido, puede volver a realizar la migración de tareos", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }
                            else
                            {
                                MessageBox.Show("No se puede eliminar registro, consultar al administrador ", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }

                            ConsultarTareo();

                        }
                    }
                    else
                    {
                        MessageBox.Show("Fecha cerrada, no se puede eliminar registros ", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }

                else
                {

                    MessageBox.Show("Error con la conexion ", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Sin acceso a internet", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            */
        }

        private void rdoGeneral_CheckedChanged(object sender, EventArgs e)
        {
            
            if (rdoGeneral.Checked)
            {
                rdoTareo.Checked = false;
                rdoGestor.Checked = false;
            }

            consultarGrilla();
        }
        protected void DetalleTotalHoras()
        {
            string dateString = dateTareo.Value.Date.ToString("dddd");
            gridDetalle.Rows.Clear();
            gridDetalle.Columns.Clear();
            gridDetalle.Refresh();


            gridDetalle.AutoGenerateColumns = false;


            gridDetalle.ColumnCount = 5;
            gridDetalle.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridDetalle.Columns[0].Name = "Item";
            gridDetalle.Columns[1].Name = "Obrero";

            DataGridViewTextBoxColumn colFECHA_INGRESOL = new DataGridViewTextBoxColumn();
            colFECHA_INGRESOL.Name = "FECHA_INGRESO";
            colFECHA_INGRESOL.Width = 100;
            colFECHA_INGRESOL.HeaderText = "Fec. Ingreso";
            colFECHA_INGRESOL.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridDetalle.Columns.Insert(2, colFECHA_INGRESOL);

            DataGridViewTextBoxColumn colFECHA_CESE = new DataGridViewTextBoxColumn();
            colFECHA_CESE.Name = "FECHA_CESE";
            colFECHA_CESE.Width = 100;
            colFECHA_CESE.HeaderText = "Fec. Cese";
            colFECHA_CESE.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridDetalle.Columns.Insert(3, colFECHA_CESE);


            gridDetalle.Columns[4].Name = "Especialidad";
            gridDetalle.Columns[5].Name = "Categoria";
            

            //DataGridViewTextBoxColumn colED = new DataGridViewTextBoxColumn();
            //colED.Name = "EstadoDiario";
            //colED.HeaderText = "E/F";
            //colED.Width = 40;
            //colED.ReadOnly = true;
            ////colED.DefaultCellStyle.BackColor = Color.FromArgb(244, 243, 226);
            //colED.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //gridDetalle.Columns.Insert(5, colED);


            gridDetalle.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridDetalle.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridDetalle.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridDetalle.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            DataGridViewTextBoxColumn colID_PERSONAL = new DataGridViewTextBoxColumn();
            colID_PERSONAL.Name = "ID_PERSONAL";
            colID_PERSONAL.HeaderText = "ID_PERSONAL";
            gridDetalle.Columns.Insert(6, colID_PERSONAL);

            gridDetalle.Columns[7].Name = "Asistencia";
            gridDetalle.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGridViewTextBoxColumn colHRS_ESTADO = new DataGridViewTextBoxColumn();
            colHRS_ESTADO.Name = "HRS_ESTADO";
            colHRS_ESTADO.HeaderText = "Hrs/E";
            colHRS_ESTADO.Width = 55;
            colHRS_ESTADO.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridDetalle.Columns.Insert(8, colHRS_ESTADO);


            DataGridViewTextBoxColumn colTotal = new DataGridViewTextBoxColumn();
            colTotal.Name = "Total";
            colTotal.HeaderText = "Total";
            colTotal.DefaultCellStyle.BackColor = Color.FromArgb(218, 247, 166);
            colTotal.Width = 55;
            colTotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridDetalle.Columns.Insert(9, colTotal);

            DataGridViewTextBoxColumn colHNoct = new DataGridViewTextBoxColumn();
            colHNoct.Name = "HNoct";
            colHNoct.HeaderText = "HNoct";
            colHNoct.Width = 55;
            colHNoct.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridDetalle.Columns.Insert(10, colHNoct);

            DataGridViewTextBoxColumn colHAlt = new DataGridViewTextBoxColumn();
            colHAlt.Name = "HAlt";
            colHAlt.HeaderText = "HAlt";
            colHAlt.Width = 55;
            colHAlt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridDetalle.Columns.Insert(11, colHAlt);

            DataGridViewTextBoxColumn colHAgua = new DataGridViewTextBoxColumn();
            colHAgua.Name = "HAgua";
            colHAgua.HeaderText = "HAgua";
            colHAgua.Width = 55;
            colHAgua.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridDetalle.Columns.Insert(12, colHAgua);

            DataGridViewTextBoxColumn colHTunel = new DataGridViewTextBoxColumn();
            colHTunel.Name = "HTunel";
            colHTunel.HeaderText = "HTunel";
            colHTunel.Width = 55;
            colHTunel.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridDetalle.Columns.Insert(13, colHTunel);

            DataGridViewTextBoxColumn colERROR_FECHA_ING = new DataGridViewTextBoxColumn();
            colERROR_FECHA_ING.Name = "ERROR_FECHA_ING";
            colERROR_FECHA_ING.HeaderText = "ERROR_FECHA_ING";
            colERROR_FECHA_ING.Width = 55;
            colERROR_FECHA_ING.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridDetalle.Columns.Insert(14, colERROR_FECHA_ING);

            DataGridViewTextBoxColumn colERROR_FECHA_CESE = new DataGridViewTextBoxColumn();
            colERROR_FECHA_CESE.Name = "ERROR_FECHA_CESE";
            colERROR_FECHA_CESE.HeaderText = "ERROR_FECHA_CESE";
            colERROR_FECHA_CESE.Width = 55;
            colERROR_FECHA_CESE.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridDetalle.Columns.Insert(15, colERROR_FECHA_CESE);

            DataGridViewTextBoxColumn colORDER_ERROR = new DataGridViewTextBoxColumn();
            colORDER_ERROR.Name = "ORDER_ERROR";
            colORDER_ERROR.HeaderText = "ORDER_ERROR";
            colORDER_ERROR.Width = 55;
            colORDER_ERROR.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridDetalle.Columns.Insert(16, colORDER_ERROR);

            //BL_FUNCIONES Fobj = new BL_FUNCIONES();
            //DataTable dtBonificacion = new DataTable();
            //dtBonificacion = Fobj.ListarBonificacion(cboCentroCosto.SelectedValue.ToString(), Convert.ToInt32(cboEmpresa.SelectedValue));

            //if (dtBonificacion.Rows.Count > 0)
            //{
            //    for (int i = 0; i < dtBonificacion.Rows.Count; i++)
            //    {

            //        DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            //        col.Name = dtBonificacion.Rows[i]["DES_ASUNTO"].ToString();
            //        col.DataPropertyName = dtBonificacion.Rows[i]["IDE_TIPO"].ToString();
            //        col.HeaderText = dtBonificacion.Rows[i]["DES_ASUNTO"].ToString();
            //        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //        col.Width = 60;
            //        gridDetalle.Columns.Add(col);
            //    }
            //}

            DataGridViewButtonColumn btnAgregar = new DataGridViewButtonColumn();
            btnAgregar.HeaderText = "";
            btnAgregar.Name = "btnEliminar";
            btnAgregar.Text = "Eliminar";
            btnAgregar.UseColumnTextForButtonValue = true;
            gridDetalle.Columns.Add(btnAgregar);

            //tamaños
            gridDetalle.Columns[0].Width = 30;
            gridDetalle.Columns["Especialidad"].Width = 100;
            gridDetalle.Columns["Asistencia"].Width = 60;
            gridDetalle.Columns["Categoria"].Width = 70;
            //gridDetalle.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            gridDetalle.Columns[1].Width = 250;
            gridDetalle.Columns["btnEliminar"].Width = 150;

            //celda bloqueados
            gridDetalle.Columns["Item"].ReadOnly = true;
            gridDetalle.Columns[1].ReadOnly = true;
            gridDetalle.Columns[2].ReadOnly = true;
            gridDetalle.Columns[3].ReadOnly = true;
            gridDetalle.Columns[4].ReadOnly = true;
            gridDetalle.Columns["Total"].ReadOnly = true;
            gridDetalle.Columns["ID_PERSONAL"].Visible  = false ;
            gridDetalle.Columns["ERROR_FECHA_ING"].Visible = false;
            gridDetalle.Columns["ERROR_FECHA_CESE"].Visible = false;
            gridDetalle.Columns["ORDER_ERROR"].Visible = false;
            //llenar trabajadores
            BL_ASIGNACION_TAREAS obj = new BL_ASIGNACION_TAREAS();
            DataTable dtResul = new DataTable();


            dtResul = obj.Lista_Personal_tareas_x_fecha(cboCentroCosto.SelectedValue.ToString(), Convert.ToInt32(cboEmpresa.SelectedValue), string.Empty , dateTareo.Value.Date.ToString("dd/MM/yyyy"), dateString, string.Empty);
            if (dtResul.Rows.Count > 0)
            {
                gridDetalle.Visible = true;
                //datos vacios
                for (int i = 0; i < dtResul.Rows.Count; i++)
                {
                    DataGridViewRow row = (DataGridViewRow)gridDetalle.Rows[i].Clone();


                    row.Cells[0].Value = Convert.ToString(i + 1);
                    row.Cells[1].Value = dtResul.Rows[i]["NOMBRES"].ToString();
                    row.Cells[2].Value = dtResul.Rows[i]["FECHA_INGRESO"].ToString();
                    row.Cells[3].Value = dtResul.Rows[i]["FECHA_CESE"].ToString();
                    row.Cells[4].Value = dtResul.Rows[i]["ESPECIALIDAD"].ToString();
                    row.Cells[5].Value = dtResul.Rows[i]["CATEGORIA"].ToString();
                    row.Cells[6].Value = dtResul.Rows[i]["ID_PERSONAL"].ToString(); 
                    row.Cells[7].Value = dtResul.Rows[i]["ASISTENCIA"].ToString();
                  
                    row.Cells[8].Value = dtResul.Rows[i]["HRS_ESTADO"].ToString();

                    row.Cells[9].Value = dtResul.Rows[i]["HORA_EMPLEADA"].ToString();

                    row.Cells[10].Value = dtResul.Rows[i]["HNoct"].ToString();
                    row.Cells[11].Value = dtResul.Rows[i]["HAlt"].ToString();
                    row.Cells[12].Value = dtResul.Rows[i]["HAgua"].ToString();
                    row.Cells[13].Value = dtResul.Rows[i]["HTunel"].ToString();
                    row.Cells[14].Value = dtResul.Rows[i]["ERROR_FECHA_ING"].ToString();
                    row.Cells[15].Value = dtResul.Rows[i]["ERROR_FECHA_CESE"].ToString();
                    row.Cells[16].Value = dtResul.Rows[i]["ORDER_ERROR"].ToString();
                    gridDetalle.Rows.Add(row);
                }
            }
            else
            {
                gridDetalle.Visible = false ;
            }


           

            double sumatoria = 0;
            for (int j = 8; j < Convert.ToInt32(gridDetalle.Columns.Count - 1); j++)
            {
                
                sumatoria = 0;

                foreach (DataGridViewRow row in gridDetalle.Rows)
                {
                    //Aquí seleccionaremos la columna que contiene los datos numericos. 
                    if (row.Cells[j].Value == null)
                    {
                        sumatoria += Convert.ToDouble((row.Cells[j].Value == null) ? "0" : row.Cells[j].Value.ToString());
                    }
                    else if (row.Cells[j].Value.ToString() == "")
                    {
                        sumatoria += Convert.ToDouble((row.Cells[j].Value.ToString() == "" ? "0" : row.Cells[j].Value.ToString()));
                    }
                    else
                    {
                        sumatoria += Convert.ToDouble(row.Cells[j].Value.ToString());
                    }

                    if (Convert.ToInt32(row.Cells["ERROR_FECHA_ING"].Value)  == 1)
                    {

                        row.DefaultCellStyle.BackColor = Color.FromArgb(250, 14, 14);
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255);
                    }
                    if (Convert.ToInt32(row.Cells["ERROR_FECHA_CESE"].Value) == 1)
                    {

                        row.DefaultCellStyle.BackColor = Color.FromArgb(250, 14, 14);
                        row.DefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255);
                    }

                    //else
                    //{
                    //    row.DefaultCellStyle.BackColor = Color.White;
                    //}

                }
                DataGridViewRow rowTotal = gridDetalle.Rows[gridDetalle.Rows.Count - 1];
                rowTotal.Cells[j].Value = sumatoria;
                sumatoria = 0;

            }
            gridDetalle.ReadOnly = true;
            gridDetalle.Rows[gridDetalle.Rows.Count - 1].DefaultCellStyle.BackColor = Color.FromArgb(255, 233, 51);

            this.gridDetalle.Sort(this.gridDetalle.Columns["ORDER_ERROR"], ListSortDirection.Descending );
        }

        private void gridDetalle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            if (e.ColumnIndex > -1)
            {
                if (gridDetalle.Columns[e.ColumnIndex].Name == "btnEliminar")
                {
                    DialogResult respuesta = MessageBox.Show("¿Desea eliminar registro?", "Mensaje SSK", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (respuesta == DialogResult.Yes)
                    {
                        DataGridViewRow Rows = gridDetalle.Rows[i];
                        string ID_PERSONAL =((Rows.Cells["ID_PERSONAL"].Value == null) ? "0" : Rows.Cells["ID_PERSONAL"].Value.ToString());

                        BL_TAREO obj = new BL_TAREO();
                        DataTable dtResulTareo = new DataTable();
                        dtResulTareo = obj.SP_ELIMINAR_TAREO_PERSONA(Convert.ToInt32(cboEmpresa.SelectedValue), cboCentroCosto.SelectedValue.ToString(), dateTareo.Value.Date.ToString("dd/MM/yyyy"), ID_PERSONAL,"");
                        if (dtResulTareo.Rows.Count > 0)
                        {
                            consultarGrilla(); 
                            MessageBox.Show("Registro eliminado", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            MessageBox.Show("No se puede realizar esta operación", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                       
                    }
                }
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            
        }
        protected void Procesar_domingos_feriados()
        {
            BL_TAREO objTareo = new BL_TAREO();
            DataTable dtResultado = new DataTable();

            string dateString = dateTareo.Value.Date.ToString("dddd");
            string feriado;

            if (dateString == "domingo")
            {
                lblFeriado.Text = "1";
                feriado = "0";
                dtResultado = objTareo.SP_GENERAR_TAREO_NO_LABORABLE(Convert.ToInt32(cboEmpresa.SelectedValue), cboCentroCosto.SelectedValue.ToString(), dateTareo.Value.Date.ToString("dd/MM/yyyy"), frmLogin.obj_user_E.IDE_USUARIO, dateString);
                if (dtResultado.Rows.Count > 0)
                {
                    //consultarGrilla();CCS
                    MessageBox.Show("Tareo dominical generado satisfactoriamente", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Existen incosistencia para generar día dominical", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                BL_FUNCIONES obj = new BL_FUNCIONES();
                DataTable dtResul = new DataTable();
                dtResul = obj.ListarHrasJorandas(dateTareo.Value.Date.ToString("dd/MM/yyyy"), Convert.ToInt32(cboEmpresa.SelectedValue), dateTareo.Value.Date.ToString("dddd"), cboCentroCosto.SelectedValue.ToString());
                if (dtResul.Rows.Count > 0)
                {

                    feriado = dtResul.Rows[0]["FERIADO"].ToString();
                    if (feriado == "1")
                    {
                        dtResultado = objTareo.SP_GENERAR_TAREO_FERIADO(Convert.ToInt32(cboEmpresa.SelectedValue), cboCentroCosto.SelectedValue.ToString(), dateTareo.Value.Date.ToString("dd/MM/yyyy"), frmLogin.obj_user_E.IDE_USUARIO, dateString);
                        if (dtResultado.Rows.Count > 0)
                        {
                            //consultarGrilla();CCS
                            MessageBox.Show("Tareo (feriado), generado satisfactoriamente", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Existen incosistencia para generar día feriado", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    

                }
                

            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTareo_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
