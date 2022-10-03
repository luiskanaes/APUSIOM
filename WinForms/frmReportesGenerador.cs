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
    public partial class frmReportesGenerador : Form
    {
        public frmReportesGenerador()
        {
            InitializeComponent();
            cargarTipoJunta();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {

            BL_MARCAS obj = new BL_MARCAS();
            DataTable dtResultado = new DataTable();

            if (cboReporte.SelectedValue.ToString() == "PIP 35 (Base de datos completa)") { 
            dtResultado = obj.SP_CONSULTAR_REPORTES(cboReporte.SelectedValue.ToString());
               }
           if (cboReporte.SelectedValue.ToString() == "Reporte Bd completa nuevo orden.") { 
            dtResultado = obj.SP_CONSULTAR_REPORTES_CS(cboReporte.SelectedValue.ToString());
              }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "txt (*.txt)|*.txt";
            sfd.FileName = "REPORTE_" + (DateTime.Now.ToShortDateString()).Replace("/", "") + ".txt";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //ToCsV(dataGridView1, @"c:\export.xls");
                ToCSV(dtResultado, sfd.FileName); // Here dataGridview1 is your grid view name
            }
        }




        private void ToCSV(DataTable dtDataTable, string strFilePath)
        {
            StreamWriter sw = new StreamWriter(strFilePath, false);
            //headers
            for (int i = 0; i < dtDataTable.Columns.Count; i++)
            {
                sw.Write(dtDataTable.Columns[i]);
                if (i < dtDataTable.Columns.Count - 1)
                {
                    sw.Write(",");
                }
            }
            sw.Write(sw.NewLine);
            foreach (DataRow dr in dtDataTable.Rows)
            {
                for (int i = 0; i < dtDataTable.Columns.Count; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        string value = dr[i].ToString();
                        if (value.Contains(','))
                        {
                            value = String.Format("\"{0}\"", value);
                            sw.Write(value);
                        }
                        else
                        {
                            sw.Write(dr[i].ToString());
                        }
                    }
                    if (i < dtDataTable.Columns.Count - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }



        private void cargarTipoJunta()
        {
            cboReporte.DataSource = new BindingSource(TipoJunta, null);
            cboReporte.DisplayMember = "Value";
            cboReporte.ValueMember = "Value";
        }

        public static Dictionary<int, string> TipoJunta = new Dictionary<int, string>()
        {
            {1,"PIP 35 (Base de datos completa)"},
            {2,"Reporte Bd completa nuevo orden."}

        };
    }
}
