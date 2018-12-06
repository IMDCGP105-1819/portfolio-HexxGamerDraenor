semi_annual_raise = 0.07
return_rate = 0.04
down_payment = 0.25
cost_of_house = 1000000
epsilon = 100
num_searches = 0

months_to_save = 36

low = 0
high = cost_of_house

guess = (high + low)/2.0

starting_salary = int(input("Enter starting salary: "))

current_savings = starting_salary/12

while abs(guess - cost_of_house) >= epsilon:
    if guess < cost_of_house:
        low = guess
    else:
        high = guess
    guess = (high + low)/2
    num_searches += 1
    print(abs(guess))

print("num_guesses = ", num_searches)

