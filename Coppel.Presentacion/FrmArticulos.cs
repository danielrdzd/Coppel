using Coppel.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coppel.Presentacion
{
    public partial class FrmArticulos : Form
    {
        public FrmArticulos()
        {
            InitializeComponent();
        }

        string skuanterior;
        string idArticulo;
        //listamos los articulos
        private void Listar()
        {
            //listamos los articulos
            DgvListado.DataSource = NArticulo.Listar();
        }

        private void Buscar()
        {
            this.Formato();
            var tabla = NArticulo.Buscar(Convert.ToInt32(mtxtBuscar.Text));

            if(tabla.Rows.Count > 0)
            {
                DgvListado.Visible = true;
                DgvListado.DataSource = tabla;
            }
            else
            {
                MessageBox.Show("No existe ese articulo con ese SKU, verificalo");
                DgvListado.Visible = false;
                mtxtBuscar.Text = "";
                mtxtBuscar.Focus();
            }
               
                
            
        }

        private void Formato()
        {
            //formato al data grid view
            DgvListado.Columns[0].Visible = false;
            DgvListado.Columns[5].HeaderText = "Departamento";
            DgvListado.Columns[6].HeaderText = "Familia";
            DgvListado.Columns[7].HeaderText = "Clase";

            //formato al data grid view
           
           
        }

        private string validarSku(int valor)
        {
            //validamos el sku del producto
            string rpta = "";
            int sku = valor;
            rpta = NArticulo.Existe(Convert.ToInt32(sku));
            return rpta;
            
        }

        private void limpiar()
        {

            mtxtsku.Clear();
            txtarticulo.Clear();
            txtMarca.Clear();
            txtModelo.Clear();
            cboDepartamento.SelectedValue.ToString();
            cboDepartamento.SelectedValue.ToString();
            cboDepartamento.SelectedValue.ToString();
            btnInsertar.Visible = false;
            ndStock.Value = 0;
            ndCantidad.Value = 0;
        }

        private void llenarCombos()
        {
            //listamos los departamentos
            cboDepartamento.DataSource =  NDepartamento.Listar();
            cboDepartamento.ValueMember = "ID";
            cboDepartamento.DisplayMember = "Nombre";

            //listamos las familias
            cboFamilia.DataSource = NFamilia.Listar();
            cboFamilia.ValueMember = "ID";
            cboFamilia.DisplayMember = "Nombre";

            //listamos las clases
            cboClase.DataSource = NClase.Listar();
            cboClase.ValueMember = "ID";
            cboClase.DisplayMember = "Nombre";


            //listamos los departamentos
            cboDepartamentoEditar.DataSource = NDepartamento.Listar();
            cboDepartamentoEditar.ValueMember = "ID";
            cboDepartamentoEditar.DisplayMember = "Nombre";

            //listamos las familias
            cbofamiliaeditar.DataSource = NFamilia.Listar();
            cbofamiliaeditar.ValueMember = "ID";
            cbofamiliaeditar.DisplayMember = "Nombre";

            //listamos las clases
            cboClaseEditar.DataSource = NClase.Listar();
            cboClaseEditar.ValueMember = "ID";
            cboClaseEditar.DisplayMember = "Nombre";
        }
        private void FrmArticulos_Load(object sender, EventArgs e)
        {
            btnActualizar.Visible = false;
            this.Listar();
            this.llenarCombos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar();
            
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            DgvListado.Visible = false;
            mtxtBuscar.Text = "";
            mtxtBuscar.Focus();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                string Rpta = "";
                //capturamos la data
                string sku = mtxtsku.Text;
                string articulo = txtarticulo.Text;
                string marca = txtMarca.Text;
                string modelo = txtModelo.Text;
                string departamento = cboDepartamento.SelectedValue.ToString();
                string clase = cboDepartamento.SelectedValue.ToString();
                string familia = cboDepartamento.SelectedValue.ToString();

                int stock = Convert.ToInt32(ndStock.Value);
                int cantidad = Convert.ToInt32(ndCantidad.Value);
                if (cantidad > stock )
                {
                    MessageBox.Show("la cantidad no sea mayor que el stock");
                    ndCantidad.Value = 0;
                    ndStock.Value = 0;
                    
                    return;
                }

                //campos obligatorios
                if(articulo == "" || marca == "" || modelo == "")
                {
                    MessageBox.Show("llena los campos faltantes");
                    
                    return;
                }

                //TE VAS Y EJECUTAS EL METODO INSERTAR DE NEGOCIO
                Rpta = NArticulo.Insertar(Convert.ToInt32( sku), articulo, marca, modelo, Convert.ToInt32(departamento), Convert.ToInt32(clase), Convert.ToInt32(familia), stock, cantidad);

                if (Rpta.Equals("OK"))
                {
                    MessageBox.Show("Se inserto correctamente");
                    this.limpiar();
                }
                else
                {
                    MessageBox.Show(Rpta);
                    btnInsertar.Visible = false;
                }



            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
          

           
          
            


        }

        private void txtsku_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }



        private void txtsku_Leave(object sender, EventArgs e)
        {
            
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

        }

        private void mtxtsku_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validamos al presionar enter
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                string rpta = this.validarSku(Convert.ToInt32
                    (mtxtsku.Text));

                if (rpta.Equals("OK"))
                {
                    MessageBox.Show("Ese sku ya existe intenta con otro");
                }
                else
                {
                    MessageBox.Show("Ese sku esta disponible");
                    btnInsertar.Visible = true;
                }


            }
        }

        private void maskedtxteditarsku_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.limpiar();
        }

        private void meditarSkuTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                
                string rpta = this.validarSku(Convert.ToInt32
                     (meditarSkuTxt.Text));


                if (rpta.Equals("OK"))
                {

                    this.llenarCombos();
                    MessageBox.Show("Sku adecuado puedes editarlo");
                    btnActualizar.Visible = true;

                   
;                
                    dgveditar.DataSource = NArticulo.Buscar(Convert.ToInt32
                     (meditarSkuTxt.Text));


                    

                    meditarSkuTxt.Text = Convert.ToString(dgveditar.CurrentRow.Cells["Sku"].Value);
                    skuanterior = Convert.ToString(dgveditar.CurrentRow.Cells["Sku"].Value);
                    //pasamos la informacion a los textbox
                    txtArticuloEditar.Text = Convert.ToString(dgveditar.CurrentRow.Cells["Articulo"].Value);
                    txtMarcaEditar.Text = Convert.ToString(dgveditar.CurrentRow.Cells["Marca"].Value);
                    txtModeloEditar.Text = Convert.ToString(dgveditar.CurrentRow.Cells["Modelo"].Value);
                    cboDepartamentoEditar.SelectedValue = Convert.ToString(dgveditar.CurrentRow.Cells["iddepartamento"].Value);
                    cbofamiliaeditar.SelectedValue = Convert.ToString(dgveditar.CurrentRow.Cells["idFamilia"].Value);
                    cboClaseEditar.SelectedValue = Convert.ToString(dgveditar.CurrentRow.Cells["idClase"].Value);
                    idArticulo = Convert.ToString(dgveditar.CurrentRow.Cells["idArticulo"].Value);
                    txteditarid.Text = idArticulo;

                    //ocultamos
                    dgveditar.Visible = false;
                }
                else
                {
                    MessageBox.Show("Ese sku no existe");
                    meditarSkuTxt.Clear();
                    btnActualizar.Visible = false;
                }
            }
        }
        
        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            try
            {
                string Rpta = "";
                //capturamos la data
                string sku = meditarSkuTxt.Text;
                string articulo = txtArticuloEditar.Text;
                string marca = txtMarcaEditar.Text;
                string modelo = txtModeloEditar.Text;
                string departamento = cboDepartamentoEditar.SelectedValue.ToString();
                string clase = cboClaseEditar.SelectedValue.ToString();
                string familia = cbofamiliaeditar.SelectedValue.ToString();

                int stock = Convert.ToInt32(nStockeditar.Value);
                int cantidad = Convert.ToInt32(nCantidadEditar.Value);
                if (cantidad > stock)
                {
                    MessageBox.Show("la cantidad no sea mayor que el stock");
                    ndCantidad.Value = 0;
                    ndStock.Value = 0;

                    return;
                }

                //campos obligatorios
                if (articulo == "" || marca == "" || modelo == "")
                {
                    MessageBox.Show("llena los campos faltantes");

                    return;
                }

                Rpta = NArticulo.Actualizar( Convert.ToInt32(idArticulo),  Convert.ToInt32(sku), Convert.ToInt32(skuanterior), articulo, marca, modelo, Convert.ToInt32(departamento), Convert.ToInt32(clase), Convert.ToInt32(familia), stock, cantidad);

                if (Rpta.Equals("OK"))
                {
                    MessageBox.Show("Se actualizo correctamente");
                    this.limpiar();
                }
                else
                {
                    MessageBox.Show(Rpta);
                    btnInsertar.Visible = false;
                }



            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }





        }
    }
}
