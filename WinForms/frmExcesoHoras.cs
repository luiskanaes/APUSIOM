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
    public partial class frmExcesoHoras : Form
    {
        public frmExcesoHoras()
        {
            InitializeComponent();
            listarProgramacion();
        }
        protected void listarProgramacion()
        {

            BL_PERSONAL objPersona = new BL_PERSONAL();

            Estructura();


            BL_TAREO obj = new BL_TAREO();
            DataTable dtResul = new DataTable();
            try
            {
                dtResul = obj.ExcesoHrs_Personal(Convert.ToInt32(frmTareoDiario.obj_asignacion_E.IDE_EMPRESA), frmTareoDiario.obj_asignacion_E.CENTRO_COSTO, frmTareoDiario.obj_asignacion_E.FECHA_TAREO);

                if (dtResul.Rows.Count > 0)
                {
                    string Row, DNI, OPERARIO, HORA_TOTAL, HORA, CTA_COSTO, ACTIVIDAD, CAPATAZ, GPO;
                    string[] Xrow;
                    for (int i = 0; i < dtResul.Rows.Count; i++)
                    {
                        Row = dtResul.Rows[i]["Row"].ToString();
                        DNI = dtResul.Rows[i]["DNI"].ToString();
                        OPERARIO = dtResul.Rows[i]["OPERARIO"].ToString();
                        HORA_TOTAL = dtResul.Rows[i]["HORA_TOTAL"].ToString();
                        HORA = dtResul.Rows[i]["HORA"].ToString();
                        CTA_COSTO = dtResul.Rows[i]["CTA_COSTO"].ToString();
                        ACTIVIDAD = dtResul.Rows[i]["ACTIVIDAD"].ToString();
                        CAPATAZ = dtResul.Rows[i]["CAPATAZ"].ToString();
                        GPO = dtResul.Rows[i]["GPO"].ToString();
                        Xrow = new string[] { Row, DNI, OPERARIO, HORA_TOTAL, HORA, CTA_COSTO, ACTIVIDAD, CAPATAZ, GPO };
                        dataGridView1.Rows.Add(Xrow);
                    }


                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (Convert.ToInt32(row.Cells["GPO"].Value) % 2 == 0)
                        {

                            row.DefaultCellStyle.BackColor = Color.FromArgb(218, 247, 166);
                        }
                        else
                        {
                            row.DefaultCellStyle.BackColor = Color.White;
                        }
                    }
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
                else
                {
                    dataGridView1.Rows.Clear();
                    dataGridView1.Refresh();
                    dataGridView1.DataSource = null;
                    dataGridView1.Columns.Clear();
                }
            }

            catch (Exception ex)
            {

            }
        }
        private void frmExcesoHoras_Load(object sender, EventArgs e)
        {

        }
        protected void Estructura()
        {
            dataGridView1.Refresh();
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            DataGridViewTextBoxColumn colRow = new DataGridViewTextBoxColumn();
            colRow.Name = "Row";
            colRow.HeaderText = "N°";
            colRow.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Insert(0, colRow);

            DataGridViewTextBoxColumn colDNI = new DataGridViewTextBoxColumn();
            colDNI.Name = "DNI";
            colDNI.HeaderText = "Dni";
            colDNI.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Insert(1, colDNI);


            DataGridViewTextBoxColumn colOPERARIO = new DataGridViewTextBoxColumn();
            colOPERARIO.Name = "OPERARIO";
            colOPERARIO.HeaderText = "Operario";
            dataGridView1.Columns.Insert(2, colOPERARIO);

            DataGridViewTextBoxColumn colHORA_TOTAL = new DataGridViewTextBoxColumn();
            colHORA_TOTAL.Name = "HORA_TOTAL";
            colHORA_TOTAL.HeaderText = "Total Hrs";
            colHORA_TOTAL.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Insert(3, colHORA_TOTAL);

            DataGridViewTextBoxColumn colHORA = new DataGridViewTextBoxColumn();
            colHORA.Name = "Hora";
            colHORA.HeaderText = "Hora";
            colHORA.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Insert(4, colHORA);

            DataGridViewTextBoxColumn colCTA_COSTO = new DataGridViewTextBoxColumn();
            colCTA_COSTO.Name = "CTA_COSTO";
            colCTA_COSTO.HeaderText = "Cta Costo";
            colCTA_COSTO.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Insert(5, colCTA_COSTO);

            DataGridViewTextBoxColumn colACTIVIDAD = new DataGridViewTextBoxColumn();
            colACTIVIDAD.Name = "ACTIVIDAD";
            colACTIVIDAD.HeaderText = "Actividad";
            dataGridView1.Columns.Insert(6, colACTIVIDAD);

            DataGridViewTextBoxColumn colCAPATAZ = new DataGridViewTextBoxColumn();
            colCAPATAZ.Name = "CAPATAZ";
            colCAPATAZ.HeaderText = "Capataz";
            dataGridView1.Columns.Insert(7, colCAPATAZ);

            DataGridViewTextBoxColumn colID = new DataGridViewTextBoxColumn();
            colID.Name = "GPO";
            colID.HeaderText = "GPO";
            colID.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Insert(8, colID);

           

            dataGridView1.Columns["GPO"].Visible = false;

            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
    }
}
