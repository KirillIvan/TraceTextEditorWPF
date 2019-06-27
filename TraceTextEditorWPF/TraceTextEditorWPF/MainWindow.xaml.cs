using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.IO;

namespace TraceTextEditorWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
        OpenFileDialog openFileDialog = new OpenFileDialog();
        string key = "";
        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = new TimeSpan(0,0,2);
            timer.Tick += t_Tick;
            RegistryKey regkey = Registry.CurrentUser;
            RegistryKey key = regkey.OpenSubKey("TraceTEWPF");
            this.key = key.GetValue("Key Activate").ToString();
            key.Close();
            if(this.key != "2353-6756-5675" && this.key != "4364-0988-2342")
                timer.Start();
            CommandBinding command;
            command = new CommandBinding(ApplicationCommands.New);
            command.Executed += NewCommand_Executed;
            this.CommandBindings.Add(command);

            command = new CommandBinding(ApplicationCommands.Open);
            command.Executed += OpenCommand_Executed;
            this.CommandBindings.Add(command);

            command = new CommandBinding(ApplicationCommands.Save);
            command.Executed += SaveCommand_Executed;
            this.CommandBindings.Add(command);

            command = new CommandBinding(ApplicationCommands.Close);
            command.Executed += CloseCommand_Executed;
            this.CommandBindings.Add(command);

            if (this.key == "2353-6756-5675")
            {
                command = new CommandBinding(ApplicationCommands.Cut);
                command.Executed += HomeKey_Command_Executed;
                this.CommandBindings.Add(command);
                command = new CommandBinding(ApplicationCommands.Copy);
                command.Executed += HomeKey_Command_Executed;
                this.CommandBindings.Add(command);
                command = new CommandBinding(ApplicationCommands.Paste);
                command.Executed += HomeKey_Command_Executed;
                this.CommandBindings.Add(command);
            }
            if (this.key == "4364-0988-2342")
            {
            }
        }

        private void t_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            Activate activate = new Activate();
            if (activate.ShowDialog() == true)
            {
                RegistryKey regkey = Registry.CurrentUser;
                RegistryKey key = regkey.OpenSubKey("TraceTEWPF");
                this.key = key.GetValue("Key Activate").ToString();
                key.Close();
                if (this.key == "2353-6756-5675")
                {
                    CommandBinding command;
                    command = new CommandBinding(ApplicationCommands.Cut);
                    command.Executed += HomeKey_Command_Executed;
                    this.CommandBindings.Add(command);
                    command = new CommandBinding(ApplicationCommands.Copy);
                    command.Executed += HomeKey_Command_Executed;
                    this.CommandBindings.Add(command);
                    command = new CommandBinding(ApplicationCommands.Paste);
                    command.Executed += HomeKey_Command_Executed;
                    this.CommandBindings.Add(command);
                }
            }
            else if (key == "")
                this.Close();
        }
        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            text.Document.Blocks.Clear();
        }

        private void HomeKey_Command_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (MessageBox.Show("Изменить ключ активации?", "Недостаточно прав",
            MessageBoxButton.YesNo, MessageBoxImage.Error, MessageBoxResult.No) == MessageBoxResult.Yes)
                t_Tick(sender, new EventArgs());
        }

        private void OpenCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            openFileDialog.Filter = "txt файлы (*.txt)|*.txt|Html файлы (*.html)|*.html|RTF файлы (*rtf)|*.rtf";
            openFileDialog.FilterIndex = 2;
            if (openFileDialog.ShowDialog() == true)
            {

                TextRange doc = new TextRange(text.Document.ContentStart, text.Document.ContentEnd);
                using (FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open))
                {
                    if (System.IO.Path.GetExtension(openFileDialog.FileName) == ".txt")
                        doc.Load(fs, DataFormats.Text);
                    if (System.IO.Path.GetExtension(openFileDialog.FileName) == ".rtf")
                        doc.Load(fs, DataFormats.Rtf);
                    if (System.IO.Path.GetExtension(openFileDialog.FileName) == ".html")
                        doc.Load(fs, DataFormats.Html);
                }

            }
        }

        private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text Files (*.txt)|*.txt|RichText Files (*.rtf)|*.rtf|HTML Files (*.html)|*.html";
            if (sfd.ShowDialog() == true)
            {
                TextRange doc = new TextRange(text.Document.ContentStart, text.Document.ContentEnd);
                using (FileStream fs = File.Create(sfd.FileName))
                {
                    if (System.IO.Path.GetExtension(sfd.FileName).ToLower() == ".rtf")
                        doc.Save(fs, DataFormats.Rtf);
                    else if (System.IO.Path.GetExtension(sfd.FileName).ToLower() == ".txt")
                        doc.Save(fs, DataFormats.Text);
                    else
                        doc.Save(fs, DataFormats.Xaml);
                }
            }
        }

        private void CloseCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }
    }
}
