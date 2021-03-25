# Introduction 
This project has dependency of dotnet core 3.1, Selenium 3.141, Specflow 3.5.5

# Project details
1. Features realted to 
2. Step definitions : has all steps implementation
3. Hooks folder has Chrome driver information
4. Pages has interface and Mobile and Desktop classes just incase in future if we wanted to extend this for Mobile, changee the Driver information and bind the Mobile Page classes based on the platform 


# Configuration 
Under the settings folder Configuration Json

{
  "TestConfiguration": {
    "Environment": "http://automationpractice.com/index.php",
    "Target": "Chrome",
    "Platform": "Desktop"
  }
}

