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
    public partial class frmTareas : Form
    {
        public frmTareas()
        {
            InitializeComponent();
            ListarActividadesAsignadas();
        }

        private void frmTareas_Load(object sender, EventArgs e)
        {

        }
        protected void ListarActividadesAsignadas()
        {
            //ESTRUCTURA GRILLA
            BL_ASIGNACION_TAREAS xobj = new BL_ASIGNACION_TAREAS();
            DataTable dtResultado = new DataTable();
            dtResultado = xobj.Listar_ActividadAsignadas(frmTareoDiario.obj_asignacion_E.IDE_EMPRESA.ToString ()  , frmTareoDiario.obj_asignacion_E.CENTRO_COSTO , null, frmTareoDiario.obj_asignacion_E.FECHA_TAREO , frmTareoDiario.obj_asignacion_E.IDE_CAPATAZ , frmTareoDiario.obj_asignacion_E.IDE_INGCAMPO );

            gridAsignacion.Rows.Clear();
            gridAsignacion.Refresh();
            gridAsignacion.DataSource = null;
            gridAsignacion.Columns.Clear();

            gridAsignacion.ColumnCount = 1;
            gridAsignacion.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            gridAsignacion.Columns[0].Name = "Item";
            gridAsignacion.Columns[0].Width = 58;

            DataGridViewTextBoxColumn colActividad = new DataGridViewTextBoxColumn();
            colActividad.Name = "DesActividad";
            colActividad.HeaderText = "Descripcion Actividad";
            colActividad.Width = 300;
            colActividad.DefaultCellStyle.BackColor = Color.FromArgb(255, 248, 110);
            gridAsignacion.Columns.Insert(1, colActividad);

            DataGridViewTextBoxColumn colTarea = new DataGridViewTextBoxColumn();
            colTarea.Name = "Tarea";
            colTarea.HeaderText = "Tarea";
            colTarea.Width = 300;
            //colTarea.ReadOnly = true;
            colTarea.DefaultCellStyle.BackColor = Color.FromArgb(244, 243, 226);
            gridAsignacion.Columns.Insert(2, colTarea);

            DataGridViewTextBoxColumn colFrente = new DataGridViewTextBoxColumn();
            colFrente.Name = "Frente";
            colFrente.HeaderText = "Frente";
            colFrente.Width = 40;
            colFrente.ReadOnly = true;
            colFrente.DefaultCellStyle.BackColor = Color.FromArgb(244, 243, 226);
            colFrente.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridAsignacion.Columns.Insert(3, colFrente);

            DataGridViewTextBoxColumn colCta = new DataGridViewTextBoxColumn();
            colCta.Name = "CtaCosto";
            colCta.HeaderText = "Cta Costo";
            colCta.Width = 70;
            colCta.ReadOnly = true;
            colCta.DefaultCellStyle.BackColor = Color.FromArgb(244, 243, 226);
            colCta.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridAsignacion.Columns.Insert(4, colCta);

            DataGridViewTextBoxColumn ColUnidad = new DataGridViewTextBoxColumn();
            ColUnidad.Name = "Unidad";
            ColUnidad.HeaderText = "Unidad";
            ColUnidad.Width = 50;
            ColUnidad.ReadOnly = true;
            ColUnidad.DefaultCellStyle.BackColor = Color.FromArgb(244, 243, 226);
            ColUnidad.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridAsignacion.Columns.Insert(5, ColUnidad);

            DataGridViewTextBoxColumn colProgramado = new DataGridViewTextBoxColumn();
            colProgramado.Name = "Programado";
            colProgramado.HeaderText = "Programado";
            colProgramado.Width = 62;
            colProgramado.DefaultCellStyle.BackColor = Color.FromArgb(255, 248, 110);
            colProgramado.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridAsignacion.Columns.Insert(6, colProgramado);

            DataGridViewTextBoxColumn colEjecutado = new DataGridViewTextBoxColumn();
            colEjecutado.Name = "Ejecutado";
            colEjecutado.HeaderText = "Ejecutado";
            colEjecutado.Width = 60;
            colEjecutado.DefaultCellStyle.BackColor = Color.FromArgb(255, 248, 110);
            colEjecutado.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridAsignacion.Columns.Insert(7, colEjecutado);


            //Add a CheckBox Column to the DataGridView at the first position.
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "RT";
            checkBoxColumn.ToolTipText = "Retrabajo";
            checkBoxColumn.Width = 40;
            checkBoxColumn.Name = "checkBoxRT";
            gridAsignacion.Columns.Insert(8, checkBoxColumn);

            DataGridViewTextBoxColumn colAreas = new DataGridViewTextBoxColumn();
            colAreas.Name = "Areas";
            colAreas.HeaderText = "Areas de Soporte";
            colAreas.Width = 150;
            gridAsignacion.Columns.Insert(9, colAreas);

            DataGridViewTextBoxColumn colObservaciones = new DataGridViewTextBoxColumn();
            colObservaciones.Name = "Observaciones";
            colObservaciones.HeaderText = "Observaciones de Incumplimiento";
            colObservaciones.Width = 200;
            gridAsignacion.Columns.Insert(10, colObservaciones);


            DataGridViewTextBoxColumn colIdTarea = new DataGridViewTextBoxColumn();
            colIdTarea.Name = "IdTarea";
            colIdTarea.HeaderText = "IdTarea";
            gridAsignacion.Columns.Insert(11, colIdTarea);

            DataGridViewTextBoxColumn colCodActividad = new DataGridViewTextBoxColumn();
            colCodActividad.Name = "Actividad";
            colCodActividad.HeaderText = "Actividad";
            gridAsignacion.Columns.Insert(12, colCodActividad);

            DataGridViewTextBoxColumn colDescripcionActividad = new DataGridViewTextBoxColumn();
            colDescripcionActividad.Name = "DescripcionActividad";
            colDescripcionActividad.HeaderText = "Descripcion Actividad";
            gridAsignacion.Columns.Insert(13, colDescripcionActividad);

            DataGridViewTextBoxColumn colcodigoTarea = new DataGridViewTextBoxColumn();
            colcodigoTarea.Name = "codigoTarea";
            colcodigoTarea.HeaderText = "codigoTarea";
            gridAsignacion.Columns.Insert(14, colcodigoTarea);

            DataGridViewTextBoxColumn colDescripcionTarea = new DataGridViewTextBoxColumn();
            colDescripcionTarea.Name = "DescripcionTarea";
            colDescripcionTarea.HeaderText = "DescripcionTarea";
            gridAsignacion.Columns.Insert(15, colDescripcionTarea);

            DataGridViewTextBoxColumn colDescripcionFrente = new DataGridViewTextBoxColumn();
            colDescripcionFrente.Name = "DescripcionFrente";
            colDescripcionFrente.HeaderText = "DescripcionFrente";
            gridAsignacion.Columns.Insert(16, colDescripcionFrente);

            //VISIBLE
            gridAsignacion.Columns["Actividad"].Visible = false;
            gridAsignacion.Columns["IdTarea"].Visible = false; // como fila de la grilla
            gridAsignacion.Columns["DescripcionFrente"].Visible = false;
            gridAsignacion.Columns["codigoTarea"].Visible = false;//
            gridAsignacion.Columns["DescripcionActividad"].Visible = false;
            gridAsignacion.Columns["DescripcionFrente"].Visible = false;
            gridAsignacion.Columns["DescripcionTarea"].Visible = false;
            


            if (dtResultado.Rows.Count > 0)
            {

                string ITEM, DESCRIPCION, DESCR_TAREA, ID_FRENTE, CTA_COSTO, DES_UNIDAD,
                       H_PROGRAMADO, H_EJECUTADO, RETRABAJO, DES_AREAS,
                        OBSERVACIONES, IDE_TAREA, IDE_ACTIVIDAD, DES_ACTIVIDAD, COD_TAREA, DESTAREA, DESFRENTE;
                string[] Xrow;

                for (int i = 0; i < dtResultado.Rows.Count; i++)
                {
                    ITEM = "Tarea " + dtResultado.Rows[i]["ITEM_ACTIVIDAD"].ToString();// Convert.ToString(i + 1);
                    IDE_ACTIVIDAD = dtResultado.Rows[i]["IDE_ACTIVIDAD"].ToString();
                    DESCR_TAREA = dtResultado.Rows[i]["DESCRIPCION_TAREA"].ToString();
                    ID_FRENTE = dtResultado.Rows[i]["ID_FRENTE"].ToString();
                    CTA_COSTO = dtResultado.Rows[i]["CTA_COSTO"].ToString();
                    H_PROGRAMADO = dtResultado.Rows[i]["H_PROGRAMADO"].ToString();
                    H_EJECUTADO = dtResultado.Rows[i]["H_EJECUTADO"].ToString();
                    DES_UNIDAD = dtResultado.Rows[i]["DES_UNIDAD"].ToString();
                    OBSERVACIONES = dtResultado.Rows[i]["OBSERVACIONES"].ToString();
                    DES_AREAS = dtResultado.Rows[i]["DES_AREAS"].ToString();
                    IDE_TAREA = dtResultado.Rows[i]["IDE_TAREA"].ToString();
                    RETRABAJO = dtResultado.Rows[i]["RETRABAJO"].ToString();
                    DESCRIPCION = dtResultado.Rows[i]["DESCRIPCION"].ToString();
                    DES_ACTIVIDAD = dtResultado.Rows[i]["DES_ACTIVIDAD"].ToString();
                    COD_TAREA = dtResultado.Rows[i]["DET_TAREA"].ToString();
                    DESTAREA = dtResultado.Rows[i]["DES_TAREA"].ToString();
                    DESFRENTE = dtResultado.Rows[i]["DES_FRENTE"].ToString();
                  
                    Xrow = new string[] {

                       ITEM, DESCRIPCION, DESCR_TAREA, ID_FRENTE, CTA_COSTO, DES_UNIDAD,
                       H_PROGRAMADO, H_EJECUTADO, Convert.ToBoolean (RETRABAJO).ToString (), DES_AREAS,
                       OBSERVACIONES, IDE_TAREA, IDE_ACTIVIDAD, DES_ACTIVIDAD,COD_TAREA,DESTAREA,DESFRENTE


                };

                    gridAsignacion.Rows.Add(Xrow);

                }
                //gridAsignacion.Columns["Item"].ReadOnly = false;

            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    DataGridViewRow row = (DataGridViewRow)gridAsignacion.Rows[i].Clone();
                    row.Cells[0].Value = "Tarea " + Convert.ToString(i + 1);
                    gridAsignacion.Rows.Add(row);
                }
           
            }

            
        }
    }
}
