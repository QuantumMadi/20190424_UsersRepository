using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UsersRepository.DataAccess;
using UsersRepostory.Models;

namespace UsersRepo.UI
{
    public partial class UpdateExistUser : Form
    {
        private Form _form;
        private DataContextUseServices dataContext;
        private Guid UserGuid;
        public UpdateExistUser(Form form, User updatingUser, DataContextUseServices dataContextUseServices)
        {
            InitializeComponent();
            txtLogin.ReadOnly = true;
            dataContext = dataContextUseServices;
            _form = form;
            UserGuid = updatingUser.Id;
            txtLogin.Text = updatingUser.Login;
            txtPassword.Text = updatingUser.HashPassword.ToString();
            txtAddress.Text = updatingUser.Address;
            txtPhone.Text = updatingUser.Phone;
            chckAdmin.Checked = updatingUser.Admin;
        }

        private void SubmitChanges(object sender, EventArgs e)
        {
            dataContext.UpdateUser(new User
            {
                Id = UserGuid,
                Login = txtLogin.Text,
                HashPassword = txtPassword.Text.GetHashCode(),
                Address = txtAddress.Text,
                Phone = txtPhone.Text,
                Admin = chckAdmin.Checked
            });
            MessageBox.Show("Changes Admited");
            _form.Show();
            this.Close();
        }
    }
}
