using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ObsApp;
using OgrenciBilgilendirmeApp.Context;
using OgrenciBilgilendirmeApp.Model;

namespace OgrenciBilgilendirmeApp
{
    public partial class DersSecim : Form
    {
        public DersSecim(string ad, string soyad, string no, string sinif)
        {
            InitializeComponent();
            txtAd.Text = ad;
            txtSoyad.Text = soyad;
            txtNumara.Text = no;
            txtSinif.Text = sinif;
        }
        private void DersSecim_Load(object sender, EventArgs e)
        {
            GetTableData();
        }
        private void GetTableData()
        {
            try
            {
                using (var ctx = new ObsDbContext())
                {
                    var dersler = ctx.Derslers.ToList();

                    DataTable dt = new DataTable();
                    dt.Columns.Add("ID", typeof(int));
                    dt.Columns.Add("Ders Adı", typeof(string));
                    dt.Columns.Add("Ders Kodu", typeof(string));

                    foreach (var ders in dersler)
                    {
                        dt.Rows.Add(ders.DersId, ders.DersAdi, ders.DersKodu);
                    }

                    dgvDersler.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDersiKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDersler.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Lütfen bir ders seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int selectedDersId = Convert.ToInt32(dgvDersler.SelectedRows[0].Cells["ID"].Value);

                using (var ctx = new ObsDbContext())
                {
                    var ders = ctx.Derslers.FirstOrDefault(d => d.DersId == selectedDersId);
                    if (ders == null)
                    {
                        MessageBox.Show("Seçilen ders bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var ogrenci = ctx.Ogrencilers.FirstOrDefault(o => o.OgrenciAd == txtAd.Text);
                    if (ogrenci == null)
                    {
                        MessageBox.Show("Öğrenci bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    bool alreadyAdded = ctx.OgrenciDerslers.Any(od => od.OgrenciId == ogrenci.OgrenciId && od.DersId == selectedDersId);
                    if (alreadyAdded)
                    {
                        MessageBox.Show("Bu öğrenci zaten bu derse kayıtlı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var ogrenciDers = new OgrenciDersler
                    {
                        OgrenciId = ogrenci.OgrenciId,
                        DersId = selectedDersId
                    };
                    ctx.OgrenciDerslers.Add(ogrenciDers);

                    int sonuc = ctx.SaveChanges();
                    if (sonuc > 0)
                    {
                        MessageBox.Show("Ders başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Ders ekleme sırasında bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_geri_Click(object sender, EventArgs e)
        {
            this.Hide();
            OgrenciIslem ogrenciIslem = new OgrenciIslem();
            ogrenciIslem.Show();
        }
    }
}
