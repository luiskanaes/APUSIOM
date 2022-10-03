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
    public partial class frmDiasTrabajo : Form
    {
        public frmDiasTrabajo()
        {
            InitializeComponent();
            ListarEmpresa();
        }

        private void frmDiasTrabajo_Load(object sender, EventArgs e)
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            listarDias();
            double  sumatoria = 0;
            for (int i = 4; i < dataGridView1.ColumnCount - 3; i++)
            {
                sumatoria = 0;

                foreach (DataGridViewRow row in dataGridView1.Rows)
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
                DataGridViewRow rowTotal = dataGridView1.Rows[dataGridView1.Rows.Count - 1];
                rowTotal.Cells[i].Value = sumatoria;

                sumatoria = 0;

            }
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].DefaultCellStyle.BackColor = Color.FromArgb(255, 248, 110);
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].ReadOnly = true;
        }
        protected void listarDias()
        {
        
      


            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();

            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //dataGridView1.AllowUserToAddRows = true;
            DataGridViewTextBoxColumn colItem = new DataGridViewTextBoxColumn();
            colItem.HeaderText = "Item";
            colItem.Width = 30;
            colItem.Name = "Row";
            colItem.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Insert(0, colItem);

            DataGridViewTextBoxColumn colFECHA = new DataGridViewTextBoxColumn();
            colFECHA.Name = "FECHA";
            colFECHA.HeaderText = "Fecha";
            colFECHA.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colFECHA.Width = 100;
            dataGridView1.Columns.Insert(1, colFECHA);


            DataGridViewTextBoxColumn colNOMBRE_DIA = new DataGridViewTextBoxColumn();
            colNOMBRE_DIA.Name = "NOMBRE_DIA";
            colNOMBRE_DIA.HeaderText = "Día";
            colNOMBRE_DIA.Width = 120;
            dataGridView1.Columns.Insert(2, colNOMBRE_DIA);

            DataGridViewTextBoxColumn colLABORABLE = new DataGridViewTextBoxColumn();
            colLABORABLE.Name = "LABORABLE";
            colLABORABLE.HeaderText = "Feriado";
            colLABORABLE.Width = 50;
            colLABORABLE.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Insert(3, colLABORABLE);


            DataGridViewTextBoxColumn colTOTAL_PERSONAS = new DataGridViewTextBoxColumn();
            colTOTAL_PERSONAS.Name = "TOTAL_PERSONAS";
            colTOTAL_PERSONAS.HeaderText = "Total Obreros";
            colTOTAL_PERSONAS.Width = 70;
            colTOTAL_PERSONAS.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Insert(4, colTOTAL_PERSONAS);

            DataGridViewTextBoxColumn colPRESENTES = new DataGridViewTextBoxColumn();
            colPRESENTES.Name = "colPRESENTES";
            colPRESENTES.HeaderText = "Presentes";
            colPRESENTES.Width = 70;
            colPRESENTES.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Insert(5, colPRESENTES);

            DataGridViewTextBoxColumn colDOMINGO = new DataGridViewTextBoxColumn();
            colDOMINGO.Name = "colDOMINGO";
            colDOMINGO.HeaderText = "Feriado / Dominical";
            colDOMINGO.Width = 70;
            colDOMINGO.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Insert(6, colDOMINGO);


            DataGridViewTextBoxColumn colBAJADAS = new DataGridViewTextBoxColumn();
            colBAJADAS.Name = "BAJADAS";
            colBAJADAS.HeaderText = "Bajadas";
            colBAJADAS.Width =70;
            colBAJADAS.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Insert(7, colBAJADAS);

            DataGridViewTextBoxColumn colFALTAS = new DataGridViewTextBoxColumn();
            colFALTAS.Name = "FALTAS";
            colFALTAS.HeaderText = "Faltas";
            colFALTAS.Width = 70;
            colFALTAS.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Insert(8, colFALTAS);

            DataGridViewTextBoxColumn colDM = new DataGridViewTextBoxColumn();
            colDM.Name = "DM";
            colDM.HeaderText = "D/M";
            colDM.Width = 70;
            colDM.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Insert(9, colDM);

            //////////////////////////////////////

            DataGridViewTextBoxColumn colSUSPENDIDO = new DataGridViewTextBoxColumn();
            colSUSPENDIDO.Name = "SUSPENDIDO";
            colSUSPENDIDO.HeaderText = "SUSPENDIDO";
            colSUSPENDIDO.Width = 70;
            colSUSPENDIDO.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Insert(10, colSUSPENDIDO);


            DataGridViewTextBoxColumn colPERMISO = new DataGridViewTextBoxColumn();
            colPERMISO.Name = "PERMISO";
            colPERMISO.HeaderText = "PERMISO";
            colPERMISO.Width = 70;
            colPERMISO.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Insert(11, colPERMISO);

            DataGridViewTextBoxColumn colOBSERVADO = new DataGridViewTextBoxColumn();
            colOBSERVADO.Name = "OBSERVADO";
            colOBSERVADO.HeaderText = "OBSERVADO";
            colOBSERVADO.Width = 70;
            colOBSERVADO.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Insert(12, colOBSERVADO);

            DataGridViewTextBoxColumn colTRANSICION = new DataGridViewTextBoxColumn();
            colTRANSICION.Name = "TRANSICION";
            colTRANSICION.HeaderText = "TRANSICION";
            colTRANSICION.Width = 70;
            colTRANSICION.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Insert(13, colTRANSICION);

            DataGridViewTextBoxColumn colSUBSIDIO = new DataGridViewTextBoxColumn();
            colSUBSIDIO.Name = "SUBSIDIO";
            colSUBSIDIO.HeaderText = "SUBSIDIO";
            colSUBSIDIO.Width = 70;
            colSUBSIDIO.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Insert(14, colSUBSIDIO);

            DataGridViewTextBoxColumn colLCGH = new DataGridViewTextBoxColumn();
            colLCGH.Name = "LCGH";
            colLCGH.HeaderText = "LCGH";
            colLCGH.Width = 70;
            colLCGH.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Insert(15, colLCGH);

            DataGridViewTextBoxColumn colLSGH = new DataGridViewTextBoxColumn();
            colLSGH.Name = "LSGH";
            colLSGH.HeaderText = "LSGH";
            colLSGH.Width = 70;
            colLSGH.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Insert(16, colLSGH);


            ///////////////////////////////////////














            DataGridViewTextBoxColumn colTOTAL_HN = new DataGridViewTextBoxColumn();
            colTOTAL_HN.Name = "TOTAL_HN";
            colTOTAL_HN.HeaderText = "Hrs Trabajo";
            colTOTAL_HN.Width = 70;
            colTOTAL_HN.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Insert(17, colTOTAL_HN);

            DataGridViewTextBoxColumn colTOTAL_BONO = new DataGridViewTextBoxColumn();
            colTOTAL_BONO.Name = "TOTAL_BONO";
            colTOTAL_BONO.HeaderText = "Hrs Bonos";
            colTOTAL_BONO.Width = 70;
            colTOTAL_BONO.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Insert(18, colTOTAL_BONO);


            DataGridViewTextBoxColumn colCONTROL_DELETE = new DataGridViewTextBoxColumn();
            colCONTROL_DELETE.Name = "CONTROL_DELETE";
            colCONTROL_DELETE.HeaderText = "Eliminar";
            colCONTROL_DELETE.Width = 100;
            colCONTROL_DELETE.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Insert(19, colCONTROL_DELETE);



            dataGridView1.Columns["CONTROL_DELETE"].Visible = false;


            DataGridViewTextBoxColumn colCIERRE = new DataGridViewTextBoxColumn();
            colCIERRE.Name = "CIERRE";
            colCIERRE.HeaderText = "Tareo";
            colCIERRE.Width = 100;
            colCIERRE.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Insert(20, colCIERRE);


            DataGridViewTextBoxColumn colMIGRACION = new DataGridViewTextBoxColumn();
            colMIGRACION.Name = "MIGRACION";
            colMIGRACION.HeaderText = "Migración";
            colMIGRACION.Width = 100;
            colCIERRE.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Insert(21, colMIGRACION);

            //boton
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            dataGridView1.Columns.Add(btn);
            btn.HeaderText = "";
            btn.Text = "Eliminar";
            btn.Name = "btn";
            btn.UseColumnTextForButtonValue = true;


            dataGridView1.Columns["TOTAL_PERSONAS"].DefaultCellStyle.BackColor = Color.FromArgb(255, 248, 110);
            dataGridView1.Columns["TOTAL_HN"].DefaultCellStyle.BackColor = Color.FromArgb(237, 252, 153);
            dataGridView1.Columns["TOTAL_BONO"].DefaultCellStyle.BackColor = Color.FromArgb(237, 252, 153);

            dataGridView1.Columns["btn"].Visible = false;
            BL_JORNADA_FERIADOS obj = new BL_JORNADA_FERIADOS();
            DataTable dtResulDisponible = new DataTable();
            int anio = Convert.ToInt32(dateTimePicker1.Value.Date.ToString("yyyy"));
            int mes = Convert.ToInt32(dateTimePicker2.Value.Date.ToString("MM"));
            string centro = cboCentroCosto.SelectedValue.ToString();
            dtResulDisponible = obj.uspSEL_JORNADA_FERIADOS_CENTRO(anio,mes,centro );
            try
            {
               
                if (dtResulDisponible.Rows.Count > 0)
                {
                    string Row, FECHA, NOMBRE_DIA, LABORABLE,  TOTAL_PERSONAS, PRESENTES, FERIADO_DOM, BAJADAS, FALTAS, DM,
                        SUSPENDIDO, PERMISO, OBSERVADO, TRANSICION, SUBSIDIO, LCGH, LSGH,
                        TOTAL_HN, TOTAL_BONO,  CONTROL_DELETE, CIERRE, MIGRACION;

                    string[] Xrow;
                    for (int i = 0; i < dtResulDisponible.Rows.Count; i++)
                    {
                        Row = dtResulDisponible.Rows[i]["Row"].ToString();// Convert.ToString(i + 1);
                        FECHA = dtResulDisponible.Rows[i]["FECHA"].ToString();
                        NOMBRE_DIA = dtResulDisponible.Rows[i]["NOMBRE_DIA"].ToString();
                        LABORABLE = dtResulDisponible.Rows[i]["LABORABLE"].ToString();
                        
                        TOTAL_PERSONAS = dtResulDisponible.Rows[i]["TOTAL_PERSONAS"].ToString();

                        PRESENTES = dtResulDisponible.Rows[i]["PRESENTES"].ToString();
                        FERIADO_DOM = dtResulDisponible.Rows[i]["FERIADO_DOM"].ToString();
                      
                        BAJADAS = dtResulDisponible.Rows[i]["BAJADAS"].ToString();
                        FALTAS = dtResulDisponible.Rows[i]["FALTAS"].ToString();
                        DM = dtResulDisponible.Rows[i]["DM"].ToString();

                        SUSPENDIDO = dtResulDisponible.Rows[i]["SUSPENDIDO"].ToString();
                        PERMISO = dtResulDisponible.Rows[i]["PERMISO"].ToString();
                        OBSERVADO = dtResulDisponible.Rows[i]["OBSERVADO"].ToString();
                        TRANSICION = dtResulDisponible.Rows[i]["TRANSICION"].ToString();
                        SUBSIDIO = dtResulDisponible.Rows[i]["SUBSIDIO"].ToString();
                        LCGH = dtResulDisponible.Rows[i]["LCGH"].ToString();
                        LSGH = dtResulDisponible.Rows[i]["LSGH"].ToString();




                        TOTAL_HN = dtResulDisponible.Rows[i]["TOTAL_HN"].ToString();

                        TOTAL_BONO = dtResulDisponible.Rows[i]["TOTAL_BONO"].ToString();
                        CONTROL_DELETE = dtResulDisponible.Rows[i]["CONTROL_DELETE"].ToString();
                        CIERRE = dtResulDisponible.Rows[i]["CIERRE"].ToString();
                        MIGRACION = dtResulDisponible.Rows[i]["MIGRACION"].ToString();
                        Xrow = new string[] {
                       //Convert.ToBoolean( FLG_LIBRE).ToString (),ITEM, Personal,CATEGORIA, IDE_PERSONAL,ASIGNADO
                       Row, FECHA, NOMBRE_DIA, LABORABLE,  TOTAL_PERSONAS, PRESENTES,FERIADO_DOM, BAJADAS, FALTAS, DM,
                            SUSPENDIDO, PERMISO, OBSERVADO, TRANSICION, SUBSIDIO, LCGH, LSGH,
                            TOTAL_HN, TOTAL_BONO, CONTROL_DELETE,CIERRE,MIGRACION
                        };

                        
                        dataGridView1.Rows.Add(Xrow);
                    }
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells["LABORABLE"].Value.ToString() == "SI")
                        {
                          
                            row.Cells["LABORABLE"].Style.BackColor = Color.FromArgb(255, 195, 0);

                        }

                    }
                    int x=0;
                    

                }

                else
                {
                    MessageBox.Show("No se registra información", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                //dataGridView1.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
              
            }


        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Desea agregar " + dateFecha.Value.Date.ToString("dd/MM/yyyy") + " como feriado?", "Grabar Registros", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (respuesta == DialogResult.Yes)
            {
                guardarFeriado();
            }
        }
        protected void guardarFeriado()
        {
            int rpta = 0;
            BE_JORNADA_FERIADOS obj = new BE_JORNADA_FERIADOS();
            obj.IDE_FERIADO = Convert.ToInt32((lblcodigo.Text  == null) ? "0" : lblcodigo.Text);
            obj.FECHA = dateFecha.Value.Date.ToString("dd/MM/yyyy");
            obj.DES_CRIPCION = dateFecha.Value.Date.ToString("dddd");
            obj.IDE_EMPRESA = Convert.ToInt32(cboEmpresa.SelectedValue.ToString ()  );
            obj.CENTRO_COSTO = cboCentroCosto.SelectedValue.ToString();
            rpta = new BL_JORNADA_FERIADOS().Mant_Insert_diasFeriados(obj);
            if (rpta > 0)
            {
                lblcodigo.Text = "0";
                listarDias();
                MessageBox.Show("Registro satisfactorio", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            string fecha;
            //eliminar fila de tareas
            if (e.ColumnIndex > -1)
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "btn")
                {
                    DataGridViewRow Rows = dataGridView1.Rows[i];
                  

                    DialogResult respuesta = MessageBox.Show("¿Desea eliminar día feriado?", "Mensaje SSK", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (respuesta == DialogResult.Yes)
                    {
                       
                        for (int j = 0; j <= e.ColumnIndex; j++)
                        {
                            try
                            {
                                string columnas = dataGridView1.Columns[j].Name;
                                if (columnas.Equals("FECHA"))
                                {
                                    fecha = (Rows.Cells["FECHA"].Value == null) ? "" : Rows.Cells["FECHA"].Value.ToString();
                                    DataTable dt = new DataTable();
                                    BL_JORNADA_FERIADOS objTarea = new BL_JORNADA_FERIADOS();
                                    dt = objTarea.uspDEL_DIA_FERIADOS_CENTRO(fecha, cboCentroCosto.SelectedValue.ToString());
                                    if (dt.Rows.Count > 0)
                                    {
                                        listarDias();
                                        MessageBox.Show("Registro eliminado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        MessageBox.Show("No se permite esta operación, fecha con horas de trabajo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

       
    }
}
