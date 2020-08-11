# BadBoys

<br />
<p align="center">
  <h3 align="center">BadBoysAPI</h3>
  <h3 align="center">An API for a Law Enforcement Agency (LEA)</h3>
    <p align="center">
<img src=https://cloudsmallbusinessservice.com/wp-content/uploads/2017/02/Best-Law-Enforcement-Software.png">
  <p align="center">
    <a href="https://www.youtube.com/watch?v=BUjUz_QEh48" target="_blank"> Inspiration comes in many forms</a>
    <br />
  </p>
</p>
<p align="center">
This App was designed with the goal that it would be useful for a local Law Enforcement Agency’s (LEA) tracking and locating field work. This app contains four key data layers, a user (officer) class, case class, suspect class and crime class. Case Class is able to be built with individual elements from officer, crime, suspect and the individual properties within each class. 
<br><br>
To run this application:
<br>
You will need to install Microsoft Visual Studio 2019 and Postman to utilize the API's endpoints easily.
<br>
<p align="center">
•	Link to <a href="https://visualstudio.microsoft.com/downloads/" target="_blank">VSC</a>
<br>
<br>
•	Link to <a href="https://www.postman.com/downloads/" target="_blank">Postman</a>
</p>
<p align="center">
Clone the software from the master branch
Begin with creating a login account in order to properly authenticate with the software. You will need to set Postman to the local host address /api/Account/Register and input Email, Password, and Confirm Password to get a token. Once you have a token be sure to set Postman authorization type to bearer token and set the value to your token. Once that is complete, you will be able to create your Officer with FullName (string) and RankOfOfficer (enum). Please note that for officer rank, it is set to an Enum with corresponding values of: Technician (1), Officer, Detective, Corporal, Sergeant, Lieutenant, Captain, DeputyChief, and Chief. 
                 <br>
                 <br>
We have loaded the API with premade suspects and crimes. You will need a unique log in to be able to see the premade values. Once you're logged in as an officer you will be able to create, edit, read, and delete cases, crimes, and suspects. 
<br><br>
When adding an additional crime to the Crime class, you will need to set the Postman web address to post at local host address /api/Crime and add the following parameters: CrimeId (int), CrimeDescription (string), Penalty (string), and CrimeType (enum). Please note that the CrimeTypes have been set to an Enum with corresponding values of: Theft (1), DrugPossession, JayWalking, Homicide, and Treason - as these are the only crimes that this LEA will be focusing on. Jay walking is a bigger problem than you would think!  
<p align="center">
When adding an additional suspect to the Suspect class you, will need to set the Postman web address to post at local host address /api/Suspect and add the following paramaters: Name (string), Height (string), Weight (int), PriorConviction (bool) and DateBooked (date). Please note that by inputting a double quotation character in your Height string (e.g. 6’1” the ” character is reserved in JSON and will display a ‘\’ character. The '\' character will not be reflected in the actual SQL data table for Suspect Height. 
<p align="center">
Once you have completed the above instructions, you will be able to compile addition cases in Postman with the web address set to post at local host /api/Case. You will need to add DateOfIncident (datetime) SuspectId (int) that is auto assigned from the suspect class, CrimeId (int) that is auto assigned from the crime class, and BadgeId (int) that is auto assigned from the Officer class. Once completed you will be able to set Postman to the get method and see all the finer details of the case.</p>
                 <p align="center">
Many thanks to the following resources for helping us complete these project:<br>
https://www.dofactory.com/net/decorator-design-pattern<br>
https://www.c-sharpcorner.com/article/how-guid-is-generated/<br>
https://www.codeproject.com/Questions/5273526/Csharp-cannot-convert-from-0-to-1-error?PageFlow=Fluid<br>
https://exceptionnotfound.net/serializing-enumerations-in-asp-net-web-api/<br>
https://stackoverflow.com/questions/13556243/entity-framework-5-multiple-identity-columns-specified-for-table-only-one-ident<br>
https://stackoverflow.com/questions/36998570/asp-net-web-api-2-double-backslash-in-string-after-serialization<br>
https://docs.microsoft.com/en-us/ef/ef6/fundamentals/relationships<br>
https://stackoverflow.com/questions/41285555/web-api-net-action-with-custom-endpoint-names<br>
https://entityframework.net/knowledge-base/44747032/no-context-type-was-found-in-the-assembly-when-running-code-first-migration<br>
https://docs.microsoft.com/en-us/aspnet/web-api/overview/data/using-web-api-with-entity-framework/part-3<br>
https://docs.microsoft.com/en-us/cpp/c-language/escape-sequences?view=vs-2019<br>
                                  </p>

