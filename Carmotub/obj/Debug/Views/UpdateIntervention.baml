   M S B A M L   `   `   `  ����  Carmotub'    !Carmotub.Views.UpdateIntervention   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Modifier une intervention��5   	   $	��280��6+   $	��630��68    � 
ResizeMode$ NoResize=�6D    � WindowStartupLocation$ CenterScreen=�6Z   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5	      $��10 �6   �� 5
      $
��Auto �6   �� 5      $��10 �6   �� 5      $
��Auto �6   �� 5      $��10 �6   �� 5      $
��Auto �6   �� 5      $��10 �6   �� 5      $
��Auto �6   �� 5      $��10 �6   �� 5      $
��Auto �6   �� 5      $��10 �6   �� 5      $
��Auto �6   �� 5      $��10 �6   �� 5      $
��Auto �6   �� 5      $��7 �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��0.32* �6   �� 5      $��0.45* �6   �� 5      $��0.32* �6   �� 5      $
��0.4* �6   .+�5"   
   �� $��Modifier une intervention��6   $��3��65   $��5,0,0,0q�6I   $��34(�6Z   $��Segoe UI Light)�6h   �� 5$   
    �� Orientation$ 
Horizontal=�6   $��1��6.   $��5��6;   $��0,5,0,0q�6O   .+�5%      �� $��Segoe UI)�6   $��5,0,0,0q�6.   �� 5&      $�Client selectionné : ��6    �� 5'      -   5         ��Name$ CustomerSelected��5'      $
��Bold"�60   5(      5)      �� 5+   
   $��Date de l'intervention : ��6   $��Center=�65   $��Segoe UI Light)�6P   $��3��6l   $��0��6y   $��5,0,0,0q�6�   (  "System.Windows.Controls.DatePicker  5,   
   -   5          Name$ DateIntervention��5,      $
��Left=�6g   $��Segoe UI Light)�6�   $��25��6�   $	��160��6�   $��3��6�   $��1��6�      SelectedDate 6/   �� * Intervention.date_intervention+6�   �� 5.   
   $��Type de chaudière : ��6   $��Center=�60   $��Segoe UI Light)�6K   $��3��6g   $��2��6t   $��5,0,0,0q�6�   �� 5/   
   -   5        	 ��Name$	 TypeChaudiere��5/      $
��Left=�6V   $��Segoe UI Light)�6q   $��25��6�   $	��160��6�   $��3��6�   $��3��6�   ��6)   �� *Intervention.type_chaudiere+6�   �� 51   
   $��	Carnet : ��6   $��Center=�6%   $��Segoe UI Light)�6@   $��5��6\   $��0��6i   $��5,0,0,0q�6y   �� 52   
   -   5        $	 Carnet��52      $
��Left=�6G   $��Segoe UI Light)�6b   $��25��6~   $	��160��6�   $��5��6�   $��1��6�   ��6"   �� *Intervention.carnet+6�   �� 54   
   $��	Nature : ��6   $��Center=�6%   $��Segoe UI Light)�6@   $��5��6\   $��2��6i   $��5,0,0,0q�6y   �� 55   
   -   5        $	 Nature��55      $
��Left=�6G   $��Segoe UI Light)�6b   $��25��6~   $	��160��6�   $��5��6�   $��3��6�   ��6"   �� *Intervention.nature+6�   �� 57   
   $��
Montant : ��6   $��Center=�6&   $��Segoe UI Light)�6A   $��7��6]   $��0��6j   $��5,0,0,0q�6z   �� 58   
   -   5        $	 Montant��58      $
��Left=�6I   $��Segoe UI Light)�6d   $��25��6�   $	��160��6�   $��7��6�   $��1��6�   ��6#   �� *Intervention.montant+6�   �� 5:   
   $��Type de paiement : ��6   $��Center=�6/   $��Segoe UI Light)�6J   $��7��6f   $��2��6s   $��5,0,0,0q�6�   �� 5;   
   -   5        $	 TypePaiement��5;      $
��Left=�6T   $��Segoe UI Light)�6o   $��25��6�   $	��160��6�   $��7��6�   $��3��6�   ��6(   �� *Intervention.type_paiement+6�   �� 5=   
   $��Numéro de chèque : ��6   $��Center=�6/   $��Segoe UI Light)�6J   $��9��6f   $��0��6s   $��5,0,0,0q�6�   �� 5>   
   -   5        $	 NumeroCheque��5>      $
��Left=�6T   $��Segoe UI Light)�6o   $��25��6�   $	��160��6�   $��9��6�   $��1��6�   ��6(   �� *Intervention.numero_cheque+6�   �� 5@   
   -	   5        
 ��Name$
 UpdateInterventionButton��5@      $��Modifier l'intervention��63   $��5,0,0,0q�6U   $��Segoe UI Light)�6f   $��11��6�   $��2��6�   $��12(�6�   $	��130��6�   $
��Left=�6�   6�   �� 5A   
   -
   5        $
 DeleteInterventionButton��5A      $��Supprimer l'intervention��63   $��10,0,0,0q�6V   $��Segoe UI Light)�6h   $��11��6�   $��1��6�   $��12(�6�   $	��130��6�   $
��Left=�6�   6�   5C      5D      