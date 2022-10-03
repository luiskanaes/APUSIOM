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
    public partial class frmControlTareoTodo : Form
    {
        AutoCompleteStringCollection DataFrente = new AutoCompleteStringCollection();
        AutoCompleteStringCollection DataActividades = new AutoCompleteStringCollection();
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
        private static List<BE_TBPARAMETROS> LstAREAS = new List<BE_TBPARAMETROS>();
        private static List<BE_TBPARAMETROS> LstBonificacion = new List<BE_TBPARAMETROS>();
        private static List<BE_TBPARAMETROS> LstEstadoDiario = new List<BE_TBPARAMETROS>();
        public int varfNuevo;
        int row;
        int col;
        int colTarea;
        int rowTarea;
        int valor = 0;
        string MGridActividad = string.Empty;
        string MGridTareo = string.Empty;
        public static bool bSalir = false;
        decimal HoraMaxima = 24;
        decimal BonoMaxima = 24;
        decimal EstDiario = 0;// horas por dia de jornada
        string AsistenciaPersona;
        int cantidadTareas = 0;
        DataTable dtTareas;
        DataTable dtResulDisponible;

        int ColumnasFijas = 9;
        public frmControlTareoTodo()
        {
            InitializeComponent();
            lblEstado.Text = frmControlTareoDigitacion.obj_Tareo_E.FLG_ESTADO.ToString();
            if (lblEstado.Text == "1")
            {
                btnGuardar.Visible = true;
                btnGuardar.Enabled = true;
            }
            else
            {
                btnGuardar.Visible = false ;
                btnGuardar.Enabled = false ;
            }
            EstadoDiario();
            BL_ASIGNACION_TAREAS obj = new BL_ASIGNACION_TAREAS();
            dtResulDisponible = new DataTable();
            //dtResulDisponible = obj.SP_OBTENER_PERSONAL_TODO_X_FECHA(frmControlTareoDigitacion.obj_Tareo_E.IDE_CECOS, Convert.ToInt32(frmControlTareoDigitacion.obj_Tareo_E.IDE_EMPRESA), frmControlTareoDigitacion.obj_Tareo_E.FEC_TAREO);

            dtResulDisponible = obj.SP_OBTENER_PLANILLA_PERSONAL_OBRERO(frmControlTareoDigitacion.obj_Tareo_E.IDE_CECOS, Convert.ToInt32(frmControlTareoDigitacion.obj_Tareo_E.IDE_EMPRESA), frmControlTareoDigitacion.obj_Tareo_E.FEC_TAREO);

            int x = dtResulDisponible.Rows.Count;

            JornadasHoras();
            ListarIngenieros();



          
            

           
        }

        private void frmControlTareoTodo_Load(object sender, EventArgs e)
        {
           
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
            objCab.IDE_EMPRESA = Convert.ToInt32(frmControlTareoDigitacion.obj_Tareo_E.IDE_EMPRESA);
            objCab.CENTRO_COSTO = frmControlTareoDigitacion.obj_Tareo_E.IDE_CECOS ;
            objCab.FECHA = frmControlTareoDigitacion.obj_Tareo_E.FEC_TAREO;
            dt = obj.ListarEstadoDiario("ASISTENCIA_PERSONAL", "IDE_ESTADO_DIARIO", objCab.IDE_EMPRESA, objCab.CENTRO_COSTO.ToString(), objCab.FECHA.ToString(), frmControlTareoDigitacion.obj_Tareo_E.NOMBRE_DIA );
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
        protected void JornadasHoras()
        {
            int anio = DateTime.Now.Year;
            BL_FUNCIONES obj = new BL_FUNCIONES();
            DataTable dtResultado = new DataTable();
            string feriado;
            string dateString = frmControlTareoDigitacion.obj_Tareo_E.NOMBRE_DIA;
            dtResultado = obj.ListarHrasJorandas(frmControlTareoDigitacion.obj_Tareo_E.FEC_TAREO, Convert.ToInt32(frmControlTareoDigitacion.obj_Tareo_E.IDE_EMPRESA), frmControlTareoDigitacion.obj_Tareo_E.NOMBRE_DIA, frmControlTareoDigitacion.obj_Tareo_E.IDE_CECOS);
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
        protected void ListarIngenieros()
        {
            BL_ASIGNACION_TAREAS obj = new BL_ASIGNACION_TAREAS();
            DataTable dtResultado = new DataTable();

            if (lblEstado.Text == "1")
            {

                dtResultado = obj.SP_OBTENER_EQUIPO_TRABAJO_TAREO(frmControlTareoDigitacion.obj_Tareo_E.IDE_CECOS, "1", "1", "", frmControlTareoDigitacion.obj_Tareo_E.FEC_TAREO);
                //dtResultado = obj.obtener_PersonalCategoria(frmControlTareoDigitacion.obj_Tareo_E.IDE_CECOS , Convert.ToInt32(frmControlTareoDigitacion.obj_Tareo_E.IDE_EMPRESA), "INGENIERO", null, frmControlTareoDigitacion.obj_Tareo_E.FEC_TAREO);
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

                dtResultado = obj.OBTENER_PERSONAL_RESPONSABLES_TAREO(frmControlTareoDigitacion.obj_Tareo_E.IDE_CECOS , Convert.ToInt32(frmControlTareoDigitacion.obj_Tareo_E.IDE_EMPRESA), frmControlTareoDigitacion.obj_Tareo_E.FEC_TAREO, 1, "");
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
            if (lblEstado.Text == "1")
            {
                dtResultado = obj.SP_OBTENER_EQUIPO_TRABAJO_TAREO(frmControlTareoDigitacion.obj_Tareo_E.IDE_CECOS, "1", "2", cboIngeniero.SelectedValue.ToString(), frmControlTareoDigitacion.obj_Tareo_E.FEC_TAREO);
                //dtResultado = obj.obtener_PersonalCategoria(frmControlTareoDigitacion.obj_Tareo_E.IDE_CECOS , Convert.ToInt32(frmControlTareoDigitacion.obj_Tareo_E.IDE_EMPRESA), "RESPONSABLE CUADRILLA", cboIngeniero.SelectedValue.ToString(), frmControlTareoDigitacion.obj_Tareo_E.FEC_TAREO);
                if (dtResultado.Rows.Count > 0)
                {
                    cboCapataz.Visible = true;
                    cboTareas.Visible = true;
                    //btnGuardar.Visible = true;
                    cboCapataz.ValueMember = "ID_PERSONAL";
                    cboCapataz.DisplayMember = "NOMBRES";
                    cboCapataz.DataSource = dtResultado;
                }
                else
                {
                    cboCapataz.Visible = false;
                    cboTareas.Visible = false;
                    //btnGuardar.Visible = false ;
                    MessageBox.Show("No existen responsables de cuadrillas asignados al" + Environment.NewLine +
                        "Sr. " + cboIngeniero.Text + " " + Environment.NewLine +
                        "Ingresar Opción : Configuración -> Asignación de responsables", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            else
            {
                dtResultado = obj.OBTENER_PERSONAL_RESPONSABLES_TAREO(frmControlTareoDigitacion.obj_Tareo_E.IDE_CECOS , Convert.ToInt32(frmControlTareoDigitacion.obj_Tareo_E.IDE_EMPRESA), frmControlTareoDigitacion.obj_Tareo_E.FEC_TAREO, 2, cboIngeniero.SelectedValue.ToString());
                if (dtResultado.Rows.Count > 0)
                {
                    cboCapataz.ValueMember = "ID_PERSONAL";
                    cboCapataz.DisplayMember = "NOMBRES";
                    cboCapataz.DataSource = dtResultado;
                }
            }

        }

        private void cboIngeniero_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarCapataz();
        }

        private void cboCapataz_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarActividadesAsignadas();
        }
        protected void ListarActividadesAsignadas()
        {
            //ESTRUCTURA GRILLA
            BL_ASIGNACION_TAREAS xobj = new BL_ASIGNACION_TAREAS();
            DataTable dtResultado = new DataTable();

            valor = 0;

            valor = Convert.ToInt32(frmControlTareoDigitacion.obj_Tareo_E.IDE_DISCIPLINA);
            dtTareas = new DataTable();
            dtTareas.Clear();
            dtTareas = xobj.SEL_ASIGNACION_TAREAS_POR_FECHA_DISCIPLINA(frmControlTareoDigitacion.obj_Tareo_E.IDE_EMPRESA, frmControlTareoDigitacion.obj_Tareo_E.IDE_CECOS, null,
                frmControlTareoDigitacion.obj_Tareo_E.FEC_TAREO, cboCapataz.SelectedValue.ToString(), cboIngeniero.SelectedValue.ToString(), valor);

            cantidadTareas = dtTareas.Rows.Count;
            if (dtTareas.Rows.Count > 0)
            {
                cboTareas.Visible = true;
                //btnGuardar.Visible = true;
                //btnGuardar.Enabled =true;
                cboTareas.ValueMember = "IDE_TAREA";
                cboTareas.DisplayMember = "DESCRIPCION_LARGA";
                cboTareas.DataSource = dtTareas;
            }
            else
            {
                cboTareas.Visible = false ;
                //btnGuardar.Visible = false ;
                //btnGuardar.Enabled= false;
                MessageBox.Show("No existen tareas agregadas al Sr." + cboCapataz.Text.ToString ());
                return;
            }

            listarCuadrilla();
        }

        private void cboTareas_SelectedIndexChanged(object sender, EventArgs e)
        {
            //listarCuadrilla();
        }
        protected void listarCuadrilla()
        {
            BL_ASIGNACION_TAREAS xobj = new BL_ASIGNACION_TAREAS();
            
            if (dtTareas.Rows.Count > 0)
            {
                gridDetalle.Visible = true;
                DetalleTrabajos();

                //Variable donde almacenaremos el resultado de la sumatoria.
                double sumatoria = 0;
                //ColumnasFijas = 9
                for (int i = ColumnasFijas; i < gridDetalle.ColumnCount - 1; i++)
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
   
            }
            else
            {
                gridDetalle.Visible = false;
                gridDetalle.Rows.Clear();
                gridDetalle.Refresh();


                //DataGridViewRow rowTotal = gridDetalle.Rows[gridDetalle.Rows.Count - 1];
                //rowTotal.Cells["Total"].Value = 0;
            }



            BE_TBPARAMETROS objCab = new BE_TBPARAMETROS();
            objCab.DES_TABLA = "TAREO";
            objCab.DES_CAMPO = "IDE_BONIFICACION";
            LstBonificacion = new BL_FUNCIONES().f_list_Parametros(objCab);
            dsBonificacion = new BL_FUNCIONES().ListarParametros("TAREO", "IDE_BONIFICACION");
        }

        protected void EstructuraGrilla()
        {
            gridDetalle.Rows.Clear();
            gridDetalle.Refresh();
            gridDetalle.DataSource = null;
            gridDetalle.Columns.Clear();
            gridDetalle.AllowUserToAddRows = true;
            gridDetalle.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //gridDetalle.AutoGenerateColumns = false;


            //gridDetalle.ColumnCount = 5;

            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "Item";
            checkBoxColumn.ToolTipText = "Disponible";
            checkBoxColumn.Width = 50;
            checkBoxColumn.Name = "Seleccion";
            gridDetalle.Columns.Insert(0, checkBoxColumn);


            DataGridViewTextBoxColumn colItem = new DataGridViewTextBoxColumn();
            colItem.Name = "Item";
            colItem.HeaderText = "Item";
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


            DataGridViewTextBoxColumn colWork_Group = new DataGridViewTextBoxColumn();
            colWork_Group.Name = "Work_Group";
            colWork_Group.HeaderText = "WG";
            colWork_Group.Width = 70;
            //colWork_Group.ReadOnly = true;
            colWork_Group.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colWork_Group.DefaultCellStyle.BackColor = Color.FromArgb(0, 255, 225);
            gridDetalle.Columns.Insert(8, colWork_Group);

            //agregar columna de tareas agregadas en bd

            BL_ASIGNACION_TAREAS xobj = new BL_ASIGNACION_TAREAS();
            //DataTable dtResultado = new DataTable();
            int valor = 0;
            valor = Convert.ToInt32(frmControlTareoDigitacion.obj_Tareo_E.IDE_DISCIPLINA);
            if (dtTareas.Rows.Count > 0)
            {
                for (int i = 0; i < dtTareas.Rows.Count; i++)
                {

                    DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                    col.Name = dtTareas.Rows[i]["ITEM_ACTIVIDAD"].ToString();
                    col.DataPropertyName = dtTareas.Rows[i]["IDE_TAREA"].ToString();
                    col.HeaderText = "Tarea " + dtTareas.Rows[i]["ITEM_ACTIVIDAD"].ToString();
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    col.Width = 67;

                    gridDetalle.Columns.Add(col);
                }
            }



            DataGridViewTextBoxColumn colTotal = new DataGridViewTextBoxColumn();
            colTotal.Name = "Total";
            colTotal.HeaderText = "Total";
            colTotal.DefaultCellStyle.BackColor = Color.FromArgb(218, 247, 166);
            colTotal.Width = 55;
            colTotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridDetalle.Columns.Add(colTotal);

            BL_FUNCIONES Fobj = new BL_FUNCIONES();
            DataTable dtBonificacion = new DataTable();
            dtBonificacion = Fobj.ListarBonificacion(frmControlTareoDigitacion.obj_Tareo_E.IDE_CECOS, Convert.ToInt32(frmControlTareoDigitacion.obj_Tareo_E.IDE_EMPRESA));

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
            gridDetalle.Columns[1].Width = 30;
            gridDetalle.Columns["Especialidad"].Width = 100;
            gridDetalle.Columns["Asistencia"].Width = 60;
            gridDetalle.Columns["Categoria"].Width = 70;

            gridDetalle.Columns["Apellidos"].Width = 300;



            //celda bloqueados
            gridDetalle.Columns["Item"].ReadOnly = true;
            gridDetalle.Columns[2].ReadOnly = true;
            gridDetalle.Columns[3].ReadOnly = true;
            gridDetalle.Columns[4].ReadOnly = true;
            gridDetalle.Columns["Total"].ReadOnly = true;
            gridDetalle.Columns["TotalMax"].ReadOnly = true;

            gridDetalle.Columns["TotalMax"].Visible = false;
            gridDetalle.Columns["IDE_PERSONAL"].Visible = false;
            gridDetalle.Columns["Especialidad"].Visible = false;
            gridDetalle.Columns["Categoria"].Visible = false;
            //boton
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            gridDetalle.Columns.Add(btn);
            btn.HeaderText = "";
            btn.Text = "Limpiar";
            btn.Name = "btn";
            btn.UseColumnTextForButtonValue = true;



            
        }
        protected void DetalleTrabajos()
        {

            EstructuraGrilla();

            //llenar trabajadores
            //BL_ASIGNACION_TAREAS obj = new BL_ASIGNACION_TAREAS();

            BL_CUADRILLA obj = new BL_CUADRILLA();
            DataTable dtResul = new DataTable();
            BL_PERSONAL objPersona = new BL_PERSONAL();
            string Padre = string.Empty;
            if (lblEstado.Text == "1")
            {
                gridDetalle.Columns["btn"].Visible = true;

                Padre = string.Empty;

                if (checkCuadrilla.Checked)
                {
                    Padre = string.Empty;
                    //dtResul = obj.obtener_PersonalCategoria(frmControlTareoDigitacion.obj_Tareo_E.IDE_CECOS, Convert.ToInt32(frmControlTareoDigitacion.obj_Tareo_E.IDE_EMPRESA), "OBREROS", cboCapataz.SelectedValue.ToString(), frmControlTareoDigitacion.obj_Tareo_E.FEC_TAREO);
                    string dateString = frmControlTareoDigitacion.obj_Tareo_E.NOMBRE_DIA;
                    dtResul = obj.SP_OBTENER_CUADRILLA_X_FECHA(frmControlTareoDigitacion.obj_Tareo_E.IDE_CECOS, Convert.ToInt32(frmControlTareoDigitacion.obj_Tareo_E.IDE_EMPRESA), cboCapataz.SelectedValue.ToString(), frmControlTareoDigitacion.obj_Tareo_E.FEC_TAREO, cboIngeniero.SelectedValue.ToString(), dateString);


                    if (dtResul.Rows.Count > 0)
                    {
                        //datos vacios
                        for (int i = 0; i < dtResul.Rows.Count; i++)
                        {
                            DataGridViewRow row = (DataGridViewRow)gridDetalle.Rows[i].Clone();
                            row.Cells[0].Value = Convert.ToBoolean(dtResul.Rows[i]["SELECCIONAR"].ToString());
                            row.Cells[1].Value = Convert.ToString(i + 1);
                            row.Cells[2].Value = dtResul.Rows[i]["ID_PERSONAL"].ToString();
                            row.Cells[3].Value = dtResul.Rows[i]["NOMBRES"].ToString();
                            row.Cells[4].Value = dtResul.Rows[i]["ESPECIALIDAD"].ToString();
                            row.Cells[5].Value = dtResul.Rows[i]["CATEGORIA"].ToString();
                            row.Cells[8].Value = dtResul.Rows[i]["Work_Group"].ToString();
                            gridDetalle.Rows.Add(row);


                        }
                    }

                }
                else
                {
                    Padre = cboCapataz.SelectedValue.ToString();
                    int x = dtResulDisponible.Rows.Count;
                    DataTable dt = dtResulDisponible as DataTable;
                    DataView dv = dt.DefaultView;
                    if (txtApellidos.Text.Trim() != string.Empty)
                    {
                        dv.RowFilter = "NOMBRES LIKE '%" + txtApellidos.Text + "%'";

                        string FLG_LIBRE, ITEM, ID_PERSONAL, NOMBRES, ESPECIALIDAD, CATEGORIA, Work_Group;

                        string[] Xrow;
                        for (int i = 0; i < dv.Count; i++)
                        {
                            FLG_LIBRE = dv[i]["SELECCIONAR"].ToString();
                            ITEM = Convert.ToString(i + 1);
                            ID_PERSONAL = dv[i]["ID_PERSONAL"].ToString();
                            NOMBRES = dv[i]["NOMBRES"].ToString();
                            ESPECIALIDAD = dv[i]["ESPECIALIDAD"].ToString();
                            CATEGORIA = dv[i]["CATEGORIA"].ToString();
                            Work_Group = dv[i]["Work_Group"].ToString();
                            Xrow = new string[] {
                       Convert.ToBoolean( FLG_LIBRE).ToString (),ITEM, ID_PERSONAL, NOMBRES, ESPECIALIDAD, CATEGORIA,Work_Group
                    };
                            gridDetalle.Rows.Add(Xrow);

                        }
                    }
                }

                
            }
            else
            {
                string dateString = frmControlTareoDigitacion.obj_Tareo_E.NOMBRE_DIA ;
                gridDetalle.Columns["btn"].Visible = false;


                if (checkCuadrilla.Checked)
                {
                    Padre = string.Empty;
                    BL_ASIGNACION_TAREAS objT = new BL_ASIGNACION_TAREAS();

                    dtResul = objT.Lista_Personal_tareas_x_fecha(frmControlTareoDigitacion.obj_Tareo_E.IDE_CECOS, Convert.ToInt32(frmControlTareoDigitacion.obj_Tareo_E.IDE_EMPRESA), cboCapataz.SelectedValue.ToString(),frmControlTareoDigitacion.obj_Tareo_E.FEC_TAREO, dateString, cboIngeniero.SelectedValue.ToString());
                    if (dtResul.Rows.Count > 0)
                    {
                        //datos vacios
                        for (int i = 0; i < dtResul.Rows.Count; i++)
                        {
                            DataGridViewRow row = (DataGridViewRow)gridDetalle.Rows[i].Clone();
                            row.Cells[1].Value = Convert.ToString(i + 1);
                            row.Cells[2].Value = dtResul.Rows[i]["ID_PERSONAL"].ToString();
                            row.Cells[3].Value = dtResul.Rows[i]["NOMBRES"].ToString();
                            row.Cells[4].Value = dtResul.Rows[i]["ESPECIALIDAD"].ToString();
                            row.Cells[5].Value = dtResul.Rows[i]["CATEGORIA"].ToString();
                            row.Cells[8].Value = dtResul.Rows[i]["Work_Group"].ToString();
                            gridDetalle.Rows.Add(row);
                        }
                    }

                }
                else
                {
                    if (txtApellidos.Text.Trim() != string.Empty)
                    {
                        Padre = cboCapataz.SelectedValue.ToString();
                        DataTable dt = dtResulDisponible as DataTable;
                        DataView dv = dt.DefaultView;
                        dv.RowFilter = "NOMBRES LIKE '%" + txtApellidos.Text + "%'";

                        string FLG_LIBRE, ITEM, ID_PERSONAL, NOMBRES, ESPECIALIDAD, CATEGORIA, Work_Group;

                        string[] Xrow;
                        for (int i = 0; i < dv.Count; i++)
                        {
                            FLG_LIBRE = dv[i]["SELECCIONAR"].ToString();
                            ITEM = Convert.ToString(i + 1);
                            ID_PERSONAL = dv[i]["ID_PERSONAL"].ToString();
                            NOMBRES = dv[i]["NOMBRES"].ToString();
                            ESPECIALIDAD = dv[i]["ESPECIALIDAD"].ToString();
                            CATEGORIA = dv[i]["CATEGORIA"].ToString();
                            Work_Group = dv[i]["Work_Group"].ToString();
                            Xrow = new string[] {
                       Convert.ToBoolean( FLG_LIBRE).ToString (),ITEM, ID_PERSONAL, NOMBRES, ESPECIALIDAD, CATEGORIA,Work_Group
                    };
                            gridDetalle.Rows.Add(Xrow);

                        }
                    }
                }

            }





            //tareo personal
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
                codPersona = gridDetalle.Rows[i].Cells[2].Value.ToString();

                //ASISTENCIA
                dtAsistencia = Xobj.AsistenciaPersonal_tareo(Convert.ToInt32(frmControlTareoDigitacion.obj_Tareo_E.IDE_EMPRESA), frmControlTareoDigitacion.obj_Tareo_E.IDE_CECOS, frmControlTareoDigitacion.obj_Tareo_E.FEC_TAREO, codPersona);
                if (dtAsistencia.Rows.Count > 0)
                {
                    gridDetalle.Rows[i].Cells["Asistencia"].Value = dtAsistencia.Rows[0]["ESTADO_DIARIO"].ToString();
                    gridDetalle.Rows[i].Cells["Work_Group"].Value = dtAsistencia.Rows[0]["Work_Group"].ToString();
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
                
                valor = Convert.ToInt32(frmControlTareoDigitacion.obj_Tareo_E.IDE_DISCIPLINA);

                int cantidadTareas = dtTareas.Rows.Count;

                //CCS
                if (dtTareas.Rows.Count > 0)
                {
                    for (int mi = 0; mi < dtTareas.Rows.Count; mi++)
                    {
                        try
                        {
                            string codTarea = dtTareas.Rows[mi]["IDE_TAREA"].ToString();//codigo

                            dtResulTareo = Xobj.actividadesPersona_tareo(Convert.ToInt32(frmControlTareoDigitacion.obj_Tareo_E.IDE_EMPRESA), frmControlTareoDigitacion.obj_Tareo_E.IDE_CECOS, 1, frmControlTareoDigitacion.obj_Tareo_E.FEC_TAREO, codPersona, Convert.ToInt32(codTarea));
                            if (dtResulTareo.Rows.Count > 0)
                            {
                                Total = Total + Convert.ToDecimal(dtResulTareo.Rows[0]["HORA_EMPLEADA"].ToString());
                                gridDetalle.Rows[i].Cells[ColumnasFijas + mi].Value = dtResulTareo.Rows[0]["HORA_EMPLEADA"].ToString();

                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    gridDetalle.Rows[i].Cells[ColumnasFijas + cantidadTareas].Value = Total;
                }

                BL_FUNCIONES objfun = new BL_FUNCIONES();
                DataTable dtBonos = new DataTable();
                dtBonos = objfun.ListarBonificacion(frmControlTareoDigitacion.obj_Tareo_E.IDE_CECOS, Convert.ToInt32(frmControlTareoDigitacion.obj_Tareo_E.IDE_EMPRESA));

                if (dtBonos.Rows.Count > 0)
                {
                    for (int bi = 0; bi < dtBonos.Rows.Count; bi++)
                    {

                        try
                        {
                            string codBono = dtBonos.Rows[bi]["IDE_TIPO"].ToString();//codigo


                            dtResulTareo = Xobj.actividadesPersona_tareo(Convert.ToInt32(frmControlTareoDigitacion.obj_Tareo_E.IDE_EMPRESA), 
                                frmControlTareoDigitacion.obj_Tareo_E.IDE_CECOS, 2,
                                frmControlTareoDigitacion.obj_Tareo_E.FEC_TAREO, 
                                codPersona, Convert.ToInt32(codBono));
                            if (dtResulTareo.Rows.Count > 0)
                            {
                                TotalBono = TotalBono + Convert.ToDecimal(dtResulTareo.Rows[0]["HORA_EMPLEADA"].ToString());
                                gridDetalle.Rows[i].Cells[ColumnasFijas +1  + cantidadTareas + bi].Value = dtResulTareo.Rows[0]["HORA_EMPLEADA"].ToString();
                                decimal HValor = Convert.ToDecimal(string.IsNullOrEmpty(dtResulTareo.Rows[0]["HORA_EMPLEADA"].ToString()) ? "0" : dtResulTareo.Rows[0]["HORA_EMPLEADA"].ToString());
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }


            }
            MGridTareo = string.Empty;
   


        }

        private void checkCuadrilla_CheckedChanged(object sender, EventArgs e)
        {
            listarCuadrilla();
        }

        private void gridDetalle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            string persona;

            if (e.ColumnIndex > -1)
            {
                if (gridDetalle.Columns[e.ColumnIndex].Name == "btn")
                {
                    DialogResult respuesta = MessageBox.Show("¿Desea Limpiar las Horas de trabajo?", "Mensaje SSK", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (respuesta == DialogResult.Yes)
                    {
                        //grabar tareas
                        DataGridViewRow rowx = gridDetalle.Rows[i];
                        persona = (rowx.Cells[2].Value == null) ? string.Empty : rowx.Cells[2].Value.ToString();// persona
                        if (persona != string.Empty)
                        {
                            BL_TAREO ObjDel = new BL_TAREO();

                            ObjDel.EliminarTareo_Personal(Convert.ToInt32(frmControlTareoDigitacion.obj_Tareo_E.IDE_EMPRESA), frmControlTareoDigitacion.obj_Tareo_E.IDE_CECOS, frmControlTareoDigitacion.obj_Tareo_E.FEC_TAREO , persona);

                            listarCuadrilla();
                        }
                        else
                        {
                            MessageBox.Show("Operacion no permitida", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }


                }

            }
        }

        private void gridDetalle_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            bKeyPressNum_GV_DATA = false;
            colTarea = gridDetalle.CurrentCell.ColumnIndex;
            TextBox txt_GV_DATA = e.Control as TextBox;
            if (colTarea == 6) //ASISTENCIA
            {
                txt_GV_DATA.ReadOnly = false;
                bKeyPressNum_GV_DATA = false;
                if (txt_GV_DATA != null)
                {
                    rowTarea = gridDetalle.CurrentCell.RowIndex;
                    txt_GV_DATA.TextChanged += txt_GV_ASISTENCIA_TextChanged;
                }
            }

            else
            {
               
                rowTarea = gridDetalle.CurrentCell.RowIndex;
                gridDetalle.Rows[rowTarea].Cells["Seleccion"].Value = true;
                gridDetalle.Rows[rowTarea].DefaultCellStyle.BackColor = Color.FromArgb(255, 248, 110);
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
                            txt_GV_DATA.TextChanged += txt_AcumuladoHras_TextChanged;
                        }
                    }
                    else
                    {
                        if (gridDetalle.Columns[colTarea].Name.Substring(0, 1) == "H")
                        {
                            bKeyPressNum_GV_DATA = true;
                            if (txt_GV_DATA != null)
                            {
                                txt_GV_DATA.MaxLength = 4;
                                rowTarea = gridDetalle.CurrentCell.RowIndex;
                                txt_GV_DATA.KeyPress += txt_Numero_KeyPress;
                                txt_GV_DATA.TextChanged += txt_BonoHras_TextChanged;
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
        protected void txt_GV_ASISTENCIA_TextChanged(object sender, EventArgs e)
        {
            //gridDetalle.AllowUserToAddRows = false;
            string valor;
            colTarea = gridDetalle.CurrentCell.ColumnIndex;
            var box = (TextBox)sender;

            rowTarea = gridDetalle.CurrentCell.RowIndex;
            if (colTarea == 6)
            {
                gridDetalle.Rows[rowTarea].Cells["Seleccion"].Value = true;
                gridDetalle.Rows[rowTarea].DefaultCellStyle.BackColor = Color.FromArgb(255, 248, 110);

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

                        //int cantidadTareas = gridAsignacion.Rows.Count;
                        for (int j = 6; j <= ColumnasFijas +1  + cantidadTareas; j++)
                        {

                            try
                            {
                                int num;
                                bool isNumber = int.TryParse(gridDetalle.Columns[j].Name, out num);
                                if (isNumber == true)
                                {
                                    gridDetalle.Rows[rowTarea].Cells[j].Value = string.Empty;
                                }
                                else
                                {
                                    if (gridDetalle.Columns[j].Name.Substring(0, 1) == "H")
                                    {
                                        gridDetalle.Rows[rowTarea].Cells[j].Value = string.Empty;
                                    }
                                    else if (gridDetalle.Columns[j].Name == "Asistencia")
                                    {
                                        gridDetalle.Rows[rowTarea].Cells["EstadoDiario"].Style.BackColor = Color.White;
                                        gridDetalle.Rows[rowTarea].Cells["EstadoDiario"].Style.ForeColor = Color.Black;
                                        gridDetalle.Rows[rowTarea].Cells["EstadoDiario"].Value = string.Empty;
                                    }
                                }
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                        if (valor == "E") //|| valor == "B"
                        {
                            gridDetalle.Rows[rowTarea].Cells["EstadoDiario"].Value = EstDiario;
                            gridDetalle.Rows[rowTarea].Cells["EstadoDiario"].Style.BackColor = Color.FromArgb(244, 243, 226);
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
        private void txt_Numero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back || (e.KeyChar == (char)'.') && !(sender as TextBox).Text.Contains("."))
            {
                return;
            }
            decimal isNumber = 0;
            e.Handled = !decimal.TryParse(e.KeyChar.ToString(), out isNumber);
        }
        protected void txt_AcumuladoHras_TextChanged(object sender, EventArgs e)
        {
            decimal Acumulado = 0;
            string valor = null;
            colTarea = gridDetalle.CurrentCell.ColumnIndex;
            rowTarea = gridDetalle.CurrentCell.RowIndex;
            var box = (TextBox)sender;
            //grabar tareas
            DataGridViewRow rowx = gridDetalle.Rows[rowTarea];
            gridDetalle.Rows[rowTarea].Cells[colTarea].Value = box.Text;
            //int cantidadTareas = gridAsignacion.Rows.Count;
            // CCS
            for (int j = ColumnasFijas; j <= ColumnasFijas + cantidadTareas; j++)
            {

                try
                {
                    valor = string.Empty;
                    int num;
                    bool isNumber = int.TryParse(gridDetalle.Columns[j].Name, out num);
                    //valor =
                    if (isNumber == true)
                    {
                        valor = (rowx.Cells[j].Value == null) ? "0" : rowx.Cells[j].Value.ToString();
                        if (valor == string.Empty)
                        {
                            valor = "0";
                        }

                        if (Convert.ToDecimal(valor) > HoraMaxima)
                        {
                            gridDetalle.Rows[rowTarea].Cells[j].Style.BackColor = Color.Red;
                            gridDetalle.Rows[rowTarea].Cells[j].Style.ForeColor = Color.White;
                            gridDetalle.Rows[rowTarea].Cells[j].ToolTipText = "No se permiten horas superior a " + Convert.ToString(HoraMaxima) + " Hrs.";
                        }
                        else
                        {
                            gridDetalle.Rows[rowTarea].Cells[j].Style.BackColor = Color.White;
                            gridDetalle.Rows[rowTarea].Cells[j].Style.ForeColor = Color.Black;
                        }


                        Acumulado = Acumulado + Convert.ToDecimal(valor);



                        if (Acumulado > HoraMaxima)
                        {
                            gridDetalle.Rows[rowTarea].Cells["Total"].Style.BackColor = Color.Red;
                            gridDetalle.Rows[rowTarea].Cells["Total"].Style.ForeColor = Color.White;
                            gridDetalle.Rows[rowTarea].Cells["Total"].Value = Acumulado;
                            gridDetalle.Rows[rowTarea].Cells["Total"].ToolTipText = "No se permiten horas superior a " + Convert.ToString(HoraMaxima) + " Hrs.";
                        }
                        else
                        {
                            gridDetalle.Rows[rowTarea].Cells["Total"].Value = Acumulado;
                            gridDetalle.Rows[rowTarea].Cells["Total"].Style.BackColor = Color.FromArgb(218, 247, 166);
                            gridDetalle.Rows[rowTarea].Cells["Total"].Style.ForeColor = Color.Black;

                        }
                    }
                }
                catch (Exception ex)
                {

                }

            }
        }
        protected void txt_BonoHras_TextChanged(object sender, EventArgs e)
        {

            colTarea = gridDetalle.CurrentCell.ColumnIndex;
            string valor;

            var box = (TextBox)sender;


            if (gridDetalle.Columns[colTarea].Name.Substring(0, 1) == "H")
            {
                rowTarea = gridDetalle.CurrentCell.RowIndex;
                DataGridViewRow Rows = gridDetalle.Rows[rowTarea];
                valor = box.Text;
                if (valor != string.Empty)
                {
                    if (Convert.ToDecimal(valor) > BonoMaxima)
                    {
                        gridDetalle.Rows[rowTarea].Cells[colTarea].Style.BackColor = Color.Red;
                        gridDetalle.Rows[rowTarea].Cells[colTarea].Style.ForeColor = Color.White;
                        gridDetalle.Rows[rowTarea].Cells[colTarea].ToolTipText = "No se permiten horas superior a " + Convert.ToString(BonoMaxima) + " Hrs.";
                    }
                    else
                    {
                        gridDetalle.Rows[rowTarea].Cells[colTarea].Style.BackColor = Color.White;
                        gridDetalle.Rows[rowTarea].Cells[colTarea].Style.ForeColor = Color.Black;
                    }

                }
            }

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

        private void gridDetalle_KeyDown(object sender, KeyEventArgs e)
        {
            if (lblEstado.Text == "1")
            {
                if ((e.Control && e.KeyCode == Keys.Delete) )//|| (e.Shift && e.KeyCode == Keys.Delete) || e.KeyCode == Keys.Delete)
                {
                    int iRow = gridDetalle.CurrentCell.RowIndex;
                    DataGridViewRow Rows = gridDetalle.Rows[iRow];

                    string Persona = ((Rows.Cells["Apellidos"].Value == null) ? "" : Rows.Cells["Apellidos"].Value.ToString());
                    DialogResult respuesta = MessageBox.Show("¿Desea eliminar registros del " + Environment.NewLine +
                        "Sr. " + Persona + " ?", "Mensaje SSK", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (respuesta == DialogResult.Yes)
                    {

                        string ID_PERSONAL = ((Rows.Cells["IDE_PERSONAL"].Value == null) ? "0" : Rows.Cells["IDE_PERSONAL"].Value.ToString());

                        BL_TAREO obj = new BL_TAREO();
                        DataTable dtResulTareo = new DataTable();

                        dtResulTareo = obj.SP_ELIMINAR_TAREO_PERSONA(Convert.ToInt32(frmControlTareoDigitacion.obj_Tareo_E.IDE_EMPRESA), frmControlTareoDigitacion.obj_Tareo_E.IDE_CECOS, frmControlTareoDigitacion.obj_Tareo_E.FEC_TAREO, ID_PERSONAL, cboCapataz.SelectedValue.ToString());
                        if (dtResulTareo.Rows.Count > 0)
                        {
                            //e.SuppressKeyPress = (e.KeyData = Keys.Delete);
                            listarCuadrilla();
                            varfNuevo++;
                            MessageBox.Show("Registro eliminado", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            MessageBox.Show("No se puede realizar esta operación", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
                else if (e.KeyCode == Keys.Delete)
                {
                    int iRow = gridDetalle.CurrentCell.RowIndex;
                    int icol = gridDetalle.CurrentCell.ColumnIndex;
                    DataGridViewRow Rows = gridDetalle.Rows[iRow];
                   
                    if (icol > 3)
                    {
                        Rows.Cells[icol].Value = string.Empty;
                    }
                }
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyClipboard();
        }
        private void CopyClipboard()
        {
            DataObject d = gridDetalle.GetClipboardContent();
            Clipboard.SetDataObject(d);
        }

        private void pasteCtrlVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PasteClipboard();
        }
        private void PasteClipboard()
        {
            try
            {
                string s = Clipboard.GetText();
                string[] lines = s.Split('\n');
                int iFail = 0, iRow = gridDetalle.CurrentCell.RowIndex;
                int iCol = gridDetalle.CurrentCell.ColumnIndex;
                DataGridViewCell oCell;
                foreach (string line in lines)
                {
                    if (iRow < gridDetalle.RowCount && line.Length > 0)
                    {
                        string[] sCells = line.Split('\t');
                        for (int i = 0; i < sCells.GetLength(0); ++i)
                        {
                            if (iCol + i < this.gridDetalle.ColumnCount)
                            {
                                oCell = gridDetalle[iCol + i, iRow];
                                if (!oCell.ReadOnly)
                                {
                                    string valor = (oCell.Value == null) ? "0" : oCell.Value.ToString();
                                    if (valor == string.Empty)
                                    {
                                        valor = "0";
                                    }
                                    if (valor != sCells[i])
                                    {
                                        oCell.Value = Convert.ChangeType(sCells[i], oCell.ValueType);
                                        //oCell.Style.BackColor = Color.Tomato;
                                    }
                                    else
                                        iFail++;//only traps a fail if the data has changed and you are pasting into a read only cell
                                }
                            }
                            else
                            { break; }
                        }
                        iRow++;
                    }
                    else
                    { break; }
                    //if (iFail > 0)
                    //    MessageBox.Show(string.Format("{0} updates failed due to read only column setting", iFail));
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("The data you pasted is in the wrong format for the cell");
                return;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            varfNuevo++;
            int faltaEstado = 0;
            string ls_error = "";
            
            UserCode.Conexion cn = new UserCode.Conexion();

            bool lb_conectado = cn.ProbarConexion(ref ls_error);

            if (lb_conectado == true)
            {

                for (int p = 0; p < gridDetalle.Rows.Count - 1; p++)
                {
                    try
                    {
                        //string x = AsistenciaPersona;
                        //if ((gridDetalle.Rows[p].Cells["Asistencia"].Value.ToString() == "X") && (gridDetalle.Rows[p].Cells["Total"].Value.ToString() == "0") && AsistenciaPersona == "")
                        //{
                        //    SinHoras++;
                        //}

                        string estadoDiario = (gridDetalle.Rows[p].Cells["Asistencia"].Value == null) ? "" : gridDetalle.Rows[p].Cells["Asistencia"].Value.ToString();
                        if (estadoDiario == "")
                        {
                            faltaEstado++;
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

                DialogResult respuesta = MessageBox.Show("¿Desea grabar Tareo, de la cuadrilla correspondiente :" + Environment.NewLine +


                        "Ing. " + cboIngeniero.Text + Environment.NewLine +
                        "Res. " + cboCapataz.Text +
                        "? ", "REGISTRAR TAREO SSK", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (respuesta == DialogResult.Yes)
                {

                    int CantError = 0;
                    ////////////////////
                    foreach (DataGridViewRow xRows in gridDetalle.Rows)
                    {
                        //grabar tareas
                        try
                        {
                            DataGridViewRow rowx = gridDetalle.Rows[xRows.Index];
                            for (int j = 0; j <= gridDetalle.ColumnCount - 1; j++)
                            {

                                string color = gridDetalle.Rows[rowx.Index].Cells[j].Style.BackColor.ToString();
                                if (color == "Color [Red]")
                                {
                                    CantError++;
                                }
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }

                    //if (SinHoras > 0)
                    //{
                    //    MessageBox.Show("Existen " + SinHoras.ToString() + " obrero(s) sin horas de trabajo, favor de verificar", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //}
                    //else
                    //{
                    if (CantError == 0)
                    {
                        //////////////////
                        string valor, persona, asistencia, Work_Group;
                        int registros = 0;

                        for (int p = 0; p < gridDetalle.Rows.Count - 1; p++)
                        {
                            DataGridViewRow rowx = gridDetalle.Rows[p];

                            if (Convert.ToBoolean(rowx.Cells["Seleccion"].Value) == true)
                            {
                                //grabar tareas

                                persona = string.IsNullOrEmpty(rowx.Cells["IDE_PERSONAL"].Value.ToString()) ? "0" : rowx.Cells["IDE_PERSONAL"].Value.ToString();// persona
                                asistencia = (rowx.Cells["Asistencia"].Value == null) ? "FALTA" : rowx.Cells["Asistencia"].Value.ToString();
                                Work_Group = (rowx.Cells["Work_Group"].Value == null) ? String.Empty  : rowx.Cells["Work_Group"].Value.ToString();
                                //TAREAS

                                BL_ASIGNACION_TAREAS objTareas = new BL_ASIGNACION_TAREAS();
                                //dtTareas = objTareas.SEL_ASIGNACION_TAREAS_POR_FECHA_DISCIPLINA(frmControlTareoDigitacion.obj_Tareo_E.IDE_EMPRESA, frmControlTareoDigitacion.obj_Tareo_E.IDE_CECOS, null, frmControlTareoDigitacion.obj_Tareo_E.FEC_TAREO, cboCapataz.SelectedValue.ToString ()  , cboIngeniero.SelectedValue.ToString(), frmControlTareoDigitacion.obj_Tareo_E.IDE_DISCIPLINA);

                                int cantidadTareas = dtTareas.Rows.Count;

                                if (dtTareas.Rows.Count > 0)
                                {
                                    for (int i = 0; i < dtTareas.Rows.Count; i++)
                                    {

                                        string codTarea = dtTareas.Rows[i]["IDE_TAREA"].ToString();//codigo


                                        try
                                        {
                                            //CCS
                                            if (rowx.Cells[ColumnasFijas + i].Value == null)
                                            {
                                                valor = "0";
                                            }
                                            else if (rowx.Cells[ColumnasFijas + i].Value.ToString() == string.Empty)
                                            {
                                                valor = "0";
                                            }
                                            else
                                            {
                                                valor = rowx.Cells[ColumnasFijas + i].Value.ToString();
                                            }


                                            if (Convert.ToDecimal(valor) >= 0)
                                            {


                                                BE_TAREO Obj = new BE_TAREO();
                                                Obj.IDE_TRABAJO = Convert.ToInt32(0);
                                                Obj.IDE_TAREA = Convert.ToInt32(codTarea);
                                                Obj.DES_DNI = persona;
                                                Obj.HORA_EMPLEADA = Convert.ToDecimal(valor);
                                                Obj.IDE_INGCAMPO = cboIngeniero.SelectedValue.ToString();
                                                Obj.IDE_CAPATAZ = cboCapataz.SelectedValue.ToString();
                                                Obj.FLG_ESTADO = true;
                                                Obj.USUARIO_REGISTRA = frmLogin.obj_user_E.IDE_USUARIO;
                                                Obj.FECHA = frmControlTareoDigitacion.obj_Tareo_E.FEC_TAREO;
                                                Obj.TIPO = 1;
                                                Obj.IDE_EMPRESA = Convert.ToInt32(frmControlTareoDigitacion.obj_Tareo_E.IDE_EMPRESA);
                                                Obj.CCENTRO = frmControlTareoDigitacion.obj_Tareo_E.IDE_CECOS;
                                                Obj.IDE_BONIFICACION = 0;
                                                Obj.DES_ASISTENCIA = asistencia;
                                                int rpta;
                                                rpta = new BL_TAREO().Mant_Insert_Trabajos(Obj);
                                                if (rpta > 0)
                                                {
                                                    valor = string.Empty;
                                                    registros++;
                                                }
                                            }
                                        }
                                        catch (Exception ex)
                                        {

                                        }
                                    }
                                }
                                /////////////////// FIN DE LAS TAREAS ////////////////////


                                BL_FUNCIONES Fobj = new BL_FUNCIONES();
                                DataTable dtBonificacion = new DataTable();
                                dtBonificacion = Fobj.ListarBonificacion(frmControlTareoDigitacion.obj_Tareo_E.IDE_CECOS, Convert.ToInt32(frmControlTareoDigitacion.obj_Tareo_E.IDE_EMPRESA));

                                if (dtBonificacion.Rows.Count > 0)
                                {
                                    for (int i = 0; i < dtBonificacion.Rows.Count; i++)
                                    {

                                        try
                                        {
                                            string codBono = dtBonificacion.Rows[i]["IDE_TIPO"].ToString();//codigo

                                            if (rowx.Cells[ + cantidadTareas + i].Value == null)
                                            {
                                                valor = "0";
                                            }
                                            else if (rowx.Cells[ColumnasFijas  + 1 + cantidadTareas + i].Value.ToString() == string.Empty)
                                            {
                                                valor = "0";
                                            }
                                            else
                                            {
                                                valor = rowx.Cells[ColumnasFijas + 1  + cantidadTareas + i].Value.ToString();
                                            }

                                            BE_TAREO Obj = new BE_TAREO();
                                            Obj.IDE_TRABAJO = Convert.ToInt32(0);
                                            Obj.IDE_TAREA = 0;
                                            Obj.DES_DNI = persona;
                                            Obj.HORA_EMPLEADA = Convert.ToDecimal(valor);
                                            Obj.IDE_INGCAMPO = cboIngeniero.SelectedValue.ToString();
                                            Obj.IDE_CAPATAZ = cboCapataz.SelectedValue.ToString();

                                            Obj.FLG_ESTADO = true;
                                            Obj.USUARIO_REGISTRA = frmLogin.obj_user_E.IDE_USUARIO;
                                            Obj.FECHA = frmControlTareoDigitacion.obj_Tareo_E.FEC_TAREO;
                                            Obj.TIPO = 2;
                                            Obj.IDE_EMPRESA = Convert.ToInt32(frmControlTareoDigitacion.obj_Tareo_E.IDE_EMPRESA);
                                            Obj.CCENTRO = frmControlTareoDigitacion.obj_Tareo_E.IDE_CECOS;
                                            Obj.IDE_BONIFICACION = Convert.ToInt32(codBono);
                                            Obj.DES_ASISTENCIA = asistencia;
                                            int rpta;
                                            rpta = new BL_TAREO().Mant_Insert_Trabajos(Obj);
                                            if (rpta > 0)
                                            {
                                                registros++;
                                            }
                                        }
                                        catch (Exception ex)
                                        {

                                        }
                                    }
                                }

                                //////// FIN DE LOS BONOS ////////////////7

                                // REGISTRO DE ASITENCIAS
                                BE_ASISTENCIA_PERSONAL ObjAsistencia = new BE_ASISTENCIA_PERSONAL();
                                ObjAsistencia.IDE_ASISTENCIA = 0;
                                ObjAsistencia.IDE_PERSONAL = persona;
                                ObjAsistencia.FEC_ASISTENCIA = frmControlTareoDigitacion.obj_Tareo_E.FEC_TAREO;
                                ObjAsistencia.CCENTRO = frmControlTareoDigitacion.obj_Tareo_E.IDE_CECOS;
                                ObjAsistencia.IDE_EMPRESA = Convert.ToInt32(frmControlTareoDigitacion.obj_Tareo_E.IDE_EMPRESA);
                                ObjAsistencia.USUARIO_REGISTRA = frmLogin.obj_user_E.IDE_USUARIO;
                                ObjAsistencia.IDE_ESTADO = asistencia;
                                ObjAsistencia.SUPERVISOR = cboCapataz.SelectedValue.ToString();
                                ObjAsistencia.Work_Group = Work_Group;
                                int rptAsistencia;
                                rptAsistencia = new BL_ASISTENCIA_PERSONAL().Mant_Insert_Asistencias(ObjAsistencia);
                            }
                        }
                        //// FIN FOR
                        if (registros > 0)
                        {
                            MessageBox.Show("Registro Satisfactorio", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        listarCuadrilla();
                    }
                    else
                    {
                        MessageBox.Show("Existen inconsistencia en el tareo, favor de verificar", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    //}//
                }
            }
            else
            {

                MessageBox.Show(ls_error);

            }

        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            
            if (keyData == Keys.F2)
            {
                btnGuardar.PerformClick();
            }
            if (keyData == Keys.Enter)
            {
                listarCuadrilla();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        
    }
}
