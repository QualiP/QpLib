/*
    Date      :     Monday, June 13, 2016
    Author    :     QualiP (https://github.com/QualiP)
    Objective :     
    Version   :     1.0
*/





using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace QPLib.Base
{
    ///
    /// <summary>
    ///     INotifyPropertyChanged interface implementation boiler-plate code.
    /// </summary>
    ///

    ///
    /// <remarks>
    /// 
    /// <see cref="https://msdn.microsoft.com/en-us/windows/uwp/data-binding/data-binding-in-depth"/>
    /// 
    ///     The C#5.0 attribute [CallerMemberName] allows OnPropertyChanged to be called without a magic string,
    ///     that is, OnPropertyChanged() instead of OnPropertyChanged("PropertyName").
    ///     
    ///     Note:
    ///         Only works with regular Binding.
    ///         When using x:Bind, PropertyChanged is always null.
    ///         2016-05-27
    ///             I may be wrong about the binding...
    ///         
    ///     Update 2016-06-27:
    ///         Added a second event to propagate changes to all
    ///         instances of a property.  For use with properties
    ///         that return static backing fields.
    ///         
    /// </remarks>
    ///

    ///
    /// <example>
    /// TargetProperty="{Binding Path=_viewModel.Property, Mode=OneWay}"
    /// </example>
    ///
    public class NotifyPropertyChangedBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }






        //
        // Be extremely careful about which properties call this event
        //
        // Current list of properties:
        //  QPGoogleAPI.OAuth.Flows.OAuthInstalledFlow.AuthorizedUser
        //
        // Do not try to keep up with the list of properties that subscribe
        // to this event.
        // All event subscribers must check PropertyChangedEventArgs.PropertyName.
        //
        public static event PropertyChangedEventHandler SingletonPropertyChanged;
        protected void OnSingletonPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var singleton = SingletonPropertyChanged;
            if (singleton != null)
                singleton(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
