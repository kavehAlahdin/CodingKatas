import re

previous="0"
continueCalculating=True
i=0
while continueCalculating:
    #get input from user
    if i==0:
        expression=input("Enter expression:")
    else:
        expression=input(str(previous)+" ")
        if expression=='quit':
            break
        expression=str(previous)+expression
    expression=re.sub('[a-zA-Z.,:;~?!§$" "]','',expression)
    previous=eval (expression)
    i+=1

print("Good Bye!")
