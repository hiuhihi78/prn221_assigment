   M S B A M L   `   `   `  ����F  BWPF_Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:WPF_Project.ViewsWPF_Project.Views  5   	   ?$clr-namespace:WPF_Project.ViewModelsWPF_Project.ViewModels  5   R   *    $WPF_Project.Views.DialogSupplierInfo   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:WPF_Project.Views     5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	   	   ] YXceed.Wpf.Toolkit.NET5, Version=4.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f47toolkit)http://schemas.xceed.com/wpf/xaml/toolkit  5
   	   _ [MaterialDesignThemes.Wpf, Version=4.7.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   5
viewmodels$clr-namespace:WPF_Project.ViewModels  6R   $��15(�5   	     � WindowStartupLocation$  CenterScreen=�5   	    � WindowStyle$
 None=�5   	   
�������$	��489��5   !   $	��455��6-   .��5      �� .+�5   
   �� $��Supplier's info��5      $��30(�5      $
��Bold"�5      $
��Left=�6    �� Left$ 24��5      $	��Top=�6   
 �� Top$ 10��66   �� 5   
   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Supplier Name��5       �� 	MaxLength$ 30��5         MaterialDesignFilledTextBox#��[  5       �� TextWrapping$
 Wrap=�5      $ 69��6!   $ 94��62   $��Center=�6B   $	��330��6_   $	��Top=�6k   .  (MaterialDesignThemes.Wpf.TextFieldAssist!   CharacterCounterVisibility 5      ��  �� Path$ 	IsChecked�	 �� ElementName$2	 ,MaterialDesignFilledTextBoxTextCountComboBox����5      �� *Supplier.Name+
 �� UpdateSourceTrigger$
 PropertyChanged=� �� Mode$ TwoWay=�{�5      �� *	CanEdit+�� 5"   
   -   5        $ Supplier Phone��5#       �� AcceptsReturn$
 True��5$      #��[  5%      $
 Wrap=�5&      $ 69��6!   $	 170��62   $��Center=�6C   $	��Top=�6`   $	��330��6x   $ 10��5)      ��5'      �� *Supplier.Phone+$
 PropertyChanged=�$ TwoWay=�{�5(      �� *	CanCreate+5*      �� 5,   
   $ Supplier Address��5-      $
 True��5.      #��[  5/      $
 Wrap=�50      $ 69��6!   $	 248��62   $��Center=�6C   $	��Top=�6`   $	��330��6x   ��51      �� *Supplier.Address+$
 PropertyChanged=�$ TwoWay=�{�52      �� *	CanEdit+�� 55   
   $	 162��56      $	 350��6   $��Center=�57      $	��Top=�6*   $	��106��58      $��68��6   ���#49be25$��40(�5:       � ToolTip$
 Save��5;      ��5<      �� *SaveCommand+ � 	Resources 5>       �� 
TargetType �� Property �� Value �� Triggers �� Binding �� Value��%�   '��       �� 5?      " ��6   .�5@      ��  � y�$ Visible=�63    5A      �� 5B       6&   �� *	CanEdit+	 False6B   .a�5C      ��  � y�$ 	Collapsed=�6;   5D      5F      5G      ��5H      '  !MaterialDesignThemes.Wpf.PackIcon  5I      $��40��5J      $��40��5K         Kind$ CheckCircleOutline=�5L      $��Center=�6/   5N      �� 5P   
   -   5        $	 292��5Q      $	 354��6   $��Center=�5R      $	��Top=�6*   $	��107��5S      $��68��6   ���#0077d0$��40(�5U      $
 Back��5V      ��5Y        5Z      $��40��5[      $��40��5\      $ KeyboardReturn=�5]      5_      5`      5a      