using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Bank
{
    public partial class Clients : Form
    {

        public class Client
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Product { get; set; }
        }

        List<Client> clients = new List<Client>()
        {
            new Client(){

                ID = 4, Name = "ivanov ivan petrovich", Product = "Credit"
            },
            new Client(){

                ID = 3, Name = "stroganov ivan petrovich", Product = "Credit"
            },
            new Client(){

                ID = 2, Name = "shostakovich ivan iakovlevich", Product = "Card"
            },
            new Client(){

                ID = 1, Name = "ivanov ivan zaurovich", Product = "Depozit"
            }

        };


        public Clients()
        {
            InitializeComponent();

            dataGridView2.DataSource = clients;

            string[] daysOfWeek = { "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота", "Воскресенье" };
            int[] numberOfVisitors = { 1200, 1450, 1504, 1790, 2450, 1900, 3050 };

            // Установим палитру
            chart1.Palette = ChartColorPalette.SeaGreen;

            // Заголовок графика
            chart1.Titles.Add("Посетители");

            // Добавляем последовательность
            for (int i = 0; i < clients.Count; i++)
            {
                Series series = chart1.Series.Add(clients[i].Name);

                // Добавляем точку
                series.Points.Add(numberOfVisitors[i]);
            }


        }
        
        private void  button1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Form client = new ClientInfo();
            client.ShowDialog();
        }
    }
}
