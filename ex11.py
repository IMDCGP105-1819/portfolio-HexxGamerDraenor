from random import randint

myInt = randint(1,9)

def GuessNum():
    userGuess = int(input("I'm thinking of a number between 1 and 9, take a guess: "))
    if(userGuess != myInt):
        if(userGuess < myInt):
            print("Aim higher!")
            GuessNum()
        elif(userGuess > myInt):
            print("Aim lower!")
            GuessNum()
        else:
            GuessNum()
    else:
        print("You got it! my number was", myInt, "And you guessed", userGuess)
GuessNum()
        
