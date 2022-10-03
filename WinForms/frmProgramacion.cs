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
using System.IO;
using System.Data.OleDb;
namespace WinForms
{
    public partial class frmProgramacion : Form
    {
        private string Excel03ConString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
        private string Excel07ConString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
       
        public frmProgramacion()
        {
            InitializeComponent();
            ListarEmpresa();
            TipoArchivos();
        }

        private void frmProgramacion_Load(object sender, EventArgs e)
        {

        }
        protected void ListarEmpresa()
        {
            BL_FUNCIONES obj = new BL_FUNCIONES();
            DataTable dtResultado = new DataTable();
            dtResultado = obj.ListarEmpresaPerfil(frmLogin.obj_perfil_E.IdPerfil, frmLogin.obj_user_E.IDE_USUARIO);
            if (dtResultado.Rows.Count > 0)
            {

                cboEmpresa.ValueMember = "ID";
                cboEmpresa.DisplayMember = "DESCRIPCION";
                cboEmpresa.DataSource = dtResultado;
                ListarCesos();
            }
        }
        protected void TipoArchivos()
        {
            //BL_FUNCIONES obj = new BL_FUNCIONES();

            BL_DISCIPLINAS obj = new BL_DISCIPLINAS();
            DataTable dtResultado = new DataTable();
            DataTable dt = new DataTable();
            //dtResultado = obj.SEL_DISCIPLINAS_POR_CENTRO_COSTO(cboCentroCosto.SelectedValue.ToString());
            dtResultado = obj.uspSEL_TIPO_TAREO_POR_CENTRO_COSTO(cboCentroCosto.SelectedValue.ToString());
            if (dtResultado.Rows.Count > 0)
            {

                DataColumn dc = new DataColumn("Codigo", typeof(String));
                dt.Columns.Add(dc);

                dc = new DataColumn("Descripcion", typeof(String));
                dt.Columns.Add(dc);

                DataRow workRow;

                workRow = dt.NewRow();
                workRow[0] = "0";
                workRow[1] = "--- SELECCIONAR  ---";
                dt.Rows.Add(workRow);

                for (int i = 0; i < dtResultado.Rows.Count; i++)
                {

                    workRow = dt.NewRow();
                    workRow[0] = dtResultado.Rows[i]["IDE_PARAMETRO"].ToString();
                    workRow[1] = dtResultado.Rows[i]["DESCRIPCION"].ToString();
                    dt.Rows.Add(workRow);
                }


                cboFile.ValueMember = "Codigo";
                cboFile.DisplayMember = "Descripcion";
                cboFile.DataSource = dt;
            }
        }
        /*
        protected void TipoArchivos()
        {
            BL_FUNCIONES obj = new BL_FUNCIONES();
            DataTable dtResultado = new DataTable();
            DataTable dt = new DataTable();
            dtResultado = obj.ListarParametros("CABECERA", "TIPO_ARCHIVO");
            if (dtResultado.Rows.Count > 0)
            {
              
                DataColumn dc = new DataColumn("Codigo", typeof(String));
                dt.Columns.Add(dc);

                dc = new DataColumn("Descripcion", typeof(String));
                dt.Columns.Add(dc);

                DataRow workRow;

                workRow = dt.NewRow();
                workRow[0] ="0";
                workRow[1] ="-------- SELECCIONAR DISCIPLINA ----------";
                dt.Rows.Add(workRow);

                for (int i = 0; i < dtResultado.Rows.Count; i++)
                {
                  
                    workRow = dt.NewRow();
                    workRow[0] = dtResultado.Rows[i]["IDE_PARAMETRO"].ToString(); 
                    workRow[1] = dtResultado.Rows[i]["DES_ASUNTO"].ToString();
                    dt.Rows.Add(workRow);
                }
                

                cboFile.ValueMember = "Codigo";
                cboFile.DisplayMember = "Descripcion";
                cboFile.DataSource = dt;
            }

            //int y = 1;
            //foreach (DataRow row in oTable.Rows)
            //{
            //    RadioButton radio = new RadioButton();
            //    radio.Text = Convert.ToString(row["DES_ASUNTO"]);
            //    radio.Tag = Convert.ToString(row["IDE_PARAMETRO"]);

            //    y += 5;
            //    //Location (X = baja arriba , y = derecha izquierda)
            //    radio.Location = new Point(10, y);

            //    panel1.Controls.Add(radio);
            //    y = radio.Bounds.Bottom + 1;
            //}


        }

           */
        protected void ListarCesos()
        {
            int anio = DateTime.Now.Year;
            BL_FUNCIONES obj = new BL_FUNCIONES();
            DataTable dtResultado = new DataTable();
            dtResultado = obj.ListarCesosPerfil(frmLogin.obj_perfil_E.IdPerfil, frmLogin.obj_user_E.IDE_USUARIO, Convert.ToInt32(cboEmpresa.SelectedValue));
            if (dtResultado.Rows.Count > 0)
            {
                cboCentroCosto.ValueMember = "ID";
                cboCentroCosto.DisplayMember = "CECOS";
                cboCentroCosto.DataSource = dtResultado;
             
            }
        }

        private void cboEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarCesos();
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }


        private void openFileDialog1_FileOk_1(object sender, CancelEventArgs e)
        {
            try
            {
                string filePath = openFileDialog1.FileName;
                string extension = Path.GetExtension(filePath);
                string header = "YES";// rbHeaderYes.Checked ? "YES" : "NO";
                string conStr, sheetName;
                dataGridView1.DataSource = null;
                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();


                conStr = string.Empty;
                //Cabecera( extension,  filePath);
                switch (extension)
                {

                    case ".xls": //Excel 97-03
                        conStr = string.Format(Excel03ConString, filePath, header);
                        break;

                    case ".xlsx": //Excel 07
                        conStr = string.Format(Excel07ConString, filePath, header);
                        break;
                }

                //Get the name of the First Sheet.
                using (OleDbConnection con = new OleDbConnection(conStr))
                {
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        cmd.Connection = con;
                        con.Open();
                        DataTable dtExcelSchema = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                        sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                        con.Close();
                    }
                }

                //Read Data from the First Sheet.
                using (OleDbConnection con = new OleDbConnection(conStr))
                {
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        using (OleDbDataAdapter oda = new OleDbDataAdapter())
                        {
                            DataTable dt = new DataTable();
                            cmd.CommandText = "SELECT * From [" + sheetName + "]";
                            cmd.Connection = con;
                            con.Open();
                            oda.SelectCommand = cmd;
                            oda.Fill(dt);
                            con.Close();

                            //Populate DataGridView.
                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Existen inconvenientes con el archivo, favor de cambiar la extensión de la misma", "Mensaje Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        protected void Cabecera(string extension , string filePath)
        {
            try
            {
                string header = "NO";// rbHeaderYes.Checked ? "YES" : "NO";
                string conStr, sheetName;
                //GridCabecera.DataSource = null;
                //GridCabecera.Columns.Clear();
                //GridCabecera.Rows.Clear();
                //GridCabecera.Refresh();


                conStr = string.Empty;
                switch (extension)
                {

                    case ".xls": //Excel 97-03
                        conStr = string.Format(Excel03ConString, filePath, header);
                        break;

                    case ".xlsx": //Excel 07
                        conStr = string.Format(Excel07ConString, filePath, header);
                        break;
                }

                //Get the name of the First Sheet.
                using (OleDbConnection con = new OleDbConnection(conStr))
                {
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        cmd.Connection = con;
                        con.Open();
                        DataTable dtExcelSchema = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                        sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                        con.Close();
                    }
                }

                //Read Data from the First Sheet.
                using (OleDbConnection con = new OleDbConnection(conStr))
                {
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        using (OleDbDataAdapter oda = new OleDbDataAdapter())
                        {
                            DataTable dt = new DataTable();
                            cmd.CommandText = "SELECT TOP 1 * From [" + sheetName + "]";
                            cmd.Connection = con;
                            con.Open();
                            oda.SelectCommand = cmd;
                            oda.Fill(dt);
                            con.Close();

                            //Populate DataGridView.
                            //GridCabecera.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Existen inconvenientes con el archivo, favor de cambiar la extensión de la misma", "Mensaje Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (cboFile.SelectedIndex > 0)
            {
                DialogResult respuesta = MessageBox.Show("¿Desea Agregar Programacion?", "Grabar Registros", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (respuesta == DialogResult.Yes)
                {

                    BL_DISCIPLINAS objDisciplina = new BL_DISCIPLINAS();
                    DataTable dtDisciplina = new DataTable();
                    dtDisciplina = objDisciplina.SEL_DISCIPLINAS_POR_DISCIPLINA(Convert.ToInt32(cboFile.SelectedValue),cboCentroCosto.SelectedValue.ToString ());

                    //if (Convert.ToInt32(dtDisciplina.Rows[0]["CANTIDAD"].ToString()) == dataGridView1.ColumnCount)
                    //{
                        int cantidad = 0;
                        if (dataGridView1.Rows.Count > 0)
                        {
                            //string H_hombre, H_metrado;
                            //string H_hombre_M, H_metrado_M;
                            //decimal num, numH;
                            dataGridView1.AllowUserToAddRows = false;
                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                BE_CABECERA obj = new BE_CABECERA();
                                obj.PK_TAREA = 0;
                                if (!row.Cells[0].Value.Equals(""))
                                {
                                    obj.ID_PROYECTO = cboCentroCosto.SelectedValue.ToString();
                                    obj.IDE_ACTIVIDAD = row.Cells[0].Value.ToString();
                                    obj.DES_ACTIVIDAD = row.Cells[1].Value.ToString();
                                    obj.ID_TAREA = row.Cells[2].Value.ToString();
                                    obj.DES_TAREA = row.Cells[3].Value.ToString();
                                    obj.DES_UNIDAD = row.Cells[4].Value.ToString();
                                    obj.CTA_COSTO = row.Cells[5].Value.ToString();
                                    obj.ID_FRENTE = row.Cells[6].Value.ToString();
                                    obj.DES_FRENTE = row.Cells[7].Value.ToString();
                                    obj.IDE_EMPRESA = Convert.ToInt32(cboEmpresa.SelectedValue);


                                    /*
                                        bool isNumber = decimal.TryParse(row.Cells[8].Value.ToString(), out num);
                                        if (isNumber == true)
                                        {
                                            H_hombre = row.Cells[8].Value.ToString();
                                        }
                                        else
                                        {
                                            H_hombre = "0";
                                        }

                                        bool isNumberM = decimal.TryParse(row.Cells[9].Value.ToString(), out numH);
                                        if (isNumberM == true)
                                        {
                                            H_metrado = row.Cells[9].Value.ToString();
                                        }
                                        else
                                        {
                                            H_metrado = "0";
                                        }

                                        obj.HORAS_HOMBRE = Convert.ToDecimal(H_hombre);
                                        obj.METRADOS = Convert.ToDecimal(H_metrado);

                                        ///////////////////////////////////////////////////////
                                        bool isNumber_M = decimal.TryParse(row.Cells[10].Value.ToString(), out num);
                                        if (isNumber_M == true)
                                        {
                                            H_hombre_M = row.Cells[10].Value.ToString();
                                        }
                                        else
                                        {
                                            H_hombre_M = "0";
                                        }

                                        bool isNumber_P = decimal.TryParse(row.Cells[11].Value.ToString(), out num);
                                        if (isNumber_P == true)
                                        {
                                            H_metrado_M = row.Cells[11].Value.ToString();
                                        }
                                        else
                                        {
                                            H_metrado_M = "0";
                                        }

                                        obj.HORAS_HOMBRE_M = Convert.ToDecimal(H_hombre_M);
                                        obj.METRADOS_M = Convert.ToDecimal(H_metrado_M);
                                    */
                                    obj.HORAS_HOMBRE = Convert.ToDecimal(0);
                                    obj.METRADOS = Convert.ToDecimal(0);
                                    obj.HORAS_HOMBRE_M = Convert.ToDecimal(0);
                                    obj.METRADOS_M = Convert.ToDecimal(0);
                                    obj.TIPO_ARCHIVO = cboFile.SelectedValue.ToString ();
                                    BL_CABECERA objActividad = new BL_CABECERA();
                                    int x_ = objActividad.Mant_Insert_ActividadPlaner(obj);
                                    cantidad++;
                                }
                            }

                            if (cantidad > 0)
                            {
                                dataGridView1.AllowUserToAddRows = true;

                                MessageBox.Show("Registro Satisfactorio", "Mensaje Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                        }
                        listarProgramacion();
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Error con el formato adjunto", "Mensaje Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}

                }
            }
            else
            {
                MessageBox.Show("Seleccionar Tipo Disciplina", "Mensaje Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cboFile.SelectedIndex > 0)
            {
                listarProgramacion();
            }
            else
            {
                MessageBox.Show("Seleccionar Tipo Tareo", "Mensaje Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        protected void listarProgramacion()
        {



            
            dataGridView1.Refresh();
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            BL_DISCIPLINAS objDisciplina = new BL_DISCIPLINAS();
            DataTable dtDisciplina = new DataTable();
            dtDisciplina = objDisciplina.uspSEL_TIPO_TAREO_POR_CENTRO_COSTO(cboCentroCosto.SelectedValue.ToString());



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


            dataGridView1.Columns["DES_ACTIVIDAD"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns["DES_TAREA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns["Grupo"].Visible = false;

            BL_CABECERA obj = new BL_CABECERA();
            DataTable dtResul = new DataTable();
            try
            {
               
                dtResul = obj.ListarProgramacion_Disciplina(cboCentroCosto.SelectedValue.ToString(), Convert.ToInt32(cboEmpresa.SelectedValue), Convert.ToInt32(cboFile.SelectedValue));
                if (dtResul.Rows.Count > 0)
                {
                    string IDE_ACTIVIDAD,DES_ACTIVIDAD, CTA_COSTO,ID_TAREA, DES_TAREA,DES_UNIDAD,ID_FRENTE,DES_FRENTE,ID;
                    string[] Xrow;
                    for (int i = 0; i < dtResul.Rows.Count; i++)
                    {
                        IDE_ACTIVIDAD = dtResul.Rows[i]["IDE_ACTIVIDAD"].ToString();
                        DES_ACTIVIDAD = dtResul.Rows[i]["DES_ACTIVIDAD"].ToString();
                        CTA_COSTO = dtResul.Rows[i]["CTA_COSTO"].ToString();
                        ID_TAREA = dtResul.Rows[i]["ID_TAREA"].ToString();
                        DES_TAREA = dtResul.Rows[i]["DES_TAREA"].ToString();
                        DES_UNIDAD = dtResul.Rows[i]["DES_UNIDAD"].ToString();
                        ID_FRENTE = dtResul.Rows[i]["ID_FRENTE"].ToString();
                        DES_FRENTE = dtResul.Rows[i]["DES_FRENTE"].ToString();
                        ID = dtResul.Rows[i]["ID"].ToString();
                        Xrow = new string[] { IDE_ACTIVIDAD, DES_ACTIVIDAD, CTA_COSTO, ID_TAREA, DES_TAREA, DES_UNIDAD, ID_FRENTE, DES_FRENTE, ID };
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
                    dataGridView1.AutoSizeColumnsMode =DataGridViewAutoSizeColumnsMode.AllCells;
                }
                else
                {
                    dataGridView1.Rows.Clear();
                    dataGridView1.Refresh();
                    dataGridView1.DataSource = null;
                    dataGridView1.Columns.Clear();

                    //GridCabecera.DataSource = null;
                    //GridCabecera.Rows.Clear();
                    //GridCabecera.Refresh();
                    
                    //GridCabecera.Columns.Clear();

                }
            }

            catch (Exception ex)
            {

            }
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
           
           int col = dataGridView1.CurrentCell.ColumnIndex;
            TextBox txt_GV_DATA = e.Control as TextBox;
            if (dataGridView1.Columns[col].Name == "HORAS_HOMBRE") 
            {
                if (txt_GV_DATA != null)
                {
                    txt_GV_DATA.KeyPress += txt_Numero_KeyPress;
                }
            }
            else if (dataGridView1.Columns[col].Name == "METRADOS") 
            {
                if (txt_GV_DATA != null)
                {
                    txt_GV_DATA.KeyPress += txt_Numero_KeyPress;
                }
            }
        }
        private void txt_Numero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back || (e.KeyChar == (char)'.') && !(sender as TextBox).Text.Contains("."))
            {
                return;
            }
            decimal isNumber = 0;
            e.Handled = !decimal.TryParse(e.KeyChar.ToString(), out isNumber);
        }

        private void cboCentroCosto_SelectedIndexChanged(object sender, EventArgs e)
        {
            TipoArchivos();
        }
    }
}
