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
    public partial class frmCronograma : Form
    {
        DataTable dtResulDisponible;
        DataView dv;

        string codigoActividades = string.Empty;
        public string varfCodActividad; //variable para pasar informacion
        public string varfActividad; //variable para pasar informacion
        public string varfDesActividad;

        public string varfTareo;
        public string varfCodTareo;
        public string varfDesTareo;

        public string varfCodFrente;
        public string varfFrente;
        public string varfDesFrente;
        public string varfCtaCosto;
        public string varfUnidad;
        public string varfCODIGO_TAREA;
        public string varfPK_TAREA;
        public frmCronograma()
        {
            InitializeComponent();
            listarProgramacion();
        }
    
        private void frmCronograma_Load(object sender, EventArgs e)
        {

        }
        protected void Estructura()
        {
            dataGridView1.Refresh();
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.AllowUserToAddRows = true ;

            BL_DISCIPLINAS objDisciplina = new BL_DISCIPLINAS();
            DataTable dtDisciplina = new DataTable();

            //CCS
            //dtDisciplina = objDisciplina.uspSEL_TIPO_TAREO_POR_CENTRO_COSTO(frmControlTareoDigitacion.obj_Tareo_E.IDE_CECOS);

            DataGridViewTextBoxColumn colIDE_ACTIVIDAD = new DataGridViewTextBoxColumn();
            colIDE_ACTIVIDAD.Name = "IDE_ACTIVIDAD";
            colIDE_ACTIVIDAD.HeaderText = "Actividad";
            colIDE_ACTIVIDAD.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Insert(0, colIDE_ACTIVIDAD);

            DataGridViewTextBoxColumn colDES_ACTIVIDAD = new DataGridViewTextBoxColumn();
            colDES_ACTIVIDAD.Name = "DES_ACTIVIDAD";
            colDES_ACTIVIDAD.HeaderText = "Descripcion Actividad";
            dataGridView1.Columns.Insert(1, colDES_ACTIVIDAD);


            DataGridViewTextBoxColumn colCTA_COSTO = new DataGridViewTextBoxColumn();
            colCTA_COSTO.Name = "CTA_COSTO";
            colCTA_COSTO.HeaderText = "Cuenta Costo";
            colCTA_COSTO.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Insert(2, colCTA_COSTO);

            DataGridViewTextBoxColumn colID_TAREA = new DataGridViewTextBoxColumn();
            colID_TAREA.Name = "ID_TAREA";
            colID_TAREA.HeaderText = "Tarea";

            dataGridView1.Columns.Insert(3, colID_TAREA);

            DataGridViewTextBoxColumn colDES_TAREA = new DataGridViewTextBoxColumn();
            colDES_TAREA.Name = "DES_TAREA";
            colDES_TAREA.HeaderText = "Descripcion Tarea";
            dataGridView1.Columns.Insert(4, colDES_TAREA);

            DataGridViewTextBoxColumn colDES_UNIDAD = new DataGridViewTextBoxColumn();
            colDES_UNIDAD.Name = "DES_UNIDAD";
            colDES_UNIDAD.HeaderText = "Unidad";
            colDES_UNIDAD.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Insert(5, colDES_UNIDAD);

            DataGridViewTextBoxColumn colID_FRENTE = new DataGridViewTextBoxColumn();
            colID_FRENTE.Name = "ID_FRENTE";
            colID_FRENTE.HeaderText = "Frente";
            colID_FRENTE.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Insert(6, colID_FRENTE);

            DataGridViewTextBoxColumn colDES_FRENTE = new DataGridViewTextBoxColumn();
            colDES_FRENTE.Name = "DES_FRENTE";
            colDES_FRENTE.HeaderText = "Descripcion Frente";
            dataGridView1.Columns.Insert(7, colDES_FRENTE);

            DataGridViewTextBoxColumn colGrupo = new DataGridViewTextBoxColumn();
            colGrupo.Name = "Grupo";
            colGrupo.HeaderText = "Grupo";
            dataGridView1.Columns.Insert(8, colGrupo);


            DataGridViewTextBoxColumn colCODIGO_TAREA = new DataGridViewTextBoxColumn();
            colCODIGO_TAREA.Name = "CODIGO_TAREA";
            colCODIGO_TAREA.HeaderText = "CODIGO_TAREA";
            colCODIGO_TAREA.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Insert(9, colCODIGO_TAREA);

            DataGridViewTextBoxColumn colPK_TAREA = new DataGridViewTextBoxColumn();
            colPK_TAREA.Name = "PK_TAREA";
            colPK_TAREA.HeaderText = "PK_TAREA";
            colPK_TAREA.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns.Insert(10, colPK_TAREA);


            dataGridView1.Columns["Grupo"].Visible = false;
            dataGridView1.Columns["CODIGO_TAREA"].Visible = false;
            dataGridView1.Columns["PK_TAREA"].Visible = false;
            dataGridView1.Columns["DES_ACTIVIDAD"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns["DES_TAREA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView1.AllowUserToAddRows = false;
        }
        protected void listarProgramacion()
        {

            BL_PERSONAL objPersona = new BL_PERSONAL();

            Estructura();


            BL_CABECERA obj = new BL_CABECERA();
            DataTable dtResul = new DataTable();
            try
            {
                //ccs
                dtResul = obj.ListarProgramacion_Disciplina(frmControlTareoDigitacion.obj_Tareo_E.IDE_CECOS, Convert.ToInt32(frmControlTareoDigitacion.obj_Tareo_E.IDE_EMPRESA), Convert.ToInt32(frmControlTareoDigitacion.obj_Tareo_E.TIPO));
          
                dtResulDisponible = dtResul;
                dv = dtResulDisponible.DefaultView;
                //if (dtResul.Rows.Count > 0)
                //{
                   

                //    string IDE_ACTIVIDAD, DES_ACTIVIDAD, CTA_COSTO, ID_TAREA, DES_TAREA, DES_UNIDAD, ID_FRENTE, DES_FRENTE, ID, CODIGO_TAREA, PK_TAREA;
                //    string[] Xrow;
                //    for (int i = 0; i < dtResul.Rows.Count; i++)
                //    {
                //        IDE_ACTIVIDAD = dtResul.Rows[i]["IDE_ACTIVIDAD"].ToString();
                //        DES_ACTIVIDAD = dtResul.Rows[i]["DES_ACTIVIDAD"].ToString();
                //        CTA_COSTO = dtResul.Rows[i]["CTA_COSTO"].ToString();
                //        ID_TAREA = dtResul.Rows[i]["ID_TAREA"].ToString();
                //        DES_TAREA = dtResul.Rows[i]["DES_TAREA"].ToString();
                //        DES_UNIDAD = dtResul.Rows[i]["DES_UNIDAD"].ToString();
                //        ID_FRENTE = dtResul.Rows[i]["ID_FRENTE"].ToString();
                //        DES_FRENTE = dtResul.Rows[i]["DES_FRENTE"].ToString();
                //        ID = dtResul.Rows[i]["ID"].ToString();
                //        CODIGO_TAREA = dtResul.Rows[i]["CODIGO_TAREA"].ToString();
                //        PK_TAREA = dtResul.Rows[i]["PK_TAREA"].ToString();
                //        Xrow = new string[] { IDE_ACTIVIDAD, DES_ACTIVIDAD, CTA_COSTO, ID_TAREA, DES_TAREA, DES_UNIDAD, ID_FRENTE, DES_FRENTE, ID, CODIGO_TAREA, PK_TAREA };
                //        dataGridView1.Rows.Add(Xrow);
                //    }


                //    foreach (DataGridViewRow row in dataGridView1.Rows)
                //    {
                //        if (Convert.ToInt32(row.Cells["Grupo"].Value) % 2 == 0)
                //        {

                //            row.DefaultCellStyle.BackColor = Color.FromArgb(218, 247, 166);
                //        }
                //        else
                //        {
                //            row.DefaultCellStyle.BackColor = Color.White;
                //        }
                //    }
                //    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                //}
                //else
                //{
                //    dataGridView1.Rows.Clear();
                //    dataGridView1.Refresh();
                //    dataGridView1.DataSource = null;
                //    dataGridView1.Columns.Clear();
                //}
            }

            catch (Exception ex)
            {

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                string IDE_ACTIVIDAD = dataGridView1.Rows[e.RowIndex].Cells["IDE_ACTIVIDAD"].Value.ToString();
                string DES_ACTIVIDAD = dataGridView1.Rows[e.RowIndex].Cells["DES_ACTIVIDAD"].Value.ToString();

                string ID_TAREA = dataGridView1.Rows[e.RowIndex].Cells["ID_TAREA"].Value.ToString();
                string DES_TAREA = dataGridView1.Rows[e.RowIndex].Cells["DES_TAREA"].Value.ToString();

                varfDesTareo = ID_TAREA + " - " + DES_TAREA;
                varfTareo = dataGridView1.Rows[e.RowIndex].Cells["DES_TAREA"].Value.ToString();
                varfCodTareo = dataGridView1.Rows[e.RowIndex].Cells["ID_TAREA"].Value.ToString();

                varfCodActividad = dataGridView1.Rows[e.RowIndex].Cells["IDE_ACTIVIDAD"].Value.ToString();
                varfDesActividad = IDE_ACTIVIDAD + " - " + DES_ACTIVIDAD;
                varfActividad = dataGridView1.Rows[e.RowIndex].Cells["DES_ACTIVIDAD"].Value.ToString();

                varfCodFrente = dataGridView1.Rows[e.RowIndex].Cells["ID_FRENTE"].Value.ToString();
                varfFrente = dataGridView1.Rows[e.RowIndex].Cells["DES_FRENTE"].Value.ToString();

                varfCtaCosto = dataGridView1.Rows[e.RowIndex].Cells["CTA_COSTO"].Value.ToString();
                varfUnidad = dataGridView1.Rows[e.RowIndex].Cells["DES_UNIDAD"].Value.ToString();

                varfDesFrente = dataGridView1.Rows[e.RowIndex].Cells["DES_FRENTE"].Value.ToString();

                varfCODIGO_TAREA = dataGridView1.Rows[e.RowIndex].Cells["CODIGO_TAREA"].Value.ToString();

                varfPK_TAREA = dataGridView1.Rows[e.RowIndex].Cells["PK_TAREA"].Value.ToString();

                this.Hide();
            }
            catch(Exception ex)
            {

            }
           
        
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            if(txtCodigo.Text.Length >= 2)
            {
                GrillaFiltro("1");
            }
           
        }
        protected void GrillaFiltro(string tipo)
        {
            DataTable dt = dtResulDisponible as DataTable;
            DataView dv = dt.DefaultView;

            if (tipo == "1")
            {
                dv.RowFilter = "IDE_ACTIVIDAD LIKE '%" + txtCodigo.Text + "%'";
            }
            else if (tipo == "2")
            {
                dv.RowFilter = "DES_ACTIVIDAD LIKE '%" + txtActividad.Text + "%'";
            }
            else if (tipo == "3")
            {
                dv.RowFilter = "DES_TAREA LIKE '%" + txtTarea.Text + "%'";
            }
            else if (tipo == "4")
            {
                dv.RowFilter = "ID_TAREA LIKE '%" + txtCodigoTarea.Text + "%'";
            }
            Estructura();

            string IDE_ACTIVIDAD, DES_ACTIVIDAD, ID_TAREA, DES_TAREA, DES_UNIDAD, CTA_COSTO, ID_FRENTE, DES_FRENTE, ID, CODIGO_TAREA, PK_TAREA;
            string[] Xrow;
            for (int i = 0; i < dv.Count; i++)
            {

                IDE_ACTIVIDAD = dv[i]["IDE_ACTIVIDAD"].ToString();
                DES_ACTIVIDAD = dv[i]["DES_ACTIVIDAD"].ToString();
                CTA_COSTO = dv[i]["CTA_COSTO"].ToString();
                ID_TAREA = dv[i]["ID_TAREA"].ToString();
                DES_TAREA = dv[i]["DES_TAREA"].ToString();
                DES_UNIDAD = dv[i]["DES_UNIDAD"].ToString();
                ID_FRENTE = dv[i]["ID_FRENTE"].ToString();
                DES_FRENTE = dv[i]["DES_FRENTE"].ToString();
                ID = dv[i]["ID"].ToString();
                CODIGO_TAREA = dv[i]["CODIGO_TAREA"].ToString();
                PK_TAREA = dv[i]["PK_TAREA"].ToString();
                Xrow = new string[] { IDE_ACTIVIDAD, DES_ACTIVIDAD, CTA_COSTO, ID_TAREA, DES_TAREA, DES_UNIDAD, ID_FRENTE, DES_FRENTE, ID, CODIGO_TAREA, PK_TAREA };
                dataGridView1.Rows.Add(Xrow);
            }


            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (Convert.ToInt32(row.Cells["Grupo"].Value) % 2 == 0)
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

        private void txtTarea_TextChanged(object sender, EventArgs e)
        {
            if (txtTarea.Text.Length > 3)
            {
                GrillaFiltro("3");
            }

          
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int row = dataGridView1.CurrentCell.RowIndex;
             
                string IDE_ACTIVIDAD = dataGridView1.Rows[row].Cells["IDE_ACTIVIDAD"].Value.ToString();
                string DES_ACTIVIDAD = dataGridView1.Rows[row].Cells["DES_ACTIVIDAD"].Value.ToString();

                string ID_TAREA = dataGridView1.Rows[row].Cells["ID_TAREA"].Value.ToString();
                string DES_TAREA = dataGridView1.Rows[row].Cells["DES_TAREA"].Value.ToString();

                varfDesTareo = ID_TAREA + " - " + DES_TAREA;
                varfTareo = dataGridView1.Rows[row].Cells["DES_TAREA"].Value.ToString();
                varfCodTareo = dataGridView1.Rows[row].Cells["ID_TAREA"].Value.ToString();

                varfCodActividad = dataGridView1.Rows[row].Cells["IDE_ACTIVIDAD"].Value.ToString();
                varfDesActividad = IDE_ACTIVIDAD + " - " + DES_ACTIVIDAD;
                varfActividad = dataGridView1.Rows[row].Cells["DES_ACTIVIDAD"].Value.ToString();

                varfCodFrente = dataGridView1.Rows[row].Cells["ID_FRENTE"].Value.ToString();
                varfFrente = dataGridView1.Rows[row].Cells["DES_FRENTE"].Value.ToString();

                varfCtaCosto = dataGridView1.Rows[row].Cells["CTA_COSTO"].Value.ToString();
                varfUnidad = dataGridView1.Rows[row].Cells["DES_UNIDAD"].Value.ToString();

                varfDesFrente = dataGridView1.Rows[row].Cells["DES_FRENTE"].Value.ToString();

                varfCODIGO_TAREA = dataGridView1.Rows[row].Cells["CODIGO_TAREA"].Value.ToString();
                varfPK_TAREA = dataGridView1.Rows[row].Cells["PK_TAREA"].Value.ToString();
                this.Hide();
            }
        }

        private void txtActividad_TextChanged(object sender, EventArgs e)
        {
            if (txtActividad.Text.Length > 3)
            {
                GrillaFiltro("2");
            }
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            GrillaFiltro("4");

        }
    }
}
