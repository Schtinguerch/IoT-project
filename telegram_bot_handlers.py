import telebot
import commands
import camera_handlers
import data_handlers


print("Start creating Telegram Bot instance")
if not ("TelegramApiKey" in data_handlers.data):
    print("First app launch, please insert your Telegram Bot API token inside data.json in ApiKeys property")
    exit(0)

try:
    tg_bot = telebot.TeleBot(data_handlers.data["TelegramApiKey"])
    tg_bot.set_my_commands(commands.command_dictionary)

except Exception:
    print("Error: cannot create Telegram Bot's instance, check your connection and Api Key")
    exit(1)
