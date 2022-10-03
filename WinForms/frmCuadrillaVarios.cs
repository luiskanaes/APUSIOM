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
    public partial class frmCuadrillaVarios : Form
    {
        public int varCuadrilla;
        public frmCuadrillaVarios()
        {
            InitializeComponent();
            Cuadrilla();
        }

        private void frmCuadrillaVarios_Load(object sender, EventArgs e)
        {
            ConsultarTareo();
        }
        protected void ConsultarTareo()
        {

            BL_ASIGNACION_TAREO obj = new BL_ASIGNACION_TAREO();
            DataTable dtResultado = new DataTable();


            dtResultado = obj.Listar_TareoFecha(Convert.ToInt32(frmControlTareoDigitacion.obj_Tareo_E.IDE_EMPRESA),
                frmControlTareoDigitacion.obj_Tareo_E.IDE_CECOS,
                frmControlTareoDigitacion.obj_Tareo_E.FEC_TAREO);

            if (dtResultado.Rows.Count > 0)
            {

                string FLG_ESTADO = dtResultado.Rows[0]["FLG_ESTADO"].ToString();
                string FLG_MIGRADO = dtResultado.Rows[0]["FLG_MIGRADO"].ToString();


                if (FLG_ESTADO == "0")
                {
                    button1.Visible = false;
                    //Keys.KeyCode.
                }
                else
                {
                    button1.Visible = true;

                }

            }

        }
        protected void Cuadrilla()
        {
            BL_CUADRILLA objCuadrilla = new BL_CUADRILLA();
            DataTable dtResultado = new DataTable();
            dtResultado = objCuadrilla.SP_LISTAR_CUADRILLA_OBRERO(
                Convert.ToInt32(frmControlTareoDigitacion.obj_Tareo_E.IDE_EMPRESA),
                frmControlTareoDigitacion.obj_Tareo_E.IDE_CECOS,
                frmControlTareoDigitacion.obj_Tareo_E.FEC_TAREO
                );


            dgvPersonal.Rows.Clear();
            dgvPersonal.Refresh();
            dgvPersonal.DataSource = null;
            dgvPersonal.Columns.Clear();

            dgvPersonal.AllowUserToAddRows = true;
            dgvPersonal.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "Item";
            checkBoxColumn.Width = 30;
            checkBoxColumn.Name = "Seleccion";
            dgvPersonal.Columns.Insert(0, checkBoxColumn);

            DataGridViewTextBoxColumn colIDE_OPERARIO = new DataGridViewTextBoxColumn();
            colIDE_OPERARIO.Name = "IDE_OPERARIO";
            colIDE_OPERARIO.HeaderText = "DNI";
            colIDE_OPERARIO.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colIDE_OPERARIO.Width = 90;
            dgvPersonal.Columns.Insert(1, colIDE_OPERARIO);

            DataGridViewTextBoxColumn colOBRERO = new DataGridViewTextBoxColumn();
            colOBRERO.Name = "OBRERO";
            colOBRERO.HeaderText = "OBRERO";
            colOBRERO.Width = 200;
            dgvPersonal.Columns.Insert(2, colOBRERO);

            DataGridViewTextBoxColumn colCAPATAZ = new DataGridViewTextBoxColumn();
            colCAPATAZ.Name = "CAPATAZ";
            colCAPATAZ.HeaderText = "CAPATAZ";
            colCAPATAZ.Width = 200;
            dgvPersonal.Columns.Insert(3, colCAPATAZ);


            DataGridViewTextBoxColumn colINGENIERO = new DataGridViewTextBoxColumn();
            colINGENIERO.Name = "INGENIERO";
            colINGENIERO.HeaderText = "INGENIERO";
            colINGENIERO.Width = 200;
            dgvPersonal.Columns.Insert(4, colINGENIERO);

            DataGridViewTextBoxColumn colHH = new DataGridViewTextBoxColumn();
            colHH.Name = "HH";
            colHH.HeaderText = "HH";
            colHH.Width = 40;
            colHH.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPersonal.Columns.Insert(5, colHH);


            DataGridViewTextBoxColumn colIDE_CAPATAZ = new DataGridViewTextBoxColumn();
            colIDE_CAPATAZ.Name = "IDE_CAPATAZ";
            colIDE_CAPATAZ.HeaderText = "IDE_CAPATAZ";
            colIDE_CAPATAZ.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colIDE_CAPATAZ.Width = 50;
            dgvPersonal.Columns.Insert(6, colIDE_CAPATAZ);


            DataGridViewTextBoxColumn colING_CAMPO = new DataGridViewTextBoxColumn();
            colING_CAMPO.Name = "ING_CAMPO";
            colING_CAMPO.HeaderText = "ING_CAMPO";
            colING_CAMPO.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colING_CAMPO.Width = 50;
            dgvPersonal.Columns.Insert(7, colING_CAMPO);

            dgvPersonal.Columns["ING_CAMPO"].Visible = false;
            dgvPersonal.Columns["IDE_CAPATAZ"].Visible = false;

            if (dtResultado.Rows.Count > 0)
            {
                string SELECCION, IDE_OPERARIO, OBRERO, CAPATAZ, INGENIERO, HH, IDE_CAPATAZ, ING_CAMPO;
                string[] Xrow;
                for (int i = 0; i < dtResultado.Rows.Count; i++)
                {
                    SELECCION = dtResultado.Rows[i]["SELECCION"].ToString();// Convert.ToString(i + 1);
                    IDE_OPERARIO = dtResultado.Rows[i]["IDE_OPERARIO"].ToString();
                    OBRERO = dtResultado.Rows[i]["OBRERO"].ToString();
                    CAPATAZ = dtResultado.Rows[i]["CAPATAZ"].ToString();
                    HH = dtResultado.Rows[i]["HH"].ToString();
                    IDE_CAPATAZ = dtResultado.Rows[i]["IDE_CAPATAZ"].ToString();
                    INGENIERO = dtResultado.Rows[i]["INGENIERO"].ToString();
                    ING_CAMPO = dtResultado.Rows[i]["ING_CAMPO"].ToString();
                    Xrow = new string[] {
                       Convert.ToBoolean( SELECCION).ToString(),IDE_OPERARIO, OBRERO,CAPATAZ,INGENIERO, HH,IDE_CAPATAZ,ING_CAMPO
                        };
                    dgvPersonal.Rows.Add(Xrow);
                }
            }

            dgvPersonal.AllowUserToAddRows = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Desea eliminar el registros de los obreros seleccionado?", "Eliminación de cuadrilla y HH", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
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
                foreach (DataGridViewRow row in dgvPersonal.Rows)
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

                    BL_TAREO objTareo = new BL_TAREO();
                    DataTable dtResulTareo = new DataTable();

                    dtResulTareo = objTareo.SP_ELIMINAR_TAREO_CUADRILLA_VARIOS
                        (
                        Convert.ToInt32(frmControlTareoDigitacion.obj_Tareo_E.IDE_EMPRESA),
                        frmControlTareoDigitacion.obj_Tareo_E.IDE_CECOS,
                        frmControlTareoDigitacion.obj_Tareo_E.FEC_TAREO,
                        row.Cells["IDE_OPERARIO"].Value.ToString(),
                        row.Cells["IDE_CAPATAZ"].Value.ToString(),
                        row.Cells["ING_CAMPO"].Value.ToString()
                        );
                    if (dtResulTareo.Rows.Count > 0)
                    {
                        varCuadrilla++;
                    }
                    dgvPersonal.Rows.Remove(row);
                }
                Cuadrilla();
            }
        }
    }
}
