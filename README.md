# SelfCheckoutMachine Web API
## 1. Clone
Clone project to the destination folder with this command: `git clone https://github.com/MateVargaHenn/SelfCheckoutMachine.git`
## 2. Database
There are 2 types to install Database:
  - Docker
    1. To Install via docker, if you have a docker containerize app, just set the docker-compose as a startup project by right-click on the docker-compose.
    2. Right click on the docker-compose select Compose Up option. the docker-compose.yaml will run automatically.
    3. If docker install is finshed, Open the database via MSSQL Management Studio, or Azure Studio.
    4. You can find the connection strings in the appsettings.json (Data Source=localhost,1433;Initial Catalog=selfcheckoutmachine;User ID=sa;Password=Passw0rd;Encrypt=False;Trust Server Certificate=True")
    5. To create a database, you can find the Sql script in the Sql.Files folder inside of project. Run this script.
    6. Set the SelfCheckoutMachine.WebApi as startup project.
    7. Open a Package Manager Console in Visual Studio. On the top of console, change the Default project to SelfCheckoutMachine.Infrastructure
    8. Type `Update-Database`, and press enter. The generated migration will be running.
  - Https
    1. You can find the connection strings in the appsettings.json (Data Source=localhost,1433;Initial Catalog=selfcheckoutmachine;User ID=sa;Password=Passw0rd;Encrypt=False;Trust Server Certificate=True") Modify it to the localhost connection string, if you would like to run it via Https, but the Initial Catalog has to be `selcheckoutmachine`.
    2. To create a database, you can find the Sql script in the Sql.Files folder inside of project. Run this script.
    3. Set the SelfCheckoutMachine.WebApi as startup project.
    4. Open a Package Manager Console in Visual Studio. On the top of console, change the Default project to SelfCheckoutMachine.Infrastructure
    5. Type `Update-Database`, and press enter. The generated migration will be running.
## 3. Run application
If you chose docker installation, set the docker-compose as start up project, and run it.
If you chose local installation, set the SelfCheckoutMachine.WebApi as startup project, and run it
