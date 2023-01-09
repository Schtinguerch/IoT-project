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
