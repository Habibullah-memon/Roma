using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace Roma
{
    public partial class ForgetPassword : Form
    {
        string verificationCode; bool iscodesent = false; public static string u_name;
        public static string to;
        public ForgetPassword()
        {
            InitializeComponent();
            textBoxUserName.Text = Login1.u_name;
            textBoxEmailUserName.Focus();
        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void ButtonSendEmailSubmit_Click(object sender, EventArgs e)
        {
            // MessageBox.Show(iscodesent.ToString());
            if (iscodesent == false)  // this is used wheather verification code is already sent or not.??  if send then this button will submit the code only
            {
                SqlDataAdapter Adp = new SqlDataAdapter("Select * from Users  where Username = '" + textBoxUserName.Text + "' and Email = '" + textBoxEmailUserName.Text + "'", Classes.DB.sql_con);
                DataTable dt = new DataTable(); Adp.Fill(dt);

                if (dt.Rows.Count > 0)  // IF UserName and Email is Correct .....
                {
                    Classes.DB.sql_con.Close();
                    string from, pass, messageBody;
                    Random rand = new Random();
                    verificationCode = (rand.Next(999999)).ToString();
                    MailMessage message = new MailMessage();
                    to = (textBoxEmailUserName.Text).ToString();
                    from = "habib.memon.adv@gmail.com";
                    pass = "OxfordGmail*2021";
                    messageBody = "your reset code is " + verificationCode;
                    message.To.Add(to);
                    message.From = new MailAddress(from);
                    message.Body = messageBody;
                    message.Subject = "password reseting code";
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                    smtp.EnableSsl = true;
                    smtp.Port = 587;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Credentials = new NetworkCredential(from, pass);
                    try
                    {
                        smtp.Send(message);
                        MessageBox.Show("Code Successful Sent, Check your Inbox & Type Veritication Code");
                        iscodesent = true;  // this will make sure, that the code sent and Now Disable the User/Pass and visible the Verification Code Field.

                        buttonSendEmailSubmit.Text = "Submit";
                        textBoxEmailUserName.Enabled = false;
                        u_name = textBoxUserName.Text; // THE Conformpassword need the username , against which the new password may be reset.
                        textBoxUserName.Enabled = false;
                        textBoxVerificationCode.Visible = true;
                        labelVerificationCode.Visible = true;
                        textBoxVerificationCode.Focus();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else // IF UserName O.R Email is W.R.O.N.G .....
                {
                    SqlDataAdapter Adp1 = new SqlDataAdapter("Select * from Users  where Username = '" + textBoxUserName.Text + "' ", Classes.DB.sql_con);
                    DataTable dt1 = new DataTable(); Adp1.Fill(dt1);
                    if (dt1.Rows.Count > 0) // IF UserName is O.K. and Email is W.R.O.N.G......
                    {
                        Classes.DB.sql_con.Close();
                        MessageBox.Show("Please Type Registered Email Address");
                        textBoxEmailUserName.Focus();
                    }
                    else  // Email  is O.K.and UserName is W.R.O.N.G......
                    {
                        MessageBox.Show("Username does not Exist");
                    }
                }
            }
            else // This Button Now will Verify the Code , if verifiyed then Go to the ChangePassword Foorm
            {
                if (textBoxVerificationCode.Text == verificationCode)
                {
                    ChangePassword cp = new ChangePassword();
                    cp.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid Code...");

                }
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
