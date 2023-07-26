using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SistemaEntrenamiento
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Refresh();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
       
        }
        override          
        public void Refresh()
        {
            cursoDB oCurso = new cursoDB();
            dataGridView1.DataSource = oCurso.GetCursos();
        }
        //nuevo elemento
        private void button1_Click(object sender, EventArgs e)
        {
            FrmNuevo nuevoF = new FrmNuevo();
            nuevoF.ShowDialog();
            Refresh();
        }

        #region HELPER
        private int? GetId()
        {
            try 
            {
                return int.Parse(
                          dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString()
                                 );

            }
            catch{ }
            {
                return null;
            }
 
        }
        #endregion
        //Editar elemento
        private void button2_Click(object sender, EventArgs e)
        {
            int? ID = GetId();
            if ( ID != null )
            {
                FrmNuevo frmEdit = new FrmNuevo(ID);
                frmEdit.ShowDialog();
                Refresh();
            }
        }
        //Eliminar elemento
        private void button3_Click(object sender, EventArgs e)
        {
            int? ID = GetId();
            try
            {
                if (ID != null)
                {
                    cursoDB oCurso = new cursoDB();
                    oCurso.eliminarCurso((int)ID);
                    Refresh();

                }
                else
                {
                    MessageBox.Show("Seleccione una fila");
                }
            }
            catch(Exception ex) {
                throw new Exception("Error " + ex);
  
            }
        }
    }
}
