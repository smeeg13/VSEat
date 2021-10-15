using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MenuDB
    {
        private IConfiguration Configuration { get; }


        public MenuDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

    }
}