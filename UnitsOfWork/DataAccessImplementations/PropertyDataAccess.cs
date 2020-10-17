using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Abstraction;
using Domain;
using Microsoft.EntityFrameworkCore;
using RepositoryServices.Repository.Repository.Implementations;
using ResponseModel;

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
            result.MinPrice= GetAll().Min(a => a.Price);
            result.MaxPrice= GetAll().Max(a => a.Price);

            return result;
        }
    }
}
