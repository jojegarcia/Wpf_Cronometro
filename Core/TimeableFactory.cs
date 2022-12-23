namespace Core
{
    public class TimeableFactory
    {
        /// <summary>
        /// Gets an instance based on possible business rules
        /// </summary>
        public ITimeable GetInstance()
        {
            return new Watch();
        }
    }
}
