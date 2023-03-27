﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using App.StudentManagement.Helpers;

namespace WPF.StudentManagement
{
    public partial class InstructorPage : Page
    {
        public InstructorPage()
        {
            InitializeComponent();
        }

        private void PersonButton_Click(object sender, RoutedEventArgs e)
        {
            //InstructorPageFrame.Content = new InstructorStudentData();
            InstructorMenuContent.Visibility = Visibility.Collapsed;
            InstructorPageFrame.Visibility = Visibility.Visible;
        }

        private void CourseButton_Click(object sender, RoutedEventArgs e)
        {
            InstructorPageFrame.Content = new InstructorCourseData();
            InstructorMenuContent.Visibility = Visibility.Collapsed;
            InstructorPageFrame.Visibility = Visibility.Visible;
        }
    }
}
