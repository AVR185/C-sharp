   M S B A M L   `   `   `  ����J  FCodeBeerProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:CodeBeerProject.ViewsCodeBeerProject.Views  5      %    CodeBeerProject.Views.LoginView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      U QMaterialDesignThemes.Wpf, Version=3.0.1.920, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      /local#clr-namespace:CodeBeerProject.Views  5        N� Title$  	LoginView��5
      .��5      � .+�5      �� $	��280��6   $	��Top=�6   ��5      �� 5   
    �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6/   .��5      �  � Color$ 	#FFFFE94F��6   � 5      $ 	#FFFF7E13��6    � Offset$ 1Q�6+   � 5      $ 	#FFFF9C33��6   $ 0.546Q�6+   5      5      �� 5      $	��280��6   $	��240��6   $��Bottom=�6)   $
��0,80q�6D    �� RadiusY$ 10��6R    �� RadiusX$ 10��6_   
������� J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5   
      
BlurRadius$ 15Q�6   	   	Direction$	 0Q�6+   
   RenderingBias$
 Quality=�69      ShadowDepth$ 1Q�6Q      Color$ 	#FFBBBBBB��6a   5      � 5      $��Bottom=�6   $��35,80q�6&   $	��240��65   $	��280��6B   .+�5      �� $��Iniciar Sesión��6   $��Center=�6'   $	��Top=�6D   $��5q�6\   
�������$��18(�6y   �� 5      $��Center=�6   $��15q�6.   .+�5   
   �� $
��0,10q�6   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Id Empleado��68    %  !MaterialDesignFloatingHintTextBox#��[  6e   $��Champagne & Limousines)�6�   $��15(�6�   ��6    �� *UserId+6�   G� 5    
   -   5         G�Name$ passwordBox��5       $
��0,10q�6+   $ Contraseña��69    ) %MaterialDesignFloatingHintPasswordBox#��[ 6e   $��Champagne & Limousines)�6�   $��15(�6�   5!   	   5"      �� 5#      -   5        $��
botonLogin��5#      $	��150��6   $��Center=�6+   $��Bottom=�6H   $
��0,65q�6c   $��Aceptar��6q   ��6�   �� *LoginCommand+��6�   ��  �� ElementName$ passwordBox���� 5$      -   5        $��informacion��5$      $��Center=�6@   $��Bottom=�6]   $��30q�6x   
������� � Cursor$
 Hand��6�   ��6#   �� *Information+6�   A� 5%      $	��100��6   $	��100��6   $	��Top=�6'   $��20q�6?   ��5&      �� 5'   
    �� ImageSource$ ../Images/logotipo.png��6   5)      5*      5+      