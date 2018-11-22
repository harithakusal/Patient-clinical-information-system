using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Patient_clinical_information_system
{
    class ErrorLog
    {
        public static void SaveError(string e)
        {
            string FilePath = "ErrorLog.txt";

            try
            {
                FileStream f1 = new FileStream(FilePath, FileMode.Append);
                f1.Close();

                FileStream f2 = new FileStream(FilePath, FileMode.Append);
                byte[] errors = Encoding.Default.GetBytes((DateTime.Now + e).ToString());
                f2.Write(errors, 0, errors.Length);
                f2.Close();
                Console.WriteLine("Error sent to Log file");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
