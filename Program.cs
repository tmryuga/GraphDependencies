using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication26
{
    class Pattern
    {
        public string Code { get; set; }
        public List<Pattern> Parents { get; set; }

        public override string ToString()
        {
            return Code;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var a = new Pattern { Code = "A" };
            var b = new Pattern { Code = "B" };
            var c = new Pattern { Code = "C" };
            var d = new Pattern { Code = "D" };
            var e = new Pattern { Code = "E" };
            var f = new Pattern { Code = "F" };
            var g = new Pattern { Code = "G" };
            var h = new Pattern { Code = "H" };
            var i = new Pattern { Code = "I" };
            var j = new Pattern { Code = "J" };
            var k = new Pattern { Code = "K" };

            a.Parents = new List<Pattern> { b };
            b.Parents = new List<Pattern> { d };
            c.Parents = new List<Pattern> { b };
            d.Parents = new List<Pattern> { };
            e.Parents = new List<Pattern> { f, h };
            f.Parents = new List<Pattern> { c, d };
            g.Parents = new List<Pattern> { f };
            h.Parents = new List<Pattern> { a, g };
            i.Parents = new List<Pattern> { h };
            j.Parents = new List<Pattern> { k, f };
            k.Parents = new List<Pattern> { g };

            var list = new List<Pattern> { a, b, c, d, e, f, g, h, i, j, k };
            var sortedList = new List<Pattern>();

            while (list.Any())
            {
                var vertices = list.Where(p => !sortedList.Any() ? !p.Parents.Any() : !p.Parents.Any(p2 => !sortedList.Contains(p2))).ToList();
                sortedList.AddRange(vertices);
                list.RemoveAll(p => vertices.Contains(p));
            }

            Console.ReadLine();
        }
    }
}
