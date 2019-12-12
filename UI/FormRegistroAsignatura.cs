using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Web.Script.Serialization;
using System.Net.Http.Headers;
using System.Net.Http;



namespace UI
{
    public partial class FormRegistroAsignatura : Form
    {
        public FormRegistroAsignatura()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            this.Registrar();
        }

        private void Registrar()
        {
            string apiUrl = "http://localhost:44359/api/Asignatura";
            object input = new
            {
                Code = txtNombre.Text.Trim(),
                Name = txtNombre.Text.Trim()
            };
            string inputJson = (new JavaScriptSerializer()).Serialize(input);
            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;
            string json = client.UploadString(apiUrl + "/Registrar Asignatura", inputJson);

            //dataGridView1.DataSource = (new JavaScriptSerializer()).Deserialize<List<Asignatura>>(json);
        }
    }
}
