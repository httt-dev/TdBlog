using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TdBlog.Data
{
    public class TbBlogContextFactory : IDesignTimeDbContextFactory<TdBlogContext>
    {
        /// <summary>
        /// Vi DI duoc khai bao tai project khac nen de co the migrate duoc thi can phai dung IDesignTimeDbContextFactory 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public TdBlogContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<TdBlogContext>();

            builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            return new TdBlogContext(builder.Options);
        }
    }
}
