   M S B A M L   `   `   `  ����J  FCodeBeerProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:CodeBeerProject.ViewsCodeBeerProject.Views  5      &     CodeBeerProject.Views.DetailView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:CodeBeerProject.Views     5      U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        N� Title$  
DetailView��5
      .��5      � $��20q�6	   .+�5      ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  -   5          Name$ TrainsitionigContentSlide��5   *   C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffect 6M   D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension     Kind$ FadeIn=�   Duration$ 0:0:0.8X�.��5      #  MaterialDesignThemes.Wpf.Card  .��5   
   � .+�5      �� $	��170��6   $	��Top=�6   $'��!/Images/back_material_design1.jpg��67   $��UniformToFill=�6b   (� 5       (� StretchDirection$
 Both=�6    (� Stretch$ Uniform=�6,   $
��Left=�6>   $	��Top=�6Y   $��
125,10,0,0q�6q   $	��150��6�   .��5      ,   &CodeBeerProject.Views.UserControlReloj  5      �� 5       �� Orientation$ 
Horizontal=�6   $��Right=�60   $��0,70,100,270q�6L   .+�5      �� $��Último Fichaje: ��6   $��14(�60   $��Center=�6>   $
��Bold"�6Y   �� 5      $
��Bold"�6L   $��18(�6^   $��Center=�6l   ��6   ��  �� Path$
 Date�	 �� StringFormat$	 
dd-MM-yyyy��6l   5      � 5      $��1��6   $��20,175,20,20q�6   
 � ColumnDefinitions
 5      �� 5      �� 5       � RowDefinitions 5      �� 5      �� 5      �� 5       �� 5!      .+�5#      �� $ 
Horizontal=�6   .+�5$      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ WatchImport=�6(   $��	15,0,10,0q�6<   $��Center=�6O   �� 5%      $��Hora Inicio: ��6   $��Center=�6/   �� 5&      $��Center=�65   $
��Bold"�6P   $��16(�6b   ��6   �� *	EntryTime+6b   5'      �� 5(      $ 
Horizontal=�6   $��1��62   .+�5)        $ TimerSandEmpty=�6(   $��	15,0,10,0q�6>   $��Center=�6Q   �� 5*      $"��Total horas trabajadas hoy: ��6   $��Center=�6>   �� 5+      $��Center=�69   $
��Bold"�6T   $��16(�6f   ��6   �� *TotalHoursDay+6f   5,      �� 5-      $��1��6   $ 
Horizontal=�6&   $��0,0,0,15q�6?   .+�5.        $ WatchExport=�6(   $��	15,0,10,0q�6;   $��Center=�6N   �� 5/      $��Hora Cierre: ��6   $��Center=�6/   �� 50      $
��Bold"�64   $��16(�6F   $��Center=�6T   ��6   �� *
ExitTime+6T   51      �� 52      $ 
Horizontal=�6   $��1��62   $��1��6?   $��0,0,0,15q�6O   .+�53        $ 	TimerSand=�6(   $��	15,0,10,0q�69   $��Center=�6L   �� 54      $(��"Total horas trabajadas en el mes: ��6   $��Center=�6D   �� 55      $
��Bold"�6;   $��16(�6M   $��Center=�6[   ��6   �� *TotalHoursMonth+6[   56      �� 57      $ 
Horizontal=�6   $��2��62   $��2��6?   $��0,15,0,0q�6S   .+�58        $ ClockAlertOutline=�6(   $��	15,0,10,0q�6A   $��Center=�6T   �� 59      $��Pausa realizada: ��6   $��Center=�63   �� 5:      $
��Bold"�67   $��16(�6I   $��Center=�6W   ��6   �� *BreakReason+6W   5;      �� 5<      $��3��6   $ 
Horizontal=�6&   $��Center=�6?   .+�5=      �� $��
Comienzo: ��6   $��Center=�6,   �� 5>      $
��Bold"�6:   $��16(�6L   $��Center=�6Z   ��6   �� *BreakStartTime+6Z   5?      �� 5@      $��3��6   $��1��6&   $ 
Horizontal=�66   .+�5A      �� $��Fin: ��6   $��Center=�6'   �� 5B      $
��Bold"�68   $��16(�6J   $��Center=�6X   ��6   �� *BreakEndTime+6X   5C      5D      5E      5F   	   5G      5H      5I      