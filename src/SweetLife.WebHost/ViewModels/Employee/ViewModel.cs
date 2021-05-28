using System;

using R = SweetLife.Logic.Repositories.Mssql;

namespace SweetLife.WebHost.ViewModels.Employee
{
    public class ViewModel : R.Employee.IEntity
    {
        public long Id { get; set; }

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }

        public DateTime BirthDate { get; set; }
        public R.Employee.Genders Gender { get; set; }

        public string PassportSeries { get; set; }
        public string PassportNumber { get; set; }
        public DateTime PassportReleaseDate { get; set; }
        public string PassportRegistrationAddress { get; set; }

        public string TemporaryRegistrationAddress { get; set; }

        public string MigrationCardSeries { get; set; }
        public string MigrationCardNumber { get; set; }
        public bool HasMigrationCard => !string.IsNullOrEmpty(MigrationCardSeries) && !string.IsNullOrEmpty(MigrationCardNumber);

        public string PatentSeries { get; set; }
        public string PatentNumber { get; set; }
        public bool HasPatent => !string.IsNullOrEmpty(PatentSeries) && !string.IsNullOrEmpty(PatentNumber);

        public bool IsFired { get; set; }

        public long? NotificationFileId { get; set; }
        public long? LastTaxReceiptFileId { get; set; }
    }
}