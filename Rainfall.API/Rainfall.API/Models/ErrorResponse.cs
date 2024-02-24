namespace Rainfall.API.Models;

public class ErrorResponse
{
    public string description { get; set; }
    public ErrorModel error_schema { get; set; }
}

public class ErrorModel
{
    public string title { get; set; }
    public string description { get; set; }
}