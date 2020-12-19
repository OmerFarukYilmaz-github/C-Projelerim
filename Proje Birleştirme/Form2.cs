using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje_Ödevi
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public string KullanıcıAdı { get; set; }
        Calisan calisan = new Calisan();
        IdariKadro Idari = new IdariKadro();


        Oyuncu oyuncu = new Oyuncu();
        string OyuncuAd;
        string OyuncuSoyad;
        string UzmanlikAlani;
        decimal Maas;
        DateTime Projebaslangic;
        DateTime Projebitis;

        OfisCalisan OfisIsleri = new OfisCalisan();

        private void Form2_Load(object sender, EventArgs e)
        {
            if (KullanıcıAdı == "MudurYardımcısı")
            {
                idarikadroEkle.Visible = false;
                idarikadroSil.Visible = false;
                idarikadroGuncelle.Visible = false;
                labelUzmanlıkAlanı.Visible = false;
                oyuncuUzmanlık.Visible = false;
                oyuncuMaas.Enabled = false;
                oyuncuProjeata.Visible = false;
                oyuncuProjeCikar.Visible = false;
                oyuncuGuncelle.Visible = false;
                oyuncuEkle.Visible = false;
                oyuncuCikar.Visible = false;
            }
            //OfisÇalısanı 

            //
            listViewİdariKadro.View = View.Details;
            listViewİdariKadro.FullRowSelect = true;
            listViewİdariKadro.Columns.Add("Ad", 150);
            listViewİdariKadro.Columns.Add("Soyad", 150);
            listViewFirmalar.View = View.Details;
            listViewFirmalar.FullRowSelect = true;
            listViewFirmalar.Columns.Add("firma adı", 70, HorizontalAlignment.Left);
            listViewFirmalar.Columns.Add("bulunduğu şehir", 70, HorizontalAlignment.Left);
            listViewFirmalar.Columns.Add("iş türü", 70, HorizontalAlignment.Left);
            listViewFirmalar.Columns.Add("belirlenen bütçe", 70, HorizontalAlignment.Left);
            listViewFirmalar.Columns.Add("reklam süresi", 70, HorizontalAlignment.Left);
            listViewFirmalar.Columns.Add("iş sayısı", 70, HorizontalAlignment.Left);
            //Oyuncu
            listViewOyuncu.View = View.Details;
            listViewOyuncu.FullRowSelect = true;
            if (oyuncuProjeVar.Checked == true)
            {
                if (KullanıcıAdı != "MudurYardımcısı")
                {
                    listViewOyuncu.Columns.Add("Ad", 100);
                    listViewOyuncu.Columns.Add("Soyad", 100);
                    listViewOyuncu.Columns.Add("Kategori", 100);
                    listViewOyuncu.Columns.Add("Proje", 100);
                    listViewOyuncu.Columns.Add("Proje Başlangıç", 125);
                    listViewOyuncu.Columns.Add("Proje Bitiş", 125);
                    listViewOyuncu.Columns.Add("Maaş", 50);
                }
                else
                {
                    listViewOyuncu.Columns.Add("Ad", 100);
                    listViewOyuncu.Columns.Add("Soyad", 100);
                    listViewOyuncu.Columns.Add("Proje", 100);
                    listViewOyuncu.Columns.Add("Proje Başlangıç", 125);
                    listViewOyuncu.Columns.Add("Proje Bitiş", 125);
                    listViewOyuncu.Columns.Add("Maaş", 50);
                }
            }
            else if (oyuncuProjeVar.Checked == false)
            {
                listViewOyuncu.Columns.Add("Ad", 100);
                listViewOyuncu.Columns.Add("Soyad", 100);
                listViewOyuncu.Columns.Add("Kategori", 100);
                listViewOyuncu.Columns.Add("Maaş", 50);
            }
            listViewOfisCalisan.View = View.Details;
            listViewOfisCalisan.FullRowSelect = true;
            listViewOfisCalisan.Columns.Add("Ad", 100);
            listViewOfisCalisan.Columns.Add("Soyad", 100);
            listViewOfisCalisan.Columns.Add("Görevi", 170);
            listViewOfisCalisan.Columns.Add("İzin Günleri", 100);
            listViewOfisCalisan.Columns.Add("Maaş", 110);
        }
        private void ofiscalisanEkle_Click(object sender, EventArgs e)
        {

            if (ofiscalisanAd.Text == null || ofiscalisanSoyad.Text == null || ofiscalisanGorevi.SelectedItem == null ||
                 ofiscalisanIzini.Text == null || ofiscalisanMaas.Text == null)
            {
                MessageBox.Show("Lütfen Bilgileri Doldurunuz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ofiscalisanAd.Clear();
                ofiscalisanSoyad.Clear();
                ofiscalisanGorevi.SelectedItem = null;
                ofiscalisanIzini.Clear();
                ofiscalisanMaas.Clear();
            }
            else
            {

                OfisIsleri.ofisCalisanEkle(ofiscalisanAd.Text, ofiscalisanSoyad.Text, ofiscalisanGorevi.Text,
               Convert.ToInt32(ofiscalisanIzini.Text), Convert.ToDecimal(ofiscalisanMaas.Text));
                OfisIsleri.ofisCalisanListele(ofiscalisanAd.Text, ofiscalisanSoyad.Text, ofiscalisanGorevi.Text,
                    Convert.ToInt32(ofiscalisanIzini.Text), Convert.ToDecimal(ofiscalisanMaas.Text));
                string[] ofisBilgileri = {ofiscalisanAd.Text, ofiscalisanSoyad.Text ,  ofiscalisanGorevi.Text ,
                ofiscalisanIzini.Text.ToString(),ofiscalisanMaas.Text.ToString()};

                listViewOfisCalisan.Items.Add(new ListViewItem(ofisBilgileri));
            }
            ofiscalisanAd.Clear();
            ofiscalisanSoyad.Clear();
            ofiscalisanGorevi.SelectedItem = null;
            ofiscalisanIzini.Clear();
            ofiscalisanMaas.Clear();
        }
        private void ofiscalisanSil_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem secilen in listViewOfisCalisan.SelectedItems)
            { secilen.Remove(); }
            ofiscalisanAd.Clear();
            ofiscalisanSoyad.Clear();
            ofiscalisanGorevi.SelectedItem = null;
            ofiscalisanIzini.Clear();
            ofiscalisanMaas.Clear();

        }
        private void listViewOfisCalisan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewOfisCalisan.SelectedItems.Count > 0)
            {
                ListViewItem item = listViewOfisCalisan.SelectedItems[0];
                ofiscalisanAd.Text = item.SubItems[0].Text;
                ofiscalisanSoyad.Text = item.SubItems[1].Text;
                ofiscalisanGorevi.SelectedItem = item.SubItems[2].Text;
                ofiscalisanIzini.Text = item.SubItems[3].Text;
                ofiscalisanMaas.Text = item.SubItems[4].Text;

            }
        }
        private void ofiscalisanGuncelle_Click(object sender, EventArgs e)
        {
            if (ofiscalisanAd.Text == null || ofiscalisanSoyad.Text == null || ofiscalisanGorevi.SelectedItem == null ||
                 ofiscalisanIzini.Text == null || ofiscalisanMaas.Text == null)
            {
                MessageBox.Show("Lütfen Bilgileri Doldurunuz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ofiscalisanAd.Clear();
                ofiscalisanSoyad.Clear();
                ofiscalisanGorevi.SelectedItem = null;
                ofiscalisanIzini.Clear();
                ofiscalisanMaas.Clear();
            }
            else
            {


                foreach (ListViewItem secilen in listViewOfisCalisan.SelectedItems)
                { secilen.Remove(); }

                OfisIsleri.ofisCalisanEkle(ofiscalisanAd.Text, ofiscalisanSoyad.Text, ofiscalisanGorevi.Text,
                      Convert.ToInt32(ofiscalisanIzini.Text), Convert.ToDecimal(ofiscalisanMaas.Text));

                OfisIsleri.ofisCalisanListele(ofiscalisanAd.Text, ofiscalisanSoyad.Text, ofiscalisanGorevi.Text,
                    Convert.ToInt32(ofiscalisanIzini.Text), Convert.ToDecimal(ofiscalisanMaas.Text));
                string[] ofisBilgileri = {ofiscalisanAd.Text, ofiscalisanSoyad.Text ,  ofiscalisanGorevi.Text ,
                ofiscalisanIzini.Text.ToString(),ofiscalisanMaas.Text.ToString()};

                listViewOfisCalisan.Items.Add(new ListViewItem(ofisBilgileri));
                MessageBox.Show("Bilgiler Başarıyla Güncellenilmiştir...", "Güncelle", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }

        }
        private void oyuncuProjeVar_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void idarikadroEkle_Click(object sender, EventArgs e)
        {
            if (idarikadroSoyad.Text == null || idarikadroAd.Text == null)
            {
                MessageBox.Show("Ad veya Soyad boş girilemez");
            }
            else
            {
                Idari.IdariKadroDeğişkenAta(idarikadroAd.Text, idarikadroSoyad.Text);
                string[] bilgiler = { idarikadroAd.Text, idarikadroSoyad.Text };
                listViewİdariKadro.Items.Add(new ListViewItem(bilgiler));
                idarikadroAd.Text = "";
                idarikadroSoyad.Text = "";
            }
        }
        private void idarikadroSil_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem secilen in listViewİdariKadro.SelectedItems)
            { secilen.Remove(); }
            idarikadroAd.Text = "";
            idarikadroSoyad.Text = "";
        }

        private void idarikadroGuncelle_Click(object sender, EventArgs e)
        {
            ListViewItem Item = listViewİdariKadro.SelectedItems[0];
            Item.SubItems[0].Text = idarikadroAd.Text;
            Item.SubItems[1].Text = idarikadroSoyad.Text;
        }

        private void oyuncular_Click(object sender, EventArgs e)
        {

        }

        private void oyuncuEkle_Click(object sender, EventArgs e)
        {
            if (oyuncuAd.Text == null || oyuncuSoyad == null || oyuncuUzmanlık.Text == null || oyuncuMaas.Text == null)
            {
                MessageBox.Show("Lütfen eksik bilgileri tamamlayınız.");

            }
            else
            {
                OyuncuAd = oyuncuAd.Text;
                OyuncuSoyad = oyuncuSoyad.Text;
                UzmanlikAlani = oyuncuUzmanlık.Text;
                decimal Maas = Convert.ToDecimal(oyuncuMaas.Text);
                Projebaslangic = dateTimePickerBaş.Value;
                Projebitis = dateTimePickerBaş.Value;
                oyuncu.OyuncuEkle(OyuncuAd, OyuncuSoyad, Maas, oyuncuUzmanlık.Text);
                string oyuncuProje = "";

                if (oyuncuProjeVar.Checked == true)
                {
                    string[] bilgiler = { OyuncuAd, OyuncuSoyad, UzmanlikAlani, oyuncuProje , dateTimePickerBaş.Value.ToString(),
                      dateTimePickerBitiş.Value.ToString(),oyuncuMaas.Text.ToString() };
                    listViewOyuncu.Items.Add(new ListViewItem(bilgiler));
                }

                else
                {
                    string[] bilgiler = { OyuncuAd, OyuncuSoyad, UzmanlikAlani, oyuncuMaas.Text.ToString() };
                    listViewOyuncu.Items.Add(new ListViewItem(bilgiler));
                }
            }
        }

        private void oyuncuCikar_Click(object sender, EventArgs e)
        {

        }


        private void oyuncuProjeYok_CheckedChanged(object sender, EventArgs e)
        {
            if (oyuncuProjeVar.Checked == true)
            {
                labelProjeBaş.Visible = true;
                labelProjeBitiş.Visible = true;
                labelProjeIsmı.Visible = true;
                oyuncuProje.Visible = true;
                dateTimePickerBaş.Visible = true;
                dateTimePickerBitiş.Visible = true;
            }

            else
            {
                labelProjeBaş.Visible = false;
                labelProjeBitiş.Visible = false;
                labelProjeIsmı.Visible = false;
                oyuncuProje.Visible = false;
                dateTimePickerBaş.Visible = false;
                dateTimePickerBitiş.Visible = false;
            }

        }

        private void listViewİdariKadro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewİdariKadro.SelectedItems.Count > 0)
            {
                ListViewItem item = listViewİdariKadro.SelectedItems[0];
                idarikadroAd.Text = item.SubItems[0].Text;
                idarikadroSoyad.Text = item.SubItems[1].Text;

            }
        }
        private void firmaIsEkle_Click(object sender, EventArgs e)
        {
            int sayac = listViewFirmalar.Items.Count;
            listViewFirmalar.Items.Add(firmaAd.Text);
            listViewFirmalar.Items[sayac].SubItems.Add(firmaSehir.Text);
            listViewFirmalar.Items[sayac].SubItems.Add(firmaIsTuru.Text);
            listViewFirmalar.Items[sayac].SubItems.Add(firmaButce.Text);
            listViewFirmalar.Items[sayac].SubItems.Add(firmaIsSuresi.Text);
            listViewFirmalar.Items[sayac].SubItems.Add(firmaIsSayisi.Text);
        }

        private void firmalarIsCıkar_Click(object sender, EventArgs e)
        {
            DialogResult cevap123 = new DialogResult();

            cevap123 = MessageBox.Show("bilgileri silmek istediğinizden eminmisiniz?", "silme işlemi", MessageBoxButtons.YesNoCancel);
            if (cevap123 == DialogResult.Yes)
            {
                listViewFirmalar.SelectedItems[0].Remove();
            }
        }
    }
}

