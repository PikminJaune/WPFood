   M S B A M L   `   `   `  ����A  =WPFood, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:WPFood.Vues.UC_ConnexionWPFood.Vues.UC_Connexion  5      +    %WPFood.Vues.UC_Connexion.UC_Connexion   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _MaterialDesignThemes.MahApps, Version=0.2.5.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5      4local&clr-namespace:WPFood.Vues.UC_Connexion   5      $	��800��5	      $	��920��6   .��5      �   � RowDefinitions  5   
   �� 5      $	��400 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $	��180 �6    � 	Resources 5   
    �� 
TargetType �� Property �� Value��%~   '�       �� 5      " �6   .�5      ��  � ��$ Center=�66   �� 5       � ��$ Center=�68   5      5      .+�5   
   �� $7��1https://wpfood.techinfo-cstj.ca/Assets/Fonts/#Spy)�6   $��WPFood��5      $��Center=�5      $��Center=�5         
CustomFont#��[  5      5!      �� 5%   
    �� Orientation$ 
Horizontal=�6   $��1��6.   $��	0,10,0,10q�6;   $��Center=�6N   .+�5'      '  !MaterialDesignThemes.Wpf.PackIcon  $��90��5(      $��90��5)      $��Right=�5*      $��Center=�5+      
�������   Kind$ UserOutline=�5-      �� 5/      -   5         ��Name$ txbUtilisateur��50      $��5,0,0,0q�5/      $��Center=�51      $
��Left=�52       ! MaterialDesignOutlinedTextBox#���  54        Sapphire)  #MaterialDesignThemes.Wpf.HintAssist   
Background# �  55      
�������$��50(�57      $	��500��58      	   Hint$	 Utilisateur��59      ��53      �� *	NomClient+59      5;      �� 5=   
   $��2��6   $��	0,20,0,10q�6"   $��Center=�65   $��Center=�6R   $ 
Horizontal=�6m   .+�5>        -   5        
  Name$
 
MyPackIcon��5?      $��90��5@      $��90��5A      $��Right=�5B      $��Center=�5C      
�������$ PasswordOutline=�5E      G� 5G      -   5        $��pwbPassword��5H      $��5,0,0,0q�5I      $��Center=�5J      $
��Left=�5K      $	 Mot de passe��5L      
�������$��50(�5N      $	��500��5O      # �  5P       % !MaterialDesignOutlinedPasswordBox#��[ 5R      5S      �� 5U   
   -   5         ��Name$ btnConnexion��5U      $��3��6   $��50(�5V       �� 	IsDefault$
 True��6'   $��80��5W      +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 15��5Y      .��5Z      � .+�5[      �� $��	Connexion��6     5\      $ LoginVariant=�6*   $��75��5]   *   $��75��5^   *   $��10,0,0,0q�5_   *   5`      5a      5b      5c      