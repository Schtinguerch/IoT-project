# Интернет вещей: проект "А где сало?"

В быту иногда возникает проблема формата "А где сало?", при этом никто не признаётся в содеянном. Наша система поможет разрешить этот спор. Также система окажет содействие тем, кто решил привить себе режим "Не есть после 18:00", так, тренер или супруг(а) сможет оценивать ситуацию и выполнение/невыполнение заявленного режима.

## Участники

Псевдоним | ФИО | Группа
--- | --- | ---
KopeykinDmitriy | Копейкин Дмитрий Евгеньевич | РИС-20-1б
Schtinguerch | Шумилов Лев Сергеевич | РИС-20-1б
SpidiMun | Ознобихин Елисей Андреевич | РИС-20-1б


## Тех. задание

Разработать аппаратную и программно-информационную систему, позволяющую отслеживать доступ в холодильник в ночное время суток.

Пользователь сможет осуществлять проверку на предмет "несанционированного" доступ к холодильнику в определённый момент времени, который считается недостустимым, например: ночью, для оперативных принятия мер в дальнейшем.

Аппаратный элемент внедряется внутрь холодильника в верней полке и работает от аккумулятора. Так холодильник превращается в "интернет-вещь" и становится частью **интернета вещей**.

Разрабатываемое ПО:
1. Система управления базой данных
2. Telegram-бот для управления устройством
3. ПО для физического устройства

Аппаратная часть:
1. Плата с поддержкой WiFi, USB
2. Видеокамера

## Инструкция по развёртыванию системы

Требования:
1. Наличие интерпретатора Python, менеджера pip и venv
2. Наличие токена от собственного telegram-бота
3. Установленный git
4. Видеокамера и выход в интернет на устройстве

```bash
git clone https://github.com/Schtinguerch/IoT-project.git
cd IoT-project

#Enable python virtual environment
python -m venv virtual_env
source virtual_env/bin/activate
```

Последняя команда для Windows вместо `source`
```
.\virtual_env\Scripts\activate.bat
```

Автоматическая установка зависимостей и запуск системы
```
pip install -r requirements.txt
python main.py
```