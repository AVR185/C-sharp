   M S B A M L   `   `   `  ����J  FCodeBeerProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:CodeBeerProjectCodeBeerProject  5   	   G(clr-namespace:CodeBeerProject.ViewModelsCodeBeerProject.ViewModels  5   	   D @FluentWPF, Version=0.8.0.6, Culture=neutral, PublicKeyToken=nullP6clr-namespace:SourceChord.FluentWPF;assembly=FluentWPFSourceChord.FluentWPF 5
   	        CodeBeerProject.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:CodeBeerProject     5   	   >	viewmodel(clr-namespace:CodeBeerProject.ViewModels     5   	   U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   ?fw6clr-namespace:SourceChord.FluentWPF;assembly=FluentWPF  5
   	   )  #SourceChord.FluentWPF.AcrylicWindow    Enabled  .  � Title$$ Control de Fichajes - CodeBeer��5   	   $	��600��60   $
��1000��6=    � Icon$ /Images/icono.ico��5   	    � DataContext 5      4  .CodeBeerProject.ViewModels.MainWindowViewModel  5      .��5      ]� .+�5      o� $	��Top=�6   ��6    Z� ��66   Z� .@�5      m� $��	_Programa��6   .@�5   
   m� $��_Cerrar Sesión��6   ���	#99FDFEFE m� Command 6+   �� *LogoutCommand+6M   m� 5   
   $��_Salir��6   ���	#99FDFEFE 6#   �� *ExitCommand+6C   5   	   m� 5      $��_Información��6   .@�5   
   m� $��	In_formes��6   ���	#99FDFEFE 6&   �� *InformesCommand+6J   m� 5   
   $��_Autor��6   ���	#99FDFEFE 6#   �� *AutorCommand+6D   5   	   5      �� 5   
   $��Bottom=�6   ��6,   Z� ��6B   Z� .@�5      �� .��5      �� -   5        $��	statusBar��5      $��	StatusBar��6-   5      5       �� 5!   
   $
��Left=�6   $��Center=�6+   y�6F   �� *ViewsVisibility+.+�5"      �� $��Páginas��6   $��15q�6!   $��DemiBold"�6-   �� 5#      -   5        $��listaVistas��5#      $��14(�6    �� SelectedIndex 62   �� *SelectedViewIndex+.@�5$   
   �� $��1q�6   .��5%      ��  �� Orientation$ 
Horizontal=�6   .+�5&      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Person=�6&   $��15q�64   �� 5'      $��Perfil��6   $��Center=�6&   5(      5)      �� 5*   
   $��1q�6   .��5+      �� $ 
Horizontal=�6   .+�5,        $ Magnify=�6&   $��15q�65   �� 5-      $��Detalles��6   $��Center=�6(   $��0,0,5,0q�6C   5.      5/      �� 50   
   $��1q�6   .��51      �� $ 
Horizontal=�6   .+�52        $ BookOpenPageVariant=�6&   $��15q�6A   �� 53      $��Consulta��6   $��Center=�6(   $��0,0,5,0q�6C   54      55      56   	   57      � 58      $��Right=�6   y�6"   �� *CheckInPanelVisibility+.+�59      �� -   5        $��ComboCodigos��59      ���#FFFFFF
��� E��)  #MaterialDesignThemes.Wpf.HintAssist   Hint$ - Empleado -��6Q   $	��Top=�6   $��Center=�6�   $	 �� IsSynchronizedWithCurrentItem$
	 TrueY�5;      ��5:      �� *EmployeeNameList+{�6@   �� *LoggedInEmployee.IsAdmin+ 5<      �� *SelectedEmployeeIndex+��5>   
   �� 5?      .R�5@      �� $ 
Horizontal=�6   $
��Left=�5A      $��Center=�5B      .+�5C      �� ��6   �� 
 �� Path$
 EmpCode�6:   �� 5D      $	�� : ��6   6'   �� 5E      ��6   �� $
 EmpName�6:   5F      5G      5I   	   �� 5J      $��Center=�6   .+�5K   
   �� $��Abrir Fichaje��66   ��6   �� *StartWorkCommand+{�6N   �� *IsStartWorkEnabled+�� 5L   
   $��0,20,0,0q�6�   ��6   �� *BreakCommand+��62   �� *BreakButtonText+{�6V   �� *IsLoggedInEmployeeOnWork+6�   �� 5M   
   ���#FFFFFF
��� E��$ -Selec. Motivo-��6?   $��Center=�6p   $��0,0,0,20q�6�   $
	 TrueY�5O      ��5N      �� *BreakOptionsList+ 5P      �� *SelectedReasonIndex+{�5Q      �� *IsLoggedInEmpNotOnBreak+�� 5R   
   $��Cerrar Fichaje��64   ��6   �� *EndWorkCommand+{�6M   �� *IsLoggedInEmployeeOnWork+5S   	   5T      � 5U      .+�5V       � -   5        $��framePrincipal��5V      
�������  � NavigationUIVisibility$ Hidden=�67   ��6W   �� *CurrentView+5W      5X      5Y      