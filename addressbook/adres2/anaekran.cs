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
    public partial class anaekran : Form
    {
        List<Kisi> kisiler = null;
        public anaekran()
        {
            InitializeComponent();
            kisiler = new List<Kisi>();
            BindData();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string keyword = textBox1.Text;
            var result = kisiler.Where(p => p.Ad.Contains(keyword)).ToList();
            listView1.Items.Clear();
            foreach (var el in result)
            {
                ListViewItem item = new ListViewItem(el.Ad);
                item.SubItems.Add(el.Soyad);
                item.SubItems.Add(el.Tarih.ToShortDateString());
                item.SubItems.Add(el.Telefon);
                item.SubItems.Add(el.Id);
                listView1.Items.Add(item);
            }
                
        }

        void BindData()
        {
            listView1.Items.Clear();
            foreach (var kisi in kisiler)
            {
                ListViewItem item = new ListViewItem(kisi.Ad);
                item.SubItems.Add(kisi.Soyad);
                item.SubItems.Add(kisi.Tarih.ToShortDateString());
                item.SubItems.Add(kisi.Telefon);
                item.SubItems.Add(kisi.Id);
                listView1.Items.Add(item);
            }
        }
        public static string which="";
        private void Button2_Click(object sender, EventArgs e)
        {
            which = "ynkyt";
            ekle frm2 = new ekle(kisiler);
            if (frm2.ShowDialog() == DialogResult.OK)
            {
                BindData();
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0) {
                string idsorgula;
                idsorgula = listView1.SelectedItems[0].SubItems[4].Text;
                kisiler.RemoveAll(s => s.Id == idsorgula);
                listView1.Items.RemoveAt(listView1.SelectedItems[0].Index);
            }
            else
            {
                MessageBox.Show("seçilen eleman yok");
            }
                
        }
        public static string idguncel;
        private void Button3_Click(object sender, EventArgs e)
        {
            which = "";
            which = "gncl";
            if (listView1.SelectedIndices.Count > 0)
            {
                idguncel = listView1.SelectedItems[0].SubItems[4].Text;
                ekle frm2 = new ekle(kisiler);
                frm2.ShowDialog();
            }
            else
            {
                MessageBox.Show("seçili kisi yok");
            }
            
            
        }
    }
}
