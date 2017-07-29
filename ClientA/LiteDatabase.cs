using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Diagnostics;
using ClientA.Models;

namespace ClientA
{
    public static class LiteDatabase
    {
        const string _nameDB = "clientDB.sqlite";
        const string _connectString = "Data Source=" + _nameDB + ";Version=3;";
        const string _tableName = "MessageHistory";

        /// <summary>
        /// Check if sqlite Db File exisit
        /// </summary>
        /// <returns>True if exisit, False if not</returns>
        public static bool IsDbExisist()
        {
            return File.Exists(_nameDB) ? true : false;
        }

        /// <summary>
        /// Check if table exisit in Db file
        /// </summary>
        /// <returns>True if exisit, False if not exisit</returns>
        public static bool IsTableExisit()
        {
            using (SQLiteConnection con = new SQLiteConnection(_connectString))
            {
                bool isExisit = false;
                try
                { 
                    string qry = "SELECT count(*) FROM " + _tableName;
                    con.Open();
                    SQLiteCommand command = new SQLiteCommand(qry, con);
                    isExisit = (command.ExecuteScalar() != null);
                    con.Close();
                }catch(Exception e)
                {
                    Debug.WriteLine("Can't check if table exist " + e);
                }

                return isExisit;
            }
        }

        /// <summary>
        /// Create sqlite database file
        /// </summary>
        /// <returns>True if file created, False if not</returns>
        public static bool CreateDbFile()
        {
            bool isCreated = false;
            try
            { 
                SQLiteConnection.CreateFile(_nameDB);
                isCreated = true;
            }catch(Exception e)
            {
                Debug.WriteLine("Can't create DB file " + e);
            }
            return isCreated;
        }

        /// <summary>
        /// Create table in Db file
        /// </summary>
        /// <returns>True if created, False if not</returns>
        public static bool CreateTable()
        {
            bool isCreated;
            try
            {
                using (SQLiteConnection con = new SQLiteConnection(_connectString))
                {
                    string qry = "CREATE TABLE " + _tableName + "(MsgDate text, msg text)";
                    con.Open();
                    SQLiteCommand command = new SQLiteCommand(qry, con);
                    command.ExecuteNonQuery();
                    isCreated = true;
                    con.Close();
                }
            }catch(Exception e)
            {
                Debug.WriteLine("Can't create file or table " + e);
                isCreated = false;
            }

            return isCreated;
        }

        /// <summary>
        /// Insert message into sqlite Db
        /// </summary>
        /// <param name="msg">Text of message</param>
        /// <returns>True if inserted, False if not</returns>
        public static bool InsertMessage(string msg)
        {
            bool isInserted = false;
            try
            {
                string qry = "INSERT INTO " + _tableName + "(msg, MsgDate) VALUES(@msg, @MsgDate)";
                using (SQLiteConnection con = new SQLiteConnection(_connectString))
                {
                    con.Open();
                    SQLiteCommand command = new SQLiteCommand(qry, con);
                    command.Parameters.Add(new SQLiteParameter("@msg", msg));
                    command.Parameters.Add(new SQLiteParameter("@MsgDate", DateTime.Now.ToString()));
                    command.ExecuteNonQuery();
                    con.Close();
                    isInserted = true;
                }
            }catch(Exception e)
            {
                Debug.WriteLine("Can't insert into table " + e);
            }
            return isInserted;
        }

        /// <summary>
        /// Gets saved Messages in sqlite DB
        /// </summary>
        /// <returns>List of model saved Messages</returns>
        public static List<SavedMessagesModel> GetMessages()
        {
            List<SavedMessagesModel> msg = new List<SavedMessagesModel>();
            try
            {
                using (SQLiteConnection con = new SQLiteConnection(_connectString))
                {
                    string qry = "SELECT MsgDate, msg FROM " + _tableName;
                    con.Open();
                    SQLiteCommand command = new SQLiteCommand(qry, con);
                    SQLiteDataReader reader = command.ExecuteReader();
                    while(reader.Read())
                    {
                        string msgDateRow = reader.GetString(0);
                        string msgRow = reader.GetString(1);

                        msg.Add(new SavedMessagesModel()
                        {
                            date = msgDateRow,
                            message = msgRow
                        });
                    }
                }
            }
            catch(Exception e)
            {
                Debug.WriteLine("GetMessages error " + e);
            }
            return msg;
        }

        /// <summary>
        /// Check if Db and table exisit. If not it will try create Db file and table.
        /// </summary>
        /// <returns>True if exisit or Create Db, False if can't create Db file or table </returns>
        public static bool CkeckingDb()
        {
            if (!(IsDbExisist()) && !(CreateDbFile()))
                    return false;

            if (!(IsTableExisit()) && !(CreateTable()))
                    return false;

            return true;

        }

    }
}
