using System;

namespace VetCoworking.App.Model
{
    public class ReportHistoryModel
    {
        public Guid ProjectId { get; set; }
        public Guid CompanyId { get; set; }
        public string? ReportType { get; set; }
        public string? PdfUrl { get; set; }
        public string? ReviewStatus { get; set; }
        public string? PaymentStatus { get; set; }
        public DateTime Sent { get; set; }
        public string? To { get; set; }
        public decimal Total { get; set; }
        public Guid ProjectQuoteId { get; set; }

    }
}
