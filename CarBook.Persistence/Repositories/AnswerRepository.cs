using CarBook.Application.Interfaces;
using CarBook.Domain.Entites;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories
{
    public class AnswerRepository : Repository<Answer>, IAnswerRepository
    {
        public AnswerRepository(MyContext myContext) : base(myContext)
        {
        }

        public async Task<List<Answer>> GetAnswersByQuestionIdAsync(int questionId)
        {
            return await _dbSet.Where(a => a.QuestionId == questionId)
                .Include(a => a.User)
                .Include(a => a.Question).ToListAsync();
        }

    }
}