# BadBoys

<br />
<p align="center">
  <h3 align="center">BadBoysAPI</h3>
  <h3 align="center">An API for a Law Enforcement Agency (LEA)</h3>
    <p align="center">
<img src=https://cloudsmallbusinessservice.com/wp-content/uploads/2017/02/Best-Law-Enforcement-Software.png">
  <p align="center">
    <a href="https://www.youtube.com/watch?v=BUjUz_QEh48" target="blank"> Inspiartion comes in many forms </a>
    <br />
  </p>
</p>
<p align="center">
This App was designed with the goal that it would be useful for a local Law Enforcement Agency’s (LEA) tracking and locating field work. This app contains four key data layers, a user (officer) class, case class, suspect class and crime class. Case Class is able to be built with individual elements from officer, crime, suspect and the individual properties within each class. 
<br><br>
To run this application:
<br>
You will need a copy of Visual Studio 2019 as well as Postman to utilize the API's endpoints easily.
<br>
<p align="center">
•	Link to VSC:<a href="https://visualstudio.microsoft.com/downloads/" target="blank"> Click here </a>
<br>
<br>
•	Link to Postman:<a href="https://www.postman.com/downloads/" target="blank"> Click here </a>
</p>
<p align="center">
Clone the software from the master branch
Begin with creating the user (officer). You will need to set Postman to the local host address /api/Account/Register and input Email, Password, and Confirm Password to get a token. Once you have a token be sure to set postman authorization type to bearer token and set the value to your token. Once that is complete you will be able to add an Office with FullName (string) and RankOfOfficer (enum). Please note that for officer rank, it is set to an Enum of Technician (1), Officer, Detective, Corporal, Sergeant, Lieutenant, Captain, DeputyChief, and Chief. 
<br><br>
When adding a crime to the Crime Class you will need to set the postman web address to post at local host address /api/Crime and add CrimeId (int), CrimeDescription (string), Penalty (string), and CrimeType (enum). Please note that the crimes have been set to an Enum of Theft (1), DrugPossession, JayWalking, Homicide, and Treason. As these are the only crimes that this LEA will be focusing on. Jay walking is a bigger problem than you would think.  
<p align="center">
When adding a suspect to the Suspect class you will need to set the postman web address to post at local host address /api/Suspect and need Name (string), Height (string), Weight (int), PriorConviction (bool) and DateBooked (date) please note that if you include characters after the height (e.g. 6’1” the ” character comes across JSON as a special character and will display a ‘\’ character. Json displaying the ‘\’ does not show up in the SQL data table. 
<p align="center">
Once you have completed the above instructions you will be able to compile addition cases in post man with the web address set to post at local host /api/Case. you will need to add DateOfIncident (date) SuspectiD (int) that is auto assigned from the suspect class, CrimeId (int) that is auto assigned from the crime class, and BadgeId (int) that is auto assigned from the Officer class. Once completed you will be able to set Postman to the get method and see all the finer details of the case.</p>
