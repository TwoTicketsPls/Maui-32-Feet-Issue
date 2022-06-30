using InTheHand.Net.Sockets;
using System.Diagnostics;

namespace Maui_32_Feet_Issue;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

        try
        {
            var _bluetoothClient = new BluetoothClient();
            var devices = _bluetoothClient.DiscoverDevices();

            foreach (var device in devices)
            {
                Debug.WriteLine($"device found:\t{device.DeviceName}\t{device.DeviceAddress}");
            }


        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error searching for devices:\t{ex.Message}");

            //Exception thrown: 'System.Runtime.InteropServices.COMException' in System.Private.CoreLib.dll
            //Error searching for devices:	A method was called at an unexpected time.
        }
    }
}

