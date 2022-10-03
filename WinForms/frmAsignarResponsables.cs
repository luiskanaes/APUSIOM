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
    public partial class frmAsignarResponsables : Form
    {
        public int varfNuevo;
        public string Varcapataz;
        public string Varingeniero;
        public frmAsignarResponsables()
        {
            InitializeComponent();
            ListarPersonal();
            Ing();
            ListarCapataz();
        }
        protected void Ing()
        {
            BL_ASIGNACION_TAREAS obj = new BL_ASIGNACION_TAREAS();
            DataTable dtResultado = new DataTable();

            dtResultado = obj.SP_OBTENER_EQUIPO_TRABAJO_TAREO(
                frmDigitacionTareo.obj_Tareas_E.CENTRO_COSTO, "1", "1", "",
                frmDigitacionTareo.obj_Tareas_E.FECHA_TAREO
                );
            if (dtResultado.Rows.Count > 0)
            {
                cboIngeniero.ValueMember = "ID_PERSONAL";
                cboIngeniero.DisplayMember = "NOMBRES";
                cboIngeniero.DataSource = dtResultado;
            
            }
        }
        protected void ListarCapataz()
        {
            BL_ASIGNACION_TAREAS obj = new BL_ASIGNACION_TAREAS();
            DataTable dtResultado = new DataTable();
            dtResultado = obj.USP_OBTENER_EQUIPO_TRABAJO_CAPATAZ(
                 frmDigitacionTareo.obj_Tareas_E.CENTRO_COSTO,
                frmDigitacionTareo.obj_Tareas_E.FECHA_TAREO
                );


            if (dtResultado.Rows.Count > 0)
            {
                cboCapataces.Visible = true;
                cboCapataces.ValueMember = "ID_PERSONAL";
                cboCapataces.DisplayMember = "NOMBRES";
                cboCapataces.DataSource = dtResultado;
            }

        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Desea asignar responsable?", "Mensajes", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (respuesta == DialogResult.Yes)
            {
                if(cboIngeniero.SelectedValue.ToString() !=string.Empty  &&  cboCapataces.SelectedValue.ToString() !=string.Empty )
                {
                    BL_ASIGNACION_TAREAS obj = new BL_ASIGNACION_TAREAS();
                    DataTable dtResultado = new DataTable();
                    dtResultado = obj.USP_ACTUALIZAR_RESPONSABLES(
                        frmDigitacionTareo.obj_Tareas_E.CENTRO_COSTO,
                        frmDigitacionTareo.obj_Tareas_E.FECHA_TAREO,
                        frmDigitacionTareo.obj_Tareas_E.DNI_VARIOS,
                        cboCapataces.SelectedValue.ToString(),
                        cboIngeniero.SelectedValue.ToString()
                        );
        
                            varfNuevo++;
                    MessageBox.Show("Asignación correcta", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error, no se puede asignar responsable", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void frmAsignarResponsables_Load(object sender, EventArgs e)
        {

        }

        protected void ListarPersonal()
        {
          

            gridDetalle.Rows.Clear();
            gridDetalle.Refresh();
            gridDetalle.DataSource = null;
            gridDetalle.Columns.Clear();
            gridDetalle.AllowUserToAddRows = true;
            gridDetalle.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;





            //gridDetalle.ColumnCount = 5;
            DataGridViewTextBoxColumn colItem = new DataGridViewTextBoxColumn();
            colItem.Name = "Item";
            colItem.HeaderText = "N°";
            colItem.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colItem.Width = 30;
            gridDetalle.Columns.Insert(0, colItem);

            DataGridViewTextBoxColumn colIDE_PERSONAL = new DataGridViewTextBoxColumn();
            colIDE_PERSONAL.Name = "IDE_PERSONAL";
            colIDE_PERSONAL.HeaderText = "IDE_PERSONAL";
            gridDetalle.Columns.Insert(1, colIDE_PERSONAL);



            DataGridViewTextBoxColumn colCtas = new DataGridViewTextBoxColumn();
            colCtas.Name = "PERSONAL";
            colCtas.HeaderText = "PERSONAL";
            colCtas.Width = 300;
            //colCtas.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            gridDetalle.Columns.Insert(2, colCtas);

    
            
            //boton

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            gridDetalle.Columns.Add(btn);
            btn.HeaderText = "";
            btn.Text = "Eliminar";
            btn.Name = "btn";
            btn.UseColumnTextForButtonValue = true;

            //celda bloqueados
            gridDetalle.Columns["Item"].ReadOnly = true;
            gridDetalle.Columns["IDE_PERSONAL"].Visible = false;

            //celda bloqueados
            gridDetalle.Columns["btn"].Visible = false;
           

            //llenar trabajadores
            BL_CUADRILLA obj = new BL_CUADRILLA();
            DataTable dtResul = new DataTable();
            

            dtResul = obj.USP_OBTENER_PERSONAL_DNI_VARIOS(frmDigitacionTareo.obj_Tareas_E.CENTRO_COSTO, frmDigitacionTareo.obj_Tareas_E.DNI_VARIOS.ToString());
            if (dtResul.Rows.Count > 0)
            {


                //datos vacios
                for (int i = 0; i < dtResul.Rows.Count; i++)
                {
                    int renglon = gridDetalle.Rows.Add();

                    gridDetalle.Rows[renglon].Cells["Item"].Value = Convert.ToString(i + 1);
                    gridDetalle.Rows[renglon].Cells["IDE_PERSONAL"].Value = dtResul.Rows[i]["IDE_PERSONAL"].ToString();
                    gridDetalle.Rows[renglon].Cells["PERSONAL"].Value = dtResul.Rows[i]["NOMBRE"].ToString();

                  

                }
            }



            gridDetalle.AutoGenerateColumns = false;
        }

        private void cboIngeniero_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
