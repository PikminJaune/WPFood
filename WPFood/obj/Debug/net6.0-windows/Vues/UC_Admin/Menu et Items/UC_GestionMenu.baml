   M S B A M L   `   `   `  ����A  =WPFood, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:WPFood.Vues.UC_AdminWPFood.Vues.UC_Admin  5      )    #WPFood.Vues.UC_Admin.UC_GestionMenu   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:WPFood.Vues.UC_Admin     5      .��5      � -   5          � RowDefinitions  5   
   �� 5      $	��100 �6   �� 5      $��* �6   �� 5      $��90 �6   .+�5   
   �� -   5        $��Retour au menu admin��5      $��0��60   $
��auto��6=   $
��auto��6K   $	��Top=�6X   $
��Left=�5      $��40(�6J   �� 5   
   $��Gestion des menus��6   $��0��6-   $��Center=�6:   $��Center=�5      $��	Underline{�61    $   MaterialDesignHeadline1TextBlock#��[  6M   
�������5      � 5   
   $��1��6   $��0,10,0,0q�6   .+�5      &   System.Windows.Controls.DataGrid  -   5        $��dg_Menus��5"      $��3��5      $��1��5         AutoGenerateColumns$ False��5          
IsReadOnly$
 True��5!      $��25(�5$        Sapphire#��[ 5%         SelectionMode$ Single=�5&      ��5      �� *	ListeMenu+ �� SelectedItem 5#      �� *MenuSelectionner+   RowStyle 5*      �� 5-       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6   .�5.      ��  �� Property � �� �� Value
 �   �67   	 �� Triggers	 5/      P� 50      
 P� Property
 �@ 
IsSelected P� Value$
 True��6<   . �51   "   ��  � ��  American_Silver# [ 6?   52      55       � 	Resources 58      =  7System.Windows.Controls.Primitives.DataGridColumnHeader  Light_Slate_Gray��%�   '        7  �� 59      "  6   .�5:      ��  � ��
 �����67   �� 5;       � ��$ 35(�65   �� 5<       � ��8   67   5=      5?         Columns 5A      0  *System.Windows.Controls.DataGridTextColumn  5B      ,  &System.Windows.Controls.DataGridColumn   Header$ Nom du Menu��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6V   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6>   �� *Nom+6V     5C      $ Catégorie du Menu��6)   $ * 6b    6D   �� *	Categorie+6b     5D      $ Saison du Menu��6)   $ * 6\    6A   �� *Saison+6\   5F      5G      � 5H   
   $��2��6   .+�5I      � $��Center=�6   $��Center=�65   .+�5K      �� -   5        $��Nouveau Menu��5K      $
��auto��60   $
��auto��6>   $��	0,0,100,0q�5L      $��40(�6,   6:   �� 5N      -   5        $��btnModifierMenu��5P   '   $��Modifier Menu��5N      $
��auto��61   $
��auto��6>   $��	0,0,100,0q�5O      $��40(�6,    � Cursor$
 Hand��5P      6'   �� 5R      -   5        $��btnSupprimerMenu��5T      $��Supprimer Menu��5R      $
��auto��62   $
��auto��6?   $��40(�5S      $
 Hand��5T   1   ��5S   '   �� *cmdSupprimerMenu_Menu+5T   1   5U      5V      5X      5Y      