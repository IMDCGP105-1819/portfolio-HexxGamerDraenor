import sys
import random
import time
import Text_Adventure_Descriptions

def quick_end():
    print("You went back home, into bed, and slept. such adventure, right?")
    input("hit enter to quit.")

def start_game():
    #start game here
    print("game started")
    Text_Adventure_Descriptions.fancy_wait()
    Text_Adventure_Descriptions.start_desc()
    selection = input("> ")
    if selection == "north":
        #go into glade here
        print("moving into the glade...")
        Text_Adventure_Descriptions.fancy_wait()
        Text_Adventure_Descriptions.enter_glade()
        Glade_intro()
    elif selection == "south":
        quick_end()
    while selection not in ["south", "north"]:
        print("Try again")
        selection = input("> ")
        if selection == "north":
            #go into glade here
            print("moving into the glade...")
            Text_Adventure_Descriptions.fancy_wait()
            Text_Adventure_Descriptions.enter_glade()
        elif selection == "south":
            quick_end()

def Glade_intro():
    selection = input("> ")
    if selection == "east":
        Text_Adventure_Descriptions.fancy_wait()
        Text_Adventure_Descriptions.bright_path()
    elif selection == "west":
        Text_Adventure_Descriptions.fancy_wait()
        Text_Adventure_Descriptions.dark_path()
        my_dark_path()
    elif selection == "quit":
        sys.exit
    while selection not in ["east", "west", "quit"]:
        print("Try again")
        selection = input("> ")
        if selection == "east":
            Text_Adventure_Descriptions.fancy_wait()
            Text_Adventure_Descriptions.bright_path()
        elif selection == "west":
            Text_Adventure_Descriptions.fancy_wait()
            Text_Adventure_Descriptions.dark_path()
            my_dark_path()
        elif selection == "quit":
            sys.exit

def my_dark_path():
    selection = "> "
    if selection == "yes":
        Text_Adventure_Descriptions.fancy_wait()
        Text_Adventure_Descriptions.open_chest()
        my_open_chest()
    elif selection == "no":
        Text_Adventure_Descriptions.no_chest()
    elif selection == "quit":
        sys.exit
    while selection not in ["yes", "no", "quit"]:
        print("Try again")
        selection = "> "
        if selection == "yes":
            Text_Adventure_Descriptions.fancy_wait()
            Text_Adventure_Descriptions.open_chest()
            my_open_chest()
        elif selection == "no":
            Text_Adventure_Descriptions.no_chest()
        elif selection == "quit":
            sys.exit

def my_open_chest():
    Text_Adventure_Descriptions.open_chest()

def help_menu():
    #help menu
    print("for commands, use lowercase syntax, otherwise you're a massive screw up")
    start_menu()

def start_menu():
    print("     MENU     ")
    print("~~~~ Play ~~~~")
    print("~~~~ Help ~~~~")
    print("~~~~ Quit ~~~~")
    selection = input("> ")
    if selection == "play":
        start_game()
    elif selection == "help":
        help_menu()
    elif selection == "quit":
        sys.exit
    while selection not in ["play", "help", "quit"]:
        print("Input wrong, try again")
        selection = input("> ")
        if selection == "play":
            start_game()
        elif selection == "help":
            help_menu()
        elif selection == "quit":
            sys.exit
        
start_menu()
