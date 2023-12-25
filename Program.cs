using System.Security.Cryptography;
using System.Text;


// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var password = "password";
var salt = Encoding.UTF8.GetBytes("salty");
var hashed = new Rfc2898DeriveBytes(password, salt); // Noncompliant code