using Pill.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Windows.Documents;
using System.Windows.Forms;

namespace Pill
{
    public partial class Form1 : Form
    {
        DataContext context = new DataContext();
        public Form1()
        {
            InitializeComponent();
            FillItem();
            BindGrid(0, "Store1");

        }

        private void FillItem()
        {
            //var depts =(from dept in context.items select dept).ToList();
            //CmpItems.DisplayMember = "ItemName";
            //CmpItems.ValueMember = "ID";
            //CmpItems.DataSource = depts;

            //CmpUnit.DisplayMember = "Unit";
            //CmpItems.ValueMember = "Unit";
            //CmpItems.DataSource = depts;

        }


        void BindGrid(int ID, string store)
        {
            var items = (from dept in context.items where dept.PillID == ID && dept.Pill.Store == store select dept).ToList();
            //var items = (from cust in context.pillitems where cust.pillid == id select cust.itemid).tolist();
            //messagebox.show(items.tostring());
            dataGridView1.DataSource = items;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;

            ////to create acombobox
            //DataGridViewComboBoxColumn cmb = new DataGridViewComboBoxColumn();
            //cmb.HeaderText = "Select Data";
            //cmb.Name = "cmb";
            //cmb.MaxDropDownItems = 4;
            //cmb.Items.Add("True");
            //cmb.Items.Add("False");
            //dataGridView1.Columns.Add(cmb);

        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            context.SaveChanges();
            FillTextbox();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                BindGrid(int.Parse(textBox1.Text), comboBox1.Text);
                FillTextbox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BindGrid(int.Parse(textBox1.Text), comboBox1.Text);
                FillTextbox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddRow();
            //FillTextbox();
        }

        private void AddRow()
        {
            var PillID = Int32.Parse(textBox1.Text);
            var store = comboBox1.Text;
            var dept =
                (from de in context.Pills
                 where de.ID == PillID && de.Store == store
                 select de).FirstOrDefault();


            if (dept != null)
            {
                var emp = new Item()
                {
                    ID = 0,
                    ItemName = "",
                    Unit = "",
                    Price = 0,
                    Qty = 0,
                    Total = "",
                    Discount = 0,
                    Net = 0,
                    PillID = PillID,
                };


                context.items.Add(emp);
                context.SaveChanges();
                MessageBox.Show("Added Successfully  ");
                BindGrid(int.Parse(textBox1.Text), comboBox1.Text);
            }

            else
            {
                var pill = new Fat()
                {
                    ID = PillID,
                    Store = store,
                    Date = dateTimePicker1.Value,
                };

                context.Pills.Add(pill);
                context.SaveChanges();
                MessageBox.Show("Pill Created successfully");
                BindGrid(int.Parse(textBox1.Text), comboBox1.Text);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

            var ItemID = Int32.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            var ItemDeleted =
                (from de in context.items
                 where de.ID == ItemID 
                 select de).FirstOrDefault();

            if (ItemDeleted != null)
            {
                context.items.Remove(ItemDeleted);
                context.SaveChanges();
                MessageBox.Show("Item Deleted");
                BindGrid(int.Parse(textBox1.Text), comboBox1.Text);
                FillTextbox();

            }
        }

        private void FillTextbox()
        {
            int TotalSum = 0;
            int DiscountSum = 0;
            int NetSum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                TotalSum += Convert.ToInt32(dataGridView1.Rows[i].Cells[5].Value);
                DiscountSum += Convert.ToInt32(dataGridView1.Rows[i].Cells[6].Value);
                NetSum += Convert.ToInt32(dataGridView1.Rows[i].Cells[7].Value);

            }
            textBox2.Text = TotalSum.ToString();
            textBox3.Text = DiscountSum.ToString();
            textBox4.Text = NetSum.ToString();

        }
    }
}
