using Super_Shop_Spring_2019_20.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Super_Shop_Spring_2019_20.UI_Layer
{
    public partial class ProductManagement : Form
    {
        ProductService productService;
        int id;
        public ProductManagement()
        {
            InitializeComponent();
            this.productService = new ProductService();
        }

        private void ProductManagement_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void ProductManagement_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = productService.GetAllProducts();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = productService.GetProductById(Convert.ToInt32(textBox1.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = productService.GetAllProducts();
            ClearText();
        }

        void UpdateGridView()
        {
            dataGridView1.DataSource = productService.GetAllProducts();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            int result = productService.AddProduct(textBox2.Text, Convert.ToSingle(textBox3.Text));
            if (result > 0)
            {
                MessageBox.Show("Product added successfully.");
                UpdateGridView();
                ClearText();
            }
            else
            {
                MessageBox.Show("Error occured..");
                ClearText();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int result = productService.EditProduct(id,textBox4.Text, Convert.ToSingle(textBox5.Text));
            if (result > 0)
            {
                MessageBox.Show("Product updated successfully.");
                UpdateGridView();
                ClearText();
            }
            else
            {
                MessageBox.Show("Error occured..");
                ClearText();
            }
        }
        void ClearText()
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = string.Empty;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            int result = productService.RemoveProduct(Convert.ToInt32(textBox6.Text));
            DialogResult dresult = MessageBox.Show("Are you sure?","Confirmation",MessageBoxButtons.YesNo);
            if (dresult == DialogResult.Yes)
            {
                if (result > 0)
                {
                    MessageBox.Show("Product deleted successfully.");
                    UpdateGridView();
                    ClearText();
                }
                else
                {
                    MessageBox.Show("Error occured..");
                    ClearText();
                }
            }
            else { }


            
        }
    }
}
