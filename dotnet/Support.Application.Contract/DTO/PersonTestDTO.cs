namespace Support.Application.Contract.DTO
{
   public class PersonTestDTO
    {
        public int IndividualTestId { get; set; }
        public string TestName { get; set; }
        public int ReportId { get; set; }
        public string ResponseDate { get; set; }
        public bool IsFinal { get; set; }
        public string ReportUrl { get; set; }
        public string Status { get; set; }
        public int StatusId { get; set; }
    }
}
