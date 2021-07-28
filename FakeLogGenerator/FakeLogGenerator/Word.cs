using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeLogGenerator
{
    public class Word
    {
        public int Id { get; set; }
        public string Value { get; set; }

        public Word(int id, string value)
        {
            Id = id;
            Value = value;
        }
    }
}
