using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Akaryakıt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        double dBenzin95 = 0, dBenzin97 = 0,
                 dDizel = 0, dEuroDizel = 0, dLpg = 0;//depodaki 

        double eBenzin95 = 0, eBenzin97 = 0,
               eDizel = 0, eEuroDizel = 0, eLpg = 0;//eklenen

        double fBenzin95 = 0, fBenzin97 = 0,
               fDizel = 0, fEuroDizel = 0, fLpg = 0; //fiyat

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)  //combobox1'in seçimi değiştiğinde çalışacak olan kodlar
        {
            if (comboBox1.Text == "Benzin(95)")
            {
                numericUpDown1.Enabled = true;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = false;
                numericUpDown5.Enabled = false;
            }
            else if (comboBox1.Text == "Benzin(97)")
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = true;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = false;
                numericUpDown5.Enabled = false;
            }
            else if (comboBox1.Text == "Dizel")
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = true;
                numericUpDown4.Enabled = false;
                numericUpDown5.Enabled = false;
            }
            else if (comboBox1.Text == "Euro Dizel")
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = true;
                numericUpDown5.Enabled = false;
            }
            else if (comboBox1.Text == "LPG")
            {
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = false;
                numericUpDown5.Enabled = true;
            }
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;
            numericUpDown5.Value = 0;
            label29.Text = "________";


        }

        private void button2_Click(object sender, EventArgs e)
        {
            sBenzin95 = double.Parse(numericUpDown1.Value.ToString());
            sBenzin97 = double.Parse(numericUpDown2.Value.ToString());
            sDizel = double.Parse(numericUpDown3.Value.ToString());
            sEuroDizel = double.Parse(numericUpDown4.Value.ToString());
            sLpg = double.Parse(numericUpDown5.Value.ToString());
            if (numericUpDown1.Enabled = true) //benzin95 seçildiyse
            {
                dBenzin95 = dBenzin95 - sBenzin95;  //kalan benzin95 miktarı
                label29.Text = Convert.ToString(sBenzin95 * fBenzin95); //ne kadar satıldığı * fiyatı=toplam satış fiyatını bulmuş olduk.
            }
            else if (numericUpDown2.Enabled = true)
            {
                dBenzin97 = dBenzin97 - sBenzin97;
                label29.Text = Convert.ToString(sBenzin97 * fBenzin97);
            }
            else if (numericUpDown3.Enabled = true)
            {
                dDizel = dDizel - sDizel;
                label29.Text = Convert.ToString(sDizel * fDizel);
            }
            else if (numericUpDown4.Enabled = true)
            {
                dEuroDizel = dEuroDizel - sEuroDizel;
                label29.Text = Convert.ToString(sEuroDizel * fEuroDizel);
            }
            else if (numericUpDown5.Enabled = true)
            {
                dLpg = dLpg - sLpg;
                label29.Text = Convert.ToString(sLpg * fLpg);
            }
            //KALANLARI DİZİYE TEKRAR AKTAR
            depoBilgileri[0] = Convert.ToString(dBenzin95);
            depoBilgileri[1] = Convert.ToString(dBenzin97);
            depoBilgileri[2] = Convert.ToString(dDizel);
            depoBilgileri[3] = Convert.ToString(dEuroDizel);
            depoBilgileri[4] = Convert.ToString(dLpg);
            System.IO.File.WriteAllLines(Application.StartupPath + "\\depo.txt", depoBilgileri);
            txtDepoOku();
            txtDepoYazdir();
            progressBarGuncelle();
            numericUpDownValue();
            //satış yapıldıktan sonra numericupdownlardaki değerler sıfırlansın.
            numericUpDown1.Value = 0;
            numericUpDown2.Value = 0;
            numericUpDown3.Value = 0;
            numericUpDown4.Value = 0;
            numericUpDown5.Value = 0;


        }

        private void button3_Click(object sender, EventArgs e)
        {
            //TextBoxa girilen değerin yuzdesini alarak fiyata ekliyoruz
            //örneğin textBoxa 5 girildiyse fiyat*5/100 yapıp eski fiyata eklemeliyiz
            try
            {
                fBenzin95 = fBenzin95 + (fBenzin95 * Convert.ToDouble(textBox6.Text) / 100);
                fiyatBilgileri[0] = Convert.ToString(fBenzin95);

            }
            catch (Exception)
            {
                textBox6.Text = "HATA!!";
            }
            try
            {
                fBenzin97 = fBenzin97 + (fBenzin97 * Convert.ToDouble(textBox7.Text) / 100);
                fiyatBilgileri[1] = Convert.ToString(fBenzin97);

            }
            catch (Exception)
            {
                textBox7.Text = "HATA!!";
            }
            try
            {
                fDizel = fDizel + (fDizel * Convert.ToDouble(textBox8.Text) / 100);
                fiyatBilgileri[2] = Convert.ToString(fDizel);

            }
            catch (Exception)
            {
                textBox8.Text = "HATA!!";
            }
            try
            {
                fEuroDizel = fEuroDizel + (fEuroDizel * Convert.ToDouble(textBox9.Text) / 100);
                fiyatBilgileri[3] = Convert.ToString(fEuroDizel);

            }
            catch (Exception)
            {
                textBox9.Text = "HATA!!";
            }
            try
            {
                fLpg = fLpg + (fLpg * Convert.ToDouble(textBox10.Text) / 100);
                fiyatBilgileri[4] = Convert.ToString(fLpg);

            }
            catch (Exception)
            {
                textBox10.Text = "HATA!!";
            }
            System.IO.File.WriteAllLines(Application.StartupPath + "\\fiyat.txt", fiyatBilgileri);
            txtFiyatOku();
            txtFiyatYazdir();
        }

        double sBenzin95 = 0, sBenzin97 = 0,
           sDizel = 0, sEuroDizel = 0, sLpg = 0; //satilan

        string[] depoBilgileri;
        string[] fiyatBilgileri;
        private void txtDepoOku() //Depodaki bilgileri okur
        {
            depoBilgileri = System.IO.File.ReadAllLines(Application.StartupPath + "\\depo.txt");
            //depo.txt dosyanin adi //StartupPath bin deki debug klasörü
            dBenzin95 = Convert.ToDouble(depoBilgileri[0]);
            dBenzin97 = Convert.ToDouble(depoBilgileri[1]);
            dDizel = Convert.ToDouble(depoBilgileri[2]);
            dEuroDizel = Convert.ToDouble(depoBilgileri[3]);
            dLpg = Convert.ToDouble(depoBilgileri[4]);
        }


        private void txtDepoYazdir()
        {
            label6.Text = dBenzin95.ToString("N");
            label7.Text = dBenzin97.ToString("N");
            label8.Text = dDizel.ToString("N");
            label9.Text = dEuroDizel.ToString("N");
            label10.Text = dLpg.ToString("N");
        }

        private void txtFiyatOku()
        {

            fiyatBilgileri = System.IO.File.ReadAllLines(Application.StartupPath + ("\\fiyat.txt"));
            fBenzin95 = Convert.ToDouble(fiyatBilgileri[0]);
            fBenzin97 = Convert.ToDouble(fiyatBilgileri[1]);
            fDizel = Convert.ToDouble(fiyatBilgileri[2]);
            fEuroDizel = Convert.ToDouble(fiyatBilgileri[3]);
            fLpg = Convert.ToDouble(fiyatBilgileri[4]);

        }

        private void txtFiyatYazdir()
        {
            label17.Text = fBenzin95.ToString("N");
            label18.Text = fBenzin97.ToString("N");
            label19.Text = fDizel.ToString("N");
            label20.Text = fEuroDizel.ToString("N");
            label21.Text = fLpg.ToString("N");

        }

        private void progressBarGuncelle()
        {
            progressBar1.Value = Convert.ToInt16(dBenzin95);
            progressBar2.Value = Convert.ToInt16(dBenzin97);
            progressBar3.Value = Convert.ToInt16(dDizel);
            progressBar4.Value = Convert.ToInt16(dEuroDizel);
            progressBar5.Value = Convert.ToInt16(dLpg);
        }

        private void numericUpDownValue()
        {
            numericUpDown1.Maximum = decimal.Parse(dBenzin95.ToString());
            numericUpDown2.Maximum = decimal.Parse(dBenzin97.ToString());
            numericUpDown3.Maximum = decimal.Parse(dDizel.ToString());
            numericUpDown4.Maximum = decimal.Parse(dEuroDizel.ToString());
            numericUpDown5.Maximum = decimal.Parse(dLpg.ToString());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                eBenzin95 = Convert.ToDouble(textBox1.Text);
                if (eBenzin95 + dBenzin95 > 1000 || eBenzin95 <= 0)
                    textBox1.Text = "HATA!!";
                else
                {
                    depoBilgileri[0] = Convert.ToString(dBenzin95 + eBenzin95);
                }
            }
            catch (Exception) //Hata yakalandığında yapılacaklar
            {
                textBox1.Text = "HATA!!";
            }
            try
            {
                eBenzin97 = Convert.ToDouble(textBox2.Text);
                if (eBenzin97 + dBenzin97 > 1000 || eBenzin97 < 0)
                    textBox2.Text = "HATA!!";
                else
                {
                    depoBilgileri[1] = Convert.ToString(dBenzin97 + eBenzin97);
                }
            }
            catch (Exception)
            {
                textBox2.Text = "HATA!!";
            }
            try
            {
                eDizel = Convert.ToDouble(textBox3.Text);
                if (eDizel + dDizel > 1000 || eDizel <= 0)
                    textBox3.Text = "HATA!!";
                else
                {
                    depoBilgileri[2] = Convert.ToString(dDizel + eDizel);
                }

            }
            catch (Exception)
            {
                textBox3.Text = "HATA!!";
            }
            try
            {
                eEuroDizel = Convert.ToDouble(textBox4.Text);
                if (eEuroDizel + dEuroDizel > 1000 || eDizel <= 0)
                {
                    textBox4.Text = "HATA!!";
                }
                else
                {
                    depoBilgileri[3] = Convert.ToString(eEuroDizel + dEuroDizel);
                }

            }
            catch (Exception)
            {
                textBox4.Text = "HATA!!";
            }
            try
            {
                eLpg = Convert.ToDouble(textBox5.Text);
                if (eLpg + dLpg > 1000 || eLpg <= 0)
                {
                    textBox5.Text = "HATA!!";
                }
                else
                {
                    depoBilgileri[4] = Convert.ToString(eLpg + dLpg);
                }
            }
            catch (Exception)
            {
                textBox5.Text = "HATA!!";
            }

            //Yapılan bu değişikliklerden sonra txt dosyamızın da değişmesi gerekiyor

            System.IO.File.WriteAllLines(Application.StartupPath + "\\depo.txt", depoBilgileri);
            txtDepoOku();//depoBilgilerini okuyan metodu çağırdık
            txtDepoYazdir(); //labellara okunan değerleri yazdıracak
            progressBarGuncelle(); //yeni değerlere göre progressbarlar güncellenecek
            numericUpDownValue(); //deponun günceline göre düzenlenecek depodakinden fazla satış yapılamayacak
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "AKARYAKIT OTOMASYONU";

            progressBar1.Maximum = 1000;
            progressBar2.Maximum = 1000;
            progressBar3.Maximum = 1000;
            progressBar4.Maximum = 1000;
            progressBar5.Maximum = 1000;
            txtDepoOku();
            txtDepoYazdir();
            txtFiyatOku();
            txtFiyatYazdir();


            progressBarGuncelle();
            numericUpDownValue();

            string[] yakitTuru = { "Benzin(95)", "Benzin(97)", "Dizel", "Euro Dizel", "LPG" };
            comboBox1.Items.AddRange(yakitTuru);

            //Form yurutuldüğünde numericUpDown'lar pasif olmalı
            //yakıt türü seçildikten sonra seçilene göre aktif olacak
            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;
            numericUpDown3.Enabled = false;
            numericUpDown4.Enabled = false;
            numericUpDown5.Enabled = false;

            //numericUpDownların virgülden sonra kaç basamak göstereceği
            numericUpDown1.DecimalPlaces = 2;
            numericUpDown2.DecimalPlaces = 2;
            numericUpDown3.DecimalPlaces = 2;
            numericUpDown4.DecimalPlaces = 2;
            numericUpDown5.DecimalPlaces = 2;

            //numericUpDownların değerinin kaç kaç artacağı 
            numericUpDown1.Increment = 0.1M;
            numericUpDown2.Increment = 0.1M;
            numericUpDown3.Increment = 0.1M;
            numericUpDown4.Increment = 0.1M;
            numericUpDown5.Increment = 0.1M;

            //numericUpDowna dışarıdan değer girilmesini engellemek
            numericUpDown1.ReadOnly = true;
            numericUpDown2.ReadOnly = true;
            numericUpDown3.ReadOnly = true;
            numericUpDown4.ReadOnly = true;
            numericUpDown5.ReadOnly = true;


        }







    }
}
