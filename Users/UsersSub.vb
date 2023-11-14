Module UsersSub
    Public Sub AddNewUser()
        ' Create a new instance of the User structure.
        Dim newUser As User

        Console.Clear()
        Console.WriteLine("-------------------- ADD A NEW USER --------------------")
        ' Prompt for each field and assign it to the newUser using validation functions.
        newUser.username = AskAndValidStringInput("Please enter the new user's username:")
        newUser.password = AskAndValidStringInput("Please enter the new user's password:")
        newUser.firstName = AskAndValidStringInput("Please enter the new user's first name:")
        newUser.lastName = AskAndValidStringInput("Please enter the new user's last name:")
        newUser.age = AskAndValidateIntegerInput("Please enter the new user's age:")
        Console.WriteLine(vbNewLine & "Please enter the new user's address (not mandatory):")
        newUser.address = Console.ReadLine()
        newUser.telephoneNumber = AskAndValidPhoneNumberInput("Please enter the new user's telephone number in this format XXX-XXX-XXXX:")

        ' Set the default values for the newUser.
        newUser.id = userNextId
        newUser.statusActiveInactive = Status.Active
        newUser.userCredentials = Credentials.User

        'Resize array?
        If userNextId >= users.Length Then
            ReDim Preserve users(users.Length * 2 - 1)
        End If

        ' Add the new user to the array and increment the nextId.
        users(userNextId - 1) = newUser
        userNextId += 1

        MsgBox($"User {newUser.username} added successfully.", MsgBoxStyle.Exclamation, "Success")
    End Sub



    Sub deleteUserAdmin()
        Console.Clear()
        Console.WriteLine("-------------------- DELETE USER --------------------")
        displayActiveUsers()

        Dim userIdToDelete As Integer = AskAndValidateIntegerInput("Select the ID of the user do you want to delete? (The status will change to inactive)")
        Dim userFound As Boolean = False
        Dim userName As String = ""

        ' Use a For loop with an index to modify the users array directly.
        For i As Integer = 0 To users.Length - 1
            If users(i).id = userIdToDelete Then
                users(i).statusActiveInactive = Status.Inactive
                userName = users(i).firstName & " " & users(i).lastName ' Store the name of the user.
                userFound = True
                MsgBox("User '" & userName & "' with ID " & userIdToDelete & " has been set to inactive.", MsgBoxStyle.Critical, "User Deleted!")
                Exit For
            End If
        Next

        If Not userFound Then
            MsgBox("There is no active user with the selected ID.", MsgBoxStyle.Exclamation, "Wrong input")
        Else
            'Nothing
        End If
    End Sub

    Sub deleteUser()
        Dim userFound As Boolean = False
        Dim userName As String = ""

        Do
            Console.Clear()
            Console.WriteLine("-------------------- DELETE USER --------------------")
            Console.WriteLine(vbNewLine & "Are you sure you want to delete your account?" & vbNewLine & "Please enter Y for yes or N for no")
            Dim deleteAcountYesOrNo = Console.ReadLine
            If deleteAcountYesOrNo.ToUpper = "Y" Then
                'Exit loop and proceed
                Exit Do
            ElseIf deleteAcountYesOrNo.ToUpper = "N" Then
                MsgBox("We are happy that you decided to stay with us!", MsgBoxStyle.Exclamation, "Happy")
                toMainMenu()
            Else
                MsgBox("Wront input. Please enter Y or N", MsgBoxStyle.Exclamation, "Wrong Input")
            End If
        Loop


        'PASSWORD
        Do
            'ask password
            Console.WriteLine(vbNewLine & "Please enter your password")
            passwordInput = Console.ReadLine()

            'validate username and password
            Dim isvaliduser As Boolean = ValidatePassword(passwordInput)
            If Not isvaliduser Then
                MsgBox("Invalid password!", MsgBoxStyle.Critical, "Invalid")
            Else
                ' if the username and password match, exit the loop           
                Exit Do
            End If
        Loop

        ' Use a For loop with an index to modify the users array directly.
        For i As Integer = 0 To users.Length - 1
            If users(i).username = usernameInput Then
                users(i).statusActiveInactive = Status.Inactive
                userName = users(i).firstName & " " & users(i).lastName ' Store the name of the user.
                userFound = True
                MsgBox("Your account has beed deleted!", MsgBoxStyle.Critical, "Account Deleted")
                Exit For
            End If
        Next

        If Not userFound Then
            MsgBox("There is no active user with the selected ID.", MsgBoxStyle.Exclamation, "Wrong input")
            Console.ReadLine()
        Else
            'Account deleted
            'Exit program
            exitProgram()
        End If
    End Sub

    Sub editUserAdmin()
        Console.Clear()
        Console.WriteLine("-------------------- EDIT USER --------------------")
        displayAllUsers()

        Dim userIdToEdit As Integer = AskAndValidateIntegerInput("Select the ID of the user you want to edit:")
        Dim userIndexToEdit As Integer = -1

        ' Find the index of the user in the array.
        For i As Integer = 0 To users.Length - 1
            If users(i).id = userIdToEdit Then
                userIndexToEdit = i
                Exit For
            End If
        Next

        ' If the user is not found, display a message and exit 
        If userIndexToEdit = -1 Then
            Console.WriteLine("User with ID " & userIdToEdit & " not found.")
            Console.WriteLine("Press any key to continue.")
            Console.ReadLine()
            Return
        End If

        ' User selection for what to edit.
        Console.Clear()
        Console.WriteLine(vbNewLine & "Select the attribute you want to edit for user ID " & userIdToEdit & ":")
        Console.WriteLine("1. Username")
        Console.WriteLine("2. Password")
        Console.WriteLine("3. First Name")
        Console.WriteLine("4. Last Name")
        Console.WriteLine("5. Age")
        Console.WriteLine("6. Address")
        Console.WriteLine("7. Telephone Number")
        Console.WriteLine("Enter the number of the attribute you want to edit:")

        Select Case Console.ReadLine()
            Case "1"
                users(userIndexToEdit).username = AskAndValidStringInput("Actual username of " & users(userIndexToEdit).username & ": " & users(userIndexToEdit).username & vbNewLine & "Enter the new username:")
            Case "2"
                users(userIndexToEdit).password = AskAndValidStringInput("Actual password of " & users(userIndexToEdit).username & ": " & users(userIndexToEdit).password & vbNewLine & "Enter the new password:")
            Case "3"
                users(userIndexToEdit).firstName = AskAndValidStringInput("Actual first name of " & users(userIndexToEdit).username & ": " & users(userIndexToEdit).firstName & vbNewLine & "Enter the new first name:")
            Case "4"
                users(userIndexToEdit).lastName = AskAndValidStringInput("Actual last name of " & users(userIndexToEdit).username & ": " & users(userIndexToEdit).lastName & vbNewLine & "Enter the new last name:")
            Case "5"
                users(userIndexToEdit).age = AskAndValidateIntegerInput("Actual age of " & users(userIndexToEdit).username & ": " & users(userIndexToEdit).age & vbNewLine & "Enter the new age:")
            Case "6"
                users(userIndexToEdit).address = AskAndValidStringInput("Actual address of " & users(userIndexToEdit).username & ": " & users(userIndexToEdit).address & vbNewLine & "Enter the new address:")
            Case "7"
                users(userIndexToEdit).telephoneNumber = AskAndValidPhoneNumberInput("Actual age of " & users(userIndexToEdit).username & ": " & users(userIndexToEdit).telephoneNumber & vbNewLine & "Enter the new telephone number (XXX-XXX-XXXX):")
            Case Else
                MsgBox("Invalid selection. No changes made.", MsgBoxStyle.Exclamation, "Wrong Input")
        End Select

        MsgBox(users(userIndexToEdit).username & " has been updated successfully.", MsgBoxStyle.Exclamation, "Edit")
    End Sub

    Sub editUser()
        Console.Clear()
        Console.WriteLine("-------------------- EDIT USER --------------------")

        Dim userIndexToEdit As Integer = -1

        ' Find the index of the user in the array.
        For i As Integer = 0 To users.Length - 1
            If users(i).username = usernameInput Then
                userIndexToEdit = i
                Exit For
            End If
        Next

        ' If the user is not found, display a message and exit the subroutine.
        If userIndexToEdit = -1 Then
            Console.WriteLine("User with ID " & usernameInput & " not found.")
            Console.WriteLine("Press any key to continue.")
            Console.ReadLine()
            Return
        End If

        ' User selection for what to edit.
        Console.Clear()
        Console.WriteLine(vbNewLine & "Select the attribute you want to edit for user ID " & usernameInput & ":")
        Console.WriteLine("1. Username")
        Console.WriteLine("2. Password")
        Console.WriteLine("3. First Name")
        Console.WriteLine("4. Last Name")
        Console.WriteLine("5. Age")
        Console.WriteLine("6. Address")
        Console.WriteLine("7. Telephone Number")
        Console.WriteLine("Enter the number of the attribute you want to edit:")

        Select Case Console.ReadLine()
            Case "1"
                users(userIndexToEdit).username = AskAndValidStringInput("Actual username of " & users(userIndexToEdit).username & ": " & users(userIndexToEdit).username & vbNewLine & "Enter the new username:")
            Case "2"
                users(userIndexToEdit).password = AskAndValidStringInput("Actual password of " & users(userIndexToEdit).username & ": " & users(userIndexToEdit).password & vbNewLine & "Enter the new password:")
            Case "3"
                users(userIndexToEdit).firstName = AskAndValidStringInput("Actual first name of " & users(userIndexToEdit).username & ": " & users(userIndexToEdit).firstName & vbNewLine & "Enter the new first name:")
            Case "4"
                users(userIndexToEdit).lastName = AskAndValidStringInput("Actual last name of " & users(userIndexToEdit).username & ": " & users(userIndexToEdit).lastName & vbNewLine & "Enter the new last name:")
            Case "5"
                users(userIndexToEdit).age = AskAndValidateIntegerInput("Actual age of " & users(userIndexToEdit).username & ": " & users(userIndexToEdit).age & vbNewLine & "Enter the new age:")
            Case "6"
                users(userIndexToEdit).address = AskAndValidStringInput("Actual address of " & users(userIndexToEdit).username & ": " & users(userIndexToEdit).address & vbNewLine & "Enter the new address:")
            Case "7"
                users(userIndexToEdit).telephoneNumber = AskAndValidPhoneNumberInput("Actual age of " & users(userIndexToEdit).username & ": " & users(userIndexToEdit).telephoneNumber & vbNewLine & "Enter the new telephone number (XXX-XXX-XXXX):")
            Case Else
                MsgBox("Invalid selection. No changes made.", MsgBoxStyle.Exclamation, "Wrong Input")
        End Select

        MsgBox("Your account has been updated successfully.", MsgBoxStyle.Exclamation, "Updated!")
    End Sub

    Sub ChangeUserStatus()
        Console.Clear()
        Console.WriteLine("-------------------- TOGGLE USER STATUS --------------------")
        displayAllUsers() ' Assuming this subroutine exists and displays all users with their IDs.

        Dim userIdToToggle As Integer = AskAndValidateIntegerInput("Enter the ID of the user to toggle status:")
        Dim userFound As Boolean = False

        ' Use a For loop with an index to find and modify the user status.
        For i As Integer = 0 To users.Length - 1
            If users(i).id = userIdToToggle Then
                ' Toggle the status.
                If users(i).statusActiveInactive = Status.Active Then
                    users(i).statusActiveInactive = Status.Inactive
                    MsgBox("User with ID " & userIdToToggle & " has been set to INACTIVE.", MsgBoxStyle.Exclamation, "Status Change")
                Else
                    users(i).statusActiveInactive = Status.Active
                    MsgBox("User with ID " & userIdToToggle & " has been set to ACTIVE.", MsgBoxStyle.Exclamation, "Status Change")
                End If
                userFound = True
                Exit For ' Exit the loop after the user is found and modified.
            End If
        Next

        If Not userFound Then
            MsgBox(vbNewLine & "User ID not found", MsgBoxStyle.Exclamation, "Wrong input")
        End If
    End Sub

    Sub changeUserCredentials()
        Console.Clear()
        Console.WriteLine("-------------------- TOGGLE CREDENTIALS --------------------")
        displayAllUsers()

        Dim userIdToToggle As Integer = AskAndValidateIntegerInput("Enter the ID of the user to change credentials:")
        Dim userFound As Boolean = False

        ' Use a For loop with an index to find and modify the user credentials.
        For i As Integer = 0 To users.Length - 1
            If users(i).id = userIdToToggle Then
                userFound = True ' Set userFound to True when the user is found
                If users(i).userCredentials = Credentials.User Then
                    users(i).userCredentials = Credentials.Admin
                    MsgBox("User with ID " & userIdToToggle & " has been given ADMIN privileges.", MsgBoxStyle.Exclamation, "Credential")
                Else
                    users(i).userCredentials = Credentials.User
                    MsgBox("User with ID " & userIdToToggle & " has been revoke ADMIN privileges.", MsgBoxStyle.Exclamation, "Credential")
                End If
                Exit For ' Exit the loop after the user is found and modified.
            End If
        Next

        If Not userFound Then
            MsgBox(vbNewLine & "User ID not found", MsgBoxStyle.Exclamation, "Wrong input")
        End If
    End Sub



    ' FUNCTIONS
    ' Function to validate non-empty input
    Function AskAndValidStringInput(prompt As String) As String
        Dim input As String
        Do
            Console.WriteLine(vbNewLine & prompt)
            input = Console.ReadLine()
            If String.IsNullOrWhiteSpace(input) Then
                MsgBox("The input cannot be empty. Please enter a valid value.", MsgBoxStyle.Exclamation, "Wrong input")
            End If
        Loop While String.IsNullOrWhiteSpace(input)
        Return input
    End Function
    Function AskAndValidateIntegerInput(prompt As String) As Integer
        Dim input As String
        Dim number As Integer
        Do
            Console.WriteLine(vbNewLine & prompt)
            input = Console.ReadLine()
            If Not Integer.TryParse(input, number) Then
                MsgBox("The input must be a number.", MsgBoxStyle.Exclamation, "Wrong input")
            End If
        Loop Until Integer.TryParse(input, number)
        Return number
    End Function

    ' FUNCTIONS
    Function AskAndValidPhoneNumberInput(prompt As String) As String
        Dim input As String
        Dim phonePattern As String = "^\d{3}-\d{3}-\d{4}$" ' Regex pattern for phone number
        Do
            Console.WriteLine(vbNewLine & prompt)
            input = Console.ReadLine()
            If Not System.Text.RegularExpressions.Regex.IsMatch(input, phonePattern) Then
                MsgBox("The input must be in the format XXX-XXX-XXXX where X is a number. Please enter a valid phone number.", MsgBoxStyle.Exclamation, "Wrong input")
            End If
        Loop Until System.Text.RegularExpressions.Regex.IsMatch(input, phonePattern)
        Return input
    End Function

End Module

