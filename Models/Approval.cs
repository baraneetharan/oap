namespace oap.Models
{

    public class Approval
    {
        public int Id { get; set; }
        public int reqid { get; set; }
        public string level { get; set; }
        public string emailto { get; set; }
        public string emailcc { get; set; }
        public string status { get; set; }
        public string iscompleted { get; set; }

    }
}