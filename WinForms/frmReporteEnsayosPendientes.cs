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
using System.Text.RegularExpressions;

namespace WinForms
{
    public partial class frmReporteEnsayosPendientes : Form
    {
        public frmReporteEnsayosPendientes()
        {
            InitializeComponent();

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {

        }

        private void dgMarcas_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

        }

        private void dgMarcas_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {

            BL_MARCAS obj = new BL_MARCAS();
            DataTable dtResultado = new DataTable();
            dtResultado = obj.SP_CONSULTAR_DATOS_COTIZACION(txtCodigoSiom.Text, txtGrupo.Text, txtDescripcion.Text, txtUnidadMedida.Text);

            if (dtResultado.Rows.Count > 0)
            {
                dgMarcas.DataSource = dtResultado;
                dgMarcas.AutoResizeColumns();
                /* dgMarcas.Columns["JUNTA"].Frozen = true;
                 dgMarcas.Columns["JUNTA"].Width= 155;
                 dgMarcas.Columns["JUNTA"].ReadOnly = true;
                 dgMarcas.Visible = true;*/

                dgMarcas.Columns[(dtResultado.Columns.Count) - 1].ReadOnly = true;
                dgMarcas.Columns[(dtResultado.Columns.Count) - 1].DefaultCellStyle.BackColor = Color.Gray;

                //dgMarcas.Columns[85].ReadOnly = true;
                //dgMarcas.Columns[86].ReadOnly = true;
                //dgMarcas.Columns[87].ReadOnly = true;
                //dgMarcas.Columns[88].ReadOnly = true;
                //dgMarcas.Columns[89].ReadOnly = true;
                //dgMarcas.Columns[90].ReadOnly = true;
                //dgMarcas.Columns[91].ReadOnly = true;
                //dgMarcas.Columns[92].ReadOnly = true;
                //dgMarcas.Columns[93].ReadOnly = true;
                //dgMarcas.Columns[94].ReadOnly = true;

                //dgMarcas.Columns[85].DefaultCellStyle.BackColor = Color.Gray;
                //dgMarcas.Columns[86].DefaultCellStyle.BackColor = Color.Gray;
                //dgMarcas.Columns[87].DefaultCellStyle.BackColor = Color.Gray;
                //dgMarcas.Columns[88].DefaultCellStyle.BackColor = Color.Gray;
                //dgMarcas.Columns[89].DefaultCellStyle.BackColor = Color.Gray;
                //dgMarcas.Columns[90].DefaultCellStyle.BackColor = Color.Gray;
                //dgMarcas.Columns[91].DefaultCellStyle.BackColor = Color.Gray;
                //dgMarcas.Columns[92].DefaultCellStyle.BackColor = Color.Gray;
                //dgMarcas.Columns[93].DefaultCellStyle.BackColor = Color.Gray;
                //dgMarcas.Columns[94].DefaultCellStyle.BackColor = Color.Gray;

                lblTotal.Text = "TOTAL: " + dtResultado.Rows.Count;

            }
            else
            {
                MessageBox.Show("NO SE ENCONTRARON REGISTROS!!!", "", MessageBoxButtons.OK);
                lblTotal.Text = "TOTAL: ";
                dgMarcas.DataSource = null;
                dgMarcas.Refresh();
                return;
            }

            DataTable dtResultado_editable = new DataTable();
            dtResultado_editable = obj.SP_CONSULTAR_COLUMNAS_EDITABLES("", Convert.ToString(frmLogin.obj_perfil_E.IdPerfil));

            if (dgMarcas.Rows.Count != 0 && dgMarcas.Rows != null)
            {

                foreach (DataRow row in dtResultado_editable.Rows)
                {
                    dgMarcas.Columns[(row["CABECERA"].ToString())].ReadOnly = true;

                    //dgMarcas.Columns[(row["CABECERA"].ToString())].DefaultCellStyle.ForeColor = Color.White;

                    //dgMarcas.Columns[(row["CABECERA"].ToString())].DefaultCellStyle.BackColor = Color.Gray;

                    dgMarcas.Columns[(row["CABECERA"].ToString())].DefaultCellStyle.Font = new System.Drawing.Font(this.Font, FontStyle.Bold);

                }

            }

        }
    }
}
