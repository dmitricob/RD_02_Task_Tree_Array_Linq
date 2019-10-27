using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RD_02_Task_Tree_Array_Linq
{
    class Student : IComparable
    {
        public string Name { get; private set; }
        public string Secondname { get; private set; }
        public int Score { get; set; }
        public Student(string name, string secondname, int score)
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
                if(compByScore == 0)
                {
                    int compByName = (this.Name + this.Secondname).CompareTo(((Student)other).Name + ((Student)other).Secondname);
                    return compByName;               
                }
                return compByScore;
            }
            else
            {
                throw new ArgumentException("Error compare type");
            }
        }

        public override string ToString()
        {
            return $"{Secondname} {Name}  -  {Score}";
        }
    }
}
