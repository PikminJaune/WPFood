   M S B A M L   `   `   `  ����A  =WPFood, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:WPFood.Vues.UC_ClientWPFood.Vues.UC_Client  5      0    *WPFood.Vues.UC_Client.UC_ClientCommentaire   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _MaterialDesignThemes.MahApps, Version=0.2.5.0, Culture=neutral, PublicKeyToken=df2a72020bd7962a_ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aHmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes   5      1local#clr-namespace:WPFood.Vues.UC_Client   5         Sapphire#���   5	      .��5
      � $��Center=�6   $��Center=�5      $
��1250��5        � ColumnDefinitions  5   
   �� 5      $��1* �6   �� 5      $��2* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��6* �6   .+�5   
   �� $��2��6   $��Commentaire Client��5      $��Center=�5      $��Center=�5       $  MaterialDesignHeadline1TextBlock#���  5      
�������$��	Underline{�5      �� 5    
   -   5        $��SP_EntrerCommentaire��5!      $��0��5       $��	15,15,0,0q�5"      $��1��5#      .+�5%      �� -   5         ��Name$ tbox_nomClient��5&      $��Center=�5'      $
��Left=�5(       ! MaterialDesignOutlinedTextBox#���  5*      )  #MaterialDesignThemes.Wpf.HintAssist   
Background# �   5+      
�������$��35(�5-       �� 	MaxLength$ 10��5.         Hint$ Entrez votre nom��5/      ��5)      �� *	NomClient+5/      �� 51      -   5        $ tb_CommentaireClient��52       �� TextWrapping$
 Wrap=�53       �� AcceptsReturn$ False��54       �� 
AcceptsTab$
 True��55      $	��160��56      $	��160��57      $��0,40,0,0q�58      $	 100��59      $��30(�5:      
�������"	 �� VerticalScrollBarVisibility$
	 Auto=�5<      $ Entrez votre commentaire��5=      # �   5>      #��[ 5?      ��5@      �� *ContenuCommentaire+�� 5B      -   5        $��cb_serveurs��5C      $��	5,10,5,20q�5D      $��Center=�5E      $
��Left=�5F       & "MaterialDesignFloatingHintComboBox#���  5I      
�������$��35(�5K      $ Choisir votre serveur��5M      ��5G      �� *NomsServeurs+
 �� SelectedValue
 5H      �� *NomServeurSelectionne+5M      � 5O      $��	0,20,0,20q�6   $��Center=�6+   .+�5P      �� $��En date du: ��6    $  MaterialDesignHeadline3TextBlock#���  5Q      
�������$��35(�5S      �� 5T      -   5        $��lbl_currentDate��5U      #���  5X      
�������$��35(�5Z      ��5V      �� *DateCommentaire+ �� StringFormat$  {0:MMMM dd, yyyy hh:mm;ss}��5Z      5[      �� 5]      $��Center=�6   $(��"Recommanderiez-vous nos services ?��5^         MaterialDesignBody2TextBlock#���  5_      
�������$��22(�5a      �� 5c      $��5q�5d       �� Orientation$ 
Horizontal=�5e      $��Center=�5f      .+�5g      	� -   5        $��rbRecommande��5h      $��5q�5i       d� 	IsChecked$
 TrueY�5j         MaterialDesignTabRadioButton#��[ 5l      .��5m      �� .+�5n      '  !MaterialDesignThemes.Wpf.PackIcon  $��Center=�5o         Kind$ ThumbsUp=�5p      $��30��5q      $��30��5r      �� 5s      $��5q�5t      $��Oui !��5u      5v      5w      	� 5y      -   5        $��rbNonRecommande��5{      $��5q�5z      #��[ 5}      .��5~      �� .+�5        $��Center=�5�      $ 	ThumbDown=�5�      $��30��5�      $��30��5�      �� 5�      $��5q�5�      $��Non !��5�      5�      5�      5�      �� 5�      -   5         ��Name$ btn_EnvoyerCommentaire��5�      $��	20,0,20,0q�5�      +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 15��5�      $��48��5�      $
��auto��5�      $��25(�5�      ��5�      �� *cmdInsererCommentaire+.��5�      � .+�5�      �� $��Envoyer le commentaire��6      5�      $��10,0,0,0q�5�      $ CommentTextMultiple=�5�      $��40��5�      $��40��5�      5�      5�      �� 5�      -	   5        $ btn_ClearFormulaire��5�      $��
20,15,20,0q�5�      $ 15��5�      $��48��5�      $
��auto��5�      ���#D64161$��25(�5�      .��5�      � .+�5�      �� $��Vider le formulaire��6      5�      $��10,0,0,0q�5�      $ TrashCan=�5�      $��40��5�      $��40��5�      5�      5�      5�      �� 5�   
   -
   5         ��Name$ MyScrollViewer��5�      $��	15,15,0,0q�5�      $��1��6*   $��1��6:     MaterialDesignScrollViewer#���  5�      .��5�      � -   5        $��wp_Commentaires��5�      5�      5�      5�      5�      