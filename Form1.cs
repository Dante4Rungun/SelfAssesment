using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SelfAssessment
{
    public partial class Main : Form
    {
        static int counter = Program.CurrentQuestion;
        List<List<string>> questionAnswers = DbFunctions.LoadQuestions(Program.con, "SELECT q.*,qp.Category,qp.Competence FROM Question q INNER JOIN[QuestionParams] qp ON qp.questionID = q.questionID");
        static List<List<int>> competenceAnalysisList = new List<List<int>> { new List<int> { }, new List<int> { }, new List<int> { }, new List<int> { }, new List<int> { }, new List<int> { }, new List<int> { }, new List<int> { }, new List<int> { }, new List<int> { }, new List<int> { }, new List<int> { }, new List<int> { }, new List<int> { }, new List<int> { } };
        static List<List<string>> answersHistory = new List<List<string>> { new List<string> { }, new List<string> { } };
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(538, 493);
            this.MaximumSize = new Size(538, 493);
            saveFileDialog1.Filter = $"Excel files(*.xls)|.xls";
            saveFileDialog1.FileName = $"АС {Program.CategoryName} { Program.PIB}";
            if (Program.isMailRegistred == true)
            {
                competenceAnalysisList = DbFunctions.LoadCompetenseAnalitycList(Program.con, Program.UserMail);
            }
            try
            {
                label2.Text = $"{counter+1}";
                label1.Text = questionAnswers[1][counter];
                radioButton1.Text = questionAnswers[2][counter];
                radioButton2.Text = questionAnswers[3][counter];
                radioButton3.Text = questionAnswers[4][counter];
                radioButton4.Text = questionAnswers[5][counter];
                radioButton5.Text = questionAnswers[6][counter];
                unCheked();
            }
            catch { 
                MessageBox.Show("Ви вже відповіли на всі запитання. \n Повторне проходження тесту не є можливим.");
                Program.competenceResults = CompetenceResults(competenceAnalysisList);
                CircleDiagram cd = new CircleDiagram();
                cd.Show();
                this.Close();
            }

        }

        private List<int> Answer()
        {
            List<int> answer = new List<int> { };
            if (radioButton1.Checked)
            {
                answer.Add(100);
                answer.Add(1);
            }
            else if (radioButton2.Checked)
            {
                answer.Add(75);
                answer.Add(2);
            }
            else if (radioButton3.Checked)
            {
                answer.Add(50);
                answer.Add(3);
            }
            else if (radioButton4.Checked)
            {
                answer.Add(25);
                answer.Add(4);
            }
            else if (radioButton5.Checked)
            {
                answer.Add(0);
                answer.Add(5);
            }
            return answer;
        }

        private bool rbIsChecked()
        {
            bool isChecked = false;

            if (radioButton1.Checked)
            {
                isChecked = true;
            }
            else if (radioButton2.Checked)
            {
                isChecked = true;
            }
            else if (radioButton3.Checked)
            {
                isChecked = true;
            }
            else if (radioButton4.Checked)
            {
                isChecked = true;
            }
            else if (radioButton5.Checked)
            {
                isChecked = true;
            }

            return isChecked;
        }

        private void unCheked()
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
        }

        private static List<int> CompetenceResults(List<List<int>> AnalysisList)
        {
            List<int> avgList = new List<int> { }; 
            int sum;
            for (int i = 0; i < AnalysisList.Count; i++)
            {
                sum = 0;
                for (int j = 0; j < AnalysisList[i].Count; j ++)
                {
                    sum += AnalysisList[i][j];
                }
                avgList.Add(sum/ AnalysisList[i].Count);
            }
            return avgList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (rbIsChecked() == true)
            {
                DbFunctions.loadAnswer(Answer()[1], questionAnswers[0][counter], counter + 1);
                answersHistory[0].Add(questionAnswers[1][counter]);
                answersHistory[1].Add(questionAnswers[Answer()[1] + 1][counter]);

                for (int j = 0; j < questionAnswers[8][counter].Split(',').Length; j++)
                {
                    competenceAnalysisList[Convert.ToInt32(questionAnswers[8][counter].Split(',')[j]) - 1].Add(Answer()[0]);
                }
                //DbFunctions.print(categoryAnalysisList[0]);
                //DbFunctions.print(categoryAnalysisList[1]);

                counter += 1;
                if (counter != 100)
                {
                    unCheked();
                    label2.Text = $"{counter + 1}";
                    label1.Text = questionAnswers[1][counter];
                    radioButton1.Text = questionAnswers[2][counter];
                    radioButton2.Text = questionAnswers[3][counter];
                    radioButton3.Text = questionAnswers[4][counter];
                    radioButton4.Text = questionAnswers[5][counter];
                    radioButton5.Text = questionAnswers[6][counter];
                }
                else
                {
                    Program.competenceResults = CompetenceResults(competenceAnalysisList);
                    if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                        return;
                    string filename = Path.GetDirectoryName(saveFileDialog1.FileName);
                    filename = filename + "\\" + Path.GetFileName(saveFileDialog1.FileName);
                    LDBANS.ExcelSave(filename);

                    Form sndm = new CircleDiagram();
                    sndm.Show();
                    Hide();
                    //MessageBox висновка по категорії і перехід до діаграми.
                }
            }
            else { MessageBox.Show("Оберіть одну із запропонованих відповідей"); }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Program.CurrentQuestion < 100)
            {
                Application.Exit();
            } 
        }
    }
}
