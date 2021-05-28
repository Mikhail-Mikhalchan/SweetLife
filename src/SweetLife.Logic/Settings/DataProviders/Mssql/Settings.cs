using System;

using D = SweetLife.Logic.DataProviders.Mssql;

namespace SweetLife.Logic.Settings.DataProviders.Mssql
{
    public class Settings: D.ISettings
    {
        public string ConnectionString { get; set; }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(ConnectionString))
            {
                throw new ArgumentException($"Settings for '{Constants.SettingsKey}' is not set in appconfig.", nameof(ConnectionString));
            }
        }
    }
}