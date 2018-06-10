using Autofac;

namespace Huntwords.Common.Services
{
    /// <summary>
    /// Extension methods to register types in this library
    /// </summary>
    public static class AutofacExtensions
    {
        /// <summary>
        /// Register common Services types
        /// </summary>
        /// <param name="builder">ContainerBuilder</param>
        /// <returns>ContainerBuilder</returns>
        public static ContainerBuilder RegisterCommonServices(this ContainerBuilder builder)
        {
            builder.RegisterType<CharacterGenerator>().As<ICharacterGenerator>();

            return builder;
        }
    }
}