using API_JohnToro.DAL.Models.Dtos;
using API_JohnToro.DAL.Models;
using API_JohnToro.Repository.IRepository;
using API_JohnToro.Services.IServices;
using AutoMapper;

namespace API_JohnToro.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public MovieService(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<bool> MovieExistsByIdAsync(int id)
        {
            return await _movieRepository.MovieExistsByIdAsync(id);
        }

        public async Task<bool> MovieExistsByNameAsync(string name)
        {
            return await _movieRepository.MovieExistsByNameAsync(name);
        }

        public async Task<MovieDto> CreateMovieAsync(MovieCreateUpdateDto movieDto)
        {
            // Validar nombre duplicado
            var movieExists = await _movieRepository.MovieExistsByNameAsync(movieDto.Name);

            if (movieExists)
            {
                throw new InvalidOperationException($"Ya existe una película con el nombre '{movieDto.Name}'");
            }

            // Mapear DTO → entidad
            var movie = _mapper.Map<Movie>(movieDto);

            // Crear
            var created = await _movieRepository.CreateMovieAsync(movie);

            if (!created)
            {
                throw new Exception("Ocurrió un error al crear la película.");
            }

            return _mapper.Map<MovieDto>(movie);
        }

        public async Task<bool> DeleteMovieAsync(int id)
        {
            // Buscar la película
            var movie = await _movieRepository.GetMovieAsync(id);

            if (movie == null)
            {
                throw new InvalidOperationException($"No se encontró la película con ID: '{id}'");
            }

            // Eliminar
            var deleted = await _movieRepository.DeleteMovieAsync(id);

            if (!deleted)
            {
                throw new Exception("Ocurrió un error al eliminar la película.");
            }

            return deleted;
        }

        public async Task<ICollection<MovieDto>> GetMoviesAsync()
        {
            var movies = await _movieRepository.GetMoviesAsync();
            return _mapper.Map<ICollection<MovieDto>>(movies);
        }

        public async Task<MovieDto> GetMovieAsync(int id)
        {
            var movie = await _movieRepository.GetMovieAsync(id);

            if (movie == null)
            {
                throw new InvalidOperationException($"No se encontró la película con ID: '{id}'");
            }

            return _mapper.Map<MovieDto>(movie);
        }

        public async Task<MovieDto> UpdateMovieAsync(MovieCreateUpdateDto dto, int id)
        {
            // Verificar existencia
            var movie = await _movieRepository.GetMovieAsync(id);

            if (movie == null)
            {
                throw new InvalidOperationException($"No se encontró la película con ID: '{id}'");
            }

            // Validar nombre duplicado
            var existsName = await _movieRepository.MovieExistsByNameAsync(dto.Name);

            if (existsName && !movie.Name.Equals(dto.Name, StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException($"Ya existe una película con el nombre '{dto.Name}'");
            }

            // Mapear DTO → entidad (actualiza propiedades)
            _mapper.Map(dto, movie);

            // Guardar cambios
            var updated = await _movieRepository.UpdateMovieAsync(movie);

            if (!updated)
            {
                throw new Exception("Ocurrió un error al actualizar la película.");
            }

            return _mapper.Map<MovieDto>(movie);
        }
    }
}
