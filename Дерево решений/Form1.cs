using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Дерево_решений
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        List<TextBox> textBoxes = new List<TextBox>();
        List<DataGridView> dataGridViewes = new List<DataGridView>();
        private void CreateTextBox(int count)
        {
            int x = (textBoxAnswer.Location.X / (int)numericUpDown1.Value) + 70;
            for (int i = 0; i < count; i++)
            {
                string name = "textBox" + i.ToString();
                string name2 = "dataGridView" + i.ToString();

                TextBox textBox = new TextBox();
                DataGridView dataGridView = new DataGridView();

                textBox.Name = name;
                dataGridView.Name = name2;

                textBox.Width = 40;
                textBox.Height = 20;


                dataGridView.Width = 200;
                dataGridView.Height = 200;
                dataGridView.Columns.Add("Вероятности", "Количество посетителей");
                dataGridView.Columns.Add("Деньги", "Доход");
                dataGridView.RowHeadersVisible = false;

                int y = 50;
                textBox.Location = new Point(x + x*i, textBoxAnswer.Location.Y + y);
                dataGridView.Location = new Point(x + x * i - 75, textBoxAnswer.Location.Y + y + 70);
                

                Controls.Add(textBox);
                Controls.Add(dataGridView);
                textBoxes.Add(textBox);
                dataGridViewes.Add(dataGridView);
            }
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {

            CreateTextBox((int)numericUpDown1.Value);

           
                

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<double> dd = new List<double>();
            double a = 0;
            double b = 0;
            double c = 0;
            double d = 0;
            for (int i = 0; i < dataGridViewes.Count(); i++)
            {
                for (int j = 0; j < dataGridViewes[i].RowCount-1; j++)
                {
                    a = Convert.ToDouble(dataGridViewes[i].Rows[j].Cells[0].Value);
                    b = Convert.ToDouble(dataGridViewes[i].Rows[j].Cells[1].Value);
                    c = a * b;
                    d += c;
                }
                textBoxes[i].Text = d.ToString();
                dd.Add(d);
                d=0;
            }
            for (int i = 0; i < textBoxes.Count(); i++)
            {
                textBoxAnswer.Text= dd.Max().ToString();
            }
        }
    }
}
