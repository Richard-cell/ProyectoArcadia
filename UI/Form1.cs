using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void registrarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormRegistroDocente form = new FormRegistroDocente();
            form.ShowDialog();
        }

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRegistrarMatricula form = new FormRegistrarMatricula();
            form.ShowDialog();
        }

        private void registrarToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            FormRegistroAsignatura form = new FormRegistroAsignatura();
            form.ShowDialog();
        }

        private void registrarToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            FormRegistroCurso form = new FormRegistroCurso();
            form.ShowDialog();
        }

        private void registrarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FormRegistroNota form = new FormRegistroNota();
            form.ShowDialog();
        }

        private void pagarCuotaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPagarCuotaDePension form = new FormPagarCuotaDePension();
            form.ShowDialog();
        }

        private void cancelarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCancelarMatricula form = new FormCancelarMatricula();
            form.ShowDialog();
        }

        private void ingresarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormModificarNota form = new FormModificarNota();
            form.ShowDialog();
        }

        private void asignarDocenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAsignarDocenteAsignatura form = new FormAsignarDocenteAsignatura();
            form.ShowDialog();
        }

        private void asignarEstudianteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAsignarEstudianteCurso form = new FormAsignarEstudianteCurso();
            form.ShowDialog();
        }

        private void asignarDocenteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormAsignarDocenteCurso form = new FormAsignarDocenteCurso();
            form.ShowDialog();
        }
    }
}
