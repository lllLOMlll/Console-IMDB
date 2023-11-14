Module DisplayUsersSub

    Sub displayAllUsers()
        Dim count As Integer = 1
        Console.Clear()
        Console.WriteLine(vbNewLine & "-------------------------> ALL USERS <---------------------------" & vbNewLine)
        For Each u As User In users
            ' Check if the user has a valid ID before displaying their information.
            If u.id <> 0 Then
                Console.WriteLine("------------- USER #" & count & "-------------")
                Console.WriteLine("Id: " & u.id)
                Console.WriteLine("USERNAME: " & u.username)
                Console.WriteLine("FIRST NAME :" & u.firstName & " | " & "LAST NAME : " & u.lastName)
                Console.WriteLine("AGE: " & u.age)
                Console.WriteLine("ADRESS : " & vbNewLine & u.address)
                Console.WriteLine("TELEPHONE NUMBER: " & u.telephoneNumber)
                Console.WriteLine("STATUS: " & u.statusActiveInactive.ToString & " | " & "CREDENTIALS: " & u.userCredentials.ToString)
                Console.WriteLine()
                count += 1
            End If
        Next
        Console.WriteLine(vbNewLine & "Press any key to continue")
        Console.ReadLine()
    End Sub


    Sub displayActiveUsers()
        Dim count As Integer = 1
        Console.Clear()
        Console.WriteLine(vbNewLine & "-------------------------> ACTIVE USERS <---------------------------" & vbNewLine)

        For Each u As User In users
            If u.id <> 0 Then
                If u.statusActiveInactive = Status.Active Then
                    Console.WriteLine("------------- USER #" & count & "-------------")
                    Console.WriteLine("Id: " & u.id)
                    Console.WriteLine("USERNAME: " & u.username)
                    Console.WriteLine("FIRST NAME :" & u.firstName & " | " & "LAST NAME : " & u.lastName)
                    Console.WriteLine("AGE: " & u.age)
                    Console.WriteLine("ADRESS : " & vbNewLine & u.address)
                    Console.WriteLine("TELEPHONE NUMBER: " & u.telephoneNumber)
                    Console.WriteLine("STATUS: " & u.statusActiveInactive.ToString & " | " & "CREDENTIALS: " & u.userCredentials.ToString)
                    Console.WriteLine()

                    count += 1
                Else
                    'Inactive users
                    'Do nothing
                End If
            End If


        Next
        Console.WriteLine(vbNewLine & "Press any key to continue")
        Console.ReadLine()
    End Sub


    Sub displayInactiveUsers()
        Dim count As Integer = 1
        Console.Clear()
        Console.WriteLine(vbNewLine & "-------------------------> INACTIVE USERS <---------------------------" & vbNewLine)
        For Each u As User In users
            If u.statusActiveInactive = Status.Inactive Then
                Console.WriteLine("------------- USER #" & count & "-------------")
                Console.WriteLine("Id: " & u.id)
                Console.WriteLine("USERNAME: " & u.username)
                Console.WriteLine("FIRST NAME :" & u.firstName & " | " & "LAST NAME : " & u.lastName)
                Console.WriteLine("AGE: " & u.age)
                Console.WriteLine("ADRESS : " & vbNewLine & u.address)
                Console.WriteLine("TELEPHONE NUMBER: " & u.telephoneNumber)
                Console.WriteLine("STATUS: " & u.statusActiveInactive.ToString & " | " & "CREDENTIALS: " & u.userCredentials.ToString)
                Console.WriteLine()

                count += 1
            Else
                'Inactive users
                'Do nothing
            End If

        Next
        Console.WriteLine(vbNewLine & "Press any key to continue")
        Console.ReadLine()
    End Sub
End Module
