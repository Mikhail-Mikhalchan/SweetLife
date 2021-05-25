using System;

namespace SweetLife.Abstractions.Repositories.Employee
{
    public interface IEntity
    {
        long Id { get; }

        string LastName { get; }

        string FirstName { get; }

        string Patronymic { get; }

        DateTime BirthDate { get; }

        Models.Genders Gender { get; }

        Models.Countries Country { get; }

        bool IsDeleted { get; }

        bool IsFired { get; }
    }
}