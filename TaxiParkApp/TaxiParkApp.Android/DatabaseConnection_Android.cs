using SQLite;
using TaxiParkApp.Droid;
using System.IO;
using TaxiParkApp.Services;

[assembly: Xamarin.Forms.Dependency(typeof(DatabaseConnection_Android))]
namespace TaxiParkApp.Droid
{
    public class DatabaseConnection_Android : IDatabaseConnection
    {
        public SQLiteConnection DbConnection()
        {
            var dbName = "taxi.db3";
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), dbName);
            return new SQLiteConnection(path);
        }
    }
}

