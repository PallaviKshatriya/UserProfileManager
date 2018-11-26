using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace UserProfiles.Model
{
    public class UserProfileSystemSetting : INotifyPropertyChanged
    {
        //This is being changed to test the INotifyPropertyChanged implementation to listen to only changed properties

        private bool _isBranchLnActive;
        private bool _isBranchBrActive;
        private bool _isBranchPrActive;
        private bool _isBranchDfActive;

        public LocalSystem LocalSystem { get; set; }
        public bool IsBranchLnActive
        {
            get { return _isBranchLnActive; }
            set
            {
                _isBranchLnActive = value;
                NotifyPropertyChanged("IsBranchLnActive");
            }
        }
        public bool IsBranchBrActive
        {
            get { return _isBranchBrActive; }
            set
            {
                _isBranchBrActive = value;
                NotifyPropertyChanged("IsBranchBrActive");
            }
        }
        public bool IsBranchPrActive
        {
            get { return _isBranchPrActive; }
            set
            {
                _isBranchPrActive = value;
                NotifyPropertyChanged("IsBranchPrActive");
            }
        }
        public bool IsBranchDfActive
        {
            get { return _isBranchDfActive; }
            set
            {
                _isBranchDfActive = value;
                NotifyPropertyChanged("IsBranchDfActive");
            }
        }

        public int UserAccessId { get; set; }

        public UserLevelCategory Category { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
