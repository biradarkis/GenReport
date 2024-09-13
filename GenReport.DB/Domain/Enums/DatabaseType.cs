using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenReport.DB.Domain.Enums
{
    /// <summary>
    /// Enum representing different database types.
    /// </summary>
    public enum DatabaseType
    {
        
        /// <summary>MySQL database.</summary>
        MySQL = 1,
        /// <summary>PostgreSQL database.</summary>
        PostgreSQL = 2,
        /// <summary>Microsoft SQL Server database.</summary>
        SQLServer = 3,
        /// <summary>Oracle database.</summary>
        Oracle = 4,
        /// <summary>SQLite database.</summary>
        SQLite = 5,
        
    }

}
