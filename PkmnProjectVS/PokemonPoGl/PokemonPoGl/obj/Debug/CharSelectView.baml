   M S B A M L   `   `   `  ����  PokemonPoGl     PokemonPoGl.CharSelectView   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -   5          � 
ResizeMode$  NoResize=�5   	    � Icon$ /res/icon/icon.ico��5	   	    � Title$ CharSelectView��5
   	   $	��800��6    $
��1000��6-   .��5      � $	��993��6   $	��769��6   $	��769��6*   $	��769��6:    � RowDefinitions 5   
   �� 5      $��2* �6   �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      ��5   
   �� 5       �� ImageSource$ res/stage/stars.png��6   .+�5   
   �� -   5         ��Name$
 Back��5      $��_<��5      $
��Left=�5      $��281,71,0,71q�5      $��50��5       ���	#FF28895A$��Impact)�5"      $��22(�5#      ���	#FFA8E9FB$��1��5%      5&      �� 5(   
   -   5        $
 Next��5(      $��_>��5)      $��0,71,281,71q�5*      ���	#FF28895A$��Impact)�5,      $��22(�5-      ���	#FFA8E9FB$��2��5/      $��1��50      51      �� 53   
   $��170,0,170,142q�6   $��res/stage/headLogo.png��6'   $
��Fill=�6G   $��0��6V   $��3��6c   $��0��6w    K� ZIndex$ 1��6�   �� 54   
   $��0��6   $��1��6   $��47,202,56,38q�6-   $��res/stage/footLogo.png��6C   $
��Fill=�6c   �� 55   
   -   5         ��Name$ Pokemon��55      $��1��6!   $��1��61   �� 57   
   -   5        $ Start��57      $��_Start Battle��6    $��2��68   $��2��6H   $��0,50,142,59q�6U   ���	#FFD3FFFC���	#FF4AA45C$��Impact)�6�   $��30(�6�   ���	#FF5080EE$��5q�6�   	 �� 	IsDefault	 . 6�   �� 59   
   -   5        
 ��Name$
 HardModeControl��59      $��
_Hard-Mode��6,   $��1��6A   $
��Left=�6Q   $��	49,72,0,0q�6l   $��2��6   $	��Top=�6�   $��20��6�   $��92��6�   $��Impact)�6�   $��14(�6�   ���	#FFD49688 � LayoutTransform 5:      �� 5;       �� ScaleX$ 3Q�6!    �� ScaleY$ 3Q�6,    J� Effect 5=      3  -System.Windows.Media.Effects.DropShadowEffect  5>         ShadowDepth$ 2Q�6#      Color$ Black��63      Opacity$ 1Q�6A      
BlurRadius$ 1Q�6M   5@      �� 5B   
   -   5         ��Name$ PokemonName��5B      $��IMPACT��6%   $��1��66   $��Center=�6F   $��0,12,0,0q�6c   $��2��6u   $	��Top=�6�   $��Impact)�6�   $��36(�6�   ���	#FFD3FFF2$	��331��6�   $��Center=�6�    5C        5D      $ 5Q�6#   $ Black��63   $ 1Q�6A   $ 1Q�6M   5F      5G      5H      