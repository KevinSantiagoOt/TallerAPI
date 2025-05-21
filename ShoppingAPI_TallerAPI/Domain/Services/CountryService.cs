using Microsoft.EntityFrameworkCore;
using ShoppingAPI_TallerAPI.DAL;
using ShoppingAPI_TallerAPI.DAL.ENTITIES;
using ShoppingAPI_TallerAPI.Domain.Interfaces;

namespace ShoppingAPI_TallerAPI.Domain.Services
{

    public class CountryService : ICountryService
    {
        private readonly DataBaseContext _context;
        public CountryService(DataBaseContext context)
        {
            _context = context;
        }

        //Método para opbtener el listado de países
        public async Task<IEnumerable<Country>> GetConuntriesAsync()
        {
            try
            {
                var conuntries = await _context.Conuntries.ToListAsync();
                return conuntries;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ??
                    dbUpdateException.Message);
            }
        }

        public async Task<Country> GetCountryByIdAsync(Guid id)
        {
            try
            {
                var country = await _context.Conuntries.FirstOrDefaultAsync(c => c.Id == id);
                return country;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ??
                    dbUpdateException.Message);
            }
        }

        public async Task<Country> CreateCountryAsync(Country country)
        {
            try
            {
                country.Id = Guid.NewGuid();
                country.CreatedDate = DateTime.Now;

                _context.Conuntries.Add(country); //el método ADD, nos permite crear el objeto en nuestra BD
                await _context.SaveChangesAsync(); //este método permite guardar

                return country;

            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ?? 
                    dbUpdateException.Message);
            }

        }

        public async Task<Country> EditCountryAsync(Country country)
        {
            try
            {
                country.ModifiedDate = DateTime.Now;
                _context.Conuntries.Update(country); //Virtualizo mi objeto
                await _context.SaveChangesAsync();

                return country;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ??
                    dbUpdateException.Message);
            }
        }

        public async Task<Country> DeleteCountryAsync(Guid id)
        {
            try
            {
                var country = await GetCountryByIdAsync(id);

                if (country == null)
                {

                    return null;

                }

                _context.Conuntries.Remove(country);
                await _context.SaveChangesAsync();

                return country;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ??
                    dbUpdateException.Message);
            }
        } 
    }
}
