using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Results.QuestionResults
{
    public class GetQuestionQueryResult
    {
        public int QuestionId { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public string? SubBrandCategory { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}