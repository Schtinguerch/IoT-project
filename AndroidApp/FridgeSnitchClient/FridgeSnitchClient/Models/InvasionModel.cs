using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FridgeSnitchClient.Models
{
    public class InvasionModel : BindableObject
    {
        private string _fridgeName;
        private string _videoUri;
        private string _previewImageUri;
        private DateTime _invasionDateTime;

        public string FridgeName
        {
            get => _fridgeName;
            set
            {
                _fridgeName = value;
                OnPropertyChanged(nameof(FridgeName));
            }
        }

        public string VideoUri
        {
            get => _videoUri;
            set
            {
                _videoUri = value;
                OnPropertyChanged(nameof(FridgeName));
            }
        }

        public string PreviewImageUri
        {
            get => _previewImageUri; 
            set
            {
                _previewImageUri = value;
                OnPropertyChanged(nameof(FridgeName));
            }
        }

        public DateTime InvasionDateTime
        {
            get => _invasionDateTime; 
            set
            {
                _invasionDateTime = value;
                OnPropertyChanged(nameof(FridgeName));
            }
        }

        public int InvasionId { get; set; }
    }
}
