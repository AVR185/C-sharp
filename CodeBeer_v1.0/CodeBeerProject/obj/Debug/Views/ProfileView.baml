   M S B A M L   `   `   `  ����J  FCodeBeerProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:CodeBeerProject.ViewsCodeBeerProject.Views  5      '    !CodeBeerProject.Views.ProfileView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:CodeBeerProject.Views     5      U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        N� Title$  ProfileView��5
      .��5      � $��20q�6	   .+�5      ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  -   5          Name$ TrainsitionigContentSlide��5   *   C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffect 6M   D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension     Kind$ FadeIn=�   Duration$ 0:0:0.8X�.��5      #  MaterialDesignThemes.Wpf.Card  .��5   
   � $��1��6   ���	#FFFFBEA3.+�5      �� $	��150��6   $	��Top=�6   $&�� /Images/back_material_design.jpg��67   $��UniformToFill=�6a   A� 5      $	��100��6   $	��100��6!   $	��Top=�6-   $��Right=�6E   $��20 100q�6a   
���������5      �� 5       �� ImageSource$ ../Images/usuario.png��6    j� Stretch$ UniformToFill=�6?   5      �� 5      
�������$��32(�6B   $��Nirmala UI Semilight)�6P   $��15 25q�6r   $	��Top=�6�   ��6   �� *	EmpName+6�   �� 5      
�������$��26(�6A   $��Nirmala UI Semilight)�6O   $��15 100q�6q   $	��Top=�6�   ��6   �� *EmpJob+6�   '  !MaterialDesignThemes.Wpf.PackIcon  5         Kind$
 Edit=�6$   $��15q�60   
�������$��Right=�6O   $��25��6k   $��25��6w    � ToolTip$ Editar Datos��6�   � 5      $��20 175 20 20q�6   	 � ColumnDefinitions	 5      �� 5      $��* �6!   �� 5      $��* �6!   
 � RowDefinitions
 5      �� 5       $
��Auto �6   �� 5!      $
��Auto �6   �� 5"      $
��Auto �6   .+�5$      ��  �� Orientation$ 
Horizontal=�6   .+�5%        $ CalendarAccount=�6(   $��15q�6?   $��25��6K   $��25��6W   �� 5&      $��Center=�6   .+�5'      �� $��Fecha Nacimiento:��6   $	��Top=�65   
�������6M   �� 5(      $��Bottom=�69   $
��Bold"�6T   $��14(�6f   ��6   �� *DateOfBirth+6f   5)      5*      �� 5+      $ 
Horizontal=�6   $��1��62   .+�5,        $ AccountCardDetails=�6(   $��15q�6B   $��25��6N   $��25��6Z   �� 5-      $��Center=�6   .+�5.      �� $
��DNI:��6   $	��Top=�6(   
�������6@   �� 5/      $��Bottom=�66   $
��Bold"�6Q   $��14(�6c   ��6   �� *
NumberId+6c   50      51      �� 52      $ 
Horizontal=�6   $��1��62   .+�53        $ 	MapMarker=�6(   $��15q�69   $��25��6E   $��25��6Q   �� 54      $��Center=�6   .+�55      �� $��Dirección:��6   $	��Top=�6.   
�������6F   �� 56      $��Bottom=�65   $
��Bold"�6P   $��14(�6b   ��6   �� *	Address+6b   57      58      �� 59      $ 
Horizontal=�6   $��1��62   $��1��6?   .+�5:        $ At=�6(   $��15q�62   $��25��6>   $��25��6J   �� 5;      $��Center=�6   .+�5<      �� $��Email:��6   $	��Top=�6*   
�������6B   �� 5=      $��Bottom=�63   $
��Bold"�6N   $��14(�6`   ��6   �� *Email+6`   5>      5?      �� 5@      $ 
Horizontal=�6   $��2��62   .+�5A        $ Phone=�6(   $��15q�65   $��25��6A   $��25��6M   �� 5B      $��Center=�6   .+�5C      �� $��Teléfono 1:��6   $	��Top=�6/   
�������6G   �� 5D      $��Bottom=�64   $
��Bold"�6O   $��14(�6a   ��6   �� *Phone1+6a   5E      5F      �� 5G      $ 
Horizontal=�6   $��2��62   $��2��6?   .+�5H        $ Phone=�6(   $��15q�65   $��25��6A   $��25��6M   �� 5I      $��Center=�6   .+�5J      �� $��Teléfono 2:��6   $	��Top=�6/   
�������6G   �� 5K      $��Bottom=�64   $
��Bold"�6O   $��14(�6a   ��6   �� *Phone2+6a   5L      5M      5N      5O      5P   	   5Q      5R      5S      