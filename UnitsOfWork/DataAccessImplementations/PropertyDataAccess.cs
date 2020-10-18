using Abstraction;
using Domain;
using Repositories.Repositories;
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
            var result = new CityRentalEstateData
            {
                AveragePrice = GetAll().Where(a => a.City == city).Average(a => a.Price),
                MinPrice = GetAll().Where(a => a.City == city).Min(a => a.Price),
                MaxPrice = GetAll().Where(a => a.City == city).Max(a => a.Price)
            };


            return result;
        }
    }
}
