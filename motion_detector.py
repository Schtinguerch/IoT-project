import cv2
import numpy as np

from threading import Timer
from datetime import datetime


class InvasionDetector:
    def __init__(self, tg_bot_instance, ds_bot_instance, json_data):
        self.continue_monitoring = True
        self.continue_recording = False
        self.timer_started = False

        self.tg_bot_instance = tg_bot_instance
        self.ds_bot_instance = ds_bot_instance
        self.json_bot_data = json_data

    def start_monitoring(self):
        previous_frame = None
        self.video = cv2.VideoCapture(1)
        print("OpenCV motion detector started")

        while True:
            start_time = datetime.strptime(self.json_bot_data["StartTime"], "%H:%M").time()
            end_time = datetime.strptime(self.json_bot_data["EndTime"], "%H:%M").time()

            if not self.is_time_between(start_time, end_time):
                return

            check, cur_frame = self.video.read()
            pass

    def start_recording(self):
        start_time = datetime.now().strftime("%d.%m.%Y__%H.%M.%S")
        self.filename = "captures/record_" + start_time + ".mp4"
        size = (int(self.video.get(3)), int(self.video.get(4)))

        self.continue_recording = True
        self.result = cv2.VideoWriter(self.filename, cv2.VideoWriter_fourcc(*"MP4V"), 24, size)

        print(f"{start_time}: recording START")

    def stop_recording(self):
        self.continue_recording = False
        self.timer_started = False

        self.video.release()
        self.result.release()

        end_time = datetime.now().strftime("%d.%m.%Y__%H.%M.%S")

        video_file = open(self.filename, "rb")
        for user in self.json_bot_data["TelegramUsers"]:
            self.tg_bot_instance.send_video(user, video_file)

        print(f"{end_time}: recording END")

    def start_timer(self):
        self.timer = Timer(2, self.stop_recording)
        self.timer_started = True
        self.timer.start()

        current_time = datetime.now().strftime("%d.%m.%Y__%H.%M.%S")
        print(f"{current_time}: timer RESTART")

    def is_time_between(self, begin_time, end_time, check_time=None):
        check_time = check_time or datetime.now().time()

        if begin_time < end_time:
            return check_time >= begin_time and check_time <= end_time

        else:
            return check_time >= begin_time or check_time <= end_time
