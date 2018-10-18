low = int(input("Input low value "))
high = int(input("Input high value "))

print(low)
while(low < high):
    low = low + 1
    if(low%3 == 0 and low%5 == 0):
        print ("FizzBuzz")
    elif(low%5 == 0):
        print("Buzz")
    elif (low%3 == 0):
        print("Fizz")
    else:
        print(low)
