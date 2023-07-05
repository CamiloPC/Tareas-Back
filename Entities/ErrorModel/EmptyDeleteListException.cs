namespace TaskApi.Entities.ErrorModel
{
    public sealed class EmptyDeleteListException : NotFoundException
    {
        public EmptyDeleteListException(): base($"The delete list is empty")
        {
        }
    }
}
