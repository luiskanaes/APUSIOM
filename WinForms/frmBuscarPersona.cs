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
    public partial class frmBuscarPersona : Form
    {
        DataTable dtResulDisponible;
        DataView dv;
        public frmBuscarPersona()
        {
            InitializeComponent();
            txtBuscar.Focus();
            Listar();
        }

        private void frmBuscarPersona_Load(object sender, EventArgs e)
        {

        }
        protected void Listar()
        {
            
            dataGridView1.AllowUserToAddRows = true;

            Estructura();
            BL_PERSONAL xobj = new BL_PERSONAL();
            DataTable dtResultado = new DataTable();
            dtResultado = xobj.SP_OBTENER_PERSONAL( frmControlTareoDigitacion.obj_Tareas_E.CENTRO_COSTO);

            dtResulDisponible = xobj.SP_OBTENER_PERSONAL(frmControlTareoDigitacion.obj_Tareas_E.CENTRO_COSTO);
            dv = dtResulDisponible.DefaultView;

            if (dtResultado.Rows.Count > 0)
            {
                string Row, NOMBRES_COMPLETO, CATEGORIA, NOMBRE_CAPATAZ, NOMBRE_ING;
                string[] Xrow;

                for (int i = 0; i < dtResultado.Rows.Count; i++)
                {
                    Row = dtResultado.Rows[i]["Row"].ToString();
                    NOMBRES_COMPLETO = dtResultado.Rows[i]["NOMBRES_COMPLETO"].ToString();
                    CATEGORIA = dtResultado.Rows[i]["CATEGORIA"].ToString();
                    NOMBRE_CAPATAZ = dtResultado.Rows[i]["NOMBRE_CAPATAZ"].ToString();
                    NOMBRE_ING = dtResultado.Rows[i]["NOMBRE_ING"].ToString();
                    Xrow = new string[] { Row, NOMBRES_COMPLETO, CATEGORIA, NOMBRE_CAPATAZ, NOMBRE_ING };
                    dataGridView1.Rows.Add(Xrow);

                }
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            dataGridView1.AllowUserToAddRows = false;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            GrillaFiltro("1");
        }
        protected void Estructura()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();

            dataGridView1.ColumnCount = 5;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[0].Name = "Nro";
            dataGridView1.Columns[1].Name = "Obreo";
            dataGridView1.Columns[2].Name = "Categoria";
            dataGridView1.Columns[3].Name = "Responsable de Cuadrilla";
            dataGridView1.Columns[4].Name = "Ingeniero de Campo";

           
        }
        protected void GrillaFiltro(string tipo)
        {
            DataTable dt = dtResulDisponible as DataTable;
            DataView dv = dt.DefaultView;

            if (tipo == "1")
            {
                dv.RowFilter = "NOMBRES_COMPLETO LIKE '%" + txtBuscar.Text + "%'";
            }
            
            Estructura();

            string Row, NOMBRES_COMPLETO, CATEGORIA, NOMBRE_CAPATAZ, NOMBRE_ING;
            string[] Xrow;
            for (int i = 0; i < dv.Count; i++)
            {
                Row = dv[i]["Row"].ToString();
                NOMBRES_COMPLETO = dv[i]["NOMBRES_COMPLETO"].ToString();
                CATEGORIA = dv[i]["CATEGORIA"].ToString();
                NOMBRE_CAPATAZ = dv[i]["NOMBRE_CAPATAZ"].ToString();
                NOMBRE_ING =  dv[i]["NOMBRE_ING"].ToString();
                Xrow = new string[] { Row, NOMBRES_COMPLETO, CATEGORIA, NOMBRE_CAPATAZ , NOMBRE_ING };
                dataGridView1.Rows.Add(Xrow);
            }

        }
    }
}
