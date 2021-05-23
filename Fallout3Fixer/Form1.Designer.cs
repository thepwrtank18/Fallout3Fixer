
namespace Fallout3Fixer
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.falloutDir = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.falloutSearch = new System.Windows.Forms.Button();
            this.useFOSE = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.useLIVE = new System.Windows.Forms.RadioButton();
            this.patchButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // falloutDir
            // 
            this.falloutDir.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.falloutDir.Location = new System.Drawing.Point(15, 29);
            this.falloutDir.Name = "falloutDir";
            this.falloutDir.Size = new System.Drawing.Size(243, 23);
            this.falloutDir.TabIndex = 0;
            this.falloutDir.TextChanged += new System.EventHandler(this.falloutDir_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Directory to Fallout 3:";
            // 
            // falloutSearch
            // 
            this.falloutSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.falloutSearch.Location = new System.Drawing.Point(264, 29);
            this.falloutSearch.Name = "falloutSearch";
            this.falloutSearch.Size = new System.Drawing.Size(64, 23);
            this.falloutSearch.TabIndex = 2;
            this.falloutSearch.Text = "Search";
            this.falloutSearch.UseVisualStyleBackColor = true;
            this.falloutSearch.Click += new System.EventHandler(this.falloutSearch_Click);
            // 
            // useFOSE
            // 
            this.useFOSE.AutoSize = true;
            this.useFOSE.Enabled = false;
            this.useFOSE.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.useFOSE.Location = new System.Drawing.Point(15, 73);
            this.useFOSE.Name = "useFOSE";
            this.useFOSE.Size = new System.Drawing.Size(171, 19);
            this.useFOSE.TabIndex = 3;
            this.useFOSE.TabStop = true;
            this.useFOSE.Text = "Use mods that require FOSE";
            this.useFOSE.UseVisualStyleBackColor = true;
            this.useFOSE.CheckedChanged += new System.EventHandler(this.useFOSE_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "I want to:";
            // 
            // useLIVE
            // 
            this.useLIVE.AutoSize = true;
            this.useLIVE.Enabled = false;
            this.useLIVE.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.useLIVE.Location = new System.Drawing.Point(15, 98);
            this.useLIVE.Name = "useLIVE";
            this.useLIVE.Size = new System.Drawing.Size(278, 19);
            this.useLIVE.TabIndex = 5;
            this.useLIVE.TabStop = true;
            this.useLIVE.Text = "Use GFWL features (Microsoft account required)";
            this.useLIVE.UseVisualStyleBackColor = true;
            this.useLIVE.CheckedChanged += new System.EventHandler(this.useLIVE_CheckedChanged);
            // 
            // patchButton
            // 
            this.patchButton.Enabled = false;
            this.patchButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patchButton.Location = new System.Drawing.Point(15, 128);
            this.patchButton.Name = "patchButton";
            this.patchButton.Size = new System.Drawing.Size(75, 23);
            this.patchButton.TabIndex = 6;
            this.patchButton.Text = "Patch";
            this.patchButton.UseVisualStyleBackColor = true;
            this.patchButton.Click += new System.EventHandler(this.patchButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 163);
            this.Controls.Add(this.patchButton);
            this.Controls.Add(this.useLIVE);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.useFOSE);
            this.Controls.Add(this.falloutSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.falloutDir);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Vault-Tec Annoyance Disabler";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox falloutDir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button falloutSearch;
        private System.Windows.Forms.RadioButton useFOSE;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton useLIVE;
        private System.Windows.Forms.Button patchButton;
    }
}

