﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18033
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ildss.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
    public sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool FirstRun {
            get {
                return ((bool)(this["FirstRun"]));
            }
            set {
                this["FirstRun"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("E:\\Documents\\GitHub\\docstore\\TestDir")]
        public string WorkingDir {
            get {
                return ((string)(this["WorkingDir"]));
            }
            set {
                this["WorkingDir"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("E:\\Documents\\GitHub\\docstore\\StorageDir")]
        public string StorageDir {
            get {
                return ((string)(this["StorageDir"]));
            }
            set {
                this["StorageDir"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("maxrevittildss")]
        public string S3BucketName {
            get {
                return ((string)(this["S3BucketName"]));
            }
            set {
                this["S3BucketName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1024")]
        public long TargetDiskUtil {
            get {
                return ((long)(this["TargetDiskUtil"]));
            }
            set {
                this["TargetDiskUtil"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("100.00:00:00")]
        public global::System.TimeSpan MaxDormancy {
            get {
                return ((global::System.TimeSpan)(this["MaxDormancy"]));
            }
            set {
                this["MaxDormancy"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("00:00:10")]
        public global::System.TimeSpan IndexInterval {
            get {
                return ((global::System.TimeSpan)(this["IndexInterval"]));
            }
            set {
                this["IndexInterval"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>.tmp</string>
  <string> .TMP </string>
  <string>.gz </string>
  <string>.ini </string>
  <string>~$ </string>
  <string>.ildss </string>
</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection IgnoredExtensions {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["IgnoredExtensions"]));
            }
            set {
                this["IgnoredExtensions"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("10.00:00:00")]
        public global::System.TimeSpan MinMaxDormancy {
            get {
                return ((global::System.TimeSpan)(this["MinMaxDormancy"]));
            }
            set {
                this["MinMaxDormancy"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("30.00:00:00")]
        public global::System.TimeSpan IntelligenceWindow {
            get {
                return ((global::System.TimeSpan)(this["IntelligenceWindow"]));
            }
            set {
                this["IntelligenceWindow"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("00:00:00")]
        public global::System.TimeSpan WindowOffset {
            get {
                return ((global::System.TimeSpan)(this["WindowOffset"]));
            }
            set {
                this["WindowOffset"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool AutoUpload {
            get {
                return ((bool)(this["AutoUpload"]));
            }
            set {
                this["AutoUpload"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool AutoRemove {
            get {
                return ((bool)(this["AutoRemove"]));
            }
            set {
                this["AutoRemove"] = value;
            }
        }
    }
}
