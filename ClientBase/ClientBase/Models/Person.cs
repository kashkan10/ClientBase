using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientBase.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Procedure { get; set; }
        public int Profit { get; set; }
        public DateTime Data { get; set; } = DateTime.Now;
        public DateTime Time { get; set; } = DateTime.Now;
    }
}