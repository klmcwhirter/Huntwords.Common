using Autofac;
using Huntwords.Common.Models;

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

            builder.RegisterType<RedisPuzzleBoardPubSubService>().As<IRedisPuzzleBoardPubSubService>();

            builder.RegisterType<JsonFromStringTransformer<PuzzleBoard>>().As<ITransformer<string, PuzzleBoard>>();
            builder.RegisterType<JsonToStringTransformer<PuzzleBoard>>().As<ITransformer<PuzzleBoard, string>>();

            return builder;
        }
    }
}