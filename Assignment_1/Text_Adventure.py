import sys
import Text_Adventure_Descriptions

my_name = ""

class Player(object):
    def __init__(self, my_name):
        self.name = my_name

def quick_end():
    print("You went back home, into bed, and slept. such adventure, right?")
    input("hit enter to quit.")

def kill_me():
    Text_Adventure_Descriptions.death_random(my_name)

def start_game():
    #start game here
    my_name = input("TYPE YOUR NAME > ")
    Text_Adventure_Descriptions.my_name_ = my_name
    print("game started\n")
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
    elif selection == "killme":
        kill_me()
    while selection not in ["south", "north", "killme"]:
        print("Try again")
        selection = input("> ")
        if selection == "north":
            #go into glade here
            print("moving into the glade...")
            Text_Adventure_Descriptions.fancy_wait()
            Text_Adventure_Descriptions.enter_glade()
        elif selection == "south":
            quick_end()
        elif selection == "killme":
            kill_me()

def Glade_intro():
    selection = input("> ")
    if selection == "east":
        Text_Adventure_Descriptions.fancy_wait()
        Text_Adventure_Descriptions.death_random(my_name)
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
            Text_Adventure_Descriptions.death_random(my_name)
        elif selection == "west":
            Text_Adventure_Descriptions.fancy_wait()
            Text_Adventure_Descriptions.dark_path()
            my_dark_path()
        elif selection == "quit":
            sys.exit

def my_dark_path():
    selection = input("> ")
    if selection == "yes":
        Text_Adventure_Descriptions.fancy_wait()
        Text_Adventure_Descriptions.open_chest()
        my_open_chest()
    elif selection == "no":
        Text_Adventure_Descriptions.death_random(my_name)
    elif selection == "quit":
        sys.exit
    while selection not in ["yes", "no", "quit"]:
        print("Try again")
        selection = "> "
        if selection == "yes":
            Text_Adventure_Descriptions.fancy_wait()
            my_open_chest()
        elif selection == "no":
            Text_Adventure_Descriptions.death_random(my_name)
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
