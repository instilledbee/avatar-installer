﻿namespace ei8.Avatar.Installer.Domain.Model.Configuration
{
    public class AvatarConfiguration
    {
        public string Name { get; set; }
        public CortexGraphConfiguration? CortexGraph { get; set; }
        public AvatarApiConfiguration? AvatarApi { get; set; }
        public CortexLibraryConfiguration? CortexLibrary { get; set; }
        public D23Configuration? D23 { get; set; }
        public NetworkConfiguration? Network { get; set; }

        /// <summary>
        /// Initialize with defaults
        /// </summary>
        public AvatarConfiguration()
        {
            Name = "sample";
            CortexGraph = new();
            AvatarApi = new(Name);
            CortexLibrary = new(Name);
            D23 = new(Name);
            Network = new();
        }
    }

    public class CortexGraphConfiguration
    {
        public string DbName { get; set; }
        public string DbUsername { get; set; }
        public string DbUrl { get; set; }
        public string ArangoRootPassword { get; set; }

        /// <summary>
        /// Initialize with defaults
        /// </summary>
        public CortexGraphConfiguration()
        {
            DbName = "graph";
            DbUsername = "root";
            DbUrl = "http://cortex.graph.persistence:8529";
            ArangoRootPassword = string.Empty;
        }
    }

    public class AvatarApiConfiguration
    {
        public string TokenIssuerUrl { get; set; }
        public string ApiName { get; set; }

        /// <summary>
        /// Initialize with defaults
        /// </summary>
        public AvatarApiConfiguration(string avatarName)
        {
            TokenIssuerUrl = @"https://login.fibona.cc";
            ApiName = $"avatarapi-{avatarName}";
        }
    }

    public class CortexLibraryConfiguration
    {
        public string NeuronsUrl { get; set; }
        public string TerminalsUrl { get; set; }

        /// <summary>
        /// Initialize with defaults
        /// </summary>
        public CortexLibraryConfiguration(string avatarName)
        {
            NeuronsUrl = $@"http://fibona.cc/{avatarName}/cortex/neurons";
            TerminalsUrl = $@"http://fibona.cc/{avatarName}/cortex/terminals";
        }
    }

    public class D23Configuration
    {
        public string OidcAuthorityUrl { get; set; }
        public string ClientId { get; set; }
        public string BasePath { get; set; }

        /// <summary>
        /// Initialize with defaults
        /// </summary>
        public D23Configuration(string avatarName)
        {
            OidcAuthorityUrl = @"https://login.fibona.cc";
            ClientId = $"d23-{avatarName}";
            BasePath = $"/{avatarName}/d23";
        }
    }

    public class NetworkConfiguration
    {
        public string LocalIp { get; set; }
        public int AvatarInPort { get; set; }
        public int D23BlazorPort { get; set; }
        public SshConfiguration? Ssh { get; set; }

        /// <summary>
        /// Initialize with defaults
        /// </summary>
        public NetworkConfiguration()
        {
            LocalIp = "192.168.0.110";
            AvatarInPort = 64101;
            D23BlazorPort = 64103;
            Ssh = new();
        }
    }

    public class SshConfiguration
    {
        public int ServerAliveInterval { get; set; }
        public int ServerAliveCountMax { get; set; }
        public int Port { get; set; }
        public string HostName { get; set; }
        public string RemoteForward { get; set; }
        public int LocalPort { get; set; }

        /// <summary>
        /// Initialize with defaults
        /// </summary>
        public SshConfiguration()
        {
            ServerAliveInterval = 60;            // 1 minute
            ServerAliveCountMax = 60 * 24 * 365; // 60 secs * 24 hours * 365 days = 1 year
            Port = 2222;
            HostName = "ei8.host";
            RemoteForward = "sample:80";
            LocalPort = 9393;
        }
    }

}
