namespace PersonCRUD.Server.Records
{
    public record ErrorResponse(string Error, int StatusCode);

    public record TokenResponse(string AccessToken);
}
