   M S B A M L   `   `   `  ����M  ITraceTextEditorWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:TraceTextEditorWPFTraceTextEditorWPF  5   	   #    TraceTextEditorWPF.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:TraceTextEditorWPF     5   	     � Title$  Trace Text Editor��5   	   $	��450��6#   $	��800��60    � Icon$ logo.ico��6<   
������� J� InputBindings 5	      �� 5
   
    �� Command$	 New��6    �� Gesture$ Ctrl+N��6#   �� 5   
   $
 Open��6   $ Ctrl+O��6$   �� 5   
   $
 Save��6   $ Ctrl+S��6$   �� 5   
   $ Close��6   $ Ctrl+E��6%   �� 5   
   $	 Cut��6   $ Ctrl+X��6#   �� 5   
   $
 Copy��6   $ Ctrl+C��6$   �� 5   
   $ Paste��6   $ Ctrl+V��6%   .��5      � .+�5   
   ]� -   5        $��panel��5   Q   $
��Left=�6   ��.  $	��794��6E   .+�5      o� $	��Top=�6   .@�5      m� $��Файл��6   .@�5      m� $��Создать��6    m� InputGestureText$ Ctrl+N��60    m� Command$	 New��6J    m� Icon 5      �� 5      $��newfile.ico��6$   5      m� 5      $��Открыть��6   $ Ctrl+O��60   $
 Open��6J    5      �� 5      $��openfile.ico��6$   5       m� 5!      $��Сохранить��6   $ Ctrl+S��62   $
 Save��6L    5"      �� 5#      $��savefile.ico��6$   5%      �� 5&      m� 5'      $��Закрыть��6   $ Ctrl+E��60   $ Close��6J    5(      �� 5)      $��exitfile.ico��6$   5+      5,      m� 5.      $"��Редактирование��6   .@�5/      m� -   5        $��cutItem��5/   Y   $��Вырезать��6   $ Ctrl+X��61   $	 Cut��6K    50      �� 51      $��cut.ico��6$   53      m� 54      -   5        $��copyItem��54   \   $��Копировать��6   $ Ctrl+C��63   $
 Copy��6M    55      �� 56      $��copy.ico��6$   58      m� 59      -   5        $��	pasteItem��59   [   $��Вставить��6   $ Ctrl+V��61   $ Paste��6K    5:      �� 5;      $��	paste.ico��6$   5=      5>      5?      �� 5@      -   5         ��Name$
 text��5@      $��0,0,0,0q�6(   $	��779��69   "	 �� VerticalScrollBarVisibility$
	 Auto=�6E   5B      5C      5E      5F      