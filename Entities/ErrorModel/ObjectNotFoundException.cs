namespace TaskApi.Entities.ErrorModel
{
    public sealed class ObjectNotFoundException : NotFoundException
    {
        public ObjectNotFoundException(int id): base($"The object with the id: {id} does not exist.")
        {
        }
    }
}
