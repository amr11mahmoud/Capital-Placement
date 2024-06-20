using CapitalPlacement.DataBase;
using CapitalPlacement.Models.Programs;
using CapitalPlacement.Models.Questions;
using CapitalPlacement.Services.Interface;
using CapitalPlacement.Shared;
using Microsoft.EntityFrameworkCore;

namespace CapitalPlacement.Services
{
    public class ProgramManager : IProgramManager
    {
        private readonly CapitalDbContext _context;

        public ProgramManager(CapitalDbContext capitalDbContext)
        {
            _context = capitalDbContext;
        }

        public async Task<int> AddProgram(CapitalProgram program)
        {

            await _context.Programs.AddAsync(program);

            return await _context.SaveChangesAsync();
        }

        public async Task<Result<bool>> DeleteProgram(Guid id)
        {
            var getProgramResult = await GetProgram(id);

            if (getProgramResult.IsFailure)
            {
                return Result.Failure<bool>(Error.Errors.CapitalPrograms.ProgramNotFound());
            }

            var programApplications = await _context.Applications.Where(a => a.CapitalProgramId ==  id).ToListAsync();
            
            if (programApplications.Any())
            {
                _context.Applications.RemoveRange(programApplications);
            }

            _context.Programs.Remove(getProgramResult.Value);
            await _context.SaveChangesAsync();
            
            return Result.Success(true);
        }

        public async Task<Result<bool>> DeleteProgramQuestion(Guid programId, Guid questionId)
        {
            var getProgramResult = await GetProgram(programId);

            if (getProgramResult.IsFailure)
            {
                return Result.Failure<bool>(Error.Errors.CapitalPrograms.ProgramNotFound());
            }

            var program = getProgramResult.Value;

            var question = program.CustomQuestions.FirstOrDefault(q=> q.Id ==  questionId);

            if (question == null)
            {
                return Result.Failure<bool>(Error.Errors.CapitalPrograms.QuestionNotFound());
            }

            // TODO find a better way to patch/delete child elements 
            var questionIndex = program.CustomQuestions.IndexOf(question);

            program.CustomQuestions.RemoveAt(questionIndex);

            _context.Programs.Update(program);
            await _context.SaveChangesAsync();
            
            return Result.Success(true);
        }

        public async Task<List<CapitalProgram>> GetAllPrograms()
        {
            var programs = await _context.Programs.ToListAsync();

            return programs;
        }

        public async Task<Result<CapitalProgram>> GetProgram(Guid id)
        {
            CapitalProgram? program = await _context.Programs.FirstOrDefaultAsync(p => p.Id == id);

            if (program == null)
            {
                return Result.Failure<CapitalProgram>(Error.Errors.CapitalPrograms.ProgramNotFound());
            }

            return Result.Success(program);
        }

        public async Task<Result<bool>> UpdateProgramQuestion(Guid programId, Question question)
        {
            CapitalProgram? program = await _context.Programs.FirstOrDefaultAsync(p => p.Id == programId);

            if (program == null)
            {
                return Result.Failure<bool>(Error.Errors.CapitalPrograms.ProgramNotFound());
            }

            var oldQuestion = program.CustomQuestions.FirstOrDefault(q => q.Id == question.Id);

            if (question == null)
            {
                return Result.Failure<bool>(Error.Errors.CapitalPrograms.QuestionNotFound());
            }

            oldQuestion.Title = question.Title;
            oldQuestion.Options = question.Options;
            oldQuestion.EnableOtherOption = question.EnableOtherOption;
            oldQuestion.Type = question.Type;
            oldQuestion.MaxChoiceAllowed = question.MaxChoiceAllowed;

            _context.Programs.Update(program);
            await _context.SaveChangesAsync();

            return Result.Success(true);
        }
    }
}
