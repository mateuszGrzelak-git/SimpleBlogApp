using System;
using System.ComponentModel;
using System.Data.SqlClient;

namespace Blog_Dirty_;

public class DatabaseInitializer2
{
    private readonly IDbConnectionFactory _connectionFactory;

    // public DatabaseInitializer(IDbConnectionFactory connectionFactory)
    // {
    //     _connectionFactory = connectionFactory;
    // }

    public void Init()
    {
        String str;
        SqlConnection myConn = new SqlConnection ("Data Source=(local)\\POSTSDATABASE;Initial Catalog=PostsRepository;Integrated Security=SSPI");

        str = @"CREATE TABLE IF NOT EXISTS Users
            ID CHAR(36) PRIMARY KEY, 
            Username TEXT NOT NULL,
            Password TEXT NOT NULL";

        SqlCommand myCommand = new SqlCommand(str, myConn);
            myConn.Open();
            myCommand.ExecuteNonQuery();
            myConn.Close();
            
            SqlConnection myConn2 = new SqlConnection ("Data Source=(local)\\USERDATABASE;Initial Catalog=UserRepository;Integrated Security=SSPI");

            
        str = @"CREATE TABLE IF NOT EXISTS Users
            ID CHAR(36) PRIMARY KEY, 
            Username TEXT NOT NULL,
            Password TEXT NOT NULL";

            SqlCommand myCommand2 = new SqlCommand(str, myConn2);
            myConn2.Open();
            myCommand2.ExecuteNonQuery();
            myConn2.Close();
    }
}