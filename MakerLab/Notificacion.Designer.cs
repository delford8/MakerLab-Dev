namespace MakerLab
{
    partial class Notificacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Notificacion));
            this.TituloNotificacion = new System.Windows.Forms.Label();
            this.boton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SubTituloNotificacion = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TituloNotificacion
            // 
            this.TituloNotificacion.AutoSize = true;
            this.TituloNotificacion.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TituloNotificacion.ForeColor = System.Drawing.Color.Black;
            this.TituloNotificacion.Location = new System.Drawing.Point(12, 9);
            this.TituloNotificacion.Name = "TituloNotificacion";
            this.TituloNotificacion.Size = new System.Drawing.Size(462, 36);
            this.TituloNotificacion.TabIndex = 0;
            this.TituloNotificacion.Text = "ERROR AL CARGAR LA NOTIFICACIÓN";
            this.TituloNotificacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // boton
            // 
            this.boton.BackColor = System.Drawing.Color.RoyalBlue;
            this.boton.FlatAppearance.BorderSize = 0;
            this.boton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MidnightBlue;
            this.boton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.CornflowerBlue;
            this.boton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.boton.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boton.ForeColor = System.Drawing.SystemColors.Control;
            this.boton.Location = new System.Drawing.Point(257, 186);
            this.boton.Name = "boton";
            this.boton.Size = new System.Drawing.Size(137, 37);
            this.boton.TabIndex = 1;
            this.boton.Text = "Cerrar";
            this.boton.UseVisualStyleBackColor = false;
            this.boton.Click += new System.EventHandler(this.boton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 240);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(682, 32);
            this.panel1.TabIndex = 2;
            // 
            // SubTituloNotificacion
            // 
            this.SubTituloNotificacion.BackColor = System.Drawing.Color.Azure;
            this.SubTituloNotificacion.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubTituloNotificacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SubTituloNotificacion.Location = new System.Drawing.Point(18, 58);
            this.SubTituloNotificacion.Multiline = true;
            this.SubTituloNotificacion.Name = "SubTituloNotificacion";
            this.SubTituloNotificacion.ReadOnly = true;
            this.SubTituloNotificacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.SubTituloNotificacion.Size = new System.Drawing.Size(652, 122);
            this.SubTituloNotificacion.TabIndex = 14;
            this.SubTituloNotificacion.Text = "ERROR AL CARGAR LA NOTIFICACION";
            this.SubTituloNotificacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Notificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(682, 272);
            this.Controls.Add(this.SubTituloNotificacion);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.boton);
            this.Controls.Add(this.TituloNotificacion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Notificacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Notificacion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TituloNotificacion;
        private System.Windows.Forms.Button boton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox SubTituloNotificacion;
    }
}