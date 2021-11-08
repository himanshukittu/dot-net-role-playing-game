namespace asp_net_course_udemy.Models
{
    public class GeneralResponse<T>
    {
        public bool IsSuccess { get; set; } = true;
        public string[] errors { get; set; }
        public string errorMessage { get; set; }
        public T response { get; set; }
    }
}