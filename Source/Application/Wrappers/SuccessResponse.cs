namespace Application.Wrappers
{
    public class SuccessResponse<T> : Response<T>
    {
        public SuccessResponse(T data)
        {
            Succeeded = true;
            Messages = null;
            Data = data;
            Exception = null;
        }
    }
}
