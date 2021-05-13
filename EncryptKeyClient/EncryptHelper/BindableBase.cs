using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace EncryptKeyClient.EncryptHelper
{
    public class BindableBase:INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        void OnInvokeHandler(string propertyName)
        {
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(propertyName));
        }
        public bool Set<T>(ref T item,T value,[CallerMemberName]string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(item,value))
            {
                item = value;
                OnInvokeHandler(propertyName);
                return true;
            }
            return false;
        }
    }
}
