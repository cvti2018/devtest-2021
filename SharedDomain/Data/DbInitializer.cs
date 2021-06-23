using Domain.Model;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;

namespace Domain.Data
{
    public static class DbInitializer
    {
        public static void Initialize(EpiContext ctx)
        {
            ctx.Database.EnsureCreated();

            if (!ctx.Epis.Any())
            {
                var assembly = typeof(Domain.Data.DbInitializer).GetTypeInfo().Assembly;
                string[] names = assembly.GetManifestResourceNames();
                string resource = names.FirstOrDefault(x => x.Contains("epi.json"));

                using var stream = assembly.GetManifestResourceStream(resource);
                using var streamReader = new StreamReader(stream);

                var lstEpi = JsonSerializer.Deserialize<List<Epi>>((streamReader.ReadToEnd()));

                foreach (var epi in lstEpi)
                {
                    ctx.Epis.Add(epi);
                }

                ctx.SaveChanges();
            }
        }
    }
}