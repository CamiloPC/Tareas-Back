namespace TaskApi.Entities.ErrorModel
{
    public sealed class EmailConfigNotFoundException : BadRequestException
    {
        public EmailConfigNotFoundException() :base("Email configuration not found")
        {
        }
    }
}
