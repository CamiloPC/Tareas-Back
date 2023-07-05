namespace TaskApi.Entities.ErrorModel
{
    public abstract class BadRequestException : Exception
    {
        protected BadRequestException(string message): base(message)
        {
        }
    }
}
