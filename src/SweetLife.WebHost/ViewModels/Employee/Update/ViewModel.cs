using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using R = SweetLife.Logic.Repositories.Mssql;

namespace SweetLife.WebHost.ViewModels.Employee.Update
{
    public class ViewModel : R.Employee.IEntity
    {
        private const string RequiredErrorMessage = "Поле '{0}' обязательно для заполнения.";
        
        [Required(ErrorMessage = RequiredErrorMessage)]
        [DisplayName("Идентификатор")]
        public long Id { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [DisplayName("Фамилия")]
        public string LastName { get; set; }
        [Required(ErrorMessage = RequiredErrorMessage)]
        [DisplayName("Имя")]
        public string FirstName { get; set; }
        [DisplayName("Отчество")]
        public string Patronymic { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [DisplayName("Дата рождения")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [DisplayName("Пол")]
        public R.Employee.Genders Gender { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [DisplayName("Серия паспорта")]
        public string PassportSeries { get; set; }
        [Required(ErrorMessage = RequiredErrorMessage)]
        [DisplayName("Номер паспорта")]
        public string PassportNumber { get; set; }
        [Required(ErrorMessage = RequiredErrorMessage)]
        [DisplayName("Дата выдачи паспорта")]
        public DateTime PassportReleaseDate { get; set; }
        [Required(ErrorMessage = RequiredErrorMessage)]
        [DisplayName("Регистрация по паспорту")]
        public string PassportRegistrationAddress { get; set; }

        [DisplayName("Временная регистрация")]
        public string TemporaryRegistrationAddress { get; set; }


        [DisplayName("Серия миграционной карты")]
        public string MigrationCardSeries { get; set; }
        [DisplayName("Номер миграционной карты")]
        public string MigrationCardNumber { get; set; }


        [DisplayName("Серия патента")]
        public string PatentSeries { get; set; }
        [DisplayName("Номер патента")]
        public string PatentNumber { get; set; }

        public bool IsFired { get; set; }

        public long? NotificationFileId { get; set; }
        public long? LastTaxReceiptFileId { get; set; }
    }
}
