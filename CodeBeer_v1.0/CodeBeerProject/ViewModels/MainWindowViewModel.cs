using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents.Serialization;
using System.Windows.Input;
using CodeBeerProject.Data;
using CodeBeerProject.Models;
using CodeBeerProject.ViewModels.Base;
using CodeBeerProject.Views;
using CodeBeerProject.Views.Global;

namespace CodeBeerProject.ViewModels
{
    class MainWindowViewModel : NotifyBase
    {
        #region Atributos
        private readonly LoginView _loginView;
        private readonly ProfileView _profileView;
        private readonly DetailView _detailView;
        private readonly DataGridView _dataGridView;
        private DetailViewModel _detailViewModel;
        private Visibility _viewsVisibility;
        private Visibility _checkInPanelVisibility;
        private object _currentView;
        private Employee _selectedEmployee;
        private Employee _loggedInEmployee;
        private int _selectedViewIndex;
        private int _selectedEmployeeIndex;
        private bool _isLoggedInEmployeeOnWork;
        private string _breakButtonText;
        private bool _isLoggedInEmpNotOnBreak;
        private bool _isBreakAvailable;
        private int _selectedReasonIndex;
        private CheckInOut _selectedRecord;
        #endregion

        #region Constructor
        public MainWindowViewModel()
        {
            DatabaseConnection.FetchData();
            UIGlobal.MainWinVmObj = this;
            ViewsVisibility = Visibility.Hidden;
            CheckInPanelVisibility = Visibility.Hidden;
            _loginView=new LoginView();
            _profileView=new ProfileView();
            _detailView=new DetailView();
            _dataGridView=new DataGridView();
            CurrentView = _loginView;
            BreakButtonText = "Pausar";
            StartWorkCommand=new CommandBase(param=>OnStartWorkCommand());
            BreakCommand=new CommandBase(param=>OnBreakCommand());
            EndWorkCommand=new CommandBase(param=>OnEndWorkCommand());
            SaveRecordCommand=new CommandBase(param=>OnSaveCommand());
            NewRecordCommand=new CommandBase(param=>OnNewRecordCommand());
            DeleteRecordCommand=new CommandBase(param=>OnDeleteCommand());
            LogoutCommand = new CommandBase(param => OnLogoutCommand());
            ExitCommand = new CommandBase(param => OnExitCommand());
            AutorCommand = new CommandBase(param => OnAutorCommand());
        }
        #endregion

        #region Propiedades
        public ICommand StartWorkCommand { get; set; }
        public ICommand BreakCommand { get; set; }
        public ICommand EndWorkCommand { get; set; }
        public ICommand SaveRecordCommand { get; set; }
        public ICommand NewRecordCommand { get; set; }
        public ICommand DeleteRecordCommand { get; set; }
        public ICommand LogoutCommand { get; set; }
        public ICommand ExitCommand { get; set; }
        public ICommand AutorCommand { get; set; }

        public CheckInOut SelectedRecord
        {
            get => _selectedRecord;
            set
            {
                _selectedRecord = value; 
                OnPropertyChanged(nameof(SelectedRecord));
            }
        }

        public Visibility ViewsVisibility
        {
            get => _viewsVisibility;
            set
            {
                _viewsVisibility = value;
                OnPropertyChanged(nameof(ViewsVisibility));
            }
        }

        public Visibility CheckInPanelVisibility
        {
            get => _checkInPanelVisibility;
            set
            {
                _checkInPanelVisibility = value;
                OnPropertyChanged(nameof(CheckInPanelVisibility));
            }
        }

        public string BreakButtonText
        {
            get => _breakButtonText;
            set
            {
                _breakButtonText = value; 
                OnPropertyChanged(nameof(BreakButtonText));
            }
        }

        public Object CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }

        public ObservableCollection<CheckInOut> CheckInOutList
        {
            get
            {
                if (LoggedInEmployee==null)
                {
                    return null;
                }
                if (LoggedInEmployee.IsAdmin)
                {
                    return DatabaseConnection.CheckInOuts;
                }
                else
                {
                    return new ObservableCollection<CheckInOut>(DatabaseConnection.CheckInOuts.Where(r => r.EmpCode == LoggedInEmployee.EmpCode)); 
                }
                
            }
            set
            {
               
                
            }
        }

        public Employee SelectedEmployee
        {
            get => _selectedEmployee;
            set
            {
                _selectedEmployee = value; 
                _detailViewModel=new DetailViewModel(SelectedEmployee);
                _detailView.DataContext = _detailViewModel;
                _profileView.DataContext = SelectedEmployee;
                OnPropertyChanged(nameof(SelectedEmployee));

            }
        }

        public Employee LoggedInEmployee
        {
            get => _loggedInEmployee;
            set
            {
                _loggedInEmployee = value;
                var _lastCheckIn = DatabaseConnection.CheckInOuts.Where(c => c.EmpCode == _loggedInEmployee.EmpCode)
                    .OrderByDescending(c => c.BeginWork).FirstOrDefault()?.BeginWork;
                var _lastCheckOut = DatabaseConnection.CheckInOuts.Where(c => c.EmpCode == _loggedInEmployee.EmpCode)
                    .OrderByDescending(c => c.BeginWork).FirstOrDefault()?.EndWork;
                if (_lastCheckOut == null)
                {
                    IsLoggedInEmployeeOnWork = _lastCheckIn?.Date == DateTime.Today;
                }
                else
                {
                    IsLoggedInEmployeeOnWork = false;
                }
                var _lastBreakSt = DatabaseConnection.CheckInOuts.Where(c => c.EmpCode == _loggedInEmployee.EmpCode)
                    .OrderByDescending(c => c.BeginWork).FirstOrDefault()?.BeginBreak;
                var _lastBreakEnd = DatabaseConnection.CheckInOuts.Where(c => c.EmpCode == _loggedInEmployee.EmpCode)
                    .OrderByDescending(c => c.BeginWork).FirstOrDefault()?.EndBreak;
                IsBreakAvailable = (_lastBreakSt == null && _lastBreakEnd == null);
                
                if (IsLoggedInEmployeeOnWork)
                {
                    IsLoggedInEmpNotOnBreak = !(_lastBreakSt != null && _lastBreakEnd == null);
                    BreakButtonText = IsLoggedInEmpNotOnBreak ? "Pausar" : "Fin Pausa";
                }
                else
                {
                    BreakButtonText = "Pausar";
                    IsLoggedInEmpNotOnBreak = false;
                }
                
                OnPropertyChanged(nameof(LoggedInEmployee));
                OnPropertyChanged(nameof(IsDataGridViewReadOnly));
            }
        }

        public bool IsLoggedInEmployeeOnWork
        {
            get => _isLoggedInEmployeeOnWork;
            set
            {
                _isLoggedInEmployeeOnWork = value;
                IsStartWorkEnabled = !_isLoggedInEmployeeOnWork;
                OnPropertyChanged(nameof(IsLoggedInEmployeeOnWork));
                OnPropertyChanged(nameof(IsStartWorkEnabled));
            }
        }

        public bool IsLoggedInEmpNotOnBreak
        {
            get => _isLoggedInEmpNotOnBreak;
            set
            {
                _isLoggedInEmpNotOnBreak = value; 
                OnPropertyChanged(nameof(IsLoggedInEmpNotOnBreak));
            }
        }

        public bool IsBreakAvailable
        {
            get => _isBreakAvailable;
            set
            {
                _isBreakAvailable = value; 
                OnPropertyChanged(nameof(IsBreakAvailable));
            }
        }

        public bool IsStartWorkEnabled { get; set; }
        #endregion

        #region Metodos
        private void OnExitCommand()
        {
            Application.Current.Shutdown();
        }

        private void OnLogoutCommand()
        {
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
            new MainWindow().Show();
        }

        private void OnAutorCommand()
        {
            Autor autor = new Autor();
            autor.Show();
        }

        public int SelectedViewIndex
        {
            get => _selectedViewIndex;
            set
            {
                _selectedViewIndex = value;
                switch (_selectedViewIndex)
                {
                    case 0:
                        UIGlobal.MainWinVmObj.NavigateView(ViewType.ProfileView);
                        break;
                    case 1:
                        
                        UIGlobal.MainWinVmObj.NavigateView(ViewType.DetailView);
                        break;
                    case 2:
                        UIGlobal.MainWinVmObj.NavigateView(ViewType.DataGridView);
                        break;
                    default:
                        UIGlobal.MainWinVmObj.NavigateView(ViewType.ProfileView);
                        break;
                }
            }
        }

        public IEnumerable<string> BreakOptionsList => DatabaseConnection.Breaks.Select(b=>b.BreakReason);
        public ObservableCollection<Employee> EmployeeNameList => DatabaseConnection.Employees;

        public int SelectedEmployeeIndex
        {
            get => _selectedEmployeeIndex;
            set
            {
                _selectedEmployeeIndex = value;
                SelectedEmployee = EmployeeNameList[_selectedEmployeeIndex];
                OnPropertyChanged(nameof(SelectedEmployeeIndex));
                OnPropertyChanged(nameof(CheckInOutList));
            }
        }

        public int SelectedReasonIndex
        {
            get => _selectedReasonIndex;
            set
            {
                _selectedReasonIndex = value; 
                OnPropertyChanged(nameof(SelectedReasonIndex));
            }
        }

        public bool IsDataGridViewReadOnly => !LoggedInEmployee?.IsAdmin??true;  
        

        public void NavigateView(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.ProfileView:
                    CurrentView = _profileView;
                    break;
                case ViewType.DetailView:
                    SelectedEmployeeIndex = SelectedEmployeeIndex;
                    CurrentView = _detailView;
                    break;
                case ViewType.DataGridView:
                    OnPropertyChanged(nameof(CheckInOutList));
                    CurrentView = _dataGridView;
                    break;
            }
        }

        private void OnStartWorkCommand()
        {
            try
            {
                IsLoggedInEmployeeOnWork = true;
                IsBreakAvailable = true;
                IsLoggedInEmpNotOnBreak = true;
                BreakButtonText = "Start Break";
                CheckInOut record=new CheckInOut(){BeginWork = DateTime.Now,EmpCode = LoggedInEmployee.EmpCode};
                DatabaseConnection.CheckInOuts.Add(record);
                DatabaseConnection.SaveData();
                DatabaseConnection.FetchData();
                // var index = SelectedEmployeeIndex;
                SelectedEmployeeIndex = SelectedEmployeeIndex;
            }
            catch (Exception e)
            {
                Debug.Assert(true, e.Message);
            }
        }

        private void OnBreakCommand()
        {
            try
            {
                if (BreakButtonText=="Start Break")
                {
                    if (!IsBreakAvailable)
                    {
                        MessageBox.Show("Sorry, no break is available for today!");
                        return;
                    }

                    var _lastCheckIn = DatabaseConnection.CheckInOuts.Where(c => c.EmpCode == _loggedInEmployee.EmpCode)
                        .OrderByDescending(c => c.BeginWork).FirstOrDefault();
                    _lastCheckIn.BeginBreak = DateTime.Now;
                    var breakcode = DatabaseConnection.Breaks.ElementAtOrDefault(SelectedReasonIndex)?.BreakCode;
                    _lastCheckIn.BreakCode = breakcode;
                    IsLoggedInEmpNotOnBreak = false;
                    BreakButtonText = "End Break";
                    DatabaseConnection.SaveData();
                    DatabaseConnection.FetchData();
                    SelectedEmployeeIndex = SelectedEmployeeIndex;
                }
                else
                {
                    var _lastCheckIn = DatabaseConnection.CheckInOuts.Where(c => c.EmpCode == _loggedInEmployee.EmpCode)
                        .OrderByDescending(c => c.BeginWork).FirstOrDefault();
                    _lastCheckIn.EndBreak = DateTime.Now;
                    IsLoggedInEmpNotOnBreak = true;
                    BreakButtonText = "Start Break";
                    IsBreakAvailable = false;
                    DatabaseConnection.SaveData();
                    DatabaseConnection.FetchData();
                    SelectedEmployeeIndex = SelectedEmployeeIndex;
                }
            }
            catch (Exception e)
            {
                Debug.Assert(true, e.Message);
            }
        }

        private void OnEndWorkCommand()
        {
            try
            {
                var _lastCheckIn = DatabaseConnection.CheckInOuts.Where(c => c.EmpCode == _loggedInEmployee.EmpCode)
                    .OrderByDescending(c => c.BeginWork).FirstOrDefault();
                _lastCheckIn.EndWork = DateTime.Now;
                IsLoggedInEmployeeOnWork = false;
                IsLoggedInEmpNotOnBreak = false;
                DatabaseConnection.SaveData();
                DatabaseConnection.FetchData();
                SelectedEmployeeIndex = SelectedEmployeeIndex;
            }
            catch (Exception e)
            {
                Debug.Assert(true,e.Message);
            }
        }
        private void OnDeleteCommand()
        {
            try
            {
                DatabaseConnection.CheckInOuts.Remove(SelectedRecord);
                OnSaveCommand();
            }
            catch (Exception e)
            {
                Debug.Assert(true, e.Message);
            }
        }
        private void OnNewRecordCommand()
        {
            try
            {
                DatabaseConnection.CheckInOuts.Add(new CheckInOut() { EmpCode = LoggedInEmployee.EmpCode, BeginWork = DateTime.Now });
                OnSaveCommand();
            }
            catch (Exception e)
            {
                Debug.Assert(true, e.Message);
            }

        }
        private void OnSaveCommand()
        {
            try
            {
                DatabaseConnection.SaveData();
                DatabaseConnection.FetchData();
                OnPropertyChanged(nameof(CheckInOutList));
            }
            catch (Exception e)
            {
                Debug.Assert(true, e.Message);
            }
        }
        #endregion
    }
}
