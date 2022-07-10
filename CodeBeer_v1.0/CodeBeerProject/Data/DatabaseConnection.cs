using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBeerProject.Data
{
    public sealed class DatabaseConnection
    {
        public static CodeBeerDb _db=new CodeBeerDb();

        public static void FetchData()
        {
            try
            {
                _db.Employee.Load();
                _db.Break.Load();
                _db.CheckInOut.Load();
            }
            catch (Exception e)
            {
                Debug.Assert(true,e.Message);
            }
        }

        public static void SaveData()
        {
            try
            {
                _db.SaveChanges();
            }
            catch (Exception e)
            {
                Debug.Assert(true, e.Message);
            }

        }
        public static IEnumerable<int> EmployeeIdList => _db.Employee.Local.Select(e => e.EmpCode);

        public static ObservableCollection<Employee> Employees => _db.Employee.Local;
        public static ObservableCollection<Break> Breaks => _db.Break.Local;
        public static ObservableCollection<CheckInOut> CheckInOuts => _db.CheckInOut.Local;
    }
}