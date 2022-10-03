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

    public partial class frmDisciplinaEstructura : Form
    {
        bool bKeyPressNum_GV_DATA = false;
        public frmDisciplinaEstructura()
        {
            InitializeComponent();
           
         
        }
        protected void ConsultarTareo()
        {
            string FLG_ESTADO;

            BL_ASIGNACION_TAREO obj = new BL_ASIGNACION_TAREO();
            DataTable dtResultado = new DataTable();

            dtResultado = obj.Listar_TareoFecha(frmControlTareo.obj_Tareas_E.IDE_EMPRESA , frmControlTareo.obj_Tareas_E.CENTRO_COSTO, frmControlTareo.obj_Tareas_E.FECHA_TAREO);
            if (dtResultado.Rows.Count > 0)
            {

                 FLG_ESTADO = dtResultado.Rows[0]["FLG_ESTADO"].ToString();
                string FLG_MIGRADO = dtResultado.Rows[0]["FLG_MIGRADO"].ToString();
            }
            else
            {
                 FLG_ESTADO = "1";
            }

            if(FLG_ESTADO == "1")
            {
                btnGuardar.Visible = true;
                dataGridView1.Columns["btnAgregar"].Visible = true;
            }
            else
            {
                btnGuardar.Visible = false ;
                dataGridView1.Columns["btnAgregar"].Visible = false;
            }


        }
        private void frmDisciplinaEstructura_Load(object sender, EventArgs e)
        {
            TipoAngulos();
        }
        protected void Estructura()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();

            dataGridView1.AllowUserToAddRows = true;

            dataGridView1.ColumnCount = 1;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            dataGridView1.Columns[0].Name = "Item";
            dataGridView1.Columns[0].Width = 30;
            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGridViewTextBoxColumn colDSC_UNIDAD = new DataGridViewTextBoxColumn();
            colDSC_UNIDAD.Name = "DSC_UNIDAD";
            colDSC_UNIDAD.HeaderText = "Unidad";
            colDSC_UNIDAD.Width = 80;
            colDSC_UNIDAD.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Insert(1, colDSC_UNIDAD);


            DataGridViewTextBoxColumn colDSC_ESTRUCTURA = new DataGridViewTextBoxColumn();
            colDSC_ESTRUCTURA.Name = "DSC_ESTRUCTURA";
            colDSC_ESTRUCTURA.HeaderText = "Estructura";
            colDSC_ESTRUCTURA.Width = 80;
            colDSC_ESTRUCTURA.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Insert(2, colDSC_ESTRUCTURA);

            DataGridViewTextBoxColumn colDSC_AREA = new DataGridViewTextBoxColumn();
            colDSC_AREA.Name = "DSC_AREA";
            colDSC_AREA.HeaderText = "Area";
            colDSC_AREA.Width = 50;
            colDSC_AREA.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Insert(3, colDSC_AREA);

            DataGridViewTextBoxColumn colDSC_MARCA = new DataGridViewTextBoxColumn();
            colDSC_MARCA.Name = "DSC_MARCA";
            colDSC_MARCA.HeaderText = "Marca";
            colDSC_MARCA.Width = 120;
            dataGridView1.Columns.Insert(4, colDSC_MARCA);

            DataGridViewTextBoxColumn colDSC_DESCRIPCION = new DataGridViewTextBoxColumn();
            colDSC_DESCRIPCION.Name = "DSC_DESCRIPCION";
            colDSC_DESCRIPCION.HeaderText = "Descripcion";
            colDSC_DESCRIPCION.Width = 80;
            colDSC_DESCRIPCION.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Insert(5, colDSC_DESCRIPCION);

            DataGridViewTextBoxColumn colNUM_CANTIDAD = new DataGridViewTextBoxColumn();
            colNUM_CANTIDAD.Name = "NUM_CANTIDAD";
            colNUM_CANTIDAD.HeaderText = "Total Global";
            colNUM_CANTIDAD.Width = 50;
            colNUM_CANTIDAD.ReadOnly = true;
            colNUM_CANTIDAD.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Insert(6, colNUM_CANTIDAD);

            DataGridViewTextBoxColumn colAcumulado = new DataGridViewTextBoxColumn();
            colAcumulado.Name = "ACUMULADO_AYER";
            colAcumulado.HeaderText = "Acumulado Ayer";
            colAcumulado.Width = 60;
            colAcumulado.ReadOnly = true;
            colAcumulado.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Insert(7, colAcumulado);


            DataGridViewTextBoxColumn colEJECUTADO = new DataGridViewTextBoxColumn();
            colEJECUTADO.Name = "EJECUTADO_HOY";
            colEJECUTADO.HeaderText = "Ejecutado del día";
            colEJECUTADO.Width = 60;
            colEJECUTADO.ReadOnly = true;
            colEJECUTADO.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Insert(8, colEJECUTADO);

           

            DataGridViewTextBoxColumn colCantSalida = new DataGridViewTextBoxColumn();
            colCantSalida.Name = "CantidadSalida";
            colCantSalida.HeaderText = "Ingresar";
            colCantSalida.Width = 60;
            colCantSalida.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Insert(9, colCantSalida);

            DataGridViewButtonColumn btnAgregar = new DataGridViewButtonColumn();
            btnAgregar.HeaderText = "";
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Text = "Agregar";
            btnAgregar.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Insert(10, btnAgregar);

            DataGridViewTextBoxColumn colID_ESTRUCTURA = new DataGridViewTextBoxColumn();
            colID_ESTRUCTURA.Name = "ID_ESTRUCTURA";
            colID_ESTRUCTURA.HeaderText = "ID_ESTRUCTURA";
            colID_ESTRUCTURA.Width = 120;
            dataGridView1.Columns.Insert(11, colID_ESTRUCTURA);

            dataGridView1.Columns["ID_ESTRUCTURA"].Visible = false ;
            
            dataGridView1.Columns["CantidadSalida"].DefaultCellStyle.BackColor = Color.FromArgb(255, 248, 110);

            BL_TAREO xobj = new BL_TAREO();
            DataTable dtResultado = new DataTable();
            
            dtResultado = xobj.LISTA_ESTRUCTURAS_CONSUMO(
                frmControlTareo.obj_Tareas_E.CENTRO_COSTO,
                Convert.ToInt32(cboReglas.SelectedValue.ToString()),
                frmControlTareo.obj_Tareas_E.FECHA_TAREO,
                frmControlTareo.obj_Tareas_E.IDE_TAREA,
                frmControlTareo.obj_Tareas_E.ID_FRENTE
                );

              
            if (dtResultado.Rows.Count > 0)
            {
                for (int i = 0; i < dtResultado.Rows.Count; i++)
                {
                    int renglon = dataGridView1.Rows.Add();
                    dataGridView1.Rows[renglon].Cells["Item"].Value = dtResultado.Rows[i]["Row"].ToString();// Convert.ToString(i + 1);
                    dataGridView1.Rows[renglon].Cells["ID_ESTRUCTURA"].Value = dtResultado.Rows[i]["ID_ESTRUCTURA"].ToString();
                    dataGridView1.Rows[renglon].Cells["DSC_UNIDAD"].Value = dtResultado.Rows[i]["DSC_UNIDAD"].ToString();
                    dataGridView1.Rows[renglon].Cells["DSC_ESTRUCTURA"].Value = dtResultado.Rows[i]["DSC_ESTRUCTURA"].ToString();
                    dataGridView1.Rows[renglon].Cells["DSC_AREA"].Value = dtResultado.Rows[i]["DSC_AREA"].ToString();
                    dataGridView1.Rows[renglon].Cells["DSC_MARCA"].Value = dtResultado.Rows[i]["DSC_MARCA"].ToString();
                    dataGridView1.Rows[renglon].Cells["DSC_DESCRIPCION"].Value = dtResultado.Rows[i]["DSC_DESCRIPCION"].ToString();
                    dataGridView1.Rows[renglon].Cells["NUM_CANTIDAD"].Value = dtResultado.Rows[i]["NUM_CANTIDAD"].ToString();
                   
                   
                    dataGridView1.Rows[renglon].Cells["EJECUTADO_HOY"].Value = dtResultado.Rows[i]["EJECUTADO_HOY"].ToString();
                    dataGridView1.Rows[renglon].Cells["ACUMULADO_AYER"].Value = dtResultado.Rows[i]["ACUMULADO_AYER"].ToString();
                    //dataGridView1.Rows[renglon].Cells["IMP_ESPESOR"].Value = dtResultado.Rows[i]["IMP_ESPESOR"].ToString();
                    //dataGridView1.Rows[renglon].Cells["DSC_MATERIAL"].Value = dtResultado.Rows[i]["DSC_MATERIAL"].ToString();
                    //dataGridView1.Rows[renglon].Cells["IMP_PEP"].Value = dtResultado.Rows[i]["IMP_PEP"].ToString();
                    //dataGridView1.Rows[renglon].Cells["DSC_CLASIFICACION"].Value = dtResultado.Rows[i]["DSC_CLASIFICACION"].ToString();

                }
            }
            //foreach (DataGridViewRow row in dataGridView1.Rows)
            //{
            //    if (Convert.ToInt32(row.Cells["STOCK"].Value) == 0)// asignado a cuadrilla
            //    {
            //        row.Cells["STOCK"].Style.BackColor = Color.GreenYellow ;
            //    }

            //    else
            //    {
            //        row.Cells["STOCK"].Style.BackColor =  Color.White;
            //    }
            //}
            //dataGridView1.AllowUserToAddRows = false;
            ConsultarTareo();
        }

        private void cboReglas_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cboReglas.SelectedIndex > 0)
            //{
            //    Estructura();
            //}
            //else
            //{
            //    dataGridView1.Rows.Clear();
            //    dataGridView1.Refresh();
            //    dataGridView1.DataSource = null;
            //    dataGridView1.Columns.Clear();

            //}
            Estructura();
        }
        protected void TipoAngulos()
        {
            BL_TAREO xobj = new BL_TAREO();
            DataTable dtResultado = new DataTable();
            DataTable dt = new DataTable();
            dtResultado = xobj.uspSEL_M_TAREA_ESTRUCTURA_POR_TAREA(frmControlTareo.obj_Tareas_E.IDE_TAREA  , frmControlTareo.obj_Tareas_E.CENTRO_COSTO , frmControlTareo.obj_Tareas_E.ID_FRENTE, frmControlTareo.obj_Tareas_E.DET_TAREA );

            if (dtResultado.Rows.Count > 0)
            {

                DataColumn dc = new DataColumn("Codigo", typeof(String));
                dt.Columns.Add(dc);

                dc = new DataColumn("Descripcion", typeof(String));
                dt.Columns.Add(dc);

                DataRow workRow;

                workRow = dt.NewRow();
                //workRow[0] = "0";
                //workRow[1] = "--- SELECCIONAR ---";
                //dt.Rows.Add(workRow);

                for (int i = 0; i < dtResultado.Rows.Count; i++)
                {

                    workRow = dt.NewRow();
                    workRow[0] = dtResultado.Rows[i]["IDE_DESCRIPCION"].ToString();
                    workRow[1] = dtResultado.Rows[i]["DESCRIPCION"].ToString();
                    dt.Rows.Add(workRow);
                }


                cboReglas.ValueMember = "Codigo";
                cboReglas.DisplayMember = "Descripcion";
                cboReglas.DataSource = dt;
            }
            Estructura();
        }
        void ValidarNumero(KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
                e.Handled = false;
            else if (Char.IsControl(e.KeyChar))
                e.Handled = false;
            else if (Char.IsSeparator(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;

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
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            bKeyPressNum_GV_DATA = false;
            int col = dataGridView1.CurrentCell.ColumnIndex;
            TextBox txt_GV_DATA = e.Control as TextBox;
            if (dataGridView1.Columns[col].Name == "CantidadSalida") //Cantidad
            {
                bKeyPressNum_GV_DATA = true;
                if (txt_GV_DATA != null)
                {

                    txt_GV_DATA.KeyPress += txt_Numero_KeyPress;
                    txt_GV_DATA.KeyPress += new KeyPressEventHandler(txt_GV_DATA_KeyPress);
                }

            }
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            string x;

            if (e.ColumnIndex > -1)
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "btnAgregar")
                {
                    DialogResult respuesta = MessageBox.Show("¿Desea Agregar Cantidad?", "Mensaje SSK", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (respuesta == DialogResult.Yes)
                    {
                        DataGridViewRow Rows = dataGridView1.Rows[i];
                        for (int j = e.ColumnIndex - 3; j <= e.ColumnIndex; j++)
                        {
                            try
                            {
                                string columnas = dataGridView1.Columns[j].Name;
                                if (columnas.Equals("CantidadSalida"))
                                {   
                                    int CantidadInicial = Convert.ToInt32 ((Rows.Cells["NUM_CANTIDAD"].Value == null) ? "0" : Rows.Cells["NUM_CANTIDAD"].Value.ToString());
                                    //int STOCK = Convert.ToInt32((Rows.Cells["STOCK"].Value == null) ? "0" : Rows.Cells["STOCK"].Value.ToString());
                                    int ID_ESTRUCTURA = Convert.ToInt32((Rows.Cells["ID_ESTRUCTURA"].Value == null) ? "0" : Rows.Cells["ID_ESTRUCTURA"].Value.ToString());

                                    x = (Rows.Cells["CantidadSalida"].Value == null) ? "-1" : Rows.Cells["CantidadSalida"].Value.ToString();
                                    if (Convert.ToInt32(x) >= 0)
                                    {

                                        if (Convert.ToInt32(x) <= CantidadInicial)
                                        {

                                            BE_M_ESTRUCTURA_INSUMO objE = new BE_M_ESTRUCTURA_INSUMO();
                                            objE.ID_INSUMO = 0;
                                            objE.ID_ESTRUCTURA = ID_ESTRUCTURA;
                                            objE.DESCRIPCION = "SALIDA";
                                            objE.EJECUTADO = Convert.ToInt32(x);
                                            objE.CENTRO = frmControlTareo.obj_Tareas_E.CENTRO_COSTO;
                                            objE.FECHA_TAREO = frmControlTareo.obj_Tareas_E.FECHA_TAREO;
                                            objE.IDE_TAREA = frmControlTareo.obj_Tareas_E.IDE_TAREA.ToString ();
                                            objE.USUARIO_REGISTRO = frmLogin.obj_user_E.IDE_USUARIO;
                                            int  rptaTareas;
                                          
                                            rptaTareas = new BL_TAREO().Mant_Insert_Estructura(objE);
                                            if (rptaTareas > 0)
                                            {

                                                Estructura();
                                                MessageBox.Show("Registro Satisfactorio", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }

                                            //obj.InsertarKardex(ID_ESTRUCTURA,"SALIDA",0, Convert.ToInt32(x), frmControlTareo.obj_Tareas_E.CENTRO_COSTO ,frmLogin.obj_user_E.IDE_USUARIO, frmControlTareo.obj_Tareas_E.FECHA_TAREO , frmControlTareo.obj_Tareas_E.IDE_TAREA );



                                        }
                                        else
                                        {
                                            MessageBox.Show("Cantidad ingresada presenta un exceso a lo permitido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                        }
                                     
                                       
                                    }
                                    else
                                    {
                                        MessageBox.Show("Valor no permitido", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                    }
                                }
                            }
                            catch (Exception ex)
                            {

                            }
                        }
                    }
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Desea Grabar?", "Grabar Registros", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (respuesta == DialogResult.Yes)
            {
                string  x;
                int CantidadInicial;
                int ID_ESTRUCTURA;
                int rptaTareas;
                int i=0;
                foreach (DataGridViewRow Rows in dataGridView1.Rows)
                {
                    CantidadInicial = Convert.ToInt32((Rows.Cells["NUM_CANTIDAD"].Value == null) ? "0" : Rows.Cells["NUM_CANTIDAD"].Value.ToString());
                   
                    ID_ESTRUCTURA = Convert.ToInt32((Rows.Cells["ID_ESTRUCTURA"].Value == null) ? "0" : Rows.Cells["ID_ESTRUCTURA"].Value.ToString());

                  
                    x = (Rows.Cells["CantidadSalida"].Value == null) ? "-1" : Rows.Cells["CantidadSalida"].Value.ToString();
                    if (Convert.ToInt32(x) >= 0 )
                    {
                        if (Convert.ToInt32(x) <= CantidadInicial)
                        {

                            BE_M_ESTRUCTURA_INSUMO objE = new BE_M_ESTRUCTURA_INSUMO();
                            objE.ID_INSUMO = 0;
                            objE.ID_ESTRUCTURA = ID_ESTRUCTURA;
                            objE.DESCRIPCION = "SALIDA";
                            objE.EJECUTADO = Convert.ToInt32(x);
                            objE.CENTRO = frmControlTareo.obj_Tareas_E.CENTRO_COSTO;
                            objE.FECHA_TAREO = frmControlTareo.obj_Tareas_E.FECHA_TAREO;
                            objE.IDE_TAREA = frmControlTareo.obj_Tareas_E.IDE_TAREA.ToString ();
                            objE.USUARIO_REGISTRO = frmLogin.obj_user_E.IDE_USUARIO;


                            rptaTareas = new BL_TAREO().Mant_Insert_Estructura(objE);
                            if (rptaTareas > 0)
                            {
                                i++;

                            }

                        }
                        else
                        {
                            Rows.Cells["CantidadSalida"].Style.BackColor = Color.GreenYellow;
                            MessageBox.Show("Cantidad ingresada presenta un exceso a lo permitido", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                if (i > 0)
                {
                    Estructura();
                    MessageBox.Show("Registro Satisfactorio", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
