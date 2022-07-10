using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Annotations;
using System.Windows.Controls;
using System.Windows.Input;
using CodeBeerProject.Data;
using CodeBeerProject.Models;
using CodeBeerProject.ViewModels.Base;
using CodeBeerProject.Views.Global;

namespace CodeBeerProject.ViewModels
{
    /// <summary>
    /// Clase LoginViewModel que herada a su vez de NotifyBase para hacer de la
    /// interfaz INotifyPropertyChanged. Es el data context de la página que sirve
    /// de login en la aplicación.
    /// <list type="table">  
    /// <listheader>  
    /// <term>Atributo</term>  
    /// <term>Tipo Dato</term>  
    /// <term>Descripción</term>  
    /// </listheader>  
    /// <item>  
    /// <term>_userId</term>  
    /// <term>string</term>  
    /// <term>Identificador de empleado con el que un usuario intenta hacer login. Debe existir en la BD</term>  
    /// </item>  
    /// <item>  
    /// <term>_password</term>  
    /// <term>string</term>  
    /// <term>Contraseña con la que se identifica un usuario. Debe corresponder con la contraseña que tiene el usuario en la BD</term>  
    /// </item>
    /// <item>  
    /// <term>loginCommand</term>  
    /// <term>ICommand</term>  
    /// <term>Command asociado al botón con el que se realiza la lógica necesaria para hacer login con el usuario y contraseña indicados</term>  
    /// </item>  
    /// <item>  
    /// <term>_information</term>  
    /// <term>string</term>  
    /// <term>Información que se mostrará al usuario en un textblock para informar que se están cargando los datos si el login fue exitoso, o si hubo algún error</term>  
    /// </item>  
    /// </list> 
    /// </summary>
    class LoginViewModel : NotifyBase
    {
        //Atributos
        private string _userId;
        private ICommand loginCommand;
        private string _password;
        private string _information;

        //Propiedades
        public string UserId{ get => _userId; set => _userId = value; }

        private string Password
        {
            get => _password;
            set => _password = value;
        }

        public string Information
        {
            get => _information;
            set
            {
                _information = value; 
                OnPropertyChanged(nameof(Information));
            }
        }

        public ICommand LoginCommand { get => loginCommand; set => loginCommand = value; }

        //Constructor
        public LoginViewModel()
        {
            LoginCommand = new CommandBase(new Action<Object>(OnLoginCommand));
        }

        /// <summary>
        /// Lógica necesaria para hacer el login correcto en la aplicación. Comprueba si el identificador de usuario
        /// existe en la base de datos, y en caso afirmativo, se evalúa si la contraseña corresponde con la de ese
        /// usuario en la Base de Datos. Si el resultado es negativo se informa del error al usuario. En cambio,
        /// Si la condición es positiva se ponen visibles los botones de la aplicación y se cargan las listas
        /// con los datos de la Base de datos.
        /// </summary>
        /// <param name="parameter">Corresponde a la constraseña introducida por el usuario que intenta loguearse</param>
        private void OnLoginCommand(object parameter)
        {
            try
            {
                int userid;
                int.TryParse(UserId, out userid);
                if (UserId != null && DatabaseConnection.EmployeeIdList.Contains(userid))
                {
                    var passwordBox = parameter as PasswordBox;
                    Password = passwordBox.Password;
                    var loginSuccessful = DatabaseConnection.Employees.First(e => e.EmpCode == userid).Password
                        .SequenceEqual(Password);
                    
                    if (loginSuccessful)
                    {
                        Information = "Inicio de sesión exitoso";
                        UIGlobal.MainWinVmObj.ViewsVisibility = Visibility.Visible;
                        UIGlobal.MainWinVmObj.CheckInPanelVisibility = Visibility.Visible;
                        //UIGlobal.MainWinVmObj.SelectedEmployee =
                        //    DatabaseConnection.Employees.FirstOrDefault(e => e.EmpCode == userid);
                        UIGlobal.MainWinVmObj.LoggedInEmployee= 
                            DatabaseConnection.Employees.FirstOrDefault(e => e.EmpCode == userid);
                        UIGlobal.MainWinVmObj.SelectedEmployeeIndex =
                            DatabaseConnection.Employees.IndexOf(UIGlobal.MainWinVmObj.LoggedInEmployee);
                        UIGlobal.MainWinVmObj.NavigateView(ViewType.ProfileView);
                    }
                    else
                    {
                        Information = "Clave incorrecta, vuelva a intentarlo.";
                    }
                }
                else
                {
                    Information = "No es posible hacer login. Contacta con el administrador.";
                }

                
            }
            catch (Exception exception)
            {
                Information = "Error al cargar datos, Vuelva a intentarlo.";
            }
        }
    }
}
