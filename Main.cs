using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LibraryManagement
{
    public partial class Main : Form
    {
        SqlConnection connection;

        public Main()
        {
            InitializeComponent();
            connection = new SqlConnection(@"Data Source=DESKTOP-7L2SU06\SQLEXPRESS01;Initial Catalog=ASM2;Integrated Security=True;");
        }
        public Main(string username)
        {
            InitializeComponent();
            connection = new SqlConnection(@"Data Source=DESKTOP-7L2SU06\SQLEXPRESS01;Initial Catalog=ASM2;Integrated Security=True;");

            MessageBox.Show("Welcome" + username);
        }
        public void GetAuthors()
        {
            string query = "select author_id, author_name from Authors";
            DataTable table = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
            dataAdapter.Fill(table);
            cbBookAuthor.DataSource = table;
            cbBookAuthor.DisplayMember = "author_name";
            cbBookAuthor.ValueMember = "author_id";
        }
        public void GetCategories()
        {
            string query = "select category_id, category_name from Categories";
            DataTable table = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
            dataAdapter.Fill(table);
            cbBookCategory.DataSource = table;
            cbBookCategory.DisplayMember = "category_name";
            cbBookCategory.ValueMember = "category_id";
        }

        public void GetPublishers()
        {
            string query = "select publisher_id, publisher_name from Publishers";
            DataTable table = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
            dataAdapter.Fill(table);
            cbBookPublisher.DataSource = table;
            cbBookPublisher.DisplayMember = "publisher_name";
            cbBookPublisher.ValueMember = "publisher_id";
        }
        public void GetBooks()
        {
            string query = "select book_id, book_name from Books";
            DataTable table = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
            dataAdapter.Fill(table);
            cbTicketBook.DataSource = table;
            cbTicketBook.DisplayMember = "book_name";
            cbTicketBook.ValueMember = "book_id";
        }
        public void GetBorrowers()
        {
            string query = "select borrower_id, borrower_name from Borrowers";
            DataTable table = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
            dataAdapter.Fill(table);
            cbTicketBorrower.DataSource = table;
            cbTicketBorrower.DisplayMember = "borrower_name";
            cbTicketBorrower.ValueMember = "borrower_id";
        }
        public void FillDataBooks()
        {
            string query = "select * from Books";
            DataTable table = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
            dataAdapter.Fill(table);
            dgvBooks.DataSource = table;
        }
        public void ClearDataBooks()
        {
            txtBookID.Text = "";
            txtBookName.Text = "";
            cbBookAuthor.SelectedIndex = -1;
            cbBookCategory.SelectedIndex = -1;
            cbBookPublisher.SelectedIndex = -1;
        }
        public void FillDataBorrowers()
        {
            string query = "select * from Borrowers";
            DataTable table = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
            dataAdapter.Fill(table);
            dgvBorrowers.DataSource = table;
        }
        public void ClearDataBorrowers()
        {
            txtBorrowerID.Text = "";
            txtBorrowerName.Text = "";
            txtBorrowerAddress.Text = "";
            txtBorrowerPhone.Text = "";
            txtBorrowerEmail.Text = "";
        }
        public void FillDataTickets()
        {
            string query = "select * from Tickets";
            DataTable table = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
            dataAdapter.Fill(table);
            dgvTickets.DataSource = table;
        }
        public void ClearDataTickets()
        {
            txtTicketID.Text = "";
            cbTicketBook.SelectedIndex = -1;
            cbTicketBorrower.SelectedIndex = -1;
        }
        private void LoadData()
        {
            GetAuthors();
            GetCategories();
            GetPublishers();
            GetBooks();
            GetBorrowers();
            FillDataBooks();
            FillDataBorrowers();
            FillDataTickets();
        }

        private void tabPageBook_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void btnTicketClearData_Click(object sender, EventArgs e)
        {
            ClearDataTickets();
        }
        private void btnBorrowerClearData_Click(object sender, EventArgs e)
        {
            ClearDataBorrowers();
        }
        private void btnBookClearData_Click(object sender, EventArgs e)
        {
            ClearDataBooks();
        }
        private void btnBookAdd_Click(object sender, EventArgs e)
        {
            string name = txtBookName.Text;
            string authorsID = cbBookAuthor.SelectedValue.ToString();
            string categoryID = cbBookCategory.SelectedValue.ToString();
            string publisherID = cbBookPublisher.SelectedValue.ToString();
            DateTime publishingDate = dtpBookPublishingDate.Value;

            string insert = "insert into Books(book_name,author_id, category_id, publisher_id, publishing_date) values(@book_name, @author_id, @category_id, @publisher_id, @publishing_date)";
            connection.Open();
            SqlCommand cmd = new SqlCommand(insert, connection);
            cmd.Parameters.Add("@book_name", SqlDbType.NVarChar);
            cmd.Parameters["@book_name"].Value = name;

            cmd.Parameters.Add("@author_id", SqlDbType.Int);
            cmd.Parameters["@author_id"].Value = authorsID;

            cmd.Parameters.Add("@category_id", SqlDbType.Int);
            cmd.Parameters["@category_id"].Value = categoryID;

            cmd.Parameters.Add("@publisher_id", SqlDbType.Int);
            cmd.Parameters["@publisher_id"].Value = publisherID;

            cmd.Parameters.Add("@publishing_date", SqlDbType.DateTime);
            cmd.Parameters["@publishing_date"].Value = publishingDate;

            cmd.ExecuteNonQuery();
            FillDataBooks();
            ClearDataBooks();
            connection.Close();
            MessageBox.Show(this, "Inserted successfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.None);
        }
        private void dgvBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvBooks.Rows[e.RowIndex];
                txtBookID.Text = row.Cells["book_id"].Value.ToString();
                txtBookName.Text = row.Cells["book_name"].Value.ToString();
                cbBookAuthor.SelectedValue = row.Cells["author_id"].Value.ToString();
                cbBookCategory.SelectedValue = row.Cells["category_id"].Value.ToString();
                cbBookPublisher.SelectedValue = row.Cells["publisher_id"].Value.ToString();
                dtpBookPublishingDate.Value = (DateTime)row.Cells["publishing_date"].Value;
            }

        }
        private void dgvBorrowers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvBorrowers.Rows[e.RowIndex];
                txtBorrowerID.Text = row.Cells["borrower_id"].Value.ToString();
                txtBorrowerName.Text = row.Cells["borrower_name"].Value.ToString();
                txtBorrowerAddress.Text = row.Cells["borrower_address"].Value.ToString();
                txtBorrowerPhone.Text = row.Cells["borrower_phone"].Value.ToString();
                txtBorrowerEmail.Text = row.Cells["borrower_email"].Value.ToString();
                dtpBookPublishingDate.Value = (DateTime)row.Cells["borrower_DOB"].Value;
            }
        }
        private void dgvTickets_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvTickets.Rows[e.RowIndex];
                txtTicketID.Text = row.Cells["ticket_id"].Value.ToString();
                cbTicketBook.SelectedValue = row.Cells["book_id"].Value.ToString();
                cbTicketBorrower.SelectedValue = row.Cells["borrower_id"].Value.ToString();
                dtpTicketBorrowDate.Value = (DateTime)row.Cells["borrower_date"].Value;
                dtpTicketReturnDate.Value = (DateTime)row.Cells["return_date"].Value;
            }
        }
        private void btnBookUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Do you want to edit?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string update = "UPDATE Books SET book_name = @book_name, author_id = @author_id, category_id = @category_id, publisher_id = @publisher_id, publishing_date = @publishing_date WHERE book_id = @book_id";

                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(update, connection);

                    cmd.Parameters.Add("@book_id", SqlDbType.Int);
                    cmd.Parameters["@book_id"].Value = int.Parse(txtBookID.Text);

                    cmd.Parameters.Add("@book_name", SqlDbType.NVarChar);
                    cmd.Parameters["@book_name"].Value = txtBookName.Text;

                    cmd.Parameters.Add("@author_id", SqlDbType.Int);
                    cmd.Parameters["@author_id"].Value = int.Parse(cbBookAuthor.SelectedValue.ToString());

                    cmd.Parameters.Add("@category_id", SqlDbType.Int);
                    cmd.Parameters["@category_id"].Value = int.Parse(cbBookCategory.SelectedValue.ToString());

                    cmd.Parameters.Add("@publisher_id", SqlDbType.Int);
                    cmd.Parameters["@publisher_id"].Value = int.Parse(cbBookPublisher.SelectedValue.ToString());

                    cmd.Parameters.Add("@publishing_date", SqlDbType.DateTime);
                    cmd.Parameters["@publishing_date"].Value = dtpBookPublishingDate.Value;

                    int affectedRows = cmd.ExecuteNonQuery();
                    if (affectedRows > 0)
                    {
                        FillDataBooks();
                        ClearDataBooks();
                        MessageBox.Show(this, "Updated successfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(this, "Update failed. No rows affected.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, $"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        private void btnBookDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Do you want to delete?", "Question", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.OK)
            {
                connection.Open();
                string delete = "delete from Books where book_id =@book_id";
                SqlCommand cmd = new SqlCommand(delete, connection);
                cmd.Parameters.Add("@book_id", SqlDbType.Int);
                cmd.Parameters["@book_id"].Value = txtBookID.Text;
                cmd.ExecuteNonQuery();
                FillDataBooks();
                ClearDataBooks();
                MessageBox.Show(this, "Delete successfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.None);
                connection.Close();
            }
        }
        private void btnBorrowerAdd_Click(object sender, EventArgs e)
        {
            string borrowerName = txtBorrowerName.Text;
            string borrowerAddress = txtBorrowerAddress.Text;
            string borrowerPhone = txtBorrowerPhone.Text;
            string borrowerEmail = txtBorrowerEmail.Text;
            DateTime dob = dtpBorrowerDOB.Value;

            string insertQuery = "INSERT INTO Borrowers (borrower_name, borrower_address, borrower_phone, borrower_email, borrower_DOB) VALUES (@borrower_name, @borrower_address, @borrower_phone, @borrower_email, @borrower_DOB)";

            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(insertQuery, connection);
                cmd.Parameters.Add("@borrower_name", SqlDbType.NVarChar).Value = borrowerName;
                cmd.Parameters.Add("@borrower_address", SqlDbType.NVarChar).Value = borrowerAddress;
                cmd.Parameters.Add("@borrower_phone", SqlDbType.NVarChar).Value = borrowerPhone;
                cmd.Parameters.Add("@borrower_email", SqlDbType.NVarChar).Value = borrowerEmail;
                cmd.Parameters.Add("@borrower_DOB", SqlDbType.DateTime).Value = dob;

                cmd.ExecuteNonQuery();
                FillDataBorrowers();
                ClearDataBorrowers();
                MessageBox.Show(this, "Inserted successfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }
        private void btnBorrowerUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Do you want to edit?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string updateQuery = "UPDATE Borrowers SET borrower_name = @borrower_name, borrower_address = @borrower_address, borrower_phone = @borrower_phone, borrower_email = @borrower_email, borrower_DOB = @borrower_DOB WHERE borrower_id = @borrower_id";

                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(updateQuery, connection);

                    cmd.Parameters.Add("@borrower_id", SqlDbType.Int).Value = int.Parse(txtBorrowerID.Text);
                    cmd.Parameters.Add("@borrower_name", SqlDbType.NVarChar).Value = txtBorrowerName.Text;
                    cmd.Parameters.Add("@borrower_address", SqlDbType.NVarChar).Value = txtBorrowerAddress.Text;
                    cmd.Parameters.Add("@borrower_phone", SqlDbType.NVarChar).Value = txtBorrowerPhone.Text;
                    cmd.Parameters.Add("@borrower_email", SqlDbType.NVarChar).Value = txtBorrowerEmail.Text;
                    cmd.Parameters.Add("@borrower_DOB", SqlDbType.DateTime).Value = dtpBorrowerDOB.Value;

                    int affectedRows = cmd.ExecuteNonQuery();
                    if (affectedRows > 0)
                    {
                        FillDataBorrowers();
                        ClearDataBorrowers();
                        MessageBox.Show(this, "Updated successfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(this, "Update failed. No rows affected.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, $"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        private void btnBorrowerDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Do you want to delete?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string deleteQuery = "DELETE FROM Borrowers WHERE borrower_id = @borrower_id";

                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(deleteQuery, connection);
                    cmd.Parameters.Add("@borrower_id", SqlDbType.Int).Value = int.Parse(txtBorrowerID.Text);
                    cmd.ExecuteNonQuery();
                    FillDataBorrowers();
                    ClearDataBorrowers();
                    MessageBox.Show(this, "Deleted successfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, $"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        private void btnTicketAdd_Click(object sender, EventArgs e)
        {
            string bookID = cbTicketBook.SelectedValue.ToString();
            string borrowerID = cbTicketBorrower.SelectedValue.ToString();
            DateTime borrowDate = dtpTicketBorrowDate.Value;
            DateTime returnDate = dtpTicketReturnDate.Value;

            string insertQuery = "INSERT INTO Tickets (book_id, borrower_id, borrow_date, return_date) VALUES (@book_id, @borrower_id, @borrow_date, @return_date)";

            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(insertQuery, connection);
                cmd.Parameters.Add("@book_id", SqlDbType.Int).Value = int.Parse(bookID);
                cmd.Parameters.Add("@borrower_id", SqlDbType.Int).Value = int.Parse(borrowerID);
                cmd.Parameters.Add("@borrow_date", SqlDbType.DateTime).Value = borrowDate;
                cmd.Parameters.Add("@return_date", SqlDbType.DateTime).Value = returnDate;

                cmd.ExecuteNonQuery();
                FillDataTickets();
                ClearDataTickets();
                MessageBox.Show(this, "Inserted successfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, $"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }
        private void btnTicketDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Do you want to delete?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string deleteQuery = "DELETE FROM Tickets WHERE ticket_id = @ticket_id";

                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(deleteQuery, connection);
                    cmd.Parameters.Add("@ticket_id", SqlDbType.Int).Value = int.Parse(txtTicketID.Text);
                    cmd.ExecuteNonQuery();
                    FillDataTickets();
                    ClearDataTickets();
                    MessageBox.Show(this, "Deleted successfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, $"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        private void dtpBookPublishingDate_ValueChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnTicketUpdate_Click(object sender, EventArgs e)
        {
            {
                if (MessageBox.Show(this, "Do you want to edit?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string updateQuery = "UPDATE Tickets SET book_id = @book_id, borrower_id = @borrower_id, borrow_date = @borrow_date, return_date = @return_date WHERE ticket_id = @ticket_id";

                    try
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand(updateQuery, connection);

                        cmd.Parameters.Add("@ticket_id", SqlDbType.Int).Value = int.Parse(txtTicketID.Text);
                        cmd.Parameters.Add("@book_id", SqlDbType.Int).Value = int.Parse(cbTicketBook.SelectedValue.ToString());
                        cmd.Parameters.Add("@borrower_id", SqlDbType.Int).Value = int.Parse(cbTicketBorrower.SelectedValue.ToString());
                        cmd.Parameters.Add("@borrow_date", SqlDbType.DateTime).Value = dtpTicketBorrowDate.Value;
                        cmd.Parameters.Add("@return_date", SqlDbType.DateTime).Value = dtpTicketReturnDate.Value;

                        int affectedRows = cmd.ExecuteNonQuery();
                        if (affectedRows > 0)
                        {
                            FillDataTickets();
                            ClearDataTickets();
                            MessageBox.Show(this, "Updated successfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(this, "Update failed. No rows affected.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, $"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        private void dgvBooks_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
