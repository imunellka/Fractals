   M S B A M L   `   `   `  ����B  >fractal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:fractalfractal  5   	       fractal.SerpTriangle   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:fractal     5   	     � Title$  SerpTriangle��5   	   $	��450��6   $	��800��6+   .��5	      � -   5        
������� � ColumnDefinitions 5
   
   �� 5      $��4* �6   �� 5      $
��188* �6   �� 5      $
��599* �6   �� 5      $��9* �6    � RowDefinitions 5   
   �� 5      $��4* �6   �� 5      $
��335* �6   �� 5      $	��61* �6   �� 5      $	��29* �6   �� 5      $��5* �6   .+�5   
   �� -   5         ��Name$ canvas��5      #��� ��6!   $��
22,21,29,2q�6h   $��1��6|   $��1��6�   $��2��6�   �� 5   
   $
��Wrap=�6   $��Sitka Banner Semibold)�6(   $��16(�6K   $��
24,10,8,11q�6Y   $��2��6m   $��1��6z   �� 6�   $6�0Выберите глубину рекурсии��6�   �� 6�   $�:��6�   �� 6�   $� от 1 до 6��6�   6�   �� 5   
   -   5         ��Name$ slider��5      $��40,24,27,12q�6!   
������ ���	#FF120A0A���	#FF171212 � Maximum$ 6Q�6~    � Minimum$ 1Q�6�    � Cursor$ Arrow��6�   $��2��6�   $��2��6�   �� 5   
   -   5        $��СОХРАНИТЬ��5      $��	17,4,48,7q�6%   $��3��68   $��Sitka Banner Semibold)�6E   $��14(�6h   $��1��6�   5      5      