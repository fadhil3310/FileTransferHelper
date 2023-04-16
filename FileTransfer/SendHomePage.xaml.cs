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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FileTransfer
{
		/// <summary>
		/// Interaction logic for SendHomePage.xaml
		/// </summary>
		public partial class SendHomePage : Page
		{
				private Action<string[]> fileChoosen;
				private Action<string> folderChoosen;

				public SendHomePage(Action<string[]> fileChoosen, Action<string> folderChoosen)
				{
						InitializeComponent();
						this.fileChoosen = fileChoosen;
						this.folderChoosen = folderChoosen;
				}

				private void OpenFileButton_Click(object sender, RoutedEventArgs e)
				{
						OpenFileDialog openFileDialog = new OpenFileDialog();
						openFileDialog.Multiselect = true;
						if (openFileDialog.ShowDialog() == true)
						{
								fileChoosen(openFileDialog.FileNames);
						}
    }
  }
}
