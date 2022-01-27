
namespace OOP_Laba_6._5
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.picBoxPaint = new System.Windows.Forms.PictureBox();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.rBSection = new System.Windows.Forms.RadioButton();
            this.rBTriangle = new System.Windows.Forms.RadioButton();
            this.rBSquare = new System.Windows.Forms.RadioButton();
            this.rBCircle = new System.Windows.Forms.RadioButton();
            this.labelInfo = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.checkBoxSticky = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPaint)).BeginInit();
            this.SuspendLayout();
            // 
            // picBoxPaint
            // 
            this.picBoxPaint.Dock = System.Windows.Forms.DockStyle.Left;
            this.picBoxPaint.Location = new System.Drawing.Point(0, 0);
            this.picBoxPaint.Name = "picBoxPaint";
            this.picBoxPaint.Size = new System.Drawing.Size(670, 558);
            this.picBoxPaint.TabIndex = 1;
            this.picBoxPaint.TabStop = false;
            this.picBoxPaint.Paint += new System.Windows.Forms.PaintEventHandler(this.picBoxPaint_Paint);
            this.picBoxPaint.MouseClick += new System.Windows.Forms.MouseEventHandler(this.picBoxPaint_MouseClick);
            // 
            // panelMenu
            // 
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(200, 100);
            this.panelMenu.TabIndex = 2;
            // 
            // rBSection
            // 
            this.rBSection.Location = new System.Drawing.Point(0, 0);
            this.rBSection.Name = "rBSection";
            this.rBSection.Size = new System.Drawing.Size(104, 24);
            this.rBSection.TabIndex = 0;
            // 
            // rBTriangle
            // 
            this.rBTriangle.Location = new System.Drawing.Point(0, 0);
            this.rBTriangle.Name = "rBTriangle";
            this.rBTriangle.Size = new System.Drawing.Size(104, 24);
            this.rBTriangle.TabIndex = 0;
            // 
            // rBSquare
            // 
            this.rBSquare.Location = new System.Drawing.Point(0, 0);
            this.rBSquare.Name = "rBSquare";
            this.rBSquare.Size = new System.Drawing.Size(104, 24);
            this.rBSquare.TabIndex = 0;
            // 
            // rBCircle
            // 
            this.rBCircle.Location = new System.Drawing.Point(0, 0);
            this.rBCircle.Name = "rBCircle";
            this.rBCircle.Size = new System.Drawing.Size(104, 24);
            this.rBCircle.TabIndex = 0;
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelInfo.Location = new System.Drawing.Point(1136, 0);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(215, 459);
            this.labelInfo.TabIndex = 3;
            this.labelInfo.Text = resources.GetString("labelInfo.Text");
            this.labelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.treeView1.Location = new System.Drawing.Point(670, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(466, 471);
            this.treeView1.TabIndex = 4;
            this.treeView1.TabStop = false;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeView1_KeyDown);
            // 
            // checkBoxSticky
            // 
            this.checkBoxSticky.AutoSize = true;
            this.checkBoxSticky.Location = new System.Drawing.Point(676, 477);
            this.checkBoxSticky.Name = "checkBoxSticky";
            this.checkBoxSticky.Size = new System.Drawing.Size(141, 21);
            this.checkBoxSticky.TabIndex = 5;
            this.checkBoxSticky.Text = "Сделать липким ";
            this.checkBoxSticky.UseVisualStyleBackColor = true;
            this.checkBoxSticky.CheckedChanged += new System.EventHandler(this.checkBoxSticky_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1351, 558);
            this.Controls.Add(this.checkBoxSticky);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.picBoxPaint);
            this.Controls.Add(this.panelMenu);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPaint)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox picBoxPaint;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.RadioButton rBCircle;
        private System.Windows.Forms.RadioButton rBSquare;
        private System.Windows.Forms.RadioButton rBTriangle;
        private System.Windows.Forms.RadioButton rBSection;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.CheckBox checkBoxSticky;
    }
}

