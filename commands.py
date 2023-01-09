from telebot.types import BotCommand


command_dictionary = [
    BotCommand("start", "Начать работу с ботом"),
    BotCommand("shot", "Получить снимок с камеры"),
    BotCommand("recordstart", "Начать запись с видеокамеры"),
    BotCommand("recordstop", "Остановить запись с видеокамеры"),
]