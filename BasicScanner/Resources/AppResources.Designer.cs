﻿// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.42000
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace BasicScanner.Localization {
    using System;
    using System.Reflection;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class AppResources {
        
        private static System.Resources.ResourceManager resourceMan;
        
        private static System.Globalization.CultureInfo resourceCulture;
        
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal AppResources() {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public static System.Resources.ResourceManager ResourceManager {
            get {
                if (object.Equals(null, resourceMan)) {
                    System.Resources.ResourceManager temp = new System.Resources.ResourceManager("BasicScanner.Localization.AppResources", typeof(AppResources).GetTypeInfo().Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        public static System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        public static string DateLabel {
            get {
                return ResourceManager.GetString("DateLabel", resourceCulture);
            }
        }
        
        public static string TimeLabel {
            get {
                return ResourceManager.GetString("TimeLabel", resourceCulture);
            }
        }
        
        public static string UserLabel {
            get {
                return ResourceManager.GetString("UserLabel", resourceCulture);
            }
        }
        
        public static string FormatLabel {
            get {
                return ResourceManager.GetString("FormatLabel", resourceCulture);
            }
        }
        
        public static string ContentLabel {
            get {
                return ResourceManager.GetString("ContentLabel", resourceCulture);
            }
        }
        
        public static string Close {
            get {
                return ResourceManager.GetString("Close", resourceCulture);
            }
        }
        
        public static string NotesLabel {
            get {
                return ResourceManager.GetString("NotesLabel", resourceCulture);
            }
        }
        
        public static string ScansLabel {
            get {
                return ResourceManager.GetString("ScansLabel", resourceCulture);
            }
        }
        
        public static string LastScanLabel {
            get {
                return ResourceManager.GetString("LastScanLabel", resourceCulture);
            }
        }
        
        public static string MainPageTitle {
            get {
                return ResourceManager.GetString("MainPageTitle", resourceCulture);
            }
        }
        
        public static string ScanLabel {
            get {
                return ResourceManager.GetString("ScanLabel", resourceCulture);
            }
        }
    }
}