using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Web;

namespace Framework.Core.File
{
    public static class FileManagement
    {
        public static string UploadExcelFile(HttpPostedFileBase file, string folder)
        {
            string excelPath = folder + Path.GetFileName(file.FileName);
            file.SaveAs(excelPath);

            string conString = string.Empty;
            string extension = Path.GetExtension(file.FileName).ToLower();

            conString = GetConnectionStringToExcel(extension, conString, excelPath);
            return string.Format(conString, excelPath);
        }

        private static string GenerateRandomFileName()
        {
            return Guid.NewGuid().ToString();
        }

        public static string SaveFile(HttpPostedFile postedFile, string folder, string logPath)
        {
            var randomName = GenerateRandomFileName();
            var extension = Path.GetExtension(postedFile.FileName).ToLower();
            string filePath = folder + randomName;
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            postedFile.SaveAs(filePath + extension);

            Log(logPath, $"Content Type: {postedFile.ContentType}, File Name: {postedFile.FileName}, Extension: {extension}");

            return randomName + extension;
        }

        private static string GetConnectionStringToExcel(string extension, string conString, string excelPath)
        {
            switch (extension)
            {
                case ".xls": //Excel 97-03
                    conString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + excelPath +
                                ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
                    break;
                case ".xlsx": //Excel 07 or higher
                    conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excelPath +
                                ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
                    break;
            }
            return conString;
        }

        public static DataTable ConvertExcelToDataAdapter(string conString)
        {
            try
            {

            DataTable dataTable = new DataTable();
            using (OleDbConnection excel_con = new OleDbConnection(conString))
            {
                excel_con.Open();
                string sheet1 = excel_con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null).Rows[0]["TABLE_NAME"].ToString();

                using (OleDbDataAdapter data = new OleDbDataAdapter("SELECT * FROM [" + sheet1 + "]", excel_con))
                {
                    data.Fill(dataTable);
                    excel_con.Close();
                    return dataTable;
                }
            }

            }
            catch (System.Exception exception)
            {
                throw exception;
            }

        }

        public static bool IsImageFile(string contentType)
        {
            if (!string.Equals(contentType, "image/jpg", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(contentType, "image/jpeg", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(contentType, "image/pjpeg", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(contentType, "image/gif", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(contentType, "image/x-png", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(contentType, "image/png", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(contentType, "image/*", StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }
            return true;
        }

        public static void Log(string path, string data)
        {
            using (StreamWriter sw = System.IO.File.AppendText(path))
            {
                sw.WriteLine("=========== Start Logging ");
                sw.WriteLine("Log Time: " + System.DateTime.Now);
                sw.WriteLine("Note: " + data);
                sw.WriteLine("=========== End ");

            }
        }

        public static bool FileIsValid(HttpPostedFile postedFile, string logPath)
        {
            if (!IsImageFile(postedFile.ContentType))
            {
                Log(logPath, "Upload file is not image");
            }

            return postedFile.ContentLength > 0;
        }

        public static void DownloadFile()
        {
            throw new NotImplementedException();
        }

        public static void BulkInsertFromExcel()
        {
            throw new NotImplementedException();
        }

        public static void InsertFromExcel()
        {
            throw new NotImplementedException();
        }

    }
}
