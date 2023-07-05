namespace TaskApi.Entities.ErrorModel
{
    public sealed class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException(string id): base($"The user with the id: {id} does not exist.")
        {
        }
    }
}
