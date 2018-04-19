using System;
using System.Collections.Generic;
using System.Text;

namespace TaxiParkApp.Services
{
    interface IDatabaseConnection
    {
        SQLite.SQLiteConnection DbConnection();
    }
}
