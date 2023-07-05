namespace TaskApi.Entities.ErrorModel
{
    public class MaxDateRangeBadRequestException :BadRequestException
    {
        public MaxDateRangeBadRequestException(): base("Max date can't be less than min date.")
        {
        }
    }
}
