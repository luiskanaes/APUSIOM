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

using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.IO.Compression;

namespace WinForms.RRHH
{
    public partial class frmReporteDescansoMedico : Form
    {
        private int totalFiles;
        private int filesExtracted;
        public frmReporteDescansoMedico()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BL_TAREO_EMPLEADO obj = new BL_TAREO_EMPLEADO();
            DataTable dtResultado = new DataTable();
            dtResultado = obj.SP_REPORTE_EMPLEADOS_DESCANSO_MEDICO("0001", cboMes.SelectedValue.ToString(), cboAnio.SelectedValue.ToString(), cboUbicacion.SelectedValue.ToString());

            if (dtResultado.Rows.Count > 0)
            {

                //gridDetalle.Rows.Clear();
                //gridDetalle.Columns.Clear();
                //gridDetalle.Refresh();
                dgTareo.DataSource = dtResultado;
                dgTareo.AutoResizeColumns();
                dgTareo.Visible = true;

                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                dgTareo.Columns.Add(btn);
                btn.HeaderText = "";
                btn.Text = "Sustentos";
                btn.Name = "btn";
                btn.UseColumnTextForButtonValue = true;

            }

        }



      




        private void btnGrabar_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "export.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //ToCsV(dataGridView1, @"c:\export.xls");
                ToCsV(dgTareo, sfd.FileName); // Here dataGridview1 is your grid view name
            }
        }

        private void ToCsV(DataGridView dGV, string filename)
        {
            string stOutput = "";
            // Export titles:
            string sHeaders = "";

            for (int j = 0; j < dGV.Columns.Count; j++)
                sHeaders = sHeaders.ToString() + Convert.ToString(dGV.Columns[j].HeaderText) + "\t";
            stOutput += sHeaders + "\r\n";
            // Export data.
            for (int i = 0; i < dGV.RowCount; i++)
            {
                string stLine = "";
                for (int j = 0; j < dGV.Rows[i].Cells.Count; j++)
                    stLine = stLine.ToString() + Convert.ToString(dGV.Rows[i].Cells[j].Value) + "\t";
                stOutput += stLine + "\r\n";
            }
            Encoding utf16 = Encoding.GetEncoding(1254);
            byte[] output = utf16.GetBytes(stOutput);
            FileStream fs = new FileStream(filename, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(output, 0, output.Length); //write the encoded file
            bw.Flush();
            bw.Close();
            fs.Close();
        }

        private void frmReporteDescansoMedico_Load(object sender, EventArgs e)
        {
            cargasMeses();
            cargasAnios();
              cargaUbicaciones();
        }
        private void cargaUbicaciones()
        {

            BL_TAREO_EMPLEADO obj = new BL_TAREO_EMPLEADO();
            DataTable dtResultado = new DataTable();
            dtResultado = obj.SP_CONSULTAR_UBICACIONES_DM("");//frmLogin.obj_user_E.IDE_USUARIO);
            if (dtResultado.Rows.Count > 0)
            {

                cboUbicacion.ValueMember = "ID";
                cboUbicacion.DisplayMember = "DESCRIPCION";
                cboUbicacion.DataSource = dtResultado;

            }

        }
        private void cargasMeses()
        {
            cboMes.DataSource = new BindingSource(meses, null);
            cboMes.DisplayMember = "Value";
            cboMes.ValueMember = "Key";
            cboMes.SelectedValue = 1;

        }

         

        private void cargasAnios()
        {
            cboAnio.DataSource = new BindingSource(anios, null);
            cboAnio.DisplayMember = "Value";
            cboAnio.ValueMember = "Key";
            cboAnio.SelectedValue = 2017;
        }

        public static Dictionary<int, string> meses = new Dictionary<int, string>()
        {
            {1,"ENERO"},
            {2,"FEBRERO"},
            {3,"MARZO"},
            {4,"ABRIL"},
            {5,"MAYO"},
            {6,"JUNIO"},
            {7,"JULIO"},
            {8,"AGOSTO"},
            {9,"SEPTIEMBRE"},
            {10,"OCTUBRE"},
            {11,"NOVIEMBRE"},
            {12,"DICIEMBRE"}
        };

        public static Dictionary<int, string> anios = new Dictionary<int, string>()
        {
            {2017,"2017"},
            {2018,"2018"},
            {2019,"2019"},
            {2020,"2020"}
        };

        private void dgTareo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String DirectorioFile = ConfigurationManager.AppSettings["DESCANSO_MEDICO"];

            if (dgTareo.Columns[e.ColumnIndex].Name == "btn")
            {
                 
                try
                {
                    
                    //string rootFolder = ".\\";
                    //string archiveName = "Archive.zip";
                    string rootFolder = DirectorioFile + "2018-" + dgTareo.Rows[e.RowIndex].Cells[0].Value.ToString();
                    string archiveName = dgTareo.Rows[e.RowIndex].Cells[0].Value.ToString()+".zip";
                    


                    List<string> exceptions = new List<string>();
                    

                    int filesAdded = CreateArchive(rootFolder,
                        exceptions, archiveName);
                    Console.WriteLine(String.Format(" {0} file(s) added ",
                        filesAdded));
                    Console.ReadLine();
                    ////////////////////////////////////////////////////////////////////////
                    ////////////////////////////////////////////////////////////////////////
                    var fbd = new FolderBrowserDialog();
                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        var localPath = Path.Combine(rootFolder+"\\"+ archiveName);
                        var remote_address = Path.Combine(fbd.SelectedPath + "\\" + archiveName);
                        //File.Copy(localPath, remote_address, true);
                        File.Copy(localPath, remote_address, true);
                        File.SetAttributes(remote_address, FileAttributes.Normal);

                        MessageBox.Show("Archivo guardado en la ruta :" + remote_address, "Archivo");
                    }


                }
                catch (Exception ex)
                {
                    // No need to rethrow the exception as for our purposes its handled.
                    Console.WriteLine("Exception during processing {0}", ex);
                }
            }


        }





        public static int CreateArchive(string folder,
                IList<string> exceptions, string archiveName)
        {
            int filesCount = 0;
            string folderFullPath = Path.GetFullPath(folder);
            string archivePath = Path.Combine(folderFullPath, archiveName);
            if (File.Exists(archivePath))
            {
                //Console.WriteLine(string.Format(@"File '{0}' already exists. Overwrite (y/n): ", archiveName));
                //string read = Console.ReadLine();
                //if (read.ToLower() == "y")
                //{
                    File.Delete(archivePath);
                //}
                //else
                //{
                //    Console.WriteLine(string.Format(@"Archive {0} already exists. 
                //        Aborting!", archivePath));
                //    return 0;
                //}
            }
            IEnumerable<string> files = Directory.EnumerateFiles(folder,
                    "*.*", SearchOption.AllDirectories);
            using (ZipArchive archive = System.IO.Compression.ZipFile.Open(archivePath, ZipArchiveMode.Create))
            {
                foreach (string file in files)
                {
                    if (!Excluded(file, exceptions))
                    {
                        try
                        {
                            var addFile = Path.GetFullPath(file);
                            if (addFile != archivePath)
                            {
                                addFile = addFile.Substring(folderFullPath.Length);
                                Console.WriteLine("Adding " + addFile);
                                archive.CreateEntryFromFile(file, addFile);
                                filesCount++;
                            }
                        }
                        catch (IOException ex)
                        {
                            Console.WriteLine(@"Failed to add {0} due to error : 
                            {1} \n Ignoring it!", file, ex.Message);
                        }
                    }
                }
            }
            return filesCount;
        }

        private static bool Excluded(string file, IList<string> exceptions)
        {
            List<String> folderNames = (from folder in exceptions
                                        where folder.StartsWith(@"\")
                                            || folder.StartsWith(@"/")
                                        select folder).ToList<string>();
            if (!exceptions.Contains(Path.GetExtension(file)))
            {
                foreach (string folderException in folderNames)
                {
                    if (Path.GetDirectoryName(file).Contains(folderException))
                    {
                        return true;
                    }
                }
                return false;
            }
            return true;
        }

        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //// Get file name.
            //string name = saveFileDialog1.FileName;
            //// Write to the file name selected.
            //// ... You can write the text from a TextBox instead of a string literal.
            //File.WriteAllText(name, "test");
        }
    }
}
