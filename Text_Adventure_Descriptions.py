import time
import random

fancy_wait_timer = 1

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

def death_random(my_name):
    my_death = random.randrange(1, 4)
    if my_death < 0.25:
        print("You got stabbed, ", my_name_, ".")
        input("enter to exit")
    elif 0.25 <= my_death < 0.5:
        print("A dragon swooped down and ate you. Fantasy game.", my_name_)
        input("enter to exit")
    elif 0.5 <= my_death < 0.75:
        print("A goblin runs up behind you, mistakes you for it's girlfriend, marries you forceably, hits you over the head with a mallet, and you wind up pregnant. This is your life now.", my_name_)
        input("enter to exit")
    elif 1 <= my_death < 1.25:
        print("So an ogre notices you're trespassing, stands on you, notices you're still alive somehow, picks you up, sticks you to his boot, and walks for 6 miles", my_name_)
        print("(6 ogre steps), making sure you're well and truly fucked.", my_name_)
        input("enter to exit")
    elif 1.25 <= my_death < 1.5:
        print("Anda meninggal, ", my_name_, ".")
        input("enter to exit")
    elif 1.5 <= my_death < 1.75:
        print("chi wedi marw.", my_name_)
        input("enter to exit")
    elif 1.75 <= my_death < 2:
        print("you stepped...on a landmine...how??? what??? ", my_name_, "??????")
        input("enter to exit")
    elif 2 <= my_death < 2.25:
        print("omae wa...mo shinderu", my_name_)
        input("enter to exit")
    elif 2.25 <= my_death < 2.5:
        print("YOU DISCOVER YOU'RE A GOD AND ASCEND TO THE HEAVENS TO MEET WITH YOUR FATHER ODIN AND RIDE THE JORMUNGARDR TILL THE DAY YOU DIE IN GLORIOUS BATTLE(jk you died)", my_name_)
        input("enter to exit")
    elif 2.75 <= my_death < 3:
        print("you got crushed by a mountain. yes a mountain. because life isn't easy.", my_name_)
        input("enter to exit")
    elif 3 <= my_death < 3.25:
        print("you get bogged down by all the assignments you have to do for uni and get severely depressed, you spend the rest of your life sleeping and taking medication. true story.", my_name_)
        input("enter to exit")
    elif 3.25 <= my_death < 3.5:
        print("a random nuke goes off 3 feet from you. no idea how or why, but it happened. you died.", my_name_)
        input("enter to exit")
    elif 3.5 <= my_death < 3.75:
        print("YOU WIN")
        time.sleep(4)
        print("jk you died", my_name_)
        input("enter to exit")
    elif 3.75 <= my_death < 4:
        print("YOU")
        time.sleep(1)
        print("FUCKIN")
        time.sleep(1)
        print("DIED")
        time.sleep(1)
        print(my_name_.upper())
        input("enter to exit")
    else:
        print("insert creative death.")
        input("enter to exit")