   M S B A M L   `   `   `  ����F  BPokemonPoGl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:PokemonPoGlPokemonPoGl  5   	   %clr-namespace:smoothBar	smoothBar  5   	        PokemonPoGl.MainWindowView   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   J FWpfAnimatedGif, Version=1.4.15.0, Culture=neutral, PublicKeyToken=null,gif"http://wpfanimatedgif.codeplex.com  5   	   +pokemonPoGlclr-namespace:PokemonPoGl  5   	   '	smoothBarclr-namespace:smoothBar  5   	   :d2http://schemas.microsoft.com/expression/blend/2008  5   	   Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5   	     � 
ResizeMode$  NoResize=�5   	    � Icon$ /res/icon/icon.ico��5   	    � Title$ BattleWindow��5   	   $	��821��6   $
��1000��6+   .��5      � $��0,0,0,0q�6   ��5   
   �� 5       �� ImageSource$ res/stage/rock.png��6   .+�5   
      PokemonPoGl.GameModeView  $��0,11,621,721q�6M    � DataContext 6#   �� *GameModeViewModel+6M      PokemonPoGl.HelpView  5   
   $��Right=�6E   $��
0,0,19,712q�6a   $��75��6u    6   �� *HelpViewModel+6u   �� 5   
   -   5         ��Name$ ImgPlayerPokemon��5      6*   �� 5   
   -   5        $ ImgEnemyPokemon��5      6)   !  smoothBar.SmoothProgressBar  5   
   -   5          Name$ PlayerHp��5   &   !   smoothBar.SmoothProgressBar   ValueChanged$ PlayerHP_ValueChanged��6�   $��30��68   $	��390��6D    � Minimum$ 0Q�6P   	 � Maximum$
	 1000Q�6\   
 � Value$
 1Q�6k   
��� � �
 � Tag$ ShouldNotBlink��6�    K� ZIndex$ 3��6�   $��585,502,0,258q�6�   $
��Left=�6�   ��5      �� 5       �� Triggers 5      P� 5       P� Property �@�Tag P� Value$ ShouldBlink��69    N� EnterActions 5       �� 5!   "   .��5"   &   �� .��5#   *   W�  �� TargetProperty$ (Image.Opacity)�5%   -    g� 	BeginTime$ 0:0:0X�5&   -    g� Duration$ 0:0:0.3D�5'   -    W� From$	 1.0X�5(   -   	 W� To$	 0.0X�68    g� RepeatBehavior$ 3x��5)   -    g� AutoReverse .  �� Target 5$   -   ��  �� Source %  System.Windows.Markup.Reference  *ImgPlayerPokemon+5*   -   5+   '   5,   #   5.      50      52        54   
   -   5        $ EnemyHp��54   &   $ EnemyHP_ValueChanged��6�   $��30��67   $	��390��6C   $ 0Q�6O   $
	 1000Q�6[   $
 1Q�6j   
��� � �$ ShouldNotBlink��6�   $ 3��6�   $��10,114,592,646q�6�   ��55      �� 56       57      P� 58       �@�Tag$ ShouldBlink��69    59      �� 5:   "   .��5;   &   �� .��5<   *   W� $ (Image.Opacity)�5>   -   $ 0:0:0X�5?   -   $ 0:0:0.3D�5@   -   $	 1.0X�5A   -   $	 0.0X�68   $ 3x��5B   -    .  5=   -   ��    *ImgEnemyPokemon+5C   -   5D   '   5E   #   5G      5I      5K      �� 5M   
   -   5         ��Name$
 Stab��5M      $��
StabAttack��5N      $
��Left=�5O      $	��Top=�5P      $	��232��5Q      $��60��5R      $��743,651,0,0q�5T      $��Impact)�5U      $��24(�5V      
���   �$��3q�5X      {�.  5Y      �� 5[   
   -   5        $ Normal��5[      $��NormalAttack��5\      $
��Left=�5]      $	��Top=�5^      $	��232��5_      $��60��5`      $��743,585,0,0q�5b      $��Impact)�5c      $��24(�5d      
�������$��3q�5f      {�.  5g      �� 5i   
   -   5         ��Name$ TxtPlayerPokemon��5i      
�������$
��Left=�5k      $��585,460,0,0q�5l      $
��Wrap=�5m      $	��Top=�5n      $��43��5o      $	��390��5p       J� OpacityMask
 �   �$��Impact)�5r      $��36(�5s      $��Your Pokemon��6"    J� Effect 5t      3  -System.Windows.Media.Effects.DropShadowEffect  5u         ShadowDepth$ 5Q�6#      Color$ Black��63       Opacity$  1Q�6A   !   
BlurRadius$! 1Q�6M   5w      �� 5y   
   -   5        $ TxtEnemyPokemon��5y      
�������$
��Left=�5{      $��	10,72,0,0q�5|      $
��Wrap=�5}      $	��Top=�5~      $��43��5      $	��390��5�      
 �   �$��Impact)�5�      $��36(�5�      $��Enemy Pokemon��5�       5�        5�      $ 5Q�6#   $ Black��63   $  1Q�6A   $! 1Q�6M   5�      �� 5�   
   -	   5        $ Narrator��5�      $
��Left=�6&   $��
26,717,0,0q�6A   $
��Wrap=�6U   $	��Top=�6i   $��73��6�   $	��966��6�   
�������$��45(�6�   $��Impact)�6�    5�        5�      $ 5Q�6#   $ Black��63   $  1Q�6A   $! 1Q�6M   5�      5�      5�      