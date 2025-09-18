using CarBook.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces
{
    public interface IAnswerRepository : IRepository<Answer>
    {
        Task<List<Answer>> GetAnswersByQuestionIdAsync(int questionId);
    }
}