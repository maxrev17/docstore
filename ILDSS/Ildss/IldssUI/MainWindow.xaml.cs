﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using MahApps.Metro.Controls;

using Ildss;
using Ildss.Index;
using Ildss.Models;
using Ildss.Storage;
using System.Drawing;
using CloudInterface;

namespace IldssUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        
        public MainWindow()
        {
            InitializeComponent();
            //docList.ItemsSource = KernelFactory.Instance.Get<IFileIndexContext>().DocPaths.Where(i => i.Document.Status == Enums.DocStatus.Archived).ToList();
            this.Hide();
            Task.Run(() =>
            {
                KernelFactory.Instance.Get<IEventManager>("Index");
                KernelFactory.Instance.Get<IMonitor>().Monitor(Settings.Default.WorkingDir);
            });

            System.Windows.Forms.NotifyIcon ni = new System.Windows.Forms.NotifyIcon();
            ni.Icon = new System.Drawing.Icon("../../cloud.ico");
            ni.Visible = true;
            ni.DoubleClick +=
                delegate(object sender, EventArgs args)
                {
                    this.Show();
                    this.WindowState = WindowState.Normal;
                };
        }

        protected override void OnStateChanged(EventArgs e)
        {
            if (WindowState == WindowState.Minimized)
                this.Hide();

            base.OnStateChanged(e);
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            btnExportCSV.Content = "Exporting...";
            await Task.Run(() =>
                {
                    StatsExport.Export();
                });
            btnExportCSV.Content = "Export CSV";
        }

        private async void btnS3_Click(object sender, RoutedEventArgs e)
        {
            btnS3.IsEnabled = false;
            await Task.Run(() =>
                {
                    // need an index here - also ensure all files closed or make not as upload will fail
                    KernelFactory.Instance.Get<IStorage>("Cloud").StoreIncrAsync();
                });
            btnS3.IsEnabled = true;
        }

        private async void btnIntelligence_Click(object sender, RoutedEventArgs e)
        {
            btnIntelligence.IsEnabled = false;
            await Task.Run(() =>
                {
                    KernelFactory.Instance.Get<IStorage>("Cloud").RemoveUnusedDocumentsAsync();
                });
            btnIntelligence.IsEnabled = true;
        }

        private void docList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnRetrieve.IsEnabled = false;
            btnDelete.IsEnabled = false;
            if (e.AddedItems.Count != 0)
            {
                var path = e.AddedItems[0] as DocPath;
                verList.ItemsSource = KernelFactory.Instance.Get<IFileIndexContext>().DocVersions.
                    Where(i => i.Document.DocPaths.Any(j => j.Path == path.Path)).
                    OrderByDescending(k => k.DocEventTime).ToList();
            }
        }

        private void verList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count != 0)
            {
                btnRetrieve.IsEnabled = true;
                btnDelete.IsEnabled = true;
            }
            else
            {
                btnRetrieve.IsEnabled = false;
                btnDelete.IsEnabled = false;
            }
        }

        private void btnRetrieve_Click(object sender, RoutedEventArgs e)
        {
            var path = docList.SelectedItem as DocPath;
            var version = verList.SelectedItem as DocVersion;

            Console.WriteLine(path.Path);
            Console.WriteLine(version.VersionKey);

            // initialise s3 download of version.versionkey
        }

        private void txtSearch_Changed(object sender, TextChangedEventArgs e)
        {
            docList.SelectedItem = null;
            verList.SelectedItem = null;
            verList.ItemsSource = null;

            if (txtSearch.Text.Count() > 2)
            {
                // search the db
                var paths = KernelFactory.Instance.Get<IFileIndexContext>().DocPaths.Where(i => i.Path.Contains(txtSearch.Text) && i.Document.Status == Enums.DocStatus.Archived).ToList();
                docList.ItemsSource = paths;
            }
            else
            {
                docList.ItemsSource = KernelFactory.Instance.Get<IFileIndexContext>().DocPaths.Where(i => i.Document.Status == Enums.DocStatus.Archived).ToList();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(this, "This file version will be delete from cloud storage forever, do you wish to continue?",
                "Confirmation", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.OK)
            {
                // Yes code here
            }
            else
            {
                // No code here
            } 
        }

        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TabItem item = sender as TabItem;
            //Console.WriteLine("Changed Tab " + item);
            //if (item == tabRetrieve)
            //{
                docList.ItemsSource = KernelFactory.Instance.Get<IFileIndexContext>().DocPaths.Where(i => i.Document.Status == Enums.DocStatus.Archived).ToList();
                //Console.WriteLine("OK BABY LETS GO " + item.Name);
            //}
        }
    }
}
