   M S B A M L   `   `   `  ����>  :MGA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:MGA.WindowsApps.ComptabiliteMGA.WindowsApps.Comptabilite  5   	   3clr-namespace:MGA.UserControlsMGA.UserControls  5   	   /    )MGA.WindowsApps.Comptabilite.Comptabilite   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:MGA.WindowsApps.Comptabilite     5   	   -ucclr-namespace:MGA.UserControls     5   	   -   5        $��WindowComptabilite��5   G     � Title$  Comptabilite��5	   	   $	��700��5
   	   $
��1200��6    � WindowStyle$
 None=�5   	    � AllowsTransparency .  � 
ResizeMode$ CanResizeWithGrip=�5   	    � SizeToContent$ WidthAndHeight=�6(   .��5      � -   5         � RowDefinitions 5   
   �� 5      $��60 �6   �� 5      $��* �6   .+�5   
      MGA.UserControls.NavBar  ���#95190C$��0��6)   �� 5   
    �� Orientation$ 
Horizontal=�6   $��0��6.   .+�5      �� -   5        $��0q�5      
������ $
��Left=�5      .��5      �� $+��%/Images/Apps/Comptabilite/Arriere.png��6   $��25��5      $��25��6#   $��	10,0,10,0q�5       5!      �� 5"      
�������$��Center=�5$      $
��Bold"�5%      $��15(�5&      $��Italic$�5'      Comptabilite5)      5*      � 5,   
   $��1��6    � ColumnDefinitions 5-      �� 5.      $
��auto �6#   $	��315��60   �� 5/      $��* �6#   .+�52      � $��0��6    53      �� 54      $��* �6$   �� 55      $��65 �6$   .+�58      �� -   5        $��lbOperations��59      $��0��58      $��15q�5:      $��0,1,0,0q�5;      ���#95190C$��Disabled=�5=      $��Stretch=�5>      $��Stretch=�63   ��5?      �� 5@      .R�5A      ��  �� CornerRadius$ 10��6%   $��0,5,0,5q�67   ��5B   "   �� 5C   &   	 �� 
StartPoint$		 0,0&�6:   
 �� EndPoint$	
 1,1&�6K   .��5D   *   �  � Offset$ 0Q�6O    � Color 67   �� *Color+6O   � 5E   *   $ FloralWhite��67   $ 1Q�6K   5F   '   ._�5H   "   �� $ 
Horizontal=�6-   $��	10,5,10,5q�6F   .+�5I   &   �� $��Center=�5J   %   $	��140��5K   %   $
��Left=�5L   %   $��20(�5M   %   $
��Bold"�5N   %   ��5O   %   �� *
Foreground+��5P   %   �� *Date+�� 5Q   &   $��Center=�5R   %   $	��150��5S   %   $
��Left=�5T   %   $��20(�5U   %   $
��Bold"�5V   %   ��5W   %   �� *
Foreground+��5X   %   �� *Libele+�� 5Y   &   $��Center=�5Z   %   $��50��5[   %   $
��Left=�5\   %   $��20(�5]   %   $
��Bold"�5^   %   ��5_   %   �� *
Foreground+��5`   %   �� *	Montant+5a   #   5b      5c      5e      �� 5g      $��1��6   $��0,0,0,15q�5h      
���  ��$ 10��5j      $��0,0,5,5q�5k      
��� ���$��Center=�5m      ._�5o      �� $ 
Horizontal=�5p      $��Center=�5q      $��Center=�66   .+�5s      �� -   5        $��0q�5t      $��25��5u      $��25��6$   $��	10,0,10,0q�5v      
������ .��5z      �� $-��'/Images/Apps/Comptabilite/Recherche.png��6$   5|      �� 5~      -   5        $��0q�5      $��25��5�      $��25��6(   $��	10,0,10,0q�5�      
������ .��5�      �� $*��$/Images/Apps/Comptabilite/Editer.png��6$   5�      �� 5�      -   5        $��0q�5�      $��35��5�      $��35��6(   $��	10,0,10,0q�5�      
������ .��5�      �� $(��"/Images/Apps/Comptabilite/Plus.png��6$   5�      �� 5�      -   5        $��DeleteButton��5�      $��0q�5�      $��25��5�      $��25��6(   $��	10,0,10,0q�5�      
������ .��5�      �� $-��'/Images/Apps/Comptabilite/Supprimer.png��6$   5�      �� 5�      $ 	15,0,15,0��6!   
�������$��5q�6\   ._�5�      �� -	   5        $��Montant��5�   !   
��� ���$��20(�5�   !   $
��Bold"�5�   !   $	��300��63    �� Padding$ 15q�6>   $��Center=�6K   5�      5�      5�      5�      � 5�      -
   5        $��GridGraphique��5�   #   $��1��6   $	��600��5�      $	��500��6   $��15q�5�      5�      5�      5�      