import cmd
import random
import textwrap
import sys
import os
import time

most_recent_choice = ""


commands = ["north", "east", "south", "west"]

def check_input():
    choice = input("> ")
    while choice not in commands:
        print("input error, try again")
        choice = input("> ")
    else:
        if choice == "north":
            print("heading north")
        elif choice == "south":
            print("heading south")
        elif choice == "west":
            print("heading west")
        elif choice == "east":
            print("heading east")
        most_recent_choice = str(choice)
        
    
def start_game():
    #start the game!
    print("You start on a journey through a glade        ")
    time.sleep(2)
    print("returning from a grocery run in the market    ")
    time.sleep(2)    
    print("you carry with you a basket of bread          ")
    time.sleep(2)
    print("a pitcher of milk and a dozen eggs            ")
    time.sleep(2)
    print()
    print("your home is NORTH, the market is SOUTH       ")
    print()
    #input check
    check_input()
    

def title_screen_selections():
    option = input("> ")
    if option.lower() == ("play"):
       start_game()
    elif option.lower() == ("help"):
        help_menu()
    elif option.lower() == ("quit"):
        sys.exit()
    while option.lower() not in ["play", "help", "quit"]:
        print("Input correct shite")
        option = input("> ")
        if option.lower() == ("play"):
            start_game()
        elif option.lower() == ("help"):
            help_menu()
        elif option.lower() == ("quit"):
            sys.exit()

def title_screen():
    print("~~~~~~~~~~~~~~~~~~~")
    print("    Welcome        ")
    print("~~~~~~~~~~~~~~~~~~~")
    print("   - Play -      \t")
    print("   - Help -      \t")
    print("   - Quit -      \t")
    title_screen_selections()

def help_menu():
    print()
    print("            ###  HELP  ###                    ")
    print("    All keywords you shall see are in caps    ")
    print("use lowercase to type any keywords or commands")
    print()
    title_screen_selections()

title_screen()
