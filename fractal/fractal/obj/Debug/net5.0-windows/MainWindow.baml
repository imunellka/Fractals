   M S B A M L   `   `   `  ����B  >fractal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:fractalfractal  5   	       fractal.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:fractal     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � $��2,5,1,0q�6    � RowDefinitions 5
   
   �� 5      $��0* �6   �� 5      $	��39* �6   �� 5      $	��39* �6   �� 5      $	��54* �6   �� 5      $	��42* �6   �� 5      $	��66* �6   �� 5      $	��80* �6   �� 5      $	��97* �6   �� 5      $	��12* �6   ��5   
   �� 5       j� TileMode$
 None=�6    j� Stretch$
 Fill=�6)    �� ImageSource$0 */1617406662_54-p-oboi-nebo-estetika-57.jpg��68    � ColumnDefinitions 5   
   �� 5      $��0* �6   �� 5      $	��16* �6   �� 5      $
��132* �6   �� 5      $	��80* �6   �� 5      $
��182* �6   �� 5      $
��124* �6   �� 5      $	��98* �6   �� 5       $
��153* �6   �� 5!      $	��13* �6   .+�5#   
   �� -   5        $L��FОбдуваемое ветром
фрактальное дерево��5#      $��	38,6,2,11q�6I   $��18(�6\   $��Sitka Display Semibold)�6j   $��6��6�   $��5��6�   $��2��6�   �� 5$   
   -   5        $��Кривая Коха��5$      $��Sitka Banner Semibold)�6'   $��18(�6J   $��4��6o   $��7��6   $��89,22,51,21q�6�   $��2��6�   �� 5&   
   -   5        $5��/Треугольник
 Серпинского��5&      $��18,11,85,11q�6=   $��18(�6R   $��Sitka Banner Semibold)�6`   $��6��6�   $��3��6�   $��2��6�   �� 5'   
   -   5        $'��!Множество Кантора��5'      $��21,19,25,16q�6-   $��Sitka Banner Semibold)�6B   $��18(�6e   $��2��6�   $��7��6�   $��2��6�   �� 5(   
   $��	25,4,76,8q�6   $��NoWrap=�6'    �� TextAlignment$ Center=�6=   $��22(�6T   #��� ��6b   $��Sitka Banner Semibold)�6�   ���	#FFFDF8F8$��4��6�   $��4��6�   $��3��6  �� 6   � Language$ ru-ru�6  $�
Шаг 2. ��6.  �� 6?  $.�(Выберите свой фрактал��6C  6c  �� 5)   
   -   5         ��Name$ button1��5)      $��3��6"   $0��*Выбор начального цвета��62   $��	33,6,11,7q�6S   $��2��6f   $��Sitka Banner Semibold)�6s   $��18(�6�   $��2��6�   �� 5*   
   $��	54,3,30,7q�6   $��NoWrap=�6'   $ Center=�6=   $��22(�6T   #��� ��6b   $��Sitka Banner Semibold)�6�   ���	#FFFDF8F8$��1��6�   $��4��6�   $��2��6  �� 6  $ ru-ru�6  $%�Шаг 1. Выбор цвета��6.  6K  �� 5+   
   -   5        $ button1_Copy��5+      $��3��6'   $.��(Выбор конечного цвета��67   $��
34,8,10,20q�6W   $��3��6k   $��Sitka Banner Semibold)�6x   $��18(�6�   $��2��6�   �� 5,   
   -   5        $'��!Ковер Серпинского��5,      $��Sitka Banner Semibold)�6-   $��18(�6P   $��6��6u   $��75,23,20,23q�6�   $��7��6�   $��2��6�   �� 5-   
   -   5        	 ��Name$	 
startColor��5-      $��5��6'   $��7,8,17,7q�67   $��2��6I   ��5.      �� 5/      
 �� EndPoint$	
 0,1&�6&   .��50      �  � Color$ 	#FFF0F0F0��6#   � 51      $ 	#FF0E0404��6#    � Offset$ 0.049Q�65   52      .@�54      �� ���	#FFE92B2B���	#FF0C0707$��20��6D   $��50��6P   $��FFE92B2B��6[   �� 55      ���	#FF30E322$��20��6,   $��50��68   $��FF30E322��6C   �� 56      ���	#FFEFC13F$��20��6,   $��50��68   $��FFEFC13F��6C   �� 57      ���	#FF3CF3F0$��20��6,   $��50��68   $��FF3CF3F0��6C   �� 58      ���	#FF5553EE$��20��6,   $��50��68   $��FF5553EE��6C   �� 59      ���	#FFCE55E6$��20��6,   $��50��68   $��FFCE55E6��6C   �� 5:      ���	#FFE0467A$��20��6,   $��50��68   $��FFE0467A��6C   5;      �� 5<   
   -	   5        $	 endColor��5<      $��5��6%   $��	9,8,15,22q�65   $��3��6H   ��5=      �� 5>      $	
 0,1&�6&   .��5?      � $ 	#FFF0F0F0��6#   � 5@      $ 	#FF0E0404��6#   $ 0.049Q�65   5A      .@�5C      �� ���	#FFE92B2B���	#FF0C0707$��20��6D   $��50��6P   $��FFE92B2B��6[   �� 5D      ���	#FF30E322$��20��6,   $��50��68   $��FF30E322��6C   �� 5E      ���	#FFEFC13F$��20��6,   $��50��68   $��FFEFC13F��6C   �� 5F      ���	#FF3CF3F0$��20��6,   $��50��68   $��FF3CF3F0��6C   �� 5G      ���	#FF5553EE$��20��6,   $��50��68   $��FF5553EE��6C   �� 5H      ���	#FFCE55E6$��20��6,   $��50��68   $��FFCE55E6��6C   �� 5I      ���	#FFE0467A$��20��6,   $��50��68   $��FFE0467A��6C   5J      5L      5M      