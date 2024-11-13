using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;


namespace GesDette.Core.Service
{
    public static class Service
    {
        public static IConfigurationBuilder LoadYaml(this IConfigurationBuilder builder, string path)
        {
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();

            var yamlContent = File.ReadAllText(path);
            var yamlObject = deserializer.Deserialize(new StringReader(yamlContent));

            var jsonSerializer = new SerializerBuilder()
                .JsonCompatible()
                .Build();

            var json = jsonSerializer.Serialize(yamlObject);

            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(json);
            writer.Flush();
            stream.Position = 0;

            return builder.AddJsonStream(stream);

        }
    }
}