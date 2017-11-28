﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PICodeFirst.GoToTheCloud.Infrastructure.Db.Sql {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class SqlTravelRepositoryQueries {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal SqlTravelRepositoryQueries() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("PICodeFirst.GoToTheCloud.Infrastructure.Db.Sql.SqlTravelRepositoryQueries", typeof(SqlTravelRepositoryQueries).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to INSERT INTO Travels (id, description, start, finish, user_id, location_from_id, location_to_id)
        ///VALUES (@id, @description, @start, @finish, @user_id, @location_from_id, @location_to_id).
        /// </summary>
        internal static string AddTravel {
            get {
                return ResourceManager.GetString("AddTravel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT id, name FROM Locations
        ///ORDER BY NAME ASC.
        /// </summary>
        internal static string GetLocations {
            get {
                return ResourceManager.GetString("GetLocations", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT t.id, 
        ///	t.description,
        ///	t.start,
        ///	t.finish,
        ///	t.user_id,
        ///	t.location_from_id,
        ///	t.location_to_id,
        ///	lf.name as location_from_name,
        ///	lt.name as location_to_name
        ///FROM Travels t
        ///INNER JOIN Locations lf ON (lf.id = t.location_from_id)
        ///INNER JOIN Locations lt ON (lt.id = t.location_to_id)
        ///.
        /// </summary>
        internal static string GetTravelList {
            get {
                return ResourceManager.GetString("GetTravelList", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to SELECT t.id, 
        ///	t.description,
        ///	t.start,
        ///	t.finish,
        ///	t.user_id,
        ///	t.location_from_id,
        ///	t.location_to_id,
        ///	lf.name as location_from_name,
        ///	lt.name as location_to_name
        ///FROM Travels t
        ///INNER JOIN Locations lf ON (lf.id = t.location_from_id)
        ///INNER JOIN Locations lt ON (lt.id = t.location_to_id)
        ///WHERE t.user_id = @user_id.
        /// </summary>
        internal static string GetTravelListForUser {
            get {
                return ResourceManager.GetString("GetTravelListForUser", resourceCulture);
            }
        }
    }
}
