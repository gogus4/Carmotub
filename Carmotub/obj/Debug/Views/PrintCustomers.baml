   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	    Carmotub#   Carmotub.Views.PrintCustomers   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   6sys&clr-namespace:System;assembly=mscorlib     5   	   -   5          � Title$'  !Imprimer une fiche d'intervention��5   	   $	��460��63   $	��510��6@    � 
ResizeMode$ NoResize=�6L    � WindowStartupLocation$ CenterScreen=�6b   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5	      $��40 �6   �� 5
      $	��220 �6   �� 5      $��40 �6   �� 5      $
��Auto �6   .+�5   
   �� $$��Impression fiches intervention��6   $��5,0,0,0q�6:   $��36(�6K   $��Segoe UI Light)�6Y   �� 5   
   $��1��6   $��Imprimer un client :��6!   $��20(�6=   $��Segoe UI Light)�6K   $��5,10,0,0q�6g   �� 5   
    �� Orientation$ Vertical=�6   $��2��6,   .+�5      �� $ Vertical=�6   $��0,5,0,0q�60   .+�5      �� $%��Rechercher le client par nom : ��6   $��14(�6C   $��Segoe UI Light)�6Q   $��5,0,0,0q�6m   �� 5      -   5         ��Name$ SearchBorder��5      $	��200��6/   $
��Left=�6;   $��5,5,0,5q�6V   $��20��6g   
�������$y�Visible=�6�   $��1q�6�   
�������._�5      �� $ 
Horizontal=�6!   .+�5      �� -   5         ��Name$ SearchBoxText��5   "   $	��180��69   
������ $��0q�6`   �� 5      -   5         ��Name$ SearchButton��5   !   
������ 
������ ��5      �� 5   "   $+��%/Carmotub;component/Assets/search.png��6(   5      5      5       &   System.Windows.Controls.DataGrid  5"      -   5          Name$ DataGridCustomers��5"      $��5q�66   $	��120��6A   	   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	 * 6N   $��Segoe UI Light)�6^   
�������
   
IsReadOnly
 .    AutoGenerateColumns .  $��Stretch=�6�      CanUserDeleteRows .     HorizontalGridLinesBrush
 �����   VerticalGridLinesBrush
 �����   Columns 5#      0  *System.Windows.Controls.DataGridTextColumn  5$      ,  &System.Windows.Controls.DataGridColumn   Header$	 Nom��6-   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� *nom+  5%      $ Prénom��6-    6=   �� *prenom+  5&      $ Ville��6-    6<   �� *ville+  5'      $ Code postal��6-    6B   �� *code_postal+  5(      $ Num tel fixe ��6-    6D   �� *telephone_1+  5)      $ Rendez vous��6-    6B   �� *Rdv+5+      5,      �� 5.      -   5        $ PrintCustomer��5.      $��Imprimer le client��6,   $��14(�6I   $��Segoe UI Light)�6W   $	��140��6s   $
��Left=�6   $��5,5,0,0q�6�   6�   5/      �� 51   
   $��3��6   $��Imprimer le planning : ��6!   $��20(�6@   $��Segoe UI Light)�6N   $��5,10,0,0q�6j   �� 53   
   $ Vertical=�6   $��4��6,   .+�54      �� $ 
Horizontal=�6   .+�55      �� $��Selectionner une date : ��6   $��Center=�6<   $��14(�6W   $��Segoe UI Light)�6e   $��5,0,0,0q�6�   (  "System.Windows.Controls.DatePicker  56      -   5          Name$ SelectedDate��56      
�������
 �� Now   SelectedDate# Z 6K   $��14(�6v   $��Segoe UI Light)�6�   $	��200��6�   $��10,0,0,0q�6�   57      �� 59      -   5        $ PrintPlanning��59      $��Imprimer le planning��6,   $��14(�6K   $��Segoe UI Light)�6Y   $	��140��6u   $
��Left=�6�   $��5,10,0,0q�6�   6�   5:      5<      5=      