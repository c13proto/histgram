using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenCvSharp;
using System.IO;

namespace histgram
{
    public partial class main : Form
    {
        public static Mat マスク元画像;
        public static Mat マスク画像;
        public static Mat 元画像;
        public static Mat 合成画像;

        public main()
        {
            InitializeComponent();
        }
        void 膨張(ref Mat src)
        {

            if (マスク元画像 != null)
            {
                src = マスク元画像.Clone();
                src = src.Threshold(254, 255, ThresholdTypes.Binary);

                Mat element = Cv2.GetStructuringElement(MorphShapes.Rect, new OpenCvSharp.Size(trackBar_mask.Value, trackBar_mask.Value), new OpenCvSharp.Point(trackBar_mask.Value / 2, trackBar_mask.Value / 2));
                src = src.MorphologyEx(MorphTypes.DILATE, element);
                pictureBoxIpl1.ImageIpl = src;
            }
        }

        void 合成(ref Mat src)
        {
            if (マスク画像 != null && 元画像 != null)
            {
                src = 元画像.Clone();
                Cv2.Add(マスク画像, 元画像, src);
                pictureBoxIpl1.ImageIpl = src;
 
            }
 
        }

        private void OnClick_マスク画像(object sender, EventArgs e)
        {
            画像取得(ref マスク元画像);
            膨張(ref マスク元画像);

        }
        private void OnClick_元画像(object sender, EventArgs e)
        {
            画像取得(ref 元画像);
        }
        void 画像取得(ref Mat src)
        {
            if (src != null) src.Dispose();
            OpenFileDialog dialog = new OpenFileDialog()
            {
                Multiselect = false,  // 複数選択の可否
                Filter =  // フィルタ
                "画像ファイル|*.bmp;*.gif;*.jpg;*.png|全てのファイル|*.*",
            };
            //ダイアログを表示
            //ダイアログを表示
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                // ファイル名をタイトルバーに設定
                this.Text = dialog.SafeFileName;
                //OpenCV処理
                src = new Mat(dialog.FileName, ImreadModes.GrayScale);
                pictureBoxIpl1.ImageIpl = src;
            }
        }



        private void ValueChanged_mask(object sender, EventArgs e)
        {
            textBox_mask.Text = "" + trackBar_mask.Value;
        }

        private void TextChanged_mask(object sender, EventArgs e)
        {
            double isnumber;
            if (double.TryParse(textBox_mask.Text, out isnumber))
                if (isnumber >= trackBar_mask.Minimum && isnumber <= trackBar_mask.Maximum)
                {
                    trackBar_mask.Value = (int)isnumber;
                    膨張(ref マスク画像);
                }
        }

        private void MouseMove_PictureBoxIpl1(object sender, MouseEventArgs e)
        {
            System.Drawing.Point sp = System.Windows.Forms.Cursor.Position;
            System.Drawing.Point cp = this.PointToClient(sp);
            textBox_x.Text = "" + (cp.X - pictureBoxIpl1.Location.X);
            textBox_y.Text = "" + (cp.Y - pictureBoxIpl1.Location.Y);
        }
        private void カーソル移動()
        {
            if (pictureBoxIpl1.ImageIpl != null)
            {
                double isnumber_x, isnumber_y;
                if (double.TryParse(textBox_x.Text, out isnumber_x) && double.TryParse(textBox_y.Text, out isnumber_y))
                    if ((isnumber_x >= 0 && isnumber_x <= pictureBoxIpl1.ImageIpl.Width) && (isnumber_y >= 0 && isnumber_y <= pictureBoxIpl1.ImageIpl.Height))
                    {
                        label_color.Text = pictureBoxIpl1.ImageIpl.At<Vec3b>((int)isnumber_y, (int)isnumber_x).Item0.ToString();
                        //クライアント座標を画面座標に変換する
                        System.Drawing.Point mp = this.PointToScreen(new System.Drawing.Point((int)isnumber_x + pictureBoxIpl1.Location.X, (int)isnumber_y + pictureBoxIpl1.Location.Y));
                        //マウスポインタの位置を設定する
                        System.Windows.Forms.Cursor.Position = mp;
                    }
            }
        }

        private void TextChanged_x(object sender, EventArgs e)
        {
            カーソル移動();
        }

        private void TextChanged_y(object sender, EventArgs e)
        {
            カーソル移動();
        }

        private void OnClick_合成(object sender, EventArgs e)
        {
            合成(ref 合成画像);
        }

        private void OnClick_画像出力(object sender, EventArgs e)
        {
            //System.IO.Directory.CreateDirectory(@"result");//resultフォルダの作成
            SaveFileDialog sfd = new SaveFileDialog();//SaveFileDialogクラスのインスタンスを作成
            sfd.FileName = "image";//はじめのファイル名を指定する
            //sfd.InitialDirectory = @"result\";//はじめに表示されるフォルダを指定する
            sfd.Filter = "画像ファイル|*.bmp;*.gif;*.jpg;*.png|全てのファイル|*.*";//[ファイルの種類]に表示される選択肢を指定する
            sfd.FilterIndex = 1;//[ファイルの種類]ではじめに「画像ファイル」が選択されているようにする
            sfd.Title = "保存先のファイルを選択してください";//タイトルを設定する
            sfd.RestoreDirectory = true;//ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            sfd.OverwritePrompt = true;//既に存在するファイル名を指定したとき警告する．デフォルトでTrueなので指定する必要はない
            sfd.CheckPathExists = true;//存在しないパスが指定されたとき警告を表示する．デフォルトでTrueなので指定する必要はない

            //ダイアログを表示する
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //OKボタンがクリックされたとき
                //選択されたファイル名を表示する
                System.Diagnostics.Debug.WriteLine(sfd.FileName);
                pictureBoxIpl1.ImageIpl.SaveImage(sfd.FileName);
            }
        }

        private void OnClick_csv出力(object sender, EventArgs e)
        {
            double[] ヒストグラム = new double[256];
            Mat sample=pictureBoxIpl1.ImageIpl;
            string 出力結果 = "";

            for (int x = 0; x < sample.Width;x++ )
                for (int y = 0; y < sample.Height; y++)
                {
                    byte val=sample.At<Vec3b>(y,x).Item0;
                    ヒストグラム[val]++;
                     
                }
            for (int i = 0; i < 256; i++) 出力結果 += "" + i + "," + ヒストグラム[i]+"\n";


            //System.IO.Directory.CreateDirectory(@"result");//resultフォルダの作成
            SaveFileDialog sfd = new SaveFileDialog();//SaveFileDialogクラスのインスタンスを作成
            sfd.FileName = "ヒストグラム_" + this.Text.Replace(".bmp","");//はじめのファイル名を指定する
            //sfd.InitialDirectory = @"result\";//はじめに表示されるフォルダを指定する
            sfd.Filter = "csvファイル|*.csv|全てのファイル|*.*";//[ファイルの種類]に表示される選択肢を指定する
            sfd.FilterIndex = 1;//[ファイルの種類]ではじめに「画像ファイル」が選択されているようにする
            sfd.Title = "保存先のファイルを選択してください";//タイトルを設定する
            sfd.RestoreDirectory = true;//ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            sfd.OverwritePrompt = true;//既に存在するファイル名を指定したとき警告する．デフォルトでTrueなので指定する必要はない
            sfd.CheckPathExists = true;//存在しないパスが指定されたとき警告を表示する．デフォルトでTrueなので指定する必要はない

            //ダイアログを表示する
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //OKボタンがクリックされたとき
                //選択されたファイル名を表示する
                System.Diagnostics.Debug.WriteLine(sfd.FileName);

                using (StreamWriter w = new StreamWriter(sfd.FileName))w.Write(出力結果);
            }

        }

    }
}
