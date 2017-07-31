using Mono.Data.Sqlite;
using System.Data;
using UnityEngine;

namespace Assets.Scripts.Utilities.Rows
{
    public class DBFunctions
    {
        private string _connectionString;
        public DBFunctions()
        {
            _connectionString = "URI=file:" + Application.dataPath + "/DB.sqlite";
        }

        public void UpdateScore()
        {
            using (var con = new SqliteConnection(_connectionString))
            {
                con.Open();
                using (IDbCommand cmd = con.CreateCommand())
                {
                    string query = string.Format("UPDATE HighScore SET Score = " + Constants.Globals.Score);
                    cmd.CommandText = query;
                    cmd.ExecuteScalar();
                }
                con.Close();
            }
        }

        public int GetScore()
        {
            int s = 0;
            using (var con = new SqliteConnection(_connectionString))
            {
                con.Open();
                using (IDbCommand cmd = con.CreateCommand())
                {
                    var query = "SELECT * FROM HighScore";
                    cmd.CommandText = query;

                    using (IDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            s = reader.GetInt32(0);
                        }
                    }
                }
                con.Close();
            }
            return s;
        }
    }
}
