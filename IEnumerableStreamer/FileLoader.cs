using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.SqlServer.Server;
using System.Data;
using System.IO;

namespace IEnumerableStreamer
{
    public class FileLoader
    {
        readonly string _filename;
        readonly string _location;

        private string connstring = "";
        private SqlConnection conn = new SqlConnection();

        public FileLoader(string location = @"C:\temp\", string filename = "TestLoad.txt")
        {
            _filename = filename;
            _location = location;

        }

        //https://stackoverflow.com/questions/36725999/c-sharp-fastest-way-to-insert-data-into-sql-database
        //for xml based deserialization into objects to pass in ienumerable
        //https://stackoverflow.com/questions/4143421/fastest-way-to-serialize-and-deserialize-net-objects
        //https://stackoverflow.com/questions/25770180/how-can-i-insert-10-million-records-in-the-shortest-time-possible

        public IEnumerable<SqlDataRecord> GetSqlDataRecords()
        {
            SqlMetaData MetaDataCol1;
            SqlMetaData MetaDataCol2;
            SqlMetaData MetaDataCol3;

            MetaDataCol1 = new SqlMetaData("stringTest", SqlDbType.NVarChar);
            MetaDataCol2 = new SqlMetaData("intTest", SqlDbType.Int);
            MetaDataCol3 = new SqlMetaData("doubleTest", SqlDbType.Decimal, 18, 8); // precision 18, 8 scale


            SqlDataRecord DataRecord = new SqlDataRecord(new SqlMetaData[] { MetaDataCol1, MetaDataCol2, MetaDataCol3 });

            var lines = File.ReadLines(_location + _filename);

            foreach(var line in lines)
            {
                var data = line.Split('|');
                DataRecord.SetString(0, data[2]);
                DataRecord.SetInt32(1, Convert.ToInt32(data[0]));
                DataRecord.SetDecimal(2, Convert.ToDecimal(data[1]));

                yield return DataRecord;
            }
        }
    }
}
