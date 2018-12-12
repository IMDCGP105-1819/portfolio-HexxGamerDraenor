import sys
import random

commands = ["North", "East", "South", "West", "Pickup"]

class Player(object):
    inventory = []
    inv_slots = 5
    def __init__(self):
        self.inv_slots = 5
        self.name = None
        self.inventory = []
        
    def add_item(self, item):
        self.inventory.append(item)
        self.inv_slots = self.inv_slots - 1

    def display_inventory():
        print("Inv slots = ", Player.inv_slots)
        print("Inventory = ", Player.inventory)
        
def set_name():
    player_name = input("Please Enter Your Name >>> ")
    Player.name = player_name

    #print(Player.name)
    
def help_menu():
    print("""
        ~~~ Use a capital letter for your command,
        several commands include:
        """, commands, """
        , Or are usually defined by capitalised keywords""")
    start_menu()
    
def start_game():
    items_in_room = ["Box", "Paper"]
    
    command_check(items_in_room)
    
def command_check(items_in_room):
    #inventory check
    com_test = input(">>> ")
    if com_test == "North":
        print("Moving north")
    elif com_test == "South":
        print("Moving South")
    elif com_test == "West":
        print("Moving West")
    elif com_test == "East":
        print("Moving East")
    elif com_test == "Pickup":
        chosen_item = input("What item would you like to pickup? >>> ")
        if chosen_item in items_in_room:
            Player.add_item(Player, chosen_item)
            items_in_room.remove(chosen_item)
            Player.display_inventory()
        else:
            print("You cannot add that to your inventory")
    while com_test not in commands:
        print("Command not recognised, please try again.")
        com_test = input(">>> ")
        if com_test == "North":
            print("Moving north")
        elif com_test == "South":
            print("Moving South")
        elif com_test == "West":
            print("Moving West")
        elif com_test == "East":
            print("Moving East")
        elif com_test == "Pickup":
            chosen_item = input("What item would you like to pickup? >>> ")
            if chosen_item in items_in_room:
                Player.add_item(Player, chosen_item)
                Player.display_inventory()
                items_in_room.remove(chosen_item)
                command_check(items_in_room)
            else:
                print("You cannot add that to your inventory")
        
def start_menu():
    print("""
        ~~~ GAME ~~~
        ~~~ Play ~~~
        ~~~ Help ~~~
        ~~~ Quit ~~~
        """)
    selection = input(">>> ")
    if selection == "Play":
        #start game here
        start_game()
    elif selection == "Help":
        #help menu display
        help_menu()
    elif selection == "Quit":
        sys.exit()
    while selection not in ["Play", "Help", "Quit"]:
        print("Command not recognised, please try again. Refer to \"Help\" if unsure.")
        selection = input(">>> ")
        if selection == "Play":
            #start game here
            start_game()
        elif selection == "Help":
            #help menu display
            help_menu()
        elif selection == "Quit":
            sys.exit()
start_menu()
