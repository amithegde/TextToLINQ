using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TextToLINQ
{
    public partial class Form1 : Form
    {
        public List<Sales> SourceData { get; set; }

        public string UserQuery { get; set; }
        public Form1()
        {
            InitializeComponent();

            LoadSourceData();
        }

        private void LoadSourceData()
        {
            #region Load Staic Sample Data
            this.SourceData = new List<Sales>
            {
                new Sales
                {
                    OrderDate = DateTimeOffset.Parse("1/6/10"),
                    Region = "East",
                    RepName = "Jones",
                    Item = "Pencil",
                    Units = 95,
                    UnitCost = 1.99,
                    Total = 189.05
                },
                new Sales
                {
                    OrderDate = DateTimeOffset.Parse("1/23/10"),
                    Region = "Central",
                    RepName = "Kivell",
                    Item = "Binder",
                    Units = 50,
                    UnitCost = 19.99,
                    Total = 999.50
                },
                new Sales
                {
                    OrderDate = DateTimeOffset.Parse("2/9/10"),
                    Region = "Central",
                    RepName = "Jones",
                    Item = "Pencil",
                    Units = 36,
                    UnitCost = 4.99,
                    Total = 179.64
                },
                new Sales
                {
                    OrderDate = DateTimeOffset.Parse("2/26/10"),
                    Region = "Central",
                    RepName = "Gill",
                    Item = "Pen",
                    Units = 27,
                    UnitCost = 19.99,
                    Total = 539.73
                },
                new Sales
                {
                    OrderDate = DateTimeOffset.Parse("3/15/10"),
                    Region = "West",
                    RepName = "Sorvino",
                    Item = "Pencil",
                    Units = 56,
                    UnitCost = 2.99,
                    Total = 167.44
                },
                new Sales
                {
                    OrderDate = DateTimeOffset.Parse("4/1/10"),
                    Region = "East",
                    RepName = "Jones",
                    Item = "Binder",
                    Units = 60,
                    UnitCost = 4.99,
                    Total = 299.40
                },
                new Sales
                {
                    OrderDate = DateTimeOffset.Parse("4/18/10"),
                    Region = "Central",
                    RepName = "Andrews",
                    Item = "Pencil",
                    Units = 75,
                    UnitCost = 1.99,
                    Total = 149.25
                },
                new Sales
                {
                    OrderDate = DateTimeOffset.Parse("5/5/10"),
                    Region = "Central",
                    RepName = "Jardine",
                    Item = "Pencil",
                    Units = 90,
                    UnitCost = 4.99,
                    Total = 449.10
                },
                new Sales
                {
                    OrderDate = DateTimeOffset.Parse("5/22/10"),
                    Region = "West",
                    RepName = "Thompson",
                    Item = "Pencil",
                    Units = 32,
                    UnitCost = 1.99,
                    Total = 63.68
                },
                new Sales
                {
                    OrderDate = DateTimeOffset.Parse("6/8/10"),
                    Region = "East",
                    RepName = "Jones",
                    Item = "Binder",
                    Units = 60,
                    UnitCost = 8.99,
                    Total = 539.40
                },
                new Sales
                {
                    OrderDate = DateTimeOffset.Parse("6/25/10"),
                    Region = "Central",
                    RepName = "Morgan",
                    Item = "Pencil",
                    Units = 90,
                    UnitCost = 4.99,
                    Total = 449.10
                },
                new Sales
                {
                    OrderDate = DateTimeOffset.Parse("7/12/10"),
                    Region = "East",
                    RepName = "Howard",
                    Item = "Binder",
                    Units = 29,
                    UnitCost = 1.99,
                    Total = 57.71
                },
                new Sales
                {
                    OrderDate = DateTimeOffset.Parse("7/29/10"),
                    Region = "East",
                    RepName = "Parent",
                    Item = "Binder",
                    Units = 81,
                    UnitCost = 19.99,
                    Total = 1619.19
                },
                new Sales
                {
                    OrderDate = DateTimeOffset.Parse("8/15/10"),
                    Region = "East",
                    RepName = "Jones",
                    Item = "Pencil",
                    Units = 35,
                    UnitCost = 4.99,
                    Total = 174.65
                },
                new Sales
                {
                    OrderDate = DateTimeOffset.Parse("9/1/10"),
                    Region = "Central",
                    RepName = "Smith",
                    Item = "Desk",
                    Units = 2,
                    UnitCost = 125.00,
                    Total = 250.00
                },
                new Sales
                {
                    OrderDate = DateTimeOffset.Parse("9/18/10"),
                    Region = "East",
                    RepName = "Jones",
                    Item = "Pen Set",
                    Units = 16,
                    UnitCost = 15.99,
                    Total = 255.84
                },
                new Sales
                {
                    OrderDate = DateTimeOffset.Parse("10/5/10"),
                    Region = "Central",
                    RepName = "Morgan",
                    Item = "Binder",
                    Units = 28,
                    UnitCost = 8.99,
                    Total = 251.72
                }
            };

            #endregion
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = SourceData;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text)) return;

            UserQuery = textBox1.Text;
            LoadFilteredData();
        }

        private void LoadFilteredData()
        {   
            var filteredData = DataFilterHelper.GetFilteredData(this.SourceData, UserQuery);

            dataGridView2.DataSource = filteredData;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "data.Where(x => x.Region == \"East\" && x.Units > 50).Select(x => new {x.Item})";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "from d in data where d.Item == \"Pencil\" && d.Units > 50 select new {d.Region, d.Units, d.Item}";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = @"data.GroupBy(x => x.Region).Select(x => new {Region = x.Key, Units = x.Sum(y => y.Units)})";
        }
    }

    /// <summary>
    /// Sample POCO
    /// </summary>
    public class Sales
    {
        public string Region { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public string RepName { get; set; }
        public string Item { get; set; }
        public int Units { get; set; }
        public double UnitCost { get; set; }
        public double Total { get; set; }
    }
}
