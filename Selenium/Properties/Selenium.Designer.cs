﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Selenium.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
    internal sealed partial class Selenium : global::System.Configuration.ApplicationSettingsBase {
        
        private static Selenium defaultInstance = ((Selenium)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Selenium())));
        
        public static Selenium Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("30.00:00:00")]
        public global::System.TimeSpan DefaultTimeout {
            get {
                return ((global::System.TimeSpan)(this["DefaultTimeout"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("5.00:00:00")]
        public global::System.TimeSpan AlertTimeout {
            get {
                return ((global::System.TimeSpan)(this["AlertTimeout"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("http://realmadryt.pl")]
        public string Url {
            get {
                return ((string)(this["Url"]));
            }
        }
    }
}
