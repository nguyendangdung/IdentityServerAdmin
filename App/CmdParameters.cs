using CommandLine;

namespace App
{
    enum DeployLocation
    {
        Debug, Production, Staging
}

    public enum AuthenticationType
    {
        Local, Ids
    }
    class CmdParameters
    {
        [Option('l', "location", Required = true, HelpText = "Deploy location", DefaultValue = App.DeployLocation.Debug)]
        public DeployLocation DeployLocation { get; set; }

        [Option('p', "port", Required = false, HelpText = "Port number", DefaultValue = 9000)]
        public int Port { get; set; }

        [Option('a', "auType", Required = false, HelpText = "Local Authenticaltion Only", DefaultValue = AuthenticationType.Local)]
        public AuthenticationType AuthenticationType { get; set; }
    }
}
