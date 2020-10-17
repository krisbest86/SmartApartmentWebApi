using System;
using Domain;
using ResponseModel;

namespace Abstraction
{
    public interface IPropertyDataAccess : IRepository<Property, Guid>
    {
        CityRentalEstateData GetCityRentalEstateData(string city);
    }
}