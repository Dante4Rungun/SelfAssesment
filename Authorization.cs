using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace SelfAssessment
{
    public partial class Authorization : Form
    {
        
        public Authorization()
        {
            InitializeComponent();
        }
        private void Authorization_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(384, 422);
            this.MaximumSize = new Size(384, 422);
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if ((textBox1.Text == "") || (textBox2.Text == "") || (comboBox1.Text == ""))
            {
                MessageBox.Show("Будь ласка, заповніть всі дані.");
            }
            else
            {
                bool isMail = DbFunctions.checkMail(DbFunctions.AvoidInjection(DbFunctions.AvoidInjection((textBox1.Text).Trim())));
                Program.UserMail = DbFunctions.AvoidInjection((textBox1.Text).Trim());
                Program.CategoryID = comboBox1.SelectedIndex;
                Program.PIB = DbFunctions.AvoidInjection((textBox2.Text).Trim());
                Program.CategoryName = comboBox1.Text;

                if (isMail == true)
                {
                    Program.CurrentQuestion = DbFunctions.LoadCurrentQuestionNumber(Program.con, Program.UserMail);
                    Program.isMailRegistred = true;
                    Main frm = new Main();
                    frm.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("Користувач із зазначеними даними відсутній в списку учасників");
                }
            }

        }
    }
}
