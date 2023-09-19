using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoRegexReal
{
    public partial class Form1 : Form
    {
        ModelUserName modelUserName = new ModelUserName();
        public Form1()
        {
            InitializeComponent();
        }


        private void txtFullName_TextChanged(object sender, EventArgs e)
        {
            string pattern = @"[0-9@#$%^~&`|'""{}\[\]\-\\_\\()!*+=?.,><:;//]";
            if (Regex.IsMatch(txtFullName.Text, pattern))
            {
                if (txtFullName.TextLength == 0)
                {
                    txtFullName.Text = "";
                }
                else
                {
                    txtFullName.Text = txtFullName.Text.Remove(txtFullName.TextLength - 1);
                    txtFullName.SelectionStart = txtFullName.Text.Length;
                }

            }
        }

        private void txtTenTK_TextChanged(object sender, EventArgs e)
        {
            string pattern = @"^[a-zA-Z0-9_-]{3,15}$";
            if (txtFullName.Text != "")
            {
                if (Regex.IsMatch(txtUserName.Text, pattern))
                {
                    lblLoiTK.Text = "Tài khoản hợp lệ";
                    lblLoiTK.ForeColor = Color.Green;
                    lblLoiTK.Visible = true;
                }
                else
                {
                    lblLoiTK.Text = "Tài khoản không hợp lệ";
                    lblLoiTK.ForeColor = Color.Red;
                    lblLoiTK.Visible = true;
                }
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            string pattern = @"^[_A-Za-z0-9-\\+]+(\\.[_A-Za-z0-9-]+)*@" + "[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$";
            if (txtEmail.Text != "")
            {
                if (Regex.IsMatch(txtEmail.Text, pattern))
                {
                    lblLoiEmail.Text = "Email hợp lệ";
                    lblLoiEmail.ForeColor = Color.Green;
                    lblLoiEmail.Visible = true;
                }
                else
                {
                    lblLoiEmail.Text = "Email không hợp lệ";
                    lblLoiEmail.ForeColor = Color.Red;
                    lblLoiEmail.Visible = true;
                }
            }
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {

            string pattern = @"(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%]).{6,20}";
            if (txtPass.Text != "")
            {

                if (!txtPass.Text.ToLower().Contains(txtUserName.Text))
                {
                    if ( Regex.IsMatch(txtPass.Text, pattern))
                    {

                        lblLoiMK.Text = "Mật khẩu hợp lệ";
                        lblLoiMK.ForeColor = Color.Green;
                        lblLoiMK.Visible = true;
                    }
                    else
                    {
                        lblLoiMK.Text = "Mật khẩu không hợp lệ ";
                        lblLoiMK.ForeColor = Color.Red;
                        lblLoiMK.Visible = true;
                    }
                }
                else
                {
                    lblLoiMK.Text = "Mật khẩu không được chứa tên tài khoản";
                    lblLoiMK.ForeColor = Color.Red;
                    lblLoiMK.Visible = true;
                }
                if (txtPassConfirm.Text != "")
                {
                    if (txtPass.Text != txtPassConfirm.Text)
                    {
                        lblLoiXacNhanMK.Text = "Mật khẩu không khớp";
                        lblLoiXacNhanMK.ForeColor = Color.Red;
                        lblLoiXacNhanMK.Visible = true;

                    }
                    else
                    {
                        lblLoiXacNhanMK.Text = "Hợp lệ";
                        lblLoiXacNhanMK.ForeColor = Color.Green;
                        lblLoiXacNhanMK.Visible = true;
                    }
                }
            }
        }

        private void txtPassConfirm_TextChanged(object sender, EventArgs e)
        {

            if (txtPass.Text != "")

            {
                if (txtPass.Text != txtPassConfirm.Text)
                {
                    lblLoiXacNhanMK.Text = "Mật khẩu không khớp";
                    lblLoiXacNhanMK.ForeColor = Color.Red;
                    lblLoiXacNhanMK.Visible = true;
                }
                else
                {
                    lblLoiXacNhanMK.Text = "Hợp lệ";
                    lblLoiXacNhanMK.ForeColor = Color.Green;
                    lblLoiXacNhanMK.Visible = true;
                }
            }
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            string pattern = @"((84|0)[3|5|7|8|9])+([0-9]{8})\b";
            if (Regex.IsMatch(txtSDT.Text, pattern))
            {
                lblSDT.Text = "SDT hợp lệ";
                lblSDT.ForeColor = Color.Green;
                lblSDT.Visible = true;
            }
            else
            {
                lblSDT.Text = "SDT không hợp lệ";
                lblSDT.ForeColor = Color.Red;
                lblSDT.Visible = true;
            }
        }

        // Mã hóa mật khẩu.
        private string ComputeMD5Hash(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        // Lư dữ liệu vào database
        private DataUser FieldInfo()
        {
            DataUser dataUser = new DataUser();

            dataUser.UserName = txtUserName.Text;
            dataUser.Email = txtEmail.Text;
            dataUser.FullName = txtFullName.Text;
            dataUser.Pasword = ComputeMD5Hash(txtPass.Text);
            dataUser.PhoneNumber = int.Parse(txtSDT.Text);

            return dataUser;
        }

        private void Insert(DataUser newUser)
        {

            modelUserName.DataUsers.Add(newUser);

            modelUserName.SaveChanges();

        }
        //sdsdsd 

        private void btnDangKi_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text != "" && txtSDT.Text != "" && txtPass.Text != "" &&
                txtUserName.Text != "" && txtPassConfirm.Text != "" && lblLoiEmail.ForeColor == Color.Green &&
                lblLoiMK.ForeColor == Color.Green && lblLoiTK.ForeColor == Color.Green &&
                lblLoiXacNhanMK.ForeColor == Color.Green && lblSDT.ForeColor == Color.Green)
            {
                // xu li luu vao co so du lieu

                DataUser newUser = modelUserName.DataUsers.FirstOrDefault(p => p.UserName.Contains(txtUserName.Text));

                if (newUser == null)
                {

                    DataUser dataUser = FieldInfo();
                    Insert(dataUser);

                    MessageBox.Show("Dang ki thanhh cong");
                }
                else
                {
                    MessageBox.Show("Da Co Ton Tai TK");
                }
            }
            else
            {
                MessageBox.Show("Đăng ký không thành công!");
            }
        }

        private void btnShowPass_MouseDown(object sender, MouseEventArgs e)
        {
            btnShowPass.BackgroundImage = DemoRegexReal.Properties.Resources.Eye;
            txtPass.PasswordChar = '\0';
        }

        private void btnShowPass_MouseUp(object sender, MouseEventArgs e)
        {
            btnShowPass.BackgroundImage = DemoRegexReal.Properties.Resources.Hide;
            txtPass.PasswordChar = '*';
        }


        private void btnShowPassConfirm_MouseDown(object sender, MouseEventArgs e)
        {
            btnShowPassConfirm.BackgroundImage = DemoRegexReal.Properties.Resources.Eye;
            txtPassConfirm.PasswordChar = '\0';
        }

        private void btnShowPassConfirm_MouseUp(object sender, MouseEventArgs e)
        {
            btnShowPassConfirm.BackgroundImage = DemoRegexReal.Properties.Resources.Hide;
            txtPassConfirm.PasswordChar = '*';
        }
    }
}
