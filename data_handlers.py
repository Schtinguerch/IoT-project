import json
import os


print("JSON data initializing")
folder = "captures"
folder_exists = os.path.exists(folder)

if not folder_exists:
    os.makedirs(folder)

f = open('data.json', "r")
data = json.loads(f.read())

f.close()
print("JSON Data initialized")


def save_data():
    stream = open('data.json', "w")
    stream.write(json.dumps(data))
    stream.close()
