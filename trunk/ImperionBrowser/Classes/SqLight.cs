using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace ImperionBrowser
{
    public class SqLight: IDisposable
    {
        private SQLiteConnection _Conn;

        public SqLight()
        {
            SQLiteConnectionStringBuilder csb = new SQLiteConnectionStringBuilder();
            csb.DataSource = @"Data\database";
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
        /// Use this for one single sql, fore more than one better use prepared sql statements
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

        public SQLiteTransaction BeginTransaction()
        {
            if (_Conn.State != System.Data.ConnectionState.Open)
                _Conn.Open();

            return _Conn.BeginTransaction();
        }

        public SQLiteCommand NewCommand()
        {
            return _Conn.CreateCommand();
        }

        public SQLiteDataReader ExecuteQuery(string sql)
        {
            SQLiteDataReader reader;

            if (_Conn.State != System.Data.ConnectionState.Open)
                Open();

            SQLiteCommand cmd = new SQLiteCommand(sql, _Conn);

            return reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        }

        public string SqlGetStrValue(string iSql)
        {
            SQLiteDataReader reader = ExecuteQuery(iSql);
            reader.Read();
            
            string result = reader.GetValue(0).ToString();
            
            reader.Close();
            reader.Dispose();

            return result;
        }

        public int SqlGetIntValue(string iSql)
        {
            return int.Parse(SqlGetStrValue(iSql));
        }

        public void Dispose()
        {
            Close();
        }

        /// <summary>
        /// Checks the database structure and will alter it if something is missing
        /// </summary>
        public static void CheckDatabaseStructure()
        {
            if (!File.Exists("Data/database"))
                SQLiteConnection.CreateFile("Data/database");

            SqLight sqlight = new SqLight();
            string sql = String.Empty;
            StringBuilder sb = new StringBuilder("Datenbank wurde erfolgreich überprüft\r\n");

            #region Table FlightTime
            if (!sqlight.TableExist("FlightTimeCache"))
            {
                sql = @"CREATE TABLE [FlightTimeCache] (
                        [ID] guid NOT NULL,
                        [SourceSystemId] varchar(50),
                        [DestSystemId] varchar(50),
                        [ShipType] integer,
                        [FlightTime] varchar(20) NOT NULL);";

                sqlight.ExecuteSql(sql);
                sb.AppendLine("- Tabelle FlightTimeCache wurde erzeugt");
            }
            else
            {
                sb.AppendLine("- Tabelle FlightTimeCache OK");
            }
            #endregion

            #region Table PlanetGrowing

            if (!sqlight.TableExist("PlanetGrowing"))
            {
                sql = @"CREATE TABLE [PlanetGrowing] (
                        [ID] guid NOT NULL,
                        [PlanetId] varchar(50),
                        [PlanetPoints] integer,
                        [PlanetName] varchar(50),
                        [PlanetType] varchar(20),
                        [OwnerId] varchar(20),
                        [OwnerName] varchar(50),
                        [OwnerAllianceName] varchar(50),
                        [FlightTime] varchar(20),
                        [ScanDate] DateTime);";

                sqlight.ExecuteSql(sql);
                sb.AppendLine("- Tabelle PlanetGrowing wurde erzeugt");
            }
            else
            {
                sb.AppendLine("- Tabelle PlanetGrowing OK");
            }
            #endregion

            MessageBox.Show(sb.ToString(),"Datenbank erzeugen / prüfen");
        }

        private bool TableExist(string iTableName)
        {
 	        SQLiteDataReader reader = ExecuteQuery("SELECT name FROM sqlite_master WHERE name='" + iTableName + "'");
            return reader.HasRows;
        }
    }
}
