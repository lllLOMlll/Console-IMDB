Module MainMenuSub

    Sub toMainMenu()
        Do While programIsRunning
            Console.Clear()
            'Display Title
            displayTitle()

            'Usercredentiel
            assertUserCredentialsAndDisplayAppropriateMenu()

            'AskAndValidateChoice
            Dim userChoice As Integer = AskAndValidateChoice(vbNewLine & "Please select an option from the menu:")
            Console.Clear()

            'Take the userChoice and put it in the right Select Case (Admin or User)   
            RedirectToTheRighSelectCase(userChoice)

        Loop


    End Sub

    'SUBS
    Sub displayTitle()
        Console.WriteLine(vbNewLine &
                          "=============================================================================")
        Console.WriteLine("---------------->          MOVIE BLOG          <-----------------------------")
        Console.WriteLine("=============================================================================" & vbNewLine)
    End Sub
    Sub displayAdminMenu()
        Console.WriteLine("------------------")
        Console.WriteLine("|   ADMIN MENU   |")
        Console.WriteLine("------------------")
        Console.WriteLine("MOVIES")
        Console.WriteLine("1.   View all movies")
        Console.WriteLine(" 11.  View published movies")
        Console.WriteLine(" 12.  View unpublished movies")
        Console.WriteLine("2.   Add movie")
        Console.WriteLine("3.   Edit movie")
        Console.WriteLine(" 31.  Publish/Unpublish movies")
        Console.WriteLine("4.   Delete movie")
        Console.WriteLine(vbNewLine &
                          "ADMIN")
        Console.WriteLine("5.   Display all users")
        Console.WriteLine(" 51.  Display active users")
        Console.WriteLine(" 52.  Display inactive users")
        Console.WriteLine("6.   Add new user")
        Console.WriteLine("7.   Edit user")
        Console.WriteLine(" 71.  Activate/Desactivate user")
        Console.WriteLine(" 72.  Give/Remove admin privileges")
        Console.WriteLine("8.   Delete account")
        Console.WriteLine(vbNewLine &
                          "EXIT")
        Console.WriteLine("9.   Exit program")


    End Sub

    Sub displayUserMenu()
        Console.WriteLine("------------------")
        Console.WriteLine("|   USER MENU   |")
        Console.WriteLine("------------------")
        Console.WriteLine("MOVIES")
        Console.WriteLine("1. View movies")
        Console.WriteLine("2. Add movie")
        Console.WriteLine(vbNewLine &
                          "ACCOUNT")
        Console.WriteLine("3. Edit account")
        Console.WriteLine("4. Delete account")
        Console.WriteLine(vbNewLine &
                          "EXIT")
        Console.WriteLine("5. Exit program")
    End Sub


    Sub assertUserCredentialsAndDisplayAppropriateMenu()
        Dim userCredentials As String = GetUserCredentials(usernameInput)
        If userCredentials = 0 Then
            displayAdminMenu()
        ElseIf userCredentials = 1 Then
            displayUserMenu()
        Else
            MsgBox("Wrong Credentials. Contact Admin", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    'FUNCTIONS
    Function AskAndValidateChoice(prompt As String) As Integer
        Dim userInput As String
        Dim userChoice As Integer

        While True
            Console.WriteLine(prompt)
            userInput = Console.ReadLine()

            If Integer.TryParse(userInput, userChoice) AndAlso userChoice > 0 Then
                Exit While
            Else
                Console.WriteLine("Invalid Input. Please enter a valid positive integer!")
                Console.Clear()
                displayTitle()
                assertUserCredentialsAndDisplayAppropriateMenu()
            End If
        End While

        Return userChoice
    End Function


    Sub RedirectToTheRighSelectCase(userChoice As Integer)
        Dim userCredentials As String = GetUserCredentials(usernameInput)
        ' 0 = ADMIN
        If userCredentials = 0 Then
            Select Case userChoice
                Case 1 'View all movies                
                    displayAllMovies()
                Case 11 'View published movies                 
                    displayPublishedMovies()
                Case 12 'View unpublished               
                    displayUnpublishedMovies()
                Case 2 'Add                   
                    AddNewMovieAdmin()
                Case 3 'Edit
                    EditMovie()
                Case 31 'Publish/Unpublish
                    publishUnpublishMovie()
                Case 4 'Delete
                    deleteMovie()
                Case 5 'Display All Users                   
                    displayAllUsers()
                Case 51 'Display Active Users                 
                    displayActiveUsers()
                Case 52 'Display Inactive Users                 
                    displayInactiveUsers()
                Case 6 'Add New User
                    AddNewUser()
                Case 7 'Edit User
                    editUserAdmin()
                Case 71 'Activate/Desactivate user status
                    ChangeUserStatus()
                Case 72
                    changeUserCredentials()
                Case 8 'Delete User
                    deleteUserAdmin()
                Case 9 'Exit
                    exitProgram()
                Case Else
                    MsgBox("Invalid Input! Please select a valid option.", MsgBoxStyle.Exclamation, "Input Error")
                    Console.Clear()
            End Select

            ' 1 = USER
        ElseIf userCredentials = 1 Then

            Select Case userChoice
                Case 1 'View all movies                     
                    displayPublishedMovies()
                Case 2 'Add
                    AddNewMovieUser()
                Case 3 'Edit
                    editUser()
                Case 4 'Delete
                    deleteUser()
                Case 5 'Exit
                    exitProgram()
                Case Else
                    MsgBox("Invalid Input! Please select a valid option.", MsgBoxStyle.Exclamation, "Input Error")
                    Console.Clear()
            End Select
        End If
    End Sub


End Module
