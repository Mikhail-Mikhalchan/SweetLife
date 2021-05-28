using System;

namespace SweetLife.Logic.Repositories.Mssql.Employee
{
    internal class Entity : IEntity
    {
        public long Id { get; set; }

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }

        public DateTime BirthDate { get; set; }
        public Genders Gender { get; set; }

        public string PassportSeries { get; set; }
        public string PassportNumber { get; set; }
        public DateTime PassportReleaseDate { get; set; }
        public string PassportRegistrationAddress { get; set; }

        public string TemporaryRegistrationAddress { get; set; }

        public string MigrationCardSeries { get; set; }
        public string MigrationCardNumber { get; set; }

        public string PatentSeries { get; set; }
        public string PatentNumber { get; set; }

        public bool IsFired { get; set; }

        public long? NotificationFileId { get; set; }
        public long? LastTaxReceiptFileId { get; set; }
    }
}