using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcSample.Models;

namespace MvcSample.Data
{
    public class MvcSampleContext : DbContext
    {
        public MvcSampleContext (DbContextOptions<MvcSampleContext> options)
            : base(options)
        {
        }

        public DbSet<MvcSample.Models.SampleModel> SampleModel { get; set; }
    }
}
