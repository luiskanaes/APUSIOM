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
    public partial class frmPersonalSinTareo : Form
    {
        public frmPersonalSinTareo()
        {
            InitializeComponent();
            Listar();
        }

        private void frmPersonalSinTareo_Load(object sender, EventArgs e)
        {

        }
        protected void Listar()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();

            dataGridView1.ColumnCount = 5;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "Item";
            checkBoxColumn.ToolTipText = "Disponible";
            checkBoxColumn.Width = 50;
            checkBoxColumn.Name = "Seleccion";
            dataGridView1.Columns.Insert(0, checkBoxColumn);
            dataGridView1.Columns[1].Name = "Nro";
            dataGridView1.Columns[2].Name = "Apellidos y nombres";
            dataGridView1.Columns[3].Name = "Responsable de Cuadrilla";
            dataGridView1.Columns[4].Name = "Dni";

            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.Columns[4].Visible = false;
            BL_TAREO xobj = new BL_TAREO();
            DataTable dtResultado = new DataTable();
            dtResultado = xobj.ListarPersonal_SinTareo( Convert.ToInt32(frmTareoDiario.obj_asignacion_E.IDE_EMPRESA.ToString()), frmTareoDiario.obj_asignacion_E.CENTRO_COSTO, frmTareoDiario.obj_asignacion_E.FECHA_TAREO);

            if (dtResultado.Rows.Count > 0)
            {
                string FLG_LIBRE,ITEM, NOMBRES_COMPLETO, CAPATAZ, DOCUMENTO_IDENTIFICACION;
                string[] Xrow;

                for (int i = 0; i < dtResultado.Rows.Count; i++)
                {
                    ITEM = dtResultado.Rows[i]["ITEM"].ToString();
                    NOMBRES_COMPLETO = dtResultado.Rows[i]["NOMBRES_COMPLETO"].ToString();
                    CAPATAZ = dtResultado.Rows[i]["CAPATAZ"].ToString();
                    FLG_LIBRE = dtResultado.Rows[i]["SELECCIONAR"].ToString();
                    DOCUMENTO_IDENTIFICACION = dtResultado.Rows[i]["DOCUMENTO_IDENTIFICACION"].ToString();
                    Xrow = new string[] { FLG_LIBRE,ITEM, NOMBRES_COMPLETO, CAPATAZ , DOCUMENTO_IDENTIFICACION };
                    dataGridView1.Rows.Add(Xrow);

                }
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            dataGridView1.AllowUserToAddRows = false ;
        }

        private void checkTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (checkTodos.Checked == false)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
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
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    dataGridView1.Rows[row.Index].SetValues(true);
                }
                //checkTodos.Checked = true;
                //chkInt = dgvCuadrilla.Rows.Count;
            }
        }

        private void btnFaltos_Click(object sender, EventArgs e)
        {
            ProcesarEstado("FALTA", "FALTA");
        }
        protected void ProcesarEstado( string Msg, string Estado)
        {
            DialogResult respuesta = MessageBox.Show("¿Desea indicar la situación de " + Msg + " a los siguiente trabajadores?", "Situación de Trabajo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (respuesta == DialogResult.Yes)
            {
                BL_PERSONAL obj = new BL_PERSONAL();
                //
                // Se define una lista temporal de registro seleccionados
                //
                List<DataGridViewRow> rowSelected = new List<DataGridViewRow>();

                //
                // Se recorre ca registro de la grilla de origen
                //
                foreach (DataGridViewRow row in dataGridView1.Rows)
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
                foreach (DataGridViewRow row in rowSelected)
                {


                    // REGISTRO DE ASITENCIAS
                    BE_ASISTENCIA_PERSONAL ObjAsistencia = new BE_ASISTENCIA_PERSONAL();
                    ObjAsistencia.IDE_ASISTENCIA = 0;
                    ObjAsistencia.IDE_PERSONAL = row.Cells["Dni"].Value.ToString();
                    ObjAsistencia.FEC_ASISTENCIA = frmTareoDiario.obj_asignacion_E.FECHA_TAREO;
                    ObjAsistencia.CCENTRO = frmTareoDiario.obj_asignacion_E.CENTRO_COSTO;
                    ObjAsistencia.IDE_EMPRESA = Convert.ToInt32(frmTareoDiario.obj_asignacion_E.IDE_EMPRESA.ToString());
                    ObjAsistencia.USUARIO_REGISTRA = frmLogin.obj_user_E.IDE_USUARIO;
                    ObjAsistencia.IDE_ESTADO = Estado;
                    int rptAsistencia;
                    rptAsistencia = new BL_ASISTENCIA_PERSONAL().Mant_Insert_Asistencias(ObjAsistencia);
                    if (rptAsistencia > 0)
                    {

                    }

                    dataGridView1.Rows.Remove(row);
                }
                Listar();
            }
        }

        private void btnBajada_Click(object sender, EventArgs e)
        {
            ProcesarEstado("BAJADA", "B");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProcesarEstado("DESCANSO MEDICO", "E");
        }

        private void btnSuspendio_Click(object sender, EventArgs e)
        {
            ProcesarEstado("SUSPENDIDO", "S");
        }

        private void btnPermiso_Click(object sender, EventArgs e)
        {
            ProcesarEstado("PERMISO", "P");
        }

        private void btnObservado_Click(object sender, EventArgs e)
        {
            ProcesarEstado("OBSERVADO", "O");
        }

        private void btnLSGH_Click(object sender, EventArgs e)
        {
            ProcesarEstado("LSGH", "LSGH");
        }
    }
}
