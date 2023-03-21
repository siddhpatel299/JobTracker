using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;

namespace BackEnd.Repositories
{
    public class CommonRepository
    {
        protected NpgsqlConnection cn = new NpgsqlConnection("Server=cipg01; Port=5432; Database=JobTracker; User Id=postgres; Password=123456;");
    }
}