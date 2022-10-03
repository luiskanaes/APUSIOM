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
    public partial class frmReporteFormatoTRPruebasHidraulicas : Form
    {
        public frmReporteFormatoTRPruebasHidraulicas()
        {
            InitializeComponent();
            cargaFiltros();
        }
        private void cargaFiltros()
        {

            BL_MARCAS obj = new BL_MARCAS();
            DataTable dtResultado = new DataTable();
            dtResultado = obj.SP_CONSULTAR_FILTROS("");//frmLogin.obj_user_E.IDE_USUARIO);
            if (dtResultado.Rows.Count > 0)
            {
                cboFiltro.ValueMember = "ID";
                cboFiltro.DisplayMember = "DESCRIPCION";
                cboFiltro.DataSource = dtResultado;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BL_MARCAS obj = new BL_MARCAS();
            DataTable dtResultado = new DataTable();
            dtResultado = obj.SP_CONSULTAR_PAQUETES_PRUEBA_FORMATO_TR("", txtUnit.Text, txtLine.Text, txtTrain.Text, txtServicio.Text, txtPaquete.Text, cboFiltro.SelectedValue.ToString(), txtFiltro.Text);

            if (dtResultado.Rows.Count > 0)
            {
                dgMarcas.DataSource = dtResultado;
                dgMarcas.AutoResizeColumns();
                //dgMarcas.Columns["JUNTA"].Frozen = true;
                //dgMarcas.Columns["JUNTA"].Width = 160;
                dgMarcas.Visible = true;

                dgMarcas.Columns[0].ReadOnly = true;
                //dgMarcas.Columns[1].ReadOnly = true;
                dgMarcas.Columns[23].ReadOnly = true;

                dgMarcas.Columns[0].DefaultCellStyle.Font = new System.Drawing.Font(this.Font, FontStyle.Bold);
                //dgMarcas.Columns[1].ReadOnly = true;
                dgMarcas.Columns[23].DefaultCellStyle.Font = new System.Drawing.Font(this.Font, FontStyle.Bold);

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
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "Reporte_Paquete_Pruebas" + (DateTime.Now.ToShortDateString()).Replace("/", "") + ".xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //ToCsV(dataGridView1, @"c:\export.xls");
                ToCsV(dgMarcas, sfd.FileName); // Here dataGridview1 is your grid view name
            }
        }


        private void ToCsV(DataGridView dGV, string filename)
        {
            string stOutput = "";
            // Export titles:
            string sHeaders = "";

            for (int j = 0; j < dGV.Columns.Count; j++)
                sHeaders = sHeaders.ToString() + Convert.ToString(dGV.Columns[j].HeaderText) + "\t";
            stOutput += sHeaders + "\r\n";
            // Export data.
            for (int i = 0; i < dGV.RowCount; i++)
            {
                string stLine = "";
                for (int j = 0; j < dGV.Rows[i].Cells.Count; j++)
                    stLine = stLine.ToString() + Convert.ToString(dGV.Rows[i].Cells[j].Value) + "\t";
                stOutput += stLine + "\r\n";
            }
            Encoding utf16 = Encoding.GetEncoding(1254);
            byte[] output = utf16.GetBytes(stOutput);
            FileStream fs = new FileStream(filename, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(output, 0, output.Length); //write the encoded file
            bw.Flush();
            bw.Close();
            fs.Close();
        }
    }
}
