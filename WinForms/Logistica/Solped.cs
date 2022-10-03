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

namespace WinForms.Logistica
{
   
    public partial class Solped : Form
    {
        public static BE_LOG_SOLPED_DETALLE obj_SOLPED_E;

        bool bKeyPressNum_GV_DATA = false;
        DataTable dtPEP = new DataTable();
        public Solped()
        {
            InitializeComponent();
            Imputacion();
            Sociedad();
            Moneda();
            ListarCodigos();
        }

        private void Solped_Load(object sender, EventArgs e)
        {
           
        }
       
        protected void Imputacion()
        {
            ddlImputacion.DisplayMember = "ValueMember";
            ddlImputacion.ValueMember = "DisplayMember";
            ddlImputacion.DataSource = GetImputacion();

        }
        private DataTable GetImputacion()
        {
            DataTable dt = new DataTable();

            //Add Columns to Table
            dt.Columns.Add(new DataColumn("DisplayMember"));
            dt.Columns.Add(new DataColumn("ValueMember"));

            //Now Add Values
            dt.Rows.Add("0", "--- Seleccionar ---");
            dt.Rows.Add("K", "K - OF. CENTRAL");
            dt.Rows.Add("Q", "Q - OBRA");
            return dt;

        }
        protected void Sociedad()
        {


            ddlSociedad.DisplayMember = "ValueMember";
            ddlSociedad.ValueMember = "DisplayMember";
            ddlSociedad.DataSource = GetSociedad();

            Obra();
            Centro();
            CentroCoste();
        }
        private DataTable GetSociedad()
        {
            DataTable dt = new DataTable();

            //Add Columns to Table
            dt.Columns.Add(new DataColumn("DisplayMember"));
            dt.Columns.Add(new DataColumn("ValueMember"));

            //Now Add Values
            dt.Rows.Add("0", "--- Seleccionar ---");
            dt.Rows.Add("IP03", "SSK");
            dt.Rows.Add("IP04", "SKEX");
            return dt;

        }
        private void ddlImputacion_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            //Obra();
            try
            {
                Obra();
                CentroCoste();
               
            }
            catch (Exception ex)
            {

            }
               
          

        }
        protected void Obra()
        {
            BL_CECOS obj = new BL_CECOS();
            DataTable dtResultado = new DataTable();
            dtResultado = obj.SEL_CECOS_POR_CATEGORIA_EMPRESA("OBRA", ddlSociedad.SelectedValue.ToString ());
            if (ddlImputacion.SelectedValue.ToString () == "K")
            {
                ddlObra.DataSource = null;
                ddlObra.Items.Clear();
            }
            else
            {
                DataTable dt = new DataTable();
                if (dtResultado.Rows.Count > 0)
                {
                   

                    dt.Clear();
                    DataColumn dc = new DataColumn("Codigo", typeof(String));
                    dt.Columns.Add(dc);

                    dc = new DataColumn("Descripcion", typeof(String));
                    dt.Columns.Add(dc);

                    DataRow workRow;

                    workRow = dt.NewRow();
                    workRow[0] = "0";
                    workRow[1] = "--- SELECCIONAR  ---";
                    dt.Rows.Add(workRow);

                    for (int i = 0; i < dtResultado.Rows.Count; i++)
                    {

                        workRow = dt.NewRow();
                        workRow[0] = dtResultado.Rows[i]["COD_CECOS"].ToString();
                        workRow[1] = dtResultado.Rows[i]["COD_CECOS"].ToString();
                        dt.Rows.Add(workRow);
                    }


                    ddlObra.ValueMember = "Codigo";
                    ddlObra.DisplayMember = "Descripcion";
                    ddlObra.DataSource = dt;
                }
            }
        }
        protected void CentroCoste()
        {
            BL_CECOS obj = new BL_CECOS();
            DataTable dtResultado = new DataTable();
            //if (ddlImputacion.SelectedIndex > 0)
            //{
            if (ddlImputacion.SelectedValue.ToString() == "Q")
            {
                ddlCoste.DataSource = null;
                ddlCoste.Items.Clear();
            }
            else if (ddlImputacion.SelectedValue.ToString() == "K")
            {
                DataTable dt = new DataTable();

                dtResultado = obj.SEL_CECOS_POR_CATEGORIA_EMPRESA("Deysu,Proyectos,Corporativo", ddlSociedad.SelectedValue.ToString());
                if (dtResultado.Rows.Count > 0)
                {

                    dt.Clear();
                    DataColumn dc = new DataColumn("Codigo", typeof(String));
                    dt.Columns.Add(dc);

                    dc = new DataColumn("Descripcion", typeof(String));
                    dt.Columns.Add(dc);

                    DataRow workRow;

                    workRow = dt.NewRow();
                    workRow[0] = "0";
                    workRow[1] = "--- SELECCIONAR  ---";
                    dt.Rows.Add(workRow);

                    for (int i = 0; i < dtResultado.Rows.Count; i++)
                    {

                        workRow = dt.NewRow();
                        workRow[0] = dtResultado.Rows[i]["COD_CENTRO"].ToString();
                        workRow[1] = dtResultado.Rows[i]["DESCRIPCION"].ToString();
                        dt.Rows.Add(workRow);
                    }
                    ddlCoste.ValueMember = "Codigo";
                    ddlCoste.DisplayMember = "Descripcion";
                    ddlCoste.DataSource = dt;
                }
                else
                {
                    ddlCoste.DataSource = null;
                    ddlCoste.Items.Clear();
                }
            }
            else
            {
                ddlCoste.DataSource = null;
                ddlCoste.Items.Clear();
            }
            //}
            //else
            //{
            //    ddlCoste.Items.Clear();
            //}
        }
        protected void Centro()
        {
            BL_CECOS obj = new BL_CECOS();
            DataTable dtResultado = new DataTable();

            if (ddlSociedad.SelectedIndex > 0)
            {
                dtResultado = obj.SEL_CECOS_CENTRO_LOGISTICO(ddlSociedad.SelectedValue.ToString (),ddlImputacion.SelectedValue.ToString ());
                DataTable dt = new DataTable();
                if (dtResultado.Rows.Count > 0)
                {
                 

                    dt.Clear();
                    DataColumn dc = new DataColumn("Codigo", typeof(String));
                    dt.Columns.Add(dc);

                    dc = new DataColumn("Descripcion", typeof(String));
                    dt.Columns.Add(dc);

                    DataRow workRow;

                    workRow = dt.NewRow();
                    workRow[0] = "0";
                    workRow[1] = "--- SELECCIONAR  ---";
                    dt.Rows.Add(workRow);

                    for (int i = 0; i < dtResultado.Rows.Count; i++)
                    {

                        workRow = dt.NewRow();
                        workRow[0] = dtResultado.Rows[i]["CENTRO"].ToString();
                        workRow[1] = dtResultado.Rows[i]["LOGISTICO"].ToString();
                        dt.Rows.Add(workRow);
                    }


                    ddlCentro.ValueMember = "Codigo";
                    ddlCentro.DisplayMember = "Descripcion";
                    ddlCentro.DataSource = dt;

                }
            }
            else
            {
                ddlCentro.DataSource = null;
                ddlCentro.Items.Clear();
            }
        }

        private void ddlSociedad_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Obra();
                Centro();
                CentroCoste();
                GrupoCompra();
            }
            catch (Exception )
            {

            }
            
            
        }
        protected void Moneda()
        {
           
            ddlMoneda.DisplayMember = "ValueMember";
            ddlMoneda.ValueMember = "DisplayMember";
            ddlMoneda.DataSource = GetMoneda();
        }
        private DataTable GetMoneda()
        {
            DataTable dt = new DataTable();

            //Add Columns to Table
            dt.Columns.Add(new DataColumn("DisplayMember"));
            dt.Columns.Add(new DataColumn("ValueMember"));

            //Now Add Values
            dt.Rows.Add("0", "--- Seleccionar ---");
            dt.Rows.Add("PEN", "SOLES");
            dt.Rows.Add("USD", "DOLARES");
            dt.Rows.Add("CLP", "PESOS");
            return dt;
        }

        private void ddlObra_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GrupoCompra();
            }
            catch (Exception ex)
            {

            }
           
        }
        protected void GrupoCompra()
        {
            try
            {
                BL_CECOS obj = new BL_CECOS();
                DataTable dtResultado = new DataTable();
                DataTable dt = new DataTable();
                dtResultado = obj.SEL_GRUPO_COMPRAS(ddlObra.SelectedValue.ToString());
                if (dtResultado.Rows.Count > 0)
                {


                    dt.Clear();
                    DataColumn dc = new DataColumn("Codigo", typeof(String));
                    dt.Columns.Add(dc);

                    dc = new DataColumn("Descripcion", typeof(String));
                    dt.Columns.Add(dc);

                    DataRow workRow;

                    workRow = dt.NewRow();
                    workRow[0] = "0";
                    workRow[1] = "--- SELECCIONAR  ---";
                    dt.Rows.Add(workRow);

                    for (int i = 0; i < dtResultado.Rows.Count; i++)
                    {

                        workRow = dt.NewRow();
                        workRow[0] = dtResultado.Rows[i]["ID"].ToString();
                        workRow[1] = dtResultado.Rows[i]["DESCRIPCION"].ToString();
                        dt.Rows.Add(workRow);
                    }

                    ddlGpoCompra.Visible = true;
                    ddlGpoCompra.ValueMember = "Codigo";
                    ddlGpoCompra.DisplayMember = "Descripcion";
                    ddlGpoCompra.DataSource = dt;
                }
                else
                {
                    ddlGpoCompra.Visible = false;
                }
            }
            catch (Exception ex)
            {

            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ddlImputacion.SelectedIndex == 0)
            {
               
                MessageBox.Show("Seleccionar Imputación", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (ddlSociedad.SelectedIndex == 0)
            {
                MessageBox.Show("Seleccionar sociedad", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (ddlMoneda.SelectedIndex == 0)
            {
                MessageBox.Show("Seleccionar Moneda", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;

            }
            else if (ddlGpoCompra.SelectedIndex == 0)
            {
              
                MessageBox.Show("Seleccionar Grupo Compra", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (ddlCentro.SelectedIndex == 0)
            {
                MessageBox.Show("Seleccionar Centro", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                if (ddlImputacion.SelectedValue.ToString () == "K")
                {
                    if (ddlCoste.SelectedIndex == 0)
                    {
                        MessageBox.Show("Seleccionar Centro de Coste", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    else
                    {
                        Grabar();
                    }
                }
                else
                {
                    if (ddlObra.SelectedIndex == 0)
                    {
                       
                        MessageBox.Show("Seleccionar Obra", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    else
                    {
                        Grabar();
                    }
                }
            }
        }
        protected void Grabar ()
        {
            if (txtValor.Text == string.Empty)
            {
                
                MessageBox.Show("Ingresar Valor", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                BE_LOG_SOLPED oBESol = new BE_LOG_SOLPED();
                oBESol = f_CapturarDatosCabecera();
                DataTable dtrpta = new DataTable();
                dtrpta = new BL_LOG_SOLPED().Mant_Insert_LOG_SOLPED(oBESol);
                if (dtrpta.Rows.Count > 0)
                {
                   
                    ListarCodigos();

                    ddlCodigo.SelectedValue = dtrpta.Rows[0]["IDE_SOLICITUD"].ToString();
                    lblId.Text = dtrpta.Rows[0]["IDE_SOLICITUD"].ToString();

                    PanelPedidos.Visible = true;

                    if (ddlCodigo.Items.Count > 0)
                    {
                        ListarPedido();
                    }
                  

                    MessageBox.Show("Registro Exitoso", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                {


                }
            }
        }
        private BE_LOG_SOLPED f_CapturarDatosCabecera()
        {

            if (lblId.Text == "lblId")
            {
                lblId.Text = string.Empty;
            }
            BE_LOG_SOLPED oBESol = new BE_LOG_SOLPED();
            try
            {
               
                string COD_PEDIDO = string.Empty;
                string IMPUTACION = string.Empty;
                string SOCIEDAD = string.Empty;
                string OBRA = string.Empty;
                string CENTRO = string.Empty;
                string GR_COMPRA = string.Empty;
                string CENTRO_COSTE = string.Empty;

               
                if (ddlCodigo.Items.Count < 1)
                {
                    COD_PEDIDO = string.Empty; 
                }
                else
                {
                    COD_PEDIDO = ddlCodigo.SelectedValue.ToString();
                }

                if (ddlImputacion.Items.Count < 1)
                {
                    IMPUTACION = string.Empty; 
                }
                else
                {
                    IMPUTACION = ddlImputacion.SelectedValue.ToString();
                }
               
                if (ddlSociedad.Items.Count < 1)
                {
                    SOCIEDAD = string.Empty;
                }
                else
                {
                    SOCIEDAD = ddlSociedad.SelectedValue.ToString();
                }

               
                if (ddlObra.Items.Count < 1)
                {
                    OBRA = string.Empty;
                }
                else
                {
                    OBRA = ddlObra.SelectedValue.ToString();
                }

              
                if (ddlCentro.Items.Count < 1)
                {
                    CENTRO = string.Empty;
                }
                else
                {
                    CENTRO = ddlCentro.SelectedValue.ToString();
                }

               
                if (ddlGpoCompra.Items.Count < 1)
                {
                    GR_COMPRA = string.Empty;
                }
                else
                {
                    GR_COMPRA = ddlGpoCompra.SelectedValue.ToString();
                }

               
                if (ddlCoste.Items.Count < 1)
                {
                    CENTRO_COSTE = string.Empty;
                }
                else
                {
                    CENTRO_COSTE = ddlCoste.SelectedValue.ToString();
                }

                oBESol.IDE_SOLICITUD = Convert.ToInt32(string.IsNullOrEmpty(lblId.Text) ? "0" : lblId.Text);
                oBESol.COD_PEDIDO = string.IsNullOrEmpty(COD_PEDIDO) ? string.Empty : COD_PEDIDO;
                oBESol.IMPUTACION = string.IsNullOrEmpty(IMPUTACION) ? string.Empty : IMPUTACION;
                oBESol.SOCIEDAD = string.IsNullOrEmpty(SOCIEDAD) ? string.Empty : SOCIEDAD;
                oBESol.OBRA = string.IsNullOrEmpty(OBRA) ? string.Empty : OBRA;
                oBESol.FECHA = dateFecha.Value.Date.ToString("dd/MM/yyyy");
                oBESol.VALOR = Convert.ToDecimal(string.IsNullOrEmpty(txtValor.Text) ? "1" : txtValor.Text);
                oBESol.MONEDA = ddlMoneda.SelectedValue.ToString();
                oBESol.CENTRO = string.IsNullOrEmpty(CENTRO) ? string.Empty : CENTRO;
                oBESol.GR_COMPRA = string.IsNullOrEmpty(GR_COMPRA) ? string.Empty : GR_COMPRA;
                oBESol.CENTRO_COSTE = string.IsNullOrEmpty(CENTRO_COSTE) ? string.Empty : CENTRO_COSTE;
                oBESol.SOLICITANTE = frmLogin.obj_user_E.IDE_USUARIO;


                
            }
            catch (Exception ex)
            {

             }
            return oBESol;
        }
        protected void ListarCodigos()
        {
            BL_CECOS obj = new BL_CECOS();
            DataTable dtResultado = new DataTable();
            DataTable dt = new DataTable();
            dtResultado = obj.uspCONSULTAR_LOG_SOLPED_USER(frmLogin.obj_user_E.IDE_USUARIO);
            if (dtResultado.Rows.Count > 0)
            {
              
                dt.Clear();
                DataColumn dc = new DataColumn("Codigo", typeof(String));
                dt.Columns.Add(dc);

                dc = new DataColumn("Descripcion", typeof(String));
                dt.Columns.Add(dc);

                DataRow workRow;

                workRow = dt.NewRow();
                workRow[0] = "0";
                workRow[1] = "--- SELECCIONAR  ---";
                dt.Rows.Add(workRow);

                for (int i = 0; i < dtResultado.Rows.Count; i++)
                {

                    workRow = dt.NewRow();
                    workRow[0] = dtResultado.Rows[i]["IDE_SOLICITUD"].ToString();
                    workRow[1] = dtResultado.Rows[i]["COD_PEDIDO"].ToString();
                    dt.Rows.Add(workRow);
                }

                ddlCodigo.Visible = true;
                ddlCodigo.ValueMember = "Codigo";
                ddlCodigo.DisplayMember = "Descripcion";
                ddlCodigo.DataSource = dt;


            }
            else
            {
                ddlCodigo.DataSource = null;
                ddlCodigo.Items.Clear();

            }
        }
        protected void ListarPedido()
        {
            BL_LOG_SOLPED oBESol = new BL_LOG_SOLPED();
            DataTable dtResultado = new DataTable();
            dtResultado = oBESol.SEL_LISTAR_PEDIDOS_SOLPED(ddlCodigo.SelectedValue.ToString(), Convert.ToInt32(lblId.Text));
            

                
               
                dataGridView1.DataSource = null;
                dataGridView1.Columns.Clear();
                dataGridView1.Refresh();
                dataGridView1.AllowUserToAddRows = true;

                dataGridView1.ColumnCount = 1;
                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


                dataGridView1.Columns[0].Name = "IMPUTACION";
                dataGridView1.Columns[0].HeaderText = "IMP.";
                dataGridView1.Columns[0].Width = 30;
                dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                DataGridViewTextBoxColumn colMATERIAL = new DataGridViewTextBoxColumn();
                colMATERIAL.Name = "MATERIAL";
                colMATERIAL.HeaderText = "MATERIAL";
                colMATERIAL.Width = 80;
                dataGridView1.Columns.Insert(1, colMATERIAL);


                DataGridViewTextBoxColumn colMATERIAL_TEXTO = new DataGridViewTextBoxColumn();
                colMATERIAL_TEXTO.Name = "MATERIAL_TEXTO";
                colMATERIAL_TEXTO.HeaderText = "DESCRIPCION";
                colMATERIAL_TEXTO.Width = 250;
                dataGridView1.Columns.Insert(2, colMATERIAL_TEXTO);

                DataGridViewTextBoxColumn colCANTIDAD = new DataGridViewTextBoxColumn();
                colCANTIDAD.Name = "CANTIDAD";
                colCANTIDAD.HeaderText = "CANT.";
                colCANTIDAD.Width = 50;
                colCANTIDAD.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns.Insert(3, colCANTIDAD);

                DataGridViewTextBoxColumn colUNIDAD = new DataGridViewTextBoxColumn();
                colUNIDAD.Name = "UNIDAD";
                colUNIDAD.HeaderText = "UNIDAD";
                colUNIDAD.Width = 80;
                dataGridView1.Columns.Insert(4, colUNIDAD);

                DataGridViewTextBoxColumn colVALOR = new DataGridViewTextBoxColumn();
                colVALOR.Name = "VALOR";
                colVALOR.HeaderText = "VALOR";
                colVALOR.Width = 80;
                colVALOR.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns.Insert(5, colVALOR);

                DataGridViewTextBoxColumn colMONEDA = new DataGridViewTextBoxColumn();
                colMONEDA.Name = "MONEDA";
                colMONEDA.HeaderText = "MONEDA";
                colMONEDA.Width = 50;
                colMONEDA.ReadOnly = true;
                colMONEDA.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns.Insert(6, colMONEDA);

                DataGridViewTextBoxColumn colFECHA = new DataGridViewTextBoxColumn();
                colFECHA.Name = "FECHA";
                colFECHA.HeaderText = "FECHA";
                colFECHA.Width = 100;
                colFECHA.ReadOnly = true;
                colFECHA.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns.Insert(7, colFECHA);


                DataGridViewTextBoxColumn colGRUPO = new DataGridViewTextBoxColumn();
                colGRUPO.Name = "GRUPO";
                colGRUPO.HeaderText = "GRUPO";
                colGRUPO.Width = 100;
                colGRUPO.ReadOnly = true;
                colGRUPO.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns.Insert(8, colGRUPO);



                DataGridViewTextBoxColumn colCENTRO = new DataGridViewTextBoxColumn();
                colCENTRO.Name = "CENTRO";
                colCENTRO.HeaderText = "CENTRO";
                colCENTRO.Width = 120;
                dataGridView1.Columns.Insert(9, colCENTRO);


                DataGridViewTextBoxColumn colSOLICITANTE = new DataGridViewTextBoxColumn();
                colSOLICITANTE.Name = "SOLICITANTE";
                colSOLICITANTE.HeaderText = "SOLICITANTE";
                colSOLICITANTE.Width = 80;
                colSOLICITANTE.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns.Insert(10, colSOLICITANTE);


                DataGridViewTextBoxColumn colGR_COMPRA = new DataGridViewTextBoxColumn();
                colGR_COMPRA.Name = "GR_COMPRA";
                colGR_COMPRA.HeaderText = "GPO COMPRA";
                colGR_COMPRA.Width = 80;
                colGR_COMPRA.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns.Insert(11, colGR_COMPRA);

                DataGridViewTextBoxColumn colCUENTA_MAYOR = new DataGridViewTextBoxColumn();
                colCUENTA_MAYOR.Name = "CUENTA_MAYOR";
                colCUENTA_MAYOR.HeaderText = "CUENTA MAYOR";
                colCUENTA_MAYOR.Width = 120;
                colCUENTA_MAYOR.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns.Insert(12, colCUENTA_MAYOR);

                DataGridViewTextBoxColumn colPEP = new DataGridViewTextBoxColumn();
                colPEP.Name = "PEP";
                colPEP.HeaderText = "PEP";
                colPEP.Width = 120;
                colPEP.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns.Insert(13, colPEP);

                DataGridViewTextBoxColumn colCENTRO_COSTE = new DataGridViewTextBoxColumn();
                colCENTRO_COSTE.Name = "CENTRO_COSTE";
                colCENTRO_COSTE.HeaderText = "CENTRO COSTE";
                colCENTRO_COSTE.Width = 120;
                colCENTRO_COSTE.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns.Insert(14, colCENTRO_COSTE);

                DataGridViewTextBoxColumn colIDE_PEDIDO = new DataGridViewTextBoxColumn();
                colIDE_PEDIDO.Name = "IDE_PEDIDO";
                colIDE_PEDIDO.HeaderText = "IDE_PEDIDO";
                colIDE_PEDIDO.Width = 120;
                dataGridView1.Columns.Insert(15, colIDE_PEDIDO);


                DataGridViewButtonColumn btnAgregar = new DataGridViewButtonColumn();
                btnAgregar.HeaderText = "";
                btnAgregar.Name = "btnAgregar";
                btnAgregar.Text = "ELIMINAR";
                btnAgregar.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Insert(16, btnAgregar);

                

                dataGridView1.Columns["IDE_PEDIDO"].Visible = false;

                dataGridView1.Columns["CANTIDAD"].DefaultCellStyle.BackColor = Color.FromArgb(255, 248, 110);

            if (dtResultado.Rows.Count > 0)
            {
                dataGridView1.Visible = true;
                for (int i = 0; i < dtResultado.Rows.Count; i++)
                {

                    int renglon = dataGridView1.Rows.Add();
                    dataGridView1.Rows[renglon].Cells["IMPUTACION"].Value = dtResultado.Rows[i]["IMPUTACION"].ToString();// Convert.ToString(i + 1);
                    dataGridView1.Rows[renglon].Cells["MATERIAL"].Value = dtResultado.Rows[i]["MATERIAL"].ToString();
                    dataGridView1.Rows[renglon].Cells["MATERIAL_TEXTO"].Value = dtResultado.Rows[i]["MATERIAL_TEXTO"].ToString();
                    dataGridView1.Rows[renglon].Cells["CANTIDAD"].Value = dtResultado.Rows[i]["CANTIDAD"].ToString();
                    dataGridView1.Rows[renglon].Cells["UNIDAD"].Value = dtResultado.Rows[i]["UNIDAD"].ToString();
                    dataGridView1.Rows[renglon].Cells["VALOR"].Value = dtResultado.Rows[i]["VALOR"].ToString();
                    dataGridView1.Rows[renglon].Cells["MONEDA"].Value = dtResultado.Rows[i]["MONEDA"].ToString();
                    dataGridView1.Rows[renglon].Cells["FECHA"].Value = dtResultado.Rows[i]["FECHA"].ToString();


                    dataGridView1.Rows[renglon].Cells["GRUPO"].Value = dtResultado.Rows[i]["GRUPO"].ToString();
                    dataGridView1.Rows[renglon].Cells["CENTRO"].Value = dtResultado.Rows[i]["CENTRO"].ToString();
                    dataGridView1.Rows[renglon].Cells["SOLICITANTE"].Value = dtResultado.Rows[i]["SOLICITANTE"].ToString();
                    dataGridView1.Rows[renglon].Cells["GR_COMPRA"].Value = dtResultado.Rows[i]["GR_COMPRA"].ToString();
                    dataGridView1.Rows[renglon].Cells["CUENTA_MAYOR"].Value = dtResultado.Rows[i]["CUENTA_MAYOR"].ToString();
                    dataGridView1.Rows[renglon].Cells["PEP"].Value = dtResultado.Rows[i]["PEP"].ToString();

                    dataGridView1.Rows[renglon].Cells["CENTRO_COSTE"].Value = dtResultado.Rows[i]["CENTRO_COSTE"].ToString();
                    dataGridView1.Rows[renglon].Cells["IDE_PEDIDO"].Value = dtResultado.Rows[i]["IDE_PEDIDO"].ToString();

                }
            }

            else
            {
                dataGridView1.Visible = false;
                dataGridView1.DataSource = dtResultado;

            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BL_LOG_SOLPED oBESol = new BL_LOG_SOLPED();
            DataTable dtResultado = new DataTable();
            if (ddlCodigo.SelectedIndex < 1)
            {
                
                MessageBox.Show("Seleccion Codigo pedido", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                dtResultado = oBESol.uspCONSULTAR_SOLPED_LISTA_ID(Convert.ToInt32 ( ddlCodigo.SelectedValue.ToString()));
                if (dtResultado.Rows.Count > 0)
                {
                    try
                    {
                        ddlImputacion.SelectedValue = dtResultado.Rows[0]["IMPUTACION"].ToString();
                        ddlSociedad.SelectedValue = dtResultado.Rows[0]["SOCIEDAD"].ToString();

                        dateFecha.Text = dtResultado.Rows[0]["FECHA"].ToString();
                        lblId.Text = dtResultado.Rows[0]["IDE_SOLICITUD"].ToString();
                        txtValor.Text = dtResultado.Rows[0]["VALOR"].ToString();

                        ddlMoneda.SelectedValue = dtResultado.Rows[0]["MONEDA"].ToString();
                        string centro = dtResultado.Rows[0]["CENTRO"].ToString();
                        ddlCentro.SelectedValue = dtResultado.Rows[0]["CENTRO"].ToString();
                        //Centro();
                        //GrupoCompra();
                      

                        if (ddlImputacion.SelectedValue.ToString () == "Q")
                        {
                            string obra = dtResultado.Rows[0]["OBRA"].ToString();
                            //Obra();
                            ddlObra.SelectedValue = dtResultado.Rows[0]["OBRA"].ToString();
                        }

                        if (ddlImputacion.SelectedValue.ToString() == "K")
                        {
                            string coste = dtResultado.Rows[0]["CENTRO_COSTE"].ToString();
                            //CentroCoste();
                            ddlCoste.SelectedValue = dtResultado.Rows[0]["CENTRO_COSTE"].ToString();
                        }
                        ddlGpoCompra.SelectedValue = dtResultado.Rows[0]["GR_COMPRA"].ToString();
                        ListarPedido();
                        PanelPedidos.Visible = true;
                    }
                    catch (Exception ex)
                    {

                    }
                }
                else
                {


                    MessageBox.Show("No existe Nro de Pedido", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
        }

        private void btnBuscarMaterial_Click(object sender, EventArgs e)
        {
            ListarMateriales();
        }
        protected void ListarMateriales()
        {
            BL_LOG_SOLPED obj = new BL_LOG_SOLPED();
            DataTable dtResultado = new DataTable();
            string IDE_MATERIAL = string.Empty;
            string DES_MATERIAL = string.Empty;
            string UNIDAD = string.Empty;
            string GRUPO_ARTICULO = string.Empty;
            string CLASE_COSTE = string.Empty;
            string PEP = string.Empty;

            if (txtDescripcion.Text.Trim () != string.Empty)
            {
                DES_MATERIAL = txtDescripcion.Text;
            }

            dataGridView2.DataSource = null;
            dataGridView2.Columns.Clear();
            dataGridView2.Refresh();
            dataGridView2.AllowUserToAddRows = true;

            dataGridView2.ColumnCount = 1;
            dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            dataGridView2.Columns[0].Name = "Row";
            dataGridView2.Columns[0].HeaderText = "N°";
            dataGridView2.Columns[0].Width = 30;
            dataGridView2.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGridViewTextBoxColumn colIDE_MATERIAL = new DataGridViewTextBoxColumn();
            colIDE_MATERIAL.Name = "IDE_MATERIAL";
            colIDE_MATERIAL.HeaderText = "MATERIAL";
            colIDE_MATERIAL.Width = 80;
            dataGridView2.Columns.Insert(1, colIDE_MATERIAL);


            DataGridViewTextBoxColumn colDES_MATERIAL = new DataGridViewTextBoxColumn();
            colDES_MATERIAL.Name = "DES_MATERIAL";
            colDES_MATERIAL.HeaderText = "DESCRIPCION";
            colDES_MATERIAL.Width = 350;
            dataGridView2.Columns.Insert(2, colDES_MATERIAL);

            DataGridViewTextBoxColumn colUNIDAD = new DataGridViewTextBoxColumn();
            colUNIDAD.Name = "UNIDAD";
            colUNIDAD.HeaderText = "UNIDAD";
            colUNIDAD.Width = 50;
            colUNIDAD.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.Columns.Insert(3, colUNIDAD);

            DataGridViewTextBoxColumn colGRUPO_ARTICULO = new DataGridViewTextBoxColumn();
            colGRUPO_ARTICULO.Name = "GRUPO_ARTICULO";
            colGRUPO_ARTICULO.HeaderText = "GPO ARTICULO";
            colGRUPO_ARTICULO.Width = 80;
            colGRUPO_ARTICULO.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.Columns.Insert(4, colGRUPO_ARTICULO);


            DataGridViewButtonColumn btnPEP = new DataGridViewButtonColumn();
            btnPEP.HeaderText = "";
            btnPEP.Name = "btnPEP";
            btnPEP.Text = "(+) PEP";
            btnPEP.UseColumnTextForButtonValue = true;
            dataGridView2.Columns.Insert(5, btnPEP);


            DataGridViewComboBoxColumn cmbCol = new DataGridViewComboBoxColumn();
            cmbCol.HeaderText = "PEP";
            cmbCol.Name = "PEP";
            dataGridView2.Columns.Insert(6, cmbCol);


            DataGridViewTextBoxColumn colCantSalida = new DataGridViewTextBoxColumn();
            colCantSalida.Name = "CantidadSalida";
            colCantSalida.HeaderText = "CANT.";
            colCantSalida.Width = 60;
            colCantSalida.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.Columns.Insert(7, colCantSalida);

            DataGridViewButtonColumn btnAgregar = new DataGridViewButtonColumn();
            btnAgregar.HeaderText = "";
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Text = "(+) AGREGAR";
            btnAgregar.UseColumnTextForButtonValue = true;
            dataGridView2.Columns.Insert(8, btnAgregar);

            dataGridView2.Columns["CantidadSalida"].DefaultCellStyle.BackColor = Color.FromArgb(255, 248, 110);
            dtResultado = obj.uspSEL_LOG_MATERIALES_BUSQUEDA(IDE_MATERIAL, DES_MATERIAL, UNIDAD, GRUPO_ARTICULO, CLASE_COSTE, PEP);
            
                if (dtResultado.Rows.Count > 0)
                {
                    dataGridView2.Visible = true;
                    for (int i = 0; i < dtResultado.Rows.Count; i++)
                    {
                        string text = "item " + i; //data for text
                        int renglon = dataGridView2.Rows.Add();
                        dataGridView2.Rows[renglon].Cells["Row"].Value = dtResultado.Rows[i]["Row"].ToString();// Convert.ToString(i + 1);
                        dataGridView2.Rows[renglon].Cells["IDE_MATERIAL"].Value = dtResultado.Rows[i]["IDE_MATERIAL"].ToString();
                        dataGridView2.Rows[renglon].Cells["DES_MATERIAL"].Value = dtResultado.Rows[i]["DES_MATERIAL"].ToString();
                        dataGridView2.Rows[renglon].Cells["UNIDAD"].Value = dtResultado.Rows[i]["UNIDAD"].ToString();
                        dataGridView2.Rows[renglon].Cells["GRUPO_ARTICULO"].Value = dtResultado.Rows[i]["GRUPO_ARTICULO"].ToString();

                        DataTable table = new DataTable("table" + i);
                        table = obj.uspSEL_LOG_MATERIALES_PEP_IDE_MATERIAL(dtResultado.Rows[i]["IDE_MATERIAL"].ToString());
                        DataGridViewRow rowCol = dataGridView2.Rows[i];
                        DataGridViewComboBoxCell comboboxCell = rowCol.Cells["PEP"] as DataGridViewComboBoxCell;

                        comboboxCell.ValueMember = "PEP";
                        comboboxCell.DisplayMember = "PEP_DETALLE";
                        comboboxCell.DataSource = table;
                    }
                dataGridView2.AllowUserToAddRows = false;
            }
          
            else
            {
                dataGridView2.Visible = false;
                dataGridView2.DataSource = null;

            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;
            string x;

            if (e.ColumnIndex > -1)
            {
                if (dataGridView2.Columns[e.ColumnIndex].Name == "btnAgregar")
                {
                    DataGridViewRow Rows = dataGridView2.Rows[i];

                    string IDE_MATERIAL = (Rows.Cells["IDE_MATERIAL"].Value == null) ? "0" : Rows.Cells["IDE_MATERIAL"].Value.ToString();
                    string  CantidadSalida = ((Rows.Cells["CantidadSalida"].Value == null) ? "" : Rows.Cells["CantidadSalida"].Value.ToString());
                    string PEP =  (Rows.Cells["PEP"].Value == null) ? "" : Rows.Cells["PEP"].Value.ToString();

                    if (CantidadSalida == string.Empty || CantidadSalida =="")
                    {
                        MessageBox.Show("Ingresar cantidad", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    else if (PEP == string.Empty || PEP == null)
                    {
                        MessageBox.Show("Seleccionar PEP", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    else
                    {
                        BE_LOG_SOLPED_DETALLE oBESol = new BE_LOG_SOLPED_DETALLE();
                        oBESol.IDE_PEDIDO = 0;
                        oBESol.MATERIAL = IDE_MATERIAL;
                        oBESol.CANTIDAD = Convert.ToInt32(CantidadSalida);
                        oBESol.COD_PEDIDO = ddlCodigo.Text.ToString();//ANALIZAR
                        oBESol.IDE_SOLICITUD = Convert.ToInt32(lblId.Text);
                        oBESol.PEP = PEP;
                        int dtrpta = 0;
                        dtrpta = new BL_LOG_SOLPED_DETALLE().INS_LOG_SOLPED_DETALLE(oBESol);
                        if (dtrpta > 0)
                        {
                            //string cleanMessage = "Registro Exitoso";
                            //ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", "doAlert('" + cleanMessage + "');", true);
                            ListarPedido();
                        }
                    }

                }
                else if (dataGridView2.Columns[e.ColumnIndex].Name == "btnPEP")
                {
                    DataGridViewRow Rows = dataGridView2.Rows[i];

                    string IDE_MATERIAL = (Rows.Cells["IDE_MATERIAL"].Value == null) ? "0" : Rows.Cells["IDE_MATERIAL"].Value.ToString();

                    obj_SOLPED_E = new BE_LOG_SOLPED_DETALLE();
                    obj_SOLPED_E.MATERIAL = IDE_MATERIAL;
                    AgregarPEP f2 = new AgregarPEP(); //creamos un objeto del formulario hijo
                    DialogResult res = f2.ShowDialog();
                    if (f2.varfNuevo > 0)
                    {
                        ListarMateriales();
                    }
                }
            }
        }

        private void dataGridView2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            

            bKeyPressNum_GV_DATA = false;
            int col = dataGridView2.CurrentCell.ColumnIndex;
            TextBox txt_GV_DATA = e.Control as TextBox;
            if (dataGridView2.Columns[col].Name == "CantidadSalida") //Cantidad
            {
                bKeyPressNum_GV_DATA = true;
                if (txt_GV_DATA != null)
                {
                    txt_GV_DATA.MaxLength = 5;
                    txt_GV_DATA.KeyPress += txt_Numero_KeyPress;
                    txt_GV_DATA.KeyPress += new KeyPressEventHandler(txt_GV_DATA_KeyPress);
                }

            }

        }
        private void txt_GV_DATA_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.ToUpper(e.KeyChar);
            if (bKeyPressNum_GV_DATA == true)
            {
                if (e.KeyChar == (char)Keys.Back || (e.KeyChar == (char)'.') && !(sender as TextBox).Text.Contains("."))
                {
                    return;
                }
                decimal isNumber = 0;
                e.Handled = !decimal.TryParse(e.KeyChar.ToString(), out isNumber);
            }
            else
            {
                e.Handled = false;
            }
        }
        private void txt_Numero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back || (e.KeyChar == (char)'.') && !(sender as TextBox).Text.Contains("."))
            {
                return;
            }
            decimal isNumber = 0;
            e.Handled = !decimal.TryParse(e.KeyChar.ToString(), out isNumber);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            
            ListarCodigos();
            Imputacion();
            Sociedad();
            Moneda();
            GrupoCompra();

            lblId.Text = string.Empty;

            txtValor.Text = string.Empty;
            PanelPedidos.Visible = false;
            txtDescripcion.Text = string.Empty;

            //ListarPedido();
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView2.DataSource = null;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            DialogResult respuesta = MessageBox.Show("¿Desea eliminar materiales?", "Mensaje SSK", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (respuesta == DialogResult.Yes)
            {
                PanelPedidos.Visible = false;
                txtDescripcion.Text = string.Empty;
                BL_LOG_SOLPED_DETALLE oBESol = new BL_LOG_SOLPED_DETALLE();
                DataTable dt = new DataTable();

                if (lblId.Text != string.Empty)
                {
                    dt = oBESol.uspDEL_LOG_SOLPED_DETALLE_POR_ID(Convert.ToInt32(lblId.Text));
                    ListarPedido();
                }
                else
                {
                    MessageBox.Show("Falta consultar codigo de pedido", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
           
            
        }

        private void btnAgregarAll_Click(object sender, EventArgs e)
        {
            DialogResult respuesta = MessageBox.Show("¿Desea agregar materiales?", "Mensaje SSK", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (respuesta == DialogResult.Yes)
            {
                string x;
                int i = 0;
                int dtrpta = 0;
                foreach (DataGridViewRow Rows in dataGridView2.Rows)
                {
                    string IDE_MATERIAL = (Rows.Cells["IDE_MATERIAL"].Value == null) ? "0" : Rows.Cells["IDE_MATERIAL"].Value.ToString();
                    string CantidadSalida = ((Rows.Cells["CantidadSalida"].Value == null) ? "" : Rows.Cells["CantidadSalida"].Value.ToString());
                    string PEP = (Rows.Cells["PEP"].Value == null) ? "" : Rows.Cells["PEP"].Value.ToString();


                    if (Rows.Cells["CantidadSalida"].Value == null)
                    {
                        x = "-1";
                    }
                    else if (Rows.Cells["CantidadSalida"].Value.ToString() == "")
                    {
                        x = "-1";
                    }
                    else
                    {
                        x = Rows.Cells["CantidadSalida"].Value.ToString();
                    }


                    if (Convert.ToInt32(x) >= 0)
                    {

                        if (PEP == string.Empty || PEP == null)
                        {
                            MessageBox.Show("Seleccionar PEP", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        else
                        {

                            BE_LOG_SOLPED_DETALLE oBESol = new BE_LOG_SOLPED_DETALLE();
                            oBESol.IDE_PEDIDO = 0;
                            oBESol.MATERIAL = IDE_MATERIAL;
                            oBESol.CANTIDAD = Convert.ToInt32(CantidadSalida);
                            oBESol.COD_PEDIDO = ddlCodigo.Text.ToString();//ANALIZAR
                            oBESol.IDE_SOLICITUD = Convert.ToInt32(lblId.Text);
                            oBESol.PEP = PEP;
                          
                            dtrpta = new BL_LOG_SOLPED_DETALLE().INS_LOG_SOLPED_DETALLE(oBESol);
                            if (dtrpta > 0)
                            {
                                i++;
                                
                            }
                        }
                    }
                  
                }

                if (i > 0)
                {
                    ListarPedido();
                    MessageBox.Show("Registro Satisfactorio", "Mensaje SSK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = e.RowIndex;


            if (e.ColumnIndex > -1)
            {

                if (dataGridView1.Columns[e.ColumnIndex].Name == "btnAgregar")
                {
                    DialogResult respuesta = MessageBox.Show("¿Desea eliminar registro?", "Mensaje SSK", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (respuesta == DialogResult.Yes)
                    {
                        DataGridViewRow Rows = dataGridView1.Rows[i];

                        string IDE_PEDIDO = (Rows.Cells["IDE_PEDIDO"].Value == null) ? "0" : Rows.Cells["IDE_PEDIDO"].Value.ToString();


                        BL_LOG_SOLPED_DETALLE oBESol = new BL_LOG_SOLPED_DETALLE();
                        DataTable dt = new DataTable();
                        dt = oBESol.uspDELETE_LOG_SOLPED_DETALLE_ID(Convert.ToInt32(IDE_PEDIDO));
                        ListarPedido();
                    }
                }
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            obj_SOLPED_E = new BE_LOG_SOLPED_DETALLE();
            obj_SOLPED_E.IDE_SOLICITUD = Convert.ToInt32 (ddlCodigo.SelectedValue  );
            RptSolped  f2 = new RptSolped(); //creamos un objeto del formulario hijo
            DialogResult res = f2.ShowDialog();
           
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1)
            {

                btnBuscar.PerformClick();
            }
            if (keyData == Keys.F2)
            {
                btnNuevo.PerformClick();
            }
            if (keyData == Keys.F3)
            {
                btnGuardar.PerformClick();
            }
            if (keyData == Keys.F4)
            {
                btnExcel.PerformClick();
            }
            if (keyData == Keys.F5)
            {
                btnEliminar.PerformClick();
            }
            if (keyData == Keys.F6)
            {
                btnBuscarMaterial.PerformClick();
            }
            if (keyData == Keys.F7)
            {
                btnAgregarAll.PerformClick();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }


    }
}
