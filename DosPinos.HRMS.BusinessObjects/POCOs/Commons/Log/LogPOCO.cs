namespace DosPinos.HRMS.BusinessObjects.POCOs.Commons.Log
{
    public class LogPOCO : EntityDTO, ILogPOCO
    {
        public DateTime TimeStamp { get; set; }
        public string Source { get; set; }
        public string Message { get; set; }
        public string Exeption { get; set; }
        public ActionCategory Action { get; set; }
        public Module Module { get; set; }
    }
}