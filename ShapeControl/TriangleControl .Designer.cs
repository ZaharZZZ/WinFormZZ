namespace ShapeControl
{
    partial class TriangleControl
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblSideA = new System.Windows.Forms.Label();
            this.lblSideB = new System.Windows.Forms.Label();
            this.lblSideC = new System.Windows.Forms.Label();
            this.txtSideA = new System.Windows.Forms.TextBox();
            this.txtSideB = new System.Windows.Forms.TextBox();
            this.txtSideC = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblSideA
            // 
            this.lblSideA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSideA.AutoSize = true;
            this.lblSideA.Location = new System.Drawing.Point(17, 21);
            this.lblSideA.Name = "lblSideA";
            this.lblSideA.Size = new System.Drawing.Size(35, 13);
            this.lblSideA.TabIndex = 0;
            this.lblSideA.Text = "label1";
            // 
            // lblSideB
            // 
            this.lblSideB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSideB.AutoSize = true;
            this.lblSideB.Location = new System.Drawing.Point(17, 48);
            this.lblSideB.Name = "lblSideB";
            this.lblSideB.Size = new System.Drawing.Size(35, 13);
            this.lblSideB.TabIndex = 1;
            this.lblSideB.Text = "label2";
            // 
            // lblSideC
            // 
            this.lblSideC.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSideC.AutoSize = true;
            this.lblSideC.Location = new System.Drawing.Point(17, 78);
            this.lblSideC.Name = "lblSideC";
            this.lblSideC.Size = new System.Drawing.Size(35, 13);
            this.lblSideC.TabIndex = 2;
            this.lblSideC.Text = "label3";
            // 
            // txtSideA
            // 
            this.txtSideA.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtSideA.Location = new System.Drawing.Point(85, 21);
            this.txtSideA.Name = "txtSideA";
            this.txtSideA.Size = new System.Drawing.Size(100, 20);
            this.txtSideA.TabIndex = 3;
            // 
            // txtSideB
            // 
            this.txtSideB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtSideB.Location = new System.Drawing.Point(85, 48);
            this.txtSideB.Name = "txtSideB";
            this.txtSideB.Size = new System.Drawing.Size(100, 20);
            this.txtSideB.TabIndex = 4;
            // 
            // txtSideC
            // 
            this.txtSideC.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtSideC.Location = new System.Drawing.Point(85, 78);
            this.txtSideC.Name = "txtSideC";
            this.txtSideC.Size = new System.Drawing.Size(100, 20);
            this.txtSideC.TabIndex = 5;
            // 
            // TriangleControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtSideC);
            this.Controls.Add(this.txtSideB);
            this.Controls.Add(this.txtSideA);
            this.Controls.Add(this.lblSideC);
            this.Controls.Add(this.lblSideB);
            this.Controls.Add(this.lblSideA);
            this.Name = "TriangleControl";
            this.Size = new System.Drawing.Size(250, 125);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSideA;
        private System.Windows.Forms.Label lblSideB;
        private System.Windows.Forms.Label lblSideC;
        private System.Windows.Forms.TextBox txtSideA;
        private System.Windows.Forms.TextBox txtSideB;
        private System.Windows.Forms.TextBox txtSideC;
    }
}
