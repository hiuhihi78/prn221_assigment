   M S B A M L   `   `   `  ����F  BWPF_Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:WPF_Project.ViewsWPF_Project.Views  5   	   ?$clr-namespace:WPF_Project.ViewModelsWPF_Project.ViewModels  5	   R   )    #WPF_Project.Views.DialogOrderDetail   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:WPF_Project.Views     5   	   _ [MaterialDesignThemes.Wpf, Version=4.7.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	   	   5
viewmodels$clr-namespace:WPF_Project.ViewModels  6R   $��15(�5
   	     � WindowStartupLocation$  CenterScreen=�5   	    � WindowStyle$
 None=�5   	   
�������$	��901��5   !   $	��544��6-   .��5      �� .+�5   
   �� $��Order Detail��6   $��25(�5      $
��Bold"�5       �� Left$ 30��5      
 �� Top$ 10��6%   $
��Left=�65   $��Center=�6P   �� 5   
   $	��237��5      $��Center=�5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ 
Order's Id��5       %  !MaterialDesignFloatingHintTextBox#��[  5      ${�False��5      $
��Left=�5      $ 54��6(   $ 50��68   ��5      �� *OrderDTO.Id+5   8   �� 5   
   $	��235��5       $��Center=�5!      $ Order's Date��5"      #��[  5#      ${�False��5%      $
��Left=�5&      $	 103��6(   $ 52��69   ��5$      �� *OrderDTO.OrderDate+5&   9   �� 5(   
   $	��235��5)      $	��Top=�5*      $ Staff order��5+      #��[  5,      ${�False��5.      $
��Left=�5/      $	 152��6(   $ 52��69   ��5-      �� *
StaffOrder+5/   9   �� 51   
   $	��235��52      $	��Top=�53      $ Total��54      #��[  55      ${�False��57      $��Center=�58      $	 204��6*   $ 52��6;   ��56      �� *OrderDTO.TotalAmount+58   ;   �� 5;   
   $	��235��5<      $	��Top=�5=      $ Customer name��5>      #��[  5?      ${�False��5A      $
��Left=�5B      $	 104��6(   $	 350��69   ��5@      �� *OrderDTO.CustomerName+5B   9   �� 5D   
   $	��235��5E      $	��Top=�5F      $ Customer Phone��5G      #��[  5H      ${�False��5J      $
��Left=�5K      $	 154��6(   $	 350��69   ��5I      �� *OrderDTO.CustomerPhone+5K   9   �� 5M   
   $	��235��5N      $	��Top=�5O      $ Customer Address��5P      #��[  5Q      ${�False��5S      $
��Left=�5T      $	 204��6(   $	 350��69   ��5R      �� *OrderDTO.CustomerAddress+5T   9   &   System.Windows.Controls.DataGrid  5V   
      CanUserAddRows$ False��5W         SelectionMode$ Extended=�5Y         SelectionUnit$
 Cell=�5Z         AutoGenerateColumns$ False��5[      	   
IsReadOnly$
	 True��5\      $
��True��5]      $	��178��5^      $ 38��6   $	 272��6+   $��Center=�6<   $	��Top=�6Y   $	��819��6q   ��5X      �� *OrderDetails+
   Columns
 5`      0  *System.Windows.Controls.DataGridTextColumn  5a      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 250 6T   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *Product.Name+6T     5b      $ Quantity��6%   $	 200 6T    67   �� *
Quantity+6T     5c      $ Price��6%   $	 200 6R    64   �� *	SellPrice+6R     5d      $ Discount��6%   $	 100 6T    67   �� *
Discount+6T   5f      �� 5h   
   -   5        $	 723��5i      $	 459��6   $��Center=�5j      $	��Top=�6*   $	��107��5k      $��68��6   ���#0077d0$��40(�5m       � ToolTip$
 Back��5n      ��5p      '  !MaterialDesignThemes.Wpf.PackIcon  5q      $��40��5r      $��40��5s         Kind$ KeyboardReturn=�5t      5v      5w      5z      