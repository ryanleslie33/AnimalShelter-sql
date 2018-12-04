using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System;
using Animal;

namespace Animal.Models
{
  public class DB
  {
    public static MySqlConnection Connection()
    {
      MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
      return conn;
    }
  }
}
