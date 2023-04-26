namespace Tetris
{
    partial class FormGame
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
            this.components = new System.ComponentModel.Container();
            this.timerDraw = new System.Windows.Forms.Timer(this.components);
            this.pbCanvasMap = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvasMap)).BeginInit();
            this.SuspendLayout();
            // 
            // timerDraw
            // 
            this.timerDraw.Tick += new System.EventHandler(this.timerDraw_Tick);
            // 
            // pbCanvasMap
            // 
            this.pbCanvasMap.BackColor = System.Drawing.Color.White;
            this.pbCanvasMap.Location = new System.Drawing.Point(12, 8);
            this.pbCanvasMap.Name = "pbCanvasMap";
            this.pbCanvasMap.Size = new System.Drawing.Size(401, 601);
            this.pbCanvasMap.TabIndex = 1;
            this.pbCanvasMap.TabStop = false;
            this.pbCanvasMap.Paint += new System.Windows.Forms.PaintEventHandler(this.pbCanvasMapPaint);
            // 
            // FormGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 621);
            this.Controls.Add(this.pbCanvasMap);
            this.DoubleBuffered = true;
            this.Name = "FormGame";
            this.Text = " ";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormGame_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvasMap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timerDraw;
        private System.Windows.Forms.PictureBox pbCanvasMap;
    }
}

