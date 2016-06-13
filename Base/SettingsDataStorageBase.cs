using Windows.Storage;

namespace QPLib.Base
{
    ///
    /// <summary>
    /// For committing a setting to local settings storage as a key-value pair.  Designed
    /// to be inherited.
    /// </summary>
    /// 

    ///
    /// <remarks>
    /// 
    /// Use of this class globally does not require it to be instantiated within a singleton.
    /// 
    /// This class creates (gets if it already exists) a sub-container within 
    /// ApplicationData.Current.LocalSettings container.  The method, WriteSettingToDisk(),
    /// will always write the setting to that container.
    /// 
    /// You can think of containers as folders.
    /// 
    /// </remarks>
    ///
    public class SettingsDataStorageBase
    {
        //
        // Folder name
        //
        const string SETTINGS_CONTAINER_NAME = "settings";



        //
        // Store all local settings here
        //
        ApplicationDataContainer _settingsContainer;
        public ApplicationDataContainer SettingsContainer { get { return _settingsContainer; } }





        public SettingsDataStorageBase()
        {
            //
            // Get the app's local settings folder
            //
            ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;

            //
            // Create a new sub container named "settings" within LocalSettings.  Get if it already exists
            //
            _settingsContainer = localSettings.CreateContainer(SETTINGS_CONTAINER_NAME, ApplicationDataCreateDisposition.Always);
        }














        //
        // Commit the variable to storage within _settingsContainer.
        //
        // The container parameter is the location where the setting will be stored.
        //
        // The key parameter is the literal name of the setting you want to write,
        // aka the "file name".
        // 
        // The value parameter gets stored with the key (aka within the file.)
        //
        // This is basic key-value pairs.
        //
        public void OverwriteSettingToDisk(ApplicationDataContainer container, string key, object value)
        {
            container.Values[key] = value;
        }








    }
}
