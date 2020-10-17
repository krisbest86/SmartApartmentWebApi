using Abstraction;
using Domain;
using RepositoryServices.Repository.Repository.Implementations;
using ResponseModel;
using System;
using System.Linq;

namespace UnitsOfWork.DataAccessImplementations
{
    public class PropertyDataAccess : RepositoryEntityFramework<Property, Guid>, IPropertyDataAccess
    {
        private SmartApartmentContext _context;
        public PropertyDataAccess(SmartApartmentContext context) : base(context)
        {
            _context = context;
        }

        public CityRentalEstateData GetCityRentalEstateData(string city)
        {
            var result = new CityRentalEstateData();

            result.AveragePrice = GetAll().Average(a => a.Price);
            result.MinPrice = GetAll().Min(a => a.Price);
            result.MaxPrice = GetAll().Max(a => a.Price);

            return result;
        }
    }
}
