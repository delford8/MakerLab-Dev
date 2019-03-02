namespace MakerLab
{
    partial class Actualizador
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Actualizador));
            this.TituloActualizador = new System.Windows.Forms.Label();
            this.boton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SubTituloActualizador = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TituloActualizador
            // 
            this.TituloActualizador.AutoSize = true;
            this.TituloActualizador.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TituloActualizador.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.TituloActualizador.Location = new System.Drawing.Point(134, 41);
            this.TituloActualizador.Name = "TituloActualizador";
            this.TituloActualizador.Size = new System.Drawing.Size(398, 36);
            this.TituloActualizador.TabIndex = 0;
            this.TituloActualizador.Text = "ACTUALIZACIÓN ENCONTRADA!";
            // 
            // boton
            // 
            this.boton.BackColor = System.Drawing.Color.SkyBlue;
            this.boton.FlatAppearance.BorderSize = 0;
            this.boton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.boton.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boton.ForeColor = System.Drawing.SystemColors.Control;
            this.boton.Location = new System.Drawing.Point(268, 166);
            this.boton.Name = "boton";
            this.boton.Size = new System.Drawing.Size(137, 37);
            this.boton.TabIndex = 1;
            this.boton.Text = "Descargar";
            this.boton.UseVisualStyleBackColor = false;
            this.boton.Click += new System.EventHandler(this.boton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 240);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(682, 32);
            this.panel1.TabIndex = 2;
            // 
            // SubTituloActualizador
            // 
            this.SubTituloActualizador.AutoSize = true;
            this.SubTituloActualizador.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubTituloActualizador.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.SubTituloActualizador.Location = new System.Drawing.Point(34, 88);
            this.SubTituloActualizador.Name = "SubTituloActualizador";
            this.SubTituloActualizador.Size = new System.Drawing.Size(619, 58);
            this.SubTituloActualizador.TabIndex = 3;
            this.SubTituloActualizador.Text = "Hay una actualización disponible, por favor descargela ahora\r\n(En las proximas ve" +
    "rsiones este proceso sera automatico)";
            // 
            // Actualizador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(682, 272);
            this.Controls.Add(this.SubTituloActualizador);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.boton);
            this.Controls.Add(this.TituloActualizador);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Actualizador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Notificacion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TituloActualizador;
        private System.Windows.Forms.Button boton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label SubTituloActualizador;
    }
}