Imports Microsoft.VisualBasic.ApplicationServices

Module Main
    'PUBLIC VARIABLES
    Public users(4) As User
    Public userCredentials As String
    Public programIsRunning As Boolean = True
    Public credientialSting As String
    Public userNextId As Integer = 6
    Public movieNextId As Integer = 21
    Public usernameInput As String
    Public passwordInput As String


    'STRUCTURES
    Public Structure User
        Dim id As Integer
        Dim username As String
        Dim password As String
        Dim firstName As String
        Dim lastName As String
        Dim age As Integer
        Dim address As String
        Dim telephoneNumber As String
        Dim statusActiveInactive As Status
        Dim userCredentials As Credentials
    End Structure

    Public Structure CastMember
        Dim actorName As String
        Dim characterName As String
    End Structure

    Public Structure Movie
        Dim id As Integer
        Dim status As MovieStatus
        Dim title As String
        Dim year As Integer
        Dim rate As Decimal
        Dim ageRating As AgeRating
        Dim length As String
        Dim types As List(Of String) ' Use List for multiple types
        Dim yearOfProduction As String
        Dim location As String
        Dim cast As List(Of CastMember) ' Use List for cast members
    End Structure

    ' You can then have a List(Of Movie) to hold all your movies
    Public movies As New List(Of Movie)


    'ENUM
    Public Enum Status
        Active
        Inactive
    End Enum

    Public Enum Credentials
        Admin
        User
    End Enum

    Public Enum MovieStatus
        Publish
        NotPublish
        Deleted
    End Enum

    Public Enum AgeRating
        G
        PG
        PG13
        R
        NC17
    End Enum

    Sub Main()
        Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight)
        ' *****************************************************  MAIN ******************************************************************************
        'Declare instances of 'user' structure
        users(0) = New User With {.id = 1, .username = "LOM", .password = "p", .firstName = "Louis", .lastName = "Major", .age = 38, .address = "50 Main Street, Sainte-Julie, Quebec, Canada", .telephoneNumber = "438-125-2244", .statusActiveInactive = Status.Active, .userCredentials = Credentials.Admin}
        users(1) = New User With {.id = 2, .username = "MAG", .password = "p", .firstName = "Magalie", .lastName = "Rivet", .age = 22, .address = "145 Super Street, Laval, Quebec, Canada", .telephoneNumber = "450-458-7466", .statusActiveInactive = Status.Active, .userCredentials = Credentials.User}
        users(2) = New User With {.id = 3, .username = "VIC", .password = "p", .firstName = "Victor", .lastName = "Proulx", .age = 37, .address = "74 Roverval, Saint-Bruno, Quebec, Canada", .telephoneNumber = "514-874-5624", .statusActiveInactive = Status.Active, .userCredentials = Credentials.User}
        users(3) = New User With {.id = 4, .username = "MIC", .password = "p", .firstName = "Michel", .lastName = "Laforet", .age = 30, .address = "50 Main Street, Sainte-Julie, Quebec, Canada", .telephoneNumber = "438-125-2244", .statusActiveInactive = Status.Active, .userCredentials = Credentials.User}
        users(4) = New User With {.id = 5, .username = "MARIE", .password = "p", .firstName = "Marie", .lastName = "Gagne", .age = 40, .address = "222 Juliette-Beliveau, St-Andre-Avellin, Quebec, Canada", .telephoneNumber = "438-825-7581", .statusActiveInactive = Status.Inactive, .userCredentials = Credentials.User}

        'Declare movies
        Dim godfather As New Movie
        With godfather
            .id = 1
            .status = MovieStatus.Publish
            .title = "The Godfather"
            .year = 1972
            .rate = 9.2D
            .ageRating = AgeRating.R
            .length = "2h 55min"
            .types = New List(Of String) From {"Crime", "Drama"}
            .yearOfProduction = "1972"
            .location = "Canada"
            .cast = New List(Of CastMember) From {
        New CastMember With {.actorName = "Marlon Brando", .characterName = "Don Vito Corleone"},
        New CastMember With {.actorName = "Al Pacino", .characterName = "Michael Corleone"},
        New CastMember With {.actorName = "James Caan", .characterName = "Sonnyl Corleone"},
        New CastMember With {.actorName = "Richard S. Castellano", .characterName = "Clemenza"},
        New CastMember With {.actorName = "Robert Duvall", .characterName = "Tom Hagen"}
    }
        End With
        movies.Add(godfather)

        Dim moonlight As New Movie
        With moonlight
            .id = 2
            .status = MovieStatus.Publish
            .title = "Moonlight"
            .year = 2016
            .rate = 7.4D
            .ageRating = AgeRating.R
            .length = "1h 51min"
            .types = New List(Of String) From {"Drama"}
            .yearOfProduction = "2016"
            .location = "USA"
            .cast = New List(Of CastMember) From {
        New CastMember With {.actorName = "Mahershala Ali", .characterName = "Juan"},
        New CastMember With {.actorName = "Ashton Sanders", .characterName = "Chiron"},
        New CastMember With {.actorName = "Trevante Rhodes", .characterName = "Black"},
        New CastMember With {.actorName = "Naomie Harris", .characterName = "Paula"},
        New CastMember With {.actorName = "Janelle Monáe", .characterName = "Teresa"}
    }
        End With
        movies.Add(moonlight)

        Dim ladyBird As New Movie
        With ladyBird
            .id = 3
            .status = MovieStatus.Publish
            .title = "Lady Bird"
            .year = 2017
            .rate = 7.4D
            .ageRating = AgeRating.R
            .length = "1h 34min"
            .types = New List(Of String) From {"Comedy", "Drama"}
            .yearOfProduction = "2017"
            .location = "USA"
            .cast = New List(Of CastMember) From {
        New CastMember With {.actorName = "Saoirse Ronan", .characterName = "Lady Bird McPherson"},
        New CastMember With {.actorName = "Laurie Metcalf", .characterName = "Marion McPherson"},
        New CastMember With {.actorName = "Tracy Letts", .characterName = "Larry McPherson"},
        New CastMember With {.actorName = "Lucas Hedges", .characterName = "Danny O'Neill"},
        New CastMember With {.actorName = "Timothée Chalamet", .characterName = "Kyle Scheible"}
    }
        End With
        movies.Add(ladyBird)

        Dim theLobster As New Movie
        With theLobster
            .id = 4
            .status = MovieStatus.Publish
            .title = "The Lobster"
            .year = 2015
            .rate = 7.2D
            .ageRating = AgeRating.R
            .length = "1h 59min"
            .types = New List(Of String) From {"Comedy", "Drama", "Romance"}
            .yearOfProduction = "2015"
            .location = "Ireland, UK, Greece, France, Netherlands, USA"
            .cast = New List(Of CastMember) From {
        New CastMember With {.actorName = "Colin Farrell", .characterName = "David"},
        New CastMember With {.actorName = "Rachel Weisz", .characterName = "Short Sighted Woman"},
        New CastMember With {.actorName = "Olivia Colman", .characterName = "Hotel Manager"},
        New CastMember With {.actorName = "Ashley Jensen", .characterName = "Biscuit Woman"},
        New CastMember With {.actorName = "John C. Reilly", .characterName = "Lisping Man"}
    }
        End With
        movies.Add(theLobster)

        Dim boyhood As New Movie
        With boyhood
            .id = 5
            .status = MovieStatus.Publish
            .title = "Boyhood"
            .year = 2014
            .rate = 7.9D
            .ageRating = AgeRating.R
            .length = "2h 45min"
            .types = New List(Of String) From {"Drama"}
            .yearOfProduction = "2014"
            .location = "USA"
            .cast = New List(Of CastMember) From {
        New CastMember With {.actorName = "Ellar Coltrane", .characterName = "Mason"},
        New CastMember With {.actorName = "Patricia Arquette", .characterName = "Olivia"},
        New CastMember With {.actorName = "Ethan Hawke", .characterName = "Mason Sr."},
        New CastMember With {.actorName = "Lorelei Linklater", .characterName = "Samantha"},
        New CastMember With {.actorName = "Libby Villari", .characterName = "Grandma"}
    }
        End With
        movies.Add(boyhood)

        ' Movie 6
        Dim silentEchoes As New Movie
        With silentEchoes
            .id = 6
            .status = MovieStatus.Publish
            .title = "Silent Echoes"
            .year = 2022
            .rate = 7.8D
            .ageRating = AgeRating.PG
            .length = "1h 40min"
            .types = New List(Of String) From {"Mystery", "Drama"}
            .yearOfProduction = "2022"
            .location = "UK"
            .cast = New List(Of CastMember) From {
        New CastMember With {.actorName = "Emily Clarke", .characterName = "Anna Wright"},
        New CastMember With {.actorName = "John Smith", .characterName = "Detective Lars"},
        New CastMember With {.actorName = "Alicia Keys", .characterName = "Mary Lou"},
        New CastMember With {.actorName = "James Earl", .characterName = "Robert King"},
        New CastMember With {.actorName = "Emma Stone", .characterName = "Lucy Sky"}
    }
        End With
        movies.Add(silentEchoes)

        ' Movie 7
        Dim beneathTheSurface As New Movie
        With beneathTheSurface
            .id = 7
            .status = MovieStatus.Publish
            .title = "Beneath The Surface"
            .year = 2021
            .rate = 8D
            .ageRating = AgeRating.PG13
            .length = "1h 50min"
            .types = New List(Of String) From {"Thriller", "Adventure"}
            .yearOfProduction = "2021"
            .location = "Australia"
            .cast = New List(Of CastMember) From {
        New CastMember With {.actorName = "Hugh Jackman", .characterName = "Captain Steve"},
        New CastMember With {.actorName = "Nicole Kidman", .characterName = "Dr. Lisa Reed"},
        New CastMember With {.actorName = "Chris Hemsworth", .characterName = "Max Harlow"},
        New CastMember With {.actorName = "Cate Blanchett", .characterName = "Agent Eliza"},
        New CastMember With {.actorName = "Russell Crowe", .characterName = "The Stranger"}
    }
        End With
        movies.Add(beneathTheSurface)

        ' Movie 8
        Dim whispersOfPast As New Movie
        With whispersOfPast
            .id = 8
            .status = MovieStatus.Publish
            .title = "Whispers Of The Past"
            .year = 2019
            .rate = 7.9D
            .ageRating = AgeRating.R
            .length = "2h 10min"
            .types = New List(Of String) From {"Historical", "Drama"}
            .yearOfProduction = "2019"
            .location = "France"
            .cast = New List(Of CastMember) From {
        New CastMember With {.actorName = "Vincent Cassel", .characterName = "Jean Dupont"},
        New CastMember With {.actorName = "Marion Cotillard", .characterName = "Claire Lacombe"},
        New CastMember With {.actorName = "Léa Seydoux", .characterName = "Marie"},
        New CastMember With {.actorName = "Gaspard Ulliel", .characterName = "Louis"},
        New CastMember With {.actorName = "Audrey Tautou", .characterName = "Sophie"}
    }
        End With
        movies.Add(whispersOfPast)

        ' Movie 9
        Dim timeUnraveled As New Movie
        With timeUnraveled
            .id = 9
            .status = MovieStatus.Publish
            .title = "Time Unraveled"
            .year = 2023
            .rate = 8.5D
            .ageRating = AgeRating.PG13
            .length = "1h 58min"
            .types = New List(Of String) From {"Sci-Fi", "Drama"}
            .yearOfProduction = "2023"
            .location = "USA"
            .cast = New List(Of CastMember) From {
        New CastMember With {.actorName = "Michael B. Jordan", .characterName = "Kyle Benson"},
        New CastMember With {.actorName = "Brie Larson", .characterName = "Sarah Newman"},
        New CastMember With {.actorName = "Samuel L. Jackson", .characterName = "Dr. Miles"},
        New CastMember With {.actorName = "Lupita Nyong'o", .characterName = "Ava"},
        New CastMember With {.actorName = "Chadwick Boseman", .characterName = "James"}
    }
        End With
        movies.Add(timeUnraveled)

        ' Movie 10
        Dim shadowsInTheWoods As New Movie
        With shadowsInTheWoods
            .id = 10
            .status = MovieStatus.Publish
            .title = "Shadows in the Woods"
            .year = 2020
            .rate = 6.8D
            .ageRating = AgeRating.R
            .length = "1h 47min"
            .types = New List(Of String) From {"Horror", "Thriller"}
            .yearOfProduction = "2020"
            .location = "Canada"
            .cast = New List(Of CastMember) From {
        New CastMember With {.actorName = "Ryan Reynolds", .characterName = "Mark"},
        New CastMember With {.actorName = "Rachel McAdams", .characterName = "Elise"},
        New CastMember With {.actorName = "Stephen Amell", .characterName = "Chris"},
        New CastMember With {.actorName = "Sandra Oh", .characterName = "Detective June"},
        New CastMember With {.actorName = "Keanu Reeves", .characterName = "The Hermit"}
    }
        End With
        movies.Add(shadowsInTheWoods)

        ' Movie 11
        Dim whispersInTheDark As New Movie
        With whispersInTheDark
            .id = 11
            .status = MovieStatus.Publish
            .title = "Whispers in the Dark"
            .year = 2022
            .rate = 6.9D
            .ageRating = AgeRating.R
            .length = "1h 33min"
            .types = New List(Of String) From {"Horror", "Thriller"}
            .yearOfProduction = "2022"
            .location = "United States"
            .cast = New List(Of CastMember) From {
        New CastMember With {.actorName = "Eva Green", .characterName = "Dr. Sarah Nightingale"},
        New CastMember With {.actorName = "Daniel Gillies", .characterName = "Officer Paul Reynolds"},
        New CastMember With {.actorName = "Lena Headey", .characterName = "The Whisperer"},
        New CastMember With {.actorName = "James McAvoy", .characterName = "Markus Leech"},
        New CastMember With {.actorName = "Aubrey Plaza", .characterName = "Rebecca"}
    }
        End With
        movies.Add(whispersInTheDark)

        ' Movie 12
        Dim theCabinRetreat As New Movie
        With theCabinRetreat
            .id = 12
            .status = MovieStatus.Publish
            .title = "The Cabin Retreat"
            .year = 2020
            .rate = 7.1D
            .ageRating = AgeRating.R
            .length = "1h 45min"
            .types = New List(Of String) From {"Horror", "Mystery"}
            .yearOfProduction = "2020"
            .location = "Canada"
            .cast = New List(Of CastMember) From {
        New CastMember With {.actorName = "Anya Taylor-Joy", .characterName = "Emily"},
        New CastMember With {.actorName = "Logan Lerman", .characterName = "Nathan"},
        New CastMember With {.actorName = "Jessica Chastain", .characterName = "Karen"},
        New CastMember With {.actorName = "Oscar Isaac", .characterName = "David"},
        New CastMember With {.actorName = "Bill Skarsgård", .characterName = "The Forest Man"}
    }
        End With
        movies.Add(theCabinRetreat)

        ' Movie 13
        Dim beneathTheMoonlight As New Movie
        With beneathTheMoonlight
            .id = 13
            .status = MovieStatus.Publish
            .title = "Beneath the Moonlight"
            .year = 2021
            .rate = 7.5D
            .ageRating = AgeRating.R
            .length = "1h 55min"
            .types = New List(Of String) From {"Horror", "Supernatural"}
            .yearOfProduction = "2021"
            .location = "Ireland"
            .cast = New List(Of CastMember) From {
        New CastMember With {.actorName = "Saoirse Ronan", .characterName = "Aisling"},
        New CastMember With {.actorName = "Cillian Murphy", .characterName = "Father Thomas"},
        New CastMember With {.actorName = "Katie McGrath", .characterName = "Siobhan"},
        New CastMember With {.actorName = "Tom Hiddleston", .characterName = "Dr. Edward Blake"},
        New CastMember With {.actorName = "Niamh Cusack", .characterName = "The Banshee"}
    }
        End With
        movies.Add(beneathTheMoonlight)

        ' Movie 14
        Dim theHauntingOfHillHouse As New Movie
        With theHauntingOfHillHouse
            .id = 14
            .status = MovieStatus.Publish
            .title = "The Haunting of Hill House"
            .year = 2023
            .rate = 8.2D
            .ageRating = AgeRating.R
            .length = "2h 10min"
            .types = New List(Of String) From {"Horror", "Drama", "Mystery"}
            .yearOfProduction = "2023"
            .location = "United Kingdom"
            .cast = New List(Of CastMember) From {
        New CastMember With {.actorName = "Elizabeth Olsen", .characterName = "Eleanor Vance"},
        New CastMember With {.actorName = "Tom Ellis", .characterName = "Dr. John Montague"},
        New CastMember With {.actorName = "Keira Knightley", .characterName = "Theodora"},
        New CastMember With {.actorName = "Jude Law", .characterName = "Luke Sanderson"},
        New CastMember With {.actorName = "Helena Bonham Carter", .characterName = "Mrs. Dudley"}
    }
        End With
        movies.Add(theHauntingOfHillHouse)

        ' Movie 15
        Dim nightmareOnElmStreet As New Movie
        With nightmareOnElmStreet
            .id = 15
            .status = MovieStatus.Publish
            .title = "Nightmare on Elm Street: Reawakening"
            .year = 2024
            .rate = 7D
            .ageRating = AgeRating.R
            .length = "2h"
            .types = New List(Of String) From {"Horror", "Thriller"}
            .yearOfProduction = "2024"
            .location = "United States"
            .cast = New List(Of CastMember) From {
        New CastMember With {.actorName = "Rami Malek", .characterName = "Freddy Krueger"},
        New CastMember With {.actorName = "Zoe Kravitz", .characterName = "Nancy Thompson"},
        New CastMember With {.actorName = "LaKeith Stanfield", .characterName = "Quentin Smith"},
        New CastMember With {.actorName = "Emma Roberts", .characterName = "Kris Fowles"},
        New CastMember With {.actorName = "John Boyega", .characterName = "Jesse Braun"}
    }
        End With
        movies.Add(nightmareOnElmStreet)

        ' Movie 16
        Dim cosmicOdyssey As New Movie
        With cosmicOdyssey
            .id = 16
            .status = MovieStatus.Publish
            .title = "Cosmic Odyssey"
            .year = 2025
            .rate = 8.5D
            .ageRating = AgeRating.PG13
            .length = "2h 30min"
            .types = New List(Of String) From {"Sci-Fi", "Adventure", "Drama"}
            .yearOfProduction = "2025"
            .location = "Outer Space"
            .cast = New List(Of CastMember) From {
        New CastMember With {.actorName = "John David Washington", .characterName = "Commander Leo"},
        New CastMember With {.actorName = "Tilda Swinton", .characterName = "AI H.A.L.D.A."},
        New CastMember With {.actorName = "Robert Pattinson", .characterName = "Dr. Alex Grimes"},
        New CastMember With {.actorName = "Elizabeth Debicki", .characterName = "Engineer Marie"},
        New CastMember With {.actorName = "Gary Oldman", .characterName = "Admiral Kurtz"}
    }
        End With
        movies.Add(cosmicOdyssey)

        ' Movie 17
        Dim shadowsOfTheMind As New Movie
        With shadowsOfTheMind
            .id = 17
            .status = MovieStatus.NotPublish
            .title = "Shadows of the Mind"
            .year = 2023
            .rate = 8.7D
            .ageRating = AgeRating.R
            .length = "2h 20min"
            .types = New List(Of String) From {"Psychological", "Thriller"}
            .yearOfProduction = "2023"
            .location = "United States"
            .cast = New List(Of CastMember) From {
        New CastMember With {.actorName = "Edward Norton", .characterName = "Professor Richard Nolan"},
        New CastMember With {.actorName = "Julianne Moore", .characterName = "Dr. Anna Peterson"},
        New CastMember With {.actorName = "Anthony Hopkins", .characterName = "Dr. Frederick Lang"},
        New CastMember With {.actorName = "Natalie Portman", .characterName = "Lara"},
        New CastMember With {.actorName = "Joaquin Phoenix", .characterName = "Tom"}
    }
        End With
        movies.Add(shadowsOfTheMind)

        ' Movie 18
        Dim echoesFromEternity As New Movie
        With echoesFromEternity
            .id = 18
            .status = MovieStatus.NotPublish
            .title = "Echoes from Eternity"
            .year = 2024
            .rate = 8.9D
            .ageRating = AgeRating.PG13
            .length = "3h"
            .types = New List(Of String) From {"Drama", "Epic"}
            .yearOfProduction = "2024"
            .location = "Europe"
            .cast = New List(Of CastMember) From {
        New CastMember With {.actorName = "Cate Blanchett", .characterName = "Empress Theodora"},
        New CastMember With {.actorName = "Daniel Day-Lewis", .characterName = "Emperor Justinian"},
        New CastMember With {.actorName = "Jude Law", .characterName = "General Belisarius"},
        New CastMember With {.actorName = "Ben Kingsley", .characterName = "Philosopher Proclus"},
        New CastMember With {.actorName = "Marion Cotillard", .characterName = "Antonia"}
    }
        End With
        movies.Add(echoesFromEternity)

        ' Movie 19
        Dim labyrinthOfIllusion As New Movie
        With labyrinthOfIllusion
            .id = 19
            .status = MovieStatus.NotPublish
            .title = "Labyrinth of Illusion"
            .year = 2026
            .rate = 8.3D
            .ageRating = AgeRating.R
            .length = "2h 45min"
            .types = New List(Of String) From {"Mystery", "Drama"}
            .yearOfProduction = "2026"
            .location = "England"
            .cast = New List(Of CastMember) From {
        New CastMember With {.actorName = "Kate Winslet", .characterName = "Lady Elizabeth"},
        New CastMember With {.actorName = "Ralph Fiennes", .characterName = "Lord William"},
        New CastMember With {.actorName = "Jeremy Irons", .characterName = "Sir Charles"},
        New CastMember With {.actorName = "Tom Hardy", .characterName = "Edward"},
        New CastMember With {.actorName = "Rosamund Pike", .characterName = "Margaret"}
    }
        End With
        movies.Add(labyrinthOfIllusion)

        ' Movie 20
        Dim theAgeOfRage As New Movie
        With theAgeOfRage
            .id = 20
            .status = MovieStatus.Deleted
            .title = "The Age of Rage"
            .year = 2027
            .rate = 8.1D
            .ageRating = AgeRating.PG13
            .length = "2h 30min"
            .types = New List(Of String) From {"War", "Drama"}
            .yearOfProduction = "2027"
            .location = "Vietnam"
            .cast = New List(Of CastMember) From {
        New CastMember With {.actorName = "Christian Bale", .characterName = "Captain John Miller"},
        New CastMember With {.actorName = "Iko Uwais", .characterName = "Lieutenant Bao"},
        New CastMember With {.actorName = "Donnie Yen", .characterName = "Commander Liang"},
        New CastMember With {.actorName = "Tom Hanks", .characterName = "General Douglas"},
        New CastMember With {.actorName = "Maggie Q", .characterName = "Journalist Linh"}
    }
        End With
        movies.Add(theAgeOfRage)


        'Main program loop
        Do
            'PASSWORD
            Do
                programIsRunning = True
                Console.Clear()

                'Display Title
                displayTitleLogin()

                'ask username
                Console.WriteLine("Please enter your username")
                usernameInput = Console.ReadLine()

                'ask password
                Console.WriteLine(vbNewLine & "Please enter your password")
                passwordInput = Console.ReadLine()

                'validate username and password
                Dim isvaliduser As Boolean = ValidateUserLogin(usernameInput, passwordInput)
                If Not isvaliduser Then
                    MsgBox("Invalid username or password! (Or INACTIVE user)", MsgBoxStyle.Critical, "Invalid")
                Else
                    ' if the username and password match, exit the loop           
                    Exit Do
                End If
            Loop

            ' Rediret to the Main Menu
            toMainMenu()


        Loop


        Console.ReadKey()
    End Sub



    'SUBS
    Sub displayTitleLogin()
        Console.WriteLine(vbNewLine &
                          "===========================================================================")
        Console.WriteLine("------------->             MOVIE BLOG           <--------------------------")
        Console.WriteLine("------------------------->   LOGIN   <-------------------------------------")
        Console.WriteLine("===========================================================================" & vbNewLine)
    End Sub

    'FUNCTIONS
    Function ValidateUserLogin(username As String, password As String) As Boolean
        For Each individual As User In users
            If individual.username = username AndAlso individual.password = password And individual.statusActiveInactive = Status.Active Then
                Console.Clear()
                Console.WriteLine("LOGIN SUCCESSFUL!" & vbNewLine &
                                  "Welcome, " & individual.firstName & vbNewLine)
                'System.Threading.Thread.Sleep(2000)
                Return True
            End If
        Next
        Return False
    End Function

    Function GetUserCredentials(username As String) As Credentials
        For Each individual As User In users
            If individual.username = username Then
                Return individual.userCredentials
            End If
        Next
        Return -1 'user not found
    End Function






End Module
