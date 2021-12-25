using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UnoPlatformTest1.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ProfilePage : Page
    {
        ObservableCollection<string> save_slots = new ObservableCollection<string>();
        ObservableCollection<string> farms = new ObservableCollection<string>();

        List<Mod> Mods = new List<Mod>()
        {
            new Mod("Elmcreek Better Farms", "0.4.0.3", true);
		}

        public void class Mod()
		{
            public string Name { get; set; }
            public string Version { get; set; }
            public bool Enabled { get; set; }

            public Mod(string name, string version, bool enabled)
			{
                Name = name;
                Version = version;
                Enabled = enabled;
			}
		}

        public ProfilePage()
        {
            this.InitializeComponent();
            for (int i = 1; i < 21; i++)
            {
                save_slots.Add("Save " + i);
            }
            farms.Add("Default Farm");
            farms.Add("Other farm");

            StackPanel modItem = new StackPanel()
            {
                Orientation = Orientation.Horizontal
            };
            TextBlock modName = new TextBlock()
            {
                Text = "Elmcreek Modified",
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center
            };
            Border modNameBorder = new Border()
            {
                BorderThickness = new Thickness(2),
                BorderBrush = new SolidColorBrush(Windows.UI.Colors.Black),
                Width = 200
            };
            TextBlock modVersion = new TextBlock()
            {
                Text = "0.4.0.3",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            Border modVersionBorder = new Border()
            {
                BorderThickness = new Thickness(2),
                BorderBrush = new SolidColorBrush(Windows.UI.Colors.Black),
                Width = 65
            };
            CheckBox modEnabled = new CheckBox()
            {
                IsChecked = true,
                Width = 40,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center
            };
            Border modEnabledBorder = new Border()
            {
                BorderThickness = new Thickness(2),
                BorderBrush = new SolidColorBrush(Windows.UI.Colors.Black),
                Width = 65
            };

            modNameBorder.Child = modName;
            modVersionBorder.Child = modVersion;
            modEnabledBorder.Child = modEnabled;
            modItem.Children.Add(modNameBorder);
            modItem.Children.Add(modVersionBorder);
            modItem.Children.Add(modEnabledBorder);

            ModsList.Children.Add(modItem);
        }
        private void TextBox_OnBeforeTextChanging(TextBox sender,
                                          TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = args.NewText.Any(c => !char.IsDigit(c));
        }
    }
}
