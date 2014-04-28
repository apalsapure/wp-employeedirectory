using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;

namespace EmployeeDirectory
{
    public partial class DetailsPage : PhoneApplicationPage
    {
        private string _source;
        public DetailsPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string selectedIndex = "";
            if (NavigationContext.QueryString.TryGetValue("selectedItem", out selectedIndex))
            {
                var user = App.ViewModel.Items.Where(i => i.Id == selectedIndex).FirstOrDefault();
                var context = new ItemViewModel(user);
                DataContext = context;
                if (!context.IsDataLoaded)
                {
                    context.LoadData();
                }
            }
            NavigationContext.QueryString.TryGetValue("source", out _source);

            if (string.IsNullOrEmpty(_source))
                NavigationService.RemoveBackEntry();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // If selected item is null (no selection) do nothing
            if (ListBox.SelectedItem == null)
                return;

            // Navigate to the new page
            NavigationService.Navigate(new Uri("/DetailsPage.xaml?selectedItem=" + (ListBox.SelectedItem as Employee).Id, UriKind.Relative));

            // Reset selected item to null (no selection)
            ListBox.SelectedItem = null;
        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            var linkButton = sender as HyperlinkButton;
            // Navigate to the new page
            NavigationService.Navigate(new Uri("/DetailsPage.xaml?selectedItem=" + linkButton.CommandParameter, UriKind.Relative));
        }

        private void PhoneHyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            var linkButton = sender as HyperlinkButton;
            PhoneCallTask phoneCallTask = new PhoneCallTask();
            phoneCallTask.PhoneNumber = linkButton.CommandParameter as string;
            phoneCallTask.Show();
        }

        private void EmailHyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            var linkButton = sender as HyperlinkButton;
            EmailComposeTask emailComposeTask = new EmailComposeTask();
            emailComposeTask.To = linkButton.CommandParameter as string;
            emailComposeTask.Subject = "Sample Email";
            emailComposeTask.Show();
        }
    }
}