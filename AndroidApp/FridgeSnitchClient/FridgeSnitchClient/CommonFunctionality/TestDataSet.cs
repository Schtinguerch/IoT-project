using FridgeSnitchClient.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FridgeSnitchClient.CommonFunctionality
{
    public static class TestDataSet
    {
        public static ObservableCollection<InvasionModel> Invasions = new ObservableCollection<InvasionModel>()
        {
            new InvasionModel()
            {
                FridgeName = "Дачный 1",
                InvasionDateTime = DateTime.Now,
                PreviewImageUri = "https://i.picsum.photos/id/302/600/380.jpg?hmac=1PFuYBDG9YWbWiRqKwYRfgk_PScfJy6rODHAN18AVEk",
                VideoUri = "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ForBiggerBlazes.mp4",
            },
            new InvasionModel()
            {
                FridgeName = "Дачный 1",
                InvasionDateTime = DateTime.Now,
                PreviewImageUri = "https://i.picsum.photos/id/1035/500/250.jpg?hmac=PuRBD7oXvr2BuGyp-kwfv66qmBmqGkDeaJTrVNykeSY",
                VideoUri = "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/ForBiggerJoyrides.mp4",
            },
            new InvasionModel()
            {
                FridgeName = "Дачный 1",
                InvasionDateTime = DateTime.Now,
                PreviewImageUri = "https://i.picsum.photos/id/363/550/280.jpg?hmac=rl6PjIjQt1t5sWrZtrJrALgXfUUvBXGUkwiu8KCoNgU",
                VideoUri = "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/WeAreGoingOnBullrun.mp4",
            },
        };

        public static ObservableCollection<FridgeModel> Fridges = new ObservableCollection<FridgeModel>()
        {
            new FridgeModel()
            {
                FridgeId = 12,
                FridgeName = "Дачный 1",
                StartTrackingTime = new TimeSpan(23, 0, 0),
                EndTrackingTime = new TimeSpan(7, 0, 0),
            },

            new FridgeModel()
            {
                FridgeId = 16,
                FridgeName = "Домашний 2",
                StartTrackingTime = new TimeSpan(21, 30, 0),
                EndTrackingTime = new TimeSpan(6, 40, 0),
            },
        };
    }
}
