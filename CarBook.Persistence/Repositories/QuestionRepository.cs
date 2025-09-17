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
    public class QuestionRepository : Repository<Question>, IQuestionRepository
    {
        private readonly MyContext _myContext;
        public QuestionRepository(MyContext myContext) : base(myContext)
        {
            _myContext = myContext;
        }

        public async Task<List<Question>> GetLastThreeQuestionsAsync()
        {
            return await _myContext.Questions
                .Include(q => q.User)
                .Include(q => q.Category)
                .Include(q => q.Brand)
                .OrderByDescending(q => q.QuestionId)
                .Take(3)
                .ToListAsync();
        }

        public new async Task<List<Question>> GetAllAsync()
        {
            return await _myContext.Questions
                .Include(q => q.User)
                .Include(q => q.Category)
                .Include(q => q.Brand)
                .ToListAsync();
        }
    }
}