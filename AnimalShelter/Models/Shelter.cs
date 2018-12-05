using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Animal.Models;
using System;

namespace Animal.Models
{
  public class Shelter
  {
    public string _type {get;set;}
    public string _sex {get;set;}
    public double _date {get;set;}
    private int _id;

    public Shelter(string type, string sex, double date, int id = 0)
    {
      this._type = type;
      this._sex = sex;
      this._id = id;
      this._date = date;
    }
    public static List<Shelter> GetAll()
    {
      List<Shelter> allShelter = new List<Shelter>{};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM Animal;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

      while(rdr.Read())
      {
        int ShelterId = rdr.GetInt32(0);
        string ShelterType = rdr.GetString(1);
        string ShelterSex = rdr.GetString(2);
        int ShelterDate = rdr.GetInt32(3);
        Shelter newShelter = new Shelter(ShelterType, ShelterSex, ShelterDate,ShelterId);
        allShelter.Add(newShelter);
      }
      conn.Close();

      if (conn != null)
      {
        conn.Dispose();
      }
      return allShelter;
    }
    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM Animal;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

  }

}
