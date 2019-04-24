using System;
using System.Windows.Forms;
using UsersRepository.DataAccess;
using UsersRepostory.Models;

namespace UsersRepo.UI
{
    public partial class CreateNewUserForm : Form
    {
        private DataContextUseServices contextUseServices = new DataContextUseServices();
        private Form _form;
        public CreateNewUserForm(Form form)
        {
            InitializeComponent();
            _form = form;
        }

        private void CreateUser(object sender, EventArgs e)
        {
            User user = new User
            {
                Login = txtLogin.Text,
                HashPassword = txtPassword.Text.GetHashCode(),
                Address = txtAddress.Text,
                Phone = txtPhone.Text,
                Admin = chckAdmin.Checked,
            };
            if (!contextUseServices.AddUser(user))
            {
                MessageBox.Show("User with such login already registered, please insert another login");
            }
            else
            {
                MessageBox.Show("The user has been added");
                _form.Show();
                this.Close();
            }
        }


    }
}
