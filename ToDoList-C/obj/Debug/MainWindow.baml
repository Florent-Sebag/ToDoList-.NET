   M S B A M L   `   `   `  ����E  AToDoList-C, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ToDoList_C
ToDoList_C  5   	       ToDoList_C.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:ToDoList_C     5   	     � Title$  	ToDo List��5   	   $��362.709��6   $��542.598��6,   .��5	      � $��0,0,-27.6,-19.2q�6   .+�5
   
   �� -   5        $��NewTask��5
      $��Add new Task��6    $
��Left=�67   $��29��6R   $��
430,10,0,0q�6^   $	��Top=�6r   $��78��6�   6�   �� 5   
   -   5        $��EditTask��5      $��	Edit Task��6!   $
��Left=�65   $��29��6P   $��
430,57,0,0q�6\   $	��Top=�6p   $��78��6�   6�   �� 5   
   -   5        $��
DeleteTask��5      $��Delete Task��6#   $
��Left=�69   $��29��6T   $��430,104,0,0q�6`   $	��Top=�6u   $��78��6�    J� RenderTransformOrigin$ 0.382,-0.129&�6�   6�   �� 5   
   -   5        $��TaskList��5      $
��Left=�6"   $	��282��6=   $	��Top=�6J   $	��415��6b   $��	10,39,0,0q�6n   $��Stretch=�6�   ��5      �� 5      .R�5      � $��1q�6    � ColumnDefinitions 5      �� 5      $��1* �6/   �� 5      $��2* �6/   �� 5      $��1* �6/   .+�5      �� $��0,0,10,0q�6$   ��66   �� *title+�� 5      $��0,0,10,0q�6$   $��1��66   ��6F   �� *description+�� 5      $��FinishedTask��6$   -   5        $��2��5   8    d� 	IsChecked 6H   �� *
isFinish+ �� Mode$ TwoWay=�6t   5      5      5      �� 5   
   $
��Left=�6   $��	10,10,0,0q�6/   $
��Wrap=�6B   $��Title��6V   $	��Top=�6c   $ 0.337,-0.608&�6{   $��94��6�   �� 5   
   $
��Left=�6   $��
115,10,0,0q�6/   $
��Wrap=�6C   $��Description��6W   $	��Top=�6j   $ 0.469,-0.507&�6�   �� 5   
   $
��Left=�6   $��
318,10,0,0q�6/   $
��Wrap=�6C   $��Done ?��6W   $	��Top=�6e   $ 0.795,-0.331&�6}   5       5!      