using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HTMLEmailAutomation.MailStoreManager
{
    class SqlDBStore : IMailStoreManager
    {
        private string _connectionString = string.Empty;
        public SqlDBStore(string conString)
        {
            _connectionString = conString;
        }

        string IMailStoreManager.FetchMailBody()
        {
            return QuerySingleColumnData("SELECT top 1 detail FROM MailBody");
        }

        string IMailStoreManager.FetchMailBodyTitle()
        {
            //To Do:SELECT top 1 title FROM MailBody WHERE scheduledDate = CAST(GETDATE() AS date)
            return QuerySingleColumnData("SELECT top 1 title FROM MailBody");
        }

        string IMailStoreManager.FetchMailFooter()
        {
            return QuerySingleColumnData("SELECT top 1 footer FROM Footer");
        }

        string IMailStoreManager.FetchMailFooter(DateTime date)
        {
            throw new NotImplementedException();
        }

        string IMailStoreManager.FetchMailHeader()
        {
            return QuerySingleColumnData("SELECT top 1 header FROM Header");
        }

        string IMailStoreManager.FetchMailHeader(DateTime date)
        {
            throw new NotImplementedException();
        }

        Dictionary<string, string> IMailStoreManager.FetchMailingList()
        {         
            return QueryMailingList("SELECT mailId,mailerType FROM MailerList");            
        }

        private Dictionary<string,string> QueryMailingList(string query)
        {
            Dictionary<string, string> mailingList = new Dictionary<string, string>();   
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = _connectionString;
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                mailingList.Add(reader[0].ToString(), reader[1].ToString());

                            }
                        }
                    }
                    conn.Close();
                    conn.Dispose();
                    return mailingList;
                }
                catch(Exception ex)
                {
                    throw new Exception("There might be some issue with Sql connection or query has encountered some error. Please have a detailed look :"+ex.Message);
                }
            }            
        }

        private string QuerySingleColumnData(string query)
        {
            string result = string.Empty;
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = _connectionString;
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                result = dataReader[0].ToString();
                            }
                        }
                    }
                    conn.Close();
                    conn.Dispose();
                }
                catch (Exception ex)
                {

                    throw new Exception("There might be some issue with Sql connection or query has encountered some error. Please have detailed Info below: "+ex.Message);
                }
            }
            return result;
        }
    }
}
