   M S B A M L   `   `   `  ����F  BWPF_Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:WPF_Project.ViewsWPF_Project.Views  5   	   5clr-namespace:WPF_Project.ViewsWPF_Project.Views  5	      &     WPF_Project.Views.CheckoutImport   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:WPF_Project.Views     5   	   2sourceclr-namespace:WPF_Project.Views     5	      _ [MaterialDesignThemes.Wpf, Version=4.7.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        N� FontSize$  15(�5      .��5      �� .+�5   
   �� $��CHECKOUT IMPORT��5      $��30(�5      $
��Bold"�5      $
��Left=�6    �� Left$ 17��6:   $	��Top=�6K   
 �� Top$ 27��6c   �� 5   
   $��Products imported��5      $��20(�5      $	 289��5      $	 129��6   $
��Left=�5      $	��Top=�6(   &   System.Windows.Controls.DataGrid  5   
   -   5        $��gridProducts��5          CanUserAddRows$ False��5!         SelectionMode$ Extended=�5#         SelectionUnit$
 Cell=�5$         AutoGenerateColumns$ False��5%         
IsReadOnly$
 True��5&      $
��True��5'      $	��301��5(      $ 17��6   $	 176��6+   $
��Left=�6<   $	��Top=�6W   $	��586��6o   ��5"      �� *ListOrderProduct+   Columns 5*      0  *System.Windows.Controls.DataGridTextColumn  5+      ,  &System.Windows.Controls.DataGridColumn	   Header$
	 Name��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 180 6L   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *Name+6L     5,      $	 Quantity��6%   $	
 100 6T    67   �� *
Quantity+6T     5-      $	 Price��6%   $	
 100 6N    64   �� *Price+6N     5.      $	 Discount��6%   $
 90 6T    67   �� *
Discount+6T     5/      $	 Category��6%   $	
 100 6Y    67   �� *Category.Name+6Y   51      �� 53   
   $��Supplier's info��54      $��20(�55      $	 776��56      $	 134��6   $
��Left=�57      $	��Top=�6(   �� 5:   
   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$
 Name��5;      ${�False��5=       �� 	MaxLength$ 40��5?         MaterialDesignFilledTextBox#��[  5@       �� TextWrapping$
 Wrap=�5A      $	 636��6!   $	 182��63   $
��Left=�6D   $��Center=�6_   $	��402��6z   ��5<      �� *SelectedSupplier.Name+.  (MaterialDesignThemes.Wpf.TextFieldAssist!   CharacterCounterVisibility 5>      ��  �� Path$ 	IsChecked� �� ElementName$2 ,MaterialDesignFilledTextBoxTextCountComboBox��   BooleanToVisibilityConverter �� 	Converter# [ 5A   z   �� 5C   
   $ Phone��5D      ${�False��5F      $ 40��5H      #��[  5I      $
 Wrap=�5J      $	 639��6!   $	 252��63   $��Center=�6D   $	��Top=�6a   $	��399��6y   ��5E      �� *SelectedSupplier.Phone+ 5G      �� $ 	IsChecked�$2 ,MaterialDesignFilledTextBoxTextCountComboBox��# [ 5J   y   �� 5M   
   $ Address��5N      ${�False��5P      $ 40��5R      #��[  5S      $
 Wrap=�5T      $	 639��6!   $	 326��63   $��Center=�6D   $	��Top=�6a   $	��399��6y   ��5O      �� *SelectedSupplier.Address+ 5Q      �� $ 	IsChecked�$2 ,MaterialDesignFilledTextBoxTextCountComboBox��# [ 5T   y   �� 5X   
   $��Total:��6   $��24(�5Y      $	 710��5Z      $	 469��6"   $
��Left=�5[      $��Center=�6+   �� 5\   
   $	��200��5^      $	 791��6   $	 477��6+   $��24(�5_      $
��Left=�6   $	��Top=�66   ��5]      �� *TotalPriceOrder+5_   6   �� 5b   
   $	 710��5d      $	 544��6   $
��Left=�5e      $	��Top=�6(   $	��133��5f      $��68��6   ���#0077d0$��40(�5h      ��5c      �� *BackToPreviousScreen+��5j      '  !MaterialDesignThemes.Wpf.PackIcon  5k      $��40��5l      $��40��5m         Kind$ KeyboardReturn=�5n      5p      �� 5r   
   $	 900��5t      $	 545��6   $
��Left=�5u      $	��Top=�6(   $	��133��5v      $��67��6   ���#49be25$��40(�5x      ��5s      �� *CheckoutOrderProduct+��5z        5{      $��40��5|      $��40��5}      $ CartArrowRight=�5~      5�      �� 5�   
   3	  -MaterialDesignThemes.Wpf.ButtonProgressAssist 	  IsIndeterminate$
 True��5�       	  IsIndicatorVisible$
 True��5�       	  Value$ -1Q�5�        MaterialDesignRaisedButton#��[ 5�      $��Chose Supplier��5�      $	 903��6&   $	 423��68   $
��Left=�6I   $��Center=�6d   ���#2c88af��5�      �� *OpenDialogSuppliers+5�      5�      