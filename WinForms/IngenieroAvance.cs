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
    public partial class IngenieroAvance : Form
    {
        public static bool bSalir = false;
        DataTable dtResulDisponible;
        DataView dv;
        private static List<BE_ASIGNACION_TAREAS> LstTareas = new List<BE_ASIGNACION_TAREAS>();
        //List<object> LstTareas;
        public IngenieroAvance()
        {
            InitializeComponent();
        }

        private void IngenieroAvance_Load(object sender, EventArgs e)
        {
            ListarIngenieros();
           
            listarActividad();
           
        }
        protected void ListarIngenieros()
        {
            BL_ASIGNACION_TAREAS obj = new BL_ASIGNACION_TAREAS();
            DataTable dtResultado = new DataTable();

            if (frmControlTareo.obj_Tareas_E.FLG_ESTADO == 1)
            {

                dtResultado = obj.obtener_PersonalCategoria(frmControlTareo.obj_Tareas_E.CENTRO_COSTO , frmControlTareo.obj_Tareas_E.IDE_EMPRESA , "INGENIERO", null, frmControlTareo.obj_Tareas_E.FECHA_TAREO);
                if (dtResultado.Rows.Count > 0)
                {
                    cboIngeniero.ValueMember = "ID_PERSONAL";
                    cboIngeniero.DisplayMember = "NOMBRES";
                    cboIngeniero.DataSource = dtResultado;
                   
                }
            }
            else
            {

                dtResultado = obj.OBTENER_PERSONAL_RESPONSABLES_TAREO(frmControlTareo.obj_Tareas_E.CENTRO_COSTO, frmControlTareo.obj_Tareas_E.IDE_EMPRESA, frmControlTareo.obj_Tareas_E.FECHA_TAREO, 1,"");
                if (dtResultado.Rows.Count > 0)
                {
                    cboIngeniero.ValueMember = "ID_PERSONAL";
                    cboIngeniero.DisplayMember = "NOMBRES";
                    cboIngeniero.DataSource = dtResultado;
                   
                }
            }
        }
        public void TipoEstructura(string CODIGO_AREA, string DET_TAREA)
        {



            BL_ASIGNACION_TAREAS obj = new BL_ASIGNACION_TAREAS();
            DataTable dt = new DataTable();
           
            dt = obj.LISTAR_M_PARTIDA_CONTROL_MARCA_CENTRO(frmControlTareo.obj_Tareas_E.CENTRO_COSTO, CODIGO_AREA, frmControlTareo.obj_Tareas_E.IDE_DISCIPLINA, DET_TAREA);
            if (dt.Rows.Count > 0)
            {
               
                cboEstructura.ValueMember = "IDE_DES_ESTRUCTURA";
                cboEstructura.DisplayMember = "DSC_DESCRIPCION";
                cboEstructura.DataSource = dt;
              
                //ListarEstructura();
            }
            else
            {

                dt.Rows.Clear();
                cboEstructura.DataSource = dt;
                cboEstructura.ResetText();
            }

        }
        protected void listarActividad()
        {
            BL_ASIGNACION_TAREAS obj = new BL_ASIGNACION_TAREAS();
            DataTable dt = new DataTable();
            dt = obj.SEL_ASIGNACION_TAREAS_FECHA_ING(frmControlTareo.obj_Tareas_E.IDE_EMPRESA.ToString(), frmControlTareo.obj_Tareas_E.CENTRO_COSTO,  frmControlTareo.obj_Tareas_E.FECHA_TAREO,  cboIngeniero.SelectedValue.ToString());
            if (dt.Rows.Count > 0)
            {
                cboActividades.ValueMember = "CODIGO_MARCA";
                cboActividades.DisplayMember = "DESCRIPCION_TAREA";
                cboActividades.DataSource = dt;

                BE_ASIGNACION_TAREAS objCab = new BE_ASIGNACION_TAREAS();
                objCab.IDE_EMPRESA  = frmControlTareo.obj_Tareas_E.IDE_EMPRESA;
                objCab.CENTRO_COSTO = frmControlTareo.obj_Tareas_E.CENTRO_COSTO;
                objCab.FECHA_TAREO = frmControlTareo.obj_Tareas_E.FECHA_TAREO;
                objCab.IDE_INGCAMPO = cboIngeniero.SelectedValue.ToString();

                LstTareas.Clear();
                LstTareas = new BL_ASIGNACION_TAREAS().f_list_SEL_ASIGNACION_TAREAS_FECHA_ING(objCab);

                string valor = cboActividades.SelectedValue.ToString();
                if (valor != string.Empty)
                {
                    BE_ASIGNACION_TAREAS result = LstTareas.Find(
                    delegate (BE_ASIGNACION_TAREAS bk)
                    {
                        return bk.CODIGO_MARCA == valor;
                    }
                    );
                    if (result != null)
                    {


                        lblCodigoArea.Text = result.CODIGO_AREA;
                        TipoEstructura(result.CODIGO_AREA, result.DET_TAREA);
                       
                    }
                    else
                    {
                        lblCodigoArea.Text = "";
                    }
                }
                else
                {

                }
                
            }
            else
            {
                LstTareas.Clear();
                dt.Rows.Clear();
                cboActividades.DataSource = dt;
                cboActividades.ResetText();

                cboEstructura.ResetText();
                dataGridView1.Visible = false ;
            }

        }
        protected void ListarEstructura(string CODIGO_AREA)
        {
            try
            {
                EstructuraGrilla();

                BL_TAREO xobj = new BL_TAREO();
                DataTable dtResultado = new DataTable();

                dtResultado = xobj.LISTA_ESTRUCTURAS_CONSUMO_ING(
                    frmControlTareo.obj_Tareas_E.CENTRO_COSTO,
                    Convert.ToInt32(cboEstructura.SelectedValue.ToString()),
                    frmControlTareo.obj_Tareas_E.FECHA_TAREO,
                    cboActividades.SelectedValue.ToString(),
                    CODIGO_AREA,
                    cboIngeniero.SelectedValue.ToString()
                    );

                //FILTRO PRINCIPAL
                dtResulDisponible = xobj.LISTA_ESTRUCTURAS_CONSUMO_ING(
                    frmControlTareo.obj_Tareas_E.CENTRO_COSTO,
                    Convert.ToInt32(cboEstructura.SelectedValue.ToString()),
                    frmControlTareo.obj_Tareas_E.FECHA_TAREO,
                    cboActividades.SelectedValue.ToString(),
                    CODIGO_AREA,
                    cboIngeniero.SelectedValue.ToString()
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
                        dataGridView1.Rows[renglon].Cells["CantidadSalida"].Value = dtResultado.Rows[i]["EJECUTADO_HOY"].ToString();
                        //dataGridView1.Rows[renglon].Cells["IMP_ESPESOR"].Value = dtResultado.Rows[i]["IMP_ESPESOR"].ToString();
                        //dataGridView1.Rows[renglon].Cells["DSC_MATERIAL"].Value = dtResultado.Rows[i]["DSC_MATERIAL"].ToString();
                        //dataGridView1.Rows[renglon].Cells["IMP_PEP"].Value = dtResultado.Rows[i]["IMP_PEP"].ToString();
                        //dataGridView1.Rows[renglon].Cells["DSC_CLASIFICACION"].Value = dtResultado.Rows[i]["DSC_CLASIFICACION"].ToString();

                    }
                    dataGridView1.Visible = true ;
                }
                else
                {
                    dataGridView1.Visible = false;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void cboEstructura_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarEstructura(lblCodigoArea.Text);
        }

        private void cboActividades_SelectedIndexChanged(object sender, EventArgs e)
        {
            string valor = cboActividades.SelectedValue.ToString();
            if (valor != string.Empty)
            {
                BE_ASIGNACION_TAREAS result = LstTareas.Find(
                delegate (BE_ASIGNACION_TAREAS bk)
                {
                    return bk.CODIGO_MARCA == valor;
                }
                );
                if (result != null)
                {
                    lblCodigoArea.Text = result.CODIGO_AREA;
                    TipoEstructura(result.CODIGO_AREA, result.DET_TAREA);
                    ListarEstructura(result.CODIGO_AREA);
                }
                else
                {
                    lblCodigoArea.Text = "";
                }
            }

            
        }

        private void cboIngeniero_SelectedIndexChanged(object sender, EventArgs e)
        {
            listarActividad();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Desea Grabar?", "Mensaje SSK", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (respuesta == DialogResult.Yes)
            {
                string x;
                int CantidadInicial;
                int ID_ESTRUCTURA;
                int rptaTareas;
                int i = 0;
                foreach (DataGridViewRow Rows in dataGridView1.Rows)
                {
                    CantidadInicial = Convert.ToInt32((Rows.Cells["NUM_CANTIDAD"].Value == null) ? "0" : Rows.Cells["NUM_CANTIDAD"].Value.ToString());

                    ID_ESTRUCTURA = Convert.ToInt32((Rows.Cells["ID_ESTRUCTURA"].Value == null) ? "0" : Rows.Cells["ID_ESTRUCTURA"].Value.ToString());


                    //x = (Rows.Cells["CantidadSalida"].Value == null) ? "-1" : Rows.Cells["CantidadSalida"].Value.ToString();
                    //x = (Rows.Cells["CantidadSalida"].Value.ToString() == "") ? "-1" : Rows.Cells["CantidadSalida"].Value.ToString();

                    if (Rows.Cells["CantidadSalida"].Value == null)
                    {
                        x = "-1";
                    }
                    else if (Rows.Cells["CantidadSalida"].Value.ToString() == "")
                    {
                        x = "-1";
                    }
                    else
                    {
                        x = Rows.Cells["CantidadSalida"].Value.ToString();
                    }


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
                            objE.PK_TAREA = cboActividades.SelectedValue.ToString();
                            objE.USUARIO_REGISTRO = frmLogin.obj_user_E.IDE_USUARIO;
                            objE.IDE_INGENIERO = cboIngeniero.SelectedValue.ToString();
                            objE.IDE_TAREA = lblCodigoArea.Text;
                            rptaTareas = new BL_TAREO().Mant_Insert_Estructura_ING(objE);
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
                    ListarEstructura(lblCodigoArea.Text);
                    MessageBox.Show("Registro Satisfactorio", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                                    int CantidadInicial = Convert.ToInt32((Rows.Cells["NUM_CANTIDAD"].Value == null) ? "0" : Rows.Cells["NUM_CANTIDAD"].Value.ToString());
                                    //int STOCK = Convert.ToInt32((Rows.Cells["STOCK"].Value == null) ? "0" : Rows.Cells["STOCK"].Value.ToString());
                                    int ID_ESTRUCTURA = Convert.ToInt32((Rows.Cells["ID_ESTRUCTURA"].Value == null) ? "0" : Rows.Cells["ID_ESTRUCTURA"].Value.ToString());

                                    //x = (Rows.Cells["CantidadSalida"].Value == null) ? "-1" : Rows.Cells["CantidadSalida"].Value.ToString();


                                    if (Rows.Cells["CantidadSalida"].Value == null)
                                    {
                                        x = "-1";
                                    }
                                    else if (Rows.Cells["CantidadSalida"].Value.ToString() == "")
                                    {
                                        x = "-1";
                                    }
                                    else
                                    {
                                        x = Rows.Cells["CantidadSalida"].Value.ToString();
                                    }

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
                                            objE.PK_TAREA = cboActividades.SelectedValue.ToString();
                                            objE.USUARIO_REGISTRO = frmLogin.obj_user_E.IDE_USUARIO;
                                            objE.IDE_INGENIERO = cboIngeniero.SelectedValue.ToString();
                                            objE.IDE_TAREA = lblCodigoArea.Text;
                                            int rptaTareas;
                                            rptaTareas = new BL_TAREO().Mant_Insert_Estructura_ING(objE);

                                            rptaTareas = new BL_TAREO().Mant_Insert_Estructura(objE);
                                            if (rptaTareas > 0)
                                            {
                                                
                                                ListarEstructura(lblCodigoArea.Text);
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

        private void txtUnidad_TextChanged(object sender, EventArgs e)
        {
            GrillaFiltro("1");
        }
        
        private void txtEsctructura_TextChanged(object sender, EventArgs e)
        {
            GrillaFiltro("2");
        }

        private void txtArea_TextChanged(object sender, EventArgs e)
        {
            GrillaFiltro("3");
        }

        private void txtMarca_TextChanged(object sender, EventArgs e)
        {
            GrillaFiltro("4");
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            GrillaFiltro("5");
        }
        protected void EstructuraGrilla()
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
            colAcumulado.HeaderText = "Acumulado anterior";
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

            DataGridViewTextBoxColumn colID_ESTRUCTURA = new DataGridViewTextBoxColumn();
            colID_ESTRUCTURA.Name = "ID_ESTRUCTURA";
            colID_ESTRUCTURA.HeaderText = "ID_ESTRUCTURA";
            colID_ESTRUCTURA.Width = 120;
            dataGridView1.Columns.Insert(9, colID_ESTRUCTURA);

            DataGridViewTextBoxColumn colCantSalida = new DataGridViewTextBoxColumn();
            colCantSalida.Name = "CantidadSalida";
            colCantSalida.HeaderText = "Ejecutado del día";
            colCantSalida.Width = 60;
            colCantSalida.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Insert(10, colCantSalida);

            DataGridViewButtonColumn btnAgregar = new DataGridViewButtonColumn();
            btnAgregar.HeaderText = "";
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Text = "Agregar";
            btnAgregar.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Insert(11, btnAgregar);

           

            dataGridView1.Columns["ID_ESTRUCTURA"].Visible = false;
            dataGridView1.Columns["EJECUTADO_HOY"].Visible = false;
            
            dataGridView1.Columns["CantidadSalida"].DefaultCellStyle.BackColor = Color.FromArgb(255, 248, 110);
        }
        protected void GrillaFiltro(string tipo)
        {
            DataTable dt = dtResulDisponible as DataTable;
            DataView dv = dt.DefaultView;

            if (tipo == "1")
            {
                dv.RowFilter = "DSC_UNIDAD LIKE '%" + txtUnidad.Text + "%'";
            }
            else if (tipo == "2")
            {
                dv.RowFilter = "DSC_ESTRUCTURA LIKE '%" + txtEsctructura.Text + "%'";
            }
            else if (tipo == "3")
            {
                dv.RowFilter = "DSC_AREA LIKE '%" + txtArea.Text + "%'";
            }
            else if (tipo == "4")
            {
                dv.RowFilter = "DSC_MARCA LIKE '%" + txtMarca.Text + "%'";
            }
            else if (tipo == "5")
            {
                dv.RowFilter = "DSC_DESCRIPCION LIKE '%" + txtDescripcion.Text + "%'";
            }
            EstructuraGrilla();

            string Row,  DSC_UNIDAD, DSC_ESTRUCTURA, DSC_AREA, DSC_MARCA, DSC_DESCRIPCION, NUM_CANTIDAD, EJECUTADO_HOY, ACUMULADO_AYER, ID_ESTRUCTURA, INGRESAR;
            string[] Xrow;
            for (int i = 0; i < dv.Count; i++)
            {
                Row = dv[i]["Row"].ToString();
               
                DSC_UNIDAD = dv[i]["DSC_UNIDAD"].ToString();
                DSC_ESTRUCTURA = dv[i]["DSC_ESTRUCTURA"].ToString();
                DSC_AREA = dv[i]["DSC_AREA"].ToString();
                DSC_MARCA = dv[i]["DSC_MARCA"].ToString();
                DSC_DESCRIPCION = dv[i]["DSC_DESCRIPCION"].ToString();
                NUM_CANTIDAD = dv[i]["NUM_CANTIDAD"].ToString();
                EJECUTADO_HOY = dv[i]["EJECUTADO_HOY"].ToString();
                ACUMULADO_AYER = dv[i]["ACUMULADO_AYER"].ToString();
                ID_ESTRUCTURA = dv[i]["ID_ESTRUCTURA"].ToString();
                INGRESAR = dv[i]["EJECUTADO_HOY"].ToString();

                Xrow = new string[] { Row,  DSC_UNIDAD, DSC_ESTRUCTURA, DSC_AREA, DSC_MARCA, DSC_DESCRIPCION, NUM_CANTIDAD, EJECUTADO_HOY, ACUMULADO_AYER, ID_ESTRUCTURA, INGRESAR };
                dataGridView1.Rows.Add(Xrow);
            }


            
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void IngenieroAvance_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bSalir == false)
            {
                DialogResult respuesta = MessageBox.Show("¿Esta seguro que desea Salir del Formulario?", "Mensaje Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (respuesta != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
                else
                {
                    e.Cancel = false;
                }
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1)
            {

                btnGuardar.PerformClick();
            }
            if (keyData == Keys.Enter )
            {

                btnGuardar.PerformClick();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
