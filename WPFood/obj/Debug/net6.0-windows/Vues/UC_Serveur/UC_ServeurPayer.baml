   M S B A M L   `   `   `  ����A  =WPFood, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:WPFood.VuesModeles.VM_ServeurWPFood.VuesModeles.VM_Serveur  5      ,    &WPFood.Vues.UC_Serveur.UC_ServeurPayer   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _MaterialDesignThemes.MahApps, Version=0.2.5.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5      Fmc;http://schemas.openxmlformats.org/markup-compatibility/2006   5      >
vm_serveur+clr-namespace:WPFood.VuesModeles.VM_Serveur   5         Sapphire#���   5        � 	Resources  5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $f `pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Button.xaml?�6%   �� 5      $i cpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.TextBlock.xaml?�6%   %    5      .��5      � -   5          5   
    �� 
TargetType �� Property  American_Silver �� Value��%U   '��       �� 5      " ��6   .�5      ��  � ��# �  6/   6[   5      5       � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5       $
��auto �6    � ColumnDefinitions 5#   
   �� 5$      $��1* �6   �� 5%      $��2* �6   �� 5&      $��1* �6   .+�5*   
   �� $��Paiement��5+      $��	0,10,0,50q�5,      $��	Underline{�5-      $��3��5.      $��Center=�5/      $��Center=�50      
������� $  MaterialDesignHeadline1TextBlock#���  52      �� 54   
   $��1��6   $��
10,0,10,10q�6"   .+�55      �� $��Clients de la table��6   $��Center=�56      $��50(�57      
�������$��DemiBold"�59      6,   �� 5:      -   5         ��Name$ 	LVClients��5=      $��2��5<      	 �� SelectionMode$	 Multiple=�5>      
������ ��5;      �� *	Clients+��5@      �� 5A      " ��6   .�5B      ��  � ��$	 150��65   �� 5C       � ��$	 100��66   �� 5D       � ��$ Stretch=�6G   �� 5E       � ��$
 auto��62   �� 5F       � ��$ 40(�65   �� 5G       � ��$ 10q�63   -   5        5I      5K      5L      �� 5N   
   $��1��6   $��1��6"   .+�5O      �� $��Résumer de la commande��6   $��Center=�5P      $��50(�5Q      
�������$��DemiBold"�5S      6,   &   System.Windows.Controls.DataGrid  5T      -   5        $��dg_ItemsCommande��5U      $��10q�5V      
   AutoGenerateColumns$
 False��5W         
IsReadOnly$
 True��5X         HeadersVisibility$	 All=�5Y      
������ #��[ 5[      $��40(�5\      ��5T      �� *ItemsClient+   Columns 5]      0  *System.Windows.Controls.DataGridTextColumn  5^      ,  &System.Windows.Controls.DataGridColumn   Header$
 Item��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 67      
Foreground# �  5_   )   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5`   )   �� *Nom+   ElementStyle 5b      �� 5c      " ��6$   .�5d   "   ��  � ��$
 Left=�6H   5e      5g        5i      $ 	Quantité��6)   $ * 6;    5j   )   �� *
Quantite+  5l      $ Prix unitaire��6)   $ * 6@    5m   )   �� *Prix+ �� StringFormat$ 	{0:C0}.00�� 5n      �� 5o      " ��6$   .�5p   "   ��  � ��$ Right=�6H   5q      5s      5u      5y      �� 5{   
   $��1��6   $��2��6"     5|      ��%t   '��       �� 5}      " ��6   .�5~      ��  � ��$ 20(�61   �� 5       � ��# �  63   5�      5�      .+�5�      �� $��Facture��6   $��Center=�5�      $��DemiBold"�5�      $��50(�5�      
�������5�   )   � 5�      .+�5�      �� -   5        $��lbl_sousTotal��5�      $��Sous-Total: ��5�      $��45(�5�      
�������5�   -   �� 5�       �� ContentStringFormat$ C��66   $��45(�6N   ��6   �� *	SousTotal+5�      5�      � 5�      .+�5�      �� -   5        $��lbl_TPS��5�      $��TPS: ��5�      
�������$��45(�5�      5�      �� 5�      $ C��67   $��45(�6O   ��6   �� *
MontantTPS+5�      5�      � 5�      .+�5�      �� -   5        $��lbl_TVQ��5�      $��TVQ: ��5�      
�������$��45(�5�      5�      �� 5�      $ C��67   $��45(�6O   ��6   �� *
MontantTVQ+5�      5�      � 5�      .+�5�      �� -   5        $��	lbl_Total��5�      $��Total: ��5�      
�������$��45(�5�      5�      �� 5�      $ C��62   $��45(�6J   ��6   �� *Total+5�      5�      �� 5�      -	   5         ��Name$ 	btn_payer��5�      $��Payer��5�      $��10q�5�      $��55��5�      $��35(�5�      +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 15��5�      5�      �� 5�      -
   5        $��
btn_retour��5�      $��Retour��5�      $��10q�5�      $��55��5�      $��35(�5�      ���#D64161$ 13��5�      �� 5�      -   5        $��btn_demandeDeNettoyage��5�      $��Demande de nettoyage��5�      $��10q�5�      $��55��5�      $��35(�5�       	 Dijon#���  5�      $ 13��5�      5�      5�      5�      