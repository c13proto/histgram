namespace histgram
{
    partial class main
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.button_mask = new System.Windows.Forms.Button();
            this.button_original = new System.Windows.Forms.Button();
            this.textBox_x = new System.Windows.Forms.TextBox();
            this.textBox_y = new System.Windows.Forms.TextBox();
            this.pictureBoxIpl1 = new OpenCvSharp.UserInterface.PictureBoxIpl();
            this.button_csv = new System.Windows.Forms.Button();
            this.label_color = new System.Windows.Forms.Label();
            this.textBox_mask = new System.Windows.Forms.TextBox();
            this.button_合成 = new System.Windows.Forms.Button();
            this.button_画像出力 = new System.Windows.Forms.Button();
            this.trackBar_mask = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIpl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_mask)).BeginInit();
            this.SuspendLayout();
            // 
            // button_mask
            // 
            this.button_mask.Location = new System.Drawing.Point(2, 3);
            this.button_mask.Name = "button_mask";
            this.button_mask.Size = new System.Drawing.Size(75, 23);
            this.button_mask.TabIndex = 0;
            this.button_mask.Text = "マスク画像";
            this.button_mask.UseVisualStyleBackColor = true;
            this.button_mask.Click += new System.EventHandler(this.OnClick_マスク画像);
            // 
            // button_original
            // 
            this.button_original.Location = new System.Drawing.Point(2, 57);
            this.button_original.Name = "button_original";
            this.button_original.Size = new System.Drawing.Size(75, 23);
            this.button_original.TabIndex = 1;
            this.button_original.Text = "元画像";
            this.button_original.UseVisualStyleBackColor = true;
            this.button_original.Click += new System.EventHandler(this.OnClick_元画像);
            // 
            // textBox_x
            // 
            this.textBox_x.Location = new System.Drawing.Point(0, 86);
            this.textBox_x.Name = "textBox_x";
            this.textBox_x.Size = new System.Drawing.Size(29, 19);
            this.textBox_x.TabIndex = 2;
            this.textBox_x.Text = "x";
            this.textBox_x.TextChanged += new System.EventHandler(this.TextChanged_x);
            // 
            // textBox_y
            // 
            this.textBox_y.Location = new System.Drawing.Point(30, 86);
            this.textBox_y.Name = "textBox_y";
            this.textBox_y.Size = new System.Drawing.Size(29, 19);
            this.textBox_y.TabIndex = 3;
            this.textBox_y.Text = "y";
            this.textBox_y.TextChanged += new System.EventHandler(this.TextChanged_y);
            // 
            // pictureBoxIpl1
            // 
            this.pictureBoxIpl1.Location = new System.Drawing.Point(83, 3);
            this.pictureBoxIpl1.Name = "pictureBoxIpl1";
            this.pictureBoxIpl1.Size = new System.Drawing.Size(299, 273);
            this.pictureBoxIpl1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxIpl1.TabIndex = 4;
            this.pictureBoxIpl1.TabStop = false;
            this.pictureBoxIpl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove_PictureBoxIpl1);
            // 
            // button_csv
            // 
            this.button_csv.Location = new System.Drawing.Point(2, 253);
            this.button_csv.Name = "button_csv";
            this.button_csv.Size = new System.Drawing.Size(75, 23);
            this.button_csv.TabIndex = 5;
            this.button_csv.Text = "csv出力";
            this.button_csv.UseVisualStyleBackColor = true;
            // 
            // label_color
            // 
            this.label_color.AutoSize = true;
            this.label_color.Location = new System.Drawing.Point(65, 89);
            this.label_color.Name = "label_color";
            this.label_color.Size = new System.Drawing.Size(30, 12);
            this.label_color.TabIndex = 6;
            this.label_color.Text = "color";
            // 
            // textBox_mask
            // 
            this.textBox_mask.Location = new System.Drawing.Point(5, 32);
            this.textBox_mask.Name = "textBox_mask";
            this.textBox_mask.Size = new System.Drawing.Size(22, 19);
            this.textBox_mask.TabIndex = 7;
            this.textBox_mask.Text = "9";
            this.textBox_mask.TextChanged += new System.EventHandler(this.TextChanged_mask);
            // 
            // button_合成
            // 
            this.button_合成.Location = new System.Drawing.Point(2, 205);
            this.button_合成.Name = "button_合成";
            this.button_合成.Size = new System.Drawing.Size(75, 23);
            this.button_合成.TabIndex = 8;
            this.button_合成.Text = "合成";
            this.button_合成.UseVisualStyleBackColor = true;
            this.button_合成.Click += new System.EventHandler(this.OnClick_合成);
            // 
            // button_画像出力
            // 
            this.button_画像出力.Location = new System.Drawing.Point(2, 229);
            this.button_画像出力.Name = "button_画像出力";
            this.button_画像出力.Size = new System.Drawing.Size(75, 23);
            this.button_画像出力.TabIndex = 9;
            this.button_画像出力.Text = "画像出力";
            this.button_画像出力.UseVisualStyleBackColor = true;
            // 
            // trackBar_mask
            // 
            this.trackBar_mask.AutoSize = false;
            this.trackBar_mask.Location = new System.Drawing.Point(30, 32);
            this.trackBar_mask.Margin = new System.Windows.Forms.Padding(0);
            this.trackBar_mask.Maximum = 20;
            this.trackBar_mask.Minimum = 1;
            this.trackBar_mask.Name = "trackBar_mask";
            this.trackBar_mask.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.trackBar_mask.Size = new System.Drawing.Size(50, 19);
            this.trackBar_mask.TabIndex = 10;
            this.trackBar_mask.Value = 9;
            this.trackBar_mask.ValueChanged += new System.EventHandler(this.ValueChanged_mask);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(389, 281);
            this.Controls.Add(this.trackBar_mask);
            this.Controls.Add(this.button_画像出力);
            this.Controls.Add(this.button_合成);
            this.Controls.Add(this.textBox_mask);
            this.Controls.Add(this.label_color);
            this.Controls.Add(this.button_csv);
            this.Controls.Add(this.pictureBoxIpl1);
            this.Controls.Add(this.textBox_y);
            this.Controls.Add(this.textBox_x);
            this.Controls.Add(this.button_original);
            this.Controls.Add(this.button_mask);
            this.Name = "main";
            this.Text = "main";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIpl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_mask)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_mask;
        private System.Windows.Forms.Button button_original;
        private System.Windows.Forms.TextBox textBox_x;
        private System.Windows.Forms.TextBox textBox_y;
        private OpenCvSharp.UserInterface.PictureBoxIpl pictureBoxIpl1;
        private System.Windows.Forms.Button button_csv;
        private System.Windows.Forms.Label label_color;
        private System.Windows.Forms.TextBox textBox_mask;
        private System.Windows.Forms.Button button_合成;
        private System.Windows.Forms.Button button_画像出力;
        private System.Windows.Forms.TrackBar trackBar_mask;
    }
}

