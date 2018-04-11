using AutoMapper;
using System;
using System.Linq;
using System.Reflection;

namespace FlyboMovie.Services
{
    public class MappersRegister
    {
        public static void RegistMappers()
        {
            //var profiles = Assembly.GetExecutingAssembly().GetTypes()
            //    .Where(p => typeof(Profile).IsAssignableFrom(p) && p.GetConstructor(Type.EmptyTypes) != null)
            //    .Select(Activator.CreateInstance)
            //    .Cast<Profile>()
            //    .ToList();
            //Mapper.Initialize(x =>
            //{
            //    profiles.ForEach(y => x.AddProfile(y));
            //});
        }
    }
}
