using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SelfAssessment
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Authorization());
        }
        public static SqlConnection con = new SqlConnection($@"Data Source=176.102.49.109,54322;Initial Catalog=Sertification;User ID=CertificateSubject;Password={СheckMethods.P12234ar()}");
        public static string UserMail;
        public static string PIB;
        public static string CategoryName;
        public static int CategoryID;
        public static int CurrentQuestion = 0;
        public static bool isMailRegistred;
        public static List<int> competenceResults;
        public static bool exit;
        
    }
}
