   M S B A M L   `   `   `  ����F  BWPF_Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:WPF_Project.ViewsWPF_Project.Views  5   	   ?$clr-namespace:WPF_Project.ViewModelsWPF_Project.ViewModels  5   R   +    %WPF_Project.Views.ChooseProductImport   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:WPF_Project.Views     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5
   
   ] YXceed.Wpf.Toolkit.NET5, Version=4.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f47toolkit)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   _ [MaterialDesignThemes.Wpf, Version=4.7.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   5
viewmodels$clr-namespace:WPF_Project.ViewModels  6R   $��15(�5   	     � WindowStartupLocation$  CenterScreen=�5   	    � WindowStyle$
 None=�5   	   
�������$	��953��5   !   $	��633��6-   .��5      �� .+�5   
   �� $��Product's info��5      $��30(�5      $
��Bold"�5      $
��Left=�6    �� Left$ 24��5      $	��Top=�6   
 �� Top$ 10��66   �� 5   
   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Search Product��5       �� AcceptsReturn$
 True��5         MaterialDesignFilledTextBox#��[  5       �� TextWrapping$
 Wrap=�5      $ 33��6!   $ 69��62   $
��Left=�6B   $��Center=�6]   $	��300��6x   $��58��5   ]   ��6   �� *SearchProduct+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�6]   &   System.Windows.Controls.DataGrid  5#   
   -   5        $��gridProducts��5$      	   CanUserAddRows$	 False��5%      
   SelectionMode$
 Extended=�5'         SelectionUnit$
 Cell=�5(         AutoGenerateColumns$ False��5)         
IsReadOnly$
 True��5*      $
��True��5+      $	��301��5,      $ 27��6   $	 144��6+   $
��Left=�6<   $	��Top=�6W   $	��542��6o   ��5&      �� *ListProduct+   Columns 5.      0  *System.Windows.Controls.DataGridTextColumn  5/      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 160 6L   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *Name+6L     50      $ Quantity��6%   $	 120 6T    67   �� *
Quantity+6T     51      $ Price��6%   $	 150 6N    64   �� *Price+6N   4  .System.Windows.Controls.DataGridTemplateColumn  53      $  ��6)   $ 80 63      CellTemplate 54      �� 55      .R�56      �� ���#696eb3��57   !   �� *" DataContext.ChooseProductCommand+ �� RelativeSource ��  �� AncestorType DataGrid��58   !   �� ��5;   "   '  !MaterialDesignThemes.Wpf.PackIcon  5<   &      Kind$ 	PlusThick=�6>   5>      5?      5A      5C      �� 5G   
   $ Product��5H      $
 True��5I      #��[  5J      $
 Wrap=�5K      $	 596��6!   $	 150��63   $��Center=�6D   $	��Top=�6a   $	��300��6y   $��58��5L   \   ${�False��5M      ��5L      �� *Product.Name+$ PropertyChanged=�$ TwoWay=�5M      �� 5P   
   -   5        $ Quantity��5Q      $
 True��5R      #��[  5S      $
 Wrap=�5T      $	 596��6!   $	 217��63   $��Center=�6D   $	��Top=�6a   $	��300��6y   $��58��5U   `   ��6   �� *Product.Quantity+$ PropertyChanged=�$ TwoWay=�5V      �� 5Y   
   -   5        $ Price��5Z      $
 True��5[      #��[  5\      $
 Wrap=�5]      $	 596��6!   $	 287��63   $��Center=�6D   $	��Top=�6a   $	��300��6y   $��58��5^   ]   ��6   �� *Product.Price+$ PropertyChanged=�$ TwoWay=�5_      �� 5b   
   $
��Wrap=�5c      $	 604��6!   $	 367��63   $��Center=�5d      $	��Top=�6*   $	��106��6B   $��42��6N   $��Discount��5e      $��17(�5f      $	  Xceed.Wpf.Toolkit.DoubleUpDown	  5i   
   -   5        $ Discount��5j      $	��166��5k      $	 730��5l      $	 356��6   $��Center=�5m      $��52��6*   $	��Top=�66   ���#e5e3e8�
  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Double, System.Runtime, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]] 
  Maximum 1005o       
  Minimum 05p      ,  &Xceed.Wpf.Toolkit.Primitives.InputBase   Text 5q      �� *Product.Discount+$ PropertyChanged=�$ TwoWay=�{�5s      �� *IsEnableItem+.  (System.Windows.Interactivity.Interaction   Triggers 5u      /  )System.Windows.Interactivity.EventTrigger  5v         	EventName$ ValueChanged��6!   5x      5z      �� 5|   
   $��Total:��6   $��24(�5}      $	 596��5~      $	 419��6"   $��Center=�5      $	��Top=�6-   �� 5�   
   $	��194��5�      $	 730��6   $	 423��6+   $��24(�5�      $
��Left=�6   $	��Top=�66   ��5�      �� *Total+5�   6   �� 5�   
   $	 625��5�      $	 523��6   $
��Left=�5�      $	��Top=�6(   $	��106��5�      $��68��6   ���#49be25$��40(�5�       � ToolTip$
 Save��5�      ��5�      �� *SaveCommand+��5�        5�      $��40��5�      $��40��5�      $ CheckCircleOutline=�5�      $��Center=�6/   5�      �� 5�   
   -   5        $	 772��5�      $	 523��6   $
��Left=�5�      $	��Top=�6(   $	��106��5�      $��68��6   ���#0077d0$��40(�5�      $
 Back��5�      ��5�        5�      $��40��5�      $��40��5�      $ KeyboardReturn=�5�      $��Center=�6+   5�      5�      5�      