using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;

namespace OgrenciBilgilendirmeApp
{
    partial class OgrenciIslem
    {
        private TextBox txtAd;
        private TextBox txtSoyad;
        private TextBox txtNumara;
        private ComboBox cmbSinif;
        private Button btnKaydet;
        private Button btnGuncelle;
        private Button btnBul;
        private Label lblAd;
        private Label lblSoyad;
        private Label lblNumara;
        private Label lblSinif;
        private GroupBox grpOgrenciBilgileri;

        private void InitializeComponent()
        {
            txtAd = new TextBox();
            txtSoyad = new TextBox();
            txtNumara = new TextBox();
            cmbSinif = new ComboBox();
            btnKaydet = new Button();
            btnGuncelle = new Button();
            btnBul = new Button();
            lblAd = new Label();
            lblSoyad = new Label();
            lblNumara = new Label();
            lblSinif = new Label();
            grpOgrenciBilgileri = new GroupBox();
            btnDers = new Button();
            btnDersIslem = new Button();
            btnSinifIslem = new Button();
            grpOgrenciBilgileri.SuspendLayout();
            SuspendLayout();
            // 
            // txtAd
            // 
            txtAd.Location = new Point(155, 41);
            txtAd.Name = "txtAd";
            txtAd.Size = new Size(200, 25);
            txtAd.TabIndex = 1;
            // 
            // txtSoyad
            // 
            txtSoyad.Location = new Point(155, 81);
            txtSoyad.Name = "txtSoyad";
            txtSoyad.Size = new Size(200, 25);
            txtSoyad.TabIndex = 3;
            // 
            // txtNumara
            // 
            txtNumara.Location = new Point(155, 121);
            txtNumara.Name = "txtNumara";
            txtNumara.Size = new Size(200, 25);
            txtNumara.TabIndex = 5;
            // 
            // cmbSinif
            // 
            cmbSinif.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSinif.Location = new Point(155, 161);
            cmbSinif.Name = "cmbSinif";
            cmbSinif.Size = new Size(200, 25);
            cmbSinif.TabIndex = 7;
            // 
            // btnKaydet
            // 
            btnKaydet.BackColor = Color.LightGreen;
            btnKaydet.FlatStyle = FlatStyle.Flat;
            btnKaydet.Location = new Point(74, 265);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(100, 40);
            btnKaydet.TabIndex = 1;
            btnKaydet.Text = "Kaydet";
            btnKaydet.UseVisualStyleBackColor = false;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // btnGuncelle
            // 
            btnGuncelle.BackColor = Color.LightBlue;
            btnGuncelle.FlatStyle = FlatStyle.Flat;
            btnGuncelle.Location = new Point(199, 265);
            btnGuncelle.Name = "btnGuncelle";
            btnGuncelle.Size = new Size(100, 40);
            btnGuncelle.TabIndex = 2;
            btnGuncelle.Text = "Güncelle";
            btnGuncelle.UseVisualStyleBackColor = false;
            btnGuncelle.Click += btnGuncelle_Click;
            // 
            // btnBul
            // 
            btnBul.BackColor = Color.LightGoldenrodYellow;
            btnBul.FlatStyle = FlatStyle.Flat;
            btnBul.Location = new Point(324, 265);
            btnBul.Name = "btnBul";
            btnBul.Size = new Size(100, 40);
            btnBul.TabIndex = 3;
            btnBul.Text = "Bul";
            btnBul.UseVisualStyleBackColor = false;
            btnBul.Click += btnBul_Click;
            // 
            // lblAd
            // 
            lblAd.AutoSize = true;
            lblAd.Location = new Point(55, 41);
            lblAd.Name = "lblAd";
            lblAd.Size = new Size(29, 19);
            lblAd.TabIndex = 0;
            lblAd.Text = "Ad:";
            // 
            // lblSoyad
            // 
            lblSoyad.AutoSize = true;
            lblSoyad.Location = new Point(55, 81);
            lblSoyad.Name = "lblSoyad";
            lblSoyad.Size = new Size(49, 19);
            lblSoyad.TabIndex = 2;
            lblSoyad.Text = "Soyad:";
            // 
            // lblNumara
            // 
            lblNumara.AutoSize = true;
            lblNumara.Location = new Point(55, 121);
            lblNumara.Name = "lblNumara";
            lblNumara.Size = new Size(61, 19);
            lblNumara.TabIndex = 4;
            lblNumara.Text = "Numara:";
            // 
            // lblSinif
            // 
            lblSinif.AutoSize = true;
            lblSinif.Location = new Point(55, 161);
            lblSinif.Name = "lblSinif";
            lblSinif.Size = new Size(37, 19);
            lblSinif.TabIndex = 6;
            lblSinif.Text = "Sınıf:";
            // 
            // grpOgrenciBilgileri
            // 
            grpOgrenciBilgileri.BackColor = Color.MidnightBlue;
            grpOgrenciBilgileri.Controls.Add(lblAd);
            grpOgrenciBilgileri.Controls.Add(txtAd);
            grpOgrenciBilgileri.Controls.Add(lblSoyad);
            grpOgrenciBilgileri.Controls.Add(txtSoyad);
            grpOgrenciBilgileri.Controls.Add(lblNumara);
            grpOgrenciBilgileri.Controls.Add(txtNumara);
            grpOgrenciBilgileri.Controls.Add(lblSinif);
            grpOgrenciBilgileri.Controls.Add(cmbSinif);
            grpOgrenciBilgileri.ForeColor = Color.WhiteSmoke;
            grpOgrenciBilgileri.Location = new Point(30, 36);
            grpOgrenciBilgileri.Name = "grpOgrenciBilgileri";
            grpOgrenciBilgileri.Size = new Size(440, 214);
            grpOgrenciBilgileri.TabIndex = 0;
            grpOgrenciBilgileri.TabStop = false;
            grpOgrenciBilgileri.Text = "Öğrenci Bilgileri";
            // 
            // btnDers
            // 
            btnDers.BackColor = Color.Crimson;
            btnDers.FlatStyle = FlatStyle.Flat;
            btnDers.Location = new Point(74, 311);
            btnDers.Name = "btnDers";
            btnDers.Size = new Size(350, 40);
            btnDers.TabIndex = 1;
            btnDers.Text = "Ders Seçimi";
            btnDers.UseVisualStyleBackColor = false;
            btnDers.Click += btnDers_Click;
            // 
            // btnDersIslem
            // 
            btnDersIslem.BackColor = Color.MidnightBlue;
            btnDersIslem.FlatStyle = FlatStyle.Flat;
            btnDersIslem.ForeColor = Color.Cyan;
            btnDersIslem.Location = new Point(324, 1);
            btnDersIslem.Name = "btnDersIslem";
            btnDersIslem.Size = new Size(146, 35);
            btnDersIslem.TabIndex = 5;
            btnDersIslem.Text = "Ders İşlemleri";
            btnDersIslem.UseVisualStyleBackColor = false;
            btnDersIslem.Click += btnDersIslem_Click;
            // 
            // btnSinifIslem
            // 
            btnSinifIslem.BackColor = Color.MidnightBlue;
            btnSinifIslem.FlatStyle = FlatStyle.Flat;
            btnSinifIslem.ForeColor = Color.Crimson;
            btnSinifIslem.Location = new Point(185, 1);
            btnSinifIslem.Name = "btnSinifIslem";
            btnSinifIslem.Size = new Size(132, 35);
            btnSinifIslem.TabIndex = 6;
            btnSinifIslem.Text = "Sınıf İşlemleri";
            btnSinifIslem.UseVisualStyleBackColor = false;
            btnSinifIslem.Click += btnSinifIslem_Click;
            // 
            // OgrenciIslem
            // 
            BackColor = Color.Black;
            ClientSize = new Size(500, 368);
            Controls.Add(btnSinifIslem);
            Controls.Add(btnDersIslem);
            Controls.Add(grpOgrenciBilgileri);
            Controls.Add(btnDers);
            Controls.Add(btnKaydet);
            Controls.Add(btnGuncelle);
            Controls.Add(btnBul);
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "OgrenciIslem";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Öğrenci Bilgilendirme Sistemi";
            Load += OgrenciIslem_Load;
            grpOgrenciBilgileri.ResumeLayout(false);
            grpOgrenciBilgileri.PerformLayout();
            ResumeLayout(false);
        }

        private Button btnDers;
        private Button btnDersIslem;
        private Button btnSinifIslem;
    }
}
