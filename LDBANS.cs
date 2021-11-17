using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using ExcelLibrary.SpreadSheet;
using System.IO;

namespace SelfAssessment
{
    class LDBANS
    {

        private static string SelectQuery()
        {
            return $"SELECT [User].PIB,Question.[Description],Answers.answerID  FROM AnswersHistory INNER JOIN Answers ON Answers.answerID = AnswersHistory.answerID INNER JOIN [User] ON [User].userMail = AnswersHistory.userMail INNER JOIN Question ON Question.questionID = AnswersHistory.questionID WHERE [User].userMail Like '{Program.UserMail}%' ORDER BY Question.questionID ";
        }

        private static string SelectTextAnswers()
        {
            return "SELECT [Answer1],[Answer2],[Answer3],[Answer4],[Answer5] FROM Question";
        }

        public static List<List<string>> LoadQuestions(SqlConnection con, string Com)
        {
            using (SqlCommand command = con.CreateCommand())
            {
                command.CommandText = Com;
                con.Open();
                List<List<string>> questionAnswers = new List<List<string>> { new List<string> { }, new List<string> { }, new List<string> { } };

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        questionAnswers[0].Add(reader.GetString(0));
                        questionAnswers[1].Add(reader.GetString(1));
                        questionAnswers[2].Add(Convert.ToString(reader.GetInt32(2)));
                    }
                }
                con.Close();

                //CompareLists.CompareIdLists(array2,array);//array2 = file DB, array = text DB, при очистке от лишних файлов.
                return questionAnswers;
            }
        }

        public static List<List<string>> LoadTextAnswers(SqlConnection con, string Com)
        {
            using (SqlCommand command = con.CreateCommand())
            {
                command.CommandText = Com;
                con.Open();
                List<List<string>> questionAnswers = new List<List<string>> { new List<string> { }, new List<string> { }, new List<string> { }, new List<string> { }, new List<string> { } };

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        questionAnswers[0].Add(reader.GetString(0));
                        questionAnswers[1].Add(reader.GetString(1));
                        questionAnswers[2].Add(reader.GetString(2));
                        questionAnswers[3].Add(reader.GetString(3));
                        questionAnswers[4].Add(reader.GetString(4));
                    }
                }
                con.Close();

                //CompareLists.CompareIdLists(array2,array);//array2 = file DB, array = text DB, при очистке от лишних файлов.
                return questionAnswers;
            }
        }

        public static void ExcelFileCreate2(List<List<string>> answersHistory, string savePath)
        {
            //создание файла
            Workbook workbook = new Workbook();
            Worksheet worksheet = new Worksheet("Первый Лист");

            for (int i = 0; i < answersHistory[0].Count; i++)
            {
                worksheet.Cells[i, 0] = new Cell(answersHistory[0][i]);
                worksheet.Cells[i, 1] = new Cell(answersHistory[1][i]);
                worksheet.Cells[i, 2] = new Cell(answersHistory[2][i]);
            }

            workbook.Worksheets.Add(worksheet);
            workbook.Save(savePath);
            //чтение файла

        }

        public static List<List<string>> createReport(List<List<string>> numAnswers, List<List<string>> textAnswers)
        {
            for (int i = 0; i < numAnswers[0].Count; i++)
            {
                //MessageBox.Show(" cols: " + Convert.ToString(textAnswers.Count) + "rows: " + Convert.ToString(textAnswers[0].Count));
                numAnswers[2][i] = textAnswers[Convert.ToInt32(numAnswers[2][i]) - 1][i];
            }
            //printMass(numAnswers);

            return numAnswers;
        }

        public static void ExcelSave(string filename)
        {
            List<List<string>> questionAnswers;
            List<List<string>> numAnswers = LoadQuestions(Program.con, SelectQuery());
            questionAnswers = createReport(numAnswers, LoadTextAnswers(Program.con, SelectTextAnswers()));
            try
            {
                ExcelMethods.ExcelFileCreate3(questionAnswers, filename);
                ExcelMethods.ExcelFileCreate3(questionAnswers, $@"{Environment.CurrentDirectory}/{Program.CategoryName} { Program.PIB}");
            }
            catch
            {
                ExcelMethods.ExcelFileCreate2(questionAnswers, filename);
                ExcelMethods.ExcelFileCreate2(questionAnswers, $@"{Environment.CurrentDirectory}/{Program.CategoryName} { Program.PIB}");
            }
        }
    }
}
