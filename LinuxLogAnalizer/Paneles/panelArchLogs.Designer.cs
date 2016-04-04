namespace LinuxLogAnalizer.Paneles
{
    partial class panelArchLogs
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
            this.btnPasswd = new System.Windows.Forms.Button();
            this.btnShadow = new System.Windows.Forms.Button();
            this.btnSecure = new System.Windows.Forms.Button();
            this.btnGroup = new System.Windows.Forms.Button();
            this.btnLastb = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPasswd
            // 
            this.btnPasswd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPasswd.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnPasswd.Location = new System.Drawing.Point(3, 3);
            this.btnPasswd.Name = "btnPasswd";
            this.btnPasswd.Size = new System.Drawing.Size(76, 60);
            this.btnPasswd.TabIndex = 0;
            this.btnPasswd.Text = "passwd";
            this.btnPasswd.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPasswd.UseVisualStyleBackColor = true;
            this.btnPasswd.Click += new System.EventHandler(this.btnPasswd_Click);
            // 
            // btnShadow
            // 
            this.btnShadow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShadow.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnShadow.Location = new System.Drawing.Point(100, 3);
            this.btnShadow.Name = "btnShadow";
            this.btnShadow.Size = new System.Drawing.Size(76, 60);
            this.btnShadow.TabIndex = 1;
            this.btnShadow.Text = "shadow";
            this.btnShadow.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnShadow.UseVisualStyleBackColor = true;
            this.btnShadow.Click += new System.EventHandler(this.btnShadow_Click);
            // 
            // btnSecure
            // 
            this.btnSecure.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSecure.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSecure.Location = new System.Drawing.Point(203, 3);
            this.btnSecure.Name = "btnSecure";
            this.btnSecure.Size = new System.Drawing.Size(76, 60);
            this.btnSecure.TabIndex = 2;
            this.btnSecure.Text = "secure";
            this.btnSecure.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSecure.UseVisualStyleBackColor = true;
            this.btnSecure.Click += new System.EventHandler(this.btnSecure_Click);
            // 
            // btnGroup
            // 
            this.btnGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGroup.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGroup.Location = new System.Drawing.Point(300, 3);
            this.btnGroup.Name = "btnGroup";
            this.btnGroup.Size = new System.Drawing.Size(76, 60);
            this.btnGroup.TabIndex = 3;
            this.btnGroup.Text = "group";
            this.btnGroup.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGroup.UseVisualStyleBackColor = true;
            this.btnGroup.Click += new System.EventHandler(this.btnGroup_Click);
            // 
            // btnLastb
            // 
            this.btnLastb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLastb.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLastb.Location = new System.Drawing.Point(3, 89);
            this.btnLastb.Name = "btnLastb";
            this.btnLastb.Size = new System.Drawing.Size(76, 60);
            this.btnLastb.TabIndex = 4;
            this.btnLastb.Text = "lastb";
            this.btnLastb.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnLastb.UseVisualStyleBackColor = true;
            this.btnLastb.Click += new System.EventHandler(this.btnLastb_Click);
            // 
            // panelArchLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnLastb);
            this.Controls.Add(this.btnGroup);
            this.Controls.Add(this.btnSecure);
            this.Controls.Add(this.btnShadow);
            this.Controls.Add(this.btnPasswd);
            this.Name = "panelArchLogs";
            this.Size = new System.Drawing.Size(384, 275);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPasswd;
        private System.Windows.Forms.Button btnShadow;
        private System.Windows.Forms.Button btnSecure;
        private System.Windows.Forms.Button btnGroup;
        private System.Windows.Forms.Button btnLastb;
    }
}
