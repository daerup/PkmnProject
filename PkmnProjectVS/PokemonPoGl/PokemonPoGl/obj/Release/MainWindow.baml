   M S B A M L   `   `   `  ���� F  BPokemonPoGl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:PokemonPoGlPokemonPoGl      PokemonPoGl.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     J FWpfAnimatedGif, Version=1.4.15.0, Culture=neutral, PublicKeyToken=null,gif"http://wpfanimatedgif.codeplex.com  +pokemonPoGlclr-namespace:PokemonPoGl    � Title$  BattleWindow��$	��821��$
��1000��.��� $��0,0,0,0q�����  �� ImageSource$ res/stage/rock.png��.+��� -    ��Name$ ImgPlayerPokemon��"  WpfAnimatedGif.ImageBehavior   AnimatedSource$# res/sprites/venusaur/back.gif��$��48,189,411,-12q��� -   $ ImgEnemyPokemon��$$ res/sprites/venusaur/front.gif��$��537,93,75,327q�#  PokemonPoGl.SmoothProgressBar  -     Name$ PlayerHp��#   PokemonPoGl.SmoothProgressBar   ValueChanged$ PlayerHP_ValueChanged��$��30��$	��250��$��667,529,75,231q� � Minimum$ 0Q� � Maximum$
 1000Q� � Value$
 1000Q�
��� � ����� 	 �� Triggers	 :� 
 :� RoutedEvent$-
 'pokemonPoGl:SmoothProgressBar.DragEnter��.[��� .����  ��Name$ playerBlink��.��W�  �� TargetProperty$ (Image.Opacity)� g� 	BeginTime$ 0:0:0X� g� Duration$ 0:0:0.3D� W� From$	 1.0X�	 W� To$	 0.0X� g� RepeatBehavior$ 3x�� g� AutoReverse .  �� Target ��  �� Source %  System.Windows.Markup.Reference  *ImgPlayerPokemon+  -   $ EnemyHp��$ EnemyHP_ValueChanged��$��30��$	��250��$��0,30,592,472q�$ 0Q�$
 1000Q�$
 1000Q�
��� � ����� 	 :� $-
 'pokemonPoGl:SmoothProgressBar.DragEnter��.[��� .���� $ 
enemyBlink��.��W� $ (Image.Opacity)�$ 0:0:0X�$ 0:0:0.3D�$	 1.0X�$	 0.0X�$ 3x�� .  ��    *ImgEnemyPokemon+�� -   $��Button��$
��Left=�$��667,625,0,0q�$	��Top=�$	��228��$��74��