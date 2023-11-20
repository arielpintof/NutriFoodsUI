namespace NutriFoods_UI.Data.Images;

public class ImageReader
{
    private readonly string _filePath = Path.Combine(@"C:/Users/Rock-/RiderProjects2.0/NutriFoods-UI/NutriFoods-UI", "Data", "Images", "ImgCsv.csv");
    public static Dictionary<string, string> ImageUrls { get; } = new();
    
    public ImageReader() => SetImageUrls();

    private void SetImageUrls()
    {
        using var reader = new StreamReader(_filePath);
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine()!;
            var parts = line.Split(';');
            var key = parts[0];
            var value = parts[1];
            ImageUrls.TryAdd(key, value);
        }

    }
}