   M S B A M L   `   `   `  ����F  BWPF_Project, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:WPF_Project.ViewsWPF_Project.Views  5      ?$clr-namespace:WPF_Project.ValidationWPF_Project.Validation  5      ?$clr-namespace:WPF_Project.ViewModelsWPF_Project.ViewModels  5   L       WPF_Project.Views.Import   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:WPF_Project.Views     5      ?ValidationRule$clr-namespace:WPF_Project.Validation     5      _ [MaterialDesignThemes.Wpf, Version=4.7.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      ] YXceed.Wpf.Toolkit.NET5, Version=4.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f47toolkit)http://schemas.xceed.com/wpf/xaml/toolkit  5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      5
viewmodels$clr-namespace:WPF_Project.ViewModels  6L     N� Title$  Import��5	       N� FontSize$ 15(�5       � DataContext 5      ,   &WPF_Project.ViewModels.ImportViewModel  5   
   .��5      �� .+�5   
   �� $��IMPORT��5      $��30(�5      $
��Bold"�5      $
��Left=�6    �� Left$ 17��5      $	��Top=�6   
 �� Top$ 27��66   �� 5!   
   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Product's name��5"       �� 	MaxLength$ 40��5$         MaterialDesignFilledTextBox#��[  5%       �� TextWrapping$
 Wrap=�5&      $	 107��6!   $ 84��63   $
��Left=�6C   $��Center=�6^   $	��395��6y    J� RenderTransformOrigin$ 0.501,0.559&�6�   .  (MaterialDesignThemes.Wpf.TextFieldAssist!	   CharacterCounterVisibility	 5#      �� 
 �� Path$
 	IsChecked� �� ElementName$2 ,MaterialDesignFilledTextBoxTextCountComboBox��   BooleanToVisibilityConverter �� 	Converter# [ ��5'      �� *SearchProductName+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=��� 5*   
   $��Choose Product Import��5+       # MaterialDesignRaisedLightButton#��[ 5-       � ToolTip$4 .Resource name: MaterialDesignRaisedLightButton��5.      $	 116��5/      $	 156��6   $
��Left=�60   $��Center=�50      $
��Auto��6(   $��30��65   ��5,      �� *ChooseProductImport+50   5   &   System.Windows.Controls.DataGrid  53   
   -   5        $��gridProducts��54         CanUserAddRows$ False��55         SelectionMode$ Extended=�57         SelectionUnit$
 Cell=�58         AutoGenerateColumns$ False��59         
IsReadOnly$
 True��5:      $
��True��5;      $	��301��5<      $	 107��6   $	 206��6,   $
��Left=�6=   $��Center=�6X   $	��815��6s   ��56      �� *ListImportProduct+   Columns 5>      0  *System.Windows.Controls.DataGridTextColumn  5?      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 180 6L   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *Name+6L     5@      $ Quantity��6%   $	 100 6T    67   �� *
Quantity+6T     5A      $ Price��6%   $	 150 6N    64   �� *Price+6N     5B      $ Discount��6%   $	 100 6T    67   �� *
Discount+6T     5C      $ Category��6%   $	 150 6Y    67   �� *Category.Name+6Y   4	  .System.Windows.Controls.DataGridTemplateColumn	  5D      $ Actions��6)   $ 80 6:    	  CellTemplate 5E      �� 5F      .R�5G      �� ���#de782a��5H   !   �� *DataContext.RemoveProduct+ �� RelativeSource ��  �� AncestorType DataGrid��5I   !   �� ��5L   "   '
  !MaterialDesignThemes.Wpf.PackIcon
  5M   &    
  Kind$ Close=�6>   5O      5P      5R      5T      �� 5V   
   $��Total:��6   $��24(�5W      $	 639��5X      $	 523��6"   $
��Left=�5Y      $��Center=�6+   �� 5Z   
   $	��200��5\      $	 729��6   $	 525��6+   $��24(�5]      $
��Left=�6   $��Center=�66   ��5[      �� *TotalPriceOrder+5]   6   �� 5`   
   $	 922��5c      $	 574��6   $
��Left=�5d      $��Center=�6(   $	��115��5e      $��53��6   ���#49be25$��40(�5g      ��5a      �� *CheckoutImport+{�5b      �� *EnableButtonCheckout+$ TwoWay=���5i      
  5j      $��40��5k      $��40��5l      $ CartArrowRight=�5m      5o      5r      5s      