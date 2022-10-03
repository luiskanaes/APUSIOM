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
namespace WinForms
{
    public partial class frmProcesarTareo : Form
    {
        //private static List<BusinessEntity.BE_ASISTENCIA_PERSONAL> LstAsistencia = new List<BusinessEntity.BE_ASISTENCIA_PERSONAL>();
        string empresa, centro_costo;
        public frmProcesarTareo()
        {
            InitializeComponent();
            centro_costo =  frmTareoDiario.obj_asignacion_E.CENTRO_COSTO.ToString();
            empresa  = frmTareoDiario.obj_asignacion_E.IDE_EMPRESA.ToString();
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            if (dateInicio.Value.Date > dateTermino.Value.Date)
            {
                MessageBox.Show("La fecha inicio no puede ser mayor a la fecha de termino", "Mensaje Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult respuesta = MessageBox.Show("¿Desea Migrar Actividades de Trabajo?, Una vez realizado la operación, todo cambio de HH u otros deberá ser realizado directamente en el Gestor", "Migración Registros", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (respuesta == DialogResult.Yes)
                {
                    string a = dateInicio.Value.Date.ToString("dd/MM/yyyy");
                    string b = dateTermino.Value.Date.ToString("dd/MM/yyyy");

                    TimeSpan t = Convert.ToDateTime(b) - Convert.ToDateTime(a);
                    double NrOfDays = t.TotalDays;



                    BL_TAREO obj = new BL_TAREO();
                    DataTable dtResultado = new DataTable();
                    DataTable dtAsistencia = new DataTable();
                    BL_ASISTENCIA_PERSONAL objAsistencia = new BL_ASISTENCIA_PERSONAL();
                    int rptAsistencia = 0, rptTareo = 0;
                    DateTime inicio, fechaProcesar;
                    for (int i = 0; i <= NrOfDays; i++)
                    {
                        inicio = Convert.ToDateTime(a);
                        fechaProcesar = inicio.AddDays(i);

                        //MessageBox.Show("dia " + fechaProcesar.Date.ToString("dd/MM/yyyy"), "Mensaje Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        dtResultado = obj.Tareo_fecha(Convert.ToInt32(empresa), centro_costo, fechaProcesar.Date.ToString("dd/MM/yyyy"));
                        dtAsistencia = objAsistencia.ListarAsistencia_fecha(Convert.ToInt32(empresa), centro_costo, fechaProcesar.Date.ToString("dd/MM/yyyy"));
                        if (dtResultado.Rows.Count > 0)
                        {
                            SvTareo.BE_ASISTENCIA_PERSONAL objAsis = new SvTareo.BE_ASISTENCIA_PERSONAL();

                            string FLG_MIGRADO = dtResultado.Rows[0]["MIGRADO"].ToString();
                            if (FLG_MIGRADO == "False")
                            {
                                for (int x = 0; x < dtAsistencia.Rows.Count; x++)
                                {
                                    objAsis.IDE_PERSONAL = dtAsistencia.Rows[x]["IDE_PERSONAL"].ToString();
                                    objAsis.FEC_ASISTENCIA = dtAsistencia.Rows[x]["FEC_ASISTENCIA"].ToString();
                                    objAsis.IDE_ESTADO = dtAsistencia.Rows[x]["IDE_ESTADO"].ToString();
                                    objAsis.ESTADO_DIARIO = dtAsistencia.Rows[x]["ESTADO_DIARIO"].ToString();
                                    objAsis.CCENTRO = dtAsistencia.Rows[x]["CCENTRO"].ToString();
                                    objAsis.IDE_EMPRESA = dtAsistencia.Rows[x]["IDE_EMPRESA"].ToString();
                                    objAsis.USUARIO_REGISTRA = dtAsistencia.Rows[x]["USUARIO_REGISTRA"].ToString();
                                    objAsis.CANTIDAD = dtResultado.Rows.Count.ToString();
                                    objAsis.CANTIDAD_ASISTENCIA = dtAsistencia.Rows.Count.ToString();
                                    rptAsistencia = new TareoClient().Insertar_ASISTENCIA(objAsis);

                                }

                                SvTareo.BE_TAREO objTareo = new SvTareo.BE_TAREO();

                                for (int y = 0; y < dtResultado.Rows.Count; y++)
                                {
                                    objTareo.IDE_TAREA = dtResultado.Rows[y]["IDE_TAREA"].ToString();
                                    objTareo.DES_DNI = dtResultado.Rows[y]["DES_DNI"].ToString();
                                    objTareo.FECHA_TAREO = dtResultado.Rows[y]["FECHA_TAREO"].ToString();
                                    objTareo.HORA_EMPLEADA = dtResultado.Rows[y]["HORA_EMPLEADA"].ToString();
                                    objTareo.IDE_INGCAMPO = dtResultado.Rows[y]["IDE_INGCAMPO"].ToString();
                                    objTareo.IDE_CAPATAZ = dtResultado.Rows[y]["IDE_CAPATAZ"].ToString();
                                    objTareo.TIPO = dtResultado.Rows[y]["TIPO"].ToString();
                                    objTareo.IDE_EMPRESA = dtResultado.Rows[y]["IDE_EMPRESA"].ToString();
                                    objTareo.IDE_BONIFICACION = dtResultado.Rows[y]["IDE_BONIFICACION"].ToString();
                                    objTareo.CCENTRO = dtResultado.Rows[y]["CCENTRO"].ToString();
                                    objTareo.IDE_ASISTENCIA = dtResultado.Rows[y]["IDE_ASISTENCIA"].ToString();
                                    objTareo.DES_ASISTENCIA = dtResultado.Rows[y]["DES_ASISTENCIA"].ToString();
                                    objTareo.FLG_MIGRADO = dtResultado.Rows[y]["FLG_MIGRADO"].ToString();
                                    objTareo.USUARIO_REGISTRA = dtResultado.Rows[y]["USUARIO_REGISTRA"].ToString();
                                    objTareo.CANTIDAD = dtResultado.Rows.Count.ToString();
                                    rptTareo = new TareoClient().Insertar_TAREO(objTareo);

                                }
                                if (rptTareo > 0)
                                {
                                    MessageBox.Show("Registros del dia " + fechaProcesar.Date.ToString("dd/MM/yyyy") + " migrados correctamente", "Mensaje Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                }
                            }
                            else
                            {
                                rptTareo = 0;
                                MessageBox.Show("Registros del dia " + fechaProcesar.Date.ToString("dd/MM/yyyy") + " ya fueron migrados", "Mensaje Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                        }
                        else
                        {

                            MessageBox.Show("No existen registros del dia " + fechaProcesar.Date.ToString("dd/MM/yyyy"), "Mensaje Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        dtAsistencia.Clear();
                        dtResultado.Clear();
                        BL_TAREO objx = new BL_TAREO();
                        objx.UpdateMigracion(Convert.ToInt32(empresa), centro_costo, fechaProcesar.Date.ToString("dd/MM/yyyy"));

                    }
                }
            }
        }
    }
}
