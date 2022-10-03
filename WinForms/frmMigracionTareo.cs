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
using ICSharpCode.SharpZipLib.Zip;

namespace WinForms
{
    public partial class frmMigracionTareo : Form
    {
        string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
        String DirectorioFile = ConfigurationManager.AppSettings["FileTareos"];
        //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ToString());

        //SvTareo.TareoClient objServicio = new SvTareo.TareoClient();
        string empresa = string.Empty;
        string centroCosto = string.Empty;
        string fecha = string.Empty;
        string fechaNombre = string.Empty;
        public int varfMigracion;
        public frmMigracionTareo()
        {
            InitializeComponent();
            empresa = frmTareoDiario.obj_asignacion_E.IDE_EMPRESA.ToString();
            fecha = frmTareoDiario.obj_asignacion_E.FECHA_TAREO;
            centroCosto = frmTareoDiario.obj_asignacion_E.CENTRO_COSTO;
            fechaNombre = frmTareoDiario.obj_asignacion_E.FECHA_TAREO_FORMAT;

        }

        private void frmMigracionTareo_Load(object sender, EventArgs e)
        {
            int anio = DateTime.Now.Year;
            lblMensaje.Text = "Copyright © " + Convert.ToString(anio) + " SSK Ingeniería y Construcción SAC";
        }
        protected void ExportarFileTareo()
        {
            string fileNombre = string.Empty;
            DataTable dt = GetTareoTxt();

            //Build the Text file data.
            string txt = string.Empty;
            int col = 0;

            string Startuppath = DirectorioFile;// Application.StartupPath + "/";
            fileNombre = centroCosto + "_" + fechaNombre + "_TAREO" + ".txt";
            string csv = string.Empty;

            //Add the Header row for txt file.
            foreach (DataColumn column in dt.Columns)
            {
                col += 1;
                if (col == 19)// cantidad de columnas de la tabla asistencia
                {
                    csv += column.ColumnName;
                }
                else
                {
                    csv += column.ColumnName + ',';
                }

            }

            //Add new line.
            csv += "\r\n";
            col = 0;
            //Adding the Rows
            foreach (DataRow row in dt.Rows)
            {
                col = 0;
                foreach (DataColumn cell in dt.Columns)
                {
                    col += 1;
                    //Add the Data rows.
                    if (col == 19)// cantidad de columnas de la tabla tareo
                    {
                        csv += row[cell].ToString().Replace(",", ";");
                    }
                    else
                    {
                        csv += row[cell].ToString().Replace(",", ";") + ',';
                    }

                }

                //Add new line.
                csv += "\r\n";
            }

            //COMPRIMIR ARCHIVOS
            string Folder = centroCosto + "_" + fechaNombre;
            string rutaFinal = DirectorioFile + "\\" + Folder;

            if (!System.IO.Directory.Exists(rutaFinal))
            {
                Directory.CreateDirectory(rutaFinal);
            }


            string Destinationpath = DirectorioFile + Folder + "\\" + fileNombre; //File Extension as your requirement .dat or .txt 
            File.WriteAllText(Destinationpath, csv);
            string archivo_fotos = Folder + ".zip";

            txtRutaTareo.Text = Destinationpath;

            BE_ARCHIVOS_MIGRACION obj = new BE_ARCHIVOS_MIGRACION();
            BL_ARCHIVOS_MIGRACION Lobj = new BL_ARCHIVOS_MIGRACION();
            obj.IDE_ENVIO = 0;
            obj.ARCHIVO = fileNombre;
            obj.RUTA_FILE = Destinationpath;
            obj.IDE_EMPRESA = Convert.ToInt32(empresa);
            obj.CENTRO_COSTO = centroCosto;
            obj.USUARIO_ENVIA = frmLogin.obj_user_E.IDE_USUARIO;
            obj.FECHA_TAREO = fecha;
            obj.FLG_ENVIO = "0";
            obj.TIPO_FILE = "T";
            obj.FILE_ZIPEADO = Startuppath + archivo_fotos;

            int rpta = Lobj.Mant_Insert_File(obj);
            if (rpta > 0)
            {
                ExportarFileAsistencia();
            }

                    //MessageBox.Show("File Created Successfully in " + Destinationpath);
            
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
        protected void ExportarFileAsistencia()
        {
            string fileNombre = string.Empty;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string qry = "SELECT [IDE_ASISTENCIA], [IDE_PERSONAL], [FEC_ASISTENCIA] ,[IDE_ESTADO],[ESTADO_DIARIO],  [CCENTRO],[IDE_EMPRESA],[USUARIO_REGISTRA],[FECHA_REGISTRO] FROM ASISTENCIA_PERSONAL WHERE IDE_EMPRESA =" + empresa + " and CCENTRO = '" + centroCosto+ "' and convert(varchar(10),[FEC_ASISTENCIA],103) = '" + fecha + "'";

                using (SqlCommand cmd = new SqlCommand(qry))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);

                            //Build the Text file data.
                            string txt = string.Empty;
                            int col = 0;
                           
                            string Startuppath = DirectorioFile;// Application.StartupPath + "/";
                            fileNombre = centroCosto + "_" + fechaNombre + "_ASISTENCIA" + ".txt";

                            string csv = string.Empty;
                            //Add the Header row for txt file.
                            foreach (DataColumn column in dt.Columns)
                            {
                                col += 1;
                                if (col == 9)// cantidad de columnas de la tabla asistencia
                                {
                                    csv += column.ColumnName;
                                }
                                else
                                {
                                    csv += column.ColumnName + ',';
                                }

                            }

                            //Add new line.
                            csv += "\r\n";
                            col = 0;
                            //Adding the Rows
                            foreach (DataRow row in dt.Rows)
                            {
                                col = 0;
                                foreach (DataColumn cell in dt.Columns)
                                {
                                    col += 1;
                                    //Add the Data rows.
                                    if (col == 9)// cantidad de columnas de la tabla tareo
                                    {
                                        csv += row[cell].ToString().Replace(",", ";");
                                    }
                                    else
                                    {
                                        csv += row[cell].ToString().Replace(",", ";") + ',';
                                    }

                                }

                                //Add new line.
                                csv += "\r\n";
                            }

                            string Folder = centroCosto + "_" + fechaNombre;
                            string rutaFinal = DirectorioFile + "\\" + Folder;

                            if (!System.IO.Directory.Exists(rutaFinal))
                            {
                                Directory.CreateDirectory(rutaFinal);
                            }
                            

                            string Destinationpath = DirectorioFile + Folder + "\\" + fileNombre; //File Extension as your requirement .dat or .txt 
                            File.WriteAllText(Destinationpath, csv);
                            string archivo_fotos = Folder + ".zip";

                            txtRutaAsistencia.Text = Destinationpath;

                            BE_ARCHIVOS_MIGRACION obj = new BE_ARCHIVOS_MIGRACION();
                            BL_ARCHIVOS_MIGRACION Lobj = new BL_ARCHIVOS_MIGRACION();
                            obj.IDE_ENVIO = 0;
                            obj.ARCHIVO = fileNombre;
                            obj.RUTA_FILE = Destinationpath;
                            obj.IDE_EMPRESA = Convert.ToInt32(empresa);
                            obj.CENTRO_COSTO = centroCosto;
                            obj.USUARIO_ENVIA = frmLogin.obj_user_E.IDE_USUARIO;
                            obj.FECHA_TAREO = fecha;
                            obj.FLG_ENVIO = "0";
                            obj.TIPO_FILE = "A";
                            obj.FILE_ZIPEADO = Startuppath + archivo_fotos;
                            int rpta = Lobj.Mant_Insert_File(obj);
                            if(rpta> 0)
                            {
                                //ExportarFilePersona();
                                ExportarFile_ASIGNACION_TAREO();
                            }
                            //MessageBox.Show("File Created Successfully");
                        }
                    }
                }
            }

        }
        protected void ExportarFilePersona()
        {
            string fileNombre = string.Empty;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string qry = "SELECT IDE_PERSONAL,[CENTRO_COSTO],[NOMBRES] ,[APELLIDO_PATERNO] ,[APELLIDO_MATERNO],[DOCUMENTO_IDENTIFICACION] ,[TIPO_TRABAJADOR],[ID_CATEGORIA] ,[ID_ESPECIALIDAD] ,[IDE_EMPRESA],[IDE_CECOS] ,[IDE_CAPATAZ] ,[IDE_INGCAMPO],[IDE_GRUPO],[FLG_LIBRE],[FLG_ESTADOS] FROM PERSONAL WHERE IDE_EMPRESA =" + empresa + " and CENTRO_COSTO = '" + centroCosto  + "' AND [FLG_ESTADOS] =1";

                using (SqlCommand cmd = new SqlCommand(qry))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);

                            //Build the Text file data.
                            string txt = string.Empty;
                            int col = 0;

                            string Startuppath = DirectorioFile;// Application.StartupPath + "/";
                            fileNombre = centroCosto + "_" + fechaNombre + "_PERSONAL" + ".txt";
                            string csv = string.Empty;
                            //Add the Header row for txt file.
                            foreach (DataColumn column in dt.Columns)
                            {
                                col += 1;
                                if (col == 16)// cantidad de columnas de la tabla asistencia
                                {
                                    csv += column.ColumnName;
                                }
                                else
                                {
                                    csv += column.ColumnName + ',';
                                }

                            }

                            //Add new line.
                            csv += "\r\n";
                            col = 0;
                            //Adding the Rows
                            foreach (DataRow row in dt.Rows)
                            {
                                col = 0;
                                foreach (DataColumn cell in dt.Columns)
                                {
                                    col += 1;
                                    //Add the Data rows.
                                    if (col == 16)// cantidad de columnas de la tabla tareo
                                    {
                                        csv += row[cell].ToString().Replace(",", ";");
                                    }
                                    else
                                    {
                                        csv += row[cell].ToString().Replace(",", ";") + ',';
                                    }
                                }
                                //Add new line.
                                csv += "\r\n";
                            }

                            //COMPRIMIR ARCHIVOS
                            string Folder = centroCosto + "_" + fechaNombre;
                            string rutaFinal = DirectorioFile + "\\" + Folder;

                            if (!System.IO.Directory.Exists(rutaFinal))
                            {
                                Directory.CreateDirectory(rutaFinal);
                            }
                           

                            string Destinationpath = DirectorioFile + Folder + "\\" + fileNombre; //File Extension as your requirement .dat or .txt 
                            File.WriteAllText(Destinationpath, csv);
                            string archivo_fotos = Folder + ".zip";

                            txtFilePersona.Text = Destinationpath;
                            
                            BE_ARCHIVOS_MIGRACION obj = new BE_ARCHIVOS_MIGRACION();
                            BL_ARCHIVOS_MIGRACION Lobj = new BL_ARCHIVOS_MIGRACION();
                            obj.IDE_ENVIO = 0;
                            obj.ARCHIVO = fileNombre;
                            obj.RUTA_FILE = Destinationpath;
                            obj.IDE_EMPRESA = Convert.ToInt32(empresa);
                            obj.CENTRO_COSTO = centroCosto;
                            obj.USUARIO_ENVIA = frmLogin.obj_user_E.IDE_USUARIO;
                            obj.FECHA_TAREO = fecha;
                            obj.FLG_ENVIO = "0";
                            obj.TIPO_FILE = "PERSONAL";
                            obj.FILE_ZIPEADO = Startuppath + archivo_fotos;
                            int rpta = Lobj.Mant_Insert_File(obj);
                            if (rpta > 0)
                            {
                                ExportarFile_ASIGNACION_TAREO();
                                //MessageBox.Show("File Created Successfully");
                            }

                        }
                    }
                }
            }
        }
        protected void ExportarFile_ASIGNACION_TAREO()
        {
            string fileNombre = string.Empty;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string qry = "SELECT [IDE_TAREO_ASIGNACION] ,  [IDE_EMPRESA],  [IDE_CECOS],  [INT_ANIO],  [INT_MES],  [INT_SEM],  [COD_PROYECTO],  [FEC_TAREO],NOMBRE_DIA,[IDE_TURNO],  [IDE_CLIENTE],  [IDE_UBICACIONES],  [FLG_ESTADO],[FLG_MIGRADO],  [USUARIO_REGISTRO],  [FECHA_REGISTRO] FROM ASIGNACION_TAREO WHERE IDE_EMPRESA =" + empresa + " and IDE_CECOS = '" + centroCosto + "' AND [FLG_MIGRADO] =0 and convert(varchar(10),[FEC_TAREO],103) = '" + fecha + "'";

                using (SqlCommand cmd = new SqlCommand(qry))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);

                            //Build the Text file data.
                            string txt = string.Empty;
                            int col = 0;

                            string Startuppath = DirectorioFile;// Application.StartupPath + "/";
                            fileNombre = centroCosto + "_" + fechaNombre + "_ASIGNACION_TAREO" + ".txt";
                            //string Destinationpath = Startuppath + fileNombre;
                            string csv = string.Empty;
                            //Add the Header row for txt file.
                            foreach (DataColumn column in dt.Columns)
                            {
                                col += 1;
                                if (col == 16)// cantidad de columnas de la tabla asistencia
                                {
                                    csv += column.ColumnName;
                                }
                                else
                                {
                                    csv += column.ColumnName + ',';
                                }

                            }

                            //Add new line.
                            csv += "\r\n";
                            col = 0;
                            //Adding the Rows
                            foreach (DataRow row in dt.Rows)
                            {
                                col = 0;
                                foreach (DataColumn cell in dt.Columns)
                                {
                                    col += 1;
                                    //Add the Data rows.
                                    if (col == 16)// cantidad de columnas de la tabla tareo
                                    {
                                        csv += row[cell].ToString().Replace(",", ";");
                                    }
                                    else
                                    {
                                        csv += row[cell].ToString().Replace(",", ";") + ',';
                                    }
                                }
                                //Add new line.
                                csv += "\r\n";
                            }

                            //COMPRIMIR ARCHIVOS
                            string Folder = centroCosto + "_" + fechaNombre;
                            string rutaFinal = DirectorioFile + "\\" + Folder;

                            if (!System.IO.Directory.Exists(rutaFinal))
                            {
                                Directory.CreateDirectory(rutaFinal);
                            }
                            

                            string Destinationpath = DirectorioFile + Folder + "\\" + fileNombre; //File Extension as your requirement .dat or .txt 
                            File.WriteAllText(Destinationpath, csv);
                            string archivo_fotos = Folder + ".zip";

                            txtTareo.Text = Destinationpath;


                            BE_ARCHIVOS_MIGRACION obj = new BE_ARCHIVOS_MIGRACION();
                            BL_ARCHIVOS_MIGRACION Lobj = new BL_ARCHIVOS_MIGRACION();
                            obj.IDE_ENVIO = 0;
                            obj.ARCHIVO = fileNombre;
                            obj.RUTA_FILE = Destinationpath;
                            obj.IDE_EMPRESA = Convert.ToInt32(empresa);
                            obj.CENTRO_COSTO = centroCosto;
                            obj.USUARIO_ENVIA = frmLogin.obj_user_E.IDE_USUARIO;
                            obj.FECHA_TAREO = fecha;
                            obj.FLG_ENVIO = "0";
                            obj.TIPO_FILE = "TAREO";
                            obj.FILE_ZIPEADO = Startuppath + archivo_fotos;
                            int rpta = Lobj.Mant_Insert_File(obj);
                            if (rpta > 0)
                            {
                                //MessageBox.Show("File Created Successfully");
                                ExportarFile_ASIGNACION_TAREAS();
                            }
                        }
                    }
                }
            }
        }
        protected void ExportarFile_ASIGNACION_TAREAS()
        {
            string fileNombre = string.Empty;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string qry = "SELECT  [IDE_TAREA] ,  [IDE_TAREO_ASIGNACION] ,  [ITEM_ACTIVIDAD] ,  [IDE_ACTIVIDAD] ,  [DES_ACTIVIDAD] ,  [DET_TAREA] ,  [ID_FRENTE],  [DES_FRENTE],  [CTA_COSTO],  [DES_TAREA],  [DES_UNIDAD],  [HORA_INICIO],  [HORA_FIN],  [PROGRAMADO],[EJECUTADO],  [FLG_ESTADO],  [OBSERVACIONES],  [AREAS],  [DES_AREAS],[RETRABAJO],  [IDE_INGCAMPO],  [IDE_CAPATAZ],  [USUARIO_REGISTRO],  [FECHA_REGISTRO],COD_MIGRACION FROM ASIGNACION_TAREAS WHERE [IDE_TAREO_ASIGNACION] = (SELECT [IDE_TAREO_ASIGNACION] FROM ASIGNACION_TAREO WHERE IDE_EMPRESA =" + empresa + " and IDE_CECOS = '" + centroCosto + "' AND [FLG_MIGRADO] =0 and convert(varchar(10),[FEC_TAREO],103) = '" + fecha + "')";

                using (SqlCommand cmd = new SqlCommand(qry))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);

                            //Build the Text file data.
                            string txt = string.Empty;
                            int col = 0;

                            string Startuppath = DirectorioFile;// Application.StartupPath + "/";
                            fileNombre = centroCosto + "_" + fechaNombre + "_ASIGNACION_TAREAS" + ".txt";
                            //string Destinationpath = Startuppath + fileNombre;
                            string csv = string.Empty;
                            //Add the Header row for txt file.
                            foreach (DataColumn column in dt.Columns)
                            {
                                col += 1;
                                if (col == 25)// cantidad de columnas de la tabla asistencia
                                {
                                    csv += column.ColumnName;
                                }
                                else
                                {
                                    csv += column.ColumnName + ',';
                                }

                            }

                            //Add new line.
                            csv += "\r\n";
                            col = 0;
                            //Adding the Rows
                            foreach (DataRow row in dt.Rows)
                            {
                                col = 0;
                                foreach (DataColumn cell in dt.Columns)
                                {
                                    col += 1;
                                    //Add the Data rows.
                                    if (col == 25)// cantidad de columnas de la tabla tareo
                                    {
                                        csv += row[cell].ToString().Replace(",", ";");
                                    }
                                    else
                                    {
                                        csv += row[cell].ToString().Replace(",", ";") + ',';
                                    }
                                }
                                //Add new line.
                                csv += "\r\n";
                            }

                            //COMPRIMIR ARCHIVOS
                            string Folder = centroCosto + "_" + fechaNombre;
                            string rutaFinal = DirectorioFile + "\\" + Folder;

                            if (!System.IO.Directory.Exists(rutaFinal))
                            {
                                Directory.CreateDirectory(rutaFinal);
                            }
                           

                            string Destinationpath = DirectorioFile + Folder + "\\" + fileNombre; //File Extension as your requirement .dat or .txt 
                            File.WriteAllText(Destinationpath, csv);


                            string archivo_fotos = Folder  + ".zip";
                            

                            txtTareas.Text = Destinationpath;

                            BE_ARCHIVOS_MIGRACION obj = new BE_ARCHIVOS_MIGRACION();
                            BL_ARCHIVOS_MIGRACION Lobj = new BL_ARCHIVOS_MIGRACION();
                            obj.IDE_ENVIO = 0;
                            obj.ARCHIVO = fileNombre;
                            obj.RUTA_FILE = Destinationpath;
                            obj.IDE_EMPRESA = Convert.ToInt32(empresa);
                            obj.CENTRO_COSTO = centroCosto;
                            obj.USUARIO_ENVIA = frmLogin.obj_user_E.IDE_USUARIO;
                            obj.FECHA_TAREO = fecha;
                            obj.FLG_ENVIO = "0";
                            obj.TIPO_FILE = "TAREAS";
                            obj.FILE_ZIPEADO = Startuppath + archivo_fotos;
                            int rpta = Lobj.Mant_Insert_File(obj);

                            if (rpta > 0)
                            {
                                ExportarTareo_registros();
                                //MessageBox.Show("Archivo creado con éxito");
                            }

                        }
                    }
                }
            }
        }
        private void btnGenerarFile_Click(object sender, EventArgs e)
        {
            
            if (!System.IO.Directory.Exists(DirectorioFile))
            {
                Directory.CreateDirectory(DirectorioFile);
            }

            ExportarFileTareo();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {

            if (txtRutaAsistencia.Text == string.Empty || txtRutaTareo.Text == string.Empty || txtTareas.Text == string.Empty || txtTareo.Text == string.Empty)
            {
                MessageBox.Show("No ha generado los archivos de envio", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {


                if (AccesoInternet())
                {
                    SvTareo.TareoClient objServicio = new SvTareo.TareoClient();
                    string ls_error = "";
                    bool lb_conectado = objServicio.ProbarConexionTareo(ref ls_error);

                    if (lb_conectado == true)
                    {

                        BL_ARCHIVOS_MIGRACION obj = new BL_ARCHIVOS_MIGRACION();
                        DataTable dtResultado = new DataTable();

                        dtResultado = obj.ARCHIVOS_MIGRACION_POR_OBRA_FECHA(Convert.ToInt32(empresa), centroCosto, fecha);

                        for (int i = 0; i < dtResultado.Rows.Count; i++)
                        {
                            int nro = Convert.ToInt32(dtResultado.Rows[i]["Row"].ToString());
                            string RUTA_FILE = dtResultado.Rows[i]["RUTA_FILE"].ToString();
                            string TIPO_FILE = dtResultado.Rows[i]["TIPO_FILE"].ToString();
                            string FILE_ZIPEADO = dtResultado.Rows[i]["FILE_ZIPEADO"].ToString();
                            string ARCHIVO = dtResultado.Rows[i]["ARCHIVO"].ToString();
                            //UploadFile(RUTA_FILE, empresa, centroCosto, fecha, TIPO_FILE, nro, FILE_ZIPEADO);
                            UploadFile(FILE_ZIPEADO, empresa, centroCosto, fecha, TIPO_FILE, nro, ARCHIVO, dtResultado.Rows.Count);
                        }

                    }
                    else
                    {

                        MessageBox.Show(ls_error);
                    }
                }

                else
                {
                    MessageBox.Show("Sin acceso a internet", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        private void UploadFile(string filename, string empresa, string centro, string fecha, string tipo, int i,string ARCHIVO, int cantidad)
        {
            try
            {
                SvTareo.TareoClient objServicio = new SvTareo.TareoClient();
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
                if (dLen < 4)
                {
                    // set up a file stream and binary reader for the 
                    // selected file
                    FileStream fStream = new FileStream(filename, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fStream);

                    // convert the file to a byte array
                    byte[] data = br.ReadBytes((int)numBytes);
                    br.Close();

                    // pass the byte array (file) and file name to the web service
                    string sTmp = objServicio.UploadFile(data, strFile ,empresa,  centro,  fecha,tipo, ARCHIVO, fechaNombre,i, cantidad);
                    fStream.Close();
                    fStream.Dispose();

                    // this will always say OK unless an error occurs,
                    // if an error occurs, the service returns the error message
                    MessageBox.Show("File " + strFile + " Upload Status: " + sTmp, "File Upload");
                    if (sTmp=="OK")
                    {
                        if (i == 1)
                        {
                            pictureBox1.Image = global::WinForms.Properties.Resources.check ;
                        }
                        else if (i == 2)
                        {
                            pictureBox2.Image = global::WinForms.Properties.Resources.check;
                        }
                        else if (i == 3)
                        {
                            pictureBox3.Image = global::WinForms.Properties.Resources.check;
                        }
                        else if (i == 4)
                        {
                            pictureBox4.Image = global::WinForms.Properties.Resources.check;
                        }
                        else
                        {
                            pictureBox5.Image = global::WinForms.Properties.Resources.check;
                        }


                        BE_ARCHIVOS_MIGRACION obj = new BE_ARCHIVOS_MIGRACION();
                        BL_ARCHIVOS_MIGRACION Lobj = new BL_ARCHIVOS_MIGRACION();
                        obj.IDE_ENVIO = 0;
                        obj.ARCHIVO = strFile;
                        obj.RUTA_FILE = "";
                        obj.IDE_EMPRESA = Convert.ToInt32(empresa);
                        obj.CENTRO_COSTO = centroCosto;
                        obj.USUARIO_ENVIA = frmLogin.obj_user_E.IDE_USUARIO;
                        obj.FECHA_TAREO = fecha;
                        obj.FLG_ENVIO = "1";

                        int rpta = Lobj.Mant_Insert_File(obj);

                        BL_TAREO objx = new BL_TAREO();
                        objx.UpdateMigracion(Convert.ToInt32(empresa), centroCosto, fecha);
                        varfMigracion++;
                    }
                    else
                    {
                        if (i == 1)
                        {
                            pictureBox1.Image = global::WinForms.Properties.Resources.Delete ;
                        }
                        else if (i == 2)
                        {
                            pictureBox2.Image = global::WinForms.Properties.Resources.Delete;
                        }
                        else if (i == 3)
                        {
                            pictureBox3.Image = global::WinForms.Properties.Resources.Delete;
                        }
                        else if (i == 4)
                        {
                            pictureBox4.Image = global::WinForms.Properties.Resources.Delete;
                        }
                        else
                        {
                            pictureBox5.Image = global::WinForms.Properties.Resources.Delete;
                        }
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
        protected void ExportarTareo_registros()
        {
           string fileNombre = string.Empty;
           DataTable  dt = GetDataTareo();

            //Build the Text file data.
            string txt = string.Empty;
            int col = 0;

            string Startuppath = DirectorioFile;// Application.StartupPath + "/";
            fileNombre = centroCosto + "_" + fechaNombre + "_TAREO_REGISTRO" + ".txt";

            string csv = string.Empty;
            //Add the Header row for txt file.
            foreach (DataColumn column in dt.Columns)
            {
                col += 1;
                if (col == 8)// cantidad de columnas de la tabla asistencia
                {
                    csv += column.ColumnName;
                }
                else
                {
                    csv += column.ColumnName + ',';
                }

            }

            //Add new line.
            csv += "\r\n";
            col = 0;
            //Adding the Rows
            foreach (DataRow row in dt.Rows)
            {
                col = 0;
                foreach (DataColumn cell in dt.Columns)
                {
                    col += 1;
                    //Add the Data rows.
                    if (col == 8)// cantidad de columnas de la tabla tareo
                    {
                        csv += row[cell].ToString().Replace(",", ";");
                    }
                    else
                    {
                        csv += row[cell].ToString().Replace(",", ";") + ',';
                    }

                }

                //Add new line.
                csv += "\r\n";
            }

            //COMPRIMIR ARCHIVOS
            string Folder = centroCosto + "_" + fechaNombre;
            string rutaFinal = DirectorioFile + "\\" + Folder;

            if (!System.IO.Directory.Exists(rutaFinal))
            {
                Directory.CreateDirectory(rutaFinal);
            }


            string Destinationpath = DirectorioFile + Folder + "\\" + fileNombre; //File Extension as your requirement .dat or .txt 
            File.WriteAllText(Destinationpath, csv);
            string archivo_fotos = Folder + ".zip";


            //Zipeando folder con las fotos y copiandolo la ruta de destino            

            //File.Delete(Startuppath + archivo_fotos);
            ZipOutputStream zip = new ZipOutputStream(File.Create(Startuppath + archivo_fotos));
            zip.SetLevel(9);
            string rutaZip = DirectorioFile + "\\" + Folder + "\\";
            ComprimirCarpeta(rutaZip, rutaZip, zip);
            zip.Finish();
            zip.Close();

            txtTareoRegistro.Text = Destinationpath;

            BE_ARCHIVOS_MIGRACION obj = new BE_ARCHIVOS_MIGRACION();
            BL_ARCHIVOS_MIGRACION Lobj = new BL_ARCHIVOS_MIGRACION();
            obj.IDE_ENVIO = 0;
            obj.ARCHIVO = fileNombre;
            obj.RUTA_FILE = Destinationpath;
            obj.IDE_EMPRESA = Convert.ToInt32(empresa);
            obj.CENTRO_COSTO = centroCosto;
            obj.USUARIO_ENVIA = frmLogin.obj_user_E.IDE_USUARIO;
            obj.FECHA_TAREO = fecha;
            obj.FLG_ENVIO = "0";
            obj.TIPO_FILE = "TR";
            obj.FILE_ZIPEADO = Startuppath + archivo_fotos;
            int rpta = Lobj.Mant_Insert_File(obj);
            if (rpta > 0)
            {

                MessageBox.Show("Archivo creado con éxito");
            }
                          
            

        }
        private DataTable GetDataTareo()
        {
            SqlConnection con = new SqlConnection(constr);
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("uspSEL_TAREO_DIA_PROCESAR", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FECHA", SqlDbType.VarChar ,10).Value = fecha ;
            cmd.Parameters.Add("@CCENTRO", SqlDbType.VarChar, 10).Value = centroCosto;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            da.Fill(dt);

            return dt;
        }
        private DataTable GetTareoTxt()
        {
            SqlConnection con = new SqlConnection(constr);
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("uspSEL_TAREO_TXT", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FECHA", SqlDbType.VarChar, 10).Value = fecha;
            cmd.Parameters.Add("@CCENTRO", SqlDbType.VarChar, 10).Value = centroCosto;

            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            da.Fill(dt);

            return dt;
        }
    }
}
