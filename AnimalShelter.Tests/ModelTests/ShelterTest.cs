using Microsoft.VisualStudio.TestTools.UnitTesting;
using Animal.Models;
using System.Collections.Generic;
using System;
using MySql.Data.MySqlClient;

namespace Animal.Tests
{
  [TestClass]
  public class ShelterTest
  {
    //
    // public void Dispose()
    // {
    //   Shelter.ClearAll();
    // }
    public ShelterTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=animal_database;";
    }
    [TestMethod]
    public void ShelterConstructor_CreatesInstanceOfItem_Shelter()
    {
      Shelter newShelter = new Shelter("test", "test", 10.12, 5);
      Assert.AreEqual(typeof(Shelter), newShelter.GetType());
    }

    [TestMethod]
    public void Gettype_ReturnsDescription_String()
    {
      //Arrange
      string type = "dog";
      string sex = "male";
      double  date = 11.18;
      Shelter newItem = new Shelter(type, sex, date);

      //Act
      string resultType = newItem._type;
      string resultSex = newItem._sex;
     double resultDate = newItem._date;

      //Assert
      Assert.AreEqual(type, resultType);
      Assert.AreEqual(sex, resultSex);
      Assert.AreEqual(date, resultDate);
    }
  }
}
