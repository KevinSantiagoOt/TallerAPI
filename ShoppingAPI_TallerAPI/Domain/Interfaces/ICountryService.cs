using ShoppingAPI_TallerAPI.DAL.ENTITIES;

namespace ShoppingAPI_TallerAPI.Domain.Interfaces
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>> GetConuntriesAsync(); //Esta es una de las tantas firmas de un Método

        Task<Country> CreateCountryAsync(Country country);

        Task<Country> GetCountryByIdAsync(Guid id);

        Task<Country> EditCountryAsync(Country country);

        Task<Country> DeleteCountryAsync(Guid id);
    }
}
