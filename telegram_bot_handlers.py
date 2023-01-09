import telebot
import commands
import camera_handlers
import data_handlers


print("Start creating Telegram Bot instance")
if not ("TelegramApiKey" in data_handlers.data):
    print("First app launch, please insert your Telegram Bot API token inside data.json in ApiKeys property")
    exit(0)
