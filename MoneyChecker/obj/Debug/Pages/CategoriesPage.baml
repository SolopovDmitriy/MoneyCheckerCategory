   M S B A M L   `   `   `  ����G  CMoneyChecker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:MoneyChecker.PagesMoneyChecker.Pages  5      '    !MoneyChecker.Pages.CategoriesPage   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:MoneyChecker.Pages     5        N� Title$  CategoriesPage��5	       N� 
Background �	#FF54C56E � 	Resources 5
         catContextMenu m� Icon��%3  &	        �� 5   
   .@�5      m� $��Delete��6    5      �� 5      $��
cancel.png��6   5      m� 5      $��Insert��6    5      �� 5      $��
insert.png��6   5      m� 5      $��Change��6    5      �� 5      $��refresh.png��6   5      5      5      .��5      �  � RowDefinitions 5   
   �� 5      6    � ColumnDefinitions 5!   
   �� 5"      6!   �� 5#      6!   �� 5$      6!   .+�5&   
   R� -   5         R�Name$ Categories_TreeView��5&      $��0��61   $��0��6>   ��5'      �� 5(       �� ItemsSource 6+   �� *SubCategories+.R�5)      �� ��6    �� *Categ+5*      5,      �� 5-   
   $)��#Добавить категорию��6   $��1��6-   $
��Left=�6=   $��	10,10,0,0q�6X   $	��Top=�6k   �� 5.   
   -   5         ��Name$ newCategoriesTextBox��5.      $��1��60   $
��Left=�6@   $��23��6[   $��	10,41,0,0q�6g   	 �� TextWrapping$
	 Wrap=�6z   $	��Top=�6�   $	��247��6�   �� 5/   
   -   5        $��Добавить��5/      $��1��6$   $
��Left=�64   $��
182,96,0,0q�6O   $	��Top=�6c   $��75��6{   6�   �� 50   
   -   5        
 ��Name$
 parentCategoryComboBox��50      $��1��63   $
��Left=�6C   $��	10,69,0,0q�6^   $	��Top=�6q   $	��247��6�   51      52      