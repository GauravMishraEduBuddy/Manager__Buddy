using EduBuddyApp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace EduBuddyApp.Services
{
    public class BooksChapterService : IBooksChapterService
    {
        private readonly HttpClient _http;

        public BooksChapterService(HttpClient http)
        {
            _http = http;
        }

        public async Task<BooksShortViewModel?> GetBookAsync(int bookId)
        {
            try
            {
                var url = $"api/BooksChapter/book/{bookId}";
                return await _http.GetFromJsonAsync<BooksShortViewModel>(url);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching book: {ex.Message}");
                return null;
            }
        }

        public async Task<List<BooksShortViewModel>> GetBooksBySubjectAsync(int subjectId)
        {
            try
            {
                var url = $"api/BooksChapter/books/subject/{subjectId}";
                var result = await _http.GetFromJsonAsync<List<BooksShortViewModel>>(url);
                return result ?? new List<BooksShortViewModel>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching books by subject: {ex.Message}");
                return new List<BooksShortViewModel>();
            }
        }

        public async Task<ChaptersViewModel?> GetChapterAsync(int chapterId)
        {
            try
            {
                var url = $"api/BooksChapter/chapter/{chapterId}";
                return await _http.GetFromJsonAsync<ChaptersViewModel>(url);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching chapter: {ex.Message}");
                return null;
            }
        }

        public async Task<List<ChaptersViewModel>> GetChaptersByBookAsync(int bookId)
        {
            try
            {
                var url = $"api/BooksChapter/chapters/book/{bookId}";
                var result = await _http.GetFromJsonAsync<List<ChaptersViewModel>>(url);
                return result ?? new List<ChaptersViewModel>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching chapters by book: {ex.Message}");
                return new List<ChaptersViewModel>();
            }
        }

        public async Task<ChaptersViewModel?> CreateChapterAsync(ChapterEditDto dto)
        {
            try
            {
                var response = await _http.PostAsJsonAsync("api/BooksChapter/chapter", dto);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<ChaptersViewModel>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating chapter: {ex.Message}");
                return null;
            }
        }

        public async Task<ChaptersViewModel?> UpdateChapterAsync(int chapterId, ChapterEditDto dto)
        {
            try
            {
                var response = await _http.PutAsJsonAsync($"api/BooksChapter/chapter/{chapterId}", dto);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadFromJsonAsync<ChaptersViewModel>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating chapter: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> DeleteChapterAsync(int chapterId)
        {
            try
            {
                var response = await _http.DeleteAsync($"api/BooksChapter/chapter/{chapterId}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting chapter: {ex.Message}");
                return false;
            }
        }

        // Create a new book for a subject
        public async Task<BooksShortViewModel?> CreateBookAsync(BookCreateDto dto, CancellationToken ct = default)
        {
            var response = await _http.PostAsJsonAsync("api/bookschapter/book", dto, ct);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<BooksShortViewModel>(cancellationToken: ct);
            }
            return null;
        }

        // Update an existing book
        public async Task<BooksShortViewModel?> UpdateBookAsync(int bookId, BookUpdateDto dto, CancellationToken ct = default)
        {
            var response = await _http.PutAsJsonAsync($"api/bookschapter/book/{bookId}", dto, ct);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<BooksShortViewModel>(cancellationToken: ct);
            }
            return null;
        }

        // Delete a book (only if no chapters)
        public async Task<bool> DeleteBookAsync(int bookId, CancellationToken ct = default)
        {
            var response = await _http.DeleteAsync($"api/bookschapter/book/{bookId}", ct);
            return response.IsSuccessStatusCode;
        }
    }
}

