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
    }
}
