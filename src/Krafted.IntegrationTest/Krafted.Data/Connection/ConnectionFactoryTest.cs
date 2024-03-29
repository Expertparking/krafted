using System.Data;
using Krafted.Configuration;
using Krafted.Data.Connection;
using Krafted.Data.Oracle.Connection;
using Krafted.Data.SqlServer.Connection;
using Xunit;

namespace Krafted.IntegrationTest.Krafted.Data.Connection
{
    [Trait(nameof(IntegrationTest), nameof(Krafted))]
    public class ConnectionFactoryTest
    {
        [Fact(Skip = "wip: database in continuous integration")]
        public void NewConnection_SqlServerConnectionFactory_SqlServerConnectionCreated()
        {
            var connectionString = Config.Instance().GetConnectionString();

            var connection = ConnectionFactory.NewConnection<SqlServerConnectionFactory>(connectionString);
            Assert.NotNull(connection);

            connection.Open();
            Assert.Equal(ConnectionState.Open, connection.State);

            connection.Close();
            Assert.Equal(ConnectionState.Closed, connection.State);
        }

        [Fact(Skip = "I need an oracle db server. I will use the docker for the integrated tests.")]
        public void NewConnection_OracleConnectionFactory_OracleConnectionCreated()
        {
            var connectionString = Config.Instance().GetConnectionString();

            var connection = ConnectionFactory.NewConnection<OracleConnectionFactory>(connectionString);
            Assert.NotNull(connection);

            connection.Open();
            Assert.Equal(ConnectionState.Open, connection.State);

            connection.Close();
            Assert.Equal(ConnectionState.Closed, connection.State);
        }
    }
}
