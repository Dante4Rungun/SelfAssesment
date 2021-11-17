using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SelfAssessment
{
    class DbFunctions
    {
        public static string AvoidInjection(string myString)
        {
            myString = myString.Replace("--", "");
            myString = myString.Replace(";", "");
            myString = myString.Replace("DROP", "");
            myString = myString.Replace("SELECT", "");
            myString = myString.Replace("ALTER", "");
            myString = myString.Replace("drop", "");
            myString = myString.Replace("select", "");
            myString = myString.Replace("alter", "");
            myString = myString.Replace("`", "'");

            return myString;
        }

        public static bool checkMail(string Email)
        {
            string userMail = "";
            bool isMail = false;
            using (SqlCommand command = Program.con.CreateCommand())
            {
                command.CommandText = $"SELECT userMail FROM [User] WHERE userMail = '{Email}'";
                Program.con.Open();
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        userMail = reader.GetString(0);
                    }
                }
                Program.con.Close();
            }
            if (userMail != "" /*|| userMail != null*/)
            {
                isMail = true;
            }
            return isMail;

        }

        public static void Registration(string userMail, string QcID, string PIB)
        {
            Program.con.Open();
            SqlCommand command = Program.con.CreateCommand();
            command.CommandText = $"INSERT INTO [User]([userMail],[QcID],[PIB]) VALUES('{userMail}',{QcID},'{PIB}')";
            command.ExecuteNonQuery();
            Program.con.Close();
        }
        public static List<List<string>> LoadQuestions(SqlConnection conn, string Com)
        {
            using (SqlCommand command = conn.CreateCommand())
            {
                command.CommandText = Com;
                conn.Open();
                List<List<string>> questionAnswers = new List<List<string>> { new List<string> { }, new List<string>{ }, new List<string> { }, new List<string> { }, new List<string> { }, new List<string> { }, new List<string> { }, new List<string> { }, new List<string> { } };

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        questionAnswers[0].Add(Convert.ToString(reader.GetInt32(0)));
                        questionAnswers[1].Add(reader.GetString(1));
                        questionAnswers[2].Add(reader.GetString(2));
                        questionAnswers[3].Add(reader.GetString(3));
                        questionAnswers[4].Add(reader.GetString(4));
                        questionAnswers[5].Add(reader.GetString(5));
                        questionAnswers[6].Add(reader.GetString(6));
                        questionAnswers[7].Add(reader.GetString(7));
                        questionAnswers[8].Add(reader.GetString(8));
                    }
                }
                conn.Close();

                //CompareLists.CompareIdLists(array2,array);//array2 = file DB, array = text DB, при очистке от лишних файлов.
                return questionAnswers;
            }
        }

        public static List<List<int>> LoadCompetenseAnalitycList(SqlConnection conn, string userMail)
        {
            using (SqlCommand command = conn.CreateCommand())
            {
                List<List<int>> competenceAnalysisList = new List<List<int>> { new List<int> { }, new List<int> { }, new List<int> { }, new List<int> { }, new List<int> { }, new List<int> { }, new List<int> { }, new List<int> { }, new List<int> { }, new List<int> { }, new List<int> { }, new List<int> { }, new List<int> { }, new List<int> { }, new List<int> { } };
                command.CommandText = $"SELECT cmID,Answers.[Value] FROM AnswersHistory INNER JOIN[User] ON AnswersHistory.userMail = [User].userMail INNER JOIN Question ON Question.questionID = AnswersHistory.questionID INNER JOIN CompetenceList ON Question.questionID = CompetenceList.questionID INNER JOIN Answers ON  AnswersHistory.answerID = Answers.answerID WHERE[User].userMail = '{userMail}' ORDER BY cmID";
                conn.Open();
                int userID = 0;

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        competenceAnalysisList[reader.GetInt32(0) - 1].Add(reader.GetInt32(1));
                    }
                }
                conn.Close();
                //CompareLists.CompareIdLists(array2,array);//array2 = file DB, array = text DB, при очистке от лишних файлов.
                return competenceAnalysisList;
            }
        }

        public static int LoadCurrentQuestionNumber(SqlConnection conn, string userMail)
        {
            using (SqlCommand command = conn.CreateCommand())
            {
                command.CommandText = $"SELECT CurrrentQuestion FROM [User] WHERE userMail = '{userMail}'";
                conn.Open();                
                int userID = 0;

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        userID = reader.GetInt32(0);
                    }
                }
                conn.Close();
                //CompareLists.CompareIdLists(array2,array);//array2 = file DB, array = text DB, при очистке от лишних файлов.
                return userID;
            }
        }

        public static void loadAnswer(int AnswerID, string questinID, int counter)
        {
            Program.con.Open();
            SqlCommand command = Program.con.CreateCommand();
            command.CommandText = $"INSERT INTO [AnswersHistory]([userMail],[questionID],[answerID]) VALUES('{Program.UserMail}',{questinID},{AnswerID}); UPDATE [User] SET [CurrrentQuestion] = {counter} WHERE [userMail] = '{Program.UserMail}'";
            command.ExecuteNonQuery();
            Program.con.Close();
        }
    }
}
