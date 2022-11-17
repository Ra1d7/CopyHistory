using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CopyHistory
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        Dictionary<string,DateTime> dateofitem = new Dictionary<string,DateTime>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            string cur_clip = Clipboard.GetText().ToString();
            if (listBox1.Items.Contains(cur_clip))
            {
                //
            }
            else
            {
                if (cur_clip.Length != 0)
                {
                    listBox1.Items.Add(cur_clip);
                    try
                    {
                        dateofitem.Add(cur_clip, DateTime.Now);
                    }
                    catch
                    {
                        //
                    }
                    
                }
            }
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                Clipboard.SetText(listBox1.SelectedItem.ToString());
                MessageBox.Show("Copied!");
            }
            catch
            {
                MessageBox.Show("Could Not Perform hotkey, make sure an item is selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void listBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                switch (e.KeyChar.ToString().ToLower())
                {
                    case "h":
                        ShowHelp();
                        break;
                    case "f":
                        MessageBox.Show(listBox1.SelectedItem.ToString());
                        break;
                    case "d":
                        listBox1.Items.Remove(listBox1.SelectedItem);
                        break;
                    case "t":
                        MessageBox.Show(dateofitem[listBox1.SelectedItem.ToString()].ToString());
                        break;
                }
            }
            catch
            {

            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            ShowHelp();   
        }

        private void ShowHelp()
        {
            MessageBox.Show("- Pressing F will show the full text of the selected item\n- Pressing D will delete the selected item\n- Pressing H will show this menu\n- Pressing T will show the time you copied the item\n- Double clicking an item will copy it", "Useful Shortcuts:", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowHelp();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
        }
    }
}
