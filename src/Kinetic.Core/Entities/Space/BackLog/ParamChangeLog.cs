namespace Kinetic.Core.Entities.Space.BackLog
{
    public class ParamChangeLog<T> : Log
    {
        public string ClassName { get; set; }
        public T From { get; set; }
        public T To { get; set; }
    }
}
