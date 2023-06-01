namespace ORMLib;

using MSSql;

public static class ObjectRelationalMappingConfigBuilderExtension
{
    public static ObjectRelationalMappingConfigBuilder UseMSSqlServer(this ObjectRelationalMappingConfigBuilder builder)
    {
        builder.SetDataBaseSystem(DataBaseSystem.SqlServer);
        builder.SetQueryProvider(new MSSqlQueryProvider());
        builder.SetAcessProvider(new MSSqlProvider());
        return builder;
    }
}