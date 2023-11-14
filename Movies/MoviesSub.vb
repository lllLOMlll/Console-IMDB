Module MoviesSub
    Sub AddNewMovieUser()
        Console.Clear()
        Console.WriteLine("-------------------- ADD A NEW MOVIE --------------------")
        ' Create a new instance of the Movie structure.
        Dim newMovie As New Movie

        ' Prompt for details of the new movie.
        newMovie.id = movieNextId
        newMovie.title = GetValidStringInput(vbNewLine & "Enter the movie title:")
        newMovie.year = GetValidYearOfProductionInput(vbNewLine & "Enter the release year of the movie:")
        newMovie.rate = GetValidRatingInput(vbNewLine & "Enter the movie's rating:")
        newMovie.ageRating = GetValidAgeRatingInput(vbNewLine & "Enter the movie's age rating (G, PG, PG13, R, NC17):")
        newMovie.length = GetValidLengthInput(vbNewLine & "Enter the movie's length (e.g., '2h 55min'):")
        newMovie.types = GetValidListOfStringInput(vbNewLine & "Enter the movie's types/genres (separated by commas):")
        newMovie.yearOfProduction = GetValidYearOfProductionInput(vbNewLine & "Enter the year of production:")
        newMovie.location = GetValidStringInput(vbNewLine & "Enter the location:")
        newMovie.cast = GetValidCastListInput(vbNewLine & "Enter the cast members (Format: ActorName - CharacterName, separated by commas):")
        newMovie.status = MovieStatus.NotPublish

        ' Add the new movie to the list of movies.
        movies.Add(newMovie)


        movieNextId = +1

        'Success message
        MsgBox("Movie added successfully. ADMIN will review the new added movie and then publish it.", MsgBoxStyle.Exclamation, "Success!")




    End Sub

    Sub AddNewMovieAdmin()
        Console.Clear()
        Console.WriteLine("-------------------- ADD A NEW MOVIE --------------------")
        ' Create a new instance of the Movie structure.
        Dim newMovie As New Movie

        ' Prompt for details of the new movie.
        newMovie.id = movieNextId
        newMovie.title = GetValidStringInput(vbNewLine & "Enter the movie title:")
        newMovie.year = GetValidYearOfProductionInput(vbNewLine & "Enter the release year of the movie:")
        newMovie.rate = GetValidRatingInput(vbNewLine & "Enter the movie's rating:")
        newMovie.ageRating = GetValidAgeRatingInput(vbNewLine & "Enter the movie's age rating (G, PG, PG13, R, NC17):")
        newMovie.length = GetValidLengthInput(vbNewLine & "Enter the movie's length (e.g., '2h 55min'):")
        newMovie.types = GetValidListOfStringInput(vbNewLine & "Enter the movie's types/genres (separated by commas):")
        newMovie.yearOfProduction = GetValidYearOfProductionInput(vbNewLine & "Enter the year of production:")
        newMovie.location = GetValidStringInput(vbNewLine & "Enter the location:")
        newMovie.cast = GetValidCastListInput(vbNewLine & "Enter the cast members (Format: ActorName - CharacterName, separated by commas):")
        newMovie.status = MovieStatus.Publish

        ' Add the new movie to the list of movies.
        movies.Add(newMovie)

        movieNextId = +1
        'Success message
        MsgBox("Movie added successfully!", MsgBoxStyle.Exclamation, "Success!")

    End Sub
    Sub deleteMovie()
        Console.Clear()
        Console.WriteLine("-------------------- DELETE A MOVIE --------------------")
        displayAllMovies()
        ' Ask the user for the movie ID they wish to delete.
        Dim movieIdToDelete As Integer = AskAndValidateIntegerInput("Enter the ID of the movie you want to delete: ")
        Dim movieFound As Boolean = False


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

        ' Iterate over the list of movies using an index.
        For i As Integer = 0 To movies.Count - 1
            If movies(i).id = movieIdToDelete Then
                ' If the movie is found, change its status to Deleted.
                movies(i) = New Movie With {
                .id = movies(i).id,
                .status = MovieStatus.Deleted,
                .title = movies(i).title,
                .year = movies(i).year,
                .rate = movies(i).rate,
                .ageRating = movies(i).ageRating,
                .length = movies(i).length,
                .types = movies(i).types,
                .yearOfProduction = movies(i).yearOfProduction,
                .location = movies(i).location,
                .cast = movies(i).cast
            }
                movieFound = True
                Exit For
            End If
        Next

        ' Inform the user of the outcome.
        If movieFound Then
            Console.WriteLine(vbNewLine & $"Movie with ID {movieIdToDelete} has been marked as deleted.")
        Else
            Console.WriteLine("No movie found with the given ID.")
        End If

        Console.WriteLine(vbNewLine & "Press any key to continue")
        Console.ReadKey()
    End Sub

    Sub EditMovie()
        Console.Clear()
        Console.WriteLine("-------------------- EDIT A MOVIE --------------------")
        displayAllMovies()
        ' Ask the user for the movie ID they wish to edit.
        Dim movieIdToEdit As Integer = AskAndValidateIntegerInput(vbNewLine & "Enter the ID of the movie you want to edit: ")
        Dim movieIndex As Integer = -1

        ' Find the index of the movie by ID.
        For i As Integer = 0 To movies.Count - 1
            If movies(i).id = movieIdToEdit Then
                movieIndex = i
                Exit For
            End If
        Next

        ' If the movie is found, edit its properties.
        If movieIndex <> -1 Then
            ' Create a copy of the movie to edit
            Dim movieToEdit As Movie = movies(movieIndex)

            ' Edit title
            Dim newTitle As String = GetOptionalStringInput(vbNewLine & "Enter new title or press Enter to skip:")
            If Not String.IsNullOrEmpty(newTitle) Then movieToEdit.title = newTitle

            ' Edit year
            Dim newYear As Integer? = GetOptionalIntegerInput(vbNewLine & "Enter new release year or press Enter to skip:")
            If newYear.HasValue Then movieToEdit.year = newYear.Value

            ' Edit rate
            Dim newRate As Decimal? = GetOptionalDecimalInput(vbNewLine & "Enter new rating or press Enter to skip:")
            If newRate.HasValue Then movieToEdit.rate = newRate.Value

            ' Edit age rating
            Dim newAgeRating As String = GetOptionalStringInput(vbNewLine & "Enter new age rating (G, PG, PG13, R, NC17) or press Enter to skip:")
            If Not String.IsNullOrEmpty(newAgeRating) Then
                Dim parsedRating As AgeRating
                If [Enum].TryParse(newAgeRating, True, parsedRating) Then
                    movieToEdit.ageRating = parsedRating
                End If
            End If

            ' Edit length
            Dim newLength As String = GetOptionalStringInput(vbNewLine & "Enter new length (e.g., '2h 55min') or press Enter to skip:")
            If Not String.IsNullOrEmpty(newLength) Then movieToEdit.length = newLength

            ' Edit types/genres
            Dim newTypes As List(Of String) = GetOptionalListOfStringInput(vbNewLine & "Enter new types/genres separated by commas or press Enter to skip:")
            If newTypes IsNot Nothing AndAlso newTypes.Count > 0 Then movieToEdit.types = newTypes

            ' Edit year of production
            Dim newYearOfProduction As Integer? = GetOptionalIntegerInput(vbNewLine & "Enter new year of production or press Enter to skip:")
            If newYearOfProduction.HasValue Then movieToEdit.yearOfProduction = newYearOfProduction.ToString()

            ' Edit location
            Dim newLocation As String = GetOptionalStringInput(vbNewLine & "Enter new location or press Enter to skip:")
            If Not String.IsNullOrEmpty(newLocation) Then movieToEdit.location = newLocation

            ' Edit cast
            For castNumber As Integer = 1 To Math.Min(5, movieToEdit.cast.Count)
                Dim updatedCastMember As CastMember = GetOptionalCastMemberInput(castNumber, movieToEdit.cast(castNumber - 1))
                movieToEdit.cast(castNumber - 1) = updatedCastMember
            Next

            ' Update the movie in the list
            movies(movieIndex) = movieToEdit

            MsgBox($"Movie with ID {movieIdToEdit} ({movieToEdit.title}) has been updated", MsgBoxStyle.Exclamation, "Edit")
        Else
            MsgBox("No movie found with the given ID.", MsgBoxStyle.Exclamation, "Not found")
        End If
    End Sub


    Sub PublishUnpublishMovie()
        Console.Clear()
        Console.WriteLine("-------------------- PUBLISH/UNPUBLISH A MOVIE --------------------")
        displayAllMovies()
        ' Ask the user for the movie ID they wish to publish/unpublish.
        Dim movieIdToPublishUnpublish As Integer = AskAndValidateIntegerInput("Enter the ID of the movie you want to publish/unpublish: ")
        Dim movieFound As Boolean = False

        ' Iterate over the movies to find the one with the matching ID.
        For i As Integer = 0 To movies.Count - 1
            If movies(i).id = movieIdToPublishUnpublish Then
                ' Found the movie, now make a copy of it.
                Dim updatedMovie As Movie = movies(i)

                ' Toggle the status of the movie.
                If updatedMovie.status = MovieStatus.Publish Then
                    updatedMovie.status = MovieStatus.NotPublish
                ElseIf updatedMovie.status = MovieStatus.NotPublish Then
                    updatedMovie.status = MovieStatus.Publish
                End If

                ' Place the updated movie back into the list.
                movies(i) = updatedMovie

                ' Indicate that the movie was found and updated.
                movieFound = True
                MsgBox($"Movie with ID {movieIdToPublishUnpublish} has been updated to {updatedMovie.status}.", MsgBoxStyle.Exclamation, "Publish/Unpublish")
                Exit For
            End If
        Next

        ' Inform the user if the movie was not found.
        If Not movieFound Then
            MsgBox("No movie found with the given ID.", MsgBoxStyle.Exclamation, "Not found")
        End If
    End Sub




    ' FUNCTIONS
    Private Function GetValidStringInput(prompt As String) As String
        Dim input As String
        Do
            Console.WriteLine(prompt)
            input = Console.ReadLine()
            If String.IsNullOrWhiteSpace(input) Then
                Console.WriteLine("Input cannot be empty. Please enter a valid value.")
            End If
        Loop While String.IsNullOrWhiteSpace(input)
        Return input
    End Function

    ' Function to validate integer input
    Private Function GetValidIntegerInput(prompt As String) As Integer
        Dim input As String
        Dim number As Integer
        Do
            Console.WriteLine(prompt)
            input = Console.ReadLine()
            If Not Integer.TryParse(input, number) Then
                Console.WriteLine("Input must be a whole number. Please enter a valid number.")
            End If
        Loop Until Integer.TryParse(input, number)
        Return number
    End Function

    ' Function to validate decimal input
    Private Function GetValidRatingInput(prompt As String) As Decimal
        Dim input As String
        Dim number As Decimal
        Do
            Console.WriteLine(prompt)
            input = Console.ReadLine()
            If Decimal.TryParse(input, number) AndAlso number >= 0 AndAlso number <= 10 Then
                Exit Do
            Else
                Console.WriteLine("Rating must be a number between 0 and 10. Please enter a valid rating.")
            End If
        Loop
        Return number
    End Function

    ' Function to validate AgeRating input
    Private Function GetValidAgeRatingInput(prompt As String) As AgeRating
        Dim input As String
        Dim rating As AgeRating
        Do
            Console.WriteLine(prompt)
            input = Console.ReadLine()
            If [Enum].TryParse(Of AgeRating)(input, True, rating) AndAlso [Enum].IsDefined(GetType(AgeRating), rating) Then
                Exit Do
            Else
                Console.WriteLine("Invalid age rating. Please enter one of the following: G, PG, PG13, R, NC17.")
            End If
        Loop
        Return rating
    End Function

    ' Function to validate list of strings (genres) input
    Private Function GetValidListOfStringInput(prompt As String) As List(Of String)
        Dim input As String
        Dim list As New List(Of String)
        Do
            Console.WriteLine(prompt)
            input = Console.ReadLine()
            If Not String.IsNullOrWhiteSpace(input) Then
                list = input.Split(","c).Select(Function(s) s.Trim()).ToList()
                If list.Count > 0 Then Exit Do
            End If
            Console.WriteLine("Input cannot be empty. Please enter a list of genres separated by commas.")
        Loop
        Return list
    End Function

    Private Function GetValidLengthInput(prompt As String) As String
        Dim input As String
        Do
            Console.WriteLine(prompt)
            input = Console.ReadLine()
            Dim regex As New Text.RegularExpressions.Regex("^\d{1,2}h \d{1,2}min$")
            If regex.IsMatch(input) Then
                Exit Do
            Else
                Console.WriteLine("Length must be in the format 'Xh Ymin'. Please enter a valid length.")
            End If
        Loop
        Return input
    End Function

    Private Function GetValidYearOfProductionInput(prompt As String) As Integer
        Dim input As String
        Dim number As Integer
        Do
            Console.WriteLine(prompt)
            input = Console.ReadLine()
            If Integer.TryParse(input, number) AndAlso number >= 1890 AndAlso number <= 2024 Then
                Exit Do
            Else
                Console.WriteLine("Year of production must be between 1890 and 2024. Please enter a valid year.")
            End If
        Loop
        Return number
    End Function

    ' Function to validate list of CastMembers input
    Private Function GetValidCastListInput(prompt As String) As List(Of CastMember)
        Dim castList As New List(Of CastMember)
        Dim castCount As Integer = 1
        While castList.Count < 5
            Console.WriteLine(vbNewLine & $"Enter Cast #{castCount} (in the format 'ActorName - CharacterName'):")
            Dim input = Console.ReadLine()
            Dim parts = input.Split("-"c).Select(Function(s) s.Trim()).ToArray()
            If parts.Length = 2 Then
                ' Add a new CastMember to the list.
                castList.Add(New CastMember With {.actorName = parts(0), .characterName = parts(1)})
                castCount += 1
            Else
                ' If the entry does not match the expected format, inform the user and prompt again.
                Console.WriteLine("Invalid format. Each cast member must be in the format 'ActorName - CharacterName'. Please try again.")
            End If
        End While
        Return castList
    End Function

    Private Function AskAndValidateIntegerInput(prompt As String) As Integer
        Dim input As String
        Dim number As Integer
        Do
            Console.WriteLine(prompt)
            input = Console.ReadLine()
            If Integer.TryParse(input, number) Then
                Return number
            Else
                Console.WriteLine("Input must be a whole number. Please enter a valid number.")
            End If
        Loop
    End Function
    ' Function to get an optional string input
    Private Function GetOptionalStringInput(prompt As String) As String
        Console.WriteLine(prompt)
        Dim input As String = Console.ReadLine()
        ' If the user just presses Enter, the function will return Nothing.
        Return If(String.IsNullOrWhiteSpace(input), Nothing, input)
    End Function

    ' Function to get an optional integer input
    Private Function GetOptionalIntegerInput(prompt As String) As Integer?
        Console.WriteLine(prompt)
        Dim input As String = Console.ReadLine()
        If String.IsNullOrWhiteSpace(input) Then Return Nothing
        Dim number As Integer
        If Integer.TryParse(input, number) Then
            Return number
        Else
            Console.WriteLine("Input must be a whole number. Please enter a valid number.")
            Return Nothing
        End If
    End Function

    ' Function to get an optional decimal input
    Private Function GetOptionalDecimalInput(prompt As String) As Decimal?
        Console.WriteLine(prompt)
        Dim input As String = Console.ReadLine()
        If String.IsNullOrWhiteSpace(input) Then Return Nothing
        Dim number As Decimal
        If Decimal.TryParse(input, number) AndAlso number >= 0 AndAlso number <= 10 Then
            Return number
        Else
            Console.WriteLine("Rating must be a number between 0 and 10. Please enter a valid rating.")
            Return Nothing
        End If
    End Function

    ' Function to get an optional list of strings input
    Private Function GetOptionalListOfStringInput(prompt As String) As List(Of String)
        Console.WriteLine(prompt)
        Dim input As String = Console.ReadLine()
        If String.IsNullOrWhiteSpace(input) Then Return Nothing
        Return input.Split(","c).Select(Function(s) s.Trim()).ToList()
    End Function

    ' Function to get an optional list of CastMembers input
    Private Function GetOptionalCastMemberInput(castNumber As Integer, existingCastMember As CastMember) As CastMember
        Console.WriteLine($"Do you want to update cast #{castNumber}? Current Actor: {existingCastMember.actorName}, Character: {existingCastMember.characterName}. (Enter to keep the same or 'ActorName - CharacterName' to update):")
        Dim input As String = Console.ReadLine()
        If String.IsNullOrWhiteSpace(input) Then Return existingCastMember ' No change if input is empty

        Dim parts = input.Split("-"c).Select(Function(s) s.Trim()).ToArray()
        If parts.Length = 2 Then
            ' Return updated CastMember
            Return New CastMember With {.actorName = parts(0), .characterName = parts(1)}
        Else
            Console.WriteLine("Invalid format. Each cast member must be in the format 'ActorName - CharacterName'. Please try again.")
            Return existingCastMember ' No change if format is incorrect
        End If
    End Function

    Function ValidatePassword(password As String) As Boolean
        For Each individual As User In users
            If individual.password = password Then
                Return True
            End If
        Next
        Return False
    End Function

End Module
