﻿namespace LinuxLogAnalizer.Paneles
{
    partial class panelCatalogo
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnUsuario = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnIp = new System.Windows.Forms.Button();
            this.btnIPsMasivo = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnUsuario);
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(185, 130);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Usuario";
            // 
            // btnUsuario
            // 
            this.btnUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsuario.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnUsuario.Location = new System.Drawing.Point(6, 19);
            this.btnUsuario.Name = "btnUsuario";
            this.btnUsuario.Size = new System.Drawing.Size(76, 60);
            this.btnUsuario.TabIndex = 1;
            this.btnUsuario.Text = "Insertar Usuarios";
            this.btnUsuario.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUsuario.UseVisualStyleBackColor = true;
            this.btnUsuario.Click += new System.EventHandler(this.btnUsuario_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnIPsMasivo);
            this.groupBox2.Controls.Add(this.btnIp);
            this.groupBox2.Location = new System.Drawing.Point(195, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(214, 130);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "IPs";
            // 
            // btnIp
            // 
            this.btnIp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIp.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnIp.Location = new System.Drawing.Point(6, 19);
            this.btnIp.Name = "btnIp";
            this.btnIp.Size = new System.Drawing.Size(76, 60);
            this.btnIp.TabIndex = 3;
            this.btnIp.Text = "Insertar IP";
            this.btnIp.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnIp.UseVisualStyleBackColor = true;
            this.btnIp.Click += new System.EventHandler(this.btnIp_Click);
            // 
            // btnIPsMasivo
            // 
            this.btnIPsMasivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIPsMasivo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnIPsMasivo.Location = new System.Drawing.Point(88, 19);
            this.btnIPsMasivo.Name = "btnIPsMasivo";
            this.btnIPsMasivo.Size = new System.Drawing.Size(76, 60);
            this.btnIPsMasivo.TabIndex = 4;
            this.btnIPsMasivo.Text = "Insertar Excel";
            this.btnIPsMasivo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnIPsMasivo.UseVisualStyleBackColor = true;
            this.btnIPsMasivo.Click += new System.EventHandler(this.btnIPsMasivo_Click);
            // 
            // panelCatalogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "panelCatalogo";
            this.Size = new System.Drawing.Size(434, 281);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnUsuario;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnIp;
        private System.Windows.Forms.Button btnIPsMasivo;
    }
}
