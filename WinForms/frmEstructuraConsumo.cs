using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessEntity;
using BusinessLogic;

namespace WinForms
{
    public partial class frmEstructuraConsumo : Form
    {
        public frmEstructuraConsumo()
        {
            InitializeComponent();
            ListarCapataz();
        }

        private void frmEstructuraConsumo_Load(object sender, EventArgs e)
        {
            
          
        }
        protected void ListarCapataz()
        {
            BL_ASIGNACION_TAREAS obj = new BL_ASIGNACION_TAREAS();
            DataTable dtResultado = new DataTable();
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn("ID_PERSONAL", typeof(String));
            dt.Columns.Add(dc);

            dc = new DataColumn("NOMBRES", typeof(String));
            dt.Columns.Add(dc);

            DataRow workRow;

            workRow = dt.NewRow();
            workRow[0] = "0";
            workRow[1] = "--- ACUMULADO ---";
            dt.Rows.Add(workRow);

            workRow = dt.NewRow();
            workRow[0] = "99";
            workRow[1] = "--- EJECUTADO DEL DIA ---";
            dt.Rows.Add(workRow);

            if (frmControlTareo.obj_Tareas_E.FLG_ESTADO  == 1)
            {
                dtResultado = obj.obtener_PersonalCategoria(
                    frmControlTareo.obj_Tareas_E.CENTRO_COSTO ,
                    frmControlTareo.obj_Tareas_E.IDE_EMPRESA ,
                    "RESPONSABLE CUADRILLA",
                    frmControlTareo.obj_Tareas_E.IDE_INGCAMPO ,
                    frmControlTareo.obj_Tareas_E.FECHA_TAREO);
                if (dtResultado.Rows.Count > 0)
                {
                    for (int i = 0; i < dtResultado.Rows.Count; i++)
                    {

                        workRow = dt.NewRow();
                        workRow[0] = dtResultado.Rows[i]["ID_PERSONAL"].ToString();
                        workRow[1] = dtResultado.Rows[i]["NOMBRES"].ToString();
                        dt.Rows.Add(workRow);
                    }
                }
            }
            else
            {
                dtResultado = obj.OBTENER_PERSONAL_RESPONSABLES_TAREO(
                     frmControlTareo.obj_Tareas_E.CENTRO_COSTO,
                     frmControlTareo.obj_Tareas_E.IDE_EMPRESA,
                     frmControlTareo.obj_Tareas_E.FECHA_TAREO, 
                    2,
                     frmControlTareo.obj_Tareas_E.IDE_INGCAMPO
                    );

                if (dtResultado.Rows.Count > 0)
                {
                    for (int i = 0; i < dtResultado.Rows.Count; i++)
                    {

                        workRow = dt.NewRow();
                        workRow[0] = dtResultado.Rows[i]["ID_PERSONAL"].ToString();
                        workRow[1] = dtResultado.Rows[i]["NOMBRES"].ToString();
                        dt.Rows.Add(workRow);
                    }
                }
            }
            cboCapataz.ValueMember = "ID_PERSONAL";
            cboCapataz.DisplayMember = "NOMBRES";
            cboCapataz.DataSource = dt;
            Listar();
        }
        protected void Listar()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dataGridView1.AllowUserToAddRows = true;

            BL_ASIGNACION_TAREAS xobj = new BL_ASIGNACION_TAREAS();
            DataTable dtResultado = new DataTable();
            DataTable dtCabecera = new DataTable();
            string capataz = string.Empty;
            string fecha = frmControlTareo.obj_Tareas_E.FECHA_TAREO;
            if (cboCapataz.SelectedIndex ==0)
            {
                capataz = string.Empty;
                fecha = string.Empty;
            }
            else if (cboCapataz.SelectedIndex == 1)
            {
                capataz = string.Empty;
                fecha = frmControlTareo.obj_Tareas_E.FECHA_TAREO;
            }
            else
            {
                capataz = cboCapataz.SelectedValue.ToString () ;
                fecha = frmControlTareo.obj_Tareas_E.FECHA_TAREO;
            }

            dtResultado = xobj.SEL_M_ESTRUCTURA_INSUMO_POR_FECHA(fecha, frmControlTareo.obj_Tareas_E.CENTRO_COSTO, capataz);
          
            if (dtResultado.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                dataGridView1.DataSource = null;
                dataGridView1.Columns.Clear();
                dataGridView1.ColumnCount = 1;
                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


                DataGridViewTextBoxColumn colPieza = new DataGridViewTextBoxColumn();
                colPieza.Name = "DESCRIPCION_PIEZA";
                colPieza.HeaderText = "Descripcion Pieza";
                colPieza.Width = 80;
                //colProgramado.DefaultCellStyle.BackColor = Color.FromArgb(255, 248, 110);
                //colProgramado.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns.Insert(0, colPieza);

                DataGridViewTextBoxColumn colMarca =new DataGridViewTextBoxColumn();
                colMarca.Name = "DSC_MARCA";
                colMarca.HeaderText = "Marca";
                colMarca.Width = 120;
                dataGridView1.Columns.Insert(1, colMarca);


                DataGridViewTextBoxColumn colTotal= new DataGridViewTextBoxColumn();
                colTotal.Name = "NUM_CANTIDAD";
                colTotal.HeaderText = "Global";
                colTotal.Width = 75;
                colTotal.DefaultCellStyle.BackColor = Color.FromArgb(255, 248, 110);
                colTotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns.Insert(2, colTotal);

                

                DataGridViewTextBoxColumn colT1= new DataGridViewTextBoxColumn();
                colT1.Name = "T1";
                colT1.HeaderText = "Transporte";
                colT1.Width = 80;
                colT1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns.Insert(3, colT1);

                DataGridViewTextBoxColumn colT2 = new DataGridViewTextBoxColumn();
                colT2.Name = "T2";
                colT2.HeaderText = "Preparación";
                colT2.Width = 80;
                colT2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns.Insert(4, colT2);

                DataGridViewTextBoxColumn colT3 = new DataGridViewTextBoxColumn();
                colT3.Name = "T3";
                colT3.HeaderText = "Habilitado";
                colT3.Width = 80;
                colT3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns.Insert(5, colT3);

                DataGridViewTextBoxColumn colT4 = new DataGridViewTextBoxColumn();
                colT4.Name = "T4";
                colT4.HeaderText = "Montaje";
                colT4.Width = 80;
                colT4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns.Insert(6, colT4);

                DataGridViewTextBoxColumn colT5 = new DataGridViewTextBoxColumn();
                colT5.Name = "T5";
                colT5.HeaderText = "Alineamiento";
                colT5.Width = 80;
                colT5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns.Insert(7, colT5);

                DataGridViewTextBoxColumn colT6 = new DataGridViewTextBoxColumn();
                colT6.Name = "T6";
                colT6.HeaderText = "Touch Up";
                colT6.Width = 80;
                colT6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns.Insert(8, colT6);


                DataGridViewTextBoxColumn colT7 = new DataGridViewTextBoxColumn();
                colT7.Name = "T7";
                colT7.HeaderText = "QA/QC ";
                colT7.Width = 80;
                colT7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns.Insert(9, colT7);


                for (int i = 0; i < dtResultado.Rows.Count; i++)
                {
                    int renglon = dataGridView1.Rows.Add();
      
                    dataGridView1.Rows[renglon].Cells["DESCRIPCION_PIEZA"].Value = dtResultado.Rows[i]["DESCRIPCION_PIEZA"].ToString();
                    dataGridView1.Rows[renglon].Cells["DSC_MARCA"].Value = dtResultado.Rows[i]["DSC_MARCA"].ToString();
                    dataGridView1.Rows[renglon].Cells["NUM_CANTIDAD"].Value = dtResultado.Rows[i]["NUM_CANTIDAD"].ToString();
                    dataGridView1.Rows[renglon].Cells["T1"].Value = dtResultado.Rows[i]["T1"].ToString();
                    dataGridView1.Rows[renglon].Cells["T2"].Value = dtResultado.Rows[i]["T2"].ToString();
                    dataGridView1.Rows[renglon].Cells["T3"].Value = dtResultado.Rows[i]["T3"].ToString();
                    dataGridView1.Rows[renglon].Cells["T4"].Value = dtResultado.Rows[i]["T4"].ToString();
                    dataGridView1.Rows[renglon].Cells["T5"].Value = dtResultado.Rows[i]["T5"].ToString();
                    dataGridView1.Rows[renglon].Cells["T6"].Value = dtResultado.Rows[i]["T6"].ToString();
                    dataGridView1.Rows[renglon].Cells["T7"].Value = dtResultado.Rows[i]["T7"].ToString();


                }
                
            }


        }

        private void cboCapataz_SelectedIndexChanged(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "export.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //ToCsV(dataGridView1, @"c:\export.xls");
                ToCsV(dataGridView1, sfd.FileName); // Here dataGridview1 is your grid view name
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
            for (int i = 0; i < dGV.RowCount - 1; i++)
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
