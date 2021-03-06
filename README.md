# REGISTONE API 

## What is the Registone Project?

The Registone Log Center is a project written in .NET Core. 
This project was carried out based on the lessons learned from Codenation's AceleraDev C# course in partnership with Stone.

### Technologies Used

- C#
- .Net Core
- XUnit
- SQL Server
- Swagger
- Docker
- Heroku

### Cloning the repository:
https://github.com/Leandrorferreira/Codenation.LogCenter.git
  
### Documentação API:
https://registone-api.herokuapp.com/swagger/index.html

### Endpoints

Endpoint                 | HTTP Verb | Description | HTTP Status Code
------------------------ | --------- | ----------- | ----------------
https://registone-api.herokuapp.com/api/account/register | POST | this endpoint receives an email and password to register the user | 201 Created, 422 Client Error
https://registone-api.herokuapp.com/api/account/login | POST | This endpoint receives an email and password and logs in | 200 Success, 404 Not Found
https://registone-api.herokuapp.com/api/log | GET | This endpoint should only return records that have not been archived | 200 Success, 401 Unauthorized, 404 Not Found
https://registone-api.herokuapp.com/api/log | POST | This endpoint receives the log data to register in the database |  200 Success, 401 Unauthorized, 422 Client Error
https://registone-api.herokuapp.com/api/log/fileds | GET | This terminal returns only archived records | 200 Success, 401 Unauthorized, 404 Not Found
https://registone-api.herokuapp.com/api/log/title/{title} | GET | This terminal returns records by title | 200 Success, 401 Unauthorized, 404 Not Found
https://registone-api.herokuapp.com/api/log/level/{level} | GET | This terminal returns records by level | 200 Success, 401 Unauthorized, 404 Not Found 
https://registone-api.herokuapp.com/api/log/origin/{origin} | GET | This terminal returns records by origin | 200 Success, 401 Unauthorized, 404 Not Found 
https://registone-api.herokuapp.com/api/log/{id} | PUT | This endpoint archives a record by ID | 200 Success, 401 Unauthorized, 404 Not Found 
https://registone-api.herokuapp.com/api/log/{id} | DELETE |This endpoint deletes a record by ID | 200 Success, 401 Unauthorized, 404 Not Found

### Give a Star! ⭐
If you liked the project,  please give a star :)
