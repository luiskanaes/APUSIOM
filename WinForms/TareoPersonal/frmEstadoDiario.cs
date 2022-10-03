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
    public partial class frmEstadoDiario : Form
    {
        public frmEstadoDiario()
        {
            InitializeComponent();
        }

        private void frmEstadoDiario_Load(object sender, EventArgs e)
        {
            cargaUbicaciones();
            CargaAsistencia();
            CargaEstado();
            Listar();
        }

        private void cargaUbicaciones()
        {

            BL_TAREO_EMPLEADO obj = new BL_TAREO_EMPLEADO();
            DataTable dtResultado = new DataTable();
            dtResultado = obj.SP_CONSULTAR_UBICACIONES(frmLogin.obj_user_E.IDE_USUARIO);//frmLogin.obj_user_E.IDE_USUARIO);
            if (dtResultado.Rows.Count > 0)
            {

                cboUbicacion.ValueMember = "ID";
                cboUbicacion.DisplayMember = "DESCRIPCION";
                cboUbicacion.DataSource = dtResultado;

            }

        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                txtColor.BackColor = colorDialog1.Color;
                String code = (colorDialog1.Color.ToArgb() & 0x00FFFFFF).ToString("X6");
                txtColorcodigo.Text ="#"+ code; 
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Desea guardar regitros?", "Mensaje SSK", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (respuesta == DialogResult.Yes)
            {
                if (txtdescripcion.Text.Trim() == string.Empty )
                {
                    MessageBox.Show("Ingresar descripción", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (txtabreviatura.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Ingresar abreviatura", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else 
                {
                    BE_UBICACIONES_ESTADO oBESol = new BE_UBICACIONES_ESTADO();
                    oBESol.IDE_ESTADO = Convert.ToInt32(string.IsNullOrEmpty(txtCodigo.Text.Trim()) ? "0" : txtCodigo.Text.Trim());
                    oBESol.IDE_UBICACION = cboUbicacion.SelectedValue.ToString()    ;
                    oBESol.DESCRIPCION = txtdescripcion.Text.Trim()     ;
                    oBESol.ABREVIATURA = txtabreviatura.Text.Trim();
                    oBESol.COLOR_FONDO = string.IsNullOrEmpty(txtColorcodigo.Text.Trim()) ? "#ffffff" : txtColorcodigo.Text.Trim();
                    oBESol.FLG_ESTADO = Convert.ToInt32(cboEstado.SelectedValue)    ;
                    oBESol.FLG_PRESENTE = Convert.ToInt32(cbopresente.SelectedValue);

                    int rpta;
                    rpta = new BL_UBICACIONES_ESTADO().uspINS_UBICACIONES_ESTADO(oBESol);
                    if (rpta > 0)
                    {
                        Limpiar();
                        MessageBox.Show("Registro satisfactorio", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Listar();
                    }

                }
            }
        }

        protected void Listar()
        {

            dgvListar.Rows.Clear();
            dgvListar.Refresh();
            dgvListar.DataSource = null;
            dgvListar.Columns.Clear();

            dgvListar.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            DataGridViewTextBoxColumn colOrden = new DataGridViewTextBoxColumn();
            colOrden.Name = "Row";
            colOrden.HeaderText = "N°";
            colOrden.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colOrden.Width = 30;
            dgvListar.Columns.Insert(0, colOrden);

            DataGridViewTextBoxColumn colDESCRIPCION = new DataGridViewTextBoxColumn();
            colDESCRIPCION.Name = "DESCRIPCION";
            colDESCRIPCION.HeaderText = "DESCRIPCIÓN";
            colDESCRIPCION.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colDESCRIPCION.Width = 250;
            dgvListar.Columns.Insert(1, colDESCRIPCION);


            DataGridViewTextBoxColumn colABREVIATURA = new DataGridViewTextBoxColumn();
            colABREVIATURA.Name = "ABREVIATURA";
            colABREVIATURA.HeaderText = "ABREVIATURA";
            colABREVIATURA.Width = 80;
            colABREVIATURA.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvListar.Columns.Insert(2, colABREVIATURA);

            DataGridViewTextBoxColumn colCOLOR_FONDO = new DataGridViewTextBoxColumn();
            colCOLOR_FONDO.Name = "COLOR_FONDO";
            colCOLOR_FONDO.HeaderText = "COLOR";
            colCOLOR_FONDO.Width = 100;
            dgvListar.Columns.Insert(3, colCOLOR_FONDO);
            



            DataGridViewTextBoxColumn colFLG_ESTADO = new DataGridViewTextBoxColumn();
            colFLG_ESTADO.Name = "FLG_ESTADO";
            colFLG_ESTADO.HeaderText = "ESTADO";
            colFLG_ESTADO.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colFLG_ESTADO.Width = 100;
            dgvListar.Columns.Insert(4, colFLG_ESTADO);


            DataGridViewTextBoxColumn colFLG_PRESENTE = new DataGridViewTextBoxColumn();
            colFLG_PRESENTE.Name = "FLG_PRESENTE";
            colFLG_PRESENTE.HeaderText = "ASISTENCIA";
            colFLG_PRESENTE.Width = 100;
            colOrden.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvListar.Columns.Insert(5, colFLG_PRESENTE);


            DataGridViewTextBoxColumn colIDE_ESTADO = new DataGridViewTextBoxColumn();
            colIDE_ESTADO.Name = "IDE_ESTADO";
            colIDE_ESTADO.HeaderText = "IDE_ESTADO";
            colIDE_ESTADO.Width = 30;
            dgvListar.Columns.Insert(6, colIDE_ESTADO);
            dgvListar.Columns["IDE_ESTADO"].Visible = false;

            //boton
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            dgvListar.Columns.Add(btn);
            btn.HeaderText = "";
            btn.Text = "EDITAR";
            btn.Name = "btn";
            btn.UseColumnTextForButtonValue = true;

            BL_UBICACIONES_ESTADO oBESol = new BL_UBICACIONES_ESTADO();
            DataTable dtResultado = new DataTable();
            dtResultado = oBESol.uspSEL_UBICACIONES_ESTADO_POR_UBICACION(cboUbicacion.SelectedValue.ToString(), "");
            if (dtResultado.Rows.Count > 0)
            {
           
                for (int i = 0; i < dtResultado.Rows.Count; i++)
                {

                    int renglon = dgvListar.Rows.Add();
                    dgvListar.Rows[renglon].Cells["Row"].Value = dtResultado.Rows[i]["Row"].ToString();// Convert.ToString(i + 1);
                    dgvListar.Rows[renglon].Cells["DESCRIPCION"].Value = dtResultado.Rows[i]["DESCRIPCION"].ToString();
                    dgvListar.Rows[renglon].Cells["ABREVIATURA"].Value = dtResultado.Rows[i]["ABREVIATURA"].ToString();
                    dgvListar.Rows[renglon].Cells["COLOR_FONDO"].Value = dtResultado.Rows[i]["COLOR_FONDO"].ToString();
                    dgvListar.Rows[renglon].Cells["COLOR_FONDO"].Style.BackColor = ColorTranslator.FromHtml(dtResultado.Rows[i]["COLOR_FONDO"].ToString());
                    dgvListar.Rows[renglon].Cells["FLG_ESTADO"].Value = dtResultado.Rows[i]["FLG_ESTADO"].ToString();
                    dgvListar.Rows[renglon].Cells["FLG_PRESENTE"].Value = dtResultado.Rows[i]["FLG_PRESENTE"].ToString();
                    dgvListar.Rows[renglon].Cells["IDE_ESTADO"].Value = dtResultado.Rows[i]["IDE_ESTADO"].ToString();

                }
            }
            else
            {
                dgvListar.Rows.Clear();
                dgvListar.Refresh();
                dgvListar.DataSource = null;
                dgvListar.Columns.Clear();
            }
        }


        static DataTable GetTableEstado()
        {
            // Here we create a DataTable with four columns.
            DataTable table = new DataTable();
            table.Columns.Add("IDE", typeof(bool));
            table.Columns.Add("DESCRIPCION", typeof(string));


            // Here we add five DataRows.
            table.Rows.Add(true, "HABILITADO");
            table.Rows.Add(false, "BLOQUEADO");
            return table;
        }

        private void CargaEstado()
        {

            BL_TAREO_EMPLEADO obj = new BL_TAREO_EMPLEADO();
            DataTable dtResultado = new DataTable();
            dtResultado = GetTableEstado();
            if (dtResultado.Rows.Count > 0)
            {

                cboEstado.ValueMember = "IDE";
                cboEstado.DisplayMember = "DESCRIPCION";
                cboEstado.DataSource = dtResultado;

            }

        }

        static DataTable GetTableAsistencia()
        {
            // Here we create a DataTable with four columns.
            DataTable table = new DataTable();
            table.Columns.Add("IDE", typeof(bool));
            table.Columns.Add("DESCRIPCION", typeof(string));


            // Here we add five DataRows.
            table.Rows.Add(true, "SI");
            table.Rows.Add(false, "NO");
            return table;
        }

        private void CargaAsistencia()
        {

            BL_TAREO_EMPLEADO obj = new BL_TAREO_EMPLEADO();
            DataTable dtResultado = new DataTable();
            dtResultado = GetTableAsistencia();
            if (dtResultado.Rows.Count > 0)
            {

                cbopresente.ValueMember = "IDE";
                cbopresente.DisplayMember = "DESCRIPCION";
                cbopresente.DataSource = dtResultado;

            }

        }

        private void cboUbicacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            Limpiar();
            Listar();
        }

        protected void Limpiar()
        {
            txtabreviatura.Text = string.Empty;
            txtCodigo.Text = string.Empty;
            txtColor.Text = string.Empty;
            txtColorcodigo.Text = string.Empty;
            txtdescripcion.Text = string.Empty;
        }
        private void dgvListar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            string codigo;

            if (e.ColumnIndex > -1)
            {
                if (dgvListar.Columns[e.ColumnIndex].Name == "btn")
                {
                    DialogResult respuesta = MessageBox.Show("¿Desea actualizar registro?", "Mensaje SSK", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (respuesta == DialogResult.Yes)
                    {
                        //grabar tareas
          
                        DataGridViewRow rowx = dgvListar.Rows[i];
                        codigo = (rowx.Cells[1].Value == null) ? string.Empty : rowx.Cells[1].Value.ToString();// persona
                        if (codigo != string.Empty)
                        {
                            BL_UBICACIONES_ESTADO oBESol = new BL_UBICACIONES_ESTADO();
                            DataTable dtResultado = new DataTable();
                            dtResultado = oBESol.uspSEL_UBICACIONES_ESTADO_POR_UBICACION(cboUbicacion.SelectedValue.ToString(), "");
                            if (dtResultado.Rows.Count > 0)
                            {

                                
                                   
                                   txtdescripcion.Text = dtResultado.Rows[i]["DESCRIPCION"].ToString();
                                   txtabreviatura.Text= dtResultado.Rows[i]["ABREVIATURA"].ToString();
                                    txtColorcodigo.Text= dtResultado.Rows[i]["COLOR_FONDO"].ToString();
                                    txtColor.BackColor = ColorTranslator.FromHtml(dtResultado.Rows[i]["COLOR_FONDO"].ToString());
                                    cboEstado.SelectedValue= Convert.ToBoolean(dtResultado.Rows[i]["FLG_ESTADO"].ToString());
                                    cbopresente.SelectedValue = Convert.ToBoolean( dtResultado.Rows[i]["FLG_PRESENTE"].ToString());
                                    txtCodigo.Text = dtResultado.Rows[i]["IDE_ESTADO"].ToString();

                                
                            }

                        }
                        else
                        {
                            MessageBox.Show("Operación no permitida", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }


                }

            }
        }
    }
    
}
