using Npgsql;

namespace Gpiot.Helpers;

public class EnvVariableHelper
{
    public static string GetConnectionString(WebApplicationBuilder builder)
    {
        var hostname = Environment.GetEnvironmentVariable("DB_HOST");
        var database = Environment.GetEnvironmentVariable("DB_DATABASE");
        var username = Environment.GetEnvironmentVariable("DB_USER");
        var password = Environment.GetEnvironmentVariable("DB_PASSWORD");
        if ( string.IsNullOrEmpty(hostname) || string.IsNullOrEmpty(database) ||
             string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            throw new ArgumentNullException("You must set [DB_HOST], [DB_DATABASE] and "
                                            + "[DB_USER], [DB_PASSWORD] Environtment variables.");
        }
        var connectionStringTemplate = builder.Configuration.GetConnectionString("Default");
        if (string.IsNullOrEmpty(connectionStringTemplate))
        {
            throw new Exception("Could not get connection string template from appsettings.[ENV].json");
        }
        
        var npgsqlBuilder = new NpgsqlConnectionStringBuilder(connectionStringTemplate)
        {
            Host = hostname,
            Database = database,
            Username = username,
            Password = password
        };

        return npgsqlBuilder.ConnectionString;
    }

    public static Auth0Config GetAuth0Config(WebApplicationBuilder builder) {
        var auth0Domain = Environment.GetEnvironmentVariable("AUTH0_DOMAIN");
        var auth0ClientId = Environment.GetEnvironmentVariable("AUTH0_CLIENT_ID");
        var auth0ClientSecret = Environment.GetEnvironmentVariable("AUTH0_CLIENT_SECRET");
        var auth0Audience = Environment.GetEnvironmentVariable("AUTH0_AUDIENCE");

        if (string.IsNullOrEmpty(auth0Domain) || string.IsNullOrEmpty(auth0ClientId) ||
            string.IsNullOrEmpty(auth0ClientSecret) || string.IsNullOrEmpty(auth0Audience))
            {
                throw new ArgumentNullException("You must set [AUTH0_DOMAIN], [AUTH0_CLIENT_ID] and "
                                            + "[AUTH0_CLIENT_SECRET], [AUTH0_AUDIENCE] Environtment variables.");
        
            }

        return new Auth0Config {
            Domain = auth0Domain,
            ClientId = auth0ClientId,
            ClientSecret = auth0ClientSecret,
            Audience = auth0Audience
        };
    }
}