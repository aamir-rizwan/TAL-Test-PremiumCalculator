# TAL-Test-PremiumCalculator
TAL Coding Test PremiumCalculator

This Coding Test has two Parts

1- API (Developed in .net Core 8.0, C#)
2- Fond end UI (Developed in angular)

After cloning project from GitHUb, Please open API solution in VS 2022 and UI Project in VS Code

3- In VS Code run npm install to install npm Packages, use npm serve to run the application
4- in API Solution, Rebuild the solution, if needed restore NUGet Packages, after successfull compile, run API project

5- Just one small change is required in UI Project, in CalculatePremiumService.TS there is a variable  
    public BaseUrl = 'https://localhost:7084/api'; 
   This is local host host and port on which API project is running on my machine, if its different at tester machine, please change port accordingly, rest of the URL will stay same

6- Application has "Calculate Premium"  to open the link, plz enter some input to check the results, Please note due to shortage of time, Inputs are not thoughly tested against different Inputs, hence
   it may break against invalid inputs
 
