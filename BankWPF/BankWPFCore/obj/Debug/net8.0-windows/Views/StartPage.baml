   M S B A M L   `   `   `  ����F  BBankWPFCore, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:BankWPFCore.ComponentsBankWPFCore.Components  5      5clr-namespace:BankWPFCore.ViewsBankWPFCore.Views  5      ?$clr-namespace:BankWPFCore.ViewModelsBankWPFCore.ViewModels  5	      !    BankWPFCore.Views.StartPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      ;
components$clr-namespace:BankWPFCore.Components     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:BankWPFCore.Views     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      ;
viewmodels$clr-namespace:BankWPFCore.ViewModels     5	        � 	Resources  5         MyButtonStyle �� 
TargetType �� Property �� Value��%  &	        �� 5   
   " ��6&   .�5      ��  � ��$ Stretch=�62   �� 5       � ��$ 31��6'   �� 5       � ��$ 0q�60   �� 5       � ��
 �����6+   �� 5       � ��
 �   �6+   �� 5       � ��$
 Auto��6'   5"      5$      .��5&      �  � RowDefinitions 5'   
   �� 5(      $��70 �6   �� 5*      $
��120* �6    � ColumnDefinitions 5-   
   �� 5.      $	��170 �6   �� 5/      $
��173* �6   .+�52   
   � $��1��6   ���	#FFE1FCFC 53      �� 54      $	��200 �6    �� 55      $	��30* �6    .+�59      � .+�5<      *   $BankWPFCore.Components.NavigationBar  $	��200��6+    � DataContext 68   �� *NavigationViewModel+5`      5l      � 5n   
   ���	#FF62F6C5.+�5o      ��   MyLabelStyle#��[ 5p      5r      � 5t   
   $��0��5u      $��1��5v      ���	#FFE1FCFC.+�5x      �� $��20,0,0,0q�5y      $��Center=�5z      $��20(�5{      $&�� Добро пожаловать!��5|      5}      � 5   
   $��1��6   $��1��6    5�      �� 5�      $
��269* �6    �� 5�      $
��103* �6    .+�5�      � $��0��6   
�������.+�5�      7  1System.Windows.Forms.Integration.WindowsFormsHost  $��0,0,0,0q�5�      $��Stretch=�5�         
Background �	#FF84DEDE5�      �� 5�      $��Stretch=�5�      $��Stretch=�5�      $!��/Resourses/sm_img-50005.jpg��5�      $��UniformToFill=�5�      5�      � 5�      $��1��6   $��0,0,0,0q�6     5�      �� 5�      $
��221* �6'   �� 5�      $
��218* �6'   �� 5�      $
��221* �6'   .+�5�      �� $��0��5�      $
��auto��5�      $
��auto��5�      $��0,0,0,0q�5�      ���	#FFC8D8E6$��0q�5�      $�� ��5�      �� 5�      $��1��5�      $
��auto��5�      $
��auto��5�      $��0,0,0,0q�5�      ���	#FFE1FCFC$��0q�5�      $�� ��5�      �� 5�      $��2��5�      $
��auto��5�      $
��auto��5�      $��0,0,0,0q�5�      
�������$��0q�5�      $�� ��5�      5�      5�      5�      5�      