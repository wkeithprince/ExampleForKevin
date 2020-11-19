# ExampleForKevin
Simple API project to show how to wire up EF.


Create new Project - shown below


![image](https://user-images.githubusercontent.com/12174036/99689078-84e2af00-2a54-11eb-8607-e4342392292f.png)
![image](https://user-images.githubusercontent.com/12174036/99689304-d3904900-2a54-11eb-83c8-11c67698497c.png)


Add a new project to this solution. This project will be for Data access using Entity Framework. Put .Data on the end of the name. 

Right click on the new Project and select Properties. Change the Output type to be Class Library as shown below. 

![image](https://user-images.githubusercontent.com/12174036/99689794-6a5d0580-2a55-11eb-9259-7ed33d199000.png)

Right click on Dependencies in this same Data project, choose Manage NuGet Packages. Browse and install the three shown below. Choose version 3.1.

![image](https://user-images.githubusercontent.com/12174036/99690102-bf991700-2a55-11eb-9fd7-ebdffd88155b.png)

Back in the main project right click on Dependencies and do the same thing as above but ensure the below are all installed. 

![image](https://user-images.githubusercontent.com/12174036/99690471-33d3ba80-2a56-11eb-918d-020e66d1a620.png)

Go to the appsettings json configuration file and add the ConnectionStrings section as shown below. Make sure your Database name in that connection string matches the Database name of your database.

![image](https://user-images.githubusercontent.com/12174036/99690623-5bc31e00-2a56-11eb-98f1-0f08079c8966.png)

In the Startup.cs file, add the line of code that is underlined in red from below. 

![image](https://user-images.githubusercontent.com/12174036/99690972-b2c8f300-2a56-11eb-9357-6dc103a48929.png)

DB Scaffold - (Reverser Engineer the Db)

Here is the command to run in the command prompt to have EF generate the code based off of the DB scheme so that your code will easily talk to the DB. Where it says Catalog, put the name of your DB there instead of the ExampleKevinDb that I have.

dotnet ef dbcontext scaffold "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ExampleKevinDb" Microsoft.EntityFrameworkCore.SqlServer

You will run this command at the folder location of the Data project as shown below. 

![image](https://user-images.githubusercontent.com/12174036/99691709-82ce1f80-2a57-11eb-98c6-2204e4d93a79.png)

If successful, you should see two new files appear as shown below. Yours will be named whatever you had named your DB and table. 

![image](https://user-images.githubusercontent.com/12174036/99691870-ad1fdd00-2a57-11eb-9980-174b5c24eaba.png)

Right click on the folder named Controllers, select Add and choose Controller. Then select the options shown below. This will generate you a API controller code file in the Controller folder. 

![image](https://user-images.githubusercontent.com/12174036/99692558-70a0b100-2a58-11eb-920a-299c8848807c.png)
![image](https://user-images.githubusercontent.com/12174036/99692788-acd41180-2a58-11eb-9998-53bc856ff170.png)


You should now be able to run the application and navigate to the URL underlined in red and see the results underlined in blue. (Your URL may be named different if you named your controller a different name and your data make look different as your data will be different)

![image](https://user-images.githubusercontent.com/12174036/99692170-ff60fe00-2a57-11eb-8067-140b3242a134.png)

Here is what the Database looks like. Notice that two records of data match the previous screenshot of data. 

![image](https://user-images.githubusercontent.com/12174036/99711023-43abc880-2a6f-11eb-8910-94d25c4067ba.png)
