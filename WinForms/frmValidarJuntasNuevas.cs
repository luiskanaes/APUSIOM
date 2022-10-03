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
    public partial class frmValidarJuntasNuevas : Form
    {
        public frmValidarJuntasNuevas()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //dgMarcas.DataSource = null;

            //BL_MARCAS obj = new BL_MARCAS();
            //DataTable dtResultado = new DataTable();
            //dtResultado = obj.SP_CONSULTA_SOLDADURAS_XVALIDAR(txtUnit.Text, txtLine.Text, txtTrain.Text, dtpInicio.Text, dtpFin.Text);

            //if (dtResultado.Rows.Count > 0)
            //{
            //    dgMarcas.DataSource = dtResultado;
            //    dgMarcas.AutoResizeColumns();
            //    dgMarcas.Visible = true;

            //}
            //else
            //{
            //    MessageBox.Show("NO SE ENCONTRARON REGISTROS!!!", "", MessageBoxButtons.OK);
            //    dgMarcas.DataSource = null;
            //    return;
            //}
        }
    }
}
