using Domain;
using ResponseModel;
using System;

namespace Abstraction
{
    public interface IPropertyDataAccess : IRepository<Property, Guid>
    {
        CityRentalEstateData GetCityRentalEstateData(string city);
    }
}