import thread_handlers
import telegram_bot_handlers
import discord_bot_handlers
import data_handlers


def start_bot():
    print("Start system")
    tg_bot = telegram_bot_handlers.tg_bot
    data = data_handlers.data

    handler = thread_handlers.Threader(tg_bot, data)
    handler.launch_all_bots()
    print("System start success")
    pass


if __name__ == '__main__':
    start_bot()
