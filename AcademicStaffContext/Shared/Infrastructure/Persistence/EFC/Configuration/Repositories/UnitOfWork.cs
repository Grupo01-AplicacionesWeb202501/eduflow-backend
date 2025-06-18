using AcademicStaffContext.Shared.Domain.Repositories;
using AcademicStaffContext.Shared.Infraestructure.Persistence.EFC.Configuration;
using AcademicStaffContext.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace AcademicStaffContext.Shared.Infrastructure.Persistence.EFC.Configuration.Repositories;
/// <summary>
///     Unit of work for the application.
/// </summary>
/// <remarks>
///     This class is used to save changes to the database context.
///     It implements the IUnitOfWork interface.
/// </remarks>
/// <param name="context">
///     The database context for the application
/// </param>
public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    // inheritedDoc
    public async Task CompleteAsync()
    {
        await context.SaveChangesAsync();
    }
}