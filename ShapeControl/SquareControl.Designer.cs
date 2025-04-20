namespace ShapeControl
{
    partial class SquareControl
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
            this.lblSide = new System.Windows.Forms.Label();
            this.txtSide = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblSide
            // 
            this.lblSide.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSide.AutoSize = true;
            this.lblSide.Location = new System.Drawing.Point(26, 32);
            this.lblSide.Name = "lblSide";
            this.lblSide.Size = new System.Drawing.Size(35, 13);
            this.lblSide.TabIndex = 0;
            this.lblSide.Text = "label1";
            // 
            // txtSide
            // 
            this.txtSide.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtSide.Location = new System.Drawing.Point(108, 29);
            this.txtSide.Name = "txtSide";
            this.txtSide.Size = new System.Drawing.Size(100, 20);
            this.txtSide.TabIndex = 1;
            // 
            // SquareControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtSide);
            this.Controls.Add(this.lblSide);
            this.Name = "SquareControl";
            this.Size = new System.Drawing.Size(250, 125);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSide;
        private System.Windows.Forms.TextBox txtSide;
    }
}
