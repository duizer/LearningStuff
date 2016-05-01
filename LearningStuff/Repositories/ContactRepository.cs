using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LearningStuff.Models;

namespace LearningStuff.Repositories
{
    public class ContactRepository
    {
        private const string CacheKey = "ContactStore";

        public ContactRepository()
        {
            var httpContext = HttpContext.Current;

            if (httpContext != null)
            {
                if (httpContext.Cache[CacheKey] == null)
                {
                    var contacts = new[]
                    {
                        new Contact {Id = 1, Name = "foo"},
                        new Contact {Id = 2, Name = "bar"}
                    };

                    httpContext.Cache[CacheKey] = contacts;
                }
            }
        }

        public IEnumerable<Contact> GetAll()
        {
            var httpContext = HttpContext.Current;

            if (httpContext != null)
            {
                return (Contact[]) httpContext.Cache[CacheKey];
            }

            return new[]
            {
                new Contact {Id = 0, Name = "Placeholder"}
            };
        }

        public bool SaveContact(Contact contact)
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                try
                {
                    var currentData = ((Contact[])ctx.Cache[CacheKey]).ToList();
                    currentData.Add(contact);
                    ctx.Cache[CacheKey] = currentData.ToArray();

                    return true;
                }
                catch (Exception)
                {
                    //Console.WriteLine(ex.ToString());
                    return false;
                }
            }

            return false;
        }
    }
}