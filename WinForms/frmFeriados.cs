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
    public partial class frmFeriados : Form
    {
        public frmFeriados()
        {
            InitializeComponent();
        }

        private void frmFeriados_Load(object sender, EventArgs e)
        {
            ListarEmpresa();


            btnAgregar.BackColor = Color.FromArgb(62, 133, 195);
            btnAgregar.ForeColor = Color.FromArgb(255, 255, 255);
            btnAgregar.Font = new Font(btnAgregar.Font.Name, btnAgregar.Font.Size, FontStyle.Bold);

 

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
        static DataTable GetTable()
        {
            // Here we create a DataTable with four columns.
            DataTable table = new DataTable();
            table.Columns.Add("nro", typeof(int));
            table.Columns.Add("dia", typeof(string));
          

            // Here we add five DataRows.
            table.Rows.Add(1, "LUN");
            table.Rows.Add(2, "MAR");
            table.Rows.Add(3, "MIE");
            table.Rows.Add(4, "JUE");
            table.Rows.Add(5, "VIE");
            table.Rows.Add(6, "SAB");
            table.Rows.Add(7, "DOM");
            return table;
        }
        static DataTable GetTableSemana()
        {
            // Here we create a DataTable with four columns.
            DataTable table = new DataTable();
            table.Columns.Add("NRO_SEM_MES", typeof(int));
        
            // Here we add five DataRows.
            table.Rows.Add(1);
            table.Rows.Add(2);
            table.Rows.Add(3);
            table.Rows.Add(4);
            table.Rows.Add(5);
            table.Rows.Add(6);

            return table;
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            listar();
        }
        private void miboton_Click(object sender, EventArgs e)
        {
           
            Button button = sender as Button;
            if (button == null)
                return;

            string dia = button.Name;
            int anio = Convert.ToInt32(dateTimePicker1.Value.Date.ToString("yyyy"));
            int mes = Convert.ToInt32(dateTimePicker2.Value.Date.ToString("MM"));
            //string fecha = string.Format("{0:00}", Convert.ToInt32 ( dia)) + "/" + string.Format("{0:00}", Convert.ToInt32(mes)) + "/" + anio.ToString ();
            //MessageBox.Show("dia " + dia, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //Process.Start((string)clickedButton.Tag);


            DialogResult respuesta = MessageBox.Show("¿Desea eliminar la situación de feriado  a la fecha " + dia + "?", "Mensaje SSK", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (respuesta == DialogResult.Yes)
            {


                try
                {
                    string fecha = string.Format("{0:0}", dia);
                    DataTable dt = new DataTable();
                    BL_JORNADA_FERIADOS objTarea = new BL_JORNADA_FERIADOS();
                    dt = objTarea.uspDEL_DIA_FERIADOS_CENTRO(fecha, cboCentroCosto.SelectedValue.ToString());
                    if (dt.Rows.Count > 0)
                    {
                        string estado = dt.Rows[0]["DELETED"].ToString();
                        if (estado =="0")
                        {
                            MessageBox.Show("No se puede realizar esta operación (Día no feriado)", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            listar();
                            MessageBox.Show("feriado eliminado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                      
                    }
                    else
                    {
                        MessageBox.Show("No se permite esta operación, fecha con horas de trabajo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                catch (Exception ex)
                {

                }

            }


        }
        protected void listar()
        {
            while (flowLayoutPanel1.Controls.Count > 0) flowLayoutPanel1.Controls.RemoveAt(0);
            //flowLayoutPanel1.Refresh ();

            BL_JORNADA_FERIADOS obj = new BL_JORNADA_FERIADOS();
            DataTable dtResul = new DataTable();
            int anio = Convert.ToInt32(dateTimePicker1.Value.Date.ToString("yyyy"));
            int mes = Convert.ToInt32(dateTimePicker2.Value.Date.ToString("MM"));
            string centro = cboCentroCosto.SelectedValue.ToString();
            dtResul = obj.SP_CALENDARIO_TAREO(anio, mes, centro);


            ///////////////////////////////////////////
            //DataTable tableSemana = GetTableSemana();

            if (dtResul.Rows.Count > 0)
            {
                for (int i = 0; i < dtResul.Rows.Count; i++)
                {
                    Button miboton = new Button();
                    miboton.Text = dtResul.Rows[i]["DIA"].ToString() + Environment.NewLine + dtResul.Rows[i]["ID"].ToString() + Environment.NewLine + dtResul.Rows[i]["DET_FERIADO"].ToString();
                    miboton.Name = dtResul.Rows[i]["FECHA_CORTO"].ToString();
                    miboton.Width = 80;
                    miboton.Height = 50;
                    string color = dtResul.Rows[i]["COLOR"].ToString();
                    if (color == "1")
                    {
                        //'SIN DIGITACION'
                        miboton.BackColor = Color.FromArgb(255, 51, 0);
                        miboton.ForeColor = Color.FromArgb(255, 255, 255);
                        miboton.Font = new Font(miboton.Font.Name, miboton.Font.Size, FontStyle.Bold);

                    }
                    else if (color == "2")
                    {
                        //'PENDIENTE CIERRE'
                        miboton.BackColor = Color.FromArgb(153, 255, 102);
                    }
                    else if (color == "3")
                    {
                        //'PENDIENTE MIGRACION'
                        miboton.BackColor = Color.FromArgb(255, 195, 0);
                    }
                    else if (color == "4")
                    {
                        //'MIGRACION EJECUTADA'
                        miboton.BackColor = Color.FromArgb(255, 255, 255);
                    }
                    //miboton.Location = new Point(136, 106);
                    miboton.Click += miboton_Click;
                    flowLayoutPanel1.Controls.Add(miboton);

                }
            }

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

        private void cboEmpresa_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ListarCesos();
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Desea agregar la fecha " + dateFecha.Value.Date.ToString("dd/MM/yyyy") + " como día feriado?", "Grabar Registros", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (respuesta == DialogResult.Yes)
            {
                guardarFeriado();
            }
        }
        protected void guardarFeriado()
        {
            int rpta = 0;
            BE_JORNADA_FERIADOS obj = new BE_JORNADA_FERIADOS();
            obj.IDE_FERIADO =0;
            obj.FECHA = dateFecha.Value.Date.ToString("dd/MM/yyyy");
            obj.DES_CRIPCION = dateFecha.Value.Date.ToString("dddd");
            obj.IDE_EMPRESA = Convert.ToInt32(cboEmpresa.SelectedValue.ToString());
            obj.CENTRO_COSTO = cboCentroCosto.SelectedValue.ToString();
            rpta = new BL_JORNADA_FERIADOS().Mant_Insert_diasFeriados(obj);
            if (rpta > 0)
            {

                listar();
                MessageBox.Show("Registro satisfactorio", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                MessageBox.Show("No se puede realizar esta operación (Día cerrado)", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
      
    }
}
  
        
