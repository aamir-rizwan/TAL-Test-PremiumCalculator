namespace TAL_PremiumCalculatorAPI.Models
{
    public class Result
    {
        public string Error { get; private set; }
        public int StatusCode { get; private set; }

        public bool IsSuccess => string.IsNullOrEmpty(Error);
        public bool IsFailure => !IsSuccess;

        public Result(string errorMessage, int statusCode)
        {
            Error = errorMessage;
            StatusCode = statusCode;
        }

        public Result(int statusCode)
        {
            StatusCode = statusCode;
        }

        public static Result Success()
        {
            return new Result(StatusCodes.Status200OK);
        }

        public static Result<T> Success<T>(T data)
        {
            return new Result<T>(data, StatusCodes.Status200OK);
        }

        public static Result Failure(string errorMessage, int statusCode = StatusCodes.Status400BadRequest)
        {
            return new Result(errorMessage, statusCode);
        }
        public static Result InternalServerErrorFailure(string errorMessage = "An error occured.")
        {
            return new Result(errorMessage, StatusCodes.Status500InternalServerError);
        }
        public static Result<T> InternalServerErrorFailure<T>(string errorMessage = "An error occured.")
        {
            return new Result<T>(errorMessage, StatusCodes.Status500InternalServerError);
        }

        public static Result<T> Failure<T>(string errorMessage, int statusCode = StatusCodes.Status400BadRequest)
        {
            return new Result<T>(errorMessage, statusCode);
        }
    }

    public class Result<T> : Result
    {
        public T Data { get; private set; }

        public Result(T data, int statusCode) : base(statusCode)
        {
            Data = data;
        }

        public Result(string errorMessage, int statusCode)
            : base(errorMessage, statusCode)
        { }
    }
}
