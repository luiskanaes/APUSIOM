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
    public partial class frmIndicadores : Form
    {
        public frmIndicadores()
        {
            InitializeComponent();
            listar();
        }

        private void frmIndicadores_Load(object sender, EventArgs e)
        {

        }
        protected void listar()
        {

            BL_PERSONAL objPersona = new BL_PERSONAL();

            Estructura();


            BL_TAREO obj = new BL_TAREO();
            DataTable dtResul = new DataTable();
            try
            {
                dtResul = obj.Indicadores_Tareo(Convert.ToInt32(frmTareoDiario.obj_asignacion_E.IDE_EMPRESA), frmTareoDiario.obj_asignacion_E.CENTRO_COSTO, frmTareoDiario.obj_asignacion_E.FECHA_TAREO);

                if (dtResul.Rows.Count > 0)
                {
                    string ID, CANTIDAD, DESCRIPCION;
                    string[] Xrow;
                    for (int i = 0; i < dtResul.Rows.Count; i++)
                    {
                        ID = dtResul.Rows[i]["ID"].ToString();
                        CANTIDAD = dtResul.Rows[i]["CANTIDAD"].ToString();
                        DESCRIPCION = dtResul.Rows[i]["DESCRIPCION"].ToString();

                        Xrow = new string[] { ID, CANTIDAD, DESCRIPCION };
                        dataGridView1.Rows.Add(Xrow);
                    }


                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (Convert.ToInt32(row.Cells["ID"].Value) % 2 == 0)
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
        protected void Estructura()
        {
            dataGridView1.Refresh();
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            DataGridViewTextBoxColumn colID = new DataGridViewTextBoxColumn();
            colID.Name = "ID";
            colID.HeaderText = "N°";
            colID.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Insert(0, colID);

            DataGridViewTextBoxColumn colCANTIDAD = new DataGridViewTextBoxColumn();
            colCANTIDAD.Name = "CANTIDAD";
            colCANTIDAD.HeaderText = "Cantidad";
            colCANTIDAD.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Insert(1, colCANTIDAD);


            DataGridViewTextBoxColumn colDESCRIPCION = new DataGridViewTextBoxColumn();
            colDESCRIPCION.Name = "DESCRIPCION";
            colDESCRIPCION.HeaderText = "Descripcion";
            dataGridView1.Columns.Insert(2, colDESCRIPCION);

            

            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
    }
}
