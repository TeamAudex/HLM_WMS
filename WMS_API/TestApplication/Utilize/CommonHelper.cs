using Librarys.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;

public class CommonHelper
{
    public void InternalFileUpload(MultipartFormDataStreamProvider mfdr, string storagePath, ref int i, ref Dictionary<int, string> strFiles)
    {
        i = 0;

        foreach (var file in mfdr.FileData)
        {
            string fileName = file.Headers.ContentDisposition.FileName;

            if (fileName.StartsWith("\"") && fileName.EndsWith("\""))
            {
                fileName = fileName.Trim('"');
            }
            if (fileName.Contains(@"/") || fileName.Contains(@"\"))
            {
                fileName = Path.GetFileName(fileName);
            }
            fileName = string.Format("{0}{1}{2}", Guid.NewGuid().ToString(), "-", fileName);
            try
            {
                File.Move(file.LocalFileName, Path.Combine(storagePath, fileName));
                strFiles.Add(Convert.ToInt16(file.Headers.ContentDisposition.Name.Replace("file", "").Replace("\"", "").Trim()), new FileInfo(fileName).Name);
                i += 1;
            }
            catch (Exception ex)
            {
                Logger.For(this).Error(ex);
            }
        }
    }
    public DataTable ReadExcel(string storagePath,string filePath)
    {

        DataTable dtExcelRecords = new DataTable();
        string connectionString = string.Empty;

        OleDbConnection con = new OleDbConnection();
        try
        {
            string fileLocation = storagePath + "\\" + filePath;
            string path = fileLocation;
            //string connStr = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=HTML Import";

            connectionString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + path + "; Extended Properties=Excel 12.0;";

            //connectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + path + "; Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1\"";

            //Create OleDB Connection and OleDb Command
            //OleDbConnection DBConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source='" + strfileName + "';" + "Extended Properties=\"Excel 8.0;HDR=Yes\"");

            con.ConnectionString = connectionString;
            con.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = con;
            OleDbDataAdapter dAdapter = new OleDbDataAdapter(cmd);
            //con.Open();
            DataTable dtExcelSheetName = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            string getExcelSheetName = dtExcelSheetName.Rows[0]["Table_Name"].ToString();
            cmd.CommandText = "SELECT * FROM [" + getExcelSheetName + "]";
            dAdapter.SelectCommand = cmd;
            dAdapter.Fill(dtExcelRecords);
            con.Close();

        }
        catch (OleDbException ex)
        {

        }
        catch (Exception ex)
        {
            Librarys.Logging.Logger.For(this).Error(ex);
        }
        finally
        {
            con.Close();
        }

        return dtExcelRecords;
    }

}