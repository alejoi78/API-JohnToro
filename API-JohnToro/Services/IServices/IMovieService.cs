using API_JohnToro.DAL.Models.Dtos;
using API_JohnToro.DAL.Models;

namespace API_JohnToro.Services.IServices
{
    public interface IMovieService
    {
        Task<ICollection<MovieDto>> GetMoviesAsync();
        Task<MovieDto> GetMovieAsync(int id);
        Task<MovieDto> CreateMovieAsync(MovieCreateUpdateDto movieDto);
        Task<MovieDto> UpdateMovieAsync(MovieCreateUpdateDto dto, int id);
        Task<bool> DeleteMovieAsync(int id);
        Task<bool> MovieExistsByIdAsync(int id);
        Task<bool> MovieExistsByNameAsync(string name);
    }
}
