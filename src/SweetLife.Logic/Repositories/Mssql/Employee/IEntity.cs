using System;

namespace SweetLife.Logic.Repositories.Mssql.Employee
{
    public interface IEntity
    {
        long Id { get; }

        string LastName { get; }
        string FirstName { get; }
        string Patronymic { get; }

        DateTime BirthDate { get; }
        Genders Gender { get; }

        string PassportSeries { get; }
        string PassportNumber { get; }
        DateTime PassportReleaseDate { get; }
        string PassportRegistrationAddress { get; }

        string TemporaryRegistrationAddress { get; }

        string MigrationCardSeries { get; }
        string MigrationCardNumber { get; }

        string PatentSeries { get; }
        string PatentNumber { get; }

        bool IsFired { get; }

        long? NotificationFileId { get; }

        long? LastTaxReceiptFileId { get; }
    }
}