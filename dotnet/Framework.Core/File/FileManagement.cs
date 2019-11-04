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
