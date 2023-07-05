namespace TaskApi.Entities;
public class WorkerTask : BaseEntity
{
    public string Description { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate{ get; set; }
    public bool isComplete { get; set; }
    //nav props
    public User Worker { get; set; }
    public string WorkerId { get; set; }
}