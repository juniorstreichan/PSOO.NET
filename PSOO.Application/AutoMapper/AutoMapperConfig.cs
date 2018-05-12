using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PSOO.Application.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            var targetAssembly = Assembly.GetExecutingAssembly();
            var subTypes = targetAssembly.GetTypes().Where(t => t.Name.EndsWith("Profile"));

            Mapper.Initialize(x =>
            {
                x.AddProfiles(subTypes);
            });
        }
    }
}
