using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Importaciones adicionales
using Platform.Modeler.Modelo;

namespace EjercicioLINQ
{
    public partial class Form1 : Form
    {

        ClsEstudiante estudiante;
        //clsValidaciones validacion;


        #region constructores e inicializadores

        public Form1()
        {
            InitializeComponent();
            estudiante = new ClsEstudiante();
            //validacion = new clsValidaciones();
        }

        private void estudianteBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.estudianteBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.ejemploConexionBDDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'ejemploConexionBDDataSet.estudiante' Puede moverla o quitarla según sea necesario.
            listar();
        }

        #endregion


        #region botones

        private void button1_Click(object sender, EventArgs e)
        {
            String codigo = txtCodigo.Text;
            String nombre = txtNombre.Text;
            String apellido = txtApellido.Text;
            int edad = Convert.ToInt32((!txtEdad.Text.Equals("")) ? txtEdad.Text : "0");
            String carrera = txtCarrera.Text;
            String semestre = txtSemestre.Text;

            if (estudiante.guardar(codigo, nombre, apellido, edad, carrera, semestre))
            {
                limpiar();
                MessageBox.Show("Guardado con exito");
                listar();
            }
            else
            {
                MessageBox.Show("Error al guardar");
            }
        }




        private void button9_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String codigo = txtCodigo.Text;

            LinkedList<String> temp = new LinkedList<String>();
            temp = estudiante.buscar(codigo);

            if (temp.Count > 0)
            {
                txtCodigo.Enabled = false;
                btnModificar.Enabled = true;
                btnEliminar.Enabled = true;
                txtCodigo.Text = temp.ElementAt(0);
                txtNombre.Text = temp.ElementAt(1);
                txtApellido.Text = temp.ElementAt(2);
                txtEdad.Text = temp.ElementAt(3);
                txtCarrera.Text = temp.ElementAt(4);
                txtSemestre.Text = temp.ElementAt(5);
            }
            else
            {
                MessageBox.Show("No se encuentra el registro");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            String codigo = txtCodigo.Text;
            String nombre = txtNombre.Text;
            String apellido = txtApellido.Text;
            int edad = Convert.ToInt32(txtEdad.Text);
            String carrera = txtCarrera.Text;
            String semestre = txtSemestre.Text;

            if (estudiante.modificar(codigo, nombre, apellido, edad, carrera, semestre))
            {
                limpiar();
                MessageBox.Show("Modificado con exito");
                listar();
            }
            else
            {
                MessageBox.Show("Error al modificar");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            String codigo = txtCodigo.Text;

            if (estudiante.eliminar(codigo))
            {
                limpiar();
                MessageBox.Show("Eliminado con exito");
                listar();
            }
            else
            {
                MessageBox.Show("No se pudo eliminar");
            }
        }

        #endregion


        #region funciones varias

        public void listar()
        {
            this.estudianteTableAdapter.Fill(this.ejemploConexionBDDataSet.estudiante);
        }

        public void limpiar()
        {
            txtCodigo.Enabled = true;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            btnModificarP.Enabled = false;
            btnEliminarP.Enabled = false;
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtEdad.Text = "";
            txtCarrera.Text = "";
            txtSemestre.Text = "";
        }


        #endregion


        #region validaciones

        private void txtInputNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            { // si es enter
                e.Handled = true; //no ponga el enter en el campo de text
                SendKeys.Send("{TAB}");//se manda un TAB a la interfaz
            }
            else
            {
               // e.Handled = validacion.numeros(e.KeyChar); //ponga el valor ingresado en el campo de text
            }
        }



        private void txtInput_keyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            { // si es enter
                e.Handled = true; //no ponga el enter en el campo de text
                SendKeys.Send("{TAB}");//se manda un TAB a la interfaz
            }
            else
            {
                e.Handled = false; //ponga el valor ingresado en el campo de text
            }
        }
        #endregion

        private void btnGuardarP_Click(object sender, EventArgs e)
        {
            String codigo = txtCodigo.Text;
            String nombre = txtNombre.Text;
            String apellido = txtApellido.Text;
            int edad = Convert.ToInt32((!txtEdad.Text.Equals("")) ? txtEdad.Text : "0");
            String carrera = txtCarrera.Text;
            String semestre = txtSemestre.Text;

            if (estudiante.guardarP(codigo, nombre, apellido, edad, carrera, semestre))
            {
                limpiar();
                MessageBox.Show("Guardado con exito");
                listar();
            }
            else
            {
                MessageBox.Show("Error al guardar");
            }
        }

        private void btnBuscarP_Click(object sender, EventArgs e)
        {
            String codigo = txtCodigo.Text;

            LinkedList<String> temp = new LinkedList<String>();
            temp = estudiante.buscarP(codigo);

            if (temp.Count > 0)
            {
                txtCodigo.Enabled = false;
                btnModificarP.Enabled = true;
                btnEliminarP.Enabled = true;
                txtCodigo.Text = temp.ElementAt(0);
                txtNombre.Text = temp.ElementAt(1);
                txtApellido.Text = temp.ElementAt(2);
                txtEdad.Text = temp.ElementAt(3);
                txtCarrera.Text = temp.ElementAt(4);
                txtSemestre.Text = temp.ElementAt(5);
            }
            else
            {
                MessageBox.Show("No se encuentra el registro");
            }
        }

        private void btnModificarP_Click(object sender, EventArgs e)
        {
            String codigo = txtCodigo.Text;
            String nombre = txtNombre.Text;
            String apellido = txtApellido.Text;
            int edad = Convert.ToInt32(txtEdad.Text);
            String carrera = txtCarrera.Text;
            String semestre = txtSemestre.Text;

            if (estudiante.modificarP(codigo, nombre, apellido, edad, carrera, semestre))
            {
                limpiar();
                MessageBox.Show("Modificado con exito");
                listar();
            }
            else
            {
                MessageBox.Show("Error al modificar");
            }
        }

        private void btnEliminarP_Click(object sender, EventArgs e)
        {
            String codigo = txtCodigo.Text;

            if (estudiante.eliminarP(codigo))
            {
                limpiar();
                MessageBox.Show("Eliminado con exito");
                listar();
            }
            else
            {
                MessageBox.Show("No se pudo eliminar");
            }
        }
    }
}
