using NJsonSchema;
using NJsonSchema.Generation.TypeMappers;

namespace MyFirstNSwagApplication.TypeMappers;

public class LongTypeMapper : ITypeMapper
{
    public Type MappedType => typeof(long);

    public bool UseReference => false;

    public void GenerateSchema(JsonSchema schema, TypeMapperContext context)
    {
        schema.Type = JsonObjectType.String;
        schema.Format = JsonFormatStrings.Long;
        schema.Example = "1415926535897934852";
        schema.Minimum = 0;
    }
}
