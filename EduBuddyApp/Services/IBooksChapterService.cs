using EduBuddyApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduBuddyApp.Services
{
    public interface IBooksChapterService
    {
        Task<BooksShortViewModel?> GetBookAsync(int bookId);
        Task<List<BooksShortViewModel>> GetBooksBySubjectAsync(int subjectId);
        Task<ChaptersViewModel?> GetChapterAsync(int chapterId);
        Task<List<ChaptersViewModel>> GetChaptersByBookAsync(int bookId);

        Task<ChaptersViewModel?> CreateChapterAsync(ChapterEditDto dto);
        Task<ChaptersViewModel?> UpdateChapterAsync(int chapterId, ChapterEditDto dto);
        Task<bool> DeleteChapterAsync(int chapterId);

        //Books CRUD
        Task<BooksShortViewModel?> CreateBookAsync(BookCreateDto dto, CancellationToken ct = default);
        Task<BooksShortViewModel?> UpdateBookAsync(int bookId, BookUpdateDto dto, CancellationToken ct = default);
        Task<bool> DeleteBookAsync(int bookId, CancellationToken ct = default);

    }
}