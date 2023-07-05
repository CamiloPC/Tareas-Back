namespace TaskApi.Entities.ErrorModel
{
    public class NotFoundException:Exception
    {
        protected NotFoundException(string msg):base(msg) {
        }
    }
}
