using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FridgeSnitchClient.Models
{
    public class FridgeModel : BindableObject
    {
        private int _fridgeId;
        private string _fridgeName;
        private TimeSpan _startTrackingTime;
        private TimeSpan _endTrackingTime;

        public int FridgeId
        {
            get => _fridgeId;
            set
            {
                _fridgeId = value;
                OnPropertyChanged(nameof(FridgeId));
            }
        }

        public string FridgeName
        {
            get => _fridgeName;
            set
            {
                _fridgeName = value;
                OnPropertyChanged(nameof(FridgeName));
            }
        }

        public TimeSpan StartTrackingTime
        {
            get => _startTrackingTime;
            set
            {
                _startTrackingTime = value;
                OnPropertyChanged(nameof(StartTrackingTime));
            }
        }

        public TimeSpan EndTrackingTime
        {
            get => _endTrackingTime; 
            set
            {
                _endTrackingTime = value;
                OnPropertyChanged(nameof(EndTrackingTime));
            }
        }

        public FridgeModel Clone()
        {
            return new FridgeModel()
            {
                FridgeId = this.FridgeId,
                FridgeName = this.FridgeName,
                StartTrackingTime = this.StartTrackingTime,
                EndTrackingTime = this.EndTrackingTime,
            };
        }
    }
}
