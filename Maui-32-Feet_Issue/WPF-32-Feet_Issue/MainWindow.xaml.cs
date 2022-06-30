using InTheHand.Net.Sockets;
using System;
using System.Diagnostics;
using System.Windows;

namespace WPF_32_Feet_Issue
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var _bluetoothClient = new BluetoothClient();
                var devices = _bluetoothClient.DiscoverDevices();

                foreach (var device in devices)
                {
                    Debug.WriteLine($"device found:\t{device.DeviceName}\t{device.DeviceAddress}");
                }
                
                // device found:	name-1	C1847E39A49E
                // device found:	name-2  99D331F4426D
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error searching for devices:\t{ex.Message}");

                //Exception thrown: 'System.Runtime.InteropServices.COMException' in System.Private.CoreLib.dll
                //Error searching for devices:	A method was called at an unexpected time.
            }
        }
    }
}
