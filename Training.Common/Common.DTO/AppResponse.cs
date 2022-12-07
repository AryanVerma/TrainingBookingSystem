namespace Training.Common.DTO
{

    public class AppResponse
    {
        public SuccessResponse Success => new SuccessResponse();

        public ErrorResponse Fail => new ErrorResponse();
    }
}
