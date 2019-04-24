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
    public partial class MainForm : Form
    {
        private List<User> users;
      
        private DataContextUseServices dataContextUse = new DataContextUseServices();
        public MainForm()
        {
            InitializeComponent();
            users = dataContextUse.GetUsersList();
            
            List<string> usersName = new List<string>();
            foreach (var user in users)
            {
                usersName.Add(user.Login);
            }
            lstUsers.Items.AddRange(usersName.ToArray<object>());
            lstUsers.DoubleClick += LstUsers_DoubleClick;
        }

        private void LstUsers_DoubleClick(object sender, EventArgs e)
        {
            UpdateExistUser updateExist = new UpdateExistUser(this,users[lstUsers.SelectedIndex],dataContextUse);
            updateExist.Show();
            this.Hide();
        }

        private void CreateNewUser(object sender, EventArgs e)
        {
            CreateNewUserForm newUserForm = new CreateNewUserForm(this);
            newUserForm.Show();
            this.Hide();
        }

        private void DeleteUser(object sender, EventArgs e)
        {
            dataContextUse.DeleteUser(users[lstUsers.SelectedIndex]);
            MessageBox.Show("User has been deleted");
        }

        private void ShowOnlyAdmin(object sender, EventArgs e)
        {
            if(chckAdmin.Checked == true)
            {
                lstUsers.Items.Clear();
                users.Clear();
                users = dataContextUse.GetAdminUsers();
                List<string> usersName = new List<string>();
                foreach (var user in users)
                {
                    usersName.Add(user.Login);
                }
                lstUsers.Items.AddRange(usersName.ToArray<object>());
            }
            else
            {
                lstUsers.Items.Clear();
                users.Clear();
                users = dataContextUse.GetUsersList();
                List<string> usersName = new List<string>();
                foreach (var user in users)
                {
                    usersName.Add(user.Login);
                }
                lstUsers.Items.AddRange(usersName.ToArray<object>());

            }
        }

        private void RefreshMethod(object sender, EventArgs e)
        {
            lstUsers.Items.Clear();
            users.Clear();
            users = dataContextUse.GetUsersList();
            List<string> usersName = new List<string>();
            foreach (var user in users)
            {
                usersName.Add(user.Login);
            }
            lstUsers.Items.AddRange(usersName.ToArray<object>());
        }
    }
}
