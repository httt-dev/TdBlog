using Microsoft.AspNetCore.Identity;
using TdBlog.Core.Domain.Identity;

namespace TdBlog.Data
{
    public class DataSeeder
    {
        public async Task SeedAsync(TdBlogContext context)
        {
            var passwordHasher = new PasswordHasher<AppUser>();
            var rootAdminRoleId = Guid.NewGuid();
            if(!context.RoleClaims.Any())
            {
                await context.Roles.AddAsync(new AppRole() {
                    Id = rootAdminRoleId,
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    DisplayName = "Quản trị viên"
                });
                await context.SaveChangesAsync();

            }

            if(!context.Users.Any())
            {
                var userId = Guid.NewGuid();
                var user = new AppUser()
                {
                    Id = userId,
                    FirstName = "Hoa",
                    LastName = "Nguyen",
                    Email = "httt.dev@gmail.com",
                    NormalizedEmail = "HTTT.DEV@GMAIL.COM",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    IsActive = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = false,
                    DateCreated = DateTime.Now
                };
                user.PasswordHash = passwordHasher.HashPassword(user, "Abc12345");
                await context.Users.AddAsync(user);

                await context.UserRoles.AddAsync(new IdentityUserRole<Guid>()
                {
                    RoleId = rootAdminRoleId,
                    UserId = userId,
                });
                await context.SaveChangesAsync();
            }

        }
    }
}
