using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;

namespace AvaloniaTest
{
    public partial class MainWindow : Window
    {
        private string[] Values =
        {
            "Пока Олег",
            "Я сказал Пока",
            "Закрыть приложение"
        };
        private int valueId = -1;
        private string text { get { valueId++; return Values[valueId]; }}
        public MainWindow()
        {
            InitializeComponent();
            button.Click += ButtonClick;
        }

        private void ButtonClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if(valueId == Values.Length - 1)
                this.Close();
            else
                button.Content = text;
        }

        
    }
}