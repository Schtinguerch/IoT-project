import cv2
import os
from datetime import datetime


def get_capture() -> str:
    camera = cv2.VideoCapture(1)
    ret, frame = camera.read()

    filename = "captures/capture_" + datetime.now().strftime("%d.%m.%Y__%H.%M.%S") + ".png"
    if not ret:
        print("Error reading camera photo")
        return ""

    cv2.imwrite(filename, frame)
    return filename


def record_video(condition) -> str:
    video = cv2.VideoCapture(1)

    if not video.isOpened():
        print("Error reading videocamera")
        return ""

    start_time = datetime.now().strftime("%d.%m.%Y__%H.%M.%S")
    filename = "captures/record_" + start_time + ".mp4"

    frame_width = int(video.get(3))
    frame_height = int(video.get(4))

    size = (frame_width, frame_height)
    result = cv2.VideoWriter(filename, cv2.VideoWriter_fourcc(*"MP4V"), 30, size)
