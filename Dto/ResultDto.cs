namespace database.Dto
{
    public class ResultDto<T>
    {
        public T Data { get; set; }
    }

    public class Success
    {
        public string Data { get; set; }
    }
}
