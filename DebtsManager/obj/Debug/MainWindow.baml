   M S B A M L   `   `   `  ����G  CDebtsManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:DebtsManagerDebtsManager  5   	       DebtsManager.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:DebtsManager     5   	     � Title$  Debts Manager v1.0��5   	   $	��800��6$   $	��450��60    � WindowStartupLocation$ CenterScreen=�5	   	    � Language$ cs-CZ�5
   	   .��5      �  � ColumnDefinitions 5   
   �� 5       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   ]� .+�5      o� $	��Top=�6   .@�5      m� $��	Dlužník��6   .@�5      m� -   5        $��addMenuItem��5   /   $��Přidat��6   6B   m� 5      -   5        $��removeMenuItem��5   0   $��Odebrat��6   6F   5      5      5      &   System.Windows.Controls.DataGrid  5   
   -   5        $��debtorsDataGrid��5      $��1��5         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 5      $��10q�5          Columns 5!      0  *System.Windows.Controls.DataGridTextColumn  5"      ,  &System.Windows.Controls.DataGridColumn   Header$ Jméno��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *Name+  5#      $ Částka��6%    65   �� *Amount+	 �� StringFormat$	 C0��  5$      $ Splaceno��6%    67   �� *Paid+$	 C0��  5%      $ Zbývající dluh��6%   
   
IsReadOnly
 .  6=   �� *RemainingDebt+$	 C0��6p     5&      $ 
Vytvořeno��6%   
 .  68   �� *	Created+$	 
d. M. yyyy��6m   5(      5)      5*      