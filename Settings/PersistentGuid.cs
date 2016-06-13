/*
    Date      :     Monday, June 13, 2016
    Author    :     QualiP (https://github.com/QualiP)
    Objective :     
    Version   :     1.0
*/


using QPLib.Base;
using System;
using Windows.Storage;




namespace QPLib.BackgroundTasks.Settings
{
    ///
    /// <summary>
    /// Assigns your application a unique guid which persists in storage.  A unique
    /// guid is generated when your application first runs on the user's system after
    /// it is installed.  Generally, the only way to change this guid is to uninstall,
    /// then reinstall the app.
    /// </summary>
    /// 

    ///
    /// <remarks>
    /// <see cref="https://msdn.microsoft.com/en-us/library/windows/apps/windows.networking.backgroundtransfer.backgrounddownloader.aspx?cs-save-lang=1&cs-lang=csharp#code-snippet-1"/>
    /// A unique guid for your app is required to retrieve your app's background download operations.
    /// Without a unique guid (per app), other installed applications using this same library may also retrieve
    /// any other application's background download operations.
    /// 
    /// Always associate a background task with your app's unique guid and use the same guid
    /// throughout the application lifetime (from installation to uninstallation.)
    /// </remarks>
    ///
    public class PersistentGuid : SettingsDataStorageBase
    {
        const string GUID_SUB_CONTAINER_NAME = "guid";



        ApplicationDataContainer _guidContainer;


        static Guid _appGuid;
        public Guid AppGuid
        {
            get
            {
                if (_appGuid == null || _appGuid == Guid.Empty)
                    _appGuid = (Guid)_guidContainer.Values["_appGuid"];

                return _appGuid;
            }
        }



        public PersistentGuid() : base()
        {
            //
            // Create (or if it exists, get) a new sub container within
            // base.SettingsContainer (which is a sub container of ApplicationData.Current.LocalSettings)
            //      "//LocalSettings/settings/guid"
            //
            _guidContainer = base.SettingsContainer.CreateContainer(GUID_SUB_CONTAINER_NAME, ApplicationDataCreateDisposition.Always);


            //
            // <see cref="https://stackoverflow.com/questions/2344098/c-sharp-how-to-create-a-guid-value"/>
            // If the guid currently does not exist within the guid container, generate a new guid.
            //
            if (!_guidContainer.Values.ContainsKey("_appGuid"))
                _guidContainer.Values["_appGuid"] = Guid.NewGuid();

            if (_appGuid == null || _appGuid == Guid.Empty)
                _appGuid = (Guid)_guidContainer.Values["_appGuid"];
        }
    }
}
