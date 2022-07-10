using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeBeerProject.Data;
using CodeBeerProject.ViewModels.Base;
using Google.Protobuf.WellKnownTypes;

namespace CodeBeerProject.ViewModels
{
    class DetailViewModel : NotifyBase
    {
        private readonly Employee _employee;
        private readonly CheckInOut _lastCheckInOut;

        public DetailViewModel(Employee employee)
        {
            _employee = employee;
            _lastCheckInOut = DatabaseConnection.CheckInOuts.Where(c => c.EmpCode == _employee.EmpCode)
                .OrderByDescending(c => c.BeginWork).FirstOrDefault();
        }

        public DateTime? Date => _lastCheckInOut?.BeginWork;
        public string EntryTime =>
            _lastCheckInOut?.BeginWork.ToString("T");

        public string ExitTime =>
            (_lastCheckInOut?.EndWork)?.ToString("T");

        public string BreakReason => DatabaseConnection.Breaks.FirstOrDefault(b => b.BreakCode == _lastCheckInOut?.BreakCode)?.BreakReason;
        public string BreakStartTime => _lastCheckInOut?.BeginBreak?.ToString("T");
        public string BreakEndTime => _lastCheckInOut?.EndBreak?.ToString("T");

        public int TotalHoursDay
        {
            get
            {

                try
                {
                    if (_lastCheckInOut?.EndWork != null)
                    {
                        return (_lastCheckInOut?.EndWork.Value - _lastCheckInOut?.BeginWork).Value.Hours;
                    }

                    if (_lastCheckInOut?.EndWork == null && _lastCheckInOut?.BeginWork.Date == DateTime.Today)
                    {
                        return (DateTime.Now.Hour - (int) _lastCheckInOut?.BeginWork.Hour);
                    }
                    else
                    {
                        return 0;
                    }
                }
                catch (Exception e)
                {
                    Debug.Assert(true, e.Message);
                    return 0;
                }
                

            }
        }
            

        public int TotalHoursMonth
        {
            get
            {
                try
                {
                    return (int)DatabaseConnection.CheckInOuts.Where(c =>
                            c.EmpCode == _employee.EmpCode && c.BeginWork.Month == DateTime.Now.Month && c.EndWork!=null)
                        .Select(c=>((c.EndWork.Value - c.BeginWork).Hours)).Sum();

                }
                catch (Exception e)
                {
                    Debug.Assert(true, e.Message);
                    return 0;
                }
            }
        }

    }
}
