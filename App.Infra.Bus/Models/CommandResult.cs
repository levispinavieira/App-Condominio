namespace App.Infra.Bus.Models
{
    public class CommandResult<TResponse>
    {
        private static CommandResult<TResponse> DefaultFailed = new CommandResult<TResponse>(false);
        
        public bool IsSuccess { get; set; }
        public TResponse Result { get; set; }
        
        public CommandResult(bool isSuccess = false)
        {
            IsSuccess = isSuccess;
        }

        public CommandResult(bool isSuccess, TResponse result)
        {
            IsSuccess = isSuccess;
            Result = result;
        }
        
        public static CommandResult<TResponse> CreateSuccessResult(TResponse body)
        {
            return new CommandResult<TResponse>(true, body);
        }
    }
}
