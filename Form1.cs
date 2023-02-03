using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhoneBook
{
    public partial class DemoPhoneBook : Form
    {

        DataTable phoneContacts = new DataTable();
        bool isEditing = false;

        public DemoPhoneBook()
        {
            InitializeComponent();
        }

        private void DemoPhoneBook_Load(object sender, EventArgs e)
        {
            phoneContacts.Columns.Add("First Name", typeof(string));
            phoneContacts.Columns.Add("Last Name", typeof(string));
            phoneContacts.Columns.Add("Phone Number");
            phoneContacts.Columns.Add("Email");


            //link created data to grid table
            phoneDataGrid.DataSource= phoneContacts;

            //resize buttons
            btnSave.Height = 30;
            btnLoad.Height = 30;
            btnNew.Height = 30;

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtLastName.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            txtName.Text = phoneContacts.Rows[phoneDataGrid.CurrentCell.RowIndex].ItemArray[0].ToString();
            txtLastName.Text = phoneContacts.Rows[phoneDataGrid.CurrentCell.RowIndex].ItemArray[1].ToString();
            txtPhone.Text = phoneContacts.Rows[phoneDataGrid.CurrentCell.RowIndex].ItemArray[2].ToString();
            txtEmail.Text = phoneContacts.Rows[phoneDataGrid.CurrentCell.RowIndex].ItemArray[3].ToString();

            isEditing = true;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(isEditing)
            {
                phoneContacts.Rows[phoneDataGrid.CurrentCell.RowIndex]["First Name"] = txtName.Text;        
                phoneContacts.Rows[phoneDataGrid.CurrentCell.RowIndex]["Last Name"] = txtLastName.Text;        
                phoneContacts.Rows[phoneDataGrid.CurrentCell.RowIndex]["Phone Number"] = txtPhone.Text;        
                phoneContacts.Rows[phoneDataGrid.CurrentCell.RowIndex]["Email"] = txtEmail.Text;        

            }
            else
            {
                phoneContacts.Rows.Add(txtName.Text, txtLastName.Text, txtPhone.Text, txtEmail.Text);
            }
            txtName.Text = "";
            txtLastName.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            isEditing = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                phoneContacts.Rows[phoneDataGrid.CurrentCell.RowIndex].Delete();
                phoneDataGrid.DataSource = phoneContacts;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid selection");
            }
        }

        private void phoneDataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtName.Text = phoneContacts.Rows[phoneDataGrid.CurrentCell.RowIndex].ItemArray[0].ToString();
            txtLastName.Text = phoneContacts.Rows[phoneDataGrid.CurrentCell.RowIndex].ItemArray[1].ToString();
            txtPhone.Text = phoneContacts.Rows[phoneDataGrid.CurrentCell.RowIndex].ItemArray[2].ToString();
            txtEmail.Text = phoneContacts.Rows[phoneDataGrid.CurrentCell.RowIndex].ItemArray[3].ToString();

            isEditing = true;
        }
    }
}
