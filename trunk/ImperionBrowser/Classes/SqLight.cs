using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;

namespace ImperionBrowser
{
    public class SqLight: IDisposable
    {
        private SQLiteConnection _Conn;

        public SqLight()
        {
            SQLiteConnectionStringBuilder csb = new SQLiteConnectionStringBuilder();
            csb.DataSource = @"Data\database";
            csb.Password = "imperion";
            _Conn = new SQLiteConnection(csb.ToString());
        }

        public void Open()
        {
            _Conn.Open();
        }

        public void Close()
        {
            _Conn.Close();
        }

        /// <summary>
        /// Use this for one single sql, fore more than one better use ExecutePreparedSql
        /// </summary>
        /// <param name="iSql"></param>
        public void ExecuteSql(string iSql)
        {
            if (_Conn.State != System.Data.ConnectionState.Open)
                Open();

            using (SQLiteCommand cmd = new SQLiteCommand(iSql, _Conn))
            {
                cmd.ExecuteNonQuery();    
            }
        }

        public void ExecutePreparedSql(string iPreparedSql, params SQLiteParameter[] iSQLiteParams)
        {
            using (SQLiteTransaction mytransaction = _Conn.BeginTransaction())
            {
                using (SQLiteCommand mycommand = new SQLiteCommand(_Conn))
                {
                    SQLiteParameter myparam = new SQLiteParameter();

                    mycommand.CommandText = iPreparedSql;
                    mycommand.Parameters.Add(myparam);

                    /*for (n = 0; n < 100000; n++)
                    {
                        myparam.Value = n + 1;
                        mycommand.ExecuteNonQuery();
                    }*/
                }
                mytransaction.Commit();
            } 
        }

        #region IDisposable Member

        public void Dispose()
        {
            Close();
        }

        #endregion

        public SQLiteDataReader ExecuteQuery(string sql)
        {
            SQLiteDataReader reader;

            if (_Conn.State != System.Data.ConnectionState.Open)
                Open();

            SQLiteCommand cmd = new SQLiteCommand(sql, _Conn);
            reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            return reader;
        }
    }
}
