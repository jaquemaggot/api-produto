using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.SqlServer.Context
{
    public class SqlServerApiContext : ApiContext
    {
        public SqlServerApiContext([NotNull] DbContextOptions options) : base(options)
        {
        }
    }
}
