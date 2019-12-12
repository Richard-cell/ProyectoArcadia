using Newtonsoft.Json;
using RestSharp;
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
    public partial class FormRegistroCurso : Form
    {
        public FormRegistroCurso()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var client = new RestClient("https://localhost:44359/api/curso");
            var request = new RestRequest(Method.POST);
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/json");

            var curso = new Curso();

            curso.Codigo = long.Parse(txtCodigo.Text);
            curso.Grado = int.Parse(txtGrado.Text);
            string body = JsonConvert.SerializeObject(curso);

            //request.AddParameter("undefined", "{\n\t\"Numero\":\"258\",\n\t\"Nombre\": \"luisa\"\n}\n", ParameterType.RequestBody);
            request.AddParameter("undefined", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            MessageBox.Show(response.StatusDescription);
        }
    }

    public class Curso 
    {
        public long Codigo { get; set; }
        public int Grado { get; set; }
    }
}
