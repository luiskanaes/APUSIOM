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
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Security;

namespace WinForms
{
    public partial class frmMostrarDocumentos : Form
    {
        public string junta;
        public frmMostrarDocumentos()
        {
            InitializeComponent(); 
            
        }

        private void frmMostrarDocumentos_Load(object sender, EventArgs e)
        {
            lbljunta.Text = junta;

            BL_MARCAS obj = new BL_MARCAS();
            DataTable dtResultado = new DataTable();
            dtResultado = obj.SP_CONSULTAR_DOCUMENTOS_JUNTA(junta);

            if (dtResultado.Rows.Count > 0)
            {
                dgMarcas.DataSource = dtResultado;
                dgMarcas.AutoResizeColumns();
                dgMarcas.Visible = true;

                //DataGridViewLinkCell lnkCell = new DataGridViewLinkCell();
                //foreach (DataGridViewRow row in dgMarcas.Rows)
                //{
                //    row.Cells[0] = lnkCell; // (ERROR) Cell provided already belongs to a grid. This operation is not valid.
                //    row.Cells[1] = lnkCell;
                //    row.Cells[2] = lnkCell;
                //    row.Cells[3] = lnkCell;
                //    row.Cells[4] = lnkCell;


                //}

            }
            else
            {
                MessageBox.Show("NO SE ENCONTRARON REGISTROS!!!", "", MessageBoxButtons.OK);
                dgMarcas.DataSource = null;
                return;
            }

        }

        private void dgMarcas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //try {
            string filename = dgMarcas[e.ColumnIndex, e.RowIndex].Value.ToString();

            string urlbase;

            urlbase = "\\\\10.10.238.10/Documentos_V16082/5.- Calidad/1.-PMRT-16082.(nuevo)/8.0 Matriz/8.7 Matriz Tuberia/CAMPO al 20.10.2017";

            filename = urlbase + filename + ".pdf";

            txtDato.Text = filename;

            
            string ProgramPath = AppDomain.CurrentDomain.BaseDirectory;
            //jump back relative to the .exe-Path to the Resources Path
            string FileName = string.Format(filename, Path.GetFullPath(Path.Combine(ProgramPath, @"..\..\")));


            string localPath = @"G:\FTPTrialLocalPath\";
            string fileName = "arahimkhan.txt";

            FtpWebRequest requestFTPUploader = (FtpWebRequest)WebRequest.Create(filename);
            requestFTPUploader.Credentials = new NetworkCredential("Curquizo", "cu41630727.");
            requestFTPUploader.Method = WebRequestMethods.Ftp.UploadFile;

            FileInfo fileInfo = new FileInfo(localPath + fileName);
            FileStream fileStream = fileInfo.OpenRead();

            int bufferLength = 2048;
            byte[] buffer = new byte[bufferLength];

            Stream uploadStream = requestFTPUploader.GetRequestStream();
            int contentLength = fileStream.Read(buffer, 0, bufferLength);

            while (contentLength != 0)
            {
                uploadStream.Write(buffer, 0, contentLength);
                contentLength = fileStream.Read(buffer, 0, bufferLength);
            }

            uploadStream.Close();
            fileStream.Close();

            requestFTPUploader = null;



            //    //filename = filename.Replace(@"\\", @"/");

            //    if (File.Exists(filename))
            //    {
            //        Process.Start(filename);
            //    }
            //    else {
            //        MessageBox.Show("El documento no ha sido digitalizado....");
            //    }
            //}
            //catch { }


            //get current folderpath of the .exe
            //string ProgramPath = AppDomain.CurrentDomain.BaseDirectory;
            ////jump back relative to the .exe-Path to the Resources Path
            //string FileName = string.Format(filename, Path.GetFullPath(Path.Combine(ProgramPath, @"..\..\")));

            ////Open PDF
            ////System.Diagnostics.Process.Start(@"" + FileName + "");

            //int LOGON32_LOGON_NEW_CREDENTIALS = 0;
            ////SaveACopyfileToServer(txtDato.Text, FileName);
            //using (var impersonation = new ImpersonateUser("Curquizo", "10.10.238.10", "cu41630727.", LOGON32_LOGON_NEW_CREDENTIALS))
            //{
            //    var files = System.IO.Directory.GetFiles(FileName);
            //}


            //string user = "Curquizo";
            //string password = "cu41630727.";
            //string domain = "SSK";
            //string open = FileName;

            //string PwString = password;

            //char[] PasswordChars = PwString.ToCharArray();
            //SecureString Password = new SecureString();
            //foreach (char c in PasswordChars)
            //    Password.AppendChar(c);

            //System.Diagnostics.Process.Start(open, user, Password, domain);





            //      string path = FileName;
            //      string username = "Curquizo";
            //      string password = "cu41630727.";


            //      NetworkCredential theNetworkCredential = new
            //NetworkCredential(@"SSK.LOCAL\Curquizo", "cu41630727.");
            //      CredentialCache theNetCache = new CredentialCache();
            //      theNetCache.Add(new Uri(@"\\10.10.238.10"), "Basic", theNetworkCredential);
            //      string[] theFolders = Directory.GetDirectories(@""+ FileName + "");

            //var PathToTheFileInTheServer = FileName;
            //var sourceFileInfo = new System.IO.FileInfo(PathToTheFileInTheServer);


            //ProcessStartInfo processStartInfo = new ProcessStartInfo();
            //processStartInfo.WorkingDirectory = FileName;
            //processStartInfo.FileName = filename;
            //processStartInfo.Arguments = filename;
            //processStartInfo.Domain = "SSK.LOCAL";
            //processStartInfo.UserName = "Curquizo";

            //string PwString = "cu41630727.";

            //char[] PasswordChars = PwString.ToCharArray();
            //SecureString Password = new SecureString();
            //foreach (char c in PasswordChars)
            //    Password.AppendChar(c);
            //processStartInfo.Password = Password;
            //processStartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            //processStartInfo.CreateNoWindow = true;
            //processStartInfo.UseShellExecute = false;
            //Process process = Process.Start(processStartInfo);

        }


     

    //    public static void SaveACopyfileToServer(string filePath, string savePath)
    //{
    //    var directory = Path.GetDirectoryName(savePath).Trim();
    //    var username = "Curquizo";
    //    var password = "cu41630727.";
    //    var filenameToSave = Path.GetFileName(savePath);

        //    if (!directory.EndsWith("\\"))
        //        filenameToSave = "\\" + filenameToSave;

        //    var 
        //    //        command = "NET USE " + directory + " /delete";
        //    //ExecuteCommand(command, 5000);

        //    command = "NET USE " + directory + " /user:" + username + " " + password;
        //    ExecuteCommand(command, 5000);

        //    command = " copy \"" + filePath + "\"  \"" + directory + filenameToSave + "\"";

        //    ExecuteCommand(command, 5000);


        //    command = "NET USE " + directory + " /delete";
        //    ExecuteCommand(command, 5000);
        //}

        //    public static int ExecuteCommand(string command, int timeout)
        //    {
        //        var processInfo = new ProcessStartInfo("cmd.exe", "/C " + command)
        //        {
        //            CreateNoWindow = true,
        //            UseShellExecute = false,
        //            WorkingDirectory = "C:\\",
        //        };

        //        var process = Process.Start(processInfo);
        //        process.WaitForExit(timeout);
        //        var exitCode = process.ExitCode;
        //        process.Close();
        //        return exitCode;
        //    }


    }
}
