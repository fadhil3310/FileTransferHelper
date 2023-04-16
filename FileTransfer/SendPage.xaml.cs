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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FileTransfer
{
		/// <summary>
		/// Interaction logic for SendPage.xaml
		/// </summary>
		public partial class SendPage : Page
		{
				private enum PageState
				{
						Home,
						FindDevice,
						Progress
				}

				private PageState pageState;

				private Action showNavigationView;
				private Action hideNavigationView;

				public SendPage(Action showNavigationView, Action hideNavigationView)
				{
						InitializeComponent();
						this.showNavigationView = showNavigationView;
						this.hideNavigationView = hideNavigationView;

						RegisterName(FindDevicePage.Name, FindDevicePage);
				}

				private void goToHomePage()
				{
						if (pageState == PageState.FindDevice)
						{
								showNavigationView();

								var homeAnim = new DoubleAnimation();
								homeAnim.From = 0;
								homeAnim.To = 1;
								homeAnim.Duration = new Duration(TimeSpan.FromMilliseconds(500));

								var findDeviceAnim = new DoubleAnimation();
								findDeviceAnim.From = 1;
								findDeviceAnim.To = 0;
								findDeviceAnim.Duration = new Duration(TimeSpan.FromMilliseconds(500));

								var findDeviceVisibilityAnim = new ObjectAnimationUsingKeyFrames { 
										Duration = new Duration(TimeSpan.Zero),
										BeginTime = TimeSpan.FromMilliseconds(500)
								};
								findDeviceVisibilityAnim.KeyFrames.Add(new DiscreteObjectKeyFrame {
										Value = Visibility.Collapsed
								});
								var homeVisibilityAnim = new ObjectAnimationUsingKeyFrames
								{
										Duration = new Duration(TimeSpan.Zero)
								};
								homeVisibilityAnim.KeyFrames.Add(new DiscreteObjectKeyFrame {
										Value = Visibility.Visible
								});

								var storyboard = new Storyboard();

								storyboard.Children.Add(homeAnim);
								storyboard.Children.Add(findDeviceAnim);
								storyboard.Children.Add(findDeviceVisibilityAnim);
								storyboard.Children.Add(homeVisibilityAnim);

								Storyboard.SetTargetName(homeAnim, HomePage.Name);
								Storyboard.SetTargetProperty(homeAnim, new PropertyPath(OpacityProperty));
								Storyboard.SetTargetName(findDeviceAnim, FindDevicePage.Name);
								Storyboard.SetTargetProperty(findDeviceAnim, new PropertyPath(OpacityProperty));
								Storyboard.SetTargetName(findDeviceVisibilityAnim, FindDevicePage.Name);
								Storyboard.SetTargetProperty(findDeviceVisibilityAnim, new PropertyPath(VisibilityProperty));
								Storyboard.SetTargetName(homeVisibilityAnim, HomePage.Name);
								Storyboard.SetTargetProperty(homeVisibilityAnim, new PropertyPath(VisibilityProperty));

								storyboard.Begin(this);
						}

						pageState = PageState.Home;
				}

				private void openFindDevicePage()
				{
						hideNavigationView();
						pageState = PageState.FindDevice;

						var homeAnim = new DoubleAnimation();
						homeAnim.From = 1;
						homeAnim.To = 0;
						homeAnim.Duration = new Duration(TimeSpan.FromMilliseconds(500));

						var findDeviceAnim = new DoubleAnimation();
						findDeviceAnim.From = 0;
						findDeviceAnim.To = 1;
						findDeviceAnim.Duration = new Duration(TimeSpan.FromMilliseconds(500));

						var findDeviceVisibilityAnim = new ObjectAnimationUsingKeyFrames
						{
								Duration = new Duration(TimeSpan.Zero)
						};
						findDeviceVisibilityAnim.KeyFrames.Add(new DiscreteObjectKeyFrame {
								Value = Visibility.Visible
						});
						var homeVisibilityAnim = new ObjectAnimationUsingKeyFrames {
								Duration = new Duration(TimeSpan.Zero),
								BeginTime = TimeSpan.FromMilliseconds(500)
						};
						homeVisibilityAnim.KeyFrames.Add(new DiscreteObjectKeyFrame {
								Value = Visibility.Collapsed
						});

						var storyboard = new Storyboard();
						storyboard.Children.Add(homeAnim);
						storyboard.Children.Add(findDeviceAnim);
						storyboard.Children.Add(findDeviceVisibilityAnim);
						storyboard.Children.Add(homeVisibilityAnim);

						Storyboard.SetTargetName(homeAnim, HomePage.Name);
						Storyboard.SetTargetProperty(homeAnim, new PropertyPath(Grid.OpacityProperty));
						Storyboard.SetTargetName(findDeviceAnim, FindDevicePage.Name);
						Storyboard.SetTargetProperty(findDeviceAnim, new PropertyPath(Grid.OpacityProperty));
						Storyboard.SetTargetName(findDeviceVisibilityAnim, FindDevicePage.Name);
						Storyboard.SetTargetProperty(findDeviceVisibilityAnim, new PropertyPath(VisibilityProperty));
						Storyboard.SetTargetName(homeVisibilityAnim, HomePage.Name);
						Storyboard.SetTargetProperty(homeVisibilityAnim, new PropertyPath(Grid.VisibilityProperty));

						FindDevicePage.Visibility = Visibility.Visible;
						storyboard.Begin(this);
				}

				private void openProgressPage()
				{

				}

				private void OpenFileButton_Click(object sender, RoutedEventArgs e)
				{
						OpenFileDialog openFileDialog = new OpenFileDialog();
						openFileDialog.Multiselect = true;
						if (openFileDialog.ShowDialog() == true)
						{
								openFindDevicePage();
						}
				}

				private void CancelButton_Click(object sender, RoutedEventArgs e)
				{
						goToHomePage();
				}
		}
}
