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
    public partial class MaestroPersonal : Form
    {
      
        public MaestroPersonal()
        {
            InitializeComponent();
            ListarEmpresa();
        }

        private void MaestroPersonal_Load(object sender, EventArgs e)
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
       

        protected void EstructuraPersonal(string TipoPersonal)
        {


            dgvPersonal.Rows.Clear();
            dgvPersonal.Refresh();
            dgvPersonal.DataSource = null;
            dgvPersonal.Columns.Clear();

            DataGridViewTextBoxColumn colid = new DataGridViewTextBoxColumn();
            colid.Name = "Item";
            colid.HeaderText = "N°";
            colid.Width = 50;
            dgvPersonal.Columns.Insert(0, colid);


            DataGridViewTextBoxColumn Columcentro = new DataGridViewTextBoxColumn();
            Columcentro.Name = "CCosto";
            Columcentro.HeaderText = "C. Costo";
            Columcentro.Width = 100;
            dgvPersonal.Columns.Insert(1, Columcentro);

            DataGridViewTextBoxColumn ColumPaterno = new DataGridViewTextBoxColumn();
            ColumPaterno.Name = "Paterno";
            ColumPaterno.HeaderText = "Apellido Paterno";
            ColumPaterno.Width = 200;
            dgvPersonal.Columns.Insert(2, ColumPaterno);

            DataGridViewTextBoxColumn ColumMaterno = new DataGridViewTextBoxColumn();
            ColumMaterno.Name = "Materno";
            ColumMaterno.HeaderText = "Apellido Materno";
            ColumMaterno.Width = 200;
            dgvPersonal.Columns.Insert(3, ColumMaterno);

            DataGridViewTextBoxColumn ColumNombres = new DataGridViewTextBoxColumn();
            ColumNombres.Name = "Nombres";
            ColumNombres.HeaderText = "Nombres";
            ColumNombres.Width = 200;
            dgvPersonal.Columns.Insert(4, ColumNombres);

            DataGridViewTextBoxColumn ColumDNI = new DataGridViewTextBoxColumn();
            ColumDNI.Name = "DNI";
            ColumDNI.HeaderText = "DNI";
            //ColumDNI.Width = 100;
            dgvPersonal.Columns.Insert(5, ColumDNI);

            DataGridViewTextBoxColumn ColumCat = new DataGridViewTextBoxColumn();
            ColumCat.Name = "CodCategoria";
            ColumCat.HeaderText = "Cod. Cat.";
            //ColumDNI.Width = 100;
            dgvPersonal.Columns.Insert(6, ColumCat);

            DataGridViewTextBoxColumn ColumEsp = new DataGridViewTextBoxColumn();
            ColumEsp.Name = "CodEspecialidad";
            ColumEsp.HeaderText = "Cod. Esp.";
            //ColumDNI.Width = 100;
            dgvPersonal.Columns.Insert(7, ColumEsp);

            DataGridViewTextBoxColumn ColumTipo = new DataGridViewTextBoxColumn();
            ColumTipo.Name = "TipoPersonal";
            ColumTipo.HeaderText = "Tipo";
            dgvPersonal.Columns.Insert(8, ColumTipo);

            DataGridViewTextBoxColumn ColCATEGORIA = new DataGridViewTextBoxColumn();
            ColCATEGORIA.Name = "Categoria";
            ColCATEGORIA.HeaderText = "Categoria";
            ColCATEGORIA.Width = 150;
            dgvPersonal.Columns.Insert(9, ColCATEGORIA);


            DataGridViewTextBoxColumn ColESPECIALIDAD = new DataGridViewTextBoxColumn();
            ColESPECIALIDAD.Name = "Especialidad";
            ColESPECIALIDAD.HeaderText = "Especialidad";
            ColESPECIALIDAD.Width = 150;
            dgvPersonal.Columns.Insert(10, ColESPECIALIDAD);

            DataGridViewTextBoxColumn ColFechaIngreso = new DataGridViewTextBoxColumn();
            ColFechaIngreso.Name = "FecIngreso";
            ColFechaIngreso.HeaderText = "FecIngreso";
            ColFechaIngreso.Width = 150;
            dgvPersonal.Columns.Insert(11, ColFechaIngreso);


            DataGridViewTextBoxColumn ColCOD_PERSONAL = new DataGridViewTextBoxColumn();
            ColCOD_PERSONAL.Name = "COD_PERSONAL";
            ColCOD_PERSONAL.HeaderText = "COD_PERSONAL";
            ColCOD_PERSONAL.Width = 100;
            dgvPersonal.Columns.Insert(12, ColCOD_PERSONAL);


            if (checkPersona.Checked)
            {
                if (txtDni.Text != string.Empty)
                {
                    ListarGrilla(TipoPersonal);
                }
                else
                {
                    MessageBox.Show("Ingresar N° Dni a consultar", "Mensaje Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                ListarGrilla(TipoPersonal);
            }
        }
        private void btnlistarPersonal_Click(object sender, EventArgs e)
        {
            

            if (AccesoInternet())
            {
                
                    //MessageBox.Show("Se realizo la conexión correctamente");

                    progressBar1.Value = 0;
                    EstructuraPersonal("01");
                
            }
            else
            {
                MessageBox.Show("Sin acceso a internet", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
        protected void ListarGrilla(string TipoPersonal)
        {

            BL_PERSONAL obj = new BL_PERSONAL();
            DataTable dtResultado = new DataTable();

            if (cboEmpresa.SelectedValue.ToString () =="1")
            {
                
            }

            if (checkPersona.Checked)
            {
                dtResultado = obj.Get_PersonalGestorDNI(Convert.ToInt32(cboEmpresa.SelectedValue), cboCentroCosto.SelectedValue.ToString(), txtDni.Text);
            }
            else
            {
                dtResultado = obj.Get_PersonalGestor(Convert.ToInt32(cboEmpresa.SelectedValue), cboCentroCosto.SelectedValue.ToString(), TipoPersonal);
            }

            //else
            //{
            //    if (checkPersona.Checked)
            //    {
            //        dtResultado = new TareoClient().Get_PersonalGestorDNI_SKEX(Convert.ToInt32(cboEmpresa.SelectedValue), cboCentroCosto.SelectedValue.ToString(), txtDni.Text);
            //    }
            //    else
            //    {
            //        dtResultado = new TareoClient().Get_PersonalGestorSKEX(Convert.ToInt32(cboEmpresa.SelectedValue), cboCentroCosto.SelectedValue.ToString(), TipoPersonal);
            //    }
            //}


            progressBar1.Minimum = 0;
            progressBar1.Visible = true;
            if (dtResultado.Rows.Count > 0)
            {
                string ID, CENTRO_COSTO, APELLIDO_PATERNO, APELLIDO_MATERNO, NOMBRES, DOCUMENTO_IDENTIFICACION, COD_CATEGORIA_OBRERO, COD_ESPECIALIDAD_TRABAJADOR, TIPO_TRABAJADOR, CATEGORIA, ESPECIALIDAD, FECHA_INGRESO, COD_PERSONAL;
                string[] Xrow;
                progressBar1.Maximum = dtResultado.Rows.Count;

                for (int i = 0; i < dtResultado.Rows.Count; i++)
                {
                    //DataGridViewRow row = (DataGridViewRow)dgvPersonal.Rows[i].Clone();



                    ID = dtResultado.Rows[i]["ID"].ToString();
                    CENTRO_COSTO = dtResultado.Rows[i]["CENTRO_COSTO"].ToString();
                    APELLIDO_PATERNO = dtResultado.Rows[i]["APELLIDO_PATERNO"].ToString();
                    APELLIDO_MATERNO = dtResultado.Rows[i]["APELLIDO_MATERNO"].ToString();
                    NOMBRES = dtResultado.Rows[i]["NOMBRES"].ToString();
                    DOCUMENTO_IDENTIFICACION = dtResultado.Rows[i]["DOCUMENTO_IDENTIFICACION"].ToString();
                    COD_CATEGORIA_OBRERO = dtResultado.Rows[i]["CATEGORIA_OBRERO"].ToString();
                    COD_ESPECIALIDAD_TRABAJADOR = dtResultado.Rows[i]["ESPECIALIDAD_TRABAJADOR"].ToString();
                    TIPO_TRABAJADOR = dtResultado.Rows[i]["TIPO_TRABAJADOR"].ToString();
                    CATEGORIA = dtResultado.Rows[i]["CATEGORIA"].ToString();
                    ESPECIALIDAD = dtResultado.Rows[i]["ESPECIALIDAD"].ToString();
                    FECHA_INGRESO = dtResultado.Rows[i]["FECHA_INGRESO"].ToString();
                    COD_PERSONAL = dtResultado.Rows[i]["COD_PERSONAL"].ToString();
                    Xrow = new string[] {
                       ID, CENTRO_COSTO, APELLIDO_PATERNO, APELLIDO_MATERNO, NOMBRES, DOCUMENTO_IDENTIFICACION, COD_CATEGORIA_OBRERO, COD_ESPECIALIDAD_TRABAJADOR, TIPO_TRABAJADOR,CATEGORIA,ESPECIALIDAD,FECHA_INGRESO,COD_PERSONAL
                            };
                    dgvPersonal.Rows.Add(Xrow);
                    progressBar1.Value = i + 1;
                }
                dgvPersonal.Columns["CodEspecialidad"].Visible = false;
                dgvPersonal.Columns["CodCategoria"].Visible = false;
                dgvPersonal.Columns["COD_PERSONAL"].Visible = false;
                //dgvPersonal.Columns["FECHA_INGRESO"].Visible = false;
                //if (TipoPersonal =="01")
                //{
                //    dgvPersonal.Columns["CodEspecialidad"].Visible = false;
                //    dgvPersonal.Columns["CodCategoria"].Visible = false;
                //    dgvPersonal.Columns["Especialidad"].Visible = false;
                //    dgvPersonal.Columns["Categoria"].Visible = false;

                //}
                //else
                //{
                //    dgvPersonal.Columns["CodEspecialidad"].Visible = false;
                //    dgvPersonal.Columns["CodCategoria"].Visible = false;
                //    dgvPersonal.Columns["Especialidad"].Visible = true;
                //    dgvPersonal.Columns["Categoria"].Visible = true;
                //}
            }
            else
            {
                progressBar1.Value = 0;
                dgvPersonal.Rows.Clear();
                dgvPersonal.Refresh();
                MessageBox.Show("No registra información", "Mensaje Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cboEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarCesos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (dgvPersonal.Rows.Count == 0)
            {
                MessageBox.Show("Listar categoria de personal", "Mensaje Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult respuesta = MessageBox.Show("¿Deseas agregar personal?", "Grabar registros", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (respuesta == DialogResult.Yes)
                {
                    int cantidad = 0;
                    string TipoPersona = string.Empty;
                    if (dgvPersonal.Rows.Count > 0)
                    {
                        if (checkPersona.Checked == true)
                        {
                            //BL_PERSONAL objPerson = new BL_PERSONAL();
                            //objPerson.Update_EstadoPersonal(Convert.ToInt32(cboEmpresa.SelectedValue), cboCentroCosto.SelectedValue.ToString(), TipoPersona);

                            foreach (DataGridViewRow row in dgvPersonal.Rows)
                            {

                                BE_PERSONAL obj = new BE_PERSONAL();
                                obj.CENTRO_COSTO = cboCentroCosto.SelectedValue.ToString();
                                obj.APELLIDO_PATERNO = row.Cells["Paterno"].Value.ToString();
                                obj.APELLIDO_MATERNO = row.Cells["Materno"].Value.ToString();
                                obj.NOMBRES = row.Cells["Nombres"].Value.ToString();
                                obj.DOCUMENTO_IDENTIFICACION = row.Cells["DNI"].Value.ToString();
                                obj.TIPO_TRABAJADOR = row.Cells["TipoPersonal"].Value.ToString();
                                TipoPersona = row.Cells["TipoPersonal"].Value.ToString();
                                obj.ID_CATEGORIA = row.Cells["CodCategoria"].Value.ToString();
                                obj.ID_ESPECIALIDAD = row.Cells["CodEspecialidad"].Value.ToString();
                                obj.IDE_EMPRESA = Convert.ToInt32(cboEmpresa.SelectedValue);
                                obj.FECHA_INGRESO = row.Cells["FecIngreso"].Value.ToString();
                                obj.COD_PERSONAL = row.Cells["COD_PERSONAL"].Value.ToString();
                                BL_PERSONAL objPersonal = new BL_PERSONAL();

                                int x_ = objPersonal.Mant_Insert_Trabajadores_WCF_DNI(obj);
                                cantidad++;
                            }

                            if (cantidad > 0)
                            {
                                MessageBox.Show("Registro satisfactorio", "Mensaje sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                        }
                        else
                        {

                            foreach (DataGridViewRow row in dgvPersonal.Rows)
                            {

                                BE_PERSONAL obj = new BE_PERSONAL();
                                obj.CENTRO_COSTO = row.Cells["CCosto"].Value.ToString();
                                obj.APELLIDO_PATERNO = row.Cells["Paterno"].Value.ToString();
                                obj.APELLIDO_MATERNO = row.Cells["Materno"].Value.ToString();
                                obj.NOMBRES = row.Cells["Nombres"].Value.ToString();
                                obj.DOCUMENTO_IDENTIFICACION = row.Cells["DNI"].Value.ToString();
                                obj.TIPO_TRABAJADOR = row.Cells["TipoPersonal"].Value.ToString();
                                TipoPersona = row.Cells["TipoPersonal"].Value.ToString();
                                obj.ID_CATEGORIA = row.Cells["CodCategoria"].Value.ToString();
                                obj.ID_ESPECIALIDAD = row.Cells["CodEspecialidad"].Value.ToString();
                                obj.IDE_EMPRESA = Convert.ToInt32(cboEmpresa.SelectedValue);
                                obj.FECHA_INGRESO = row.Cells["FecIngreso"].Value.ToString();
                                obj.COD_PERSONAL = row.Cells["COD_PERSONAL"].Value.ToString();
                                BL_PERSONAL objPersonal = new BL_PERSONAL();
                                int x_ = objPersonal.Mant_Insert_Trabajadores_WCF(obj);
                                cantidad++;
                            }

                            if (cantidad > 0)
                            {
                                MessageBox.Show("Registro satisfactorio", "Mensaje sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }

                    

                    /// ACTUALIZACION PARA PERSONSAL NUEVO Y CESADOS
                }
            }
            checkPersona.Checked = false ;
             txtDni.Text = string.Empty;
        }

        private void checkPersona_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPersona.Checked)
            {
                txtDni.ReadOnly = false;
            }
            else
            {
                txtDni.ReadOnly = true;
            }
        }

        private void btnListarObreros_Click(object sender, EventArgs e)
        {
      

            if (AccesoInternet())
            {
                
                    progressBar1.Value = 0;
                    EstructuraPersonal("02");
            }
            else
            {
                MessageBox.Show("Sin acceso a internet", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private bool AccesoInternet()
        {

            try
            {
                System.Net.IPHostEntry host = System.Net.Dns.GetHostEntry("www.google.com");
                return true;

            }
            catch (Exception es)
            {

                return false;
            }

        }

        private void txtDni_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
