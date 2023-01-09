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
