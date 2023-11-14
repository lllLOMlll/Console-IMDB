Module DisplayMoviesSub
    Sub displayAllMovies()
        Console.Clear()
        Console.WriteLine(vbNewLine & "-------------------------> ALL MOVIES <---------------------------" & vbNewLine)
        For Each m As Movie In movies
            If m.status <> MovieStatus.Deleted Then
                ' Title and year

                Console.WriteLine("---------- " & m.title.ToUpper & " ---------- ")
                Console.WriteLine("           (ID: " & m.id & ")")
                Console.WriteLine("           Status: " & m.status.ToString)
                Console.WriteLine("• " & m.title & " (" & m.year.ToString() & ") Rate " & m.rate.ToString("0.0") & "/10")

                ' Age rating (using Enum's ToString method), length, type, year of production, and location
                Console.WriteLine("• " & m.ageRating.ToString() & " | " & m.length & " | " & String.Join(", ", m.types) & " | " & m.yearOfProduction & " (" & m.location & ")")

                ' Cast (Top 5)
                Console.WriteLine("• Cast (Top 5)")
                For i As Integer = 0 To Math.Min(m.cast.Count, 5) - 1
                    Console.WriteLine(" " & (i + 1).ToString() & ". " & m.cast(i).actorName & " as " & m.cast(i).characterName)
                Next
                Console.WriteLine()
            End If
        Next
        Console.WriteLine(vbNewLine & "Press any key to continue")
        Console.ReadLine()
        Console.Clear()
    End Sub

    Sub displayPublishedMovies()
        Console.Clear()
        Console.WriteLine(vbNewLine & "-------------------------> PUBLISHED MOVIES <---------------------------" & vbNewLine)
        For Each m As Movie In movies
            If m.status = MovieStatus.Publish Then
                ' Title and year
                Console.WriteLine("---------- " & m.title.ToUpper & " ---------- ")
                Console.WriteLine("           (ID: " & m.id & ")")
                Console.WriteLine("           Status: " & m.status.ToString)
                Console.WriteLine("• " & m.title & " (" & m.year.ToString() & ") Rate " & m.rate.ToString("0.0") & "/10")

                ' Age rating (using Enum's ToString method), length, type, year of production, and location
                Console.WriteLine("• " & m.ageRating.ToString() & " | " & m.length & " | " & String.Join(", ", m.types) & " | " & m.yearOfProduction & " (" & m.location & ")")

                ' Cast (Top 5)
                Console.WriteLine("• Cast (Top 5)")
                For i As Integer = 0 To Math.Min(m.cast.Count, 5) - 1
                    Console.WriteLine((i + 1).ToString() & ". " & m.cast(i).actorName & " as " & m.cast(i).characterName)
                Next
                Console.WriteLine()
            Else
                'Status = 1 
                'Do nothing. Dont display
            End If
        Next
        Console.WriteLine(vbNewLine & "Press any key to continue")
        Console.ReadLine()
        Console.Clear()
    End Sub

    Sub displayUnpublishedMovies()
        Console.Clear()
        Console.WriteLine(vbNewLine & "-------------------------> UNPUBLISHED MOVIES <---------------------------" & vbNewLine)
        For Each m As Movie In movies
            If m.status = MovieStatus.NotPublish Then
                ' Title and year
                Console.WriteLine("---------- " & m.title.ToUpper & " ---------- ")
                Console.WriteLine("           (ID: " & m.id & ")")
                Console.WriteLine("           Status: " & m.status.ToString)
                Console.WriteLine("• " & m.title & " (" & m.year.ToString() & ") Rate " & m.rate.ToString("0.0") & "/10")

                ' Age rating (using Enum's ToString method), length, type, year of production, and location
                Console.WriteLine("• " & m.ageRating.ToString() & " | " & m.length & " | " & String.Join(", ", m.types) & " | " & m.yearOfProduction & " (" & m.location & ")")

                ' Cast (Top 5)
                Console.WriteLine("• Cast (Top 5)")
                For i As Integer = 0 To Math.Min(m.cast.Count, 5) - 1
                    Console.WriteLine((i + 1).ToString() & ". " & m.cast(i).actorName & " as " & m.cast(i).characterName)
                Next
                Console.WriteLine()
            Else
                'Status = 1 
                'Do nothing. Dont display
            End If
        Next
        Console.WriteLine(vbNewLine & "Press any key to continue")
        Console.ReadLine()
        Console.Clear()
    End Sub

End Module
