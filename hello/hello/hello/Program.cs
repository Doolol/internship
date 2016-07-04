using Database;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hello
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Format("My new parameter: {2:00.00000}, {0}, {1}", true, 3, 3.4));
            Console.WriteLine(string.Format("My new parameter: {0}", ConfigurationManager.AppSettings["myParam"]));
            Console.WriteLine(string.Format("My new parameter: {0}", CommonLib.MyClass.GetA()));

            using (var db = new TestDatabaseEntities())
            {
                db.Products.OrderByDescending(x => x.Name).Skip(0).Take(10).ToList().ForEach(x => Console.WriteLine(string.Format("id={0} name={1} date={2}", x.Id, x.Name, x.CreatedOn)));
                Console.WriteLine(string.Format("Max date={0} ", db.Products.Max(x => x.CreatedOn).ToString()));
                Console.WriteLine(string.Format("count={0} ",db.Products.Max(x => x.Id)));
                Console.WriteLine("Where = Product1");
                var l= db.Products.Where(x => x.Name == "lal").Take(11).ToList();
                foreach (var a in l)
                {
                    Console.WriteLine(string.Format("id={0} name={1} date={2}", a.Id, a.Name, a.CreatedOn));
                }
            }

            Console.WriteLine("_______________________completed_________________");
            Console.ReadKey();
        }
    }
}
