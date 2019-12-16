using Immo.Database;
using Immo.Domain.BusinessDomain;
using Immo.Logic;
using Immo.Repositories.EF.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Immo.Tests
{
    public class EFRepositoryTests
    {
        [Fact]
        public void Test_EFRepository_Get()
        {
            var options = new DbContextOptionsBuilder<ImmoContext>().UseInMemoryDatabase(databaseName: "Test_EFRepository_Get").Options;
            using (var context = new ImmoContext(options))
            {
                new ImmoSeeder(context).Seed();

                var propertiesRepository = new EFReadOnlyRepositoryBase<Property, Guid>(context);
                var properties = propertiesRepository.GetAll();
                var firstProperty = propertiesRepository.GetByIds(new List<Guid> { SeedValues.Properties.MyApartment.Id }).FirstOrDefault();
                Assert.True(properties.Count() == 1);
                Assert.True(properties.First().Id == SeedValues.Properties.MyApartment.Id);
                Assert.True(firstProperty.Id == properties.FirstOrDefault().Id);
            }
        }

        [Fact]
        public void Test_EFRepository_Delete()
        {
            var options = new DbContextOptionsBuilder<ImmoContext>().UseInMemoryDatabase(databaseName: "Test_EFRepository_Delete").Options;
            using (var context = new ImmoContext(options))
            {
                new ImmoSeeder(context).Seed();

                var propertiesRepository = new EFReadWriteRepositoryBase<Property, Guid>(context);
                propertiesRepository.DeleteByIds(new List<Guid> { SeedValues.Properties.MyApartment.Id });
                context.SaveChanges();
                Assert.True(propertiesRepository.GetAll().Count() == 0);
               
            }
        }

        [Fact]
        public void Test_EFRepository_CreateOrUpdate()
        {
            var options = new DbContextOptionsBuilder<ImmoContext>().UseInMemoryDatabase(databaseName: "Test_EFRepository_CreateOrUpdate").Options;
            using (var context = new ImmoContext(options))
            {
                new ImmoSeeder(context).Seed();

                var propertiesRepository = new EFReadWriteRepositoryBase<Property, Guid>(context);
                propertiesRepository.DeleteById(SeedValues.Properties.MyApartment.Id );
                context.SaveChanges();

                Assert.True(propertiesRepository.GetAll().Count() == 0);
                propertiesRepository.CreateOrUpdate( SeedValues.Properties.MyApartment );

                var properties = propertiesRepository.GetAll();
                var myApartment = propertiesRepository.GetById(SeedValues.Properties.MyApartment.Id);
                Assert.True(properties.Count() == 1);
                Assert.True(myApartment.Id == SeedValues.Properties.MyApartment.Id);

                myApartment.OriginalURL = "test";
                propertiesRepository.CreateOrUpdate( myApartment );

                var myApartmentAfterUpdate = propertiesRepository.GetById( SeedValues.Properties.MyApartment.Id );
                Assert.True(myApartmentAfterUpdate.OriginalURL == myApartment.OriginalURL);

            }
        }
    }
}
