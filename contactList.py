class Person(object):

    def __init__(self, name, phone, email, contactList):
        self.name = name
        self.phone = phone
        self.email = email
        contactList.append(self) #add exam to list of exams

    def print(self):
        print(self.name + ", " + self.phone + ", " + self.email)
        
        
def main():

    contactList = []
    x = False
    print("Welcome to your contact directory\n")
    print ("To add a contact type 'add'")
    print("To remove a contact type 'remove'")
    print("To find a contact type 'find'")
    print("To update a contact type 'update'")
    print("To view all contacts type 'view'\n")
    
    while x == False:
        a = input()
        if a == "add":
            add(contactList)
        elif a == "remove":
            remove(contactList)
        elif a == "find":
            find(contactList)
        elif a == "update":
            update(contactList)
        elif a == "view":
            view(contactList)
        else:
            print("Sorry command not recognised!")

def add(contactList):

    name = input("Please enter the contacts name\n")
    phone = input("Please enter the contacts phone\n")
    email = input("Please enter the contacts email\n")

    Person(name, phone, email, contactList)

def view(contactList):

	if not contactList:
		print("List is empty")
	else:
		for person in contactList:
			person.print()

def find(contactList):

    name = input("Which person would you like to find?\n")
    found = False
    
    for person in contactList:

        if name == person.name:
            person.print()
            found = True
            
    if found == False:
        print("Sorry name not found")

def remove(contactList):

    name = input("Which person would you like to remove?\n")
    found = False

    for i, person in enumerate(contactList):

        if person.name == name:
            del contactList[i]
            found = True

    if found == False:
        print("Sorry name not found")
    else:
    	print(name + " successfully removed")
    

def update(contactList):
    
    name = input("Which person would you like to update?\n")
    found = False
    
    for person in contactList:

        if name == person.name:
            person.print()

            field(person)
            
            found = True
            
    if found == False:
        print("Sorry name not found")
        update(contactList)

def field(person):
    valid = False
    while valid == False:
        field = input("Which field would you like to update? 'name', 'phone', 'email'\n")
        if field == "name":
            person.name = input("Enter new " + field + "\n")
            print("Name was updated")
            valid = True
        elif field == "phone":
            person.phone = input("Enter new " + field + "\n")
            print("Phone was updated")
            valid = True
        elif field == "email":
            person.email = input("Enter new " + field + "\n")
            print("Email was updated")
            valid = True
        else:
            print("Sorry field not found")
   
main()


