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

@tg_bot.message_handler(commands=["начать"])
def on_start_command(message):
    if message.from_user.id in data_handlers.data["TelegramUsers"]:
        tg_bot.send_message(message.from_user.id, "Всё хорошо, я уже настроен и во всю работаю!!!")
        return

    data_handlers.data["TelegramUsers"].append(message.from_user.id)
    data_handlers.save_data()

    tg_bot.send_message(message.from_user.id, "Настройка прошла успешно, за сим я на страже!")

@tg_bot.message_handler(commands=["снять"])
def on_shot_command(message):
    photo = camera_handlers.get_capture()
    if photo == "":
        tg_bot.send_message(message.from_user.id, "Ошибка: не удалось сделать снимок; проверьте состояние камеры")
        return

    tg_bot.send_photo(message.from_user.id, open(photo, "rb"))