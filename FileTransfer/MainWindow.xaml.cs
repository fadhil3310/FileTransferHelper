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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Windows.Devices.WiFiDirect;
using Windows.UI.Xaml.Controls;
using Wpf.Ui;

namespace FileTransfer
{
		/// <summary>
		/// Interaction logic for MainWindow.xaml
		/// </summary>
		public partial class MainWindow : Window
		{
				private SendPage sendPage;


				public MainWindow()
				{
						InitializeComponent();
						navigateToSendPage();

						RegisterName(NavigationView.Name, NavigationView);
				}

				public void abc()
				{
						Frame.Opacity = 0;
						
				}

				private void navigateToSendPage()
				{
						if (sendPage == null)
								sendPage = new SendPage(ShowNavigationView, HideNavigationView);

						Frame.Navigate(sendPage);
						NavigationView.SelectedPageIndex = 0;
						SendNavItem.IsActive = true;
						ReceiveNavItem.IsActive = false;
				}

				private void navigateToReceivePage()
				{
						NavigationView.SelectedPageIndex = 1;
						SendNavItem.IsActive = false;
						ReceiveNavItem.IsActive = true;
				}
				
				public void ShowNavigationView()
				{
						var widthAnimation = new DoubleAnimation();
						widthAnimation.To = 60;
						widthAnimation.BeginTime = TimeSpan.FromMilliseconds(250);
						widthAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(750));
						widthAnimation.EasingFunction = new CubicEase();

						var storyboard = new Storyboard();
						storyboard.Children.Add(widthAnimation);
						Storyboard.SetTargetName(widthAnimation, NavigationView.Name);
						Storyboard.SetTargetProperty(widthAnimation,
								new PropertyPath(Wpf.Ui.Controls.NavigationStore.WidthProperty));

						storyboard.Begin(this);
				}

				public void HideNavigationView()
				{
						var widthAnimation = new DoubleAnimation();
						widthAnimation.To = 0;
						widthAnimation.BeginTime = TimeSpan.FromMilliseconds(250);
						widthAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(750));
						widthAnimation.EasingFunction = new CubicEase();

						var storyboard = new Storyboard();
						storyboard.Children.Add(widthAnimation);
						Storyboard.SetTargetName(widthAnimation, NavigationView.Name);
						Storyboard.SetTargetProperty(widthAnimation,
								new PropertyPath(Wpf.Ui.Controls.NavigationStore.WidthProperty));

						storyboard.Begin(this);
				}

				private void SendNavItem_Click(object sender, RoutedEventArgs e)
				{
						if (NavigationView.SelectedPageIndex == 0)
								return;

						navigateToSendPage();
				}

				private void ReceiveNavItem_Click(object sender, RoutedEventArgs e)
				{
						if (NavigationView.SelectedPageIndex == 1)
								return;

						navigateToReceivePage();
				}
		}
}
