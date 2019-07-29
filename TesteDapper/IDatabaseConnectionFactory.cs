using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace TesteDapper
{
    public interface IDatabaseConnectionFactory
    {   IDbConnection GetConnection();
    }
}
