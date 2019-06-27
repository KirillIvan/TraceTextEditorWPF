using Microsoft.Win32;
using System;
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
using System.Windows.Shapes;

namespace TraceTextEditorWPF
{
    /// <summary>
    /// Логика взаимодействия для Activate.xaml
    /// </summary>
    public partial class Activate : Window
    {
        public Activate()
        {
            InitializeComponent();
        }

        private void BtnActivated_Click(object sender, RoutedEventArgs e)
        {
            if (keyBox.Text == "4364-0988-2342"||keyBox.Text == "2353-6756-5675")
            {
                RegistryKey regkey = Registry.CurrentUser;
                RegistryKey key = regkey.CreateSubKey("TraceTEWPF");
                key.SetValue("Key Activate", keyBox.Text);
                key.Close();
                this.DialogResult = true;
            }
            else
            {
                errorBlock.Visibility = Visibility.Visible;
                keyBox.Text = "";
            }
        }

        private void KeyBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (keyBox.Text == "xxxx-xxxx-xxxx")
                keyBox.Text = "";
        }

        private void KeyBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int val;
            if (!Int32.TryParse(e.Text, out val) && e.Text != "-")
            {
                e.Handled = true;
            }
        }

        private void KeyBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (keyBox.Text.Length > 14)
            {
                keyBox.Text = keyBox.Text.Remove(14);
                keyBox.Select(14, 0);
            }

        }
    }
}
