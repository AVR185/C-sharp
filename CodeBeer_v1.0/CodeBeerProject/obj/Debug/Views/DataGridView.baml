   M S B A M L   `   `   `  ����J  FCodeBeerProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:CodeBeerProject.ViewsCodeBeerProject.Views  5      ?$clr-namespace:CodeBeerProject.ModelsCodeBeerProject.Models  5      (    "CodeBeerProject.Views.DataGridView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:CodeBeerProject.Views     5      7vrules$clr-namespace:CodeBeerProject.Models     5        N� Title$  PageDataGrid��5
      .��5      ]� 
�������.+�5      �� $��Bottom=�6    �� Orientation$ 
Horizontal=�6)   $��Center=�6B   {�6_   �� *LoggedInEmployee.IsAdmin+.+�5      �� $��Nuevo��64   ��6   �� *NewRecordCommand+64   �� 5      $��Guardar��65   $��	20,0,20,0q�6G   ��6   �� *SaveRecordCommand+6G   �� 5      $��Eliminar��67   ��6   �� *DeleteRecordCommand+67   5      &   System.Windows.Controls.DataGrid  5      -   5          Name$ detailDataGrid��5         AutoGenerateColumns .     CanUserAddRows .  $ �� IsSynchronizedWithCurrentItem$
 TrueY�5      ��5   '   �� *CheckInOutList+   
IsReadOnly 5      �� *IsDataGridViewReadOnly+ �� SelectedItem 5      �� *SelectedRecord+ � 	Resources 5         
errorStyle	 �� 
TargetType
 �� Property �� Value �� Triggers P� Property P� Value �� RelativeSource �� Path��%#  &	        �� 5   
   "	 ��6#   .�5      �� 
 � ��$ -2q�6&    5      P� 5       �@=�HasError . . �5      �� 
 � ��
 �  ��6-   �� 5      
 �@�ToolTip 5      ��  �� *Self+$) #(Validation.Errors)[0].ErrorContent�5!      5#      5$   	      Columns 5%      0  *System.Windows.Controls.DataGridTextColumn  5&   
   ,  &System.Windows.Controls.DataGridColumn   Header$ Id Empleado��6   1  +System.Windows.Controls.DataGridBoundColumn   EditingElementStyle# [  62      Binding 5'      �� 5(      $ EmpCode�6    �� ValidatesOnExceptions .  �� UpdateSourceTrigger$ PropertyChanged=�6B    �� ValidationRules 5)      3  -CodeBeerProject.Models.EmployeeValidationRule  5*      5,      5.        5/   
   $ Comienzo Trabajo��6   # [  67    50      �� 51      $ 	BeginWork�6    . $ PropertyChanged=�6D    52      /  )CodeBeerProject.Models.DateValidationRule  53      55      57        58   
   $ Fin Trabajo��6   # [  62    59   
   �� 5:      $ EndWork�6    . $ PropertyChanged=�6B    5;        5<      5>      5@        5A   
   $ Id Descanso��6   # [  62    5B      �� 5C      $ 	BreakCode�6    . $ PropertyChanged=�6D    5D      4  .CodeBeerProject.Models.BreakCodeValidationRule  5E      5G      5I        5J   
   $ Comienzo Descanso��6   # [  68    5K      �� 5L      $ 
BeginBreak�6    . $ PropertyChanged=�6E    5M        5N      5P      5R        5S   
   $ Fin Descanso��6   # [  63    5T      �� 5U      $ EndBreak�6    . $ PropertyChanged=�6C    5V        5W      5Y      5[      5]      5^      5_      