   M S B A M L   `   `   `  ����A  =WPFood, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:WPFood.Vues.UC_Admin.Menu_et_Items"WPFood.Vues.UC_Admin.Menu_et_Items  5      8    2WPFood.Vues.UC_Admin.Menu_et_Items.UC_ModifierMenu   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Blocal0clr-namespace:WPFood.Vues.UC_Admin.Menu_et_Items     5        � 	Resources  5	       �� 
TargetType �� Property �� Value   MaterialDesignComboBox �� BasedOn  Sapphire  MaterialDesignTextBox��%^  '��       '�� n     7   7  '�� �     7  �� 5
   
   " ��6   .�5      ��  � ��
 �����6+   �� 5       � ��$ 18(�6)   5      �� 5   
   " ��6   8   .�5      ��  � ��$ 20(�6)   �� 5       �@J�OpacityMask8  6,   5      �� 5   
   " ��6   8   .�5      ��  � ��$ 20(�6)   5      5      .��5      � -   5        $��10q�5        � RowDefinitions 5   
   �� 5      $	��200 �6   �� 5      $��* �6   �� 5      $	��100 �6    � ColumnDefinitions 5   
   �� 5      $	��750 �6   �� 5       $	��350 �6   �� 5!      $��* �6   .+�5$   
   � .+�5%      �� -   5         ��Name$ 	bntRetour��5%      $��Retour��6(   $
��auto��69   $��60��6F   $��40(�5&   -   5'      �� 5)   
   $��0��6   $��Center=�6"   $��3��6?   .+�5*      �� -   5        $��txbNomMenuModif��5*   )   $��	MenuTempo��6    $  MaterialDesignHeadline2TextBlock#��[ 6@   
�������6z   � 5,      .+�5-      �� $��Nom du menu : ��6   �� 5.      -   5        $��
txbNomMenu��5.      $	��180��6,   $
��auto��68   
�������6F   5/      � 50      .+�51      �� $��Saison du menu : ��6   �� 52      -   5        $��	cmbSaison��52   '   $	��150��6   
�������.@�53      �� $��Été��6#   �� 54      $��Hiver��6#   �� 55      $��	Printemps��6#   �� 56      $��Automne��6#   57      58      � 5:      .+�5;      �� $��Catégorie du menu : ��6   �� 5<      -   5        $��cmbCategorie��5<   '   $	��150��6   
�������.@�5=      �� $��Dîner��6#   �� 5>      $��	Déjeuner��6#   �� 5?      $��Souper��6#   �� 5@      $��Entrée��6#   �� 5A      $��Desert��6#   5B      5C      5D      �� 5E   
   $��Menu Sélectionné��6   $��30(�6+   $��1��69   $��Center=�6F   � 5F   
   $��1��6   $��0,50,0,0q�6   .+�5G      &   System.Windows.Controls.DataGrid  -   5        $��dg_ItemMenu��5M      $��3��5G      $��1��5H         AutoGenerateColumns$ False��5J      
���   �	   
IsReadOnly$
	 True��5L      $	��750��5N      $��23(�5O      #��[ 5P      $
��True��5Q      ��5I      �� *
ListeItems+
   RowStyle
 5T      �� 5U      )  #System.Windows.Controls.DataGridRow"  6    �� Triggers 5V      P� 5W       P� Property �@ 
IsSelected P� Value$
 True��6<   . �5X   "   ��  � ��  American_Silver# [ 6?   5Y      5[        5^      =  7System.Windows.Controls.Primitives.DataGridColumnHeader  Light_Slate_Gray��%x   '        7  �� 5_      "  6   .�5`      ��  � ��
 �����67   �� 5a       � ��8   67   5b      5c         Columns 5e      0  *System.Windows.Controls.DataGridTextColumn  5f      ,  &System.Windows.Controls.DataGridColumn   Header$ Nom de l'item��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6@   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6J   �� *Nom+  5g      $ Catégorie de l'item��6)   $	 300 6F    6R   �� *	Categorie+  5h      $
 Prix��6)   $	 100 67    6C   �� *Prix+ �� StringFormat$ {0:c}��   ElementStyle 5i      �� 5j      " ��6$   .�5k   "   ��  � ��$ Right=�6H   5l      5n      5p      5q      �� 5t   
   $��Center=�6   $��1��60   $��1��6@   $��20,0,0,0q�6M   .+�5v      �� -   5        $��btnAjouterAuMenu��5w   J   $��Ajouter item(s) menu��5v      $
��auto��64   $
��auto��6A   $��26(�6O   $��0,0,0,50q�5w   8   6J   �� 5y      -	   5        $��btnSupprimerDuMenu��5z   4   $��Supprimer item(s) menu��5y      $��26(�66   $
��auto��5z      $
��auto��6&   64   5{      � 5}   
   $��1��6   $��2��6!   $��Center=�61   .+�5�      �� $��Right=�6   $	��Top=�65   .+�5�      �� $��Items Disponible��6   $��Center=�63   $��30(�6P     5�      -
   5        $��dg_ItemDispo��5�      $��3��5�      $��1��5�      $ False��5�      $
	 True��5�         SelectionMode$ Extended=�5�      $	��750��5�      
���   �$	��570��5�      $��23(�5�      #��[ 5�      $
��True��5�      ��5�      �� *ListeItemsComplet+
 5�      �� 5�      "  6     5�      P� 5�   "    �@ 
IsSelected$
 True��6@   . �5�   &   ��  � ��# [ 6C   5�   #   5�        5�      ��%x   '        7  �� 5�      "  6    .�5�      ��  � ��
 �����6;   �� 5�       � ��8   6;   5�      5�       5�        5�      $ Nom de l'item��6-   $ * 6D    6N   �� *Nom+  5�      $ Catégorie de l'item��6-   $	 300 6J    6V   �� *	Categorie+  5�      $
 Prix��6-   $	 100 6;    6G   �� *Prix+$ {0:c}�� 5�      �� 5�   "   " ��6(   .�5�   &   ��  � ��$ Right=�6L   5�   #   5�      5�      5�      5�      � 5�   
   $��2��6   $��Center=�6!   $��Center=�6>   $��3��6Y   .+�5�      �� -   5        $��btnEnregistrerModif��5�   9   $��Enregistrer Modifications��6   $��
10,0,300,0q�5�      $��50��6)   $��25(�65   $
��auto��6C   6P   �� 5�      -   5        $��
btnAjouter��5�   -   $��Créer un Item��6   $��	10,0,10,0q�6?   $��25(�5�   3   $
��auto��6A   $
��auto��6N   �� 5�      -   5        $��btnModifier��5�   6   $��Modifier un Item Dispo��6   $��	10,0,10,0q�6I   $��25(�5�   6   $
��auto��6D   $
��auto��6Q   �� 5�      -   5        $��btnSupprimer��5�   7   $��Supprimer un Item Dispo��6   $��	10,0,10,0q�6K   $��25(�5�   <   $
��auto��6J   $
��auto��6W   5�      5�      5�      