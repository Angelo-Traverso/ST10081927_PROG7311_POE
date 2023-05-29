	.....ooooo00000 Project Title 00000ooooo.....

	-	Project Title: Farm Central Web Applicatiomn: A Prototype

	.....ooooo00000 Project Description 00000ooooo.....

	- 	Farm Central is a group of local farmers who have decided to work together to start a brick-and-mortor store.
	- 	This project was aimed to provide them with an easy-to-use and visually appealing web application so that their stock management 			process can be as easy as 1, 2, 3.
	-	By making use of minimal navigation and easy user input, I was able to meet these criteria.

	.....ooooo00000 Technologies Used 00000ooooo.....

	-	Entity Framework (EF): I Made use of EF to act as a 'middle man' between my code and the database. EF made communicating with my 			database extremely easy with a higher level of code instead of using SQL statements. This make code easier to read and easier to 			maintain.
	-	SQL Server-Based Database: I used this as all data stored is relational as each farmer owns certain products and each user has 			specific login credentials. So a relational database made the most sense to make use of.
	-	Languages used:	C#, Javascript, and CSS

	.....ooooo00000 Installation 00000ooooo.....
	Option 1: 
		1: Unzip folder "AngeloTraverso_ST10081927_PROG7311_POE_PART2"
		2: Open folder "ProgPOE"
		3: Double click the visual studio solution "ProgPOE.sln"
		4: This should open Visual Studio with the current project open
		5: None of the files should be by default open, if not, then double click any class to view code
		6: Click the big "play" button at the top of your IDE OR Click "Ctrl + F5" to run the prototype.
	Option 2: 
		1: Unzip folder "AngeloTraverso_ST10081927_PROG7311_POE_PART2"
		2: Open Visual Studio
		3: Choose "Open a project or solution"
		4: Locate folder "ProgPOE" from the unzipped folder
		5: In "ProgPOE" folder, select "ProgPOE.sln" file to launch the code into your IDE
		6: None of the files should be by default open, if not, then double click any class to view code
		7: Click the big "play" button at the top of your IDE OR Click "Ctrl + F5" to run the prototype.

	.....ooooo00000 Usage Guide 00000ooooo.....

		1:	When launching the website, you can login using either a farmers' crednetials or employee, which is provided at the bottom of 			this document.
		Employee:
		1: 	If you log in as an employee, you will be presented with the "ViewProducts" page where you can view all products, and filter 				them according to your desired needs.
		2:	You can click "Reset" to reset all filter criteria, followed by "Filter" to repopulate your gridview.
		3:	You can then navigate to "AddFarmer" where you can add a new farmer to the database.
		4:	there is a progress bar at the top of the page which will show you how far you are to complete all the inputs provided.
		5:	Once you have added a new farmer, you will be presented with a confirmation label at the top of you screen to confirm your 				newly added farmer.
		6:	Pages were kept to a minimal Farm Central requested the website to be easy to use without any effort of looking for certain 				processors.
		7:	Once you are done, you can simply logout of the website using the "logout" button on the top navigation.
		Farmer:
		1: 	If you log in as a farmer, you will be presented with only one page which is "AddProduct".
		2: 	Once you are in "AddProduct" as a farmer, you can add all product information, where you will then be presented with a 					confirmation message at the top of your screen, verifying you have successfully added a new product.
		3:	Once you are done, you can simply logout of the website using the "logout" button on the top navigation.


	.....ooooo00000 File Structure 00000ooooo.....

	-	All files will be found under "Solution Explorer"

	-	Once the code is open in Visual Studio, you will find a folder App_Data which is where you will find the attached local database.
	-	You can find a folder called "Scripts" where you can find all default .css, .js and bootstrap stylings for the website.
	-	You can find a folder called "Styles" where you can find all of my custom added css for all UI's throughout the website.
	-	Below those folders, you will find all UI designs and layouts within all of the .aspx files and all c# code in the .cs files which 			are each nested within the .aspx files

	.....ooooo00000 User Login Credentials 00000ooooo.....
	Farmers:	
		1: username = JJones | password = Jones01
		2: username = Lastra | password = Layla001
		3: username = cBiosh | password = Bosh001
	Employees:
		1: username = atraverso13 | password = seeSharp001
		2: username = pietPompies | password = Programming01

	.....ooooo00000 Github Repo Link 00000ooooo.....

	https://github.com/Angelo-Traverso/ST10081927_PROG7311_POE.git




