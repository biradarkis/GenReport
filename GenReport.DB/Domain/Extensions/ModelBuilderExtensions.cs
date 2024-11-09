using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace GenReport.Infrastructure.Static.Externsions
{
    public static class ModelBuilderExtensions
    {
        public static void ApplyAllConfigurations(this ModelBuilder modelBuilder)
        {
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.GetInterfaces()
                .Any(gi => gi.IsGenericType && gi.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))).ToList();

            foreach (var type in typesToRegister)
            {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                dynamic configurationInstance = Activator.CreateInstance(type);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                modelBuilder.ApplyConfiguration(configurationInstance);
            }
        }
    }
}
