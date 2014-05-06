using UnityEngine;
using System.Collections;
using System.Data;
using Mono.Data.SqliteClient;

/* Important Note: Need Mono.Data.SqliteClient.dll and System.data.dll - can be found in Monodevelop's folder | downloaded from some site*/
public class KPDatabase {
	private string connection;
	private IDbConnection dbcon;
	private IDbCommand dbcmd; 
	private IDataReader reader; 

	public KPDatabase(){

	}

	public void OpenDB(string name){
		this.connection = "URI=file:" + name;
		dbcon = new SqliteConnection(connection);
		dbcon.Open ();
	}

	public void CreateTable(string tableName, string[] columnNames, string[] columnTypes){
		if (columnNames.Length != 0 && columnTypes.Length != 0){
			string insertionString = "CREATE TABLE " + tableName + " (";
			for (int i = 0; i < columnNames.Length; i++){
				if (i == 0) insertionString += columnNames[i] + " " + columnTypes[i];
				else insertionString += ", " + columnNames[i] + " " + columnTypes[i];
			}
			insertionString += ");";
			Debug.Log(insertionString);

			this.query(insertionString);
		}
	}

	public void InsertNewRow(string tableName,  string[] values){
		if (values.Length != 0){
			string insertionString = "INSERT INTO " + tableName + " VALUES (";
			insertionString += values[0];
			for (int i = 1; i < values.Length; i++){
				insertionString += ", " + values[i];
			}
			insertionString += ");";
			Debug.Log (insertionString);

			this.query (insertionString);
		}

	}

	private void query(string command){
		this.dbcmd = this.dbcon.CreateCommand();
		this.dbcmd.CommandText = command;
		this.dbcmd.ExecuteReader();
	}
}
