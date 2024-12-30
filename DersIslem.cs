using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using OgrenciBilgilendirmeApp.Context;
using OgrenciBilgilendirmeApp.Model;

namespace OgrenciBilgilendirmeApp
{
    public partial class DersIslem : Form
    {
        Dersler? ders;
        public DersIslem()
        {
            InitializeComponent();
            GetTableData();
        }

        private void DersIslem_Load(object sender, EventArgs e)
        {

        }

        private void grpDersBilgileri_Enter(object sender, EventArgs e)
        {

        }

        private void btnDersEkle_Click(object sender, EventArgs e)
{
    // Tüm giriş alanlarının doldurulduğundan emin olun
    foreach (Control item in grpDersBilgileri.Controls)
    {
        if (item is TextBox && string.IsNullOrWhiteSpace(item.Text))
        {
            MessageBox.Show("Lütfen tüm alanları doldurun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
    }

    try
    {
        var yeniDersAdi = txtDersAdi.Text.Trim();
        var yeniDersKodu = txtDersKodu.Text.Trim();

        using (var ctx = new ObsDbContext())
        {
            var mevcutDers = ctx.Derslers.FirstOrDefault(d => d.DersKodu == yeniDersKodu);
            if (mevcutDers != null)
            {
                MessageBox.Show("Bu kodla zaten bir ders mevcut. Lütfen başka bir ders kodu girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var klnc = new Dersler
            {
                DersAdi = yeniDersAdi,
                DersKodu = yeniDersKodu
            };

            ctx.Derslers.Add(klnc);
            int sonuc = ctx.SaveChanges();
            MessageBox.Show($"{sonuc} ders başarıyla kaydedildi.", "Başarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        GetTableData();
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}


        private void btnDersGuncelle_Click(object sender, EventArgs e)
        { 

            using (var ctx = new ObsDbContext())
            {
                if (this.ders != null)
                {
                    ders.DersAdi = txtDersAdi.Text.Trim();
                    ders.DersKodu = txtDersKodu.Text;
                    ctx.Entry(ders).State = EntityState.Modified;
                    int sonuc = ctx.SaveChanges();
                    MessageBox.Show($"{sonuc} kullanıcı güncellendi");
                    GetTableData();
                }
                else
                {
                    MessageBox.Show("Lütfen Değerleri Giriniz");
                }
            }
        }

        private void btnDersSil_Click(object sender, EventArgs e)
        {
            string dersadi = txtDersAdi.Text.Trim();
            if (dersadi == string.Empty)
            {
                MessageBox.Show("Lütfen silmek istediğiniz sınıf adını girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var ctx = new ObsDbContext())
                {
                    var ders = ctx.Derslers!.FirstOrDefault(s => s.DersAdi == dersadi);

                    if (ders == null)
                    {
                        MessageBox.Show("Seçilen sınıf bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int ogrenciSayisi = ctx.OgrenciDerslers!.Count(o => o.DersId == ders.DersId);
                    if (ogrenciSayisi > 0)
                    {
                        MessageBox.Show("Bu dersi almış öğrenciler bulunduğu için silme işlemi yapılamaz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    ctx.Derslers!.Remove(ders);
                    int sonuc = ctx.SaveChanges();
                    MessageBox.Show($"{sonuc} Sınıf başarıyla silindi.", "Başarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                GetTableData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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


        private void dgvDersler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvDersler.Rows[e.RowIndex];

                txtDersAdi.Text = selectedRow.Cells["Ders Adı"].Value.ToString();
                txtDersKodu.Text = selectedRow.Cells["Ders Kodu"].Value.ToString();

                int dersId = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                using (var ctx = new ObsDbContext())
                {
                    this.ders = ctx.Derslers.FirstOrDefault(d => d.DersId == dersId);
                }
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
