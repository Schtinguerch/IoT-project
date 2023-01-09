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

    def launch_all_bots(self):
        print("Start thread pool")
        telegram_listener_thread = threading.Thread(target=self.launch_telegram_listener)
        telegram_listener_thread.start()

        motion_detector_thread = threading.Thread(target=self.launch_detector)
        motion_detector_thread.start()

        self.launch_discord_listener()
        print("Thread pool created")
