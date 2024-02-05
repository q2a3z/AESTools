
namespace Kumas_SavadataTool
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.plTitle = new System.Windows.Forms.Panel();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlDragAndDrop = new System.Windows.Forms.Panel();
            this.lbDrop = new System.Windows.Forms.Label();
            this.editTextBox = new System.Windows.Forms.RichTextBox();
            this.treeViewJson = new System.Windows.Forms.TreeView();
            this.btnEditSave = new System.Windows.Forms.Button();
            this.plAesKey = new System.Windows.Forms.Panel();
            this.txtAesKey = new System.Windows.Forms.TextBox();
            this.lbAesKey = new System.Windows.Forms.Label();
            this.plTitle.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlDragAndDrop.SuspendLayout();
            this.plAesKey.SuspendLayout();
            this.SuspendLayout();
            // 
            // plTitle
            // 
            this.plTitle.BackColor = System.Drawing.SystemColors.HotTrack;
            this.plTitle.Controls.Add(this.btnImport);
            this.plTitle.Controls.Add(this.btnSave);
            this.plTitle.Controls.Add(this.btnClose);
            this.plTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.plTitle.Location = new System.Drawing.Point(0, 0);
            this.plTitle.Name = "plTitle";
            this.plTitle.Size = new System.Drawing.Size(800, 37);
            this.plTitle.TabIndex = 1;
            this.plTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.plTitle_MouseDown);
            // 
            // btnImport
            // 
            this.btnImport.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImport.BackgroundImage")));
            this.btnImport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnImport.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnImport.FlatAppearance.BorderSize = 0;
            this.btnImport.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.ForeColor = System.Drawing.Color.White;
            this.btnImport.Location = new System.Drawing.Point(650, 0);
            this.btnImport.Margin = new System.Windows.Forms.Padding(0);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(50, 37);
            this.btnImport.TabIndex = 2;
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSave.BackgroundImage")));
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(700, 0);
            this.btnSave.Margin = new System.Windows.Forms.Padding(0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(50, 37);
            this.btnSave.TabIndex = 1;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(750, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(50, 37);
            this.btnClose.TabIndex = 0;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel1
            // 
            this.panel1.AllowDrop = true;
            this.panel1.Controls.Add(this.pnlDragAndDrop);
            this.panel1.Controls.Add(this.editTextBox);
            this.panel1.Controls.Add(this.treeViewJson);
            this.panel1.Controls.Add(this.btnEditSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 94);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 356);
            this.panel1.TabIndex = 0;
            // 
            // pnlDragAndDrop
            // 
            this.pnlDragAndDrop.AllowDrop = true;
            this.pnlDragAndDrop.Controls.Add(this.lbDrop);
            this.pnlDragAndDrop.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlDragAndDrop.Location = new System.Drawing.Point(0, 3);
            this.pnlDragAndDrop.Name = "pnlDragAndDrop";
            this.pnlDragAndDrop.Size = new System.Drawing.Size(800, 353);
            this.pnlDragAndDrop.TabIndex = 1;
            // 
            // lbDrop
            // 
            this.lbDrop.Font = new System.Drawing.Font("MS UI Gothic", 50F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbDrop.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbDrop.Location = new System.Drawing.Point(191, 118);
            this.lbDrop.Name = "lbDrop";
            this.lbDrop.Size = new System.Drawing.Size(437, 156);
            this.lbDrop.TabIndex = 0;
            this.lbDrop.Text = "ここにファイルをドロップしてください。";
            // 
            // editTextBox
            // 
            this.editTextBox.Location = new System.Drawing.Point(544, 67);
            this.editTextBox.Name = "editTextBox";
            this.editTextBox.Size = new System.Drawing.Size(167, 214);
            this.editTextBox.TabIndex = 0;
            this.editTextBox.Text = "";
            // 
            // treeViewJson
            // 
            this.treeViewJson.Location = new System.Drawing.Point(63, 19);
            this.treeViewJson.Name = "treeViewJson";
            this.treeViewJson.Size = new System.Drawing.Size(365, 262);
            this.treeViewJson.TabIndex = 0;
            this.treeViewJson.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewJson_AfterSelect);
            // 
            // btnEditSave
            // 
            this.btnEditSave.Location = new System.Drawing.Point(584, 38);
            this.btnEditSave.Name = "btnEditSave";
            this.btnEditSave.Size = new System.Drawing.Size(75, 23);
            this.btnEditSave.TabIndex = 2;
            this.btnEditSave.Text = "Save";
            this.btnEditSave.UseVisualStyleBackColor = true;
            this.btnEditSave.Click += new System.EventHandler(this.btnEditSave_Click);
            // 
            // plAesKey
            // 
            this.plAesKey.Controls.Add(this.txtAesKey);
            this.plAesKey.Controls.Add(this.lbAesKey);
            this.plAesKey.Location = new System.Drawing.Point(0, 35);
            this.plAesKey.Name = "plAesKey";
            this.plAesKey.Size = new System.Drawing.Size(800, 53);
            this.plAesKey.TabIndex = 2;
            // 
            // txtAesKey
            // 
            this.txtAesKey.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtAesKey.Location = new System.Drawing.Point(280, 17);
            this.txtAesKey.MaxLength = 16;
            this.txtAesKey.Name = "txtAesKey";
            this.txtAesKey.Size = new System.Drawing.Size(281, 23);
            this.txtAesKey.TabIndex = 1;
            // 
            // lbAesKey
            // 
            this.lbAesKey.AutoSize = true;
            this.lbAesKey.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbAesKey.Location = new System.Drawing.Point(201, 17);
            this.lbAesKey.Name = "lbAesKey";
            this.lbAesKey.Size = new System.Drawing.Size(73, 16);
            this.lbAesKey.TabIndex = 0;
            this.lbAesKey.Text = "AES KEY:";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.plAesKey);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.plTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.plTitle.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnlDragAndDrop.ResumeLayout(false);
            this.plAesKey.ResumeLayout(false);
            this.plAesKey.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel plTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlDragAndDrop;
        private System.Windows.Forms.Label lbDrop;
        private System.Windows.Forms.RichTextBox editTextBox;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Panel plAesKey;
        private System.Windows.Forms.TextBox txtAesKey;
        private System.Windows.Forms.Label lbAesKey;
        private System.Windows.Forms.TreeView treeViewJson;
        private System.Windows.Forms.Button btnEditSave;
    }
}