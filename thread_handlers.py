import threading
import motion_detector


class Threader:
    def __init__(self, telegram_bot, json_data):
        self.tg_bot = telegram_bot
        self.data = json_data

    def launch_detector(self):
        detector = motion_detector.InvasionDetector(self.tg_bot, self.ds_bot, self.data)
        detector.start_monitoring()

    def launch_telegram_listener(self):
        self.tg_bot.polling(none_stop=True, interval=0)
        