#pragma warning disable CS1998

using System.Threading.Tasks;

namespace ORMLib;

using Exceptions;
using Providers;

public class ObjectRelationalMappingConfig
{
    private static ObjectRelationalMappingConfig config = null;
    public static ObjectRelationalMappingConfig Config
    {
        get
        {
            if(config == null)
                throw new ConfigNotInitializedException();
            return config;
        }
    }

    public static ObjectRelationalMappingConfigBuilder GetBuilder()
        => new ObjectRelationalMappingConfigBuilder();

    public virtual DataBaseSystem DataBaseSystem { get; set; }
    public virtual string StringConnection { get; set; }
    public virtual string InitialCatalog { get; set; }
    public IQueryProvider QueryProvider { get; set; }
    public IAccessProvider AcessProvider { get; set; }

    public ObjectRelationalMappingConfig(
        DataBaseSystem dataBaseSystem,
        string stringConnection,
        string initialCatalog,
        IQueryProvider queryProvider,
        IAccessProvider acessProvider
    )
    {
        this.DataBaseSystem = dataBaseSystem;
        this.StringConnection = stringConnection;
        this.InitialCatalog = initialCatalog;
        this.QueryProvider = queryProvider;
        this.AcessProvider = acessProvider;
    }

    public void Use()
        => config = this;

    public virtual async Task UseAsync()
        => Use();
}