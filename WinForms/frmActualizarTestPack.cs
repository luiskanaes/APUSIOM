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
    public partial class frmActualizarTestPack : Form
    {
        public frmActualizarTestPack()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BL_MARCAS obj = new BL_MARCAS();
            DataTable dtResultado = new DataTable();
            dtResultado = obj.SP_CONSULTAR_TESTPACK("", txtUnit.Text, txtServicio.Text, txtLine.Text, txtTrain.Text, txtTestPack.Text);

            if (dtResultado.Rows.Count > 0)
            {
                dgMarcas.DataSource = dtResultado;
                dgMarcas.AutoResizeColumns(); 
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Esta seguro de guardar los cambios?", "Mensaje Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (respuesta == DialogResult.Yes)
            {

                BL_MARCAS obj = new BL_MARCAS();
                DataTable dtResultado = new DataTable();
                dtResultado = obj.SP_ACTUALIZAR_TESTPACK("", txtUnit.Text, txtServicio.Text, txtLine.Text, txtTrain.Text, txtTestPack.Text, txtEstado.Text, txtFecha.Value.Date.ToString("dd/MM/yyyy"));

                if (dtResultado.Rows.Count > 0)
                {
                    dgMarcas.DataSource = dtResultado;
                    dgMarcas.AutoResizeColumns();

                    DataTable dtResultado2 = new DataTable();
                    dtResultado2 = obj.SP_CONSULTAR_TESTPACK("", txtUnit.Text, txtServicio.Text, txtLine.Text, txtTrain.Text, txtTestPack.Text);

                    if (dtResultado2.Rows.Count > 0)
                    {
                        dgMarcas.DataSource = dtResultado2;
                        dgMarcas.AutoResizeColumns();
                    }
                }

            }

                
        }

        private void frmActualizarTestPack_Load(object sender, EventArgs e)
        {

        }
    }
}
