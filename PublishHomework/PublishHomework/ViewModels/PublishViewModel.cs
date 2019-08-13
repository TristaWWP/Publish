using Microsoft.Expression.Interactivity.Core;
using PublishHomework.Business;
using PublishHomework.Models;
using PublishHomework.Utilities;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace PublishHomework.ViewModels
{
    public class PublishViewModel : INotifyPropertyChanged
    {
        public static PublishViewModel Instance { get; } = new PublishViewModel();

        public ICommand PushCommand { get; set; }

        public PublishInfo Info { get; private set; }

        public ObservableCollection<PictureInfo> Pictures { get; } = new ObservableCollection<PictureInfo>();        

        public string Tips
        {
            get
            {
                return _tips;
            }
            set
            {
                _tips = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Subject CurrentSubject
        {
            get
            {
                return _currentSubject;
            }
            set
            {
                _currentSubject = value;
                OnPropertyChanged();
            }
        }

        public static int GetTimestamp(DateTime d)
        {
            TimeSpan ts = d.ToLocalTime() - new DateTime(1970, 1, 1).ToLocalTime();
            return (int)ts.TotalSeconds;
        }
        private NetworkConnect NetworkConnect { get; } = new NetworkConnect();
        private PublishViewModel()
        {
            Info = new PublishInfo();
            DefaultInfo.ReadDefaultInfo(Info);           
            PushCommand = new ActionCommand(PublishHomework);
        }

        private void PublishHomework()
        {
            Info.Pictures.Clear();           
            foreach (var pic in Pictures)
            {
                if (pic.IsChecked)
                {
                    Info.Pictures.Add(pic.FilePath);
                }
            }
            
            Info.Categ.Subject = this.CurrentSubject;
            string fromId = "1";
            string timestamp = GetTimestamp(DateTime.Now).ToString();
            this.Tips = NetworkConnect.PublishHomeworkAsync(Info, fromId, timestamp).Result;
            DefaultInfo.WriteDefaultInfo(Info);
        }

        private void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private Subject _currentSubject = Subject.Chinese;
        private string _tips;
    }

    public class PictureInfo
    {
        public string FilePath { get; set; }
        public bool IsChecked { get; set; }
    }

}