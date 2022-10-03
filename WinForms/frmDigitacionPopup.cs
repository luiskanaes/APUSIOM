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

namespace WinForms
{
    public partial class frmDigitacionPopup : Form
    {
        AutoCompleteStringCollection DataFrente = new AutoCompleteStringCollection();
        AutoCompleteStringCollection DataActividades = new AutoCompleteStringCollection();
        AutoCompleteStringCollection DataTarea = new AutoCompleteStringCollection();
        AutoCompleteStringCollection DataAreas = new AutoCompleteStringCollection();
        AutoCompleteStringCollection DataEstadiDiario = new AutoCompleteStringCollection();
        bool bKeyPressNum_GV_DATA = false;
        int row;
        int col;
        int colTarea;
        int rowTarea;
        public int varfNuevo;
        public double  varTotal;
        string  ESTADO_TAREO;
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

        public frmDigitacionPopup()
        {
            InitializeComponent();
            ESTADO_TAREO = frmDigitacionTareo.obj_Tareas_E.ESTADO;
            ActividadesProyectos();
            DetalleTrabajos();

            lblNombre.Text = frmDigitacionTareo.obj_Tareas_E.NOMBRE_TRABAJOR ;

          
        }

        private void frmDigitacionPopup_Load(object sender, EventArgs e)
        {

            //BL_ASIGNACION_TAREO obj = new BL_ASIGNACION_TAREO();
            //DataTable dtResultado = new DataTable();


            //dtResultado = obj.Listar_TareoFecha(Convert.ToInt32(frmControlTareo.obj_Tareo_E.IDE_EMPRESA),
            //    frmControlTareo.obj_Tareo_E.IDE_CECOS,
            //    frmControlTareo.obj_Tareo_E.FEC_TAREO);
        }
        public void ActividadesProyectos()
        {
            BE_CABECERA objCab = new BE_CABECERA();
            BL_FUNCIONES obj = new BL_FUNCIONES();
            DataTable dt = new DataTable();
            DataActividades.Clear();
            dsActividad.Clear();
            LstActividades.Clear();

            objCab.TIPO = Convert.ToInt32(1);
            objCab.ID_PROYECTO = string.IsNullOrEmpty(frmDigitacionTareo.obj_Tareas_E.CENTRO_COSTO) ? "0" : frmDigitacionTareo.obj_Tareas_E.CENTRO_COSTO;
            objCab.IDE_ACTIVIDAD = "1";
            objCab.ID_TAREA = "1";
            objCab.IDE_EMPRESA = Convert.ToInt32(frmDigitacionTareo.obj_Tareas_E.IDE_EMPRESA);
            objCab.TIPO_ARCHIVO = frmDigitacionTareo.obj_Tareas_E.FILE;
            //dt = obj.Listar_ActividadTarea(1, frmDigitacionTareo.obj_Tareas_E.CENTRO_COSTO, "1", "1", Convert.ToInt32(frmDigitacionTareo.obj_Tareas_E.IDE_EMPRESA), Convert.ToInt32(frmDigitacionTareo.obj_Tareas_E.FILE));
            dt = obj.USP_OBTENER_TODAS_TAREAS_PROYECTO(1, frmDigitacionTareo.obj_Tareas_E.CENTRO_COSTO, "1", "1", Convert.ToInt32(frmDigitacionTareo.obj_Tareas_E.IDE_EMPRESA), Convert.ToInt32(frmDigitacionTareo.obj_Tareas_E.FILE));

            if (dt.Rows.Count > 0)
            {
                //dsActividad = obj.Listar_ActividadTarea(1, frmDigitacionTareo.obj_Tareas_E.CENTRO_COSTO, "1", "1", Convert.ToInt32(frmDigitacionTareo.obj_Tareas_E.IDE_EMPRESA), Convert.ToInt32(frmDigitacionTareo.obj_Tareas_E.FILE));
                //LstActividades = new BL_CONTROL_AVANCE().f_list_TareProyecto(objCab);


                dsActividad = dt;
                LstActividades = UserCode.Conversion_DataTable_Lista.ucTablaLista<BE_CABECERA>.TablaALista(dt);


                //if (DataActividades.Count <= 0)
                //{
                foreach (DataRow row in dt.Rows)
                {

                    DataActividades.Add(Convert.ToString(row["DESCRIPCION"]));
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
        protected void DetalleTrabajos()
        {
            gridDetalle.Rows.Clear();
            gridDetalle.Refresh();
            gridDetalle.DataSource = null;
            gridDetalle.Columns.Clear();
            gridDetalle.AllowUserToAddRows = true;
            gridDetalle.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;





            //gridDetalle.ColumnCount = 5;
            DataGridViewTextBoxColumn colItem = new DataGridViewTextBoxColumn();
            colItem.Name = "Item";
            colItem.HeaderText = "Item";
            colItem.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colItem.Width = 30;
            gridDetalle.Columns.Insert(0, colItem);

            DataGridViewTextBoxColumn colIDE_PERSONAL = new DataGridViewTextBoxColumn();
            colIDE_PERSONAL.Name = "IDE_PERSONAL";
            colIDE_PERSONAL.HeaderText = "IDE_PERSONAL";
            gridDetalle.Columns.Insert(1, colIDE_PERSONAL);



            DataGridViewTextBoxColumn colCtas = new DataGridViewTextBoxColumn();
            colCtas.Name = "Ctas";
            colCtas.HeaderText = "Cta Costo";
            colCtas.Width = 200;
            //colCtas.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridDetalle.Columns.Insert(2, colCtas);

            DataGridViewTextBoxColumn colHH = new DataGridViewTextBoxColumn();
            colHH.Name = "HH";
            colHH.HeaderText = "HH";
            colHH.Width = 60;
            colHH.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridDetalle.Columns.Insert(3, colHH);

            DataGridViewTextBoxColumn colIDE_TRABAJO = new DataGridViewTextBoxColumn();
            colIDE_TRABAJO.Name = "IDE_TRABAJO";
            colIDE_TRABAJO.HeaderText = "IDE_TRABAJO";
            colIDE_TRABAJO.Width = 60;
            colIDE_TRABAJO.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridDetalle.Columns.Insert(4, colIDE_TRABAJO);

            //tamaños
            gridDetalle.Columns[0].Width = 30;

            //celda bloqueados
            gridDetalle.Columns["Item"].ReadOnly = true;
            gridDetalle.Columns["IDE_PERSONAL"].Visible = false;
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


           
            if (frmDigitacionTareo.obj_Tareas_E.ASISTENCIA =="X" || frmDigitacionTareo.obj_Tareas_E.ASISTENCIA == "F")
            {

                if (ESTADO_TAREO == "1")
                {
                    gridDetalle.Columns["btn"].Visible = true;
                    btnGuardar.Visible = true;
                }
                else
                {
                    gridDetalle.Columns["btn"].Visible = false;
                    btnGuardar.Visible = false;
                }

                //gridDetalle.Columns["btn"].Visible = true;
                //btnGuardar.Visible = true;
            }
            else
            {
                gridDetalle.Columns["btn"].Visible = false;
                btnGuardar.Visible = false;
            }

            



            gridDetalle.Columns["Item"].Visible = false;
            gridDetalle.Columns["IDE_TRABAJO"].Visible = false;

            dtResul = obj.SP_OBTENER_PERSONAL_TAREADO_ID_WS(frmDigitacionTareo.obj_Tareas_E.CENTRO_COSTO, frmDigitacionTareo.obj_Tareas_E.FECHA_TAREO, frmDigitacionTareo.obj_Tareas_E.IDE_PERSONAL);




            if (dtResul.Rows.Count > 0)
            {
               

                //datos vacios
                for (int i = 0; i < dtResul.Rows.Count; i++)
                {
                    int renglon = gridDetalle.Rows.Add();

                    gridDetalle.Rows[renglon].Cells["Item"].Value = Convert.ToString(i + 1);
                    gridDetalle.Rows[renglon].Cells["IDE_PERSONAL"].Value = dtResul.Rows[i]["IDE_PERSONAL"].ToString();

                    //gridDetalle.Rows[renglon].Cells["Ctas"].Value = dtResul.Rows[i]["IDE_ACTIVIDAD"].ToString();
                    gridDetalle.Rows[renglon].Cells["Ctas"].Value = dtResul.Rows[i]["DESCRIPCION"].ToString();

                    gridDetalle.Rows[renglon].Cells["HH"].Value = dtResul.Rows[i]["HORA_EMPLEADA"].ToString();
                    gridDetalle.Rows[renglon].Cells["IDE_TRABAJO"].Value = dtResul.Rows[i]["IDE_TRABAJO"].ToString();

                }
            }



            gridDetalle.AutoGenerateColumns = false;
        }

        private void gridDetalle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            string persona;


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
                        persona = (rowx.Cells[1].Value == null) ? string.Empty : rowx.Cells[1].Value.ToString();// persona
                       string IDE_TRABAJO = (rowx.Cells["IDE_TRABAJO"].Value == null) ? string.Empty : rowx.Cells["IDE_TRABAJO"].Value.ToString();
                        if (persona != string.Empty)
                        {

                            BL_TAREO ObjDel = new BL_TAREO();

                            ObjDel.uspDEL_TAREO_PERSONA_ID(Convert.ToInt32(IDE_TRABAJO));
                            varfNuevo++;
                            DetalleTrabajos();
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
            rowTarea = gridDetalle.CurrentCell.RowIndex;
            TextBox txt_GV_DATA = e.Control as TextBox;
            TextBox txt_GV_CTA = e.Control as TextBox;

            if (colTarea == 2) //CTAS COSTO
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
            else if (gridDetalle.Columns[colTarea].Name.Substring(0, 1) == "H")
            {
                txt_GV_CTA.AutoCompleteCustomSource = null;
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
        private void txt_Numero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back || (e.KeyChar == (char)'.') && !(sender as TextBox).Text.Contains("."))
            {
                return;
            }
            decimal isNumber = 0;
            e.Handled = !decimal.TryParse(e.KeyChar.ToString(), out isNumber);
        }
        protected void txt_GV_CTAS_TextChanged(object sender, EventArgs e)
        {
            //gridDetalle.AllowUserToAddRows = false;
            string valor;
            colTarea = gridDetalle.CurrentCell.ColumnIndex;
            var box = (TextBox)sender;

            rowTarea = gridDetalle.CurrentCell.RowIndex;
            if (colTarea == 2)
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
                    gridDetalle.Rows[rowTarea].Cells[colTarea].ToolTipText = "Error, No existe cuenta de costo";
                    gridDetalle.Rows[rowTarea].Cells[colTarea].Style.BackColor = Color.Red;
                    gridDetalle.Rows[rowTarea].Cells[colTarea].Value = string.Empty;



                }

            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GrabarDigitacion();

            double  sumatoria = 0;

            foreach (DataGridViewRow row in gridDetalle.Rows)
            {
                //Aquí seleccionaremos la columna que contiene los datos numericos. 
                if (row.Cells["HH"].Value == null)
                {
                    sumatoria += Convert.ToDouble((row.Cells["HH"].Value == null) ? "0" : row.Cells["HH"].Value.ToString());
                }
                else if (row.Cells["HH"].Value.ToString() == "")
                {
                    sumatoria += Convert.ToDouble((row.Cells["HH"].Value.ToString() == "" ? "0" : row.Cells["HH"].Value.ToString()));
                }
                else
                {
                    sumatoria += Convert.ToDouble(row.Cells["HH"].Value.ToString());
                }

                //(rx.Cells["Asistencia"].Value == null) ? "" : rx.Cells["Asistencia"].Value.ToString()
            }
            varTotal = sumatoria;
        }
        protected void GrabarDigitacion()
        {
            int CantError = 0;
            string ls_error = "";
            int registros = 0;
            UserCode.Conexion cn = new UserCode.Conexion();

            bool lb_conectado = cn.ProbarConexion(ref ls_error);

            if (lb_conectado == true)
            {

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

                if (CantError > 0)
                {
                    MessageBox.Show("Existen incosistencia en la digitación", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    for (int p = 0; p < gridDetalle.Rows.Count - 1; p++)
                    {
                        DataGridViewRow rowx = gridDetalle.Rows[p];
                        string persona = frmDigitacionTareo.obj_Tareas_E.IDE_PERSONAL;
                        string HH = (rowx.Cells["HH"].Value == null) ? string.Empty : rowx.Cells["HH"].Value.ToString();
                        string cta = (rowx.Cells["Ctas"].Value == null) ? string.Empty : rowx.Cells["Ctas"].Value.ToString();
                        BL_ASIGNACION_TAREO objT = new BL_ASIGNACION_TAREO();
                        DataTable dtResultado = new DataTable();

                        string colorCta = (rowx.Cells["Ctas"].Style.BackColor.ToString() == null) ? string.Empty : rowx.Cells["Ctas"].Style.BackColor.ToString();
                        string colorHH = (rowx.Cells["HH"].Style.BackColor.ToString() == null) ? string.Empty : rowx.Cells["HH"].Style.BackColor.ToString();

                        if (colorCta != "Color [Red]" && colorHH != "Color [Red]")
                        {
                            if (cta != string.Empty)
                            {
                                //dtResultado = objT.uspINS_ASIGNACION_TAREAS_WS(
                                //frmDigitacionTareo.obj_Tareas_E.CENTRO_COSTO,
                                //frmDigitacionTareo.obj_Tareas_E.FECHA_TAREO,
                                //frmDigitacionTareo.obj_Tareas_E.IDE_INGCAMPO,
                                //frmDigitacionTareo.obj_Tareas_E.IDE_CAPATAZ,
                                //cta,
                                //frmLogin.obj_user_E.IDE_USUARIO
                                //);

                                dtResultado = objT.uspINS_ASIGNACION_TAREAS_DIRECTO(
                                frmDigitacionTareo.obj_Tareas_E.CENTRO_COSTO,
                                frmDigitacionTareo.obj_Tareas_E.FECHA_TAREO,
                                string.Empty,
                                string.Empty,
                                cta,
                                frmLogin.obj_user_E.IDE_USUARIO,
                                frmDigitacionTareo.obj_Tareas_E.FILE,
                                frmDigitacionTareo.obj_Tareas_E.IDE_TAREO_ASIGNACION.ToString()
                                );



                                if (dtResultado.Rows.Count > 0)
                                {
                                    string IDE_TAREA = dtResultado.Rows[0]["IDE_TAREA"].ToString();

                                    if (HH != string.Empty )
                                    {
                                        BE_TAREO Obj = new BE_TAREO();
                                        Obj.IDE_TRABAJO = Convert.ToInt32(0);
                                        Obj.IDE_TAREA = Convert.ToInt32(IDE_TAREA);
                                        Obj.DES_DNI = persona;
                                        Obj.HORA_EMPLEADA = Convert.ToDecimal(HH);
                                        Obj.IDE_INGCAMPO = frmDigitacionTareo.obj_Tareas_E.IDE_INGCAMPO;
                                        Obj.IDE_CAPATAZ = frmDigitacionTareo.obj_Tareas_E.IDE_CAPATAZ;
                                        Obj.FLG_ESTADO = true;
                                        Obj.USUARIO_REGISTRA = frmLogin.obj_user_E.IDE_USUARIO;
                                        Obj.FECHA = frmDigitacionTareo.obj_Tareas_E.FECHA_TAREO;
                                        Obj.TIPO = 1;
                                        Obj.IDE_EMPRESA = Convert.ToInt32(frmDigitacionTareo.obj_Tareas_E.IDE_EMPRESA);
                                        Obj.CCENTRO = frmDigitacionTareo.obj_Tareas_E.CENTRO_COSTO;
                                        Obj.IDE_BONIFICACION = 0;
                                        Obj.DES_ASISTENCIA = "X";
                                        int rpta;
                                        rpta = new BL_TAREO().Mant_Insert_Trabajos(Obj);
                                        if (rpta > 0)
                                        {
                                            //valor = string.Empty;
                                            registros++;
                                            varfNuevo++;
                                        }
                                    }
                                    
                                }
                            }
                        }
                    }

                    if (registros > 0)
                    {
                        MessageBox.Show("Registro exitoso", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        DetalleTrabajos();
                       
                    }
                }
            }
        }
    }
}
