namespace Application.Wrappers
{
    public class InvalidResponse<T> :Response<T>
    {
        public InvalidResponse(string[] messages)
        {
            Succeeded = false;
            Messages.AddRange(messages);
            Data = this.Data;
            Exception = null;
        }
    }
}
