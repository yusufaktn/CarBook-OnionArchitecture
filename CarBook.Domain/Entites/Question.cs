using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entites
{
    public class Question
    {
        public int QuestionId { get; set; }
        public int UserId{ get; set; }
        public User User { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public string? SubBrandCategory { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }    

        public List<Answer> Answers { get; set; }

    }
}
