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

namespace Assignment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Activity> allActivities = new List<Activity>();

        List<Activity> selectedActivities = new List<Activity>();

        List<Activity> filteredActivities = new List<Activity>();

        string description = "Nothing Selected";
        decimal totalCost = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // create some Activities
            Activity kayak = new Activity("Kayaking", "Half day lakeland kayak with island picnic.", new DateTime(2019,6,1), Type.Water, 40m);
            Activity parachute = new Activity("Parachuting", "Experience the thrill of free fall while you tandem jump from an airplane.", new DateTime(2019,6,1), Type.Air, 100m);
            Activity biking = new Activity("Mountain Biking", "Instructor led half day mountain biking.  All equipment provided.", new DateTime(2019,6,2), Type.Land, 30m);
            Activity gliding = new Activity("Hang Gliding", "Soar on hot air currents and enjoy spectacular views of the coastal region.", new DateTime(2019,6,2), Type.Air, 80m);
            Activity abseiling = new Activity("Abseiling", "Experience the rush of adrenaline as you descend cliff faces from 10-500m.", new DateTime(2019,6,3), Type.Land, 40m);
            Activity sailing = new Activity("Sailing", "Full day lakeland kayak with island picnic.", new DateTime(2019,6,3), Type.Water, 50m);
            Activity helicopter = new Activity("Helicopter Tour", "Experience the ultimate in aerial sight-seeing as you tour the area in our modern helicopters", new DateTime(2019,6,3), Type.Air, 200m);
            Activity treking = new Activity("Treking", "Instructor led group trek through local mountains.", new DateTime(2019,6,1), Type.Land, 20m);
            Activity surfing = new Activity("Surfing", "2 hour surf lesson on the wild atlantic way", new DateTime(2019,6,2), Type.Water, 25m);

            // add to list
            allActivities.Add(kayak);
            allActivities.Add(parachute);
            allActivities.Add(biking);
            allActivities.Add(gliding);
            allActivities.Add(abseiling);
            allActivities.Add(sailing);
            allActivities.Add(helicopter);
            allActivities.Add(treking);
            allActivities.Add(surfing);
            allActivities.Sort();

            // Display in List Box
            lbxActivities.ItemsSource = allActivities; // gives the List Box a source to display from
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            // Determine selected item
            Activity selectedActivity = lbxActivities.SelectedItem as Activity;

            // null check
            if(selectedActivity != null)
            {
                // move item from left list box to right
                allActivities.Remove(selectedActivity);

                selectedActivities.Add(selectedActivity);

                selectedActivities.Sort();

                RefreshScrn();
            }

            totalCost += selectedActivity.Cost;

            txtTotal.Text = string.Format($"{totalCost:C}");
        }

        private void BtnRemove_Click(object sender, RoutedEventArgs e)
        {
            // Determine selected item
            Activity selectedActivity = lbxSelected.SelectedItem as Activity;

            // null check
            if(selectedActivity != null)
            {
                // move item from right list box to left
                selectedActivities.Remove(selectedActivity);

                allActivities.Add(selectedActivity);

                RefreshScrn(); 
            }

            totalCost -= selectedActivity.Cost;

            txtTotal.Text = string.Format($"{totalCost:C}");
        }

        private void RefreshScrn()
        {
            lbxActivities.ItemsSource = null;
            lbxActivities.ItemsSource = allActivities;

            lbxSelected.ItemsSource = null;
            lbxSelected.ItemsSource = selectedActivities;
        }
        private void FilteredRefreshScrn()
        {
            lbxActivities.ItemsSource = null;
            lbxActivities.ItemsSource = filteredActivities;
        }

        // handles all radio button clicks
        private void RbAll_Click(object sender, RoutedEventArgs e)
        {
            filteredActivities.Clear();

            if(rbAll.IsChecked == true)
            {
                // show all activities

                RefreshScrn();
            }
            else if(rbLand.IsChecked == true)
            {
                // show all land activities

                foreach (Activity activity in allActivities)
                {
                    if(activity.Type == Type.Land)
                    {
                        filteredActivities.Add(activity);
                        FilteredRefreshScrn();
                    }

                }
            }
            else if(rbWater.IsChecked == true)
            {
                // show all water activities

                foreach (Activity activity in allActivities)
                {
                    if (activity.Type == Type.Water)
                    {
                        filteredActivities.Add(activity);
                        FilteredRefreshScrn();
                    }
                }
            }
            else if(rbAir.IsChecked == true)
            {
                // show all air activities

                foreach (Activity activity in allActivities)
                {
                    if (activity.Type == Type.Air)
                    {
                        filteredActivities.Add(activity);
                        FilteredRefreshScrn();
                    }
                }
            }
        }

        private void LbxActivities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Activity selectedActivity = lbxActivities.SelectedItem as Activity;

            if(selectedActivity == null)
            {

            }
            else
            {
                description = string.Format($"{selectedActivity.Description}. Cost = {selectedActivity.Cost:C}");
                txtDescription.Text = null;
                txtDescription.Text = description;
            }
        }

        private void LbxSelected_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Activity selectedActivity = lbxSelected.SelectedItem as Activity;

            if (selectedActivity == null)
            {

            }
            else
            {
                description = string.Format($"{selectedActivity.Description}. Cost = {selectedActivity.Cost:C}");
                txtDescription.Text = null;
                txtDescription.Text = description;
            }
        }
    }
}
