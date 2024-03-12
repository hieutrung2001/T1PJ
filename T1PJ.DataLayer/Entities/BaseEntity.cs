

namespace T1PJ.DataLayer.Entity
{
    
    public class BaseEntity
    {
        public int Id { get; set; }
        public int State { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }

        public BaseEntity()
        {
            State = 1;
            Created = DateTime.Now;
            LastUpdated = DateTime.Now;
        }
    }
}
