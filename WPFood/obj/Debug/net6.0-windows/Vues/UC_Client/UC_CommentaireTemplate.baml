   M S B A M L   `   `   `  ����A  =WPFood, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:WPFood.Vues.UC_ClientWPFood.Vues.UC_Client  5      2    ,WPFood.Vues.UC_Client.UC_CommentaireTemplate   5      c _MaterialDesignThemes.MahApps, Version=0.2.5.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:WPFood.Vues.UC_Client     5         Sapphire#���   5      $	��800��6G   $	��150��6S   $
��auto��6c   .��5      #  MaterialDesignThemes.Wpf.Card  $��10q�5	   	     Jean#��[ 5
   	   .  (MaterialDesignThemes.Wpf.ElevationAssist    	Elevation$
  Dp16=�5   	   .��5   
   �  � ColumnDefinitions 5      �� 5      $��2* �6#   �� 5      $��3* �6#   .+�5      �� $��5,5,0,0q�6   $��0��6*   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� -   5        $��lbl_NomClient��5        $  MaterialDesignHeadline4TextBlock#���  5   %   $��	Underline{�5   %   
���������5   %   �� *	NomClient+5   %   5      � 5      $��0,5,0,0q�6   .+�5      �� -   5        $��lbl_ServisPar��5       $��	Serveur: ��5   !    $  MaterialDesignHeadline6TextBlock#���  5   !   
�������5    !   �� 5"      -   5        $��lbl_NomServeur��5"        % !MaterialDesignHeadliner1TextBlock#���  5$   %   $��20(�5%   %   
���������5#   %   �� *
NomServeur+5&   %   5'      � 5)      .+�5*      �� -   5        $��	base_text��5*       $��Écrit le : ��5+       
������� $  MaterialDesignSubtitle1TextBlock#���  5-       $��18(�5.       $
��Bold"�5/       �� 53      -   5        $��lbl_DateCommentaire��53       
�������#���  57   )   $��18(�58   )   ��54   )   �� *DateMessage+ �� StringFormat$ d��58   )   5:      �� 5;      $ 
Horizontal=�6   .+�5=      �� 
�������#���  5@      $��15(�5A      ��5>      �� *TextRecommandation+5A      '  !MaterialDesignThemes.Wpf.PackIcon  5C      -   5          Name$ 
MyPackIcon��5D      $��40��5E      $��25��5F      $��0,0,0,5q�5G         Kind 5H      �� *Icon+5I      5K      �� 5M      -   5        $��txb_ContenuMessage��5M      $��1��62   $
��Wrap=�5O      $��5q�5P      
�������$��30(�5R         MaterialDesignBody1TextBlock#���  5S      ��5N      �� *ContenuMessage+5S      5U      5V      5W      