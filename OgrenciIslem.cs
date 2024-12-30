using System;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using OgrenciBilgilendirmeApp.Context;
using OgrenciBilgilendirmeApp.Model;

namespace OgrenciBilgilendirmeApp
{
    public partial class OgrenciIslem : Form
    {
        Ogrenciler? ogr;

        public OgrenciIslem()
        {
            InitializeComponent();
        }

        private void OgrenciIslem_Load(object sender, EventArgs e)
        {
            using (var ctx = new ObsDbContext())
            {
                var siniflar = ctx.Siniflars!.Select(s => new { s.SinifId, s.SinifAdi }).ToList();
                cmbSinif.DataSource = siniflar;
                cmbSinif.DisplayMember = "SinifAdi";
                cmbSinif.ValueMember = "SinifId";
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string? secilenSinifAdi = cmbSinif.Text;
            foreach (Control item in grpOgrenciBilgileri.Controls)
            {
                if (item is TextBox && item.Text == string.Empty)
                {
                    MessageBox.Show("Lütfen tüm alanlarý doldurun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            }

            try
            {
                using (var ctx = new ObsDbContext())
                {
                    int secilenSinifId = (int)cmbSinif.SelectedValue;
                    int mevcutOgrenciSayisi = ctx.Ogrencilers!.Count(o => o.SinifId == secilenSinifId);
                    var sinif = ctx.Siniflars!.FirstOrDefault(s => s.SinifId == secilenSinifId);

                    if (sinif == null)
                    {
                        MessageBox.Show("Sýnýf bulunamadý.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (sinif.Kontenjan <= mevcutOgrenciSayisi)
                    {
                        MessageBox.Show("Kontenjan Yetersiz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    this.ogr = new Ogrenciler
                    {
                        OgrenciAd = txtAd.Text.Trim(),
                        OgrenciSoyad = txtSoyad.Text.Trim(),
                        OgrenciNumara = txtNumara.Text.Trim(),
                        SinifId = secilenSinifId
                    };
                    ctx.Ogrencilers!.Add(ogr);
                    int sonuc = ctx.SaveChanges();
                    MessageBox.Show($"{sonuc} Kayýt Baþarýyla Yapýldý");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluþtu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            using (var ctx = new ObsDbContext())
            {
                if (this.ogr != null)
                {
                    var sinifId = cmbSinif.SelectedValue as int?;

                    if (sinifId == null)
                    {
                        MessageBox.Show("Lütfen geçerli bir sýnýf seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var sinif = ctx.Siniflars.FirstOrDefault(s => s.SinifId == sinifId);
                    if (sinif == null)
                    {
                        MessageBox.Show("Seçilen sýnýf bulunamadý.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    ogr.OgrenciAd = txtAd.Text;
                    ogr.OgrenciSoyad = txtSoyad.Text;
                    ogr.OgrenciNumara = txtNumara.Text;
                    ogr.SinifId = sinif.SinifId;

                    ctx.Entry(ogr).State = EntityState.Modified;

                    try
                    {
                        int sonuc = ctx.SaveChanges();
                        MessageBox.Show($"{sonuc} kullanýcý baþarýyla güncellendi.", "Baþarýlý", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Bir hata oluþtu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Lütfen geçerli bir öðrenci seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }


        private void btnBul_Click(object sender, EventArgs e)
        {
            string secilenOgrenciNumarasi = txtNumara.Text.Trim();
            if (secilenOgrenciNumarasi == string.Empty)
            {
                MessageBox.Show("Lütfen bulmak istediðiniz kiþinin numarasýný girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                using (var ctx = new ObsDbContext())
                {
                    var ogr = ctx.Ogrencilers!.FirstOrDefault(s => s.OgrenciNumara == secilenOgrenciNumarasi);

                    if (ogr == null)
                    {
                        MessageBox.Show("Seçilen öðrenci bulunamadý.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var sinif = ctx.Siniflars!.FirstOrDefault(s => s.SinifId == ogr.SinifId);

                    if (sinif == null)
                    {
                        MessageBox.Show("Öðrencinin sýnýf bilgisi bulunamadý.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    this.ogr = ogr;
                    txtAd.Text = ogr.OgrenciAd;
                    txtSoyad.Text = ogr.OgrenciSoyad;
                    txtNumara.Text = ogr.OgrenciNumara;

                    cmbSinif.SelectedValue = sinif.SinifId;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluþtu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDers_Click(object sender, EventArgs e)
        {
            foreach (Control item in grpOgrenciBilgileri.Controls)
            {
                if (item is TextBox && item.Text == string.Empty)
                {
                    MessageBox.Show("Lütfen tüm alanlarý doldurun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            }
            DersSecim dersSecim = new DersSecim(txtAd.Text, txtSoyad.Text, txtNumara.Text, cmbSinif.Text);
            dersSecim.Show();
            this.Hide();
        }
        private void btnDersIslem_Click(object sender, EventArgs e)
        {
            DersIslem dersIslem = new DersIslem();
            dersIslem.Show();
            this.Hide();
        }

        private void btnSinifIslem_Click(object sender, EventArgs e)
        {
            SinifIslem sinifIslem = new SinifIslem();
            sinifIslem.Show();
            this.Hide();
        }

    }
}
