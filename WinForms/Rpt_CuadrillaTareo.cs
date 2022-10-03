using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessEntity;
using BusinessLogic;
using Microsoft.Reporting.WinForms;
using UserCode;
using ICSharpCode.SharpZipLib.Zip;
namespace WinForms
{
    public partial class Rpt_CuadrillaTareo : Form
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());
        String DirectorioFile = ConfigurationManager.AppSettings["FileParte"];
        public Rpt_CuadrillaTareo()
        {
            InitializeComponent();
            ListarEmpresa();
        }

        private void Rpt_CuadrillaTareo_Load(object sender, EventArgs e)
        {

            this.ReportViewer1.RefreshReport();
            this.ReportViewer1.RefreshReport();
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string ls_error = "";
            UserCode.Conexion cn = new UserCode.Conexion();

            bool lb_conectado = cn.ProbarConexion(ref ls_error);

            if (lb_conectado == true)
            {
                ConsultarTareo();
                ListarIngenieros();
                button1.Visible = true;
                btnTotal.Visible = true;
                


            }
            else
            {

                MessageBox.Show(ls_error);
            }
        }
        protected void ConsultarTareo()
        {

            BL_ASIGNACION_TAREO obj = new BL_ASIGNACION_TAREO();
            DataTable dtResultado = new DataTable();


            dtResultado = obj.Listar_TareoFecha(Convert.ToInt32(cboEmpresa.SelectedValue.ToString()), cboCentroCosto.SelectedValue.ToString(), dateTareo.Value.Date.ToString("dd/MM/yyyy"));

            if (dtResultado.Rows.Count > 0)
            {

                string FLG_ESTADO = dtResultado.Rows[0]["FLG_ESTADO"].ToString();
                string FLG_MIGRADO = dtResultado.Rows[0]["FLG_MIGRADO"].ToString();
                lblEstado.Text = FLG_ESTADO;



            }
            else
            {
                lblEstado.Text = "1";
            }


        }
        protected void ListarIngenieros()
        {
            BL_ASIGNACION_TAREAS obj = new BL_ASIGNACION_TAREAS();
            DataTable dtResultado = new DataTable();

            if (lblEstado.Text == "1")
            {

                dtResultado = obj.SP_OBTENER_EQUIPO_TRABAJO_TAREO(cboCentroCosto.SelectedValue.ToString(), "1", "1", "", dateTareo.Value.Date.ToString("dd/MM/yyyy"));
                if (dtResultado.Rows.Count > 0)
                {
                    cboIngeniero.ValueMember = "ID_PERSONAL";
                    cboIngeniero.DisplayMember = "NOMBRES";
                    cboIngeniero.DataSource = dtResultado;
                    ListarCapataz();
                }
            }
            else
            {

                dtResultado = obj.OBTENER_PERSONAL_RESPONSABLES_TAREO(cboCentroCosto.SelectedValue.ToString(), Convert.ToInt32(cboEmpresa.SelectedValue), dateTareo.Value.Date.ToString("dd/MM/yyyy"), 1, "");
                if (dtResultado.Rows.Count > 0)
                {
                    cboIngeniero.ValueMember = "ID_PERSONAL";
                    cboIngeniero.DisplayMember = "NOMBRES";
                    cboIngeniero.DataSource = dtResultado;
                    ListarCapataz();
                }
            }
        }
        protected void ListarCapataz()
        {
            BL_ASIGNACION_TAREAS obj = new BL_ASIGNACION_TAREAS();
            DataTable dtResultado = new DataTable();
            if (lblEstado.Text == "1")
            {


                //dtResultado = obj.obtener_PersonalCategoria(cboCentroCosto.SelectedValue.ToString(), Convert.ToInt32(cboEmpresa.SelectedValue), "RESPONSABLE CUADRILLA", cboIngeniero.SelectedValue.ToString(), dateTareo.Value.Date.ToString("dd/MM/yyyy"));
                dtResultado = obj.SP_OBTENER_EQUIPO_TRABAJO_TAREO(cboCentroCosto.SelectedValue.ToString(), "1", "2", cboIngeniero.SelectedValue.ToString(), dateTareo.Value.Date.ToString("dd/MM/yyyy"));

                if (dtResultado.Rows.Count > 0)
                {



                    checkedListBox1.DataSource = dtResultado;
                    checkedListBox1.ValueMember = "ID_PERSONAL";
                    checkedListBox1.DisplayMember = "NOMBRES";
                }
                else
                {


                    MessageBox.Show("No existen responsables de cuadrillas asignados al" + Environment.NewLine +
                        "Sr. " + cboIngeniero.Text + " " + Environment.NewLine +
                        "Ingresar Opción : Configuración -> Asignación de responsables", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            else
            {

                dtResultado = obj.OBTENER_PERSONAL_RESPONSABLES_TAREO(cboCentroCosto.SelectedValue.ToString(), Convert.ToInt32(cboEmpresa.SelectedValue), dateTareo.Value.Date.ToString("dd/MM/yyyy"), 2, cboIngeniero.SelectedValue.ToString());
                if (dtResultado.Rows.Count > 0)
                {


                    checkedListBox1.DataSource = dtResultado;
                    checkedListBox1.ValueMember = "ID_PERSONAL";
                    checkedListBox1.DisplayMember = "NOMBRES";

                }
            }

        }

        private void cboIngeniero_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListarCapataz();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //int i;
            //string s;
            //s = "Checked items:\n";
            //for (i = 0; i <= (checkedListBox1.Items.Count - 1); i++)
            //{
            //    if (checkedListBox1.GetItemChecked(i))
            //    {
            //        s = s + "Item " + (i + 1).ToString() + " = " + checkedListBox1.Items[i].ToString() + "\n";
            //    }
            //}
            //MessageBox.Show(s);

            int estado = 1;
            if (rdoNuevo.Checked == true)
            {
                estado = 1;
            }
            else if (rdoHH.Checked == true)
            {
                estado = 0;
            }

            BL_ASIGNACION_TAREAS obj = new BL_ASIGNACION_TAREAS();
            //DataTable dtResultado = new DataTable();
            DataTable dt = new DataTable();
            string DNI = string.Empty;
            int TOTAL_HOJAS = 0;
            string CAPATAZ = string.Empty;
            string INGENIERO = string.Empty;
            foreach (var item in checkedListBox1.CheckedItems)
            {
                var row = (item as DataRowView).Row;

                dt.Clear();

                dt = obj.SP_RPT_LISTAR_CUADRILLA_TAREO_PERSONAL(cboCentroCosto.SelectedValue.ToString(), row["ID_PERSONAL"].ToString(), dateTareo.Value.Date.ToString("dd/MM/yyyy"), estado, cboIngeniero.SelectedValue.ToString());

                if (dt.Rows.Count > 0)
                {
                    TOTAL_HOJAS = Convert.ToInt32(dt.Rows[0]["MAXIMO"].ToString());
                    CAPATAZ = dt.Rows[0]["CAPATAZ"].ToString();
                    INGENIERO = dt.Rows[0]["INGENIERO"].ToString();
                }


                //DataView dv = dt.DefaultView;
                //dv.RowFilter = "GRUPO = " + "1 ";
                for (int i = 1; i <= 5; i++)
                {
                    //DataRow[] result = dt.Select("grupo = '1'");
                    DataRow[] result = dt.Select("grupo =" + i.ToString());

                    if (result.Length > 0)
                    {
                        foreach (DataRow Xrow in result)
                        {
                            //Console.WriteLine("{0}, {1}", Xrow[0], Xrow[1]);
                            DNI = DNI + Xrow[1] + ",";
                        }

                        rpt_Cuadro(row["ID_PERSONAL"].ToString(), row["NOMBRES"].ToString(), estado, DNI, i, TOTAL_HOJAS, INGENIERO, CAPATAZ);
                        DNI = string.Empty;
                    }
                }


                //s = s + row["ID_PERSONAL"] + ": " + row["NOMBRES"] + "\n"; 
                //MessageBox.Show(row["ID_PERSONAL"] + ": " + row["NOMBRES"]);
            }
            //MessageBox.Show(s);
        }
        protected void rpt_Cuadro(string IDE_CAPATAZ, string NOMBRE, int ESTADO, string DNI, int i, int TOTAL_HOJAS, string INGENIERO, string CAPATAZ)
        {
            this.ReportViewer1.Refresh();


            DataTable dsCustomers = GetData(IDE_CAPATAZ, ESTADO);
            ReportDataSource datasource = new ReportDataSource("DataSet1", dsCustomers);

            DataTable dsResponsables = GetDataResponsables(IDE_CAPATAZ);
            ReportDataSource dtResponsable = new ReportDataSource("DataSet2", dsResponsables);

            DataTable dsCuadrilla = GetDataCuadrilla(IDE_CAPATAZ, ESTADO, DNI, i, TOTAL_HOJAS);
            ReportDataSource dtCuadrilla = new ReportDataSource("DataSet3", dsCuadrilla);

            if (dsCustomers.Rows.Count > 0)
            {
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.Visible = true;
                ReportViewer1.LocalReport.DataSources.Clear();

                ReportViewer1.LocalReport.DataSources.Add(datasource);
                ReportViewer1.LocalReport.DataSources.Add(dtResponsable);
                ReportViewer1.LocalReport.DataSources.Add(dtCuadrilla);

                ReportViewer1.RefreshReport();
                ReportViewer1.Show();
                ReportViewer1.LocalReport.DisplayName = IDE_CAPATAZ;
                //byte[] byteViewer = ReportViewer1.LocalReport.Render("PDF");
                //SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                //saveFileDialog1.Filter = "*Archivos PDF  (*.pdf)|*.pdf";

                try
                {
                    byte[] byteViewer = ReportViewer1.LocalReport.Render("EXCEL");
                    //byte[] byteViewer = ReportViewer1.LocalReport.Render("PDF");
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    //saveFileDialog1.Filter = "Microsoft Excel Workbook(*.xls) | *.xls";
                    saveFileDialog1.Filter = "Archivos de Excel (*.xls;*.xlsx)|*.xls;*.xlsx";
                    //saveFileDialog1.Filter = "*Archivos PDF  (*.pdf)|*.pdf";
                    saveFileDialog1.Title = "Tareo SSK";
                    saveFileDialog1.FilterIndex = 2;
                    string Nombre_file = cboCentroCosto.SelectedValue.ToString() + "_" + dateTareo.Value.Date.ToString("yyyyMMdd") + "_ING_" + INGENIERO + "_RESP_" + CAPATAZ + "_HOJA_" + i.ToString();
                    saveFileDialog1.FileName = Nombre_file;
                    saveFileDialog1.RestoreDirectory = true;
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        FileStream newFile = new FileStream(saveFileDialog1.FileName, FileMode.Create);
                        newFile.Write(byteViewer, 0, byteViewer.Length);
                        newFile.Close();
                    }
                    //System.Diagnostics.Process.Start(saveFileDialog1.FileName); para abrir el excel o archivo
                }
                catch (Exception ex)
                {

                }



            }
            else
            {
                ReportViewer1.Visible = false;
                ReportViewer1.LocalReport.DataSources.Clear();
            }
        }
        private DataTable GetData(string IDE_CAPATAZ, int ESTADO)
        {

            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("uspRPT_ASIGNACION_TAREAS_POR_FECHA", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 99999;
            cmd.Parameters.Add("@IDE_CECOS", SqlDbType.VarChar, 10).Value = cboCentroCosto.SelectedValue.ToString();
            cmd.Parameters.Add("@FEC_TAREO ", SqlDbType.VarChar, 10).Value = dateTareo.Value.Date.ToString("dd/MM/yyyy");
            cmd.Parameters.Add("@IDE_CAPATAZ", SqlDbType.VarChar, 10).Value = IDE_CAPATAZ;
            cmd.Parameters.Add("@IDE_INGCAMPO", SqlDbType.VarChar, 10).Value = cboIngeniero.SelectedValue.ToString();
            cmd.Parameters.Add("@DISCIPLINA", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@NUEVO ", SqlDbType.Int).Value = ESTADO;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            da.Fill(dt);

            return dt;
        }
        private DataTable GetDataResponsables(string IDE_CAPATAZ)
        {

            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("uspRPT_ASIGNACION_TAREAS_RESPONSABLE", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 99999;
            cmd.Parameters.Add("@IDE_CECOS", SqlDbType.VarChar, 10).Value = cboCentroCosto.SelectedValue.ToString();
            cmd.Parameters.Add("@IDE_CAPATAZ", SqlDbType.VarChar, 10).Value = IDE_CAPATAZ;
            cmd.Parameters.Add("@IDE_INGCAMPO", SqlDbType.VarChar, 10).Value = cboIngeniero.SelectedValue.ToString();

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            da.Fill(dt);

            return dt;
        }
        private DataTable GetDataCuadrilla(string IDE_CAPATAZ, int ESTADO, string DNI, int HOJA, int HOJA_TOTAL)
        {

            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("SP_RPT_LISTAR_CUADRILLA_TAREO", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 99999;
            cmd.Parameters.Add("@IDE_CECOS", SqlDbType.VarChar, 10).Value = cboCentroCosto.SelectedValue.ToString();
            cmd.Parameters.Add("@IDE_PADRE", SqlDbType.VarChar, 10).Value = IDE_CAPATAZ;
            cmd.Parameters.Add("@FECHA", SqlDbType.VarChar, 10).Value = dateTareo.Value.Date.ToString("dd/MM/yyyy");
            cmd.Parameters.Add("@NUEVO", SqlDbType.Int).Value = ESTADO;
            cmd.Parameters.Add("@LISTA", SqlDbType.VarChar, 4000).Value = DNI;
            cmd.Parameters.Add("@HOJA", SqlDbType.Int).Value = HOJA;
            cmd.Parameters.Add("@HOJA_TOTAL", SqlDbType.Int).Value = HOJA_TOTAL;
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            da.Fill(dt);

            return dt;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, true);
                }
            }
            else
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, false);
                }
            }
        }

        private void btnTotal_Click(object sender, EventArgs e)
        {



            int estado = 1;
            if (rdoNuevo.Checked == true)
            {
                estado = 1;
            }
            else if (rdoHH.Checked == true)
            {
                estado = 0;
            }

            BL_ASIGNACION_TAREAS obj = new BL_ASIGNACION_TAREAS();
            string IDE_INGCAMPO = string.Empty;
            string IDE_CAPATAZ = string.Empty;

            DialogResult respuesta = MessageBox.Show("¿Desea descagar todos los partes?", "Mensaje SSK", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (respuesta == DialogResult.Yes)
            {
                DataTable dtResultado = new DataTable();
                DataTable dtCapataz = new DataTable();
                DataTable dt = new DataTable();

                string DNI = string.Empty;
                int TOTAL_HOJAS = 0;
                string CAPATAZ = string.Empty;
                string INGENIERO = string.Empty;

                dtResultado = obj.SP_OBTENER_PERSONAL_TAREO(cboCentroCosto.SelectedValue.ToString(), 1, "", dateTareo.Value.Date.ToString("dd/MM/yyyy"));

                for (int i = 0; i < dtResultado.Rows.Count; i++)
                {
                    IDE_INGCAMPO = dtResultado.Rows[i]["IDE_INGCAMPO"].ToString();

                    dtCapataz.Clear();
                    dtCapataz = obj.SP_OBTENER_PERSONAL_TAREO(cboCentroCosto.SelectedValue.ToString(), 2, IDE_INGCAMPO, dateTareo.Value.Date.ToString("dd/MM/yyyy"));
                    for (int j = 0; j < dtCapataz.Rows.Count; j++)
                    {
                        IDE_CAPATAZ = dtCapataz.Rows[j]["IDE_CAPATAZ"].ToString();


                        ////////////////////////////////
                        dt.Clear();
                        dt = obj.SP_RPT_LISTAR_CUADRILLA_TAREO_PERSONAL(cboCentroCosto.SelectedValue.ToString(), IDE_CAPATAZ, dateTareo.Value.Date.ToString("dd/MM/yyyy"), estado, IDE_INGCAMPO);

                        if (dt.Rows.Count > 0)
                        {
                            TOTAL_HOJAS = Convert.ToInt32(dt.Rows[0]["MAXIMO"].ToString());
                            CAPATAZ = dt.Rows[0]["CAPATAZ"].ToString();
                            INGENIERO = dt.Rows[0]["INGENIERO"].ToString();
                        }


                        //DataView dv = dt.DefaultView;
                        //dv.RowFilter = "GRUPO = " + "1 ";
                        for (int p = 1; p <= 5; p++)
                        {
                            //DataRow[] result = dt.Select("grupo = '1'");
                            DataRow[] result = dt.Select("grupo =" + p.ToString());

                            if (result.Length > 0)
                            {
                                foreach (DataRow Xrow in result)
                                {
                                    //Console.WriteLine("{0}, {1}", Xrow[0], Xrow[1]);
                                    DNI = DNI + Xrow[1] + ",";
                                }

                                rpt_CuadroZipeado(IDE_CAPATAZ.ToString(), "", estado, DNI, p, TOTAL_HOJAS, INGENIERO, CAPATAZ);
                                DNI = string.Empty;
                            }
                        }
                    }

                }


                //Zipeando folder con las fotos y copiandolo la ruta de destino            
                //COMPRIMIR ARCHIVOS
                string Folder = cboCentroCosto.SelectedValue.ToString() + "_" + dateTareo.Value.Date.ToString("yyyyMMdd");
                string rutaFinal = DirectorioFile + "\\" + Folder;
                string archivo_fotos = Folder + ".zip";

                //File.Delete(Startuppath + archivo_fotos);
                ZipOutputStream zip = new ZipOutputStream(File.Create(DirectorioFile + archivo_fotos));
                zip.SetLevel(9);
                string rutaZip = DirectorioFile + "\\" + Folder + "\\";
                ComprimirCarpeta(rutaZip, rutaZip, zip);
                zip.Finish();
                zip.Close();

              
                UploadFile(rutaFinal + ".zip");
            }
        }
        public static void ComprimirCarpeta(string RootFolder, string CurrentFolder, ZipOutputStream zStream)
        {
            string[] SubFolders = Directory.GetDirectories(CurrentFolder);
            //Llama de nuevo al metodo recursivamente para cada carpeta 
            foreach (string Folder in SubFolders)
            {
                ComprimirCarpeta(RootFolder, Folder, zStream);
            }
            string relativePath = CurrentFolder.Substring(RootFolder.Length) + "/";
            //the path "/" is not added or a folder will be created 
            //at the root of the file 
            if (relativePath.Length > 1)
            {
                ZipEntry dirEntry;
                dirEntry = new ZipEntry(relativePath);
                dirEntry.DateTime = DateTime.Now;
            }
            //Añade todos los ficheros de la carpeta al zip 
            foreach (string file in Directory.GetFiles(CurrentFolder))
            {
                AñadirFicheroaZip(zStream, relativePath, file);
            }
        }
        private static void AñadirFicheroaZip(ZipOutputStream zStream, string relativePath, string file)
        {
            byte[] buffer = new byte[4096];
            //the relative path is added to the file in order to place the file within 
            //this directory in the zip 
            string fileRelativePath = (relativePath.Length > 1 ? relativePath : string.Empty) + Path.GetFileName(file);
            ZipEntry entry = new ZipEntry(fileRelativePath);
            entry.DateTime = DateTime.Now;
            zStream.PutNextEntry(entry);
            using (FileStream fs = File.OpenRead(file))
            {
                int sourceBytes;
                do
                {
                    sourceBytes = fs.Read(buffer, 0, buffer.Length);
                    zStream.Write(buffer, 0, sourceBytes);
                } while (sourceBytes > 0);
            }

        }
        protected void UploadFile(string filename)
        {
            try
            {
               
                // get the exact file name from the path
                String strFile = System.IO.Path.GetFileName(filename);

                // create an instance fo the web service

                //TestUploader.Uploader.FileUploader srv = new TestUploader.Uploader.FileUploader();
                //new TareoClient().Insertar_TAREO();

                // get the file information form the selected file
                FileInfo fInfo = new FileInfo(filename);

                // get the length of the file to see if it is possible
                // to upload it (with the standard 4 MB limit)
                long numBytes = fInfo.Length;
                double dLen = Convert.ToDouble(fInfo.Length / 1000000);

                // Default limit of 4 MB on web server
                // have to change the web.config to if
                // you want to allow larger uploads
                if (dLen < 8)
                {
                    // set up a file stream and binary reader for the 
                    // selected file
                    FileStream fStream = new FileStream(filename, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fStream);

                    // convert the file to a byte array
                    byte[] data = br.ReadBytes((int)numBytes);
                    br.Close();

                    // pass the byte array (file) and file name to the web service
                    string sTmp = "OK";
                    fStream.Close();
                    fStream.Dispose();

                    // this will always say OK unless an error occurs,
                    // if an error occurs, the service returns the error message
                    MessageBox.Show("File " + strFile + " Upload Status: " + sTmp, "File Upload");
                    if (sTmp == "OK")
                    {
                        Stream myStream;
                        SaveFileDialog saveFileDialog = new SaveFileDialog();

                        saveFileDialog.Filter = "zip files (*.zip)|*.zip|All files (*.*)|*.*";
                        saveFileDialog.FilterIndex = 2;
                        saveFileDialog.RestoreDirectory = true;
                        saveFileDialog.FileName = strFile;
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            if ((myStream = saveFileDialog.OpenFile()) != null)
                            {
                                // Code to write the stream goes here.
                                //byte[] zipFile = strFile.ToString();
                                string file = saveFileDialog.FileName;
                                myStream.Write(data, 0, data.Length);
                                myStream.Close();
                            }
                        }
                    }
                    else
                    {

                    }


                }
                else
                {
                    // Display message if the file was too large to upload
                    MessageBox.Show("The file " + strFile + "selected exceeds the size limit for uploads.", "File Size");
                }
            }
            catch (Exception ex)
            {
                // display an error message to the user
                MessageBox.Show(ex.Message.ToString(), "Upload Error");
            }
        }
        protected void rpt_CuadroZipeado(string IDE_CAPATAZ, string NOMBRE, int ESTADO, string DNI, int i, int TOTAL_HOJAS, string INGENIERO, string CAPATAZ)
        {

            string Startuppath = DirectorioFile;

            //COMPRIMIR ARCHIVOS
            string Folder = cboCentroCosto.SelectedValue.ToString() + "_" + dateTareo.Value.Date.ToString("yyyyMMdd");
            string rutaFinal = DirectorioFile + "\\" + Folder;

            if (!System.IO.Directory.Exists(rutaFinal))
            {
                Directory.CreateDirectory(rutaFinal);
            }

            string archivo_fotos = Folder + ".zip";

            this.ReportViewer1.Refresh();


            DataTable dsCustomers = GetData(IDE_CAPATAZ, ESTADO);
            ReportDataSource datasource = new ReportDataSource("DataSet1", dsCustomers);

            DataTable dsResponsables = GetDataResponsables(IDE_CAPATAZ);
            ReportDataSource dtResponsable = new ReportDataSource("DataSet2", dsResponsables);

            DataTable dsCuadrilla = GetDataCuadrilla(IDE_CAPATAZ, ESTADO, DNI, i, TOTAL_HOJAS);
            ReportDataSource dtCuadrilla = new ReportDataSource("DataSet3", dsCuadrilla);

            if (dsCustomers.Rows.Count > 0)
            {
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.Visible = true;
                ReportViewer1.LocalReport.DataSources.Clear();

                ReportViewer1.LocalReport.DataSources.Add(datasource);
                ReportViewer1.LocalReport.DataSources.Add(dtResponsable);
                ReportViewer1.LocalReport.DataSources.Add(dtCuadrilla);

                ReportViewer1.RefreshReport();
                ReportViewer1.Show();
                ReportViewer1.LocalReport.DisplayName = IDE_CAPATAZ;
                //byte[] byteViewer = ReportViewer1.LocalReport.Render("PDF");
                //SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                //saveFileDialog1.Filter = "*Archivos PDF  (*.pdf)|*.pdf";

                try
                {
                    byte[] byteViewer = ReportViewer1.LocalReport.Render("EXCEL");
                    //byte[] byteViewer = ReportViewer1.LocalReport.Render("PDF");
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    //saveFileDialog1.Filter = "Microsoft Excel Workbook(*.xls) | *.xls";
                    saveFileDialog1.Filter = "Archivos de Excel (*.xls;*.xlsx)|*.xls;*.xlsx";
                    //saveFileDialog1.Filter = "*Archivos PDF  (*.pdf)|*.pdf";
                    saveFileDialog1.Title = "Tareo SSK";
                    saveFileDialog1.FilterIndex = 2;
                    string Nombre_file = cboCentroCosto.SelectedValue.ToString() + "_" + dateTareo.Value.Date.ToString("yyyyMMdd") + "_ING_" + INGENIERO + "_RESP_" + CAPATAZ + "_HOJA_" + i.ToString();
                    saveFileDialog1.FileName = rutaFinal + "\\" + Nombre_file + ".xls";
                    saveFileDialog1.RestoreDirectory = true;


                    FileStream newFile = new FileStream(saveFileDialog1.FileName, FileMode.Create);
                    newFile.Write(byteViewer, 0, byteViewer.Length);
                    newFile.Close();


                    //if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    //{
                    //    FileStream newFile = new FileStream(saveFileDialog1.FileName, FileMode.Create);
                    //    newFile.Write(byteViewer, 0, byteViewer.Length);
                    //    newFile.Close();
                    //}
                    //System.Diagnostics.Process.Start(saveFileDialog1.FileName); para abrir el excel o archivo
                }
                catch (Exception ex)
                {

                }



            }
            else
            {
                ReportViewer1.Visible = false;
                ReportViewer1.LocalReport.DataSources.Clear();
            }
        }
    }
    

}
