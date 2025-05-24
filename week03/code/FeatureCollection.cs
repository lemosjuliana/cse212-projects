// Deserialization of JSON data into C# objects

public class FeatureCollection
{
    public string Type { get; set; } // Type of the collection
    public List<Feature> Features { get; set; } // List of earthquake records..

    // Individual Earthquake Data
    public class Feature
    {
        public Properties Properties { get; set; } // details about the earthquake
    }

    // Location (Place) and Magnitude (Mag)
    public class Properties
    {
        public string Place { get; set; }
        public double? Mag { get; set; }
    }

    // Creates an empty list to store formatted earthquake data
    public string[] GetSummaries()
    {
        var summaries = new List<string>();

        if (Features != null) // checks if feature exists to avoid errors..
        {
            foreach (var feature in Features)
            {
                // Make sure Properties is not null
                if (feature.Properties != null)
                {
                    string place = feature.Properties.Place;
                    double? mag = feature.Properties.Mag;

                    // Only add if both place and mag are present
                    if (!string.IsNullOrEmpty(place) && mag.HasValue)
                    {
                        summaries.Add($"{place} - Mag {mag.Value}"); // Format the output data
                    }
                }
            }
        }

        return summaries.ToArray();
    }
}