from funcs import *
rows = getRows()
writeInFile(rows, "input.txt")
amount = int(input("Enter the amount of rows you want to copy \n"))
miss = createOuptup("output.txt", rows, amount)
printFile("input.txt")
printFile("output.txt")
print("The amount of deleted rows = ", miss)