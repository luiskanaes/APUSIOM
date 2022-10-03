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
using ThoughtWorks.QRCode;
using ThoughtWorks.QRCode.Codec;
using ThoughtWorks.QRCode.Codec.Data;
using System.Configuration;

namespace WinForms
{
    public partial class Fotocheck : Form
    {
        public static BE_PERSONAL obj_personal_E;
        private Color colorFondoQR = Color.FromArgb(255, 255, 255, 255);
        private Color colorQR = Color.FromArgb(255, 0, 0, 0);
        public Fotocheck()
        {
            InitializeComponent();
            ListarEmpresa();
        }

        private void Fotocheck_Load(object sender, EventArgs e)
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

        private void cboEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarCesos();
        }

        private void cboCentroCosto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnlistarPersonal_Click(object sender, EventArgs e)
        {
            EstructuraPersonal("01");
        }

        private void btnListarObreros_Click(object sender, EventArgs e)
        {
            EstructuraPersonal("02");
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
            colid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPersonal.Columns.Insert(0, colid);


            DataGridViewTextBoxColumn Columcentro = new DataGridViewTextBoxColumn();
            Columcentro.Name = "CCosto";
            Columcentro.HeaderText = "Proyecto";
            Columcentro.Width = 80;
            Columcentro.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPersonal.Columns.Insert(1, Columcentro);


            DataGridViewTextBoxColumn ColumDNI = new DataGridViewTextBoxColumn();
            ColumDNI.Name = "DNI";
            ColumDNI.HeaderText = "DNI";
            ColumDNI.Width = 80;
            ColumDNI.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPersonal.Columns.Insert(2, ColumDNI);

            DataGridViewTextBoxColumn ColumPaterno = new DataGridViewTextBoxColumn();
            ColumPaterno.Name = "Personal";
            ColumPaterno.HeaderText = "Personal";
            ColumPaterno.Width = 400;
            dgvPersonal.Columns.Insert(3, ColumPaterno);


            DataGridViewTextBoxColumn ColumCat = new DataGridViewTextBoxColumn();
            ColumCat.Name = "CATEGORIA";
            ColumCat.HeaderText = "CATEGORIA";
            //ColumDNI.Width = 100;
            ColumCat.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPersonal.Columns.Insert(4, ColumCat);

            DataGridViewTextBoxColumn ColumEsp = new DataGridViewTextBoxColumn();
            ColumEsp.Name = "ESPECIALIDAD";
            ColumEsp.HeaderText = "ESPECIALIDAD";
            //ColumDNI.Width = 100;
            dgvPersonal.Columns.Insert(5, ColumEsp);

            DataGridViewTextBoxColumn ColumTipo = new DataGridViewTextBoxColumn();
            ColumTipo.Name = "TipoPersonal";
            ColumTipo.HeaderText = "Tipo";
            dgvPersonal.Columns.Insert(6, ColumTipo);



            DataGridViewTextBoxColumn ColFechaIngreso = new DataGridViewTextBoxColumn();
            ColFechaIngreso.Name = "FecIngreso";
            ColFechaIngreso.HeaderText = "FecIngreso";
            ColFechaIngreso.Width = 100;
            ColFechaIngreso.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPersonal.Columns.Insert(7, ColFechaIngreso);

            DataGridViewTextBoxColumn ColIDE_PERSONAL = new DataGridViewTextBoxColumn();
            ColIDE_PERSONAL.Name = "IDE_PERSONAL";
            ColIDE_PERSONAL.HeaderText = "IDE_PERSONAL";
            ColIDE_PERSONAL.Width = 120;
            dgvPersonal.Columns.Insert(8, ColIDE_PERSONAL);


            DataGridViewTextBoxColumn ColTIPO_TRABAJADOR = new DataGridViewTextBoxColumn();
            ColTIPO_TRABAJADOR.Name = "TIPO_TRABAJADOR";
            ColTIPO_TRABAJADOR.HeaderText = "TIPO_TRABAJADOR";
            ColTIPO_TRABAJADOR.Width = 120;
            dgvPersonal.Columns.Insert(9, ColTIPO_TRABAJADOR);

            DataGridViewTextBoxColumn ColAPELLIDO_PATERNO = new DataGridViewTextBoxColumn();
            ColAPELLIDO_PATERNO.Name = "APELLIDO_PATERNO";
            ColAPELLIDO_PATERNO.HeaderText = "APELLIDO_PATERNO";
            ColAPELLIDO_PATERNO.Width = 120;
            dgvPersonal.Columns.Insert(10, ColAPELLIDO_PATERNO);

            DataGridViewTextBoxColumn ColAPELLIDO_MATERNO = new DataGridViewTextBoxColumn();
            ColAPELLIDO_MATERNO.Name = "APELLIDO_MATERNO";
            ColAPELLIDO_MATERNO.HeaderText = "APELLIDO_MATERNO";
            ColAPELLIDO_MATERNO.Width = 120;
            dgvPersonal.Columns.Insert(11, ColAPELLIDO_MATERNO);

            DataGridViewTextBoxColumn ColNOMBRES = new DataGridViewTextBoxColumn();
            ColNOMBRES.Name = "NOMBRES";
            ColNOMBRES.HeaderText = "NOMBRES";
            ColNOMBRES.Width = 120;
            dgvPersonal.Columns.Insert(12, ColNOMBRES);


            DataGridViewTextBoxColumn ColFOTO = new DataGridViewTextBoxColumn();
            ColFOTO.Name = "FOTO";
            ColFOTO.HeaderText = "FOTO";
            ColFOTO.Width = 120;
            dgvPersonal.Columns.Insert(13, ColFOTO);


            DataGridViewTextBoxColumn ColFOTOCHECK = new DataGridViewTextBoxColumn();
            ColFOTOCHECK.Name = "FOTOCHECK";
            ColFOTOCHECK.HeaderText = "FOTOCHECK";
            ColFOTOCHECK.Width = 120;
            dgvPersonal.Columns.Insert(14, ColFOTOCHECK);


            DataGridViewTextBoxColumn ColFLG_FOTO = new DataGridViewTextBoxColumn();
            ColFLG_FOTO.Name = "FLG_FOTO";
            ColFLG_FOTO.HeaderText = "FOTO";
            ColFLG_FOTO.Width = 60;
            ColFLG_FOTO.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPersonal.Columns.Insert(15, ColFLG_FOTO);

            DataGridViewTextBoxColumn ColEXISTE_FOTOCHECK = new DataGridViewTextBoxColumn();
            ColEXISTE_FOTOCHECK.Name = "EXISTE_FOTOCHECK";
            ColEXISTE_FOTOCHECK.HeaderText = "QR";
            ColEXISTE_FOTOCHECK.Width = 80;
            ColEXISTE_FOTOCHECK.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPersonal.Columns.Insert(16, ColEXISTE_FOTOCHECK);


            DataGridViewTextBoxColumn ColCODIGO_SISPLAN = new DataGridViewTextBoxColumn();
            ColCODIGO_SISPLAN.Name = "CODIGO_SISPLAN";
            ColCODIGO_SISPLAN.HeaderText = "CODIGO_SISPLAN";
            ColCODIGO_SISPLAN.Width = 80;
            ColCODIGO_SISPLAN.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPersonal.Columns.Insert(17, ColCODIGO_SISPLAN);


            DataGridViewTextBoxColumn ColEMPRESA_BREVE = new DataGridViewTextBoxColumn();
            ColEMPRESA_BREVE.Name = "EMPRESA_BREVE";
            ColEMPRESA_BREVE.HeaderText = "EMPRESA_BREVE";
            ColEMPRESA_BREVE.Width = 80;
            ColEMPRESA_BREVE.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPersonal.Columns.Insert(18, ColEMPRESA_BREVE);

            //boton
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            dgvPersonal.Columns.Add(btn);
            btn.HeaderText = "";
            btn.Text = "Generar";
            btn.Name = "btn";
            btn.UseColumnTextForButtonValue = true;


            DataGridViewButtonColumn btnExport = new DataGridViewButtonColumn();
            dgvPersonal.Columns.Add(btnExport);
            btnExport.HeaderText = "";
            btnExport.Text = "Exportar";
            btnExport.Name = "btnExport";
            btnExport.UseColumnTextForButtonValue = true;

            BL_PERSONAL obj = new BL_PERSONAL();
            DataTable dtResultado = new DataTable();
            dtResultado = obj.USP_PERSONAL_FOTOCHECK(cboCentroCosto.SelectedValue.ToString(), TipoPersonal, string.Empty);
            if (dtResultado.Rows.Count > 0)
            {
                string Row,
                        CENTRO_COSTO, DOCUMENTO_IDENTIFICACION,
                        PERSONAL,
                        CATEGORIA,
                        ESPECIALIDAD,
                        TP_TRABAJADOR,
                        FECHA_INGRESO,
                        IDE_PERSONAL, TIPO_TRABAJADOR, APELLIDO_PATERNO, APELLIDO_MATERNO, NOMBRES, FOTO, FOTOCHECK,
                        FLG_FOTO, EXISTE_FOTOCHECK, CODIGO_SISPLAN, EMPRESA_BREVE;
                string[] Xrow;

                for (int i = 0; i < dtResultado.Rows.Count; i++)
                {
                    //DataGridViewRow row = (DataGridViewRow)dgvPersonal.Rows[i].Clone();



                    Row = dtResultado.Rows[i]["Row"].ToString();
                    CENTRO_COSTO = dtResultado.Rows[i]["CENTRO_COSTO"].ToString();
                    DOCUMENTO_IDENTIFICACION = dtResultado.Rows[i]["DOCUMENTO_IDENTIFICACION"].ToString();
                    PERSONAL = dtResultado.Rows[i]["PERSONAL"].ToString();
                    CATEGORIA = dtResultado.Rows[i]["CATEGORIA"].ToString();
                    ESPECIALIDAD = dtResultado.Rows[i]["ESPECIALIDAD"].ToString();
                    TP_TRABAJADOR = dtResultado.Rows[i]["TP_TRABAJADOR"].ToString();
                    FECHA_INGRESO = dtResultado.Rows[i]["FECHA_INGRESO"].ToString();
                    IDE_PERSONAL = dtResultado.Rows[i]["IDE_PERSONAL"].ToString();

                    TIPO_TRABAJADOR = dtResultado.Rows[i]["TIPO_TRABAJADOR"].ToString();
                    APELLIDO_PATERNO = dtResultado.Rows[i]["APELLIDO_PATERNO"].ToString();
                    APELLIDO_MATERNO = dtResultado.Rows[i]["APELLIDO_MATERNO"].ToString();
                    NOMBRES = dtResultado.Rows[i]["NOMBRES"].ToString();
                    FOTO = dtResultado.Rows[i]["FOTO"].ToString();
                    FOTOCHECK = dtResultado.Rows[i]["FOTOCHECK"].ToString();

                    FLG_FOTO = dtResultado.Rows[i]["FLG_FOTO"].ToString();
                    EXISTE_FOTOCHECK = dtResultado.Rows[i]["EXISTE_FOTOCHECK"].ToString();
                    CODIGO_SISPLAN = dtResultado.Rows[i]["CODIGO_SISPLAN"].ToString();
                    EMPRESA_BREVE = dtResultado.Rows[i]["EMPRESA_BREVE"].ToString();
                    Xrow = new string[] {
                                Row,
                                CENTRO_COSTO,
                                DOCUMENTO_IDENTIFICACION,
                                PERSONAL,
                                CATEGORIA,
                                ESPECIALIDAD,
                                TP_TRABAJADOR,
                                FECHA_INGRESO,
                                IDE_PERSONAL,TIPO_TRABAJADOR,APELLIDO_PATERNO ,APELLIDO_MATERNO, NOMBRES, FOTO, FOTOCHECK,
                                FLG_FOTO,EXISTE_FOTOCHECK,CODIGO_SISPLAN,EMPRESA_BREVE
                            };
                    dgvPersonal.Rows.Add(Xrow);

                }
                dgvPersonal.Columns["IDE_PERSONAL"].Visible = false;
                dgvPersonal.Columns["TipoPersonal"].Visible = false;

                dgvPersonal.Columns["TIPO_TRABAJADOR"].Visible = false;
                dgvPersonal.Columns["APELLIDO_PATERNO"].Visible = false;
                dgvPersonal.Columns["APELLIDO_MATERNO"].Visible = false;
                dgvPersonal.Columns["NOMBRES"].Visible = false;

                dgvPersonal.Columns["FOTO"].Visible = false;
                dgvPersonal.Columns["FOTOCHECK"].Visible = false;
                dgvPersonal.Columns["CODIGO_SISPLAN"].Visible = false;
                dgvPersonal.Columns["EMPRESA_BREVE"].Visible = false;
                
            }
            else
            {

                dgvPersonal.Rows.Clear();
                dgvPersonal.Refresh();
                MessageBox.Show("No existe información", "Mensaje Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void dgvPersonal_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            string DNI, TIPO_TRABAJADOR, APELLIDO_PATERNO, APELLIDO_MATERNO, NOMBRES, IDE_PERSONAL, FOTO, FOTOCHECK, PERSONAL,
                EMPRESA_BREVE, CATEGORIA, ESPECIALIDAD;

            if (e.ColumnIndex > -1)
            {
                if (dgvPersonal.Columns[e.ColumnIndex].Name == "btn")
                {


                    DataGridViewRow rowx = dgvPersonal.Rows[i];
                    DNI = (rowx.Cells[2].Value == null) ? string.Empty : rowx.Cells[2].Value.ToString();// persona
                    TIPO_TRABAJADOR = (rowx.Cells[9].Value == null) ? string.Empty : rowx.Cells[9].Value.ToString();// 
                    APELLIDO_PATERNO = (rowx.Cells[10].Value == null) ? string.Empty : rowx.Cells[10].Value.ToString();// 
                    APELLIDO_MATERNO = (rowx.Cells[11].Value == null) ? string.Empty : rowx.Cells[11].Value.ToString();// 
                    NOMBRES = (rowx.Cells[12].Value == null) ? string.Empty : rowx.Cells[12].Value.ToString();// 
                    IDE_PERSONAL = (rowx.Cells[8].Value == null) ? "0" : rowx.Cells[8].Value.ToString();// IDE_PERSONAL

                    FOTO = (rowx.Cells[13].Value == null) ? "" : rowx.Cells[13].Value.ToString();
                    FOTOCHECK = (rowx.Cells[14].Value == null) ? "" : rowx.Cells[14].Value.ToString();
                    EMPRESA_BREVE = (rowx.Cells[18].Value == null) ? "" : rowx.Cells[18].Value.ToString();

                    ESPECIALIDAD = (rowx.Cells[5].Value == null) ? "" : rowx.Cells[5].Value.ToString();
                    CATEGORIA = (rowx.Cells[4].Value == null) ? "" : rowx.Cells[4].Value.ToString();


                    if (DNI != string.Empty)
                    {
                        obj_personal_E = new BE_PERSONAL();
                        obj_personal_E.DOCUMENTO_IDENTIFICACION = DNI;
                        obj_personal_E.TIPO_TRABAJADOR = TIPO_TRABAJADOR;
                        obj_personal_E.APELLIDO_PATERNO = APELLIDO_PATERNO;
                        obj_personal_E.APELLIDO_MATERNO = APELLIDO_MATERNO;
                        obj_personal_E.NOMBRES = NOMBRES;
                        obj_personal_E.IDE_PERSONAL = Convert.ToInt32(IDE_PERSONAL);
                        obj_personal_E.FOTO = FOTO;
                        obj_personal_E.FOTOCHECK = FOTOCHECK;
                        obj_personal_E.EMPRESA_BREVE = EMPRESA_BREVE;
                        obj_personal_E.CATEGORIA = CATEGORIA;
                        obj_personal_E.ESPECIALIDAD = ESPECIALIDAD;


                        FotoCheckId f2 = new FotoCheckId(); //creamos un objeto del formulario hijo
                        DialogResult res = f2.ShowDialog();
                        if (f2.varFoto > 0)
                        {
                            dgvPersonal.Rows[rowx.Index].Cells["FOTO"].Value = "SI";
                        }

                        if(f2.varQR > 0)
                        {
                            dgvPersonal.Rows[rowx.Index].Cells["FOTOCHECK"].Value = "SI";
                        }


                       



                        //MessageBox.Show(DNI, "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Operacion no permitida", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }

                if (dgvPersonal.Columns[e.ColumnIndex].Name == "btnExport")
                {
                    DataGridViewRow rowx = dgvPersonal.Rows[i];
                    IDE_PERSONAL = (rowx.Cells[8].Value == null) ? "0" : rowx.Cells[8].Value.ToString();// IDE_PERSONAL
                    FOTO = (rowx.Cells[13].Value == null) ? "0" : rowx.Cells[13].Value.ToString();
                    FOTOCHECK = (rowx.Cells[14].Value == null) ? "0" : rowx.Cells[14].Value.ToString();
                    PERSONAL = (rowx.Cells[3].Value == null) ? "0" : rowx.Cells[3].Value.ToString();
                    EMPRESA_BREVE = (rowx.Cells[18].Value == null) ? "" : rowx.Cells[18].Value.ToString();


                    obj_personal_E = new BE_PERSONAL();
                    obj_personal_E.IDE_PERSONAL = Convert.ToInt32(IDE_PERSONAL);
                    obj_personal_E.FOTO = FOTO;
                    obj_personal_E.FOTOCHECK = FOTOCHECK;
                    obj_personal_E.NOMBRE_COMPLETO = PERSONAL;
                    obj_personal_E.EMPRESA_BREVE = EMPRESA_BREVE;
                    FotoReportId f2 = new FotoReportId(); //creamos un objeto del formulario hijo
                    DialogResult res = f2.ShowDialog();
                    if (f2.varFoto > 0)
                    {
                        //dgvPersonal.Rows[rowx.Index].Cells["FOTOCHECK"].Value = "SI";

                    }
                }


            }
        }

        private void btnQR_Click(object sender, EventArgs e)
        {
            int cantidad = 0;
            string TIPO_TRABAJADOR = "02";
            if (dgvPersonal.Rows.Count < 1)
            {
                MessageBox.Show("No existe personal", "Archivo");
            }
            else
            {


                DialogResult respuesta = MessageBox.Show("¿Desea genear QR masivos?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (respuesta == DialogResult.Yes)
                {


                    QRCodeEncoder generarCodigoQR = new QRCodeEncoder();
                    generarCodigoQR.QRCodeEncodeMode = ThoughtWorks.QRCode.Codec.QRCodeEncoder.ENCODE_MODE.BYTE;
                    generarCodigoQR.QRCodeScale = Int32.Parse("6"); //TAMAÑO DE IMAGEN


                    //lsNivelCorreccion 30%
                    generarCodigoQR.QRCodeErrorCorrect = ThoughtWorks.QRCode.Codec.QRCodeEncoder.ERROR_CORRECTION.H;

                    //'La versión "0" calcula automáticamente el tamaño
                    generarCodigoQR.QRCodeVersion = 0;


                    generarCodigoQR.QRCodeBackgroundColor = System.Drawing.Color.FromArgb(255, 255, 255, 255);
                    generarCodigoQR.QRCodeForegroundColor = System.Drawing.Color.FromArgb(255, 0, 0, 0);

                    for (int p = 0; p < dgvPersonal.Rows.Count ; p++)
                    {
                        try
                        {


                            string DNI = (dgvPersonal.Rows[p].Cells["DNI"].Value == null) ? "" : dgvPersonal.Rows[p].Cells["DNI"].Value.ToString();
                            string IDE_PERSONAL = (dgvPersonal.Rows[p].Cells["IDE_PERSONAL"].Value == null) ? "" : dgvPersonal.Rows[p].Cells["IDE_PERSONAL"].Value.ToString();
                            string FOTOCHECK = (dgvPersonal.Rows[p].Cells["FOTOCHECK"].Value == null) ? "NO" : dgvPersonal.Rows[p].Cells["FOTOCHECK"].Value.ToString();
                            TIPO_TRABAJADOR = (dgvPersonal.Rows[p].Cells["TIPO_TRABAJADOR"].Value == null) ? "02" : dgvPersonal.Rows[p].Cells["TIPO_TRABAJADOR"].Value.ToString();
                            string EMPRESA_BREVE = (dgvPersonal.Rows[p].Cells["EMPRESA_BREVE"].Value == null) ? "" : dgvPersonal.Rows[p].Cells["EMPRESA_BREVE"].Value.ToString();
                            string APELLIDO_PATERNO = (dgvPersonal.Rows[p].Cells["APELLIDO_PATERNO"].Value == null) ? "" : dgvPersonal.Rows[p].Cells["APELLIDO_PATERNO"].Value.ToString();
                            string APELLIDO_MATERNO = (dgvPersonal.Rows[p].Cells["APELLIDO_MATERNO"].Value == null) ? "" : dgvPersonal.Rows[p].Cells["APELLIDO_MATERNO"].Value.ToString();
                            string NOMBRES = (dgvPersonal.Rows[p].Cells["NOMBRES"].Value == null) ? "" : dgvPersonal.Rows[p].Cells["NOMBRES"].Value.ToString();
                            string CATEGORIA = (dgvPersonal.Rows[p].Cells["CATEGORIA"].Value == null) ? "" : dgvPersonal.Rows[p].Cells["CATEGORIA"].Value.ToString();
                            string ESPECIALIDAD = (dgvPersonal.Rows[p].Cells["ESPECIALIDAD"].Value == null) ? "" : dgvPersonal.Rows[p].Cells["ESPECIALIDAD"].Value.ToString();


                            if (FOTOCHECK == "NO" || FOTOCHECK == string.Empty )
                            {
                                //Con UTF-8 podremos añadir caracteres como ñ, tildes, etc.
                                string texto = EMPRESA_BREVE + ";" + DNI + ";" + APELLIDO_PATERNO + ";" + APELLIDO_MATERNO + ";" + NOMBRES + ";" + CATEGORIA + ";" + ESPECIALIDAD ;
                                imgQR.Image = generarCodigoQR.Encode(texto, System.Text.Encoding.UTF8);

                                if ((this.imgQR.Image == null))
                                {
                                    MessageBox.Show("No se ha generado el Código QR", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                }
                                else
                                {
                                    SaveFileDialog dlGuardar = new SaveFileDialog();
                                    String DirectorioFile = ConfigurationManager.AppSettings["FOTOS"];
                                    DirectorioFile = DirectorioFile + "QR\\";
                                    string NewName = DateTime.Today.Year.ToString() + "_" + DateTime.UtcNow.ToFileTimeUtc();

                                    imgQR.Image.Save(DirectorioFile + NewName + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);


                                    BL_PERSONAL obj = new BL_PERSONAL();
                                    DataTable dtResultado = new DataTable();

                                    dtResultado = obj.USP_ACTUALIZAR_FOTOS(IDE_PERSONAL, DirectorioFile, "", NewName + ".jpg");
                                    cantidad++;
                                    //MessageBox.Show("QR generado correctamente", "Archivo");

                                }
                            }


                        }
                        catch (Exception ex)
                        {

                        }
                    }


                    if (cantidad > 0)
                    {
                        EstructuraPersonal(TIPO_TRABAJADOR);
                        MessageBox.Show(cantidad.ToString() + " QR generados correctamente", "Archivo");


                    }
                    else
                    {
                        MessageBox.Show("No existen QR pendientes", "Archivo");
                    }
                }
            }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            if (dgvPersonal.Rows.Count < 1)
            {
                MessageBox.Show("No existe personal", "Archivo");
            }
            else
            {
                for (int p = 0; p < 1; p++)
                {
                    string TIPO_TRABAJADOR = (dgvPersonal.Rows[p].Cells["TIPO_TRABAJADOR"].Value == null) ? "02" : dgvPersonal.Rows[p].Cells["TIPO_TRABAJADOR"].Value.ToString();

                    obj_personal_E = new BE_PERSONAL();
                    obj_personal_E.TIPO_TRABAJADOR = TIPO_TRABAJADOR;
                    obj_personal_E.CENTRO_COSTO = cboCentroCosto.SelectedValue.ToString();

                }

                FotoReportVarios f2 = new FotoReportVarios(); //creamos un objeto del formulario hijo
                DialogResult res = f2.ShowDialog();
                if (f2.varFoto > 0)
                {

                }


            }
            
        }
    }
}
