namespace InsUpdDel
{
    partial class FrmUID
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tvMain = new TreeView();
            tbAuthorName = new TextBox();
            btnAdd = new Button();
            btnMod = new Button();
            btnDel = new Button();
            SuspendLayout();
            // 
            // tvMain
            // 
            tvMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tvMain.Location = new Point(12, 12);
            tvMain.Name = "tvMain";
            tvMain.Size = new Size(342, 264);
            tvMain.TabIndex = 0;
            tvMain.AfterCheck += tvMain_AfterSelect;
            tvMain.AfterSelect += tvMain_AfterSelect;
            // 
            // tbAuthorName
            // 
            tbAuthorName.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbAuthorName.Location = new Point(12, 282);
            tbAuthorName.Name = "tbAuthorName";
            tbAuthorName.Size = new Size(342, 27);
            tbAuthorName.TabIndex = 10;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAdd.Location = new Point(12, 315);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(110, 29);
            btnAdd.TabIndex = 11;
            btnAdd.Text = "Добавить";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnMod
            // 
            btnMod.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnMod.Location = new Point(128, 315);
            btnMod.Name = "btnMod";
            btnMod.Size = new Size(110, 29);
            btnMod.TabIndex = 12;
            btnMod.Text = "Изменить";
            btnMod.UseVisualStyleBackColor = true;
            btnMod.Click += btnMod_Click;
            // 
            // btnDel
            // 
            btnDel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDel.Location = new Point(244, 315);
            btnDel.Name = "btnDel";
            btnDel.Size = new Size(110, 29);
            btnDel.TabIndex = 13;
            btnDel.Text = "Удалить";
            btnDel.UseVisualStyleBackColor = true;
            btnDel.Click += btnDel_Click;
            // 
            // FrmUID
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(366, 368);
            Controls.Add(btnDel);
            Controls.Add(btnMod);
            Controls.Add(btnAdd);
            Controls.Add(tbAuthorName);
            Controls.Add(tvMain);
            MinimumSize = new Size(384, 415);
            Name = "FrmUID";
            Text = "Редактор исполнителей";
            Load += FrmUID_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TreeView tvMain;
        private TextBox tbAuthorName;
        private Button btnAdd;
        private Button btnMod;
        private Button btnDel;
    }
}
