using System;
using System.Collections.Generic;
using System.Linq;

namespace Utility.Valocity.ProfileHelper
{
    public class People(string name, DateTime dob)
    {
     private static readonly DateTime Under16 = DateTime.UtcNow.AddYears(-16);
        public string Name { get; private set; } = name;
        public DateTime DOB { get; private set; } = dob;
        public People(string name) : this(name, Under16.Date) { }
    }

    public class BirthingUnit
    {
        /// <summary>
        /// MaxItemsToRetrieve
        /// </summary>
        private readonly List<People> _people;
        private static readonly Random _random = new Random();

        public BirthingUnit()
        {
            _people = new List<People>();
        }

        /// <summary>
        /// GetPeoples
        /// </summary>
        /// <param name="j"></param>
        /// <returns>List<object></returns>
        public List<People> GetPeople(int count)
        {
            for (int j = 0; j < count; j++)
            {
               try
               {
                 string name = _random.Next(0, 2) == 0 ? "Bob" : "Betty";
 
                 var dob = DateTime.UtcNow.Subtract(
                     TimeSpan.FromDays(_random.Next(18, 85) * 365)
                 );
 
                 _people.Add(new People(name, dob));
               }
               catch (Exception ex)
               {
                    throw new Exception("Something failed in user creation",ex);
               }
            }

            return _people;
        }

        private IEnumerable<People> GetBobs(bool olderThan30)
        {
            if (olderThan30)
            {
                var cutoff = DateTime.UtcNow.AddYears(-30);
                return _people.Where(x => x.Name == "Bob" && x.DOB <= cutoff);
            }

            return _people.Where(x => x.Name == "Bob");
        }

        public string GetMarried(People p, string lastName)
        {
            if (p == null) throw new ArgumentNullException(nameof(p));

            if (string.IsNullOrEmpty(lastName) || lastName.Contains("test"))
                return p.Name;

            var fullName = $"{p.Name} {lastName}";

            return fullName.Length > 255
                ? fullName.Substring(0, 255)
                : fullName;
        }
    }
}