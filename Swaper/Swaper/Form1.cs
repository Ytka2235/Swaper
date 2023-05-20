using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Swaper
{
    public partial class Form1 : Form
    {
        double[] coff = new double[] {0.71,0.45,2.48,1.78,0.1016,0.1778,0.71,1066.8,0.0444};
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int i = 0; i < checkedListBox.Items.Count; ++i)
                if (i != e.Index) checkedListBox.SetItemChecked(i, false);
        }

        private async void but_swp_Click(object sender, EventArgs e)
        {
            double number;
            if (!double.TryParse(textBox.Text, out number)) return;
            double x = Convert.ToDouble(textBox.Text);

            int y = -1;
            foreach (object itemChecked in checkedListBox.CheckedItems)
            {
                if (checkedListBox.GetItemCheckState(checkedListBox.Items.IndexOf(itemChecked)) == CheckState.Checked)
                    y = checkedListBox.Items.IndexOf(itemChecked);
            }
            if (y == -1) return;
            label.Text = Convert.ToString(x * coff[y]);

            if (checkBox.Checked)
            {
                string path = "C:\\Users\\admin_0\\source\\repos\\Swaper\\SWAP.txt";
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    await writer.WriteLineAsync($"{textBox.Text} {checkedListBox.GetItemText(checkedListBox.Items[y])} = {label.Text} метр");
                }
            }

        }
    }
}
