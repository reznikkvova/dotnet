using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    internal class Paper
    {
        public string _name;
        public Person _author;
        public DateTime _publishDate;

        public Paper(string name, Person author, DateTime publishDate)
        {
            _name = name;
            _author = author;
            _publishDate = publishDate;
        }

        public Paper()
        {
            _author = new Person();
            _name = "";
            _publishDate = new DateTime(1, 1, 1);
        }
        public virtual Paper DeepCopy()
        {
            return new Paper(_name, _author.DeepCopy(), new DateTime(_publishDate.Year, _publishDate.Month, _publishDate.Day));
        }


        public override string ToString()
        {
            return $"Name: {_name}, Author: {_author}, Publish date: {_publishDate.ToString("yyyy/MM/dd")}";
        }
    }
}
