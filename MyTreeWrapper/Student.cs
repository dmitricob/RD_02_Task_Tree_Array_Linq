using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTreeWrapper
{
    class Student : IComparable
    {
        public string Name { get; private set; }
        public string Secondname { get; private set; }
        public int Score { get; set; }
        public Student(string name, string secondname,int score)
        {
            this.Name = name;
            this.Secondname = secondname;
            this.Score = score;
        }

        public int CompareTo(object other)
        {
            if (other is Student)
            {
                int compByScore = this.Score.CompareTo(((Student)other).Score);
                int compByName = (this.Name + this.Secondname).CompareTo(((Student)other).Name + ((Student)other).Secondname);
                return compByScore.CompareTo(compByName);
            }
            else
            {
                throw new ArgumentException("Error compare type");
            }
        }
    }
}
