using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Contexts;

public class SystemDbContext(DbContextOptions<SystemDbContext> options) : DbContext(options);