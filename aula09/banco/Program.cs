using static System.Console;
using System.Data.SqlClient;
using System.Data;

SqlConnectionStringBuilder stringConnectionBuilder = new SqlConnectionStringBuilder();

stringConnectionBuilder.DataSource = @"CT-C-0018A\SQLEXPRESS";

stringConnectionBuilder.InitialCatalog = "example";
stringConnectionBuilder.IntegratedSecurity = true;

string stringConnection = stringConnectionBuilder.ConnectionString;



SqlConnection conn = new SqlConnection(stringConnection);
conn.Open();

// EXEMPLO INSERT

// SqlCommand comm = new SqlCommand("INSERT Cliente values ('Camila', '123', GETDATE());");
// comm.Connection = conn;
// comm.ExecuteNonQuery();

// conn.Close();


string nome = ReadLine();
string senha = ReadLine();

SqlCommand comm = new SqlCommand($"SELECT * FROM Cliente WHERE Nome = '{nome}' AND Senha = '{senha}'");
comm.Connection = conn;

// Com brecha para SQL Injection

// var reader = comm.ExecuteReader();

// DataTable dt = new DataTable();
// dt.Load(reader);

// if(dt.Rows.Count > 0)
//     WriteLine($"Usuário {dt.Rows[0].ItemArray[0]} Logado");
// else 
//     WriteLine("Inexistente");

conn.Close();


conn.Close();