import json
import os


print("JSON data initializing")
folder = "captures"
folder_exists = os.path.exists(folder)

if not folder_exists:
    os.makedirs(folder)