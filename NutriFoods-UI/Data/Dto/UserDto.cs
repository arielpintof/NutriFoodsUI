namespace NutriFoods_UI.Data.Dto;

public class UserDto
{
    public Guid Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string ApiKey { get; set; } = string.Empty;
    public DateTime JoinedOn { get; set; }
    public double? TotalMetabolicRate { get; set; }
    public UserDataDto? UserData { get; set; }
    public ICollection<UserBodyMetricDto> UserBodyMetrics { get; set; } = null!;
    public MealPlanDto? MealPlan { get; set; }
}