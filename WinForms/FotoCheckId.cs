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
using System.IO;
using ThoughtWorks.QRCode;
using ThoughtWorks.QRCode.Codec;
using ThoughtWorks.QRCode.Codec.Data;
namespace WinForms
{
    public partial class FotoCheckId : Form
    {
        public int varFoto;
        public int varQR;
        public FotoCheckId()
        {
            InitializeComponent();
            String pathTmpQR;
            String DirectorioFile = ConfigurationManager.AppSettings["FOTOS"];
            String pathTmp = DirectorioFile + "\\FOTOS\\" + Fotocheck.obj_personal_E.FOTO.ToString();

            if (System.IO.File.Exists(pathTmp))
            {
                imgFoto.Image = Image.FromFile(pathTmp);
                lblFoto.Text = pathTmp;
            }
            else
            {
                BL_PERSONAL obj = new BL_PERSONAL();
                DataTable dtResultado = new DataTable();
               
                dtResultado = obj.USP_PERSONAL_FOTOCHECK_ID(Fotocheck.obj_personal_E.IDE_PERSONAL.ToString());
                if(dtResultado.Rows.Count > 0)
                {
                    string FOTO = dtResultado.Rows[0]["FOTO"].ToString();
                    if(FOTO !=string.Empty )
                    {
                        lblFoto.Text = DirectorioFile + "\\FOTOS\\" + FOTO;
                        imgFoto.Image = Image.FromFile(DirectorioFile + "\\FOTOS\\" + FOTO);
                    }

                    string FOTOCHECK = dtResultado.Rows[0]["FOTOCHECK"].ToString();
                    if (FOTOCHECK != string.Empty)
                    {
                       
                        lblFotoCheck.Text = DirectorioFile + "\\QR\\" + FOTOCHECK;
                        pathTmpQR = DirectorioFile + "\\QR\\" + FOTOCHECK;

                        if (System.IO.File.Exists(pathTmpQR))
                        {
                            imgQR.Image = Image.FromFile(pathTmpQR);
                            lblFotoCheck.Text = pathTmpQR;
                        }
                      
                    }
                }
               
            }

            pathTmpQR = DirectorioFile + "\\QR\\" + Fotocheck.obj_personal_E.FOTOCHECK.ToString();

            if (System.IO.File.Exists(pathTmpQR))
            {
                imgQR.Image = Image.FromFile(pathTmpQR);
                lblFotoCheck.Text = pathTmpQR;
                btnQr.Visible = false;
            }
            else
            {
                if (System.IO.File.Exists(lblFotoCheck.Text))
                {
                    btnQr.Visible = false;
                    imgQR.Image = Image.FromFile(lblFotoCheck.Text);
                }
                else
                {
                    btnQr.Visible = true;
                }

            }




            txtDNI.Text = Fotocheck.obj_personal_E.DOCUMENTO_IDENTIFICACION.ToString();
            txtPaterno.Text = Fotocheck.obj_personal_E.APELLIDO_PATERNO.ToString(); 
            txtMaterno.Text = Fotocheck.obj_personal_E.APELLIDO_MATERNO.ToString(); 
            txtNombre.Text = Fotocheck.obj_personal_E.NOMBRES.ToString();
            //txtDNI.Text = Fotocheck.obj_personal_E.IDE_PERSONAL.ToString(); 

        }

        private void FotoCheckId_Load(object sender, EventArgs e)
        {

        }

        private void btnFoto_Click(object sender, EventArgs e)
        {
            String DirectorioFile = ConfigurationManager.AppSettings["FOTOS"];
            //FOTOS Y QR NOMBRE DE LAS CARPETAS
            
            string DNI = Fotocheck.obj_personal_E.DOCUMENTO_IDENTIFICACION.ToString();
            string IDE_PERSONAL = Fotocheck.obj_personal_E.IDE_PERSONAL.ToString();
            string FOTO = Fotocheck.obj_personal_E.FOTO.ToString();


            DirectorioFile = DirectorioFile + "FOTOS\\" ; 

            //  crear carpeta 


            bool exists = System.IO.Directory.Exists(DirectorioFile);

            if (!exists)
                System.IO.Directory.CreateDirectory(DirectorioFile);

            OpenFileDialog openFileDialogCSV = new OpenFileDialog();

            openFileDialogCSV.InitialDirectory = Application.ExecutablePath.ToString();
            //openFileDialogCSV.Filter = "(*.*)|*.*";
            openFileDialogCSV.FilterIndex = 1;
            openFileDialogCSV.RestoreDirectory = true;

            if (openFileDialogCSV.ShowDialog() == DialogResult.OK)
            {
                this.txtFileToImport.Text = openFileDialogCSV.FileName.ToString();

                //File.Copy(txtFileToImport.Text, Path.Combine(DirectorioFile, Path.GetFileName(txtFileToImport.Text)), true);
                
                ////////////// FOTO ANTIGUA ////////////////////////////////////
                String pathTmp = lblFoto.Text;// DirectorioFile + FOTO;
                
                if (System.IO.File.Exists(pathTmp))
                {
                    FileStream file = new FileStream(pathTmp, FileMode.Open, FileAccess.Read); //file is opened
                    file.Close(); //then you must to close the file

                    if (!(this.imgFoto.Image == null))
                    {
                        this.imgFoto.Image.Dispose();
                        this.imgFoto.Image = null;
                        System.IO.File.Delete(pathTmp);
                    }

                   
                }

                //////////////////// FOTO NUEVO ////////////////////////////////
                FileInfo f1 = new FileInfo(this.txtFileToImport.Text);
                string NewName= DateTime.Today.Year.ToString() + "_" + DateTime.UtcNow.ToFileTimeUtc() ;

                f1.CopyTo(string.Format("{0}{1}{2}", DirectorioFile, NewName, f1.Extension),true );
                
                imgFoto.Image = Image.FromFile(DirectorioFile + NewName + f1.Extension);
                BL_PERSONAL obj = new BL_PERSONAL();
                DataTable dtResultado = new DataTable();
                lblFoto.Text = DirectorioFile+ NewName + f1.Extension;
                dtResultado = obj.USP_ACTUALIZAR_FOTOS(IDE_PERSONAL, DirectorioFile, NewName + f1.Extension, "");
                varFoto++;

                MessageBox.Show("Archivo guardado en la ruta :" + DirectorioFile, "Archivo");


            }
        }

        private void btnQr_Click(object sender, EventArgs e)
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

            try
            {

                //Con UTF-8 podremos añadir caracteres como ñ, tildes, etc.
                string texto = 

                    Fotocheck.obj_personal_E.EMPRESA_BREVE + ";" + Fotocheck.obj_personal_E.DOCUMENTO_IDENTIFICACION + ";" +
                    Fotocheck.obj_personal_E.APELLIDO_PATERNO + ";" + Fotocheck.obj_personal_E.APELLIDO_MATERNO + ";" +
                    Fotocheck.obj_personal_E.NOMBRES + ";" +
                    Fotocheck.obj_personal_E.CATEGORIA + ";" +
                    Fotocheck.obj_personal_E.ESPECIALIDAD;

   

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

                    //dlGuardar.Filter = "JPEG|*.jpg|Mapa de Bits|*.bmp|Gif|*.gif|PNG|*.png";
                    //dlGuardar.Title = "Guardar código QR";
                    //dlGuardar.CheckFileExists = true;
                    //dlGuardar.CheckPathExists = true;
                    //dlGuardar.RestoreDirectory = true;
                    //dlGuardar.FileName = NewName;


                    //dlGuardar.InitialDirectory = DirectorioFile;
                    //imgQR.Image.Save(dlGuardar.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);

                    imgQR.Image.Save(DirectorioFile + NewName + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);


                    BL_PERSONAL obj = new BL_PERSONAL();
                    DataTable dtResultado = new DataTable();
                    lblFotoCheck.Text = DirectorioFile + NewName + ".jpg";
                    string IDE_PERSONAL = Fotocheck.obj_personal_E.IDE_PERSONAL.ToString();
                    dtResultado = obj.USP_ACTUALIZAR_FOTOS(IDE_PERSONAL, DirectorioFile, "" , NewName + ".jpg");


                    MessageBox.Show("QR generado correctamente" , "Archivo");
                    btnQr.Visible = false;
                    varQR++;
                    //dlGuardar.ShowDialog();
                    //if ((dlGuardar.FileName != ""))
                    //{
                    //    switch (dlGuardar.FilterIndex)
                    //    {
                    //        case 1:
                    //            imgQR.Image.Save(dlGuardar.FileName,
                    //                System.Drawing.Imaging.ImageFormat.Jpeg);
                    //            break;
                    //        case 2:
                    //            imgQR.Image.Save(dlGuardar.FileName,
                    //                System.Drawing.Imaging.ImageFormat.Bmp);
                    //            break;
                    //        case 3:
                    //            imgQR.Image.Save(dlGuardar.FileName,
                    //                System.Drawing.Imaging.ImageFormat.Gif);
                    //            break;
                    //        case 4:
                    //            imgQR.Image.Save(dlGuardar.FileName,
                    //                System.Drawing.Imaging.ImageFormat.Png);
                    //            break;
                    //    }
                    //}


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Operacion no permitida", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
              
            }
        }
    }
}
