import threading
import motion_detector


class Threader:
    def __init__(self, telegram_bot, json_data):
        self.tg_bot = telegram_bot
        self.data = json_data
