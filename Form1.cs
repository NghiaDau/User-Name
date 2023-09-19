using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoRegexReal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string pattern = @"[0-9@#$%^~&`|'""{}\[\]\-\\_\\()!*+=?.,><:;//]";
            if (Regex.IsMatch(txtHoTen.Text, pattern))
            {
                if (txtHoTen.TextLength == 0)
                {
                    txtHoTen.Text = "";
                }
                else
                {
                    txtHoTen.Text = txtHoTen.Text.Remove(txtHoTen.TextLength - 1);
                    txtHoTen.SelectionStart = txtHoTen.Text.Length;
                }

            }
        }
        private void txtTenTK_TextChanged(object sender, EventArgs e)
        {
            string pattern = @"^[a-zA-Z0-9_-]{3,15}$";
            if (txtTenTK.Text != null)
            {
                if (Regex.IsMatch(txtTenTK.Text, pattern))
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
            if (txtEmail.Text != null)
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
            if (txtPass.Text != null)
            {
                if (Regex.IsMatch(txtPass.Text, pattern))
                {
                    lblLoiMK.Text = "Mật khẩu hợp lệ";
                    lblLoiMK.ForeColor = Color.Green;
                    lblLoiMK.Visible = true;
                }
                else
                {
                    lblLoiMK.Text = "Mật khẩu không hợp lệ";
                    lblLoiMK.ForeColor = Color.Red;
                    lblLoiMK.Visible = true;
                }
                if (txtPassConfirm.Text != null)
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
            if (txtPass.Text != null) 
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

        private void btnDangKi_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text != "" && txtSDT.Text != "" && txtPass.Text != "" &&
                txtTenTK.Text != "" && txtPassConfirm.Text != "" && lblLoiEmail.ForeColor == Color.Green &&
                lblLoiMK.ForeColor == Color.Green && lblLoiTK.ForeColor == Color.Green &&
                lblLoiXacNhanMK.ForeColor == Color.Green && lblSDT.ForeColor == Color.Green)
            {
                // xu li luu vao co so du lieu
                MessageBox.Show("Dang ki thanhh cong");
            }
            else
            {
                MessageBox.Show("Dang ki khong thanh cong");
            }
        }

       
    }
}
