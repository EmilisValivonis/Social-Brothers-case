Software used:
	Windows 10, 
	Visual studio 2022,
	DB browser for SQLite,

How to run the project

Download project and run SocialBrothersBackEndCase.sln file

	When visual studio 2022 project is loaded press: tools>>NuGet Package Manager>>Package Manager console
 
	In the console write line:
	Update-database
	Hit enter

	Addresses.db file is spawned in C:\Temp folder

Note: if you have different name for your storage drive you have to edit script inside the project  
Models>>Context.cs
 
 
Now we can run the project to fill the database using POST>>execute

We can open addresses.db file in DB browser for SQLite to check the records
 
Part 3 in the addresses.cs end google maps api key should be included
 
I’m proud of:

	Database update method which allows to easily create database from the console without exporting database for project testing

	Created Models working properly

	GET/addresses/:id 
	Seems properly working and returns id from the database with or without error exception

	POST/addresses
	Inserts and saves records into database

	DELETE/addresses/:id
	Properly deletes record by chosen id


I’m less proud of:  

	Part 2: Filters 

However search is working but it could be more implemented. I’m currently employed and didn’t have enough time to implement all parts.

Also some parts could be more implemented like: 

	GET/addresses/ should not be firstordefault() but listed and mapped array and give proper not found
	error exception 

	PUT/addresses/:id could have more updatable fields

Addresses strings should be valid addresses and passed to distance calculation instead of writing distance addresses by hand.


If you feel like this is not enough and you are willing to give me more time I would implement everything as neatly as possible
