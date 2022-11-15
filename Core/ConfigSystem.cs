﻿using InvoicesManager.Classes;
using InvoicesManager.Models;
using Newtonsoft.Json;
using System;
using System.IO;

namespace InvoicesManager.Core
{
    public class ConfigSystem
    {
        public static void Init()
        {
            string json = File.ReadAllText(EnvironmentsVariable.ConfigJsonFileName);

            ConfigModel config = new ConfigModel()
            {
                PathPDFBrowser = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe",
                UILanguage = "English",
                ConfigVersion = EnvironmentsVariable.PROGRAM_VERSION,
                PathInvoice = EnvironmentsVariable.PathInvoices
            };
        
            if (!(json.Equals("[]") || String.IsNullOrWhiteSpace(json) || json.Equals("null")))
                config = JsonConvert.DeserializeObject<ConfigModel>(json);

            EnvironmentsVariable.PathPDFBrowser = config.PathPDFBrowser;
            EnvironmentsVariable.UILanguage = config.UILanguage;
            EnvironmentsVariable.ConfigVersion = config.ConfigVersion;
            EnvironmentsVariable.PathInvoices = config.PathInvoice;

            Save();
        }

        public static void Save()
        {
            ConfigModel config = new ConfigModel()
            {
                PathPDFBrowser = EnvironmentsVariable.PathPDFBrowser,
                UILanguage = EnvironmentsVariable.UILanguage,
                ConfigVersion = EnvironmentsVariable.PROGRAM_VERSION,
                PathInvoice = EnvironmentsVariable.PathInvoices
            };
            
            File.WriteAllText( EnvironmentsVariable.ConfigJsonFileName, JsonConvert.SerializeObject(config));
        }
    }
}
