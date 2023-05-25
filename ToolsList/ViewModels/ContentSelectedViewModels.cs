using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ToolsList.ViewModels
{
    public class ContentSelectedViewModels : INotifyPropertyChanged
    {
        private string actionSelected;
        public string ActionSelected
        { 
            get { return this.actionSelected; } 
            set 
            {
                Debug.WriteLine("actionSelected : " + this.actionSelected);
                if (this.actionSelected != value)
                {
                    Debug.WriteLine("SetActionSelected");
                    this.actionSelected = value;
                    this.NotifyPropertyChanged("actionSelected");                        
                }
                Debug.WriteLine("actionSelected : " + this.actionSelected);
            } 
        }

        public ContentSelectedViewModels(string actionSelected) 
        {
            Debug.WriteLine("Constructor");
            this.ActionSelected = actionSelected;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propName)
        {
            Debug.WriteLine("NotifyPropertyChanged");
            if (this.PropertyChanged != null)
            {
                Debug.WriteLine("NotifyPropertyChanged PropertyChanged not null");
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

    }
}
