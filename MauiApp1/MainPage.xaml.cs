namespace MauiApp1;

public partial class MainPage : ContentPage
{
    private readonly Dictionary<string, (string imageSource, string fact)> vehicleData;

    public MainPage()
    {
        InitializeComponent();

        // Initialize the dictionary with vehicle data
        vehicleData = new Dictionary<string, (string imageSource, string fact)>
        {
            { "Car", ("car.png", "Cars were invented in the late 1800s! The first practical automobile was created by Karl Benz in 1885.") },
            { "Motorcycle", ("motorcycle.png", "The first motorcycle was created by Gottlieb Daimler in 1885. It was essentially a wooden bicycle with a gasoline engine!") },
            { "Bicycle", ("bicycle.png", "The modern bicycle design was introduced in the 1880s. It's the most energy-efficient form of human transport!") }
        };
    }

    private Void InitializeComponent()
    {
        throw new NotImplementedException();
    }

    private void OnVehicleSelected(object sender, EventArgs e)
    {
        if (vehiclePicker.SelectedItem is string selectedVehicle && 
            vehicleData.TryGetValue(selectedVehicle, out var vehicleInfo))
        {
            // Update the UI with the selected vehicle information
            vehicleImage.Source = vehicleInfo.imageSource;
            vehicleFactLabel.Text = vehicleInfo.fact;

            // Add a subtle animation to make the updates more engaging
            uint animationLength = 500;
            vehicleImage.Opacity = 0;
            vehicleFactLabel.Opacity = 0;

            vehicleImage.FadeTo(1, animationLength);
            vehicleFactLabel.FadeTo(1, animationLength);

            // Announce the change for accessibility
            SemanticScreenReader.Announce($"Selected {selectedVehicle}. {vehicleInfo.fact}");
        }
    }
}