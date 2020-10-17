using System;
using Abstraction;
using Domain;
using UnitsOfWork.DataAccessImplementations;

namespace UnitsOfWork
{
    public class UnitOfWorkSmartApartment : IUnitOfWork
    {
        private readonly SmartApartmentContext _context;

        public UnitOfWorkSmartApartment(SmartApartmentContext context)
        {
            _context = context;
            Properties =new PropertyDataAccess(context);
        }
        public void Dispose()
        {
            _context.Dispose();
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public IPropertyDataAccess Properties { get; }
    }
}
