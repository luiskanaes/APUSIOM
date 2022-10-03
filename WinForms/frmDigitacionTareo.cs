using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessEntity;
using BusinessLogic;
using UserCode;
namespace WinForms
{
    public partial class frmDigitacionTareo : Form
    {
        AutoCompleteStringCollection DataFrente = new AutoCompleteStringCollection();
        AutoCompleteStringCollection DataActividades = new AutoCompleteStringCollection();
        AutoCompleteStringCollection DataActividadesPK = new AutoCompleteStringCollection();
        AutoCompleteStringCollection DataTarea = new AutoCompleteStringCollection();
        AutoCompleteStringCollection DataAreas = new AutoCompleteStringCollection();
        AutoCompleteStringCollection DataEstadiDiario = new AutoCompleteStringCollection();
        bool bKeyPressNum_GV_DATA = false;
        DataTable dsBonificacion = new DataTable();
        DataTable dsActividad = new DataTable();
        DataTable dtAreas = new DataTable();
        public static BE_ASIGNACION_TAREO obj_Tareo_E;
        public static BE_ASIGNACION_TAREAS obj_Tareas_E;
        private static List<BE_CABECERA> LstActividades = new List<BE_CABECERA>();
        private static List<BE_CABECERA> LstActividadesNro = new List<BE_CABECERA>();

       
        private List<BE_CABECERA> LstActividades1;


        private static List<BE_TBPARAMETROS> LstAREAS = new List<BE_TBPARAMETROS>();
        private static List<BE_TBPARAMETROS> LstBonificacion = new List<BE_TBPARAMETROS>();
        private static List<BE_TBPARAMETROS> LstEstadoDiario = new List<BE_TBPARAMETROS>();

        int row;
        int col;
        int colTarea;
        int rowTarea;
        string MGridActividad = string.Empty;
        string MGridTareo = string.Empty;
        public static bool bSalir = false;
        double HoraMaxima = 24;
        double BonoMaxima = 24;
        decimal EstDiario = 0;// horas por dia de jornada
        string AsistenciaPersona;
        int ColumnasFijas = 9;
        public frmDigitacionTareo()
        {

            //btnGuardarTareo.BackColor = Color.FromArgb(62, 133, 195);
            //btnGuardarTareo.ForeColor = Color.FromArgb(255, 255, 255);
            //btnGuardarTareo.Font = new Font(btnGuardarTareo.Font.Name, btnGuardarTareo.Font.Size, FontStyle.Bold);

            InitializeComponent();
           
            ListarEmpresa();
            JornadasHoras();
       

            TipoDisciplina();
        }
        protected void TipoDisciplina()
        {
            //BL_FUNCIONES obj = new BL_FUNCIONES();

            BL_DISCIPLINAS obj = new BL_DISCIPLINAS();
            DataTable dtResultado = new DataTable();
            DataTable dt = new DataTable();

            dtResultado = obj.uspSEL_TIPO_TAREO_POR_CENTRO_COSTO(cboCentroCosto.SelectedValue.ToString());
            if (dtResultado.Rows.Count > 0)
            {

                DataColumn dc = new DataColumn("Codigo", typeof(String));
                dt.Columns.Add(dc);

                dc = new DataColumn("Descripcion", typeof(String));
                dt.Columns.Add(dc);

                DataRow workRow;

                workRow = dt.NewRow();
                workRow[0] = "0";
                workRow[1] = "--- SELECCIONAR  ---";
                dt.Rows.Add(workRow);

                for (int i = 0; i < dtResultado.Rows.Count; i++)
                {

                    workRow = dt.NewRow();
                    workRow[0] = dtResultado.Rows[i]["IDE_PARAMETRO"].ToString();
                    workRow[1] = dtResultado.Rows[i]["DESCRIPCION"].ToString();
                    dt.Rows.Add(workRow);
                }


                cboFile.ValueMember = "Codigo";
                cboFile.DisplayMember = "Descripcion";
                cboFile.DataSource = dt;
            }
        }
        protected void JornadasHoras()
        {
            int anio = DateTime.Now.Year;
            BL_FUNCIONES obj = new BL_FUNCIONES();
            DataTable dtResultado = new DataTable();
            string feriado;
            string dateString = dateTareo.Value.Date.ToString("dddd");
            dtResultado = obj.ListarHrasJorandas(dateTareo.Value.Date.ToString("dd/MM/yyyy"), Convert.ToInt32(cboEmpresa.SelectedValue), dateTareo.Value.Date.ToString("dddd"), cboCentroCosto.SelectedValue.ToString());
            if (dtResultado.Rows.Count > 0)
            {
                EstDiario = Convert.ToDecimal(dtResultado.Rows[0]["HORAS_TRABAJO"].ToString());
                feriado = dtResultado.Rows[0]["FERIADO"].ToString();
                if (feriado == "1")
                {
                    AsistenciaPersona = "F";
                }
                else
                {
                    AsistenciaPersona = string.Empty;
                }

            }
            else
            {
                AsistenciaPersona = string.Empty;
            }
        }
        private void frmDigitacionTareo_Load(object sender, EventArgs e)
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
            TipoDisciplina();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string ls_error = "";
            UserCode.Conexion cn = new UserCode.Conexion();

            bool lb_conectado = cn.ProbarConexion(ref ls_error);

            if (lb_conectado == true)
            {
                if (cboFile.SelectedIndex < 1)
                {
                    MessageBox.Show("Seleccionar modo de tareo", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {

                    BL_ASIGNACION_TAREO obj = new BL_ASIGNACION_TAREO();
                    DataTable dtResultado = new DataTable();

                  
                    // LISTAR DATOS FECHA DE TAREO
                    lblIDE_TAREO_ASIGNACION.Text = string.Empty;

                    ConsultarTareo();
                    if(lblIDE_TAREO_ASIGNACION.Text == string.Empty )
                    {
                        // INSERTAR FECHA
                        dtResultado = obj.SP_INSERT_ASIGNACION_TAREO(Convert.ToInt32(cboEmpresa.SelectedValue.ToString()), cboCentroCosto.SelectedValue.ToString(), dateTareo.Value.Date.ToString("dd/MM/yyyy"), frmLogin.obj_user_E.IDE_USUARIO, dateTareo.Value.Date.ToString("dddd"));
                        ConsultarTareo();
                    }


                    // LAS TAREAS DE LAS OBRAS
                    ActividadesProyectos();

                    EstadoDiario();

                    JornadasHoras();

                    //ListarIngenieros();
                    DetalleTrabajos();
                    //DetalleTrabajos();
                }


            }
            else
            {

                MessageBox.Show(ls_error);
            }
        }
        public void EstadoDiario()
        {
            BE_TBPARAMETROS objCab = new BE_TBPARAMETROS();
            BL_FUNCIONES obj = new BL_FUNCIONES();
            DataTable dt = new DataTable();
            dt.Clear();
            DataEstadiDiario.Clear();
            LstEstadoDiario.Clear();

            objCab.DES_TABLA = "ASISTENCIA_PERSONAL";
            objCab.DES_CAMPO = "IDE_ESTADO_DIARIO";
            objCab.IDE_EMPRESA = Convert.ToInt32(cboEmpresa.SelectedValue);
            objCab.CENTRO_COSTO = cboCentroCosto.SelectedValue.ToString();
            objCab.FECHA = dateTareo.Value.Date.ToString("dd/MM/yyyy");
            dt = obj.ListarEstadoDiario("ASISTENCIA_PERSONAL", "IDE_ESTADO_DIARIO", objCab.IDE_EMPRESA, objCab.CENTRO_COSTO.ToString(), objCab.FECHA.ToString(), dateTareo.Value.Date.ToString("dddd"));
            if (dt.Rows.Count > 0)
            {
                LstEstadoDiario = new BL_FUNCIONES().f_list_EstadoDiario(objCab);
                foreach (DataRow row in dt.Rows)
                {
                    DataEstadiDiario.Add(Convert.ToString(row["DES_ABREVIADO"]));
                }

            }
            else
            {
                dt.Rows.Clear();
                dt.Clear();
                DataEstadiDiario.Clear();
            }
        }
        public void ActividadesProyectos()
        {
            BE_CABECERA objCab = new BE_CABECERA();
            BL_FUNCIONES obj = new BL_FUNCIONES();
            DataTable dt = new DataTable();
            DataActividades.Clear();
            DataActividadesPK.Clear();
            dsActividad.Clear();
            LstActividades.Clear();

            objCab.TIPO = Convert.ToInt32(1);
            objCab.ID_PROYECTO = string.IsNullOrEmpty(cboCentroCosto.SelectedValue.ToString()) ? "0" : cboCentroCosto.SelectedValue.ToString();
            objCab.IDE_ACTIVIDAD = "1";
            objCab.ID_TAREA = "1";
            objCab.IDE_EMPRESA = Convert.ToInt32(cboEmpresa.SelectedValue);
            objCab.TIPO_ARCHIVO = cboFile.SelectedValue.ToString();

            dt = obj.USP_OBTENER_TODAS_TAREAS_PROYECTO(1, cboCentroCosto.SelectedValue.ToString(), "1", "1", Convert.ToInt32(cboEmpresa.SelectedValue), Convert.ToInt32(cboFile.SelectedValue));

            if (dt.Rows.Count > 0)
            {
                //dsActividad = obj.Listar_ActividadTarea(1, cboCentroCosto.SelectedValue.ToString(), "1", "1", Convert.ToInt32(cboEmpresa.SelectedValue), Convert.ToInt32(cboFile.SelectedValue));
                dsActividad = dt;



                LstActividades = UserCode.Conversion_DataTable_Lista.ucTablaLista<BE_CABECERA>.TablaALista(dt);


                //LstActividades = new BL_CONTROL_AVANCE().f_list_TareProyecto(objCab);
                //if (DataActividades.Count <= 0)
                //{
                foreach (DataRow row in dt.Rows)
                {

                    DataActividades.Add(Convert.ToString(row["DESCRIPCION"]));
                    DataActividadesPK.Add(Convert.ToString(row["PK_TAREA"]));
                }
                //}
            }
            else
            {
                dt.Rows.Clear();
                dt.Clear();
                //DataActividades.Clear();
            }
        }

       

        /// <summary>
        /// 
        /// </summary>
        protected void ConsultarTareo()
        {

            BL_ASIGNACION_TAREO obj = new BL_ASIGNACION_TAREO();
            DataTable dtResultado = new DataTable();


            dtResultado = obj.Listar_TareoFecha(Convert.ToInt32(cboEmpresa.SelectedValue.ToString()), cboCentroCosto.SelectedValue.ToString(), dateTareo.Value.Date.ToString("dd/MM/yyyy"));

            if (dtResultado.Rows.Count > 0)
            {
                lblIDE_TAREO_ASIGNACION.Text = dtResultado.Rows[0]["IDE_TAREO_ASIGNACION"].ToString();
                string FLG_ESTADO = dtResultado.Rows[0]["FLG_ESTADO"].ToString();
                string FLG_MIGRADO = dtResultado.Rows[0]["FLG_MIGRADO"].ToString();
                lblEstado.Text = FLG_ESTADO;

                if (FLG_ESTADO == "0")
                {
                    //btnGuardarActividad.Visible = false;
                    btnGuardarTareo.Visible = false;
                    btnAsignar.Visible = false;
                    checkBox2.Visible = false;
                    //Keys.KeyCode.
                }
                else
                {
                    checkBox2.Visible = true;
                    //btnGuardarActividad.Visible = true;
                    btnGuardarTareo.Visible = true;
                    btnAsignar.Visible = true;
                }

            }
            else
            {
                lblEstado.Text = "1";
            }


        }
        protected void ListarIngenieros()
        {
            BL_ASIGNACION_TAREAS obj = new BL_ASIGNACION_TAREAS();
            DataTable dtResultado = new DataTable();

            //if (lblEstado.Text == "1")
            //{

            //    dtResultado = obj.obtener_PersonalCategoria(cboCentroCosto.SelectedValue.ToString(), Convert.ToInt32(cboEmpresa.SelectedValue), "INGENIERO", null, dateTareo.Value.Date.ToString("dd/MM/yyyy"));
            //    if (dtResultado.Rows.Count > 0)
            //    {
            //        cboIngeniero.ValueMember = "ID_PERSONAL";
            //        cboIngeniero.DisplayMember = "NOMBRES";
            //        cboIngeniero.DataSource = dtResultado;
            //        ListarCapataz();
            //    }
            //}
            //else
            //{

            //    dtResultado = obj.OBTENER_PERSONAL_RESPONSABLES_TAREO(cboCentroCosto.SelectedValue.ToString(), Convert.ToInt32(cboEmpresa.SelectedValue), dateTareo.Value.Date.ToString("dd/MM/yyyy"), 1, "");
            //    if (dtResultado.Rows.Count > 0)
            //    {
            //        cboIngeniero.ValueMember = "ID_PERSONAL";
            //        cboIngeniero.DisplayMember = "NOMBRES";
            //        cboIngeniero.DataSource = dtResultado;
            //        ListarCapataz();
            //    }
            //}

            if (lblEstado.Text == "1")
            {

                //dtResultado = obj.obtener_PersonalCategoria(cboCentroCosto.SelectedValue.ToString(), Convert.ToInt32(cboEmpresa.SelectedValue), "INGENIERO", null, dateTareo.Value.Date.ToString("dd/MM/yyyy"));

                dtResultado = obj.SP_OBTENER_EQUIPO_TRABAJO_TAREO(cboCentroCosto.SelectedValue.ToString(), "1", "1", "", dateTareo.Value.Date.ToString("dd/MM/yyyy"));
                if (dtResultado.Rows.Count > 0)
                {
                    cboIngeniero.ValueMember = "ID_PERSONAL";
                    cboIngeniero.DisplayMember = "NOMBRES";
                    cboIngeniero.DataSource = dtResultado;
                    ListarCapataz();
                }
            }
            else
            {

                dtResultado = obj.OBTENER_PERSONAL_RESPONSABLES_TAREO(cboCentroCosto.SelectedValue.ToString(), Convert.ToInt32(cboEmpresa.SelectedValue), dateTareo.Value.Date.ToString("dd/MM/yyyy"), 1, "");
                if (dtResultado.Rows.Count > 0)
                {
                    cboIngeniero.ValueMember = "ID_PERSONAL";
                    cboIngeniero.DisplayMember = "NOMBRES";
                    cboIngeniero.DataSource = dtResultado;
                    ListarCapataz();
                }
            }
        }
        protected void ListarCapataz()
        {
            BL_ASIGNACION_TAREAS obj = new BL_ASIGNACION_TAREAS();
            DataTable dtResultado = new DataTable();
            //if (lblEstado.Text == "1")
            //{
            //    dtResultado = obj.obtener_PersonalCategoria(cboCentroCosto.SelectedValue.ToString(), Convert.ToInt32(cboEmpresa.SelectedValue), "RESPONSABLE CUADRILLA", cboIngeniero.SelectedValue.ToString(), dateTareo.Value.Date.ToString("dd/MM/yyyy"));
            //    if (dtResultado.Rows.Count > 0)
            //    {
            //        cboCapataces.Visible = true;
            //        cboCapataces.ValueMember = "ID_PERSONAL";
            //        cboCapataces.DisplayMember = "NOMBRES";
            //        cboCapataces.DataSource = dtResultado;

            //        DetalleTrabajos();
            //    }
            //    else
            //    {
            //        cboCapataces.Visible = false;

            //        MessageBox.Show("No existen responsables de cuadrillas asignados al" + Environment.NewLine +
            //            "Sr. " + cboIngeniero.Text + " " + Environment.NewLine +
            //            "Ingresar Opción : Configuración -> Asignación de responsables", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //        return;
            //    }
            //}
            //else
            //{
            //    dtResultado = obj.OBTENER_PERSONAL_RESPONSABLES_TAREO(cboCentroCosto.SelectedValue.ToString(), Convert.ToInt32(cboEmpresa.SelectedValue), dateTareo.Value.Date.ToString("dd/MM/yyyy"), 2, cboIngeniero.SelectedValue.ToString());
            //    if (dtResultado.Rows.Count > 0)
            //    {
            //        cboCapataces.ValueMember = "ID_PERSONAL";
            //        cboCapataces.DisplayMember = "NOMBRES";
            //        cboCapataces.DataSource = dtResultado;
            //        DetalleTrabajos();
            //    }
            //}
            if (lblEstado.Text == "1")
            {
                //dtResultado = obj.obtener_PersonalCategoria(cboCentroCosto.SelectedValue.ToString(), Convert.ToInt32(cboEmpresa.SelectedValue), "RESPONSABLE CUADRILLA", cboIngeniero.SelectedValue.ToString(), dateTareo.Value.Date.ToString("dd/MM/yyyy"));

                dtResultado = obj.SP_OBTENER_EQUIPO_TRABAJO_TAREO(cboCentroCosto.SelectedValue.ToString(), "1", "2", cboIngeniero.SelectedValue.ToString(), dateTareo.Value.Date.ToString("dd/MM/yyyy"));
                if (dtResultado.Rows.Count > 0)
                {
                    cboCapataces.Visible = true;
                    cboCapataces.ValueMember = "ID_PERSONAL";
                    cboCapataces.DisplayMember = "NOMBRES";
                    cboCapataces.DataSource = dtResultado;
                }
                else
                {

                    //cboCapataz.Visible = false;
                    cboCapataces.ValueMember = "ID_PERSONAL";
                    cboCapataces.DisplayMember = "NOMBRES";
                    cboCapataces.DataSource = dtResultado;
                    cboCapataces.Text = string.Empty;


                    MessageBox.Show("No existen responsables de cuadrillas asignados al" + Environment.NewLine +
                        "Sr. " + cboIngeniero.Text + " " + Environment.NewLine +
                        "Ingresar opción : Configuración -> Asignación de responsables", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            else
            {
                dtResultado = obj.OBTENER_PERSONAL_RESPONSABLES_TAREO(cboCentroCosto.SelectedValue.ToString(), Convert.ToInt32(cboEmpresa.SelectedValue), dateTareo.Value.Date.ToString("dd/MM/yyyy"), 2, cboIngeniero.SelectedValue.ToString());
                if (dtResultado.Rows.Count > 0)
                {
                    cboCapataces.ValueMember = "ID_PERSONAL";
                    cboCapataces.DisplayMember = "NOMBRES";
                    cboCapataces.DataSource = dtResultado;
                }
            }
        }

        private void cboIngeniero_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarCapataz();
        }
        protected void DetalleTrabajos()
        {
            int verTotal;
            if (checkBox1.Checked )
            {
                verTotal = 1;
            }
            else
            {
                verTotal = 0;
            }



            string  TOTAL_HH = "";
            gridDetalle.Rows.Clear();
            gridDetalle.Refresh();
            gridDetalle.DataSource = null;
            gridDetalle.Columns.Clear();
            gridDetalle.AllowUserToAddRows = true;
            gridDetalle.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //gridDetalle.AutoGenerateColumns = false;
            int CANTIDAD_PERSONAL = 0;


            //gridDetalle.ColumnCount = 5;

            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "Item";
            checkBoxColumn.ToolTipText = "Disponible";
            checkBoxColumn.Width = 30;
            checkBoxColumn.Name = "Seleccion";
            gridDetalle.Columns.Insert(0, checkBoxColumn);


            DataGridViewTextBoxColumn colItem = new DataGridViewTextBoxColumn();
            colItem.Name = "Item";
            colItem.HeaderText = "N°";
            colItem.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colItem.Width = 30;
            gridDetalle.Columns.Insert(1, colItem);

            DataGridViewTextBoxColumn colIDE_PERSONAL = new DataGridViewTextBoxColumn();
            colIDE_PERSONAL.Name = "IDE_PERSONAL";
            colIDE_PERSONAL.HeaderText = "IDE_PERSONAL";
            gridDetalle.Columns.Insert(2, colIDE_PERSONAL);

            DataGridViewTextBoxColumn colApellidos = new DataGridViewTextBoxColumn();
            colApellidos.Name = "Apellidos";
            colApellidos.HeaderText = "Apellidos y nombres";
            //colApellidos.Width = 350;
            gridDetalle.Columns.Insert(3, colApellidos);

            DataGridViewTextBoxColumn colEspecialidad = new DataGridViewTextBoxColumn();
            colEspecialidad.Name = "Especialidad";
            colEspecialidad.HeaderText = "Especialidad";
            colEspecialidad.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //colEspecialidad.Width = 30;
            gridDetalle.Columns.Insert(4, colEspecialidad);

            DataGridViewTextBoxColumn colCategoria = new DataGridViewTextBoxColumn();
            colCategoria.Name = "Categoria";
            colCategoria.HeaderText = "Categoria";
            colCategoria.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //colEspecialidad.Width = 30;
            gridDetalle.Columns.Insert(5, colCategoria);

            DataGridViewTextBoxColumn colAsistencia = new DataGridViewTextBoxColumn();
            colAsistencia.Name = "Asistencia";
            colAsistencia.HeaderText = "Asistencia";
            colAsistencia.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colAsistencia.DefaultCellStyle.BackColor = Color.FromArgb(255, 248, 110);
            gridDetalle.Columns.Insert(6, colAsistencia);

            

            DataGridViewTextBoxColumn colED = new DataGridViewTextBoxColumn();
            colED.Name = "EstadoDiario";
            colED.HeaderText = "E/F";
            colED.Width = 40;
            colED.ReadOnly = true;
            colED.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridDetalle.Columns.Insert(7, colED);


            

            DataGridViewTextBoxColumn colCtas = new DataGridViewTextBoxColumn();
            colCtas.Name = "Ctas";
            colCtas.HeaderText = "Cta Costo";
            colCtas.Width = 200;
            //colCtas.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;
            gridDetalle.Columns.Insert(8, colCtas);


            DataGridViewTextBoxColumn colWork_Group = new DataGridViewTextBoxColumn();
            colWork_Group.Name = "Work_Group";
            colWork_Group.HeaderText = "WG";
            colWork_Group.Width = 60;
            //colWork_Group.ReadOnly = true;
            colWork_Group.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colWork_Group.DefaultCellStyle.BackColor = Color.FromArgb(0, 255, 225);
            gridDetalle.Columns.Insert(9, colWork_Group);


            DataGridViewTextBoxColumn colHH = new DataGridViewTextBoxColumn();
            colHH.Name = "HH";
            colHH.HeaderText = "HH";
            colHH.Width = 45;
            colHH.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridDetalle.Columns.Insert(10, colHH);

            DataGridViewTextBoxColumn colTotal = new DataGridViewTextBoxColumn();
            colTotal.Name = "Total";
            colTotal.HeaderText = "Total";
            colTotal.DefaultCellStyle.BackColor = Color.FromArgb(218, 247, 166);
            colTotal.Width = 45;
            colTotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridDetalle.Columns.Add(colTotal);

            DataGridViewButtonColumn btnMas = new DataGridViewButtonColumn();
            gridDetalle.Columns.Add(btnMas);
            btnMas.HeaderText = "Actividad";
            btnMas.Text = "(+)";
            btnMas.Name = "btnMas";
            btnMas.Width = 50;
            btnMas.UseColumnTextForButtonValue = true;

            DataGridViewTextBoxColumn colHNoct = new DataGridViewTextBoxColumn();
            colHNoct.Name = "HNoct";
            colHNoct.HeaderText = "HNoct";
            colHNoct.Width = 50;
            colHNoct.DataPropertyName = "35";
            colHNoct.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridDetalle.Columns.Add(colHNoct);

            DataGridViewTextBoxColumn colHAlt = new DataGridViewTextBoxColumn();
            colHAlt.Name = "HAlt";
            colHAlt.HeaderText = "HAlt";
            colHAlt.Width = 50;
            colHAlt.DataPropertyName = "36";
            colHAlt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridDetalle.Columns.Add(colHAlt);

            DataGridViewTextBoxColumn colHAgua = new DataGridViewTextBoxColumn();
            colHAgua.Name = "HAgua";
            colHAgua.HeaderText = "HAgua";
            colHAgua.Width = 50;
            colHAgua.DataPropertyName = "37";
            colHAgua.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridDetalle.Columns.Add(colHAgua);

            DataGridViewTextBoxColumn colHTunel = new DataGridViewTextBoxColumn();
            colHTunel.Name = "HTunel";
            colHTunel.HeaderText = "HTunel";
            colHTunel.Width = 50;
            colHTunel.DataPropertyName = "38";
            colHTunel.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridDetalle.Columns.Add(colHTunel);

            DataGridViewTextBoxColumn colTotalMax = new DataGridViewTextBoxColumn();
            colTotalMax.Name = "TotalMax";
            colTotalMax.HeaderText = "Total";
            colTotalMax.Width = 50;
            colTotalMax.DefaultCellStyle.BackColor = Color.FromArgb(218, 247, 166);
            colTotalMax.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridDetalle.Columns.Add(colTotalMax);

            DataGridViewTextBoxColumn colID_CATEGORIA = new DataGridViewTextBoxColumn();
            colID_CATEGORIA.Name = "ID_CATEGORIA";
            colID_CATEGORIA.HeaderText = "ID_CATEGORIA";
            colID_CATEGORIA.Width = 55;
            colID_CATEGORIA.DefaultCellStyle.BackColor = Color.FromArgb(218, 247, 166);
            colID_CATEGORIA.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridDetalle.Columns.Add(colID_CATEGORIA);


            DataGridViewTextBoxColumn colID_ESPECIALIDAD = new DataGridViewTextBoxColumn();
            colID_ESPECIALIDAD.Name = "ID_ESPECIALIDAD";
            colID_ESPECIALIDAD.HeaderText = "ID_ESPECIALIDAD";
            colID_ESPECIALIDAD.Width = 55;
            colID_ESPECIALIDAD.DefaultCellStyle.BackColor = Color.FromArgb(218, 247, 166);
            colID_ESPECIALIDAD.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridDetalle.Columns.Add(colID_ESPECIALIDAD);

            DataGridViewTextBoxColumn colCAPATAZ = new DataGridViewTextBoxColumn();
            colCAPATAZ.Name = "CAPATAZ";
            colCAPATAZ.HeaderText = "Capataz";
            colCAPATAZ.Width = 160;
            colCAPATAZ.DefaultCellStyle.BackColor = Color.FromArgb(218, 247, 166);
            //colCAPATAZ.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridDetalle.Columns.Add(colCAPATAZ);


            DataGridViewTextBoxColumn colINGENIERO = new DataGridViewTextBoxColumn();
            colINGENIERO.Name = "INGENIERO";
            colINGENIERO.HeaderText = "Ingeniero";
            colINGENIERO.Width = 160;
            colINGENIERO.DefaultCellStyle.BackColor = Color.FromArgb(218, 247, 166);
            //colINGENIERO.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridDetalle.Columns.Add(colINGENIERO);


            //tamaños
            //gridDetalle.Columns[0].Width = 30;
            gridDetalle.Columns["Especialidad"].Width = 100;
            gridDetalle.Columns["Asistencia"].Width = 60;
            gridDetalle.Columns["Categoria"].Width = 70;
            gridDetalle.Columns["Apellidos"].Width = 300;



            //celda bloqueados
            gridDetalle.Columns["Item"].ReadOnly = true;
            gridDetalle.Columns[3].ReadOnly = true;
            gridDetalle.Columns[4].ReadOnly = true;
            gridDetalle.Columns[5].ReadOnly = true;
            gridDetalle.Columns["Total"].ReadOnly = true;
            gridDetalle.Columns["TotalMax"].ReadOnly = true;

            gridDetalle.Columns["TotalMax"].Visible = false;
            gridDetalle.Columns["IDE_PERSONAL"].Visible = false;

            gridDetalle.Columns["ID_CATEGORIA"].Visible = false;
            gridDetalle.Columns["ID_ESPECIALIDAD"].Visible = false;
            //boton

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            gridDetalle.Columns.Add(btn);
            btn.HeaderText = "";
            btn.Text = "Limpiar";
            btn.Name = "btn";
            btn.UseColumnTextForButtonValue = true;

            //llenar trabajadores
            BL_CUADRILLA obj = new BL_CUADRILLA();
            DataTable dtResul = new DataTable();
            BL_PERSONAL objPersona = new BL_PERSONAL();
            string Padre = string.Empty;
            if (lblEstado.Text == "1")
            {
                gridDetalle.Columns["btn"].Visible = true;
                Padre = string.Empty;// cboCapataces.SelectedValue.ToString();
                string dateString = dateTareo.Value.Date.ToString("dddd");
                //dtResul = obj.SP_OBTENER_CUADRILLA_X_FECHA_WS(cboCentroCosto.SelectedValue.ToString(), Convert.ToInt32(cboEmpresa.SelectedValue), string.Empty , string.Empty, dateTareo.Value.Date.ToString("dd/MM/yyyy"), verTotal);
                dtResul = obj.SP_OBTENER_CUADRILLA_X_FECHA_directo(cboCentroCosto.SelectedValue.ToString(), Convert.ToInt32(cboEmpresa.SelectedValue), string.Empty, string.Empty, dateTareo.Value.Date.ToString("dd/MM/yyyy"), dateString,verTotal);

                


                CANTIDAD_PERSONAL = dtResul.Rows.Count;

                if (dtResul.Rows.Count > 0)
                {
                    //datos vacios
                    for (int i = 0; i < dtResul.Rows.Count; i++)
                    {
                        int renglon = gridDetalle.Rows.Add();

                        gridDetalle.Rows[renglon].Cells["Item"].Value = Convert.ToString(i + 1);
                        gridDetalle.Rows[renglon].Cells["IDE_PERSONAL"].Value = dtResul.Rows[i]["ID_PERSONAL"].ToString();
                        gridDetalle.Rows[renglon].Cells["Apellidos"].Value = dtResul.Rows[i]["NOMBRES"].ToString();
                        gridDetalle.Rows[renglon].Cells["Especialidad"].Value = dtResul.Rows[i]["ESPECIALIDAD"].ToString();
                        gridDetalle.Rows[renglon].Cells["Categoria"].Value = dtResul.Rows[i]["CATEGORIA"].ToString();
                        //gridDetalle.Rows[renglon].Cells["Ctas"].Value = dtResul.Rows[i]["CTA"].ToString();
                        gridDetalle.Rows[renglon].Cells["Ctas"].Value = dtResul.Rows[i]["DESCRIPCION"].ToString();

                        gridDetalle.Rows[renglon].Cells["Work_Group"].Value = dtResul.Rows[i]["Work_Group"].ToString();
                        gridDetalle.Rows[renglon].Cells["HH"].Value = dtResul.Rows[i]["HH"].ToString();
                        gridDetalle.Rows[renglon].Cells["Total"].Value = dtResul.Rows[i]["HORA_EMPLEADA"].ToString();
                        TOTAL_HH = dtResul.Rows[i]["HORA_EMPLEADA"].ToString();
                        string ED = dtResul.Rows[i]["ASISTENCIA"].ToString();
                        if (ED != string.Empty)
                        {
                            gridDetalle.Rows[renglon].Cells["Asistencia"].Value = dtResul.Rows[i]["ASISTENCIA"].ToString();
                        }
                        else
                        {
                            if (AsistenciaPersona == "F")
                            {
                                gridDetalle.Rows[renglon].Cells["Asistencia"].Value = AsistenciaPersona;
                                gridDetalle.Rows[renglon].Cells["EstadoDiario"].Value = EstDiario;
                                gridDetalle.Rows[renglon].Cells["EstadoDiario"].Style.BackColor = Color.FromArgb(244, 243, 226);
                            }
                        }


                        if (ED == "F" || ED == "E") // || ED == "B"
                        {
                            gridDetalle.Rows[renglon].Cells["EstadoDiario"].Value = EstDiario;
                            gridDetalle.Rows[renglon].Cells["EstadoDiario"].Style.BackColor = Color.FromArgb(244, 243, 226);
                        }


                        gridDetalle.Rows[renglon].Cells["HNoct"].Value = dtResul.Rows[i]["HNoct"].ToString();
                        gridDetalle.Rows[renglon].Cells["HAlt"].Value = dtResul.Rows[i]["HAlt"].ToString();
                        gridDetalle.Rows[renglon].Cells["HAgua"].Value = dtResul.Rows[i]["HAgua"].ToString();
                        gridDetalle.Rows[renglon].Cells["HTunel"].Value = dtResul.Rows[i]["HTunel"].ToString();

                        gridDetalle.Rows[renglon].Cells["ID_ESPECIALIDAD"].Value = dtResul.Rows[i]["ID_ESPECIALIDAD"].ToString();
                        gridDetalle.Rows[renglon].Cells["ID_CATEGORIA"].Value = dtResul.Rows[i]["ID_CATEGORIA"].ToString();

                        gridDetalle.Rows[renglon].Cells["CAPATAZ"].Value = dtResul.Rows[i]["CAPATAZ"].ToString();
                        gridDetalle.Rows[renglon].Cells["INGENIERO"].Value = dtResul.Rows[i]["INGENIERO"].ToString();

                        if (TOTAL_HH== string.Empty )
                        {
                            TOTAL_HH = "0";
                        }

                        if (Convert.ToDecimal (TOTAL_HH) > 24)
                        {
                            gridDetalle.Rows[renglon].Cells["Total"].Style.BackColor = Color.Red;
                        }
                    }
                }
            }
            else
            {
                string dateString = dateTareo.Value.Date.ToString("dddd");
                gridDetalle.Columns["btn"].Visible = false;
                BL_ASIGNACION_TAREAS objT = new BL_ASIGNACION_TAREAS();
              
                //dtResul = objT.SP_OBTENER_PERSONAL_TAREADO_FECHA_WS(cboCentroCosto.SelectedValue.ToString(), Convert.ToInt32(cboEmpresa.SelectedValue), string.Empty , 
                //    string.Empty, dateTareo.Value.Date.ToString("dd/MM/yyyy"), dateString, verTotal);

                dtResul = objT.SP_OBTENER_CUADRILLA_X_FECHA_directo(cboCentroCosto.SelectedValue.ToString(), Convert.ToInt32(cboEmpresa.SelectedValue), string.Empty,
                    string.Empty, dateTareo.Value.Date.ToString("dd/MM/yyyy"), dateString, verTotal);



                CANTIDAD_PERSONAL = dtResul.Rows.Count;
                if (dtResul.Rows.Count > 0)
                {
                    //datos vacios
                    for (int i = 0; i < dtResul.Rows.Count; i++)
                    {
                        int renglon = gridDetalle.Rows.Add();

                        gridDetalle.Rows[renglon].Cells["Item"].Value = Convert.ToString(i + 1);
                        gridDetalle.Rows[renglon].Cells["IDE_PERSONAL"].Value = dtResul.Rows[i]["ID_PERSONAL"].ToString();
                        gridDetalle.Rows[renglon].Cells["Apellidos"].Value = dtResul.Rows[i]["NOMBRES"].ToString();
                        gridDetalle.Rows[renglon].Cells["Especialidad"].Value = dtResul.Rows[i]["ESPECIALIDAD"].ToString();
                        gridDetalle.Rows[renglon].Cells["Categoria"].Value = dtResul.Rows[i]["CATEGORIA"].ToString();
                        //gridDetalle.Rows[renglon].Cells["Ctas"].Value = dtResul.Rows[i]["CTA"].ToString();
                        gridDetalle.Rows[renglon].Cells["Ctas"].Value = dtResul.Rows[i]["DESCRIPCION"].ToString();


                        gridDetalle.Rows[renglon].Cells["Work_Group"].Value = dtResul.Rows[i]["Work_Group"].ToString();
                        gridDetalle.Rows[renglon].Cells["HH"].Value = dtResul.Rows[i]["HH"].ToString();
                        gridDetalle.Rows[renglon].Cells["Total"].Value = dtResul.Rows[i]["HORA_EMPLEADA"].ToString();
                        //gridDetalle.Rows[renglon].Cells["Asistencia"].Value = dtResul.Rows[i]["ESTADO_DIARIO"].ToString();
                        TOTAL_HH = dtResul.Rows[i]["HORA_EMPLEADA"].ToString();
                        string ED = dtResul.Rows[i]["ESTADO_DIARIO"].ToString();

                        if (ED != string.Empty)
                        {
                            gridDetalle.Rows[renglon].Cells["Asistencia"].Value = dtResul.Rows[i]["ESTADO_DIARIO"].ToString();
                        }
                        else
                        {
                            if (AsistenciaPersona == "F")
                            {
                                gridDetalle.Rows[renglon].Cells["Asistencia"].Value = AsistenciaPersona;
                                gridDetalle.Rows[renglon].Cells["EstadoDiario"].Value = EstDiario;
                                gridDetalle.Rows[renglon].Cells["EstadoDiario"].Style.BackColor = Color.FromArgb(244, 243, 226);
                            }
                        }

                        if (ED == "F" || ED == "E") // || ED == "B"
                        {
                            gridDetalle.Rows[renglon].Cells["EstadoDiario"].Value = EstDiario;
                            gridDetalle.Rows[renglon].Cells["EstadoDiario"].Style.BackColor = Color.FromArgb(244, 243, 226);
                        }


                        gridDetalle.Rows[renglon].Cells["HNoct"].Value = dtResul.Rows[i]["HNoct"].ToString();
                        gridDetalle.Rows[renglon].Cells["HAlt"].Value = dtResul.Rows[i]["HAlt"].ToString();
                        gridDetalle.Rows[renglon].Cells["HAgua"].Value = dtResul.Rows[i]["HAgua"].ToString();
                        gridDetalle.Rows[renglon].Cells["HTunel"].Value = dtResul.Rows[i]["HTunel"].ToString();

                        gridDetalle.Rows[renglon].Cells["ID_ESPECIALIDAD"].Value = dtResul.Rows[i]["ID_ESPECIALIDAD"].ToString();
                        gridDetalle.Rows[renglon].Cells["ID_CATEGORIA"].Value = dtResul.Rows[i]["ID_CATEGORIA"].ToString();
                        gridDetalle.Rows[renglon].Cells["CAPATAZ"].Value = dtResul.Rows[i]["CAPATAZ"].ToString();
                        gridDetalle.Rows[renglon].Cells["INGENIERO"].Value = dtResul.Rows[i]["INGENIERO"].ToString();

                        if (TOTAL_HH == string.Empty)
                        {
                            TOTAL_HH = "0";
                        }

                        if (Convert.ToDecimal(TOTAL_HH) > 24)
                        {
                            gridDetalle.Rows[renglon].Cells["Total"].Style.BackColor = Color.Red;
                        }


                    }
                }

            }

            

        }

        private void gridDetalle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            string persona;
            string cta;
            string Asistencia;
            string HH;
            
            if (e.ColumnIndex > -1)
            {
                if (gridDetalle.Columns[e.ColumnIndex].Name == "btn")
                {
                    DialogResult respuesta = MessageBox.Show("¿Desea limpiar las horas de trabajo?", "Mensaje SSK", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (respuesta == DialogResult.Yes)
                    {
                        //grabar tareas
                        //GrabarDigitacionDelete();
                        DataGridViewRow rowx = gridDetalle.Rows[i];
                        persona = (rowx.Cells[2].Value == null) ? string.Empty : rowx.Cells[2].Value.ToString();// persona
                        if (persona != string.Empty)
                        {

                            BL_TAREO ObjDel = new BL_TAREO();

                            ObjDel.EliminarTareo_Personal(Convert.ToInt32(cboEmpresa.SelectedValue), cboCentroCosto.SelectedValue.ToString(), dateTareo.Value.Date.ToString("dd/MM/yyyy"), persona);

                            DetalleTrabajos();
                        }
                        else
                        {
                            MessageBox.Show("Operacion no permitida", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }


                }
                else if (gridDetalle.Columns[e.ColumnIndex].Name == "btnMas")
                {
                    
                    DataGridViewRow rowx = gridDetalle.Rows[i];
                    persona = (rowx.Cells["IDE_PERSONAL"].Value == null) ? string.Empty : rowx.Cells["IDE_PERSONAL"].Value.ToString();// persona
                    cta = (rowx.Cells["Ctas"].Value == null) ? string.Empty : rowx.Cells["Ctas"].Value.ToString();
                    Asistencia = (rowx.Cells["Asistencia"].Value == null) ? string.Empty : rowx.Cells["Asistencia"].Value.ToString();
                    HH = (rowx.Cells["HH"].Value == null) ? string.Empty : rowx.Cells["HH"].Value.ToString();

                    BL_ASIGNACION_TAREO objT = new BL_ASIGNACION_TAREO();
                    DataTable dtResultado = new DataTable();

                    string colorCta = (rowx.Cells["Ctas"].Style.BackColor.ToString() == null) ? string.Empty : rowx.Cells["Ctas"].Style.BackColor.ToString();
                    string colorHH = (rowx.Cells["HH"].Style.BackColor.ToString() == null) ? string.Empty : rowx.Cells["HH"].Style.BackColor.ToString();

                    if (colorCta != "Color [Red]" && colorHH != "Color [Red]")
                    {


                        if (cta != string.Empty)
                        {
                            dtResultado = objT.uspINS_ASIGNACION_TAREAS_DIRECTO(
                            cboCentroCosto.SelectedValue.ToString(),
                            dateTareo.Value.Date.ToString("dd/MM/yyyy"),
                            string.Empty,
                            string.Empty,
                            cta,
                            frmLogin.obj_user_E.IDE_USUARIO,
                            cboFile.SelectedValue.ToString(),
                            lblIDE_TAREO_ASIGNACION.Text
                            );

                            if (dtResultado.Rows.Count > 0)
                            {
                                string IDE_TAREA = dtResultado.Rows[0]["IDE_TAREA"].ToString();

                                if(HH != string.Empty )
                                {
                                    BE_TAREO Obj = new BE_TAREO();
                                    Obj.IDE_TRABAJO = Convert.ToInt32(0);
                                    Obj.IDE_TAREA = Convert.ToInt32(IDE_TAREA);
                                    Obj.DES_DNI = persona;
                                    Obj.HORA_EMPLEADA = Convert.ToDecimal(HH);
                                    Obj.IDE_INGCAMPO = string.Empty ;
                                    Obj.IDE_CAPATAZ = string.Empty;
                                    Obj.FLG_ESTADO = true;
                                    Obj.USUARIO_REGISTRA = frmLogin.obj_user_E.IDE_USUARIO;
                                    Obj.FECHA = dateTareo.Value.Date.ToString("dd/MM/yyyy");
                                    Obj.TIPO = 1;
                                    Obj.IDE_EMPRESA = Convert.ToInt32(cboEmpresa.SelectedValue);
                                    Obj.CCENTRO = cboCentroCosto.SelectedValue.ToString();
                                    Obj.IDE_BONIFICACION = 0;
                                    Obj.DES_ASISTENCIA = Asistencia;
                                    int rpta;
                                    rpta = new BL_TAREO().Mant_Insert_Trabajos(Obj);
                                    if (rpta > 0)
                                    {
                                        //valor = string.Empty;
                                        //registros++;
                                    }
                                }
                            }

                            //BONIFICACIONES
                             
                            

                            string valorBonHNoct = (rowx.Cells["HNoct"].Value == null) ? "0" : rowx.Cells["HNoct"].Value.ToString();
                            GuardarBono(persona, valorBonHNoct, "35", Asistencia);


                            string valorBonAlt = (rowx.Cells["HAlt"].Value == null) ? "0" : rowx.Cells["HAlt"].Value.ToString();
                            GuardarBono(persona, valorBonAlt, "36", Asistencia);


                            string valorBonAgua = (rowx.Cells["HAgua"].Value == null) ? "0" : rowx.Cells["HAgua"].Value.ToString();
                            GuardarBono(persona, valorBonAgua, "37", Asistencia);


                            string valorBonHTunel = (rowx.Cells["HTunel"].Value == null) ? "0" : rowx.Cells["HTunel"].Value.ToString();
                            GuardarBono(persona, valorBonHTunel, "38", Asistencia);



                        }
                    }


                    string color = gridDetalle.Rows[rowx.Index].Cells["Asistencia"].Style.BackColor.ToString();
                   
                    if (color != "Color [Red]")
                    {


                        // REGISTRO DE ASITENCIAS
                        BE_ASISTENCIA_PERSONAL ObjAsistencia = new BE_ASISTENCIA_PERSONAL();
                        ObjAsistencia.IDE_ASISTENCIA = 0;
                        ObjAsistencia.IDE_PERSONAL = persona;
                        ObjAsistencia.FEC_ASISTENCIA = dateTareo.Value.Date.ToString("dd/MM/yyyy");
                        ObjAsistencia.CCENTRO = cboCentroCosto.SelectedValue.ToString();
                        ObjAsistencia.IDE_EMPRESA = Convert.ToInt32(cboEmpresa.SelectedValue);
                        ObjAsistencia.USUARIO_REGISTRA = frmLogin.obj_user_E.IDE_USUARIO;
                        ObjAsistencia.IDE_ESTADO = Asistencia;
                        ObjAsistencia.SUPERVISOR = string.Empty ;

                        int rptAsistencia;
                        rptAsistencia = new BL_ASISTENCIA_PERSONAL().Mant_Insert_Asistencias(ObjAsistencia);
                    }

                    string estado = "0";
                    if (btnGuardarTareo.Visible == false)
                    {
                        estado = "0";
                    }
                    else
                    {
                        estado = "1";
                    }


                    obj_Tareas_E = new BE_ASIGNACION_TAREAS();
                    obj_Tareas_E.IDE_EMPRESA = Convert.ToInt32( cboEmpresa.SelectedValue.ToString());
                    obj_Tareas_E.CENTRO_COSTO = cboCentroCosto.SelectedValue.ToString();
                    obj_Tareas_E.FECHA_TAREO = dateTareo.Value.Date.ToString("dd/MM/yyyy");
                    obj_Tareas_E.IDE_INGCAMPO = string.Empty ;
                    obj_Tareas_E.IDE_CAPATAZ = string.Empty;
                    obj_Tareas_E.IDE_PERSONAL = persona;
                    obj_Tareas_E.ASISTENCIA = Asistencia;
                    obj_Tareas_E.FILE = cboFile.SelectedValue.ToString();
                    obj_Tareas_E.ESTADO = estado;
                    obj_Tareas_E.NOMBRE_TRABAJOR = (rowx.Cells["Apellidos"].Value == null) ? string.Empty : rowx.Cells["Apellidos"].Value.ToString();
                    obj_Tareas_E.IDE_TAREO_ASIGNACION = Convert.ToInt32(lblIDE_TAREO_ASIGNACION.Text);


                    frmDigitacionPopup f2 = new frmDigitacionPopup(); //creamos un objeto del formulario hijo
                    DialogResult res = f2.ShowDialog();
                    if (f2.varfNuevo > 0)
                    {

                        gridDetalle.Rows[rowx.Index].Cells["Total"].Value = f2.varTotal;

                        if (f2.varTotal > 24)
                        {
                            gridDetalle.Rows[rowx.Index].Cells["Total"].Style.BackColor = Color.Red;
                        }
                        else
                        {
                            gridDetalle.Rows[rowx.Index].Cells["Total"].Style.BackColor = Color.White;
                        }
                        //GrabarDigitacion();

                        //DetalleTrabajos ();
                    }

                }

            }
        }
        protected void txt_GV_ASISTENCIA_TextChanged(object sender, EventArgs e)
        {
            //gridDetalle.AllowUserToAddRows = false;
            string valor;
            colTarea = gridDetalle.CurrentCell.ColumnIndex;
            var box = (TextBox)sender;

            rowTarea = gridDetalle.CurrentCell.RowIndex;
            if (colTarea == 6)
            {

                DataGridViewRow Rows = gridDetalle.Rows[rowTarea];
                valor = box.Text;
                if (valor == string.Empty)
                {
                    valor = "FALTA";
                }
                BE_TBPARAMETROS result = LstEstadoDiario.Find(
                delegate (BE_TBPARAMETROS bk)
                {
                    return bk.DES_ABREVIADO == valor;
                }
                );


                if (result != null)
                {
                    gridDetalle.Rows[rowTarea].Cells["Asistencia"].Style.BackColor = Color.White;

                    // agregar horas
                    if (valor == "X")
                    {
                        gridDetalle.Rows[rowTarea].Cells["EstadoDiario"].Style.BackColor = Color.White;
                        gridDetalle.Rows[rowTarea].Cells["EstadoDiario"].Style.ForeColor = Color.Black;
                        gridDetalle.Rows[rowTarea].Cells["EstadoDiario"].Value = string.Empty;
                    }
                    else if (valor == "F")
                    {
                        gridDetalle.Rows[rowTarea].Cells["EstadoDiario"].Value = EstDiario;
                        gridDetalle.Rows[rowTarea].Cells["EstadoDiario"].Style.BackColor = Color.FromArgb(244, 243, 226);
                    }

                    else
                    {

                        gridDetalle.Rows[rowTarea].Cells["EstadoDiario"].Value = string.Empty;
                        gridDetalle.Rows[rowTarea].Cells["Ctas"].Value = string.Empty;
                        gridDetalle.Rows[rowTarea].Cells["HH"].Value = string.Empty;
                        gridDetalle.Rows[rowTarea].Cells["Total"].Value = string.Empty;

                        gridDetalle.Rows[rowTarea].Cells["HNoct"].Value = string.Empty;
                        gridDetalle.Rows[rowTarea].Cells["HAlt"].Value = string.Empty;
                        gridDetalle.Rows[rowTarea].Cells["HAgua"].Value = string.Empty;
                        gridDetalle.Rows[rowTarea].Cells["HTunel"].Value = string.Empty;

                        if (valor == "E") //|| valor == "B"
                        {
                            gridDetalle.Rows[rowTarea].Cells["EstadoDiario"].Value = EstDiario;
                            gridDetalle.Rows[rowTarea].Cells["EstadoDiario"].Style.BackColor = Color.FromArgb(244, 243, 226);
                            gridDetalle.Rows[rowTarea].Cells["Ctas"].Style.BackColor = Color.White;
                            gridDetalle.Rows[rowTarea].Cells["HH"].Style.BackColor = Color.White;
                        }
                        else if(valor == "B")
                        {
                            gridDetalle.Rows[rowTarea].Cells["Ctas"].Style.BackColor = Color.White;
                            gridDetalle.Rows[rowTarea].Cells["HH"].Style.BackColor = Color.White;
                            gridDetalle.Rows[rowTarea].Cells["EstadoDiario"].Style.BackColor = Color.White;
                        }
                    }

                }
                else
                {
                    gridDetalle.Rows[rowTarea].Cells[colTarea].ToolTipText = "Error, No existe Estado Diario";
                    gridDetalle.Rows[rowTarea].Cells[colTarea].Style.BackColor = Color.Red;
                    gridDetalle.Rows[rowTarea].Cells[colTarea].Value = string.Empty;

                    gridDetalle.Rows[rowTarea].Cells["EstadoDiario"].Style.BackColor = Color.White;
                    gridDetalle.Rows[rowTarea].Cells["EstadoDiario"].Value = string.Empty;

                }

            }
        }
        protected void txt_GV_CTAS_TextChanged(object sender, EventArgs e)
        {
            //gridDetalle.AllowUserToAddRows = false;
            string valor;
            colTarea = gridDetalle.CurrentCell.ColumnIndex;
            var box = (TextBox)sender;

            rowTarea = gridDetalle.CurrentCell.RowIndex;
            if (colTarea == 8)
            {

                DataGridViewRow Rows = gridDetalle.Rows[rowTarea];
                valor = box.Text;
                //if (valor == string.Empty)
                //{
                //    valor = "FALTA";
                //}
                BE_CABECERA result = LstActividades.Find(
                delegate (BE_CABECERA bk)
                {
                    return bk.DESCRIPCION == valor;
                }
                );


                if (result != null)
                {
                    gridDetalle.Rows[rowTarea].Cells["Ctas"].Style.BackColor = Color.White;

                    

                }
                else
                {
                    if (valor == string.Empty )
                    {
                        
                        gridDetalle.Rows[rowTarea].Cells[colTarea].Style.BackColor = Color.White;
                        gridDetalle.Rows[rowTarea].Cells[colTarea].Value = string.Empty;
                    }
                    else
                    {
                        gridDetalle.Rows[rowTarea].Cells[colTarea].ToolTipText = "Error, No existe cuenta de costo";
                        gridDetalle.Rows[rowTarea].Cells[colTarea].Style.BackColor = Color.Red;
                        gridDetalle.Rows[rowTarea].Cells[colTarea].Value = string.Empty;
                    }
                    

                    

                }

            }
        }
        protected void txt_AcumuladoHras_TextChanged(object sender, EventArgs e)
        {
            double Acumulado = 0;
            string valor = null;
            string Total = null;
            colTarea = gridDetalle.CurrentCell.ColumnIndex;
            rowTarea = gridDetalle.CurrentCell.RowIndex;
            var box = (TextBox)sender;
            //grabar tareas
            DataGridViewRow rowx = gridDetalle.Rows[rowTarea];
            gridDetalle.Rows[rowTarea].Cells[colTarea].Value = box.Text;


            try
            {

                if (colTarea == 9)
                {
                    valor = string.Empty;


                    valor = (rowx.Cells["HH"].Value == null) ? "0" : rowx.Cells["HH"].Value.ToString();
                    Total = (rowx.Cells["Total"].Value == null) ? "0" : rowx.Cells["Total"].Value.ToString();
                    if (valor == string.Empty)
                    {
                        valor = "0";
                    }
                    if (Total == string.Empty)
                    {
                        Total = "0";
                    }

                    if (Convert.ToDouble(valor) > HoraMaxima)
                    {
                        gridDetalle.Rows[rowTarea].Cells["HH"].Style.BackColor = Color.Red;
                        gridDetalle.Rows[rowTarea].Cells["HH"].Style.ForeColor = Color.White;
                        gridDetalle.Rows[rowTarea].Cells["HH"].ToolTipText = "No se permiten horas superior a " + Convert.ToString(HoraMaxima) + " Hrs.";
                    }
                    else
                    {
                        gridDetalle.Rows[rowTarea].Cells["HH"].Style.BackColor = Color.White;
                        gridDetalle.Rows[rowTarea].Cells["HH"].Style.ForeColor = Color.Black;
                    }


                    //Acumulado = Convert.ToDouble(Total) + Convert.ToDouble(valor);
                    //if (Acumulado > HoraMaxima)
                    //{
                    //    gridDetalle.Rows[rowTarea].Cells["Total"].Style.BackColor = Color.Red;
                    //    gridDetalle.Rows[rowTarea].Cells["Total"].Style.ForeColor = Color.White;
                     
                    //    gridDetalle.Rows[rowTarea].Cells["Total"].ToolTipText = "No se permiten horas superior a " + Convert.ToString(HoraMaxima) + " Hrs.";
                    //}
                    //else
                    //{
                    //    //gridDetalle.Rows[rowTarea].Cells["Total"].Value = Acumulado;
                    //    gridDetalle.Rows[rowTarea].Cells["Total"].Style.BackColor = Color.FromArgb(218, 247, 166);
                    //    gridDetalle.Rows[rowTarea].Cells["Total"].Style.ForeColor = Color.Black;

                    //}
                }

            }
            catch (Exception ex)
            {

            }

            
        }
        private void gridDetalle_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            bKeyPressNum_GV_DATA = false;
            colTarea = gridDetalle.CurrentCell.ColumnIndex;
            rowTarea = gridDetalle.CurrentCell.RowIndex;
            TextBox txt_GV_DATA = e.Control as TextBox;
            TextBox txt_GV_CTA = e.Control as TextBox;
            if (colTarea == 6) //ASISTENCIA
            {
                txt_GV_DATA.ReadOnly = false;
                bKeyPressNum_GV_DATA = false;
                if (txt_GV_DATA != null)
                {
                    //rowTarea = gridDetalle.CurrentCell.RowIndex;
                    //txt_GV_DATA.TextChanged += txt_GV_ASISTENCIA_TextChanged;

                    txt_GV_CTA.AutoCompleteMode = AutoCompleteMode.Suggest;
                    txt_GV_CTA.AutoCompleteSource = AutoCompleteSource.CustomSource;//CustomSource
                    txt_GV_CTA.AutoCompleteCustomSource = DataEstadiDiario; //autocompletar dsActividad;// 
                    rowTarea = gridDetalle.CurrentCell.RowIndex;
                    txt_GV_DATA.TextChanged += txt_GV_ASISTENCIA_TextChanged;




                }
            }
            else if (colTarea == 8) //CTAS COSTO
            {
                txt_GV_CTA.ReadOnly = false;
                bKeyPressNum_GV_DATA = false;
                if (txt_GV_CTA != null)
                {
                    txt_GV_CTA.AutoCompleteMode = AutoCompleteMode.Suggest;
                    txt_GV_CTA.AutoCompleteSource = AutoCompleteSource.CustomSource;//CustomSource
                    txt_GV_CTA.AutoCompleteCustomSource = DataActividades; //autocompletar dsActividad;// 
                    rowTarea = gridDetalle.CurrentCell.RowIndex;
                    txt_GV_CTA.TextChanged += txt_GV_CTAS_TextChanged;
                }
            }

            else
            {
                rowTarea = gridDetalle.CurrentCell.RowIndex;

               
                txt_GV_CTA.AutoCompleteCustomSource = null; //autocompletar dsActividad;// 

                string valorAsistencia = (gridDetalle.Rows[rowTarea].Cells["Asistencia"].Value == null) ? "" : gridDetalle.Rows[rowTarea].Cells["Asistencia"].Value.ToString();
                if (valorAsistencia == "F" || valorAsistencia == "X")
                {

                    txt_GV_DATA.ReadOnly = false;
                    int num;
                    bool isNumber = int.TryParse(gridDetalle.Columns[colTarea].Name, out num);

                    if (isNumber == true)
                    {
                        bKeyPressNum_GV_DATA = true;
                        if (txt_GV_DATA != null)
                        {
                            txt_GV_DATA.MaxLength = 4;
                            rowTarea = gridDetalle.CurrentCell.RowIndex;
                            txt_GV_DATA.KeyPress += txt_Numero_KeyPress;
                            //txt_GV_DATA.TextChanged += txt_AcumuladoHras_TextChanged;
                        }
                    }
                    else
                    {
                        if (gridDetalle.Columns[colTarea].Name.Substring(0, 2) == "HH")
                        {
                            bKeyPressNum_GV_DATA = true;
                            if (txt_GV_DATA != null)
                            {
                                txt_GV_DATA.MaxLength = 4;
                                rowTarea = gridDetalle.CurrentCell.RowIndex;
                                txt_GV_DATA.KeyPress += txt_Numero_KeyPress;
                                txt_GV_DATA.TextChanged += txt_AcumuladoHras_TextChanged;
                            }
                        }
                        else if (gridDetalle.Columns[colTarea].Name.Substring(0, 1) == "H")
                        {
                            bKeyPressNum_GV_DATA = true;
                            if (txt_GV_DATA != null)
                            {
                                txt_GV_DATA.MaxLength = 4;
                                rowTarea = gridDetalle.CurrentCell.RowIndex;
                                txt_GV_DATA.KeyPress += txt_Numero_KeyPress;
                                //txt_GV_DATA.TextChanged += txt_BonoHras_TextChanged;
                            }
                        }
                    }
                }
               
                else
                {
                    txt_GV_DATA.ReadOnly = true;
                }

            }

            txt_GV_DATA.KeyPress += new KeyPressEventHandler(txt_GV_DATA_KeyPress);
        }
        private void txt_Numero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back || (e.KeyChar == (char)'.') && !(sender as TextBox).Text.Contains("."))
            {
                return;
            }
            decimal isNumber = 0;
            e.Handled = !decimal.TryParse(e.KeyChar.ToString(), out isNumber);
        }
        private void txt_GV_DATA_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
            if (bKeyPressNum_GV_DATA == true)
            {
                if (e.KeyChar == (char)Keys.Back || (e.KeyChar == (char)'.') && !(sender as TextBox).Text.Contains("."))
                {
                    return;
                }
                decimal isNumber = 0;
                e.Handled = !decimal.TryParse(e.KeyChar.ToString(), out isNumber);
            }
            else
            {
                e.Handled = false;
            }
        }

        private void btnGuardarTareo_Click(object sender, EventArgs e)
        {
            int faltaEstado = 0;
            int SinHoras = 0;
            int CantError = 0;

            string dia = dateTareo.Value.Date.ToString("dddd").ToUpper();
            string estadoAsistencia = string.Empty;
            if (dia == "DOMINGO")
            {
                estadoAsistencia = "X";
            }
            else
            {
                estadoAsistencia = AsistenciaPersona;
            }

            for (int p = 0; p < gridDetalle.Rows.Count - 1; p++)
            {
                try
                {

                    string color1 = gridDetalle.Rows[p].Cells["Asistencia"].Style.BackColor.ToString();
                    string color2 = gridDetalle.Rows[p].Cells["Ctas"].Style.BackColor.ToString();
                    string color3 = gridDetalle.Rows[p].Cells["Asistencia"].Style.BackColor.ToString();
                    string color4 = gridDetalle.Rows[p].Cells["Total"].Style.BackColor.ToString();

                    if (color1 == "Color [Red]")
                    {
                        CantError++;
                    }
                    if (color2 == "Color [Red]")
                    {
                        CantError++;
                    }
                    if (color3 == "Color [Red]")
                    {
                        CantError++;
                    }
                    if (color4 == "Color [Red]")
                    {
                        CantError++;
                    }


                 

                    string estadoDiario = (gridDetalle.Rows[p].Cells["Asistencia"].Value == null) ? "" : gridDetalle.Rows[p].Cells["Asistencia"].Value.ToString();
                    if (estadoDiario == "")
                    {
                        faltaEstado++;
                    }

                    if ((gridDetalle.Rows[p].Cells["Asistencia"].Value.ToString() == "X") && (gridDetalle.Rows[p].Cells["Total"].Value.ToString() == "0") && estadoAsistencia == "")
                    {
                        SinHoras++;
                    }


                }
                catch (Exception ex)
                {

                }

            }

            if (faltaEstado > 0)
            {

                MessageBox.Show("Existen " + (faltaEstado).ToString() + " Obrero(s) sin asignación de trabajo(s)", "Falta Ingresar Estado Diario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            DialogResult respuesta = MessageBox.Show("¿Desea grabar tareo?", "Grabar Registros", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (respuesta == DialogResult.Yes)
            {

                if (SinHoras > 0)
                {
                    MessageBox.Show("Existen " + SinHoras.ToString() + " obrero(s) sin horas de trabajo, favor de verificar", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (CantError == 0)
                    {
                        GrabarDigitacion();
                    }

                    else
                    {
                        MessageBox.Show("Existen inconsistencia en la digitación, favor de verificar", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
                        
        }
        protected void GrabarDigitacion()
        {
           
            string ls_error = "";
            

            string persona, Work_Group;
            string cta;
            string Asistencia;
            string HH;

            UserCode.Conexion cn = new UserCode.Conexion();

            bool lb_conectado = cn.ProbarConexion(ref ls_error);

            if (lb_conectado == true)
            {
                //////////////////

                string CAPATAZ = string.Empty;
                string INGENIERO = string.Empty;

                INGENIERO = string.Empty ;
                CAPATAZ = string.Empty ;

                for (int p = 0; p < gridDetalle.Rows.Count - 1; p++)
                {
                    DataGridViewRow rowx = gridDetalle.Rows[p];
                    persona = (rowx.Cells["IDE_PERSONAL"].Value == null) ? string.Empty : rowx.Cells["IDE_PERSONAL"].Value.ToString();// persona
                    cta = (rowx.Cells["Ctas"].Value == null) ? string.Empty : rowx.Cells["Ctas"].Value.ToString();
                    Asistencia = (rowx.Cells["Asistencia"].Value == null) ? string.Empty : rowx.Cells["Asistencia"].Value.ToString();
                    HH = (rowx.Cells["HH"].Value == null) ? string.Empty : rowx.Cells["HH"].Value.ToString();
                    Work_Group = (rowx.Cells["Work_Group"].Value == null) ? string.Empty : rowx.Cells["Work_Group"].Value.ToString();

                    BL_ASIGNACION_TAREO objT = new BL_ASIGNACION_TAREO();
                    DataTable dtResultado = new DataTable();


                    // REGISTRO DE ASITENCIAS
                    BE_ASISTENCIA_PERSONAL ObjAsistencia = new BE_ASISTENCIA_PERSONAL();
                    ObjAsistencia.IDE_ASISTENCIA = 0;
                    ObjAsistencia.IDE_PERSONAL = persona;
                    ObjAsistencia.FEC_ASISTENCIA = dateTareo.Value.Date.ToString("dd/MM/yyyy");
                    ObjAsistencia.CCENTRO = cboCentroCosto.SelectedValue.ToString();
                    ObjAsistencia.IDE_EMPRESA = Convert.ToInt32(cboEmpresa.SelectedValue);
                    ObjAsistencia.USUARIO_REGISTRA = frmLogin.obj_user_E.IDE_USUARIO;
                    ObjAsistencia.IDE_ESTADO = Asistencia;
                    ObjAsistencia.SUPERVISOR = string.Empty ;
                    ObjAsistencia.Work_Group = Work_Group;
                    int rptAsistencia;
                    rptAsistencia = new BL_ASISTENCIA_PERSONAL().Mant_Insert_Asistencias(ObjAsistencia);

                    if (cta != string.Empty)
                    {
                        dtResultado = objT.uspINS_ASIGNACION_TAREAS_DIRECTO(
                            cboCentroCosto.SelectedValue.ToString(),
                            dateTareo.Value.Date.ToString("dd/MM/yyyy"),
                            string.Empty ,
                            string.Empty ,
                            cta,
                            frmLogin.obj_user_E.IDE_USUARIO,
                            cboFile.SelectedValue.ToString(),
                            lblIDE_TAREO_ASIGNACION.Text
                            );

                        if (dtResultado.Rows.Count > 0)
                        {
                            string IDE_TAREA = dtResultado.Rows[0]["IDE_TAREA"].ToString();

                            if (HH != string.Empty)
                            {
                                BE_TAREO Obj = new BE_TAREO();
                                Obj.IDE_TRABAJO = Convert.ToInt32(0);
                                Obj.IDE_TAREA = Convert.ToInt32(IDE_TAREA);
                                Obj.DES_DNI = persona;
                                Obj.HORA_EMPLEADA = Convert.ToDecimal(HH);
                                Obj.IDE_INGCAMPO = string.Empty ;
                                Obj.IDE_CAPATAZ = string.Empty ;
                                Obj.FLG_ESTADO = true;
                                Obj.USUARIO_REGISTRA = frmLogin.obj_user_E.IDE_USUARIO;
                                Obj.FECHA = dateTareo.Value.Date.ToString("dd/MM/yyyy");
                                Obj.TIPO = 1;
                                Obj.IDE_EMPRESA = Convert.ToInt32(cboEmpresa.SelectedValue);
                                Obj.CCENTRO = cboCentroCosto.SelectedValue.ToString();
                                Obj.IDE_BONIFICACION = 0;
                                Obj.DES_ASISTENCIA = Asistencia;
                                int rpta;
                                rpta = new BL_TAREO().Mant_Insert_Trabajos(Obj);
                                if (rpta > 0)
                                {
                                    //valor = string.Empty;
                                    //registros++;
                                }
                            }
                        }

                        //BONIFICACIONES

                        ///////// grabar bono //////////////////

                        
                        
                        string valorBonHNoct = (rowx.Cells["HNoct"].Value == null) ? "0": rowx.Cells["HNoct"].Value.ToString();
                        GuardarBono( persona, valorBonHNoct,  "35",  Asistencia);

                        
                        string valorBonAlt = (rowx.Cells["HAlt"].Value == null) ? "0" : rowx.Cells["HAlt"].Value.ToString();
                        GuardarBono(persona, valorBonAlt, "36", Asistencia);

                       
                        string valorBonAgua = (rowx.Cells["HAgua"].Value == null) ? "0" : rowx.Cells["HAgua"].Value.ToString();
                        GuardarBono(persona, valorBonAgua, "37", Asistencia);

                      
                        string valorBonHTunel = (rowx.Cells["HTunel"].Value == null) ? "0" : rowx.Cells["HTunel"].Value.ToString();
                        GuardarBono(persona, valorBonHTunel, "38", Asistencia);


                        //for (int j = 0; j < 4; j++)
                        //{
                        //    string codBono = string.Empty;
                        //    string valorBon = string.Empty;
                        //    try
                        //    {
                        //        if (j == 0)
                        //        {
                        //            codBono = "35";
                        //            valorBon = (rowx.Cells["HNoct"].Value == null) ? string.Empty : rowx.Cells["HNoct"].Value.ToString();
                        //        }
                        //        else if (j == 1)
                        //        {
                        //            codBono = "36";
                        //            valorBon = (rowx.Cells["HAlt"].Value == null) ? string.Empty : rowx.Cells["HAlt"].Value.ToString();
                        //        }
                        //        else if (j == 2)
                        //        {
                        //            codBono = "37";
                        //            valorBon = (rowx.Cells["HAgua"].Value == null) ? string.Empty : rowx.Cells["HAgua"].Value.ToString();
                        //        }
                        //        else if (j == 3)
                        //        {
                        //            codBono = "38";
                        //            valorBon = (rowx.Cells["HTunel"].Value == null) ? string.Empty : rowx.Cells["HTunel"].Value.ToString();
                        //        }

                        //        if (valorBon != string.Empty)
                        //        {

                        //            BE_TAREO ObjBono = new BE_TAREO();
                        //            ObjBono.IDE_TRABAJO = Convert.ToInt32(0);
                        //            ObjBono.IDE_TAREA = 0;
                        //            ObjBono.DES_DNI = persona;
                        //            ObjBono.HORA_EMPLEADA = Convert.ToDecimal(valorBon);
                        //            ObjBono.IDE_INGCAMPO = string.Empty ;
                        //            ObjBono.IDE_CAPATAZ = string.Empty ;

                        //            ObjBono.FLG_ESTADO = true;
                        //            ObjBono.USUARIO_REGISTRA = frmLogin.obj_user_E.IDE_USUARIO;
                        //            ObjBono.FECHA = dateTareo.Value.Date.ToString("dd/MM/yyyy");
                        //            ObjBono.TIPO = 2;
                        //            ObjBono.IDE_EMPRESA = Convert.ToInt32(cboEmpresa.SelectedValue);
                        //            ObjBono.CCENTRO = cboCentroCosto.SelectedValue.ToString();
                        //            ObjBono.IDE_BONIFICACION = Convert.ToInt32(codBono);
                        //            ObjBono.DES_ASISTENCIA = Asistencia;
                        //            int rptaBono;
                        //            rptaBono = new BL_TAREO().Mant_Insert_Trabajos(ObjBono);
                        //            if (rptaBono > 0)
                        //            {
                        //                //registros++;
                        //            }
                        //        }
                        //    }
                        //    catch (Exception ex)
                        //    {

                        //    }
                        //}
                    }




                    

                   
                }
                DetalleTrabajos();
            }
            else
            {

                MessageBox.Show(ls_error);

            }
        }
        protected void GuardarBono(string persona,string valorBon,string codBono,string Asistencia)
        {
            if (valorBon != "")
            {

                BE_TAREO ObjBono = new BE_TAREO();
                ObjBono.IDE_TRABAJO = Convert.ToInt32(0);
                ObjBono.IDE_TAREA = 0;
                ObjBono.DES_DNI = persona;
                ObjBono.HORA_EMPLEADA = Convert.ToDecimal(valorBon);
                ObjBono.IDE_INGCAMPO = string.Empty;
                ObjBono.IDE_CAPATAZ = string.Empty;

                ObjBono.FLG_ESTADO = true;
                ObjBono.USUARIO_REGISTRA = frmLogin.obj_user_E.IDE_USUARIO;
                ObjBono.FECHA = dateTareo.Value.Date.ToString("dd/MM/yyyy");
                ObjBono.TIPO = 2;
                ObjBono.IDE_EMPRESA = Convert.ToInt32(cboEmpresa.SelectedValue);
                ObjBono.CCENTRO = cboCentroCosto.SelectedValue.ToString();
                ObjBono.IDE_BONIFICACION = Convert.ToInt32(codBono);
                ObjBono.DES_ASISTENCIA = Asistencia;
                int rptaBono;
                rptaBono = new BL_TAREO().Mant_Insert_Trabajos(ObjBono);
                if (rptaBono > 0)
                {
                    //registros++;
                }
            }
        }
        private void cboCapataces_SelectedIndexChanged(object sender, EventArgs e)
        {
            DetalleTrabajos();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            DetalleTrabajos();
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {

            BL_PERSONAL obj = new BL_PERSONAL();
            //
            // Se define una lista temporal de registro seleccionados
            //
            List<DataGridViewRow> rowSelected = new List<DataGridViewRow>();

            //
            // Se recorre ca registro de la grilla de origen
            //
            foreach (DataGridViewRow row in gridDetalle.Rows)
            {
                //
                // Se recupera el campo que representa el checkbox, y se valida la seleccion
                // agregandola a la lista temporal
                //
                DataGridViewCheckBoxCell cellSelecion = row.Cells["Seleccion"] as DataGridViewCheckBoxCell;

                if (Convert.ToBoolean(cellSelecion.Value))
                {
                    rowSelected.Add(row);
                }
            }

            //
            // Se agrega el item seleccionado a la grilla de destino
            // eliminando la fila de la grilla original
            //

            string personal = string.Empty;
            int cantidad = 0;
            foreach (DataGridViewRow row in rowSelected)
            {

                personal += row.Cells["IDE_PERSONAL"].Value + ",";
                cantidad++;
            }

            if(cantidad >0)
            {
                obj_Tareas_E = new BE_ASIGNACION_TAREAS();
                obj_Tareas_E.IDE_EMPRESA = Convert.ToInt32(cboEmpresa.SelectedValue.ToString());
                obj_Tareas_E.CENTRO_COSTO = cboCentroCosto.SelectedValue.ToString();
                obj_Tareas_E.FECHA_TAREO = dateTareo.Value.Date.ToString("dd/MM/yyyy");
                obj_Tareas_E.DNI_VARIOS = personal;
                obj_Tareas_E.IDE_TAREO_ASIGNACION = Convert.ToInt32(lblIDE_TAREO_ASIGNACION.Text);


                frmAsignarResponsables f2 = new frmAsignarResponsables(); //creamos un objeto del formulario hijo
                DialogResult res = f2.ShowDialog();
                if (f2.varfNuevo > 0)
                {

                    DetalleTrabajos();
                    //gridDetalle.Rows[rowx.Index].Cells["Total"].Value = f2.varTotal;

                    //if (f2.varTotal > 24)
                    //{
                    //    gridDetalle.Rows[rowx.Index].Cells["Total"].Style.BackColor = Color.Red;
                    //}
                    //else
                    //{
                    //    gridDetalle.Rows[rowx.Index].Cells["Total"].Style.BackColor = Color.White;
                    //}


                }
            }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == false)
            {
                foreach (DataGridViewRow row in gridDetalle.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                    if (chk.Value == chk.TrueValue)
                    {
                        chk.Value = chk.FalseValue;
                    }
                    else
                    {
                        chk.Value = chk.TrueValue;
                    }
                }
                //checkTodos.Checked = false;
                //checkTodos.Checked = 0;
                return;
            }
            else
            {
                foreach (DataGridViewRow row in gridDetalle.Rows)
                {
                    gridDetalle.Rows[row.Index].SetValues(true);
                }
                //checkTodos.Checked = true;
                //chkInt = dgvCuadrilla.Rows.Count;
            }
        }
    }
   
}
