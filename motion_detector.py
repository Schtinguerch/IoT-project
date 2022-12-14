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

            if cur_frame is None:
                self.video = cv2.VideoCapture(1)
                continue

            prepared_frame = cv2.cvtColor(cur_frame, cv2.COLOR_BGR2GRAY)
            prepared_frame = cv2.GaussianBlur(src=prepared_frame, ksize=(15, 15), sigmaX=0)

            if previous_frame is None:
                previous_frame = prepared_frame
                continue

            diff_frame = cv2.absdiff(src1=previous_frame, src2=prepared_frame)
            previous_frame = prepared_frame

            kernel = np.ones((5, 5))
            diff_frame = cv2.dilate(diff_frame, kernel, 1)

            thresh_frame = cv2.threshold(src=diff_frame, thresh=20, maxval=255, type=cv2.THRESH_BINARY)[1]
            contours, _ = cv2.findContours(image=thresh_frame, mode=cv2.RETR_EXTERNAL, method=cv2.CHAIN_APPROX_SIMPLE)

            if len(contours) > 0:
                ret, frame = self.video.read()
                if not ret:
                    break

                if not self.continue_recording:
                    self.start_recording()

                if self.timer_started:
                    self.timer.cancel()

                self.start_timer()
                now_time = datetime.now().strftime("%d.%m.%Y, %H:%M:%S")

                cv2.putText(frame, now_time, (25, 25), cv2.FONT_HERSHEY_SIMPLEX, 0.6, (0, 255, 0), 2, cv2.LINE_AA)
                self.result.write(frame)

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
