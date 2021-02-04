using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace adres2
{
    public partial class ekle : Form
    {
        List<Kisi> kisiler = null;

        public ekle(List<Kisi> kisiler)
        {
            InitializeComponent();
            this.kisiler = kisiler;
        }

        private void Button1_Click(object sender, EventArgs e)
        { 
            if (anaekran.which == "ynkyt")
            {
            Random rastgele = new Random();
            int sayi = rastgele.Next();
            Kisi k = new Kisi();
            int ascii = rastgele.Next(65, 91);
            char karakter = Convert.ToChar(ascii);
            string newid = karakter + sayi.ToString();
            k.Id = newid;
            k.Ad = textBox1.Text;
            k.Soyad = textBox2.Text;
            k.Tarih = dateTimePicker1.Value;
            k.Telefon = textBox3.Text;
            k.Email = textBox4.Text;
            k.Adres = textBox5.Text;
            kisiler.Add(k);
            this.DialogResult = DialogResult.OK;
            }
            else if (anaekran.which == "gncl")
            {
                var result = kisiler.Where(p => p.Id.Contains(anaekran.idguncel)).ToList();
                foreach (var el in result)
                {
                    kisiler.RemoveAll(s => s.Id == anaekran.idguncel);
                    el.Id = anaekran.idguncel;
                    el.Ad = textBox1.Text;
                    el.Soyad = textBox2.Text;
                    el.Tarih = dateTimePicker1.Value;
                    el.Telefon = textBox3.Text;
                    el.Email = textBox4.Text;
                    el.Adres = textBox5.Text;
                    kisiler.Add(el);
                }
                this.DialogResult = DialogResult.OK;

            }
            anaekran.which = "";
        }

        private void Ekle_Load(object sender, EventArgs e)
        {label7.Text = anaekran.idguncel;
            if (anaekran.which == "ynkyt")
            {
            }
            else if (anaekran.which == "gncl")
            {
                var result = kisiler.Where(p => p.Id.Contains(anaekran.idguncel)).ToList();
                foreach (var el in result)
                {
                    
                    textBox1.Text = el.Ad;
                    textBox2.Text = el.Soyad;
                    dateTimePicker1.Value = el.Tarih;
                    textBox3.Text = el.Telefon;
                    textBox4.Text = el.Email;
                    textBox5.Text = el.Adres;
                }
            }
        }
    }
}
