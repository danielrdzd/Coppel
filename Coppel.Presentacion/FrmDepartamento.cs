using Coppel.Negocio;
using System;
using System.Windows.Forms;

namespace Coppel.Presentacion
{
    public partial class FrmDepartamento : Form
    {

        private string NombreAnt;


        public FrmDepartamento()
        {
            InitializeComponent();
        }

        private void Listar()
        {
            try
            {
                DgvListado.DataSource = NDepartamento.Listar();
                //le damos formato
                this.Formato();
                this.Limpiar();
                //total de registros
                lbltotal.Text = "Total de registros: " + DgvListado.Rows.Count;
            }
            catch (Exception ex)
            {
                //mostramos mensajes de todas las capas
                MessageBox.Show(ex.Message + ex.StackTrace);    
            }
        }

        
        private void Formato()
        {
            DgvListado.Columns[0].Visible = false;
            DgvListado.Columns[1].Visible = false;
            DgvListado.Columns[2].Width = 600;
            DgvListado.Columns[3].Width = 150;
            DgvListado.Columns[2].HeaderText = "Nombre departamento";
           
            


            
        }


        private void Limpiar()
        {
            //deja en blanco las cajas de texto
            txtBuscar.Clear();
            txtNombre.Clear();
            txtId.Clear();
            btnInsertar.Visible = true;
            btnActualizar.Visible = false;
            errorIcono.Clear();

            DgvListado.Columns[0].Visible = false;
            btneliminar.Visible = false;

            checkBox1.Checked = false;
        }

        //mostrar mensaje de rror
        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema Coppel", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //mostrar mensaje de ok
        private void MensajeOk(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema Coppel", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Buscar()
        {
            //validar que no venga vacio el textbox
            try
            {
                DgvListado.DataSource = NDepartamento.Buscar(txtBuscar.Text);
                //le damos formato
                this.Formato();
                //total de registros
                lbltotal.Text = "Total de registros: " + DgvListado.Rows.Count;
            }
            catch (Exception ex)
            {
                //mostramos mensajes de todas las capas
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void FrmDepartamento_Load(object sender, EventArgs e)
        {
            //cuando cargue llame a listar
            this.Listar();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if(txtBuscar.Text == "")
            {
                MessageBox.Show("No puede ir vacio el campo de busqueda");

            }
            else
            {
                //llamamos el metodo buscar
                this.Buscar();
            }
            
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                string Rpta = "";
                if(txtNombre.Text == string.Empty)
                {
                    this.MensajeError("Falta ingresar el dato");
                    errorIcono.SetError(txtNombre, "Ingresa un nombre");
                }
                else
                {
                    Rpta = NDepartamento.Insertar(txtNombre.Text.Trim());
                    if (Rpta.Equals("OK"))
                    {
                        this.MensajeOk("Departamento Insertado");
                        this.Limpiar();
                        this.Listar();
                    }
                    else
                    {
                        this.MensajeError(Rpta);
                        this.Limpiar();
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //si cancelamos 
            this.Limpiar();
            tabGeneral.SelectedIndex = 0;
        }

        private void DgvListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.Limpiar();
                btnActualizar.Visible = true;
                btnInsertar.Visible = false;
                //obtenemos el id de la row donde dimos click, son los nombres de la base de datos
                txtId.Text = Convert.ToString(DgvListado.CurrentRow.Cells["ID"].Value);
                this.NombreAnt = Convert.ToString(DgvListado.CurrentRow.Cells["Nombre"].Value);
                txtNombre.Text = Convert.ToString(DgvListado.CurrentRow.Cells["Nombre"].Value);

                //cambiamos a la ventana de manteniumiento
                tabGeneral.SelectedIndex = 1;
            }
            catch (Exception)
            {

                MessageBox.Show("Seleccione desde la celda nombre");
            }
           
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                string Rpta = "";
                if (txtNombre.Text == string.Empty || txtId.Text == string.Empty)
                {
                    this.MensajeError("Falta ingresar el dato");
                    errorIcono.SetError(txtNombre, "Ingresa un nombre");
                }
                else
                {
                    Rpta = NDepartamento.Actualizar(Convert.ToInt32(txtId.Text), this.NombreAnt,  txtNombre.Text.Trim());
                    if (Rpta.Equals("OK"))
                    {
                        this.MensajeOk("Departamento actualizado");
                        this.Limpiar();
                        this.Listar();
                    }
                    else
                    {
                        this.MensajeError(Rpta);
                       
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //cuando le douy click aparece la columna seleccionar y el boton eliminar
            if (checkBox1.Checked)
            {
                DgvListado.Columns[0].Visible = true;
                btneliminar.Visible = true;
            }
            else
            {
                DgvListado.Columns[0].Visible = false;
                btneliminar.Visible = false;
            }
        }

        private void DgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //si seleccione el checbok de una fila
           if(e.ColumnIndex == DgvListado.Columns["Seleccionar"].Index)
            {
                //permite seleccionar los registros
                DataGridViewCheckBoxCell chkEliminar = (DataGridViewCheckBoxCell) DgvListado.Rows[e.RowIndex].Cells["Seleccionar"];
                chkEliminar.Value = !Convert.ToBoolean(chkEliminar.Value);

            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("¿Deseas eliminar el(los) registro(s)?", "Sistema Coppel", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if(Opcion == DialogResult.OK)
                {
                    int Codigo;
                    string Rpta = "";

                    //recorremos todas las filas del dgv
                    foreach(DataGridViewRow row in DgvListado.Rows)
                    {
                        //indicamos si esta seleccionado el chekbox
                        if(Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToInt32(row.Cells[1].Value);
                            Rpta = NDepartamento.Eliminar(Codigo);

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se elimino el registro: " + Convert.ToString(row.Cells[2].Value) );
                            }
                            else
                            {
                                this.MensajeError(Rpta);
                            }
                        }
                    }

                    this.Listar();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
