import time
import random

fancy_wait_timer = 0.2

def fancy_wait():
    time.sleep(fancy_wait_timer)
    print(".")
    time.sleep(fancy_wait_timer)
    print("..")
    time.sleep(fancy_wait_timer)
    print("...")
    time.sleep(fancy_wait_timer * 2)

def start_desc():
    print("You start off at the edge of a glade, the wind whistling at you...as it does.")
    time.sleep(1)
    print("do you go into the glade, to the north, or back the way you came, to the south?")
    time.sleep(1)
    print("don't question how you know this, you have a compass on your forehead or something.")
    time.sleep(1)
    print("North, or south?")

def enter_glade():
    print("As you enter the glade, the trees blow in the breeze, swaying softly or something")
    time.sleep(1)
    print("as you wander through, you see a forked path")
    time.sleep(1)
    print("one brightly lit, with no leafy roof overhead, sunlight beaming through to the east")
    time.sleep(1)
    print("the other, dimly lit, and with a deer decomposing on the edge of it to the west")
    time.sleep(1)
    print("East, or west?")
    
def bright_path():
    death_random()

def dark_path():
    print("as you edge past the corpse, trying not to smell it, you begin your paved walk.")
    time.sleep(1)
    print("nothing eventful happens")
    time.sleep(1)
    print("nothing at all.")
    time.sleep(1)
    print("at the end of the path, you find a chest, do you look inside? it looks heavy.")
    time.sleep(1)
    print("yes, or no?")

def open_chest():
    print("You open the chest and find it filled with gold, you stash as much of it as you can.")
    time.sleep(1)
    print("You retrace your steps, making your way downtown, walking fast, faces pass as you're homebound.")
    time.sleep(1)
    print("You enter, put your gold down, and realise you're the strongest person ever for carrying that gold.")
    time.sleep(1)
    print("Gratz. you won.")

def no_chest():
    death_random()

def death_random():
    my_death = random.random()
    if my_death < 0.25:
        print("You got stabbed.")
    elif 0.25 <= my_death < 0.5:
        print("A dragon swooped down and ate you. Fantasy game.")
    elif 0.5 <= my_death < 0.75:
        print("A goblin runs up behind you, mistakes you for it's girlfriend, marries you forceably, hits you over the head with a mallet, and you wind up pregnant. This is your life now.")
    else:
        print("insert creative death.")