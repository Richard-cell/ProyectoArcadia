using System;

namespace UI
{
    partial class FormModificarNota
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCodAsig = new System.Windows.Forms.TextBox();
            this.txtIdEstud = new System.Windows.Forms.TextBox();
            this.txt2nota = new System.Windows.Forms.TextBox();
            this.txt3nota = new System.Windows.Forms.TextBox();
            this.txt1nota = new System.Windows.Forms.TextBox();
            this.txt4nota = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(224, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "INGRESAR NOTAS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "codigo asignatura";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nota 1° periodo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Nota 3° periodo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(293, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Id estudiante";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(293, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Nota 2° periodo";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(293, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Nota 4° periodo";
            // 
            // txtCodAsig
            // 
            this.txtCodAsig.Location = new System.Drawing.Point(148, 81);
            this.txtCodAsig.Name = "txtCodAsig";
            this.txtCodAsig.Size = new System.Drawing.Size(100, 20);
            this.txtCodAsig.TabIndex = 7;
            // 
            // txtIdEstud
            // 
            this.txtIdEstud.Location = new System.Drawing.Point(388, 81);
            this.txtIdEstud.Name = "txtIdEstud";
            this.txtIdEstud.Size = new System.Drawing.Size(100, 20);
            this.txtIdEstud.TabIndex = 8;
            // 
            // txt2nota
            // 
            this.txt2nota.Location = new System.Drawing.Point(388, 123);
            this.txt2nota.Name = "txt2nota";
            this.txt2nota.Size = new System.Drawing.Size(100, 20);
            this.txt2nota.TabIndex = 9;
            // 
            // txt3nota
            // 
            this.txt3nota.Location = new System.Drawing.Point(148, 150);
            this.txt3nota.Name = "txt3nota";
            this.txt3nota.Size = new System.Drawing.Size(100, 20);
            this.txt3nota.TabIndex = 10;
            // 
            // txt1nota
            // 
            this.txt1nota.Location = new System.Drawing.Point(148, 115);
            this.txt1nota.Name = "txt1nota";
            this.txt1nota.Size = new System.Drawing.Size(100, 20);
            this.txt1nota.TabIndex = 11;
            // 
            // txt4nota
            // 
            this.txt4nota.Location = new System.Drawing.Point(388, 159);
            this.txt4nota.Name = "txt4nota";
            this.txt4nota.Size = new System.Drawing.Size(100, 20);
            this.txt4nota.TabIndex = 12;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(161, 219);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 13;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click_1);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(286, 219);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 14;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // FormModificarNota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 300);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txt4nota);
            this.Controls.Add(this.txt1nota);
            this.Controls.Add(this.txt3nota);
            this.Controls.Add(this.txt2nota);
            this.Controls.Add(this.txtIdEstud);
            this.Controls.Add(this.txtCodAsig);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormModificarNota";
            this.Text = "FormModificarNota";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCodAsig;
        private System.Windows.Forms.TextBox txtIdEstud;
        private System.Windows.Forms.TextBox txt2nota;
        private System.Windows.Forms.TextBox txt3nota;
        private System.Windows.Forms.TextBox txt1nota;
        private System.Windows.Forms.TextBox txt4nota;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCerrar;
    }
}