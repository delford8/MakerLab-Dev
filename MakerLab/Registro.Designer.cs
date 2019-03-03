namespace MakerLab
{
    partial class Registro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Registro));
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.CrearBoton = new System.Windows.Forms.Button();
            this.CrearContraseña = new System.Windows.Forms.TextBox();
            this.CrearUsuario = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.ClaveRegistro = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.CrearReContraseña = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(108)))), ((int)(((byte)(0)))));
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.Control;
            this.button3.Location = new System.Drawing.Point(632, 625);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(102, 23);
            this.button3.TabIndex = 19;
            this.button3.Text = "Inicia Sesión";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(499, 628);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 15);
            this.label3.TabIndex = 18;
            this.label3.Text = "Ya tienes una cuenta?";
            // 
            // CrearBoton
            // 
            this.CrearBoton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.CrearBoton.Enabled = false;
            this.CrearBoton.FlatAppearance.BorderSize = 0;
            this.CrearBoton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(108)))), ((int)(((byte)(0)))));
            this.CrearBoton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(162)))), ((int)(((byte)(60)))));
            this.CrearBoton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CrearBoton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CrearBoton.ForeColor = System.Drawing.SystemColors.Control;
            this.CrearBoton.Location = new System.Drawing.Point(565, 581);
            this.CrearBoton.Name = "CrearBoton";
            this.CrearBoton.Size = new System.Drawing.Size(128, 32);
            this.CrearBoton.TabIndex = 17;
            this.CrearBoton.Text = "Crear Cuenta";
            this.CrearBoton.UseVisualStyleBackColor = false;
            this.CrearBoton.Click += new System.EventHandler(this.CrearBoton_Click);
            // 
            // CrearContraseña
            // 
            this.CrearContraseña.BackColor = System.Drawing.Color.Black;
            this.CrearContraseña.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CrearContraseña.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CrearContraseña.ForeColor = System.Drawing.Color.White;
            this.CrearContraseña.Location = new System.Drawing.Point(523, 361);
            this.CrearContraseña.MaxLength = 255;
            this.CrearContraseña.Name = "CrearContraseña";
            this.CrearContraseña.Size = new System.Drawing.Size(215, 19);
            this.CrearContraseña.TabIndex = 14;
            this.CrearContraseña.UseSystemPasswordChar = true;
            this.CrearContraseña.TextChanged += new System.EventHandler(this.CrearContraseña_TextChanged);
            this.CrearContraseña.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CrearContraseña_KeyDown);
            // 
            // CrearUsuario
            // 
            this.CrearUsuario.BackColor = System.Drawing.Color.Black;
            this.CrearUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CrearUsuario.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CrearUsuario.ForeColor = System.Drawing.Color.White;
            this.CrearUsuario.Location = new System.Drawing.Point(523, 277);
            this.CrearUsuario.MaxLength = 20;
            this.CrearUsuario.Name = "CrearUsuario";
            this.CrearUsuario.Size = new System.Drawing.Size(215, 19);
            this.CrearUsuario.TabIndex = 13;
            this.CrearUsuario.TextChanged += new System.EventHandler(this.CrearUsuario_TextChanged);
            this.CrearUsuario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CrearUsuario_KeyDown);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel3.Location = new System.Drawing.Point(523, 381);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(215, 1);
            this.panel3.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel2.Location = new System.Drawing.Point(523, 297);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(215, 1);
            this.panel2.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.button2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1191, 30);
            this.panel1.TabIndex = 10;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Gray;
            this.button2.Location = new System.Drawing.Point(1149, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(30, 30);
            this.button2.TabIndex = 2;
            this.button2.Text = "X";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ClaveRegistro
            // 
            this.ClaveRegistro.BackColor = System.Drawing.Color.Black;
            this.ClaveRegistro.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ClaveRegistro.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClaveRegistro.ForeColor = System.Drawing.Color.White;
            this.ClaveRegistro.Location = new System.Drawing.Point(523, 532);
            this.ClaveRegistro.MaxLength = 10;
            this.ClaveRegistro.Name = "ClaveRegistro";
            this.ClaveRegistro.Size = new System.Drawing.Size(215, 19);
            this.ClaveRegistro.TabIndex = 21;
            this.ClaveRegistro.TextChanged += new System.EventHandler(this.ClaveRegistro_TextChanged);
            this.ClaveRegistro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ClaveRegistro_KeyDown);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel4.Location = new System.Drawing.Point(523, 552);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(215, 1);
            this.panel4.TabIndex = 20;
            // 
            // CrearReContraseña
            // 
            this.CrearReContraseña.BackColor = System.Drawing.Color.Black;
            this.CrearReContraseña.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CrearReContraseña.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CrearReContraseña.ForeColor = System.Drawing.Color.White;
            this.CrearReContraseña.Location = new System.Drawing.Point(523, 454);
            this.CrearReContraseña.MaxLength = 255;
            this.CrearReContraseña.Name = "CrearReContraseña";
            this.CrearReContraseña.Size = new System.Drawing.Size(215, 19);
            this.CrearReContraseña.TabIndex = 24;
            this.CrearReContraseña.UseSystemPasswordChar = true;
            this.CrearReContraseña.TextChanged += new System.EventHandler(this.CrearReContraseña_TextChanged);
            this.CrearReContraseña.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CrearReContraseña_KeyDown);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel5.Location = new System.Drawing.Point(523, 474);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(215, 1);
            this.panel5.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(234, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(809, 59);
            this.label6.TabIndex = 14;
            this.label6.Text = "ACCESO A SISTEMA DE IDENTIFICACIÓN";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(519, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(206, 78);
            this.label7.TabIndex = 11;
            this.label7.Text = "ASMIE";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(517, 316);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(145, 33);
            this.label8.TabIndex = 13;
            this.label8.Text = "Contraseña:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(517, 238);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 33);
            this.label9.TabIndex = 12;
            this.label9.Text = "Usuario:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(517, 405);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(230, 33);
            this.label1.TabIndex = 26;
            this.label1.Text = "Repetir Contraseña:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(517, 485);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(212, 33);
            this.label10.TabIndex = 27;
            this.label10.Text = "Clave De Registro:";
            // 
            // Registro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1191, 652);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.CrearReContraseña);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.ClaveRegistro);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CrearBoton);
            this.Controls.Add(this.CrearContraseña);
            this.Controls.Add(this.CrearUsuario);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Registro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registro";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button CrearBoton;
        private System.Windows.Forms.TextBox CrearContraseña;
        private System.Windows.Forms.TextBox CrearUsuario;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox ClaveRegistro;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox CrearReContraseña;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
    }
}