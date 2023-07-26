using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaEntrenamiento
{
    public partial class FrmNuevo : Form
    {
        private int? Id;

        public FrmNuevo(int? Id = null)
        {
            InitializeComponent();
            this.Id = Id;
            if(this.Id != null)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            cursoDB oCurso = new cursoDB();
            Curso EditarCurso = oCurso.GetCurso((int)Id);
            txtTitulo.Text = EditarCurso.titulo;
            txtDescripcion.Text = EditarCurso.descripcion;
            txtDuracion.Text = EditarCurso.duracion.ToString();
            txtNivel.Text = EditarCurso.nivel;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmNuevo_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
         
            cursoDB oCurso = new cursoDB();
            try
            {
                if(Id != null)
                {
                    oCurso.editarCurso(txtTitulo.Text, txtDescripcion.Text, Int32.Parse(txtDuracion.Text), txtNivel.Text, (int)Id);
                    this.Close();
                }
                else
                {
                    oCurso.AddCurso(txtTitulo.Text, txtDescripcion.Text, Int32.Parse(txtDuracion.Text), txtNivel.Text);
                    txtTitulo.ResetText();
                    txtDescripcion.ResetText();
                    txtDuracion.ResetText();
                    txtNivel.ResetText();
                    
                }

               
            }catch(Exception ex)
            {
               throw new Exception("Hay un error" + ex);

            }
        }
    }
}
