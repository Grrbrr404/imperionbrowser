using System;
using System.Collections.Generic;
using System.Text;
using FirebirdSql.Data.FirebirdClient;
using System.Collections;

namespace ImperionBrowser
{
    class Firebird: IDisposable
    {
        private FbConnection _fbConnection;

        public Firebird()
        {
            _fbConnection = new FbConnection("ServerType=1;User=SYSDBA;Password=masterkey;Dialect=3;Database=data/database.fdb");
        }

        public void Open()
        {
            _fbConnection.Open();
        }

        public void Close()
        {
            _fbConnection.Close();
        }

        public int executeSql(string iSql)
        {
            int result = -1;
            using (FbCommand cmd = new FbCommand(iSql,_fbConnection))
            {
                Open();
                result = cmd.ExecuteNonQuery();
                Close();
            }
            return result;
        }

        #region IDisposable Member
        public void Dispose()
        {
            _fbConnection.Close();
            _fbConnection.Dispose();
        }

        public static void CreateDatabaseStructure()
        {

            FbConnection.CreateDatabase("ServerType=1;User=SYSDBA;Password=masterkey;Dialect=3;Database=data/database.fdb");

            using (Firebird fb = new Firebird())
            {
                fb.executeSql(@"CREATE TABLE FLIGHTTIMECACHE(
                                    ID VARCHAR(38) NOT NULL,
                                    SOURCESYSTEMID VARCHAR(50),
                                    DESTSYSTEMID VARCHAR(50),
                                    SHIPTYPE INTEGER,
                                    FLIGHTTIME VARCHAR(20),
                                    PRIMARY KEY (ID));");
            }
        }
        #endregion

        public FbDataReader ExecuteQuery(string sql)
        {
            FbDataReader reader;
            FbCommand cmd = new FbCommand(sql, _fbConnection);
            {
                Open();
                reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            }
            return reader;
        }
    }
}
