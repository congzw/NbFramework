namespace DemoSite.Domains.Demo
{
    public interface IVisualizer<in TLog>
    {
        string ToHtml(TLog log);
    }

    public class DefaultVisualizer<TLog> : IVisualizer<TLog>
    {
        public string ToHtml(TLog log)
        {
            return string.Format("<div>{0}</div>", log);
        }
    }


    public class IssueCreated
    {

    }

    public class IssueCreatedVisualizer : IVisualizer<IssueCreated>
    {
        public string ToHtml(IssueCreated log)
        {
            return string.Format("<h2>{0}<h2>", log);
        }
    }
}
