using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work.Entities
{
    public class EFContext : DbContext
    {
        public EFContext() : base("HomeWorkAddressDB")
        {

        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<AddressType> AddressTypes { get; set; }
        public DbSet<BusinessEntity> BusinessEntities { get; set; }
        public DbSet<BusinessEntityAddress> BusinessEntityAddresses { get; set; }
        public DbSet<BusinessEntityContact> BusinessEntityContacts { get; set; }
        public DbSet<ContactType> ContactTypes { get; set; }
        public DbSet<CountryRegion> CountryRegions { get; set; }
        public DbSet<EmailAddress> EmailAddresses { get; set; }
        public DbSet<Password> Passwords { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<PersonPhone> PersonPhones { get; set; }
        public DbSet<PhoneNumberType> PhoneNumberTypes { get; set; }
        public DbSet<StateProvince> StateProvinces { get; set; }
    }
}
